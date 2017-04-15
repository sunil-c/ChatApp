using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ChatApp.Models;
using System.Threading.Tasks;
using Prism.Navigation;
using System.Diagnostics;

namespace ChatApp.ViewModels
{
    public class MessagePageViewModel : BaseViewModel
    {
        public Conversation Conversation { get; set; }
        private Message[] _messages;
        public Message[] Messages
        { 
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }
        public string Text { get; set; }

        private DelegateCommand<Task> _friendPage;
        public DelegateCommand<Task> NavFriendPage => _friendPage != null ? _friendPage : (_friendPage = new DelegateCommand<Task>(GoToFriendPage));

        //selected conversation
        DelegateCommand<Message> _messageSelectedCommand;
        public DelegateCommand<Message> MessageSelectedCommand =>
            _messageSelectedCommand != null ? _messageSelectedCommand : (_messageSelectedCommand = new DelegateCommand<Message>(MessageSelected));


        public MessagePageViewModel(INavigationService navigationService, IWebService webservice, ISettings settings) : base(navigationService, webservice, settings)
        {
            Debug.WriteLine("MessagePageViewModel cstor");
        }

        private async void MessageSelected(Message msg)
        {
            NavigationParameters p = new NavigationParameters();
            p.Add("message", msg);
            await _navigationService.NavigateAsync("FriendPage", p);
        }

        private async void GoToFriendPage(Task obj)
        {
            await _navigationService.NavigateAsync("FriendPage");
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("convo"))
            {
                Conversation = (Conversation)parameters["convo"];
                GetMessages();
            }
                
        }

        public async Task GetMessages()
        {
            if (Conversation == null)
                throw new Exception("No conversation.");

            IsBusy = true;
            try
            {
                Messages = await _webservice.GetMessages(Conversation.Id);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task SendMessage()
        {
            if (_settings.User == null)
                throw new Exception("Not logged in.");

            if (Conversation == null)
                throw new Exception("No conversation.");

            if (string.IsNullOrEmpty(Text))
                throw new Exception("Message is blank.");

            IsBusy = true;
            try
            {
                var message = await _webservice.SendMessage(new Message
                {
                    UserId = _settings.User.Id,
                    ConversationId = Conversation.Id,
                    Text = Text
                });
                //Update our local list of messages
                var messages = new List<Message>();
                if (Messages != null)
                    messages.AddRange(Messages);
                messages.Add(message);

                Messages = messages.ToArray();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
