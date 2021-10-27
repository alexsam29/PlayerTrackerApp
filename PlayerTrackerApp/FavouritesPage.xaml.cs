using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlayerTrackerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritesPage : ContentPage
    {
        ObservableCollection<Player> favPlayers = new ObservableCollection<Player>();
        NetworkingManager manager = new NetworkingManager();
        DatabaseManager dbManager = new DatabaseManager();
        public FavouritesPage(ObservableCollection<Player> favList)
        {
            InitializeComponent();
            favPlayers = favList;
            playerInfo.ItemsSource = favPlayers;
            if (favPlayers.Count == 0)
            {
                emptyLabel.Text = "There are currently no players in your favourites!";
                removeBtn.IsEnabled = false;
            }
            else
            {
                emptyLabel.Text = "Total players: " + favPlayers.Count;
            }
        }

        private async void playerInfo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Player player = await manager.getPlayerByID(Convert.ToString((playerInfo.SelectedItem as Player).id), (playerInfo.SelectedItem as Player).leagueName);
            await Navigation.PushAsync(new PlayerDetailsPage(player));
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var removePlayer = menuItem.CommandParameter as Player;
            dbManager.removePlayer(removePlayer);
            favPlayers.Remove(removePlayer);
            if (favPlayers.Count == 0)
            {
                emptyLabel.Text = "There are currently no players in your favourites!";
                removeBtn.IsEnabled = false;
            }
            else
            {
                emptyLabel.Text = "Total players: " + favPlayers.Count;
            }
        }

        private async void RemoveAll_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Remove All?", "This will remove all players from your favourites. This cannot be undone.", "Remove", "cancel");

            if (answer)
            {
                dbManager.removeAll();
                favPlayers.Clear();
                emptyLabel.Text = "There are currently no players in your favourites!";
                removeBtn.IsEnabled = false;
            }
        }
    }
}