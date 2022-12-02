using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PalsPolls.Tables;
using PalsPolls.Views;
using Syncfusion.ListView.XForms;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PalsPolls.ViewModels
{
    public class MyAccountPageViewModel : BaseViewModel
    {
        private bool _isDataLoaded;

        private readonly string myUN;

        public DataTemplate ItemTemplate
        {
            get;
            set;
        }

        public ObservableCollection<PollTableViewModel> PollTables
        {
            get;
            private set;
        } = new ObservableCollection<PollTableViewModel>();

        public ICommand LoadDataCommand
        {
            get;
            private set;
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var polltables = await App.myPollServices.ReadPosts();
            foreach (var polltable in from polltable in polltables where polltable.PostUserName == myUN select polltable)
                PollTables.Add(new PollTableViewModel(polltable));
        }
        public MyAccountPageViewModel()
        {
            myUN = App._userName;
            Task.Run(async () => await LoadData());
        }

    }
}