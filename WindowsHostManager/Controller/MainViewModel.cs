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

        public MainViewModel()
        {
            var testData = new ObservableCollection<Model.HostItem>
            {
                new Model.HostItem {Activated=true, IP="127.0.0.1", Host="www.baidu.com", Comment="this is comment", GroupName="localhost"},
                new Model.HostItem {Activated=true, IP="127.0.0.1", Host="12344445", Comment="this is comment", GroupName="localhost"},
                new Model.HostItem {Activated=true, IP="192.168.0.1", Host="www.kafan.cn", Comment="this is comment", GroupName="kafan"},
                new Model.HostItem {Activated=true, IP="192.168.0.2", Host="www.kafan.com", Comment="this is comment", GroupName="kafan"}
            };
            HostLists = new ListCollectionView(testData);
            HostLists.GroupDescriptions.Add(new PropertyGroupDescription("GroupName"));
            //hostItems.ItemsSource = HostLists;
        }
    }
}
