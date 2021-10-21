using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerTrackerApp
{
    public class Overall
    {
        public string gp { set; get; }
        public string goals { set; get; }

        public string assists { get; set; }
        public string points { get; set; }
        public string penalty { get; set; }
        public string ppg { get; set; }
        public string shg { get; set; }
        public string gwg { get; set; }

        public Overall(string gp, string goals, string assists, string points, string penalty, string ppg, string shg, string gwg)
        {
            this.gp = gp;
            this.goals = goals;
            this.assists = assists;
            this.points = points;
            this.penalty = penalty;
            this.ppg = ppg;
            this.shg = shg;
            this.gwg = gwg;
        }
    }
}
