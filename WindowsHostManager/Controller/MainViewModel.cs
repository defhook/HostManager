using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WindowsHostManager.Controller
{
    public class MainViewModel
    {
        public ICollectionView HostLists { get; private set; }
        public ICollectionView ProjectLists { get; private set; }

        public MainViewModel()
        {
            var testData = HostReader.ReadSystemHostFile();
            HostLists = new ListCollectionView(testData);
            HostLists.GroupDescriptions.Add(new PropertyGroupDescription("GroupName"));

            initListbox();
        }

        private void initListbox()
        {
            var testData = new ObservableCollection<Model.HostProject>
            {
                new Model.HostProject { ProjectName="General", ProjectType=Model.EProjectType.System, Activated=true},
                new Model.HostProject { ProjectName="Local1", ProjectType=Model.EProjectType.Local, Activated=true},
                new Model.HostProject { ProjectName="Local2", ProjectType=Model.EProjectType.Local, Activated=false},
                new Model.HostProject { ProjectName="Internet1", ProjectType=Model.EProjectType.Online, Activated=true},
                new Model.HostProject { ProjectName="Internet2", ProjectType=Model.EProjectType.Online, Activated=false},

            };
            ProjectLists = new ListCollectionView(testData);
            ProjectLists.GroupDescriptions.Add(new PropertyGroupDescription("ProjectType"));
        }
    }
}
