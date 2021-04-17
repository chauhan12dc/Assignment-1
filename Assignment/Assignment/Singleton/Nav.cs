using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assignment.Singleton
{
    public class Nav
    {
        private App assignment1 = Application.Current as App;
        public Nav()
        {
        }

        public Task DisplayAlertAsync(string title, string message, string button = "Ok")
        {
            return assignment1.MainPage.DisplayAlert(title, message, button);
        }

        public static Nav Shared = new Nav();
    }
}
