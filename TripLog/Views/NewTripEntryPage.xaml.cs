using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public partial class NewTripEntryPage : ContentPage
    {
        NewTripEntryViewModel ViewModel => BindingContext as NewTripEntryViewModel;

        public NewTripEntryPage()
        {
            InitializeComponent();

            BindingContextChanged += NewTripEntryPage_BindingContextChanged;
            BindingContext = new NewTripEntryViewModel(DependencyService.Get<INavService>());
        }

        void NewTripEntryPage_BindingContextChanged(object sender, EventArgs e)
        {
            ViewModel.ErrorsChanged += ViewModel_ErrorsChanged;
        }

        void ViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            var propertiesHasErrors = (ViewModel.GetErrors(e.PropertyName) as List<string>)?.Any() == true;

            switch (e.PropertyName)
            {
                case nameof(ViewModel.Title):
                    title.LabelColor = propertiesHasErrors ? Color.Red : Color.Black;
                    break;
                case nameof(ViewModel.Rating):
                    rating.LabelColor = propertiesHasErrors ? Color.Red : Color.Black;
                    break;
                default:
                    break;
            }
        }
    }
}
