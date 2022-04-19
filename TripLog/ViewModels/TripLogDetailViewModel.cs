using System;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class TripLogDetailViewModel : BaseViewModel<TripLogEntry>
    {
        public TripLogDetailViewModel(INavService navigationService) : base(navigationService)
        {    
        }

        public override void Init(TripLogEntry tripLogEntry)
        {
            TripLogEntry = tripLogEntry;
        }

        TripLogEntry _tripLogEntry;
        public TripLogEntry TripLogEntry
        {
            get => _tripLogEntry;
            set
            {
                _tripLogEntry = value;
                OnPropertyChanged();
            }
        }
    }
}
