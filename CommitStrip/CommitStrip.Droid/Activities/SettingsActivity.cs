using Android.App;
using Android.OS;
using Android.Views;
using CommitStrip.Core.ViewModels;

namespace CommitStrip.Droid.Activities
{
    [Activity(Label = "SettingsActivity", Theme = "@style/AppTheme")]
    public class SettingsActivity : BaseActivity<SettingsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.view_settings);

            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    OnBackPressed();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}