using Prism.Unity;
using ChatApp.Views;
using Xamarin.Forms;
using ChatApp.Models;
using ChatApp.Fakes;
using Microsoft.Practices.Unity;
using System.Diagnostics;

namespace ChatApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            Debug.WriteLine("OnInitialized App");
            NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IWebService, FakeWebService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ISettings, FakeSettings>(new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<RegisterPage>();
            Container.RegisterTypeForNavigation<FriendPage>();
            Container.RegisterTypeForNavigation<MessagePage>();
            Container.RegisterTypeForNavigation<MDFrame>();
        }
    }
}
