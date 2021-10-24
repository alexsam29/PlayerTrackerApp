using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PlayerTrackerApp
{
    public class Player : INotifyPropertyChanged
    {
        public int id { set; get; }
        public string name { set; get; }
        public string teamshort { set; get; }
        public string teamlong { get; set; }
        public string jersey { get; set; }
        public string pos { get; set; }
        public Bio bio { get; set; }
        public Overall overall { get; set; }
        public List<League> league { get; set; }

        private bool _favourite = false;
        public bool favourite
        {
            get { return _favourite; }
            set
            {
                if (value == _favourite)
                    return;
                _favourite = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(favourite)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
