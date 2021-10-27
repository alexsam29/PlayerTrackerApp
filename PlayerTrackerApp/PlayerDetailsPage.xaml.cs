using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlayerTrackerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerDetailsPage : ContentPage
    {
        Player info;
        List<League> stats;
        DatabaseManager dbManager = new DatabaseManager();
        public PlayerDetailsPage(Player player)
        {
            InitializeComponent();
            info = player;
            stats = info.league;

            name.Text = info.name;
            team.Text = info.teamlong;
            number.Text = "#" + info.jersey;
            pos.Text = info.pos;

            born.Text = info.bio.born;
            shoots.Text = info.bio.hold;
            weight.Text = info.bio.kg + "kg";
            height.Text = info.bio.cm + "cm";

            gp.Text = info.overall.gp;
            goals.Text = info.overall.goals;
            assists.Text = info.overall.asists;
            points.Text = info.overall.points;

            pim.Text = info.overall.penalty;
            ppg.Text = info.overall.ppg;
            shg.Text = info.overall.shg;
            gwg.Text = info.overall.gwg;

        }

        protected async override void OnAppearing()
        {
            if (await dbManager.isAdded(info))
                favButton.IsEnabled = false;
            base.OnAppearing();
        }

        private void Stats_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SeasonStatsPage(info.league));
        }

        private void Favourite_Clicked(object sender, EventArgs e)
        {
            dbManager.addPlayer(info);
            favButton.IsEnabled = false;

            string[] names = info.name.Split(' ');
            DisplayAlert("Player added to favourites!", names[1] + " " + names[0] + " was successfully added to your favourites list.", "Okay");
        }
    }
}