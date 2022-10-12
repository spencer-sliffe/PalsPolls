using System;
using System.Collections.Generic;
using System.IO;
using PalsPolls.Tables;
using SQLite;
using Xamarin.Forms;
using PalsPolls.Services;
using System.Threading.Tasks;

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

    }
}

