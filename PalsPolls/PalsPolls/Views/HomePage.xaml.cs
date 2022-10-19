﻿using System;
using System.Collections.Generic;
using PalsPolls.Views;
using Xamarin.Forms;
using PalsPolls.Tables;

namespace PalsPolls
{
    public partial class HomePage : ContentPage
    {
        private readonly RegUserTable m_userTable;
        public HomePage(RegUserTable MyAccount)
        {
            InitializeComponent();
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            m_userTable = MyAccount;            
        }

        private async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PreferencesPage(m_userTable));
        }
        private async void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PollCreatingPage(m_userTable));
        }

        private async void TapGestureRecognizer_Tapped_2(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MyAccountPage(m_userTable));
        }
    }
}

