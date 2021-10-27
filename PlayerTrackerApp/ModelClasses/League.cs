namespace PlayerTrackerApp
{
    public class League
    {
        public string name { set; get; }
        public string team { set; get; }

        public Stats stats { get; set; }

        public League(string name, string team, Stats stats)
        {
            this.name = name;
            this.team = team;
            this.stats = stats;
        }
    }
}
