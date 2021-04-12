using System;
using System.Collections.Generic;
using Data_Binding.ViewModels;

using Xamarin.Forms;

namespace Data_Binding.Views
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