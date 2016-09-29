using Acr.UserDialogs;
using CommitStrip.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace CommitStrip.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<MainViewModel>();

            
        }

        public App()
        {
            Mvx.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
        }
    }
}