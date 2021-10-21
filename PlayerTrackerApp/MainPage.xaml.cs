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
        ObservableCollection<Player> playersSearched = new ObservableCollection<Player>();
        NetworkingManager manager = new NetworkingManager();
        public MainPage()
        {
            InitializeComponent();            
        }

        async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            Player playData = await manager.getPlayer(playerName, leagueName);
            playersSearched.Add(playData);
            playerInfo.ItemsSource = playersSearched;

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
    }
}
