using Assignment.Services;
using Assignment.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage =new NavigationPage(new AddGenre());
        }

        public void navigationMain(string to)
        {
            switch (to)
            {
                case "login":
                    MainPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = ColorConverters.FromHex("#1d96f0"), BarTextColor = Color.White };
                    break;
                case "main":
                    MainPage = new NavigationPage(new AddGenre());
                    break;
                case "list":
                    MainPage = new NavigationPage(new GenrePage());
                    break;
            }
        }

        protected override void OnStart()
        {
            var isLoggedIn = App.Current.Properties.ContainsKey("username") && App.Current.Properties.ContainsKey("password");
            Console.WriteLine(isLoggedIn);
            if (!isLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = ColorConverters.FromHex("#1d96f0"), BarTextColor = Color.White };
            }
            else
            {
                MainPage = new NavigationPage(new AddGenre());
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            var isLoggedIn = App.Current.Properties.ContainsKey("username") && App.Current.Properties.ContainsKey("password");
            Console.WriteLine(isLoggedIn);
            if (!isLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = ColorConverters.FromHex("#1d96f0"), BarTextColor = Color.White };
            }
            else
            {
                MainPage = new NavigationPage(new AddGenre());
            }
        }
    }
}
