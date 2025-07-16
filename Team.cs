using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlayerApp
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int MatchesPlayed { get; set; }
        public List<Player> Members { get; set; }


        //constructor 
        public Team(int Id, string teamName, int matchesPlayed, List<Player> members)
        {
            TeamID = Id;
            TeamName = teamName;
            MatchesPlayed = matchesPlayed;
            Members = members;

        }

        //tostring
        public override string ToString()
        {
            return $"Team Number: {TeamID}, Team Name: {TeamName}, Matches Played as Team: {MatchesPlayed}";
        }
    }
}
