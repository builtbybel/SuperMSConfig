using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SuperMSConfig.Helpers
{
    internal static class Utils
    {
        // Check if app runs as Admin
        public static bool IsRunningAsAdmin()
        {
            try
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

                //logger.Log($"App is running with Admin rights: {isAdmin}", isAdmin ? Color.Green : Color.Red);

                if (!isAdmin)
                {
                    // logger.Log("The app should be run as Administrator to ensure all features work properly.", Color.Orange);
                }

                return isAdmin;
            }
            catch (Exception ex)
            {
                // logger.Log($"Error checking admin rights: {ex.Message}", Color.Red);
                return false;
            }
        }
    }
}
