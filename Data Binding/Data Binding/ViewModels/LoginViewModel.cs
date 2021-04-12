﻿using Data_Binding.Singleton;
using Data_Binding.Services;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace Data_Binding.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        string username = string.Empty;
        string password = string.Empty;

        private App assignment1 = Application.Current as App;

        public LoginViewModel()
        {
            LoginCommand = new Command(() => {
                authenticate();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string str)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
        }

        public string Username
        {
            get => username;
            set
            {
                if(username == value)
                {
                    return;
                }
                username = value;
                OnPropertyChanged(nameof(username));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password == value)
                {
                    return;
                }
                password = value;
                OnPropertyChanged(nameof(password));
            }
        }

        public ICommand LoginCommand { get; set; }

        private bool emailAuth(string email)
        {
            Console.WriteLine(email);
            Regex rg = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            MatchCollection match = rg.Matches(email);
            if (match.Count == 1)
            {
                return true;
            }
            return false;
        }

        private bool passwordAuth(string password)
        {
            Console.WriteLine(password);
            Regex rg = new Regex("^[a-zA-Z0-9_]*$");
            MatchCollection match = rg.Matches(password);
            if (match.Count == 1)
            {
                return true;
            }
            return false;
        }

        private async void authenticate()
        {
            if (emailAuth(username) && passwordAuth(password))
            {
                NetworkCalls networkCalls = new NetworkCalls();
                string token = networkCalls.Login(username, password);
                Console.WriteLine(token);
                Application.Current.Properties["username"] = username;
                Application.Current.Properties["password"] = password;
                Application.Current.Properties["token"] = token;
                await Application.Current.SavePropertiesAsync();
                assignment1.navigationMain("main");
            }
            else
            {
                await Nav.Shared.DisplayAlertAsync("Alert", "Invalid credentials", "Try again");
                Username = "";
                Password = "";
            }
        }
    }

    //public class LoginViewModel : BaseViewModel
    //{
    //    public Command LoginCommand { get; }

    //    public LoginViewModel()
    //    {
    //        LoginCommand = new Command(OnLoginClicked);
    //    }

    //    private async void OnLoginClicked(object obj)
    //    {
    //        // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
    //        await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
    //    }
    //}
}
