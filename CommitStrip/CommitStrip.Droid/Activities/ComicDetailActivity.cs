using Android.App;
using Android.OS;
using CommitStrip.Core.ViewModel;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;

namespace CommitStrip.Droid.Activities
{
    [Activity(Label = "ComicDetailActivity")]
    public class ComicDetailActivity : MvxActivity<ComicDetailViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.view_comic_detail);
        }
    }
}