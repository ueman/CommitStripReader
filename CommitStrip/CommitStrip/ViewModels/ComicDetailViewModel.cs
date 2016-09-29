using CommitStrip.Core.Services;

namespace CommitStrip.Core.ViewModels
{
    public class ComicDetailViewModel : BaseViewModel
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

        public string Comic { get; set; }

        public ComicDetailViewModel(INetworkConnectivityService _connectivityService) : base(_connectivityService)
        {
            
        }

        public void Init(string comic, string title)
        {
            Title = title;
            ImageLink = "";
            Comic = comic;
        }
    }
}