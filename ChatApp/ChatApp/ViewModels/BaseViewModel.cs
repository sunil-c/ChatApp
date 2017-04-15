using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ChatApp.Models;
using Prism.Navigation;
using System.Diagnostics;

namespace ChatApp.ViewModels
{
    public class BaseViewModel : BindableBase, INavigatedAware
    {
        protected readonly IWebService _webservice;
        protected readonly ISettings _settings;
        protected readonly INavigationService _navigationService;

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetProperty(ref _isBusy, value);
            }
        }

        public BaseViewModel(INavigationService navigationService, IWebService webservice, ISettings settings)
        {
            _webservice = webservice;
            _settings = settings;
            _navigationService = navigationService;

            Debug.WriteLine("BaseViewModel cstor");
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
