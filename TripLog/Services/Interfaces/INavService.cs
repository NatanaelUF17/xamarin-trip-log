using System;
using System.ComponentModel;
using System.Threading.Tasks;
using TripLog.ViewModels;

namespace TripLog.Services
{
    public interface INavService
    {
        bool CanGoBack { get; }
        Task GoBack();
        Task NavigateTo<viewModel>() where viewModel : BaseViewModel;
        Task NavigateTo<viewModel, TParameter>(TParameter parameter) where viewModel : BaseViewModel;
        void RemoveLastView();
        void ClearBackStack();
        void NavigateToUri(Uri uri);

        event PropertyChangedEventHandler CanGoBackChanged;
    }
}
