using System;
using System.Collections.Generic;
using System.Linq;
using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
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
