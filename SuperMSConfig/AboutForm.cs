using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SuperMSConfig
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            linkVersion.Text = "Version " + Program.GetCurrentVersionTostring();
            SetStyle();
        }

        private void SetStyle()
        {
            // Set default colors
            BackColor = Color.FromArgb(243, 243, 243);
            panelBottom.BackColor = Color.FromArgb(251, 226, 81);
        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/builtbybel/SuperMSConfig");
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            string paypalUrl = "https://www.paypal.com/donate?hosted_button_id=MY7HX4QLYR4KG";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = paypalUrl,
                    UseShellExecute = true
                });
                MessageBox.Show("Thank you for your support! 💖", "Thank You!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the donation page. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string pattern = @"\((http[^\)]+)\)";        // Find link within parentheses
            string text = linkVersion.Text;

            Match match = Regex.Match(text, pattern);
            if (match.Success)
            {
                string link = match.Groups[1].Value;
                Clipboard.SetText(link);
                MessageBox.Show("Link copied to clipboard.");
            }
        }
    }
}