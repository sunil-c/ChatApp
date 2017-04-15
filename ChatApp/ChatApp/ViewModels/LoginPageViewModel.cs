using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Models;
using Prism.Navigation;
using System.Diagnostics;

namespace ChatApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string LoginMessage { get; set; }

        private DelegateCommand<Task> _callLogin;
        public DelegateCommand<Task> CallLogin => _callLogin != null ? _callLogin : (_callLogin = new DelegateCommand<Task>(Login));

        public LoginPageViewModel(INavigationService navigationService, IWebService webservice, ISettings settings): base(navigationService, webservice, settings)
        {
            Debug.WriteLine("LoginpageViewModel cstor");
        }

        private async void Login(Task obj)
        {

            if (string.IsNullOrEmpty(Username))
            {
                LoginMessage = "Fill in the user name";
            }

            if (string.IsNullOrEmpty(Password))
            {
                LoginMessage = "Fill in the password";
            }

            IsBusy = true;
            try
            {
                this._settings.User = await this._webservice.Login(Username, Password);
                this._settings.Save();
                //absolute destination removes this page from teh nav stack
                await _navigationService.NavigateAsync(Constants.MDFramePage);
            }
            finally
            {
                IsBusy = false;
            }

        }

    }
}
