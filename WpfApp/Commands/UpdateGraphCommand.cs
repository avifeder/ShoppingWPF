using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class UpdateGraphCommand : ICommand
    {

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string shopName = parameter as string;
            CurrentVM.updateGraph(shopName);
            ((App)Application.Current).Currents.CurrentVM = CurrentVM;
        }
        public HistoryByShopVM CurrentVM { get; set; }

        public UpdateGraphCommand(HistoryByShopVM VM)
        {
            CurrentVM = VM;
        }
    }
}
