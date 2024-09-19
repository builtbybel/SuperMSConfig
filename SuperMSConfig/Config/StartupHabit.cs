using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SuperMSConfig
{
    public class StartupHabit : BaseHabit
    {
        private readonly string appName;
        private readonly string description;
        private readonly Logger logger;

        public StartupHabit(string appName, string description, Logger logger)
        {
            this.appName = appName;
            this.description = description ?? "No description provided";
            this.logger = logger;
        }

        public override string Name => appName;
        public override string Description => description;

        public override HabitStatus Status { get; set; } = HabitStatus.NotConfigured;

        public override async Task Check()
        {
            await Task.Run(() =>
            {
                try
                {
                    bool foundInHKCU = CheckRegistry(@"Software\Microsoft\Windows\CurrentVersion\Run", Registry.CurrentUser);
                    bool foundInHKLM = CheckRegistry(@"Software\Microsoft\Windows\CurrentVersion\Run", Registry.LocalMachine);

                    if (foundInHKCU || foundInHKLM)
                    {
                        Status = HabitStatus.Bad;
                    }
                    else
                    {
                        Status = HabitStatus.Good;
                    }

                    logger.Log($"Checked startup for '{appName}': {(Status == HabitStatus.Bad ? "Found" : "Not Found")}", Status == HabitStatus.Bad ? Color.Red : Color.Green);
                }
                catch (Exception ex)
                {
                    logger.Log($"Error during Check for '{appName}': {ex.Message}", Color.Red);
                }
            });
        }

        private bool CheckRegistry(string subKey, RegistryKey baseKey)
        {
            try
            {
                using (var key = baseKey.OpenSubKey(subKey))
                {
                    if (key != null)
                    {
                        var apps = key.GetValueNames();
                        return apps.Contains(appName);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Error during Check for '{appName}': {ex.Message}", Color.Red);
            }
            return false;
        }

        public override async Task Fix()
        {
            await Task.Run(() =>
            {
                try
                {
                    bool removedFromHKCU = RemoveFromRegistry(@"Software\Microsoft\Windows\CurrentVersion\Run", Registry.CurrentUser);
                    bool removedFromHKLM = RemoveFromRegistry(@"Software\Microsoft\Windows\CurrentVersion\Run", Registry.LocalMachine);

                    if (removedFromHKCU || removedFromHKLM)
                    {
                        Status = HabitStatus.Good;
                        logger.Log($"Fixed startup for '{appName}': Removed from startup", Color.Green);
                    }
                    else
                    {
                        logger.Log($"Failed to remove startup entry for '{appName}'", Color.Orange);
                    }
                }
                catch (Exception ex)
                {
                    logger.Log($"Error during Fix for '{appName}': {ex.Message}", Color.Red);
                }
            });
        }

        private bool RemoveFromRegistry(string subKey, RegistryKey baseKey)
        {
            try
            {
                using (var key = baseKey.OpenSubKey(subKey, true))
                {
                    if (key != null && Status == HabitStatus.Bad)
                    {
                        var apps = key.GetValueNames();
                        if (apps.Contains(appName))
                        {
                            key.DeleteValue(appName, false);
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Error removing from registry '{appName}': {ex.Message}", Color.Red);
            }
            return false;
        }

        public override Task Revert()
        {
            return Task.Run(() =>
            {
                try
                {
                    string message = "Revert of this action is not possible. Please enable the autostart in the application's settings.";
                    logger.Log(message, Color.Orange);
                    MessageBox.Show(message, "Revert Not Possible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    logger.Log($"Error during Revert for '{appName}': {ex.Message}", Color.Red);
                }
            });
        }

        public override string GetDetails()
        {
            return $"App Name: {appName}, Description: {description}";
        }
    }
}