using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(XamarinFormsNavService))]
namespace TripLog.Services
{
    public class XamarinFormsNavService : INavService
    {
        public INavigation Navigation { get; set; }

        bool INavService.CanGoBack => throw new NotImplementedException();

        readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public XamarinFormsNavService()
        {
        }

        public void RegisterViewMapping(Type viewmodel, Type view)
        {
            _map.Add(viewmodel, view);
        }

        public event PropertyChangedEventHandler CanGoBackChanged;

        public bool CanGoBack()
        {
            return Navigation.NavigationStack != null && Navigation.NavigationStack.Count > 0;
        }

        public void ClearBackStack()
        {
            if (Navigation.NavigationStack.Count < 2)
            {
                return;
            }

            for (var x = 0; x < Navigation.NavigationStack.Count - 1; x++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[x]);
            }
        }

        public async Task GoBack()
        {
            if (CanGoBack())
            {
                await Navigation.PopAsync(true);
                OnCanGoBackChanged();
            }
        }

        public async Task NavigateTo<viewModel>() where viewModel : BaseViewModel
        {
            await NavigateToView(typeof(viewModel));
            if (Navigation.NavigationStack.Last().BindingContext is BaseViewModel)
            {
                ((BaseViewModel)Navigation.NavigationStack.Last().BindingContext).Init();
            }

        }

        public async Task NavigateTo<viewModel, TParameter>(TParameter parameter) where viewModel : BaseViewModel
        {
            await NavigateToView(typeof(viewModel));

            if (Navigation.NavigationStack.Last().BindingContext is BaseViewModel<TParameter>)
            {
                ((BaseViewModel<TParameter>)(Navigation.NavigationStack.Last().BindingContext)).Init(parameter);
            }
        }

        public void NavigateToUri(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("Invalid URI");
            }

            Launcher.OpenAsync(uri);
        }

        public void RemoveLastView()
        {
            if (Navigation.NavigationStack.Count < 2)
            {
                return;
            }

            var lastView = Navigation.NavigationStack[Navigation.NavigationStack.Count - 2];
            Navigation.RemovePage(lastView);
        }

        async Task NavigateToView(Type viewModelType)
        {
            if (!_map.TryGetValue(viewModelType, out Type viewType))
            {
                throw new ArgumentException($"No view found in view mapping for {viewModelType.FullName}.");
            }

            var constructor = viewType.GetTypeInfo()
                                      .DeclaredConstructors
                                      .FirstOrDefault(dc => !dc.GetParameters().Any());
            var view = constructor.Invoke(null) as Page;

            await Navigation.PushAsync(view, true);
        }

        void OnCanGoBackChanged()
        {
            CanGoBackChanged?.Invoke(this, new PropertyChangedEventArgs("CanGoBack"));
        }
    }
}
