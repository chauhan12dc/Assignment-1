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
            MainPage =new NavigationPage(new AddGenre());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
