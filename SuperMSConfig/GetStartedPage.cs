using System;
using System.Drawing;
using System.Windows.Forms;

namespace SuperMSConfig
{
    public partial class GetStartedPage : UserControl
    {
        private int currentStep = 0;

        private string[] stepsDescriptions = new[]
{
            "SuperMSConfig revisits the out-of-box setup, letting you fine-tune the Windows 11 post-installation experience. Whether it’s disabling intrusive features or optimizing services, it provides full control over how your system behaves immediately after setup. " +
            "\n\nGot questions? Just click the Copilot icon!",

            "The 'OOBE' scan reviews all default system configuration categories, as well as over 10 additional areas for potential misconfigurations." +
            "You can personalize the scan by selecting specific categories using the dropdown. " +
            "\n\nClick 'Check' to begin the scan.",

            "After a successful scan, you can view the results directly. Good configurations are grayed out," +
            " non-configured settings are highlighted in orange, and bad configurations are marked in red. " +
            "Clicking on an entry also updates the status in the three small radio buttons at the bottom left.",

            "Besides the native scan, you can map any other tweaks you want. " +
            "Whether it's a recommended config from Neowin or Deskmodder, " +
            "or from an app like Bloatynosy, the magic lies in '... Settings > Load config from source'." +
            "For more details on how it works and to add more tweaks, check the 'source' folder of the app."
        };

        private string[] stepsHeader = new[]
  {
            "Welcome",
            "Step 1: Let's customize your experience",
            "Step 2: Review the results",
            "Step 3: Load additional tweaks"
        };

        public GetStartedPage()
        {
            InitializeComponent();
            SetStyle();
            UpdateStep();
            BackColor = Color.FromArgb(249, 249, 251);
        }

        private void SetStyle()
        {
            // Segoe MDL2 Assets
            btnBack.Text = "\uE76B";
            btnNext.Text = "\uE76C";
        }

        private void UpdateStep()
        {
            lblDescription.Text = stepsDescriptions[currentStep];
            lblHeader.Text = stepsHeader[currentStep];
            btnBack.Enabled = currentStep > 0;
            btnNext.Text = currentStep < stepsDescriptions.Length - 1 ? "\uE76C" : "\uE73E";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (currentStep > 0)
            {
                currentStep--;
                UpdateStep();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentStep < stepsDescriptions.Length - 1)
            {
                currentStep++;
                UpdateStep();
            }
            else
            {
                MessageBox.Show("Thanks for taking the time to get to know SuperMSConfig! Your system's new configuration awaits.");
            }
        }
    }
}
