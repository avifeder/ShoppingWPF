using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    class SignupCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SignupVM CurrentVM { get; set; }

        public SignupCommand(SignupVM VM)
        {
            CurrentVM = VM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;
            PasswordBox PasswordBox1 = values[0] as PasswordBox;
            PasswordBox PasswordBox2 = values[1] as PasswordBox;
            CurrentVM.Password1 = PasswordBox1.Password;
            CurrentVM.Password2 = PasswordBox2.Password;
            CurrentVM.Signup();
        }
    }
}
