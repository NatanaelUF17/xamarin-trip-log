using System;
using System.Collections.Generic;
using TripLog.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TripLog.Views
{
    public partial class TripLogDetailPage : ContentPage
    {
        public TripLogDetailPage(TripLogEntry tripLogEntry)
        {
            InitializeComponent();

            var mapPosition = new Position(tripLogEntry.Latitude, tripLogEntry.Longitude);
            var distance = Distance.FromMiles(.5);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(mapPosition, distance));
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = tripLogEntry.Title,
                Position = mapPosition
            });

            title.Text = tripLogEntry.Title;
            date.Text = tripLogEntry.Date.ToString("M");
            rating.Text = $"{tripLogEntry.Rating} star rating";
            notes.Text = tripLogEntry.Notes;
        }
    }
}
