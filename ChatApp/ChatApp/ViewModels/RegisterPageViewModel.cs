using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ChatApp.Models;
using System.Threading.Tasks;
using Prism.Navigation;

namespace ChatApp.ViewModels
{
    public class RegisterPageViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public RegisterPageViewModel(INavigationService navigationService, IWebService webservice, ISettings settings) : base(navigationService, webservice, settings)
        {

        }

        public async Task Register()
        {
            if (string.IsNullOrEmpty(Username))
                throw new Exception("UserName is blank.");
            if (string.IsNullOrEmpty(Password))
                throw new Exception("Password is blank.");
            if (Password != ConfirmPassword)
                throw new Exception("Passwords don't match.");
            IsBusy = true;
            try
            {
                _settings.User = await _webservice.Register(new User { UserName = Username, Password = Password, });
                _settings.Save();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
