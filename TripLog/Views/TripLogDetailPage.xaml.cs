using System;
using System.Collections.Generic;
using System.ComponentModel;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TripLog.Views
{
    public partial class TripLogDetailPage : ContentPage
    {
        TripLogDetailViewModel ViewModel => BindingContext as TripLogDetailViewModel;

        public TripLogDetailPage()
        {
            InitializeComponent();

            BindingContext = new TripLogDetailViewModel(DependencyService.Get<INavService>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += OnViewModelPropertyChanged;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (ViewModel != null)
            {
                ViewModel.PropertyChanged -= OnViewModelPropertyChanged;
            }
        }

        void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TripLogDetailViewModel.TripLogEntry))
            {
                UpdateMap();
            }
        }

        void UpdateMap()
        {
            if (ViewModel.TripLogEntry == null)
            {
                return;
            }

            var mapPosition = new Position(ViewModel.TripLogEntry.Latitude, ViewModel.TripLogEntry.Longitude);
            var distance = Distance.FromMiles(.5);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(mapPosition, distance));
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = ViewModel.TripLogEntry.Title,
                Position = mapPosition
            });
        }
    }
}
