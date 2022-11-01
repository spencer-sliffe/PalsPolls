using System;
using System.Collections.Generic;
using PalsPolls.Views;
using Xamarin.Forms;
using PalsPolls.Tables;
using Syncfusion;
using Syncfusion.ListView.XForms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace PalsPolls
{
    public partial class HomePage : ContentPage
    {
        private readonly RegUserTable m_userTable;

        public HomePage(RegUserTable MyAccount)
        {
            InitializeComponent();            
            m_userTable = MyAccount;
        }


        protected async override void OnAppearing()
        {               
            base.OnAppearing();            
            listView.ItemsSource = await App.myPollServices.Init();
        }

        private async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PreferencesPage(m_userTable));
        }
        private async void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PollCreatingPage(m_userTable));
        }

        private async void TapGestureRecognizer_Tapped_2(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MyAccountPage(m_userTable));
        }

        private async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FriendsPage());
        }

    }
}

