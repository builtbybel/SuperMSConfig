using Newtonsoft.Json;
using PluginInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCleanupCompanion
{
    public partial class MSCCPluginControl : UserControl, IPlugin
    {
        private List<AppInfo> originalAppsInfo = new List<AppInfo>();
        private bool selectAll = true;

        public UserControl GetControl()
        {
            return this;
        }

        public string PluginName => "Microsoft Cleanup Companion";
        public string PluginVersion => "1.0";
        public string PluginInfo => "This Plugin is a powerful tool designed to streamline and optimize your Windows 10/11 experience. With advanced community-driven detection capabilities, this plugin allows you to easily identify and remove unnecessary bloatware, enhancing system performance and freeing up valuable resources.";

        private void ShowPluginInfo()
        {
            string pluginDetails = $"{PluginName}\n" +
                                   $"Version: {PluginVersion}\n\n" +
                                   $"{PluginInfo}";

            MessageBox.Show(pluginDetails, "Plugin Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public class AppInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string RemoveCommand { get; set; }

            public override string ToString()
            {
                return $"{Name} - {Description}";
            }
        }

        public MSCCPluginControl()
        {
            InitializeComponent();
            SetStyle();
        }

        private void SetStyle()
        {
            // Segoe MDL2 Assets font
            mdlMenu.Text = "\uE712";

            // BackColor
            BackColor =
            checkedListBoxApps.BackColor =
               Color.FromArgb(250, 251, 247);
        }

        private async void toolDebloaterPageView_Load(object sender, EventArgs e)
        {
            await ScanApps();
        }

        private async Task ScanApps()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins\\PluginMSCleanupCompanion", "MSCleanupCompanion.json");
            await LoadAppsFromJson(jsonFilePath);
        }

        private async Task LoadAppsFromJson(string jsonFilePath)
        {
            installedToolStripMenuItem.Enabled = false; // Disable showing all apps checkbox during loading

            try
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                originalAppsInfo = JsonConvert.DeserializeObject<List<AppInfo>>(jsonString);

                checkedListBoxApps.Items.Clear();
                bool bloatwareFound = false;

                foreach (var appInfo in originalAppsInfo)
                {
                    bool isInstalled = await IsAppInstalled(appInfo.Name);
                    if (isInstalled)
                    {
                        checkedListBoxApps.Items.Add(appInfo, false);
                        bloatwareFound = true;
                    }
                }

                // Display message if no bloatware is found
                if (!bloatwareFound)
                {
                    lblStatus.Text = "No unnecessary apps found.";
                    lblStatus.BackColor = Color.PaleGreen;
                    lblStatus.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading JSON file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            installedToolStripMenuItem.Enabled = true;
        }

        // The manual way to load all installed apps and remove
        private async Task LoadAllInstalledApps()
        {
            try
            {
                checkedListBoxApps.Items.Clear();
                originalAppsInfo.Clear();

                using (PowerShell powerShell = PowerShell.Create())
                {
                    powerShell.AddScript("Get-AppxPackage | Select-Object Name, PackageFullName");
                    var results = await Task.Run(() => powerShell.Invoke());

                    foreach (var result in results)
                    {
                        var appName = result.Members["Name"].Value.ToString();
                        var appPackageFullName = result.Members["PackageFullName"].Value.ToString();
                        var appInfo = new AppInfo { Name = appName, Description = appPackageFullName, RemoveCommand = $"Get-AppxPackage -Name {appName} | Remove-AppxPackage" };
                        originalAppsInfo.Add(appInfo);
                        checkedListBoxApps.Items.Add(appInfo, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading installed apps: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> IsAppInstalled(string appName)
        {
            lblStatus.BackColor = Color.FromArgb(234,240,227);
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            bool isInstalled = false;
            try
            {
                lblStatus.Text = $"Checking {appName}...";
                using (PowerShell powerShell = PowerShell.Create())
                {
                    powerShell.AddScript($"Get-AppxPackage -Name *{appName}*");
                    var results = await Task.Run(() => powerShell.Invoke());

                    isInstalled = results.Count > 0;
                }
                lblStatus.Text = $"{appName} Check completed.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking app {appName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblStatus.Text = "Check completed.";
            return isInstalled;
        }

        private async Task ExecutePowerShellCommand(string command)
        {
            try
            {
                using (PowerShell ps = PowerShell.Create())
                {
                    ps.AddScript(command);
                    await Task.Run(() => ps.Invoke());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing PowerShell command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            // Ensure at least one app is checked
            if (checkedListBoxApps.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one app to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Disable delete button during deletion process
            btnRemoveSelected.Enabled = false;

            // Create a copy of checked items to iterate over
            var checkedItems = checkedListBoxApps.CheckedItems.Cast<AppInfo>().ToList();

            // Iterate through checked items and execute remove command asynchronously
            foreach (var checkedItem in checkedItems)
            {
                AppInfo appInfo = checkedItem as AppInfo;
                if (appInfo != null)
                {
                    // Removing
                    lblStatus.Text = $"Removing {appInfo.Name}...";
                    await ExecutePowerShellCommand(appInfo.RemoveCommand);
                    lblStatus.Text = $"{appInfo.Name}  removed.";

                    // Remove the app from CheckedListBox after deletion
                    checkedListBoxApps.Items.Remove(appInfo);
                }
            }

            // Re-enable delete button after deletion process completes
            btnRemoveSelected.Enabled = true;

            lblStatus.Text = "Apps successfully removed.";
            MessageBox.Show("Apps successfully removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Select all or deselect all apps
        private void selectAllStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxApps.Items.Count; i++)
            {
                checkedListBoxApps.SetItemChecked(i, selectAll);
            }
            selectAll = !selectAll;
            selectAllToolStripMenuItem.Text = selectAll ? "Select all" : "Deselect all";
        }

        // Show all installed apps
        private async void installedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle the check state
            installedToolStripMenuItem.Checked = !installedToolStripMenuItem.Checked;

            if (installedToolStripMenuItem.Checked)
            {
                // Load all installed apps
                await LoadAllInstalledApps();
            }
            else
            {
                // Load bloatware from JSON db
                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins\\PluginMSCleanupCompanion", "MSCleanupCompanion.json");
                await LoadAppsFromJson(jsonFilePath);
            }
        }

        // Load custom JSON database
        private async void customDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files|*.json";
            openFileDialog.Title = "Select a JSON file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string jsonFilePath = openFileDialog.FileName;
                await LoadAppsFromJson(jsonFilePath);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();
            checkedListBoxApps.Items.Clear();

            foreach (var appInfo in originalAppsInfo)
            {
                if (appInfo.Name.ToLower().Contains(searchText) || appInfo.Description.ToLower().Contains(searchText))
                {
                    checkedListBoxApps.Items.Add(appInfo, false);
                }
            }
        }

        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
        }

        private void mdlMenu_Click(object sender, EventArgs e)
        {
            this.contextMenu.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void pluginInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPluginInfo();
        }

        private async void scanAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ScanApps();
        }
    }
}