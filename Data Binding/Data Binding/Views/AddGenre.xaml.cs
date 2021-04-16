using Data_Binding.ViewModels;
using RestSharp;
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
            // InitializeList();
            BindingContext = new GenreViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            String btnTxt = button.Text;

            if (button.BackgroundColor.Equals(Color.Black))
            {
                button.BackgroundColor = Color.FromHex("74D2D0");
                button.BorderColor = Color.Black;
                selectedGenre.Remove(btnTxt);
            }
            else
            {
                button.BackgroundColor = Color.Black;
                button.BorderColor = Color.White;
                selectedGenre.Add(btnTxt);
            }
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            if (selectedGenre.Count() == 0)
            {
                DisplayAlert("Alert!", "No Genre Selected", "dismiss");
                return;
            }

            String selectedGenreString = "\"";
            selectedGenreString += String.Join("\",\"", selectedGenre);
            selectedGenreString += "\"";
            Preferences.Set("selectedGenre", selectedGenreString);
            Navigation.PushAsync(new GenrePage());


            var client = new RestClient("https://content-guide.herokuapp.com/user-preferences");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer "+assignment1.Properties["token"].ToString());
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\"email_address\": \"theopussquad@gmail.com\",\"preferences\": [" + selectedGenreString + "]}", ParameterType.RequestBody);
            //DisplayAlert("DD", "{\"email_address\": \"brenden.kevin@gmail.com\",\"preferences\": [" + selectedGenreString + "]}", "done");
            IRestResponse response = client.Execute(request);
            DisplayAlert("Successful!", response.StatusCode.ToString(), "Checking");

        }

        private void logout(object sender, EventArgs e)
        {
            App.Current.Properties["isLoggedIn"] = false;
            assignment1.navigationMain("login");
        }

        //private void InitializeList()
        //{
        //    Dictionary<int, int> already = new Dictionary<int, int>();
        //    BubbleService service = new BubbleService();
        //    Random r = new Random();
        //    foreach (var item in service.vs)
        //    {
        //        Button a = new Button() {
        //        Text = item,
        //        CornerRadius = 100,
        //        WidthRequest = 50,
        //        HeightRequest = 20
        //        };
        //        a.Clicked += Button_Clicked;
        //        ran.Children.Add(a, r.Next(0, 4), r.Next(0, 5));
        //    }
        //}

    }
}