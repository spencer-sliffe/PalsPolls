using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PalsPolls.Views
{
    public partial class PreferencesPage : ContentPage
    {
        public PreferencesPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());
        }



        async void ViewCell_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PreferencesPage());
        }

        async void ViewCell_Tapped_1(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());
        }
    }
}

