using System.Collections.Generic;
using CommitStrip.Core.Model;
using CommitStrip.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace CommitStrip.Core.ViewModel
{
    public class MainViewModel : MvxViewModel
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


        public MainViewModel()
        {
        }

        public async void Init()
        {
            Loading = true;
            Comics = await Mvx.Resolve<ICommitStripDownloadService>().DownloadCommitStrip(1);
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
            ShowViewModel<ComicDetailViewModel>(new { link = item.ImageLink });
        }

    }
}