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

        public RegUserTable regUser;

        public RegisterPage()
        {
            InitializeComponent();
        }
        //Function for account registration
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var email = EntryUserEmail.Text;

            var pass = EntryUserPassword.Text;

            var emailPattern = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";

            var passPattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";

            if (string.IsNullOrWhiteSpace(EntryUserName.Text) || string.IsNullOrWhiteSpace(EntryUserPassword.Text) || string.IsNullOrWhiteSpace(EntryUserPhoneNumber.Text))
            {
                await DisplayAlert("Error", "Must answer all fields", "Okay");
            }
            else if (Regex.IsMatch(pass, passPattern) != true)
            {
                ErrorLabel.Text = "Password must contain a numeric, lowercase, uppercase, special character";
            }
            else if (Regex.IsMatch(email, emailPattern) != true)
            {
                ErrorLabel.Text = "Email is not valid";
            }
            else
            {
                AddNewUser();

                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Congratulations", "User Registration Successful", "Okay", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new SignIn());
                });
            }
        }

        async void AddNewUser()
        {
            await App.myDataBase.CreateLogin(regUser = new Tables.RegUserTable
            {
                UserName = EntryUserName.Text,
                Password = App.myDataBase.HashPass(EntryUserPassword.Text),
                Email = EntryUserEmail.Text,
                PhoneNumber = EntryUserPhoneNumber.Text
            });
            await Navigation.PopAsync();
        }
    }
}

