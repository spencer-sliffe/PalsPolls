using System;
using System.Collections.Generic;

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

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());
        }
    }
}

