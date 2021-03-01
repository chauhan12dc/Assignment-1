using Data_Binding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Binding.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Data_Binding.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenrePage : ContentPage
    {
        public GenrePage()
        {
            InitializeComponent();
            BindingContext = new GenreViewModel();

        }
    }
}