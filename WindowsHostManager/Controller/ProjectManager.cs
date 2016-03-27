using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsHostManager.Model;

namespace WindowsHostManager.Controller
{
    public class ProjectManager
    {
        private ObservableCollection<HostProject> loadProjects(IEnumerable<Uri> uris, EProjectType type)
        {
            var projects = new ObservableCollection<HostProject>();
            foreach (var uri in uris)
            {
                var project = new HostProject()
                {
                    ProjectPath = uri,
                    ProjectName = System.IO.Path.GetFileNameWithoutExtension(uri.LocalPath),
                    ProjectType = type,
                    HostItems = HostReader.ReadHostFile(uri.LocalPath)
                };
            }
            return projects;
        }
        public ObservableCollection<HostProject> LoadLocalProjects(IEnumerable<Uri> uris)
        {
            var projects = new ObservableCollection<HostProject>();
            foreach(var uri in uris)
            {
                var project = new HostProject()
                {
                    ProjectPath = uri,
                    ProjectName = System.IO.Path.GetFileNameWithoutExtension(uri.LocalPath),
                    ProjectType = EProjectType.Local,
                    HostItems = HostReader.ReadHostFile(uri.LocalPath)
                };
            }
            return projects;
        }

        public ObservableCollection<HostProject> LoadProjectFolder(string local_folder)
        {
            var projects = new ObservableCollection<HostProject>();

            return projects;
        }

        public bool SaveProjects(IEnumerable<HostProject> hosts)
        {
            return true;
        }

        public bool ActiveProject(HostProject host)
        {
            return true;
        }
    }
}
