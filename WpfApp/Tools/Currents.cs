﻿using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.ViewModels;

namespace WpfApp.Tools
{


    /// <summary>
    /// class for keeping current application-wide properties
    /// </summary>
    public class Currents : INotifyPropertyChanged
    {
        public Stack<BaseViewModel> GoBack;
        public Currents()
        {
            GoBack = new Stack<BaseViewModel>();
        }

        private BaseViewModel currentVM;
        public BaseViewModel CurrentVM
        {
            get { return currentVM; }
            set
            {
                if (currentVM != null && !currentVM.GetType().Equals(value.GetType()))
                    GoBack.Push(currentVM);
                currentVM = value;
                OnPropertyRaised("CurrentVM");
                
            }
        }

        private User loggedUser;
        public User LoggedUser
        {
            get { return loggedUser; }
            set
            {
                loggedUser = value;
                OnPropertyRaised("LoggedUser");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
