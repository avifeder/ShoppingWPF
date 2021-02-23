using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Models;
using BE;
using System.ComponentModel;
using WpfApp.Tools;

namespace WpfApp.ViewModels
{
    class SignupVM :  BaseViewModel
    {       
        public SignupM SignUpModel { get; set; }
        public SignupVM()
        {
            ErrorMessageVisible = Visibility.Hidden;
            SuccessMessageVisible = Visibility.Hidden;
            SignUpModel = new SignupM();
        }
        #region command properties

        public ICommand SignUpCommand
        {
            get
            {
                return new SignupCommand(this);
            }
        }

        public ICommand ErrorCommand
        {
            get
            {
                return new BaseCommand(delegate () { this.clear(); });
            }
        }
        public ICommand SuccessCommand
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new LoginVM(); ((App)Application.Current).Currents.GoBack.Clear(); });
            }
        }
        #endregion
        #region signup properties

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyRaised("FirstName");
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {

                lastName = value;
                OnPropertyRaised("LastName");
            }
        }

        public string id;

        public string Id
        {
            get { return id; }
            set
            {

                id = value;
                OnPropertyRaised("Id");
            }
        }


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

        private string password1;
        public string Password1
        {
            get { return password1; }
            set
            {
                password1 = null;
                Password2 = null;
                password1 = value;
                OnPropertyRaised("Password1");
                OnPropertyRaised("Password2");
            }
        }

        private string password2;
        public string Password2
        {
            get { return password2; }
            set
            {
                password2 = null;
                password2 = value;
                OnPropertyRaised("Password2");
            }
        }
        #endregion
        #region view properties

        private string messageText;
        public string MassageText
        {
            get { return messageText; }
            set
            {
                messageText = value;
                OnPropertyRaised("MassageText");
            }
        }

        private Visibility errorMessageVisible;
        public Visibility ErrorMessageVisible
        {
            get { return errorMessageVisible; }
            set
            {

                errorMessageVisible = value;
                OnPropertyRaised("ErrorMessageVisible");
            }
        }

        private Visibility successMessageVisible;
        public Visibility SuccessMessageVisible
        {
            get { return successMessageVisible; }
            set
            {

                successMessageVisible = value;
                OnPropertyRaised("SuccessMessageVisible");
            }
        }

        #endregion
        #region other
        public void Signup()
        {


            if (FirstName == null || LastName == null || Id == null || Mail == null || Password1 == null || Password2 == null)
            {
                MassageText = "אנא מלא את כל השדות";
                ErrorMessageVisible = Visibility.Visible;
            }
                

            else if (!new ValidPassword().IsValidPassword(Password1))
            {
                MassageText = "סיסמה צריכה להכיל 6 תווית לפחות ותו חזק";
                ErrorMessageVisible = Visibility.Visible;
            }


            else if (Password1 != Password2)
            {
                MassageText = "הסיסמאות שהזנת אינן תואמות";
                ErrorMessageVisible = Visibility.Visible;
            }

            else
            {
                User user = new User(FirstName, LastName, Id, Mail, Password1);
                if (SignUpModel.Signup(user))
                    SuccessMessageVisible = Visibility.Visible;
                else
                {
                    MassageText = "המשתמש כבר קיים";
                    ErrorMessageVisible = Visibility.Visible;
                }

            }
            

        }
        public void clear()
        {
            ErrorMessageVisible = Visibility.Hidden;
        }
        #endregion
    }
}
