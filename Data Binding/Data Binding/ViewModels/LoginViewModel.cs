using Data_Binding.Singleton;
using Data_Binding.Views;
using System;
using System.ComponentModel;
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

        private async void authenticate()
        {
            if (username == "test" && password == "test")
            {
                Application.Current.Properties["username"] = username;
                Application.Current.Properties["password"] = password;
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
