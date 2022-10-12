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

