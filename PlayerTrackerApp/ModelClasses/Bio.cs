using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PlayerTrackerApp
{
    public class Bio
    {
        public string born { set; get; }
        public string hold { set; get; }
        public string kg { get; set; }
        public string cm { get; set; }

        public Bio(string born, string hold, string kg, string cm)
        {
            this.born = born;
            this.hold = hold;
            this.kg = kg;
            this.cm = cm;
        }
    }
}
