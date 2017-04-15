using Xamarin.Forms;
using System.Diagnostics;
using ChatApp.ViewModels;
using ChatApp.Models;

namespace ChatApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            ((MainPageViewModel)this.BindingContext).ConvoSelectedCommand.Execute((Conversation)args.Item);
        }

        private async void OnAddItemClicked(object sender, ItemTappedEventArgs args)
        {
            //nothing yet
        }

    }
}
