using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHostManager.Controller
{
    public class HostReader
    {
        private string getHostPath()
        {
            string windir = Environment.SystemDirectory;
            System.IO.Path.Combine(windir, "drivers/etc/hosts");
            return "";
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint GetWindowsDirectory(StringBuilder buffer, uint usize);

        private string getWindowsDirectory()
        {
            uint usize = 0;
            usize = GetWindowsDirectory(null, usize);

            StringBuilder sb = new StringBuilder((int)usize);
            GetWindowsDirectory(sb, usize);
            return sb.ToString();
        }
    }
}
