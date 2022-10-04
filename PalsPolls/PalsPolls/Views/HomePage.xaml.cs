using System;
using System.Collections.Generic;
using PalsPolls.Views;
using Xamarin.Forms;

namespace PalsPolls
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);


            InitializeComponent();
        }

        

        private async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PreferencesPage());
        }
    }
}

