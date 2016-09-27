using Android.Content;
using CommitStrip.Core;
using CommitStrip.Core.Services;
using CommitStrip.Droid.Services;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace CommitStrip.Droid
{
    public class Setup : MvxAndroidSetup
    {

        private Context _context;

        public Setup(Context applicationContext)
            : base(applicationContext)
        {
            _context = applicationContext;
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();
            MvvmCross.Plugins.DownloadCache.PluginLoader.Instance.EnsureLoaded();

            Mvx.RegisterSingleton<INetworkConnectivityService>(new ConnectivityService(_context));
        }
    }
}