using System;
using System.Windows.Forms;
using PluginInterface;
using Microsoft.Web.WebView2.WinForms;

namespace PluginClipilot
{
    public partial class PluginClipilotControl : UserControl, IPlugin
    {
        private WebView2 webView;

        public UserControl GetControl()
        {
            return this;
        }

        public string PluginName => "Ask Clipilot";
        public string PluginVersion => "1.0";
        public string PluginInfo => "Displays the Microsoft Copilot in a WebView2 control.";

        public PluginClipilotControl()
        {
            InitializeComponent();
            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            // Initialize WebView2 control
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(webView);

            // Wait for WebView2 to be initialized
            await webView.EnsureCoreWebView2Async(null);

            // Navigate to the Microsoft Copilot URL
            webView.CoreWebView2.Navigate("https://copilot.microsoft.com");
        }
    }
}
