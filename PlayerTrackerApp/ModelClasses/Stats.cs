using System;
using System.Collections.Generic;
using System.Text;

namespace PlayerTrackerApp
{
    public class Stats
    {
        public string goals { set; get; }
        public string assists { set; get; }

        public string points { get; set; }
        public string penalty { get; set; }
        public string ppg { get; set; }
        public string shg { get; set; }
        public string gwg { get; set; }

        public Stats(string goals, string assists, string points, string penalty, string ppg, string shg, string gwg)
        {
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
