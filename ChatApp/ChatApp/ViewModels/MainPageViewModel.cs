using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using ChatApp.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using ChatApp.Fakes;

namespace ChatApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private Conversation[] _conversations;
        public Conversation[] Conversations
        {
            get { return _conversations; }
            set { SetProperty(ref _conversations, value); }
        }

        //navigate to message page command
        private DelegateCommand<Task> _messagePage;
        public DelegateCommand<Task> NavMessagePage => _messagePage != null ? _messagePage : (_messagePage = new DelegateCommand<Task>(GoToMessagePage));
        
        //selected conversation
        DelegateCommand<Conversation> _convoSelectedCommand;
        public DelegateCommand<Conversation> ConvoSelectedCommand =>
            _convoSelectedCommand != null ? _convoSelectedCommand : (_convoSelectedCommand = new DelegateCommand<Conversation>(ConvoSelected));

        //cstor
        public MainPageViewModel(INavigationService navigationService, IWebService webservice, ISettings settings): base(navigationService, webservice, settings)
        {
            Debug.WriteLine("MainpageViewModel cstor");
        }

        private async void ConvoSelected(Conversation convo)
        {
            NavigationParameters p = new NavigationParameters();
            p.Add("convo", convo);
            await _navigationService.NavigateAsync("MessagePage", p);
        }

        private async void GoToMessagePage(Task obj)
        {
            await _navigationService.NavigateAsync("MessagePage");
        }

        public async Task GetConversations()
        {
            if (_settings.User == null)
                throw new Exception("Not logged in.");

            IsBusy = true;
            try
            {
                Conversations = await _webservice.GetConversations(_settings.User.Id);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                this.Title = (string)parameters["title"] + " and Prism";
            GetConversations();
        }
    }
}
