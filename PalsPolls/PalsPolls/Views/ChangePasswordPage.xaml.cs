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
        private readonly RegUserTable m_UserTable;
        public ChangePasswordPage(RegUserTable MyAccount)
        {
            InitializeComponent();
            m_UserTable = MyAccount;
        }

        /*private String ChangePassword(RegUserTable MyAccount)
        {
            
        }*/

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
        }
    }
}

