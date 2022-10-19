using System;
using System.Collections.Generic;
using PalsPolls.Tables;
using Xamarin.Forms;

namespace PalsPolls.Views
{
    public partial class MyAccountPage : ContentPage
    {
        private readonly RegUserTable m_usertable;
        public MyAccountPage(RegUserTable MyAccount)
        {
            InitializeComponent();
            m_usertable = MyAccount;

        }
    }
}

