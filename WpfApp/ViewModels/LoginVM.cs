using WpfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Commands;
using System.ComponentModel;
using BE;

namespace WpfApp.ViewModels
{
    class LoginVM : BaseViewModel
    {
        public LoginM LoginModel { get; set; }
        public LoginVM()
        {
            ErrorVisible = Visibility.Hidden;
            LoginModel = new LoginM();
        }
        #region commands
        public ICommand DisplaySignUpView
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new SignupVM(); });
            }
        }
        public ICommand LoginCommand
        {
            get
            {
                return new LoginCommand(this);
            }
        }

        public ICommand ErrorCommand
        {
            get
            {
                return new BaseCommand(delegate () { this.clear(); });
            }
        }
        #endregion

        #region user property 
        private string mail;
        public string Mail
        {
            get { return mail; }
            set
            {

                mail = value;
                OnPropertyRaised("Mail");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {

                password = value;
                OnPropertyRaised("Password");
            }
        }
        #endregion

        #region view property 
        private Visibility errorVisible;
        public Visibility ErrorVisible
        {
            get { return errorVisible; }
            set
            {

                errorVisible = value;
                OnPropertyRaised("ErrorVisible");
            }
        }
        #endregion
       
        #region other
        public void Login()
        {

           
            if(LoginModel.Login(Mail, Password))
               ((App)Application.Current).Currents.CurrentVM = new LastPurchaseVM();
            else
                ErrorVisible = Visibility.Visible;


        }

        public void clear()
        {
            ErrorVisible = Visibility.Hidden;
        }
        #endregion
    }
}
