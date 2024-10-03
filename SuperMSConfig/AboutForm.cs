using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            panelBottom.BackColor = Color.FromArgb(243, 243, 243);

           this.Paint += new PaintEventHandler(ApplyGradientBackground);
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

        // Apply gradient to control
        private void ApplyGradientBackground(object sender, PaintEventArgs e)
        {
            Control control = sender as Control;

            if (control != null)
            {
                // Create rectangle that matches the control's size
                Rectangle controlRect = control.ClientRectangle;

                // Create LinearGradientBrush with multiple colorss
                using (LinearGradientBrush brush = new LinearGradientBrush(controlRect, Color.Empty, Color.Empty, 45f))
                {
                    // Color blend to create a multi-color gradient
                    ColorBlend colorBlend = new ColorBlend();
                    colorBlend.Colors = new Color[]
                    {
                    Color.FromArgb(255, 220, 230, 250), // Soft Blue
                    Color.FromArgb(255, 255, 220, 250), // Soft Pink
                    Color.FromArgb(255, 200, 220, 240), // Soft Purple
                    Color.FromArgb(255, 240, 210, 240), // Pastel Pink
                    Color.FromArgb(255, 250, 230, 240)  // Soft Red
                    };

                    // Positions for each color in the gradient
                    colorBlend.Positions = new float[] { 0f, 0.25f, 0.5f, 0.75f, 1f };
                    brush.InterpolationColors = colorBlend;

                    // Fill the control with the gradient brush
                    e.Graphics.FillRectangle(brush, controlRect);
                }
            }
        }
    }
}
