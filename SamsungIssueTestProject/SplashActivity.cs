using Android.App;
using Android.Content.PM;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace SamsungIssueTestProject
{
    [Activity(MainLauncher = true, 
              NoHistory = true,
              Name = "SamsungIssueTestProject.SplashActivity",
              ScreenOrientation = ScreenOrientation.Portrait,
              ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class SplashActivity : MvxSplashScreenActivity, IMvxAppStart
    {
        public SplashActivity() : base(Resource.Layout.activity_splashscreen) { }

        public void Start(object hint = null)
        {
        }
    }
}