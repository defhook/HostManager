using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WindowsHostManager.Model
{
    public enum EProjectType
    {
        System, // system used hosts
        Local,
        Online
    }

    public class HostProject: INotifyPropertyChanged
    {
        public Uri ProjectPath
        {
            get { return projectPath; }
            set
            {
                projectPath = value;
                NotifyPropertyChanged("ProjectPath");
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

        public ObservableCollection<HostItem> HostItems
        {
            get { return hostItems; }
            set
            {
                hostItems = value;
                NotifyPropertyChanged("HostItems");
            }
        }


        private Uri projectPath; // hosts file path
        private string projectName;
        private ObservableCollection<HostItem> hostItems;
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
