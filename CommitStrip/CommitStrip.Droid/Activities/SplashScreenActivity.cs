using Android.App;
using MvvmCross.Droid.Views;

namespace CommitStrip.Droid.Activities
{
    [Activity(Label = "CommitStrip", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon", Theme = "@style/AppTheme.Splash")]
    public class SplashScreenActivity : MvxSplashScreenActivity
    {
    }
}