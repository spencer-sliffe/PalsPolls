using System;
using System.Collections.Generic;
using System.IO;
using PalsPolls.Tables;
using SQLite;
using Xamarin.Forms;

namespace PalsPolls.Views
{
    public partial class ChangePasswordPage : ContentPage
    {
        public RegUserTable regUser;
        private readonly RegUserTable m_regUser;
        public ChangePasswordPage(RegUserTable MyAccount)
        {
            InitializeComponent();
            m_regUser = MyAccount;
            regUser = MyAccount;
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDataBase.db3");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(txtUsername.Text) && App.myDataBase.HashPass(u.Password).Equals(App.myDataBase.HashPass(txtPassword.Text))).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(newTxtPassword.Text))
            {
                await DisplayAlert("Error", "Must answer all fields", "Okay");
            }
            else if (myquery != null)
            {
                regUser.Password = App.myDataBase.HashPass(newTxtPassword.Text);
                ChangePassword();
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Congratulations", "Password Changed", "Okay", "Cancel");
                    if (result)
                        await Navigation.PushAsync(new SignIn());
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Oops..", "Username or Password is incorrect!", "Okay", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new ChangePasswordPage(m_regUser));
                    else
                    {
                        await Navigation.PushAsync(new ChangePasswordPage(m_regUser));
                    }
                });
            }
        }

        async void ChangePassword()
        {
            await App.myDataBase.UpdateUser(regUser);
        }
    }
}



