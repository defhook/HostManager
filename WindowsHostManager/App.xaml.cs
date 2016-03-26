using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Principal;
using System.Diagnostics;

namespace WindowsHostManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            changePrivilege();
        }

        private void changePrivilege()
        {
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool adminMode = principal.IsInRole(WindowsBuiltInRole.Administrator);
            if(!adminMode)
            {
                //var startInfo = new ProcessStartInfo();
                var startInfo = Process.GetCurrentProcess().StartInfo;
                startInfo.Verb = "runas";
                startInfo.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                startInfo.UseShellExecute = true;

                try
                {
                    Process.Start(startInfo);
                }
                catch
                {
                    MessageBox.Show(
                        WindowsHostManager.Properties.Resources.RunAsAdmin,
                        WindowsHostManager.Properties.Resources.PrivilegeFailed,
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    Environment.Exit(-1);
                }
            }
        }
    }
}
