using System.Collections.Generic;
using CommitStrip.Core.Models;
using CommitStrip.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace CommitStrip.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool _laoding;
        public bool Loading
        {
            get { return _laoding; }
            set
            {
                _laoding = value;
                RaisePropertyChanged(() => Loading);
                RaisePropertyChanged(() => NotLoading);
            }
        }

        public bool NotLoading { get { return !Loading; } }

        private List<CommitStripItem> _comics; 
        public List<CommitStripItem> Comics {
            get
            {
                return _comics;
                
            }
            set
            {
                _comics = value;
                RaisePropertyChanged(() => Comics);
            }
        }

        private int Page { get; set; }


        public MainViewModel(INetworkConnectivityService _connectivityService) :base (_connectivityService)
        {
        }

        public async void Init()
        {
            Page = 1;
            Title = "CommitStrip";
            OpenPage(Page);
            if (ConnectivityService.IsConnected())
            {
                //TODO
            }
        }


        private async void OpenPage(int page)
        {
            Loading = true;
            Comics = await Mvx.Resolve<ICommitStripDownloadService>().DownloadCommitStrip(page);
            Loading = false;
        }

        private MvxCommand<CommitStripItem> _selectComic;
        public IMvxCommand SelectComicCommand
        {
            get
            {
                _selectComic = _selectComic ?? new MvxCommand<CommitStripItem>(SelectComic);
                return _selectComic;
            }
        }

        private void SelectComic(CommitStripItem item)
        {
            ShowViewModel<ComicDetailViewModel>(new { comic = item.Description, title = item.Title });
        }

        private MvxCommand _previousPageCommand;
        public IMvxCommand OpenPreviousPageCommand
        {
            get
            {
                _previousPageCommand = _previousPageCommand ?? new MvxCommand(OpenPreviousPage);
                return _previousPageCommand;
            }
        }

        private void OpenPreviousPage()
        {
            if (Page == 1) return;
            Page -= 1;
            OpenPage(Page);
        }

        private MvxCommand _nextPageCommand;
        public IMvxCommand OpenNextPageCommand
        {
            get
            {
                _nextPageCommand = _nextPageCommand ?? new MvxCommand(OpenNextPage);
                return _nextPageCommand;
            }
        }

        private void OpenNextPage()
        {
            Page += 1;
            OpenPage(Page);
        }


    }
}