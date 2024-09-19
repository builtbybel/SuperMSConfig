using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMSConfig
{
    public class Logger
    {
        private readonly MainForm mainForm;

        public Logger(MainForm mainForm)
        {
            this.mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
        }

        // Log method that supports additional details
        public void Log(string message, Color color, string details = "")
        {
            // Find the RichTextBox where logs are displayed
            RichTextBox logBox = mainForm.Controls.Find("rtbLog", true).FirstOrDefault() as RichTextBox;

            if (logBox != null)
            {
                // Ensure UI updates are made on the UI thread
                if (logBox.InvokeRequired)
                {
                    logBox.Invoke((Action)(() =>
                    {
                        AppendLog(logBox, message, color, details);
                    }));
                }
                else
                {
                    AppendLog(logBox, message, color, details);
                }
            }
        }

        private void AppendLog(RichTextBox logBox, string message, Color color, string details)
        {
            logBox.SelectionColor = color;
            logBox.AppendText($"{DateTime.Now}: {message}\n");

            // If there are additional details, append them indented
            if (!string.IsNullOrEmpty(details))
            {
                logBox.SelectionColor = Color.Gray; 
                logBox.AppendText($"\tDetails: {details}\n");
            }

            // Autoscroll to the bottom
            logBox.SelectionStart = logBox.Text.Length; 
            logBox.ScrollToCaret();
        }

    }
}
