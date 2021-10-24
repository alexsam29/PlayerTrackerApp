using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PlayerTrackerApp
{
    public partial class MainPage : ContentPage
    {
        string playerName;
        string leagueName;
        ObservableCollection<Player> playerResult = new ObservableCollection<Player>();
        ObservableCollection<Player> history = new ObservableCollection<Player>();
        NetworkingManager manager = new NetworkingManager();
        public MainPage()
        {
            InitializeComponent();            
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
    }
}
