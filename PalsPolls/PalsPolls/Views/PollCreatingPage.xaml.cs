using System;
using System.Collections.Generic;
using System.IO;
using PalsPolls.Tables;
using SQLite;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace PalsPolls.Views
{
    public partial class PollCreatingPage : ContentPage
    {
        public PollTable m_poll;
        private readonly RegUserTable m_userTable;
        public PollCreatingPage(RegUserTable MyAccount)
        {
            InitializeComponent();
            m_userTable = MyAccount;
        }
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EntryAnswer1.Text) || string.IsNullOrWhiteSpace(EntryAnswer2.Text) || string.IsNullOrWhiteSpace(EntryPoll.Text))
            {
                await DisplayAlert("Error", "Must answer all fields", "Okay");
            }
            else
            {
                AddNewPost();
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Success", "New Post Created", "Okay", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new HomePage(m_userTable));
                });
            }
            
        }

        async void AddNewPost()
        {
            await App.myPollServices.CreatePoll(m_poll = new Tables.PollTable
            {
                PostUserName = m_userTable.UserName,
                PostContent = EntryPoll.Text,
                LeftNum = 0,
                RightNum = 0
            });
        }
    }
}
