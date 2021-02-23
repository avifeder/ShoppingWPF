using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.ViewModels;
using System.Windows;

namespace WpfApp.ViewModels
{
    class MainWindowVM : BaseViewModel
    {
        public MainWindowVM()
        {
            ((App)Application.Current).Currents.CurrentVM = new LoginVM();
        }
    }
}
