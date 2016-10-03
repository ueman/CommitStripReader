using CommitStrip.Core.Common;
using CommitStrip.Core.Helpers;
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

        public bool EnglishLanguage
        {
            get { return ComicLanguage.Equals(Constants.EnglishLanguageComicCode); }
            set {
                if (value)
                {
                    ComicLanguage = Constants.EnglishLanguageComicCode;
                    RaisePropertyChanged(() => FrenchLanguage);
                    RaisePropertyChanged(() => EnglishLanguage);
                }
            }
        }

        public bool FrenchLanguage
        {
            get { return ComicLanguage.Equals(Constants.FrenchLanguageComicCode); }
            set {
                if (value)
                {
                    ComicLanguage = Constants.FrenchLanguageComicCode;
                    RaisePropertyChanged(() => FrenchLanguage);
                    RaisePropertyChanged(() => EnglishLanguage);
                }
            }
        }

        public string ComicLanguage
        {
            get { return Settings.ComicLanguageSettings; }
            set { Settings.ComicLanguageSettings = value; }
        }

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