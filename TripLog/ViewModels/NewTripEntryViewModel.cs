  using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class NewTripEntryViewModel : BaseValidationViewModel
    {
        public Command SaveCommand { private set; get; }

        public NewTripEntryViewModel(INavService navigationService) : base(navigationService)
        {
            Date = DateTime.Today;

            SaveCommand = new Command(async () => 
            {
                await SaveTripLog();
                CanSaveTripLog();
            });
        }

        public override void Init()
        {
            
        }

        async Task SaveTripLog()
        {
            var newTripLog = new TripLogEntry
            {
                Title = Title,
                Latitude = Latitude,
                Longitude = Longitude,
                Date = Date,
                Rating = Rating,
                Notes = Notes
            };

            await NavigationService.GoBack();
        }

        bool CanSaveTripLog() => !string.IsNullOrWhiteSpace(Title) && !HasErrors;

        string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                Validate(() => !string.IsNullOrWhiteSpace(_title), "Title must be provided");
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute(); 
            }
        }

        double _latitude;
        public double Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }

        double _longitude;
        public double Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }

        DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        int _rating;
        public int Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                Validate(() => _rating >= 1 && _rating <= 5, "Rating must be between 1 and 5");
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        string _notes;
        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }
    }
}
