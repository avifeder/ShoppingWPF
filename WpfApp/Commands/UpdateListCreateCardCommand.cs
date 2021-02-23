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
    class UpdateListCreateCardCommand : ICommand
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
            CurrentVM.UpdatePriceCartList(itemName);
            ((App)Application.Current).Currents.CurrentVM = CurrentVM;
        }
        public CreateCartVM CurrentVM { get; set; }

        public UpdateListCreateCardCommand(CreateCartVM VM)
        {
            CurrentVM = VM;
        }
    }
}
