using System;
using System.Collections.Generic;
using System.IO;
using PalsPolls.Tables;
using SQLite;
using Xamarin.Forms;
using PalsPolls.Services;

namespace PalsPolls.Views
{
    public partial class PreferencesPage : ContentPage
    {
        public PreferencesPage()
        {
            DisplayUserName();
            InitializeComponent();
        }

        async void DisplayUserName()
        {
            DisplayUN.Text = UserName();
            await Navigation.PopAsync();
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

        private String UserName()
        {
            return App.MyAccountAttributes.getUserName();
        }

        private String Email()
        {
            return App.MyAccountAttributes.getEmail();
        }

        private String PhoneNumber()
        {
            return App.MyAccountAttributes.getPhoneNumber();
        }
    }
}

