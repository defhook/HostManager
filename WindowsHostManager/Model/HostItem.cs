using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHostManager.Model
{
    public class HostItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool Activated
        {
            get {return activated;}
            set
            {
                activated = value;
                NotifyPropertyChanged("Activated");
            }
        }

        public string IP
        {
            get {return ip;}
            set
            {
                ip = value;
                NotifyPropertyChanged("IP");
            }
        }

        public string Host
        {
            get { return host; }
            set
            {
                host = value;
                NotifyPropertyChanged("Host");
            }
        }

        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                NotifyPropertyChanged("Comment");
            }
        }

        public string GroupName
        {
            get { return groupName; }
            set
            {
                groupName = value;
                NotifyPropertyChanged("GroupName");
            }
        }

        #region private fields
        private bool activated;
        private string ip;
        private string host;
        private string comment;
        private string groupName;
        #endregion

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
