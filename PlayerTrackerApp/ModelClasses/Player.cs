using System.Collections.Generic;
using SQLite;

namespace PlayerTrackerApp
{
    public class Player
    {
        [PrimaryKey]
        public int id { set; get; }
        public string name { set; get; }
        public string teamshort { set; get; }
        public string teamlong { get; set; }
        public string jersey { get; set; }
        public string pos { get; set; }
        public string leagueName { get; set; }

        [Ignore]
        public Bio bio { get; set; }

        [Ignore]
        public Overall overall { get; set; }

        [Ignore]
        public List<League> league { get; set; }

        public Player()
        {

        }
        public Player(int id, string name, string teamshort, string teamlong, string jersey, string pos, Bio bio, Overall overall, List<League> league)
        {
            this.id = id;
            this.name = name;
            this.teamshort = teamshort;
            this.teamlong = teamlong;
            this.jersey = jersey;
            this.pos = pos;
            this.bio = bio;
            this.overall = overall;
            this.league = league;
        }
    }
}
