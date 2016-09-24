using CommitStrip.Core.Services;
using CommitStrip.Core.ViewModel;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace CommitStrip.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainViewModel>();
        }

        public App()
        {
            Mvx.ConstructAndRegisterSingleton<ICommitStripDownloadService, CommitStripDownloadService>();
        }
    }
}