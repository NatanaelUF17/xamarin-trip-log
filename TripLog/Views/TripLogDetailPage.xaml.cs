using System;
using System.Collections.Generic;
using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TripLog.Views
{
    public partial class TripLogDetailPage : ContentPage
    {
        TripLogDetailViewModel Viewmodel => BindingContext as TripLogDetailViewModel;

        public TripLogDetailPage(TripLogEntry tripLogEntry)
        {
            InitializeComponent();

            BindingContext = new TripLogDetailViewModel(tripLogEntry);

            var mapPosition = new Position(Viewmodel.TripLogEntry.Latitude, Viewmodel.TripLogEntry.Longitude);
            var distance = Distance.FromMiles(.5);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(mapPosition, distance));
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = Viewmodel.TripLogEntry.Title,
                Position = mapPosition
            });
        }
    }
}
