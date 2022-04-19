using System;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripLog
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainPage = new NavigationPage(new MainPage());
            var navigationService = DependencyService.Get<INavService>() as XamarinFormsNavService;

            navigationService.Navigation = mainPage.Navigation;
            navigationService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
            navigationService.RegisterViewMapping(typeof(TripLogDetailViewModel), typeof(TripLogDetailPage));
            navigationService.RegisterViewMapping(typeof(NewTripEntryViewModel), typeof(NewTripEntryPage));

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
