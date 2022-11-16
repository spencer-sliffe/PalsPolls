﻿using System;
using System.Collections.Generic;
using System.IO;
using PalsPolls.Tables;
using SQLite;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using PalsPolls.ViewModels;

namespace PalsPolls.Views
{
    public partial class PollCreatingPage : ContentPage
    {
        public PollTable m_poll;
        //private readonly RegUserTable m_userTable;
        public PollCreatingPage(PollTableViewModel viewModel)
        {
            InitializeComponent();
            //m_userTable = MyAccount;
            BindingContext = new PollCreatingPageViewModel(viewModel ?? new PollTableViewModel());

        }
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(EntryAnswer1.Text) || string.IsNullOrWhiteSpace(EntryAnswer2.Text) || string.IsNullOrWhiteSpace(EntryPoll.Text))
            {
                await DisplayAlert("Error", "Must answer all fields", "Okay");
            }
            else
            {
                //AddNewPost();
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Success", "New Post Created", "Okay", "Cancel");

                    if (result)
                        await Navigation.PopAsync();
                });
            }
           
            
        }

        /*async void AddNewPost()
        {
            await App.myPollServices.CreatePoll(m_poll = new Tables.PollTable
            {
                PostUserName = "test",
                PostContent = EntryPoll.Text,
                PostContent1 = EntryAnswer1.Text,
                PostContent2 = EntryAnswer2.Text
            });
        }*/
    }
}
