using MvvmCross.Core.ViewModels;

namespace CommitStrip.Core.ViewModel
{
    public class ComicDetailViewModel : MvxViewModel
    {
        private string _imageLink;

        public string ImageLink
        {
            get { return _imageLink; }
            set
            {
                _imageLink = value;
                RaisePropertyChanged(() => ImageLink);
            }
        }

        public void Init(string link)
        {
            ImageLink = link;
        }
    }
}