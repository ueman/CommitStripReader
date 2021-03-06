using Acr.UserDialogs;
using Android.App;
using Android.OS;
using CommitStrip.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;


namespace CommitStrip.Droid.Activities
{
    [Activity(Theme = "@style/AppTheme", Label = "BaseActivity")]
    public class BaseActivity<T> : MvxAppCompatActivity<T> where T : BaseViewModel
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            UserDialogs.Init(Application);
            base.OnCreate(savedInstanceState);
            
            var set = this.CreateBindingSet<BaseActivity<T>, T>();
            set.Bind(SupportActionBar).For(v => v.Title).To(vm => vm.Title);
            set.Apply();
        }
    }
}