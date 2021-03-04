using Data_Binding.Services;
using Data_Binding.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Data_Binding
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
                    MainPage = new NavigationPage(new LoginPage());
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
            var isLoggedIn = App.Current.Properties.ContainsKey("isLoggedIn") ? (bool)App.Current.Properties["isLoggedIn"] : false;
            Console.WriteLine(isLoggedIn);
            if (!isLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
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
            var isLoggedIn = App.Current.Properties.ContainsKey("isLoggedIn") ? (bool)App.Current.Properties["isLoggedIn"] : false;
            Console.WriteLine(isLoggedIn);
            if (!isLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new AddGenre());
            }
        }
    }
}
