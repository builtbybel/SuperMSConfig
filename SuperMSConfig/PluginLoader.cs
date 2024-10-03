using PluginInterface;
using SuperMSConfig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

public class PluginLoader
{
    private ContextMenuStrip extensionsMenuStrip;
    private Dictionary<string, string> pluginPaths;
    private List<string> loadRandomPlugin = new List<string>(); // Keep track of randomly loaded plugins

    private Form pluginsForm; // Form to hold plugins
    private Panel pluginPanel;
    private Form mainForm; // Reference to the main "MainForm" form

    private string unblockFileIndicator; // Path for the unblock indicator file

    public PluginLoader(Form mainForm, ContextMenuStrip menuStrip)
    {
        this.mainForm = mainForm;
        extensionsMenuStrip = menuStrip;
        pluginPaths = new Dictionary<string, string>();
        unblockFileIndicator = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins", "unblockIndicator.txt");

        // Initialize PluginsForm
        InitializePluginsForm();

        // Hook into the LocationChanged event of the main form to keep PluginsForm aligned
        mainForm.LocationChanged += (sender, e) => PositionPluginsForm();

        LoadAllPlugins(); // Load all plugins when initializing
    }

    private void InitializePluginsForm()
    {
        pluginsForm = new Form
        {
            Size = new Size(400, mainForm.Height), 
            StartPosition = FormStartPosition.Manual, // Position it manually next to the main form
            FormBorderStyle = FormBorderStyle.Sizable,
            ShowInTaskbar = false,
            ShowIcon = false,
            TopMost = true,
        };

        // Create the panel inside PluginsForm
        pluginPanel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White
        };
        pluginsForm.Controls.Add(pluginPanel);

        // Handle the FormClosing event to prevent disposal
        pluginsForm.FormClosing += (sender, e) =>
        {
            e.Cancel = true;  // Prevent the form from being closed
            pluginsForm.Hide();  // Just hide the form instead of closing it
        };

        PositionPluginsForm(); // Set the initial position
    }

    private void PositionPluginsForm()
    {
        // Position PluginsForm to the right of the main form
        if (pluginsForm != null && !pluginsForm.IsDisposed)
        {
            pluginsForm.Location = new Point(mainForm.Location.X + mainForm.Width - 10, mainForm.Location.Y); // 10 is the gap
        }
    }

    private bool IsFileUnblocked(string filePath)
    {
        // Check if the unblock indicator file exists
        return File.Exists(unblockFileIndicator) && File.ReadAllLines(unblockFileIndicator).Contains(filePath);
    }

    private void UnblockFile(string filePath)
    {
        if (!IsFileUnblocked(filePath))
        {
            string cmd = $"Unblock-File -Path '{filePath}'";
            Process.Start(new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = cmd,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }).WaitForExit();

            File.AppendAllText(unblockFileIndicator, filePath + Environment.NewLine);
        }
    }

    public bool LoadPlugin(string pluginPath)
    {
        if (!File.Exists(pluginPath))
        {
            MessageBox.Show($"{pluginPath} DLL not found!");
            return false;
        }

        try
        {
            var assembly = Assembly.LoadFrom(pluginPath);
            bool pluginLoaded = false;

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                {
                    IPlugin pluginInstance = (IPlugin)Activator.CreateInstance(type);
                    UserControl pluginControl = pluginInstance.GetControl();
                    pluginControl.Dock = DockStyle.Fill;

                    pluginPanel.Controls.Clear(); // Clear previous plugin content
                    pluginPanel.Controls.Add(pluginControl);

                    // Set plugin name in PluginsForm title
                    pluginsForm.Text = $"{pluginInstance.PluginName}";

                    pluginLoaded = true;
                    break;
                }
            }

            if (!pluginLoaded)
            {
                MessageBox.Show($"No valid plugin found in {pluginPath} DLL.");
                return false;
            }

            // Show the PluginsForm and position it correctly
            if (!pluginsForm.Visible)
            {
                pluginsForm.Show();
                PositionPluginsForm();
            }

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading plugin from {pluginPath}: {ex.Message}");
            return false;
        }
    }

    public void LoadAllPlugins()
    {
        loadRandomPlugin.Clear(); // Clear the list before loading
        extensionsMenuStrip.Items.Clear(); // Clear previous items

        // Attach "App-Info" ToolStripMenuItem
        ToolStripMenuItem appInfoItem = new ToolStripMenuItem
        {
            Text = "App-Info",
            Font = new Font("Segoe UI Variable Small", 9F, FontStyle.Bold), // Smaller font size
            ForeColor = Color.DimGray,
            AutoSize = true,
        };

        appInfoItem.Click += (sender, e) =>
        {
            new AboutForm().ShowDialog();
        };  // Add the app info item to the extensions menu
        extensionsMenuStrip.Items.Add(appInfoItem);

        string pluginDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");

        if (Directory.Exists(pluginDirectory))
        {
            // Get all plugin directories in the "plugins" folder
            foreach (string subDir in Directory.GetDirectories(pluginDirectory))
            {
                // Find any DLLs in the subdirectory
                foreach (string pluginPath in Directory.GetFiles(subDir, "*.dll"))
                {
                    // Unblock the file only if the indicator file does not exist
                    UnblockFile(pluginPath);

                    try
                    {
                        var assembly = Assembly.LoadFrom(pluginPath);
                        IPlugin pluginInstance = null;

                        // Find the plugin class in the assembly
                        foreach (Type type in assembly.GetTypes())
                        {
                            if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                            {
                                pluginInstance = (IPlugin)Activator.CreateInstance(type);
                                break;
                            }
                        }

                        if (pluginInstance != null)
                        {
                            // Add the plugin name and path to the dictionary
                            string pluginName = pluginInstance.PluginName;

                            // Randomly load a plugin if it's not already in the list for MainForm
                            pluginPaths[pluginName] = pluginPath; // Store the plugin path using the plugin name
                            loadRandomPlugin.Add(pluginName); // Add the plugin name to the list

                            // Create the main menu item for the plugin
                            ToolStripMenuItem pluginMenuItem = new ToolStripMenuItem
                            {
                                Text = pluginName,
                                Font = new Font("Segoe UI Variable Small", 12F, FontStyle.Regular),
                                Padding = new Padding(1)
                            };

                            // Load the plugin on click
                            pluginMenuItem.Click += (sender, e) =>
                            {
                                pluginPanel.Controls.Clear(); // Clear previous plugin content
                                if (LoadPlugin(pluginPath))
                                {
                                    pluginPanel.Visible = true;
                                }
                            };

                            // Add the plugin to the context menu
                            extensionsMenuStrip.Items.Add(pluginMenuItem);

                            // Create a link-style entry for the plugin info
                            ToolStripMenuItem infoMenuItem = new ToolStripMenuItem
                            {
                                Text = "View Info",
                                Font = new Font("Segoe UI Variable Small", 9F, FontStyle.Underline),
                                ForeColor = Color.DeepPink,
                                Padding = new Padding(1)
                            };

                            // Show full plugin description in a message box when clicked
                            infoMenuItem.Click += (sender, e) =>
                            {
                                MessageBox.Show(pluginInstance.PluginInfo, "Plugin Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            };

                            // Add the info entry just below the plugin name
                            extensionsMenuStrip.Items.Add(infoMenuItem);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Show an error message with the plugin name
                        MessageBox.Show($"Error loading plugin from \"{pluginPath}\": {ex.Message}",
                                        "Plugin Load Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }

            LoadMsConfigMenu(); // Load msconfig tools
        }
    }

    // Just for the nostalgia, add classic msconfig tools to the context menu
    public void LoadMsConfigMenu()
    {
        ToolStripMenuItem msconfigMenuItem = new ToolStripMenuItem
        {
            Text = "MSConfig",
            Font = new Font("Segoe UI Variable Small", 12F, FontStyle.Regular),
            Padding = new Padding(5)
        };

        // Helper method to create menu items for each tool
        void AddToolMenuItem(string name, string command)
        {
            ToolStripMenuItem toolMenuItem = new ToolStripMenuItem
            {
                Text = name,
                Font = new Font("Segoe UI", 10F),
                Padding = new Padding(10)
            };

            toolMenuItem.Click += (sender, e) =>
            {
                try
                {
                    Process.Start(command); // Execute the command to open the tool
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not open {name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            msconfigMenuItem.DropDownItems.Add(toolMenuItem); // Add tool as submenu item
        }

        // Add original Windows and classic msconfig tools as submenu items
        AddToolMenuItem("About Windows", "winver");
        AddToolMenuItem("Change UAC Settings", "UserAccountControlSettings");
        AddToolMenuItem("Action Center", "wscui.cpl");
        AddToolMenuItem("Windows Troubleshooting", "msdt.exe");
        AddToolMenuItem("Computer Management", "compmgmt.msc");
        AddToolMenuItem("System Information", "msinfo32");
        AddToolMenuItem("Event Viewer", "eventvwr.msc");
        AddToolMenuItem("Programs", "appwiz.cpl");
        AddToolMenuItem("System Properties", "sysdm.cpl");
        AddToolMenuItem("Performance Monitor", "perfmon");
        AddToolMenuItem("Resource Monitor", "resmon");
        AddToolMenuItem("Task Manager", "taskmgr");
        AddToolMenuItem("Command Prompt", "cmd");
        AddToolMenuItem("Registry Editor", "regedit");
        AddToolMenuItem("Remote Assistance", "msra");
        AddToolMenuItem("System Restore", "rstrui.exe");

        // Add "msconfig" menu item to the context menu
        extensionsMenuStrip.Items.Add(msconfigMenuItem);
    }

    public void ResetPluginPanel()
    {
        pluginPanel.Controls.Clear(); // Clear the panel
    }

    // Get a random plugin name for MainForm to display
    public string GetRandomPlugin()
    {
        if (loadRandomPlugin.Count == 0)
        {
            return "No Plugins Available"; // Handle case with no plugins
        }
        Random random = new Random();
        int index = random.Next(loadRandomPlugin.Count);
        return loadRandomPlugin[index];
    }

    // Open a plugin random by its name on MainForm
    public void OpenPlugin(string pluginName)
    {
        string trimmedPluginName = pluginName.Trim();
        //  Debug.WriteLine($"Attempting to open plugin: '{trimmedPluginName}'");

        if (pluginPaths.TryGetValue(trimmedPluginName, out string pluginPath))
        {
            //Debug.WriteLine($"Plugin path found: '{pluginPath}'");

            // Load the plugin and check if it was successful
            if (LoadPlugin(pluginPath))
            {
                // Make sure to set the pluginPanel visible after loading the plugin
                pluginPanel.Visible = true;
            }
            else
            {
                // Handle failure to load the plugin
                MessageBox.Show($"Failed to load the plugin from {pluginPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show($"Plugin '{trimmedPluginName}' not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}