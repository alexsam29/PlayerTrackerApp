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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        ObservableCollection<Player> history;
        public HistoryPage(ObservableCollection<Player> searchHistory)
        {
            InitializeComponent();
            history = searchHistory;
            historyList.ItemsSource = history;
        }

        private void historyList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Player selected = historyList.SelectedItem as Player;
            Navigation.PushAsync(new PlayerDetailsPage(selected));
        }
    }
}