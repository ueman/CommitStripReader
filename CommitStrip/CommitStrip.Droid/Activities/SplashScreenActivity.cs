using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace CommitStrip.Droid.Activities
{
    [Activity(Label = "CommitStrip", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon", Theme = "@style/AppTheme.Splash")]
    public class SplashScreenActivity : MvxSplashScreenActivity
    {
    }
}