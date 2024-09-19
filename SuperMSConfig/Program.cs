﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMSConfig
{
    internal static class Program
    {
        /// <summary>
        /// Get app version
        /// </summary>
        internal static string GetCurrentVersionTostring() => new Version(Application.ProductVersion).ToString(4);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
