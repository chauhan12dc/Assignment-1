using Data_Binding.ViewModels;
using Data_Binding.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Data_Binding
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
