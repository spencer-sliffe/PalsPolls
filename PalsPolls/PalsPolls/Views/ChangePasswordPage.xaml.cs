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

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDataBase.db3");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(txtUsername.Text) && u.Password.Equals(txtPassword.Text)).FirstOrDefault();
            if (myquery != null)
            {               
                App.myDataBase.UpdateUserPassword(newTxtPassword.Text, myquery);
                App.Current.MainPage = new NavigationPage(new PreferencesPage(m_UserTable));

            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Oops..", "Username or Password is incorrect!", "Okay", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new ChangePasswordPage(m_UserTable));
                    else
                    {
                        await Navigation.PushAsync(new ChangePasswordPage(m_UserTable));
                    }
                });
            }
        }



        

    }
}

