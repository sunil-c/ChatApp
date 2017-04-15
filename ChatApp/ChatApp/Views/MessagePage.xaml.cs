using Xamarin.Forms;
using ChatApp.ViewModels;
using ChatApp.Models;

namespace ChatApp.Views
{
    public partial class MessagePage : ContentPage
    {
        public MessagePage()
        {
            InitializeComponent();
        }
        private async void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((MessagePageViewModel)this.BindingContext).MessageSelectedCommand.Execute((Message)args.Item);
        }
    }
}
