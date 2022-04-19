using System;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public class TripLogDetailViewModel : BaseViewModel
    {
        public TripLogDetailViewModel(TripLogEntry tripLogEntry)
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
