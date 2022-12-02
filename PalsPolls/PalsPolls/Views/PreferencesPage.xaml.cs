using System;
using System.Collections.Generic;
using System.IO;
using PalsPolls.Tables;
using SQLite;
using Xamarin.Forms;
using PalsPolls.Services;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Linq;

namespace PalsPolls.Views
{
    public partial class PreferencesPage : ContentPage
    {
        private readonly RegUserTable m_UserTable;
        public PreferencesPage(RegUserTable MyAccount)
        {
            InitializeComponent();
            m_UserTable = MyAccount;
            String myUserName = UserName(m_UserTable);
            DisplayUN.Text = myUserName;
            String myEmail = Email(m_UserTable);
            DisplayEM.Text = myEmail;
            String myPhoneNumber = PhoneNumber(m_UserTable);
            string formattedPhoneNumber = string.Format("({0}) {1}-{2}", myPhoneNumber.Substring(0, 3), myPhoneNumber.Substring(3, 3), myPhoneNumber.Substring(6, 4));
            DisplayPN.Text = formattedPhoneNumber;
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());
        }

        async void ViewCell_Tapped(System.Object sender, System.EventArgs e)
        {            
            await Navigation.PushAsync(new ChangePasswordPage(m_UserTable));
        }
        async void ViewCell_Tapped_1(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());
        }

        private String UserName(RegUserTable MyAccount)
        {
            return MyAccount.UserName;
        }

        private String Email(RegUserTable MyAccount)
        {
            return MyAccount.Email;
        }

        private String PhoneNumber(RegUserTable MyAccount)
        {
            return MyAccount.PhoneNumber;
        }

        void ViewCell_Tapped_2(System.Object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Warning", "About To Delete Account!", "Okay", "Cancel");

                if (result == true)
                {
                    await App.myDataBase.DeleteUser(m_UserTable);
                    var polltables = await App.myPollServices.ReadPosts();
                    foreach (var polltable in from polltable in polltables where polltable.PostUserName == m_UserTable.UserName select polltable)
                        await App.myPollServices.DeletePost(polltable);

                    await Navigation.PushAsync(new SignIn());
                }
                else
                {
                    await Navigation.PopAsync();
                }
            });
        }
    }
}

