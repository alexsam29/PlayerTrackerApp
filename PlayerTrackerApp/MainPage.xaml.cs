using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PlayerTrackerApp
{
    public partial class MainPage : ContentPage
    {
        string playerName;
        string leagueName;
        ObservableCollection<Player> favPlayers = new ObservableCollection<Player>();
        ObservableCollection<Player> playerResult = new ObservableCollection<Player>();
        ObservableCollection<Player> history = new ObservableCollection<Player>();
        NetworkingManager manager = new NetworkingManager();
        DatabaseManager dbManager = new DatabaseManager();
        public MainPage()
        {
            InitializeComponent();            
        }

        protected async override void OnAppearing()
        {
            favPlayers = await dbManager.createTable();
            base.OnAppearing();
        }

        async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            if (playerName != null && leagueName != null)
            {
                Player playData = await manager.getPlayer(playerName, leagueName);
                if(playData.name != null)
                {
                    if (playerResult.Count == 1)
                        playerResult.Clear();
                    playData.leagueName = leagueName;
                    playerResult.Add(playData);
                    history.Insert(0, playData);
                    playerInfo.ItemsSource = playerResult;
                }
                else
                    await DisplayAlert("Error!", "Player not found. Make sure first and last name are spelt correctly.", "Okay");
            }
            else if (leagueName == null && playerName == null)
                await DisplayAlert("Error!", "Please select a league and type in a player's name before searching.", "Okay");
            else if (leagueName == null)
                await DisplayAlert("Error!", "Please select a league before searching.", "Okay");
            else if (playerName == null)
                await DisplayAlert("Error!", "Please input first and last name to search for a player.", "Okay");
        }

        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            playerName = e.NewTextValue;
        }

        void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (e.Value == true)
                leagueName = rb.Value.ToString();
        }

        void Search_Button_Clicked(object sender, EventArgs e)
        {
            SearchBar_SearchButtonPressed(sender, e);
        }

        private void playerInfo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new PlayerDetailsPage(playerResult[0]));

        }

        private void History_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HistoryPage(history));
        }

        private void Favourites_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FavouritesPage(favPlayers));
        }

        private async void AddFavourite_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var addPlayer = menuItem.CommandParameter as Player;

            if(!await dbManager.isAdded(addPlayer))
            {
                dbManager.addPlayer(addPlayer);
                favPlayers.Add(addPlayer);
                string[] names = addPlayer.name.Split(' ');
                await DisplayAlert("Player added to favourites!", names[1] + " " + names[0] + " was successfully added to your favourites list.", "Okay");
            }
            else
                await DisplayAlert("Player already added!", "This player is already in your favourites list.", "Okay");


        }
    }
}
