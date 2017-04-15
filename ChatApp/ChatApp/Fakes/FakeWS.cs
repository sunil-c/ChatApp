using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Models;

namespace ChatApp.Fakes
{
    public class FakeSettings : ISettings
    {
        public User User { get; set; }
        public void Save() { }
    }

        
    public class FakeWebService: IWebService
    {
        public int SleepDuration { get; set; }

        public FakeWebService()
        {
            SleepDuration = 1;
        }

        private Task Sleep()
        {
            return Task.Delay(SleepDuration);
        }

        public async Task<User> Login(string username, string password)
        {
            await Sleep();

            return new User { Id = "1", UserName = username };
        }

        public async Task<User> Register(User user)
        {
            await Sleep();

            return user;
        }

        public async Task<User[]> GetFriends(string userId)
        {
            await Sleep();

            return new[]
            {
                new User { Id = "2", UserName = "bobama" },
                new User { Id = "3", UserName = "bobloblaw" },
                new User { Id = "4", UserName = "gmichael" },
                new User { Id = "5", UserName = "tprince" },
                new User { Id = "6", UserName = "xjohnson" },
                new User { Id = "7", UserName = "ahornsby" },
                new User { Id = "8", UserName = "ohenly" },
                new User { Id = "9", UserName = "wterry" }

            };
        }

        public async Task<User> AddFriend(string userId, string username)
        {
            await Sleep();

            return new User { Id = "10", UserName = username };
        }

        public async Task<Conversation[]> GetConversations(string userId)
        {
            await Sleep();

            return new[]
            {
                new Conversation { Id = "1", UserId = "2", UserName = "bobama", LastMessage = "Hey!" },
                new Conversation { Id = "1", UserId = "3", UserName = "bobloblaw", LastMessage = "Have you seen that new movie?" },
                new Conversation { Id = "1", UserId = "4", UserName = "gmichael", LastMessage = "What?" },
            };
        }

        public async Task<Message[]> GetMessages(string conversationId)
        {
            await Sleep();

            return new[]
            {
                new Message
                {
                    Id = "1",
                    ConversationId = conversationId,
                    UserId = "2",
                    UserName = "bobama",
                    Text = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    Date = DateTime.Now.AddMinutes(-15)
                },
                new Message
                {
                    Id = "2",
                    ConversationId = conversationId,
                    UserId = "2",
                    UserName = "bobama",
                    Text = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    Date = DateTime.Now.AddMinutes(-20)
                },
                new Message
                {
                    Id = "3",
                    ConversationId = conversationId,
                    UserId = "3",
                    UserName = "bobloblaw",
                    Text = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    Date = DateTime.Now.AddMinutes(-25)
                },
                new Message
                {
                    Id = "4",
                    ConversationId = conversationId,
                    UserId = "3",
                    UserName = "bobloblaw",
                    Text = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    Date = DateTime.Now.AddMinutes(-27)
                },
                new Message
                {
                    Id = "5",
                    ConversationId = conversationId,
                    UserId = "4",
                    UserName = "gmichael",
                    Text = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                    Date = DateTime.Now.AddMinutes(-30)
                }
            };
        }

        public async Task<Message> SendMessage(Message message)
        {
            await Sleep();

            return message;
        }
    }
}
