using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using Data_Binding.ViewModels;

namespace Data_Binding.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        //private App assignment1 = Application.Current as App;
        //public LoginPage()
        //{
        //    InitializeComponent();
        //}

        //async private void login(object sender, EventArgs e)
        //{
        //    if (username.Text == null|| password.Text == null)
        //    {
        //        await DisplayAlert("Alert", "Both the fields are required", "Cancel");
        //    }
        //    else if (username.Text == "test" && password.Text == "test")
        //    {
        //        App.Current.Properties["isLoggedIn"] = true;
        //        assignment1.navigationMain("main");
        //    }
        //    else
        //    {
        //        await DisplayAlert("Alert", "You have entered wrong credentials", "Try Again!");
        //    }
        //}
    }
}