using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Assignment.Views
{
    public partial class Logout : ContentPage
    {
        private App assignment1 = Application.Current as App;
        public Logout()
        {
            InitializeComponent();
        }
        private void logoutOption(object sender, EventArgs e)
        {
            App.Current.Properties["isLoggedIn"] = false;
            assignment1.navigationMain("login");
        }
    }
}
