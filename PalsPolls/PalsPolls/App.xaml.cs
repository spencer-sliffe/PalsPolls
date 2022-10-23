using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using PalsPolls.Services;
using PalsPolls.Views;
using PalsPolls.Tables;


namespace PalsPolls
{
    public partial class App : Application
    {
        private static DataBaseServices db;
        private static PollServices db1;
      
        public static PollServices myPollServices
        {
            get
            {
                if (db1 == null)
                {
                    db1 = new PollServices(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PollDataBase.db3"));
                }
                return db1;
            }
        }

        public static DataBaseServices myDataBase
        {
            get
            {
                if (db == null)
                {
                    db = new DataBaseServices(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDataBase.db3"));

                }
                return db;
            }
        }


        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new SignIn());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

