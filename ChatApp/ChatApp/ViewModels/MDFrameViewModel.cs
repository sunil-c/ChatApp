using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms;
using ChatApp.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ChatApp.ViewModels
{
    public class MDFrameViewModel : BindableBase, IMasterDetailPageOptions
    {
        protected readonly IWebService _webservice;
        protected readonly ISettings _settings;
        protected readonly INavigationService _navigationService;

        //navigate to message page command
        private DelegateCommand<string> _somePage;
        public DelegateCommand<string> NavPage => _somePage != null ? _somePage : (_somePage = new DelegateCommand<string>(GoToPage));

        public MDFrameViewModel(INavigationService navigationService, IWebService webservice, ISettings settings)
        {
            _webservice = webservice;
            _settings = settings;
            _navigationService = navigationService;

            Debug.WriteLine("MDTestViewModel cstor");
        }

        public bool IsPresentedAfterNavigation
        {
            get
            {
                return Device.Idiom != TargetIdiom.Phone;
            }
        }

        private void GoToPage(string s)
        {
            _navigationService.NavigateAsync(s.ToString());
        }

    }
}
