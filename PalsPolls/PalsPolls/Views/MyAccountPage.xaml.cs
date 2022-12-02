using PalsPolls.Tables;
using PalsPolls.ViewModels;
using PalsPolls.Views;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace PalsPolls
{
    public partial class MyAccountPage : ContentPage
    {
        private readonly RegUserTable m_userTable;
        private readonly PollTable poll = new PollTable();

        public MyAccountPage(RegUserTable MyAccount)
        {           
            InitializeComponent();
            m_userTable = MyAccount;
            // listView.ItemTapped += ListView_ItemTapped;
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            listView.ItemTapped += ListView_ItemTapped;
        }

        private void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            if (vm.PollTables.Contains(e.ItemData as PollTableViewModel))
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Warning", "You are about to delete a poll", "Okay", "Cancel");

                    if (result)
                    {
                        PollTableViewModel m_poll = e.ItemData as PollTableViewModel;
                        poll.PostId = m_poll.PostId;
                        poll.PostUserName = m_poll.PostUserName;
                        poll.PostContent = m_poll.PostContent;
                        poll.PostContent1 = m_poll.PostContent1;
                        poll.PostContent2 = m_poll.PostContent2;
                        
                        if (poll.PostId != null)
                            DeletePoll(poll);
                        //MessagingCenter.Send(this, Events.PollTableDeleted, vm.PollTables);
                        //vm.PollTables.Remove(e.ItemData as PollTableViewModel);
                        await Navigation.PushAsync(new HomePage(m_userTable));
                    }
                });
            }            
        }

        async void DeletePoll(PollTable m_poll)
        {
            await App.myPollServices.DeletePost(m_poll);
            MessagingCenter.Send(this, Events.PollTableDeleted, m_poll);
        }


        /*private void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        { 
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Warning", "You are about to delete a poll", "Okay", "Cancel");

                if (result)
                {
                    if (e.ItemData == vm.PollTables)
                        vm.PollTables.Remove(e.ItemData as PollTableViewModel);

                    await Navigation.PushAsync(new HomePage(m_userTable));
                    MessagingCenter.Send(this, Events.PollTableDeleted, vm.PollTables);
                }
            });
        }*/

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}

