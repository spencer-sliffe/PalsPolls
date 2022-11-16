using System;
using System.Threading.Tasks;
using System.Windows.Input;
using PalsPolls.Tables;
using Xamarin.Essentials;
using Xamarin.Forms;
using PalsPolls.Views;

namespace PalsPolls.ViewModels
{
    public class PollCreatingPageViewModel : BaseViewModel
    {
        public PollTable PollTable { get; private set; }
        public ICommand PostCommand { get; private set; }

        public PollCreatingPageViewModel(PollTableViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            PostCommand = new Command(async () => await Post());

            PollTable = new PollTable
            {
                PostId = viewModel.PostId,
                PostUserName = viewModel.PostUserName,
                PostContent = viewModel.PostContent,
                PostContent1 = viewModel.PostContent1,
                PostContent2 = viewModel.PostContent2
            };

            async Task Post()
            {
                if (String.IsNullOrWhiteSpace(PollTable.PostContent) || String.IsNullOrWhiteSpace(PollTable.PostContent1) || String.IsNullOrWhiteSpace(PollTable.PostContent2))
                {
                    return;
                }
                if (PollTable.PostId == null)
                {
                    await App.myPollServices.CreatePoll(PollTable);
                    MessagingCenter.Send(this, Events.PollTableAdded, PollTable);
                }
            }
        }
    }
}

