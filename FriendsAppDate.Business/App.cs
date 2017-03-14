using MvvmCross.Core.ViewModels;

namespace FriendsAppDate.Business
{
    public class App : MvxApplication
    {
        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        public override void Initialize()
        {
            // Start the app with the Main View Model.
            RegisterAppStart(new AppStart());
        }
    }
}