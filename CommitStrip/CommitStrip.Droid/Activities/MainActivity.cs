using Android.App;
using Android.OS;
using Android.Views;
using CommitStrip.Core.ViewModels;

namespace CommitStrip.Droid.Activities
{
    [Activity(Label = "CommitStrip", Theme = "@style/AppTheme")]
    public class MainActivity : BaseActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.view_main);

            LayoutInflater inflater = LayoutInflater.From(this);
            View header = inflater.Inflate(Resource.Layout.item_actionbar_header, null);

            SupportActionBar?.SetDisplayShowCustomEnabled(true);
            SupportActionBar?.SetDisplayShowTitleEnabled(false);
            if (SupportActionBar != null)
            {
                SupportActionBar.CustomView = header;
            }
            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.main_activity_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.settings:
                    ViewModel.OpenSettingsPageCommand.Execute();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}