using Android.Content;
using Autofac;
using Autofac.Extras.MvvmCross;
using SamsungIssueTestProject.Business;
using SamsungIssueTestProject.Droid;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform.IoC;

namespace SamsungIssueTestProject
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxIoCProvider CreateIocProvider()
        {
            var cb = new ContainerBuilder();

            cb.RegisterModule<DroidModule>();

            return new AutofacMvxIocProvider(cb.Build());
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}