using CommitStrip.Core.Services;
using MvvmCross.Core.ViewModels;

namespace CommitStrip.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        //Services
        public INetworkConnectivityService ConnectivityService { get; set; }

        private string _title;

        public string Title
        {
            get { return _title;}
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        public BaseViewModel(INetworkConnectivityService connectivityService)
        {
            ConnectivityService = connectivityService;
        }
         
    }
}