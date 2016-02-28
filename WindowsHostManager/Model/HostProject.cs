using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsHostManager.Model
{
    public class HostProject
    {
        


        private string projectPath; // local path or uri
        private string siteName; // localhost or website name
        private string projectName;
        private ICollectionView hostItems;
    }
}
