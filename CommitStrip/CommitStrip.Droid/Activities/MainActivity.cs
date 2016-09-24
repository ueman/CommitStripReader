using Android.App;
using Android.OS;
using Android.Views;
using CommitStrip.Core.ViewModel;
using MvvmCross.Droid.Views;

namespace CommitStrip.Droid.Activities
{
    [Activity(Label = "CommitStrip", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.view_main);

            LayoutInflater inflater = LayoutInflater.From(this);
            View header = inflater.Inflate(Resource.Layout.item_actionbar_header, null);

            ActionBar.SetDisplayShowCustomEnabled(true);
            ActionBar.SetDisplayShowTitleEnabled(false);
            ActionBar.CustomView = header;
        }
    }
}