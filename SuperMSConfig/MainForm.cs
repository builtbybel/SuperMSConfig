using SuperMSConfig.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using Templates;
using static BaseHabit;

namespace SuperMSConfig
{
    public partial class MainForm : Form
    {
        private Logger logger;
        private HabitChecker habitChecker;
        private PluginLoader pluginLoader; // PluginLoader instance
        private bool isPanel1Visible = false; 

        private List<ListViewItem> allItems = new List<ListViewItem>();
        private string creatorsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "source");
        private bool isTemplateLoaded = false; // Flag to track if a template is loaded


        public MainForm()
        {
            InitializeComponent();
            InitializeLoggerAndHabitChecker();
            InitializeNativeCategories();
            InitializePluginLoader();

            Task.Run(() => LoadTemplatesIntoDropdown(toolStripComboTemplates, creatorsFolderPath));  // Initialize Templates
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Initialize basic UI settings
            SetFormTitle(); // Admin or User mode
            SetStyle(); // Set the UI style
            GetGreeting(); // Get the greeting based on the time of day
            ShowRandomPlugin(); // Show a random plugin
        }

        private void InitializeLoggerAndHabitChecker()
        {
            // Create the Logger
            logger = new Logger(this);

            // Initialize the HabitChecker with the Logger
            habitChecker = new HabitChecker(logger);
        }

        private void InitializePluginLoader()
        {
            pluginLoader = new PluginLoader(this, extensionsMenuStrip);
        }

        private void GetGreeting()
        {
            int hour = DateTime.Now.Hour;

            if (hour >= 5 && hour < 12)
                rtbCheckNote.Rtf = @"{\rtf1\ansi\pard\qc\fs42\b Hello, good morning!\b0\par}";
            else if (hour >= 12 && hour < 22)
                rtbCheckNote.Rtf = @"{\rtf1\ansi\pard\qc\fs42\b Hello, good afternoon!\b0\par}";
            else
                rtbCheckNote.Rtf = @"{\rtf1\ansi\pard\qc\fs42\b Hello, good evening!\b0\par}";
        }

        private void SetStyle()
        {
            // Background color
            BackColor =
                 Color.FromArgb(248, 249, 251);
            panelMain.BackColor =
            habitListView.BackColor =
            rtbCheckNote.BackColor =
            rtbLog.BackColor =
                  Color.FromArgb(253, 247, 248);
            // Segoe MDL2 Assets
            assetMenu.Text = "\u2630";
            assetMenuSettings.Text = "\uE712";
            // Set the ListView columns
            habitListView.Columns.Add("Configurations", -2);
            // Enable double buffering to reduce flickering in the ListView
            EnableDoubleBuffering(habitListView);
        }

        // Enable double buffering to reduce flickering in the habitListView
        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void InitializeNativeCategories()
        {
            comboBoxMSConfig.Items.Add("OOBE"); // All configs

            foreach (var category in habitChecker.GetCategoryNames())
            {
                comboBoxMSConfig.Items.Add(category);
            }

            // default to "OOBE"
            comboBoxMSConfig.SelectedIndex = 0;
        }

        private void ShowRandomPlugin()
        {
            // Get the random plugin name and set it to lblRandomPlugin
            string randomPlugin = pluginLoader.GetRandomPlugin();
            linkRandomPlugin.Text = $"Did you know? The '{randomPlugin}' plugin can enhance your experience! Click to learn more.";

            // Set up click event to open the plugin when the label is clicked
            linkRandomPlugin.Click += (s, e) =>
            {
                pluginLoader.OpenPlugin(randomPlugin);
            };
        }

        private void SetFormTitle()
        {
            bool isAdmin = Utils.IsRunningAsAdmin();
            this.Text = isAdmin ? "SuperMSConfig" : "SuperMSConfig: (No Admin)";
        }

        private async Task ProcessHabit(BaseHabit habit, ListView habitListView, List<ListViewItem> allItems)
        {
            await habit.Check();

            var displayText = $"{habit.Description} ({habit.GetDetails()})";
            var listItem = new ListViewItem(displayText)
            {
                Tag = habit,
                ForeColor = habitChecker.GetColorForStatus(habit.Status)
            };

            habitListView.Items.Add(listItem);
            allItems?.Add(listItem);

            listItem.EnsureVisible();
        }

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            await LoadHabits();
        }

        private async Task LoadHabits()
        {
            rtbCheckNote.Visible = false;
            btnCheck.Enabled = false;
            habitListView.Visible =
            panelSettings.Visible = true;
            btnCheck.Text = "Checking...";
            btnCheck.Image = null;

            habitListView.Items.Clear();
            rtbLog.Clear();
            allItems.Clear();

            string selectedCategory = comboBoxMSConfig.SelectedItem.ToString();

            List<BaseHabit> habits = selectedCategory == "OOBE"
                ? await habitChecker.GetAllHabits()
                : await habitChecker.GetHabitsByCategory(selectedCategory);

            int goodHabitsCount = 0;
            int badHabitsCount = 0;

            foreach (var habit in habits)
            {
                await ProcessHabit(habit, habitListView, allItems);

                if (habit.Status == HabitStatus.Bad)
                {
                    badHabitsCount++;
                }
                else if (habit.Status == HabitStatus.Good)
                {
                    goodHabitsCount++;
                }
            }

            btnCheck.Enabled = true;
            btnCheck.Text = "Check";
            habitListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            ShowResults(goodHabitsCount, badHabitsCount);
        }

        private void ShowResults(int goodHabitsCount, int badHabitsCount)
        {
            MessageBox.Show(
                $"🎉 System Scan Complete!\n\n✅ Good Config: {goodHabitsCount}\n❌ Bad Config: {badHabitsCount}",
                "Results",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private async void lblFix_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (habitListView.CheckedItems.Count == 0)
            {
                MessageBox.Show("No items are checked for fixing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Prompt before proceeding
            var result = MessageBox.Show("Are you sure you want to fix the selected items? This will update their status.", "Confirm Fix", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (ListViewItem item in habitListView.CheckedItems)
                {
                    // Get the habit associated with the item
                    var habit = item.Tag as BaseHabit;
                    if (habit != null)
                    {
                        try
                        {
                            // Call Fix regardless of status
                            await habit.Fix();
                            // Log the fix action
                            logger.Log($"Fixed: {habit.Description}", Color.Green, habit.GetDetails());
                        }
                        catch (Exception ex)
                        {
                            // Log any errors encountered
                            logger.Log($"Error fixing {habit.Description}: {ex.Message}", Color.Red, ex.StackTrace);
                        }
                    }
                }

                var reloadResult = MessageBox.Show("All fixed!\n\nDo you want to reload msconfig to reflect the updated status?", "Reload msconfig", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (reloadResult == DialogResult.Yes)
                {
                    if (isTemplateLoaded)
                    {
                        // Update only the template entries if a template is loaded
                        await ReloadTemplate();
                    }
                    else
                    {
                        // Reload default habits to reflect the updated status
                        await LoadHabits();
                    }
                }
            }
        }

        private async void lblRestore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (habitListView.CheckedItems.Count == 0)
            {
                MessageBox.Show("No items are checked for reverting.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Confirm before reverting
            var result = MessageBox.Show("Are you sure you want to revert the selected items?", "Confirm Revert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (ListViewItem item in habitListView.CheckedItems)
                {
                    var habit = item.Tag as BaseHabit;
                    if (habit != null)
                    {
                        try
                        {
                            // Call Revert regardless of status
                            await habit.Revert();
                            logger.Log($"Reverted: {habit.Description}", Color.Blue, habit.GetDetails());
                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show(ex.Message, "Revert Not Possible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Reload the data to reflect changes
                var reloadResult = MessageBox.Show("All reverted!\n\nDo you want to reload msconfig to reflect the updated status?", "Reload msconfig", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (reloadResult == DialogResult.Yes)
                {
                    if (isTemplateLoaded)
                    {
                        // Update only the template entries if a template is loaded
                        await ReloadTemplate();
                    }
                    else
                    {
                        await LoadHabits();
                    }
                }
            }
        }

        // Process the imported template
        private async Task ProcessImportedFile(List<HabitTemplate> templates)
        {
            var habitFactory = new HabitFactory();
            int goodHabitsCount = 0;
            int badHabitsCount = 0;

            try
            {
                foreach (var template in templates)
                {
                    var habit = habitFactory.CreateHabit(template, logger);
                    await ProcessHabit(habit, habitListView, null);

                    if (habit.Status == HabitStatus.Bad)
                    {
                        badHabitsCount++;
                    }
                    else if (habit.Status == HabitStatus.Good)
                    {
                        goodHabitsCount++;
                    }
                }

                ShowResults(goodHabitsCount, badHabitsCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading templates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTemplatesIntoDropdown(ToolStripComboBox comboBox, string folderPath)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("..."); // Placeholder entry
            comboBox.SelectedIndex = 0;

            // Loading templates in the background
            try
            {
                if (Directory.Exists(folderPath))
                {
                    var files = await Task.Run(() => Directory.GetFiles(folderPath, "*.json"));

                    // After the files are loaded, we can safely update the UI on the main thread...
                    foreach (var file in files)
                    {
                        comboBox.Items.Add(Path.GetFileNameWithoutExtension(file));
                    }
                }
                else
                {
                    MessageBox.Show($"Directory '{folderPath}' does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading templates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ReloadTemplate()
        {
            if (toolStripComboTemplates.SelectedItem != null && toolStripComboTemplates.SelectedIndex > 0) // Ensure a valid template is selected
            {
                rtbCheckNote.Visible =
                searchTextBox.Visible =
                cbShowOnlyBadHabits.Visible = false;
                habitListView.Items.Clear();

                string selectedFileName = toolStripComboTemplates.SelectedItem.ToString();
                string selectedFilePath = Path.Combine(creatorsFolderPath, selectedFileName + ".json");

                if (File.Exists(selectedFilePath))
                {
                    try
                    {
                        // Load the template file (including header and entries)
                        var templateLoader = new TemplateLoader();
                        var templateFile = templateLoader.LoadTemplateFile(selectedFilePath);

                        if (templateFile != null)
                        {
                            // Show description
                            MessageBox.Show(templateFile.Header, "Template Description", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Text = $"SuperMSConfig - @{selectedFileName}";

                            // Process the template's entries
                            await ProcessImportedFile(templateFile.Entries);

                            // Set the flag to true
                            isTemplateLoaded = true;
                        }
                        else
                        {
                            MessageBox.Show("Failed to load the template file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing template file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The selected template file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetHabitDetails()
        {
            try
            {
                if (habitListView.SelectedItems.Count > 0)
                {
                    // Retrieve the selected habit from the ListViewItem's Tag
                    var selectedHabit = habitListView.SelectedItems[0].Tag as BaseHabit;

                    if (selectedHabit != null)
                    {
                        // Display the habit details
                        lblDescription.Text = selectedHabit.Description;
                        rtbLog.Text = selectedHabit.GetDetails();

                        // Update the radio buttons based on habit status
                        switch (selectedHabit.Status)
                        {
                            case HabitStatus.Good:
                                rbGood.Checked = true;
                                rbBad.Checked = false;
                                rbNotConfigured.Checked = false;
                                break;

                            case HabitStatus.Bad:
                                rbGood.Checked = false;
                                rbBad.Checked = true;
                                rbNotConfigured.Checked = false;
                                break;

                            case HabitStatus.NotConfigured:
                                rbGood.Checked = false;
                                rbBad.Checked = false;
                                rbNotConfigured.Checked = true;
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The selected item is not a valid habit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // MessageBox.Show("Please select a habit to open it in the editor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the habit editor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void habitListView_Click(object sender, EventArgs e)
        {
            GetHabitDetails();
        }

        private async void toolStripComboTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            await ReloadTemplate();
        }

        // Filter bad items ONLY
        private void FilterAndDisplayItems()
        {
            habitListView.Items.Clear();

            var filteredItems = allItems.Where(item =>
                !cbShowOnlyBadHabits.Checked || ((BaseHabit)item.Tag).Status == HabitStatus.Bad).ToList();

            foreach (var item in filteredItems)
            {
                habitListView.Items.Add(item);
            }
        }

        private void cbShowOnlyBadHabits_CheckedChanged(object sender, EventArgs e)
        {
            FilterAndDisplayItems();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.ToLower();
            habitListView.Items.Clear();

            foreach (var item in allItems)
            {
                if (item.Text.ToLower().Contains(searchText))
                {
                    habitListView.Items.Add(item);
                }
            }
        }

        private void searchTextBox_Click(object sender, EventArgs e)
        {
            searchTextBox.Clear();
        }

        private void assetMenuSettings_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool allSelected = true;

            foreach (ListViewItem item in habitListView.Items)
            {
                if (!item.Checked)
                {
                    allSelected = false;
                    break;
                }
            }

            foreach (ListViewItem item in habitListView.Items)
            {
                item.Checked = !allSelected;
            }
        }

        private void selectBadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in habitListView.Items)
            {
                if (item.Tag is BaseHabit habit)
                {
                    item.Checked = habit.Status == HabitStatus.Bad;
                }
            }
        }

        private void selectNotConfiguredOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in habitListView.Items)
            {
                if (item.Tag is BaseHabit habit)
                {
                    item.Checked = habit.Status == HabitStatus.NotConfigured;
                }
            }
        }

        // Apply the fix or revert based on the rb button selected
        private async Task ApplyFixOrRevert(bool isFix)
        {
            try
            {
                if (habitListView.SelectedItems.Count > 0)
                {
                    var selectedHabit = habitListView.SelectedItems[0].Tag as BaseHabit;
                    if (selectedHabit != null)
                    {
                        if (isFix)
                        {
                            await selectedHabit.Fix();
                            // MessageBox.Show("The habit is fixed.");
                        }
                        else
                        {
                            await selectedHabit.Revert();
                            //  MessageBox.Show("The habit was reverted.");
                        }
                        // Update color based on the habit's status
                        habitListView.SelectedItems[0].ForeColor = habitChecker.GetColorForStatus(selectedHabit.Status);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while applying the habit changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void rbBad_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBad.Checked)
            {
                await ApplyFixOrRevert(isFix: false);
            }
        }

        private async void rbGood_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGood.Checked)
            {
                await ApplyFixOrRevert(isFix: true);
            }
        }

        private void assetMenu_Click(object sender, EventArgs e)
        {
            isPanel1Visible = !isPanel1Visible;
            splitContainer.Panel1Collapsed = !isPanel1Visible;

            if (isPanel1Visible)
            {
                var getStartedPage = new GetStartedPage();
                panelSplitter.Controls.Clear();
                panelSplitter.Controls.Add(getStartedPage);
                getStartedPage.Dock = DockStyle.Fill;
            }
            else
            {
                panelSplitter.Controls.Clear();
            }
        }

        private void assetMenuExtensions_Click(object sender, System.EventArgs e)
        {
            this.extensionsMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void linkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/builtbybel/SuperMSConfig");
        }
    }
}