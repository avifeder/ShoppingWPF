using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Tools;
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
     public partial class App : Application
    { 
       public Currents Currents { get; set; }
        
        public App()
        {
            Currents = new Currents();

        }        
    }
}
