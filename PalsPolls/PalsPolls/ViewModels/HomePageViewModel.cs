using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PalsPolls.Tables;
using PalsPolls.Views;
using Syncfusion.ListView.XForms;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PalsPolls.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private bool _isDataLoaded;

        public DataTemplate ItemTemplate { get; set; }

        public ObservableCollection<PollTableViewModel> PollTables { get; private set; }
            = new ObservableCollection<PollTableViewModel>();

        public ICommand LoadDataCommand { get; private set; }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var polltables = await App.myPollServices.ReadPosts();
            foreach (var polltable in polltables)
                PollTables.Add(new PollTableViewModel(polltable));


            /*SfListView listView = new SfListView
            {
                ItemsSource = PollTables,
                ItemTemplate = new DataTemplate(() =>
                {
                    Label Polllabel = new Label() { FontSize = 18 };
                    Polllabel.SetBinding(Label.TextProperty, "PostContent");

                    Label Option1Label = new Label() { FontSize = 12 };
                    Option1Label.SetBinding(Label.TextProperty, "PostContent1");

                    Label Option2Label = new Label() { FontSize = 12 };
                    Option2Label.SetBinding(Label.TextProperty, "PostContent2");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Children =
                            {
                                Polllabel,
                                Option1Label,
                                Option2Label
                            }
                        }

                    };
                })

            };*/
        }

        public HomePageViewModel()
        {
            
            Task.Run(async () => await LoadData());
            MessagingCenter.Subscribe<PollCreatingPageViewModel, PollTable>
                (this, Events.PollTableAdded, OnPollCreated);
        }

        private void OnPollCreated(PollCreatingPageViewModel source, PollTable polltable)
        {
            PollTables.Add(new PollTableViewModel(polltable));
        }
    }
}

