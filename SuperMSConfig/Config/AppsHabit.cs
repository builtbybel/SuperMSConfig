using System;
using System.Drawing;
using System.Management.Automation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMSConfig
{
    public class AppsHabit : BaseHabit
    {
        public AppsHabit(string appName, string description, Logger logger)
        {
            Name = appName;
            Description = description;
            this.logger = logger;
            Status = HabitStatus.NotConfigured; // Default status
        }

        // Override Name property
        public override string Name { get; }

        // Override Description property
        public override string Description { get; }

        // Override Status property
        public override HabitStatus Status { get; set; }

        private readonly Logger logger;

        // Override Check method
        public override async Task Check()
        {
            try
            {
                logger.Log($"Checking for {Name}...", Color.Blue);

                Status = await IsAppInstalled(Name) ? HabitStatus.Bad : HabitStatus.Good;
                logger.Log(Status == HabitStatus.Bad ? $"{Name} is installed." : $"{Name} is not installed.", Status == HabitStatus.Bad ? Color.Red : Color.Green);
            }
            catch (Exception ex)
            {
                logger.Log($"Error during Check: {ex.Message}", Color.Red, ex.StackTrace);
            }
        }

        // Override Fix method
        public override async Task Fix()
        {
            try
            {
                if (Status == HabitStatus.Bad)
                {
                    logger.Log($"Uninstalling {Name}...", Color.Blue);
                    await UninstallApp(Name);
                    Status = HabitStatus.Good; // Update status after fixing
                    logger.Log($"{Name} uninstalled successfully.", Color.Green);
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Error during Fix: {ex.Message}", Color.Red, ex.StackTrace);
            }
        }

        // Override Revert method
        public override async Task Revert()
        {
            try
            {
                string message = $"{Name} reinstall not possible. Please use the Microsoft Store";

                MessageBox.Show(message, "Revert Not Possible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                logger.Log($"Error during Revert: {ex.Message}", Color.Red, ex.StackTrace);
            }
        }

        // Override GetDetails method
        public override string GetDetails()
        {
            return $"Application Name: {Name}, Description: {Description}, Status: {Status}";
        }

        // Check if an app is installed
        private async Task<bool> IsAppInstalled(string appName)
        {
            try
            {
                using (PowerShell powerShell = PowerShell.Create())
                {
                    powerShell.AddScript($"Get-AppxPackage -Name *{appName}*");
                    var results = await Task.Run(() => powerShell.Invoke());

                    // Results?, so its installed!
                    return results.Count > 0;
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Error checking app {appName}: {ex.Message}", Color.Red, ex.StackTrace);
            }

            // Not installed
            return false;
        }

        // Uninstall an appx
        private async Task UninstallApp(string appName)
        {
            try
            {
                string uninstallCommand = $"Get-AppxPackage *{appName}* | Remove-AppxPackage";

                using (PowerShell powerShell = PowerShell.Create())
                {
                    powerShell.AddScript(uninstallCommand);
                    await Task.Run(() => powerShell.Invoke());
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Error uninstalling app {appName}: {ex.Message}", Color.Red, ex.StackTrace);
            }
        }
    }
}
