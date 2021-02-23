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
    class UpdateGraphItemCommand : ICommand
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
            string itemName = parameter as string;
            CurrentVM.updateGraph(itemName);
            ((App)Application.Current).Currents.CurrentVM = CurrentVM;
        }
        public HistoryByItemVM CurrentVM { get; set; }

        public UpdateGraphItemCommand(HistoryByItemVM VM)
        {
            CurrentVM = VM;
        }
    }
}
