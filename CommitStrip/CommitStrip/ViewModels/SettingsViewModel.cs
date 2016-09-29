using CommitStrip.Core.Common;
using CommitStrip.Core.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.WebBrowser;

namespace CommitStrip.Core.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public new string Title { get; set; }

        public string CsButtonTitle { get; set; }

        public SettingsViewModel(INetworkConnectivityService connectivityService) : base(connectivityService)
        {
        }

        public void Init()
        {
            Title = "Settings";
            CsButtonTitle = "CommitStrip Webpage";
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
            var task = Mvx.Resolve<IMvxWebBrowserTask>();
            task.ShowWebPage(Constants.CommitStripLink);
        }

        #endregion
    }
}