using System;
using System.Collections.Generic;
using System.Linq;
using TripLog.Models;
using Xamarin.Forms;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var items = new List<TripLogEntry>()
            {
                new TripLogEntry()
                {
                    Title = "Washington Monument",
                    Notes = "Amazing",
                    Rating = 3,
                    Date = new DateTime(2019, 2, 4),
                    Latitude = 38.8895,
                    Longitude = -77.0352
                },
                new TripLogEntry()
                {
                    Title = "Statue of Liberty",
                    Notes = "Inspiring!",
                    Rating = 4,
                    Date = new DateTime(2019, 4, 13),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                },
                new TripLogEntry()
                {
                    Title = "Golden Gate Bridge",
                    Notes = "Foggy, but beautiful",
                    Rating = 5,
                    Date = new DateTime(2019, 4, 26),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                }
            };

            trips.ItemsSource = items;
        }

        void NewEntry_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewTripEntryPage());
        }

        async void OnTripSelected(object sender, SelectionChangedEventArgs e)
        {
            var trip = (TripLogEntry)e.CurrentSelection.FirstOrDefault();

            if (trip != null)
            {
                await Navigation.PushAsync(new TripLogDetailPage(trip));
            }

            trips.SelectedItem = null;
        }
    }
}
