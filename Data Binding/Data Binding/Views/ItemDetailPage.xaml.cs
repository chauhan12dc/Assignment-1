using Data_Binding.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Data_Binding.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}