using Microsoft.Win32;
using System;
using System.Drawing;
using System.Security;
using System.Threading.Tasks;

namespace SuperMSConfig
{
    public class RegistryHabit : BaseHabit
    {
        private readonly RegistryHive hive;
        private readonly string keyPath;
        private readonly string valueName;
        private readonly object badValue;
        private readonly object goodValue;
        private readonly string description;
        private readonly Logger logger;
        private readonly RegistryValueKind valueKind;

        public RegistryHabit(
            RegistryHive hive,
            string keyPath,
            string valueName,
            object badValue,
            object goodValue,
            string description,
            string valueType,
            Logger logger)
        {
            this.hive = hive;                    // Store the registry hive
            this.keyPath = keyPath;              // Store the registry key path
            this.valueName = valueName;          // Store the name of the value in the registry
            this.badValue = badValue;            // Value considered "bad"
            this.goodValue = goodValue;          // Value considered "good"
            this.description = description;      // Description of the registry habit
            this.logger = logger;                // Logger instance to write logs

                                                
            valueKind = GetRegistryValueKind(valueType);  // Determine the RegistryValueKind based on the valueType

            // Log creation of the RegistryHabit instance
            //  this.logger.Log($"RegistryHabit created: {Name}, Path: {keyPath}", Color.Green);
        }

        public override string Name => $"Registry Key: {valueName}";
        public override string Description => description;

        public override HabitStatus Status { get; set; } = HabitStatus.NotConfigured;

        public override string GetDetails()
        {
            return $"Registry Path: {hive}\\{keyPath}, Value Name: {valueName}, Current Value: {GetCurrentValue()}, Bad Value: {badValue}, Good Value: {goodValue}";
        }

        // hex strings like "ffffffff" = DWORD format (so this is 32-bit integer)
        // values like "ffffffff", should return -1 as a DWORD since 0xFFFFFFFF represents -1 in signed 32-bit integers in DWORD
        // GoodValue or BadValue is "00000020", so it should be written as a DWORD with the value 32
        public override async Task Check()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (var key = OpenRegistryKey())
                    {
                        if (key == null)
                        {
                            Status = HabitStatus.NotConfigured;
                            logger.Log($"Key not found: {keyPath}. Status: Not Configured", Color.Blue);
                            return;
                        }

                        var currentValue = key.GetValue(valueName);

                        if (currentValue == null)
                        {
                            Status = HabitStatus.NotConfigured;
                            logger.Log($"Registry value is missing and not configured.", Color.Blue);
                            return;
                        }

                        if (valueKind == RegistryValueKind.DWord && int.TryParse(currentValue.ToString(), out int currentIntValue))
                        {
                            int badIntValue = Convert.ToInt32(badValue);
                            int goodIntValue = Convert.ToInt32(goodValue);

                            if (currentIntValue == badIntValue)
                            {
                                // Set IsBad based on whether current value matches badValue
                                Status = HabitStatus.Bad;
                            }
                            // If the current value matches the good value, reset IsBad to false, so a goo status again
                            else if (currentIntValue == goodIntValue)
                            {
                                Status = HabitStatus.Good;
                            }
                        }
                        else     // Handle non-DWORD (string or other) value comparison
                        {
                            if (currentValue.ToString() == badValue.ToString())
                            {
                                Status = HabitStatus.Bad;
                            }
                            else if (currentValue.ToString() == goodValue.ToString())
                            {
                                Status = HabitStatus.Good;
                            }
                        }

                        logger.Log($"Checked {Name}. Status: {Status}",
                            Status == HabitStatus.Bad ? Color.Red : (Status == HabitStatus.Good ? Color.Green : Color.Blue),
                            GetDetails());
                    }
                });
            }
            catch (Exception ex)
            {
                logger.Log($"Error during Check: {ex.Message}", Color.Red, ex.StackTrace);
            }
        }

        public override async Task Fix()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (var key = OpenRegistryKey(true))
                    {
                        if (key != null)
                        {
                            // Convert the goodValue based on valueKind
                            object valueToSet = ConvertValueToType(goodValue);

                            // Create/update the value in the registry
                            key.SetValue(valueName, valueToSet, valueKind);
                            Status = HabitStatus.Good; // Marks state as good, so fix has been applied
                        }
                    }

                    logger.Log($"Fixed {Name}", Color.Green, GetDetails());
                });
            }
            catch (Exception ex)
            {
                logger.Log($"Error during Fix: {ex.Message}", Color.Red, ex.StackTrace);
            }
        }

        public override async Task Revert()
        {
            try
            {
                await Task.Run(() =>
                {
                    RegistryKey rootKey = hive == RegistryHive.CurrentUser ? Registry.CurrentUser : Registry.LocalMachine;

                    using (var key = OpenRegistryKey(true))
                    {
                        if (key != null)
                        {
                            // DELETE the key if the badValue is DELETE
                            if (badValue != null && badValue.ToString().Equals("DELETE", StringComparison.OrdinalIgnoreCase))
                            {    // Close the key before deleting it
                                key.Close();
                                try
                                {
                                    // Delete the entire key tree from the correct hive
                                    DeleteKeyTree(rootKey, keyPath);
                                    logger.Log($"Successfully deleted registry key: {keyPath}", Color.Green);
                                }
                                catch (Exception ex)
                                {
                                    logger.Log($"Error during DeleteKeyTree: {ex.Message}", Color.Red, ex.StackTrace);
                                }
                            }
                            else
                            {
                                // Convert the badValue based on valueKind
                                object valueToSet = ConvertValueToType(badValue);

                                // Create or update the value in the registry key
                                key.SetValue(valueName, valueToSet, valueKind);
                            }

                            Status = HabitStatus.Bad;
                        }
                        else
                        {
                            logger.Log($"Failed to open registry key: {keyPath}", Color.Red);
                        }
                    }

                    logger.Log($"Reverted {Name}", Color.Orange, GetDetails());
                });
            }
            catch (Exception ex)
            {
                logger.Log($"Error during Revert: {ex.Message}", Color.Red, ex.StackTrace);
            }
        }

        // Delete the key and all its subkeys from the correct hive
        private void DeleteKeyTree(RegistryKey rootKey, string keyPath)
        {
            try
            {
                rootKey.DeleteSubKeyTree(keyPath, false);
            }
            catch (Exception ex)
            {
                logger.Log($"Error during DeleteKeyTree: {ex.Message}", Color.Red, ex.StackTrace);
            }
        }

        //  Check if the key path exists and opens it
        //  If not, it creates the key with full read/write permissions
        private RegistryKey OpenRegistryKey(bool writable = false)
        {
            var rootKey = hive == RegistryHive.CurrentUser ? Registry.CurrentUser : Registry.LocalMachine;
            try
            {
                // Attempt to open the key in the specified mode (read/write or read-only)
                var key = rootKey.OpenSubKey(keyPath, writable);

                // If the key does not exist and we need write access, create it
                if (key == null && writable)
                {
                    key = rootKey.CreateSubKey(keyPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
                }
                return key;
            }
            catch (SecurityException)
            {
                //lack of permissions
                return null;
            }
        }

        private object GetCurrentValue()
        {
            using (var key = OpenRegistryKey())
            {
                return key?.GetValue(valueName);
            }
        }

        /// <summary>
        /// Converts the value to the appropriate type based on registry value kind.
        /// Parses hexadecimal numbers for DWord/QWord; otherwise returns the value as a string.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        ///
        private object ConvertValueToType(object value)
        {
            if (value == null)
                return null;

            if (valueKind == RegistryValueKind.DWord)
            {
                // If value -1, convert it to 0xFFFFFFFF
                if (Convert.ToInt32(value) == -1)
                {
                    return unchecked((int)0xFFFFFFFF);
                }
                return Convert.ToInt32(value); // Normal Conversion to DWORD(32 - Bit Integer)
            }

            return value.ToString(); // return string for other types
        }

        /// <summary>
        /// Returns the RegistryValueKind based on the specified value type string.
        /// </summary>
        /// <param name="valueType">The type of registry value (e.g., "DWORD", "STRING").</param>
        /// <returns>The corresponding RegistryValueKind.</returns>
        ///
        private RegistryValueKind GetRegistryValueKind(string valueType)
        {
            switch (valueType.ToUpper())
            {
                case "DWORD":
                    return RegistryValueKind.DWord;
                case "STRING":
                    return RegistryValueKind.String;
                default:
                    return RegistryValueKind.String; // Default to string
            }
        }
    }
}
