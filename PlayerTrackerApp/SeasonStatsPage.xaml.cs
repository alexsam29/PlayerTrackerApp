using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlayerTrackerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeasonStatsPage : ContentPage
    {
        List<League> stats;
        public SeasonStatsPage(List<League> sznStats)
        {
            InitializeComponent();
            stats = sznStats;
            seasonStats.ItemsSource = stats;
            totalSeasons.Text = "Total Seasons: " + Convert.ToString(stats.Count());
        }
    }
}