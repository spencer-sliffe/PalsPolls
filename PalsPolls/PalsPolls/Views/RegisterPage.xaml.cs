using System;
using System.Collections.Generic;
using System.IO;
using PalsPolls.Tables;
using SQLite;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace PalsPolls
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        //Function for account registration
       void Handle_Clicked(object sender, System.EventArgs e)
        {
            var email = EntryUserEmail.Text;

            var emailPattern = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";

            if (Regex.IsMatch(email, emailPattern))
            {
                var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDataBase.db"); //Database path
                var db = new SQLiteConnection(dbpath);
                db.CreateTable<RegUserTable>();

                //new user
                var item = new RegUserTable()
                {
                    UserName = EntryUserName.Text,
                    Password = EntryUserPassword.Text,
                    Email = EntryUserEmail.Text,
                    PhoneNumber = EntryUserPhoneNumber.Text
                };

                //new database item
                db.Insert(item);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Congratulations", "User Registration Successful", "Okay", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new SignIn());

                });
            }
            else
            {
                ErrorLabel.Text = "Email is not valid";
            }
            

        }
    }
}

