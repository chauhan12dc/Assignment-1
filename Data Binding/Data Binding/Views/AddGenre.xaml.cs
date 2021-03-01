using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Data_Binding.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGenre : ContentPage
    {
        List<String> selectedGenre = new List<String>();

        public AddGenre()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (selectedGenre.Count()==0)
            {
                DisplayAlert("Alert!", "No Genre Selected", "dismiss");
                return;
            }

            String selectedGenreString = String.Join(",",selectedGenre);
            Preferences.Set("selectedGenre", selectedGenreString);
            Navigation.PushAsync(new GenrePage());
        }

        private void Action_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Action");
            }
            else
            {
                selectedGenre.Remove("Action");
            }
        }

        private void Comedy_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                selectedGenre.Add("Comedy");
            }
            else
            {
                selectedGenre.Remove("Comedy");
            }
        }
    }
}