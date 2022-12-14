using System;
using System.Collections.Generic;
using System.IO;
using PalsPolls.Tables;
using SQLite;
using Xamarin.Forms;
using PalsPolls.ViewModels;
using PalsPolls.Services;

namespace PalsPolls
{
    public partial class SignIn : ContentPage
    {
        public SignIn()
        {
            InitializeComponent();
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDataBase.db3");
            var db = new SQLiteConnection(dbpath);
            string pass = App.myDataBase.HashPass(txtPassword.Text);
            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(txtUsername.Text) && u.Password.Equals(pass)).FirstOrDefault();

            if (myquery != null)
            {
                App._userName = myquery.UserName;
                App.Current.MainPage = new NavigationPage(new HomePage(myquery));
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Oops..", "Username or Password is incorrect!", "Okay", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new SignIn());
                    else
                    {
                        await Navigation.PushAsync(new SignIn());
                    }
                });
            }
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}

