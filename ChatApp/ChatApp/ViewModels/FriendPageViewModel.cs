using ChatApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Navigation;

namespace ChatApp.ViewModels
{
    public class FriendPageViewModel : BaseViewModel
    {
        public User[] Friends { get; private set; }
        public string Username { get; set; }

        private DelegateCommand<Task> _mainPage;
        public DelegateCommand<Task> NavMainPage => _mainPage != null ? _mainPage : (_mainPage = new DelegateCommand<Task>(GoToMainPage));

        public FriendPageViewModel(INavigationService navigationService, IWebService webservice, ISettings settings) : base(navigationService, webservice, settings)
        {

        }

        private async void GoToMainPage(Task obj)
        {
            await _navigationService.NavigateAsync("app:///NavigationPage/MainPage");
            //await _navigationService.GoBackAsync();
        }

        public async Task GetFriends()
        {
            if (_settings.User == null)
                throw new Exception("Not logged in.");

            IsBusy = true;
            try
            {
                Friends = await _webservice.GetFriends(_settings.User.Id);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task AddFriend()
        {
            if (_settings.User == null)
                throw new Exception("Not logged in.");

            if (string.IsNullOrEmpty(Username))
                throw new Exception("UserName is blank.");

            IsBusy = true;
            try
            {
                var friend = await _webservice.AddFriend(_settings.User.Id, Username);

                //Update our local list of friends
                var friends = new List<User>();
                if (Friends != null)
                    friends.AddRange(Friends);
                friends.Add(friend);

                Friends = friends.OrderBy(f => f.UserName).ToArray();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
