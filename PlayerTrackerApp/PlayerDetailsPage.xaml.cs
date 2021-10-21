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
    public partial class PlayerDetailsPage : ContentPage
    {
        Player info;
        public PlayerDetailsPage(ObservableCollection<Player> player)
        {
            InitializeComponent();
            info = player[0];

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

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}