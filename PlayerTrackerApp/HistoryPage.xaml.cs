using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlayerTrackerApp
{
    public partial class HistoryPage : ContentPage
    {
        ObservableCollection<Player> history;
        DatabaseManager dbManager = new DatabaseManager();
        public HistoryPage(ObservableCollection<Player> searchHistory)
        {
            InitializeComponent();
            history = searchHistory;
            historyList.ItemsSource = history;
            if (history.Count == 0)
            {
                emptyLabel.Text = "History is empty";
                favBtn.IsEnabled = false;
            }
        }

        private void historyList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Player selected = historyList.SelectedItem as Player;
            Navigation.PushAsync(new PlayerDetailsPage(selected));
        }

        private async void AddAll_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Player> toAdd = new ObservableCollection<Player>();
            for (int i = 0; i < history.Count(); ++i)
            {
                if (!await dbManager.isAdded(history[i]))
                    toAdd.Add(history[i]);
            }

            if (toAdd.Count == 0)
                await DisplayAlert("Players Already Added!", "All players have already been added to favourites", "Okay");
            else
            {
                for (int i = 0; i < toAdd.Count; ++i)
                    dbManager.addPlayer(toAdd.ElementAt(i));
                await DisplayAlert("Players Added!", "All players not already in your favourites have been added to favourites.", "Okay");
            }
        }

        private async void AddFavourite_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var addPlayer = menuItem.CommandParameter as Player;

            if (!await dbManager.isAdded(addPlayer))
            {
                dbManager.addPlayer(addPlayer);
                //favPlayers.Add(addPlayer);
                string[] names = addPlayer.name.Split(' ');
                await DisplayAlert("Player added to favourites!", names[1] + " " + names[0] + " was successfully added to your favourites list.", "Okay");
            }
            else
                await DisplayAlert("Player already added!", "This player is already in your favourites list.", "Okay");
        }
    }
}