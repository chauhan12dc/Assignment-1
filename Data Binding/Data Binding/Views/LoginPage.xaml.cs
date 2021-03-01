using System;
using Xamarin.Forms;

namespace Data_Binding.Views
{
    public partial class LoginPage : ContentPage
    {
        private App assignment1 = Application.Current as App;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void login(object sender, EventArgs e)
        {
            if (username.Text == "test" && password.Text == "test")
            {
                App.Current.Properties["isLoggedIn"] = true;
                assignment1.navigationMain("main");
            }
        }
    }
}