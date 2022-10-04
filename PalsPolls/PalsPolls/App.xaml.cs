using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PalsPolls
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

