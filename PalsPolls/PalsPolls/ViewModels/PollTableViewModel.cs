using System;
using PalsPolls.Tables;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PalsPolls.ViewModels
{
    public class PollTableViewModel : BaseViewModel
    {
        public Guid PostId
        {
            get;
            set;
        }

        public PollTableViewModel()
        {

        }

        public PollTableViewModel(PollTable polltable)
        {
            PostId = polltable.PostId;
            _postUserName = polltable.PostUserName;
            _content = polltable.PostContent;
            _content1 = polltable.PostContent1;
            _content2 = polltable.PostContent2;
            _createdDate = polltable.CreatedDate;
        }

        private string _postUserName;

        public string PostUserName
        {
            get
            {
                return _postUserName;
            }
            set
            {
                SetValue(ref _postUserName, value);
                OnPropertyChanged(nameof(PollTable));

            }
        }

        private string _content;

        public string PostContent
        {
            get
            {
                return _content;
            }
            set
            {
                SetValue(ref _content, value);
                OnPropertyChanged(nameof(PollTable));
            }
        }

        private string _content1;

        public string PostContent1
        {
            get
            {
                return _content1;
            }
            set
            {
                SetValue(ref _content1, value);
                OnPropertyChanged(nameof(PollTable));
            }
        }

        private string _content2;

        public string PostContent2
        {
            get
            {
                return _content2;
            }
            set
            {
                SetValue(ref _content2, value);
                OnPropertyChanged(nameof(PollTable));
            }
        }

        private DateTime _createdDate;

        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                SetValue(ref _createdDate, value);
                OnPropertyChanged(nameof(PollTable));
            }
        }

        public string PollTable
        {
            get
            {
                return $"{PostContent} {PostContent1} {PostContent2} {CreatedDate}";
            }
        }
    }
}
