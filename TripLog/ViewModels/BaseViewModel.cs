using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected INavService NavigationService { private set; get; }

        protected BaseViewModel(INavService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Init()
        {

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class BaseViewModel<TParameter> : BaseViewModel
    {
        protected BaseViewModel(INavService navigationService) : base(navigationService)
        {
        }

        public override void Init()
        {
            Init(default);
        }

        public virtual void Init(TParameter parameter)
        { }
    }
}
