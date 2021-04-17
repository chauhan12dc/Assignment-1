using Data_Binding.Services;
using Data_Binding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Data_Binding.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGenre : ContentPage
    {
        List<String> selectedGenre = new List<String>();
        private App assignment1 = Application.Current as App;

        public AddGenre()
        {
            InitializeComponent();
            BindingContext = new GenreViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            String btnTxt = button.Text;

            if (button.TextColor.Equals(Color.FromHex("#1d96f0")))
            {
                //button.BackgroundColor = Color.FromHex("1d96f0");
                button.TextColor = Color.FromHex("#ff0095");
                selectedGenre.Add(btnTxt);
            }
            else
            {
                //button.BackgroundColor = Color.White;
                //button.BorderColor = Color.FromHex("1d96f0");
                button.TextColor = Color.FromHex("#1d96f0");
                selectedGenre.Remove(btnTxt);
            }
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine(!selectedGenre.Any());
            Console.WriteLine(selectedGenre.Count());
            if (selectedGenre.Count() == 0)
            {
                DisplayAlert("Alert!", "No Genre Selected", "Dismiss");
                return;
            }
            String selectedGenreString = "\"";
            selectedGenreString += String.Join("\",\"", selectedGenre);
            selectedGenreString += "\"";
            Preferences.Set("selectedGenre", selectedGenreString);
            Navigation.PushAsync(new GenrePage());


            NetworkCalls networkcall = new NetworkCalls();
            networkcall.saveUserPreferences(assignment1.Properties["token"].ToString(), assignment1.Properties["username"].ToString(), selectedGenreString);
            DisplayAlert("", "Your preferences have been synchronized", "Proceed");
            
        }

        private void logout(object sender, EventArgs e)
        {
            App.Current.Properties["isLoggedIn"] = false;
            assignment1.navigationMain("login");
        }

    }
}