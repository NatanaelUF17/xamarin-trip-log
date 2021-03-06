using System;
using System.Collections.ObjectModel;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        
        ObservableCollection<TripLogEntry> _logEntries;

        public MainViewModel(INavService navigationService) : base(navigationService)
        {
            LogEntries = new ObservableCollection<TripLogEntry>();
        }

        public Command<TripLogEntry> ViewCommand => new Command<TripLogEntry>(async (entry) =>
            await NavigationService.NavigateTo<TripLogDetailViewModel, TripLogEntry>(entry));

        public Command NewCommand => new Command(async () =>
               await NavigationService.NavigateTo<NewTripEntryViewModel>());

        public override void Init()
        {
            LoadEntries();
        }

        public ObservableCollection<TripLogEntry> LogEntries
        {
            get => _logEntries;
            set
            {
                _logEntries = value;
                OnPropertyChanged();
            }
        }

        void LoadEntries()
        {
            LogEntries.Clear();

            LogEntries.Add(new TripLogEntry()
            {
                Title = "Washington Monument",
                Notes = "Amazing",
                Rating = 3,
                Date = new DateTime(2019, 2, 4),
                Latitude = 38.8895,
                Longitude = -77.0352
            });

            LogEntries.Add(new TripLogEntry()
            {
                Title = "Statue of Liberty",
                Notes = "Inspiring!",
                Rating = 4,
                Date = new DateTime(2019, 4, 13),
                Latitude = 40.6892,
                Longitude = -74.0444
            });

            LogEntries.Add(new TripLogEntry()
            {
                Title = "Golden Gate Bridge",
                Notes = "Foggy, but beautiful",
                Rating = 5,
                Date = new DateTime(2019, 4, 26),
                Latitude = 37.8268,
                Longitude = -122.4798
            });
        }
    }
}
