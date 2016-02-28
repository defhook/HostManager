using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WindowsHostManager.Model
{
    public enum EProjectType
    {
        General, // common host, include current used and global
        Local,
        Internet
    }

    public class HostProject: INotifyPropertyChanged
    {
        public string ProjectPath
        {
            get { return projectPath; }
            set
            {
                projectPath = value;
                NotifyPropertyChanged("ProjectPath");
            }
        }

        public string SiteName
        {
            get { return siteName; }
            set
            {
                siteName = value;
                NotifyPropertyChanged("SiteName");
            }
        }

        public string ProjectName
        {
            get { return projectName; }
            set
            {
                projectName = value;
                NotifyPropertyChanged("ProjectName");
            }
        }

        public EProjectType ProjectType
        {
            get { return projectType; }
            set
            {
                projectType = value;
                NotifyPropertyChanged(projectType.ToString());
            }
        }

        public ICollectionView HostItems
        {
            get { return hostItems; }
            set
            {
                hostItems = value;
                NotifyPropertyChanged("HostItems");
            }
        }


        private string projectPath; // local path or uri
        private string siteName; // localhost or website name
        private string projectName;
        private ICollectionView hostItems;
        private EProjectType projectType;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
