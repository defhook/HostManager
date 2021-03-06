﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WindowsHostManager.Model;

namespace WindowsHostManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Controller.MainViewModel mm;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new Controller.MainViewModel();

        }

        protected void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListBoxItem;
            if(item != null)
            {
                var project = item.DataContext as HostProject;
                project.Activated = !project.Activated;
            }
            
        }
    }
}
