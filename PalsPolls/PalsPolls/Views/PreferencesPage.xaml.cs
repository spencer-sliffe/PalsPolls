using System;
using System.Collections.Generic;
using System.IO;
using PalsPolls.Tables;
using SQLite;
using Xamarin.Forms;
using PalsPolls.Services;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

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
    }
}

