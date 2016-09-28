using CommitStrip.Core.Services;
using MvvmCross.Core.ViewModels;

namespace CommitStrip.Core.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public SettingsViewModel(INetworkConnectivityService connectivityService) : base(connectivityService)
        {
            Title = "Settings";
        }

        #region Commands

        private MvxCommand _openCsCommand;
        public IMvxCommand OpenCsPageCommand
        {
            get
            {
                _openCsCommand = _openCsCommand ?? new MvxCommand(OpenCsWebPage);
                return _openCsCommand;
            }
        }

        private void OpenCsWebPage()
        {
            //show commit strip page
        }

        #endregion
    }
}