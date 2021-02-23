using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Models
{
    class LoginM
    {
        IBL BL;
        public LoginM()
        {
            BL = new BLImp(((App)Application.Current).Currents.LoggedUser);
        }

        public bool Login(string Mail, string Password)
        {
            User user = BL.GetAllUsers(tempUser => tempUser.Mail == Mail && tempUser.Password == Password).FirstOrDefault();
            if (user != null)
            {
                ((App)Application.Current).Currents.LoggedUser = user;
                return true;
            }
            return false;
        }
    }
}
