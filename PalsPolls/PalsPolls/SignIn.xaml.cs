using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PalsPolls
{
    public partial class SignIn : ContentPage
    {
        public SignIn()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if(txtUsername.Text=="Admin" && txtPassword.Text=="123")
            {
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                DisplayAlert("Oops..", "Username or Password is incorrect!", "Ok");
            }
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}

