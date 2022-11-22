
using PalsPolls.Tables;
using PalsPolls.ViewModels;
using PalsPolls.Views;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace PalsPolls
{
    public partial class HomePage : ContentPage
    {
        public readonly RegUserTable m_userTable;

        public HomePage(RegUserTable MyAccount)
        {
            
            InitializeComponent();
            m_userTable = MyAccount;
            
        }

        private async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PreferencesPage(m_userTable));
        }
        private async void TapGestureRecognizer_Tapped_1(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PollCreatingPage(new PollTableViewModel(), m_userTable));
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

