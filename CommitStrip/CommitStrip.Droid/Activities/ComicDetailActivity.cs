using Android.App;
using Android.OS;
using Android.Views;
using CommitStrip.Core.ViewModels;

namespace CommitStrip.Droid.Activities
{
    [Activity(Label = "ComicDetailActivity", Theme = "@style/AppTheme")]
    public class ComicDetailActivity : BaseActivity<ComicDetailViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.view_comic_detail);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home: OnBackPressed();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}