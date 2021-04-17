using System;
using System.Collections.Generic;
using Assignment.ViewModels;

using Xamarin.Forms;

namespace Assignment.Views
{
    public partial class GenrePage : ContentPage
    {
        private App assignment1 = Application.Current as App;
        public GenrePage()
        {
            InitializeComponent();
            //BindingContext = new GenreViewModel();

        }

        private void logout(object sender, EventArgs e)
        {
            App.Current.Properties["isLoggedIn"] = false;
            assignment1.navigationMain("login");
        }
    }
}