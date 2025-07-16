using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerApp
{
    public class TeamManager
    {
        public static List<Team> Teams = SerializeData.DeserializeTeams();
        //List<Player> teamPlayers = new List<Player>();

        public static void AddTeam()
        {
            Console.WriteLine("Enter your team Id:");
            int teamId = int.Parse(Console.ReadLine());
            //check if id is same as previously entered then ask to reiunter id
            Console.WriteLine("Enter your team name:");
            string teamName = Console.ReadLine();
            Console.WriteLine("Matches Won by Team");
            int matchesPlayed = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter team member details: ");
            Console.WriteLine("Number of players you want to the team");
            int playerCount = int.Parse(Console.ReadLine());
            List<Player> teamPlayers = new List<Player>();

            for (int i = 0; i < playerCount; i++)
            {
                Console.WriteLine($"\n Adding Player {i + 1}");
                PlayerManager.AddPlayer();
                Player lastAddedPlayer = PlayerManager.Players.Last();
                teamPlayers.Add(lastAddedPlayer);
            }
            Team t = new Team(teamId, teamName, matchesPlayed, teamPlayers);
            Teams.Add(t);
            SerializeData.SerializeTeams(Teams);


            Console.WriteLine("Team Succesfully Created");

        }

        public static void DisplayTeams()
        {
            {
                if (Teams.Count == 0)
                {
                    Console.WriteLine("No teams to display.");
                    return;
                }

                Console.WriteLine("\nTeam List:");
                foreach (var team in Teams)
                {
                    Console.WriteLine(team);
                    Console.WriteLine("Members:");
                    foreach (var player in team.Members)
                    {
                        Console.WriteLine($" - {player.Name} (Jersey #{player.JerseyNumber})");
                    }
                    Console.WriteLine();
                }
            }
        }

        //public static void DisplayPlayers()
        //{
        //    Console.WriteLine("Players List:");
        //    foreach (var team in TeamManager.Teams)
        //    {
        //        foreach (var player in team.Members)
        //        {
        //            Console.WriteLine($"Jersey Number: {player.JerseyNumber}, Name: {player.Name}, Age: {player.Age}, Fifties: {player.Fifties}, Hundreds: {player.Hundreds}, Runs: {player.Runs}");
        //        }
        //    }
        //}

        public static void UpdateTeamRunsMadeByPlayers()
        {
            if (Teams.Count < 2)
            {
                Console.WriteLine("Need at least two teams to simulate a match.");
                return;
            }

            Console.WriteLine("Score Calculation of Match between");
            Console.WriteLine($"1. {Teams[0].TeamName}");
            Console.WriteLine($"2. {Teams[1].TeamName}");

            int team1total = SimulateInnings(Teams[0]);
            int team2total = SimulateInnings(Teams[1]);

            SerializeData.SerializeTeams(Teams);

            // Match Result
            Console.WriteLine($"\nMatch Result:");
            Console.WriteLine($"{Teams[0].TeamName}: {team1total} runs");
            Console.WriteLine($"{Teams[1].TeamName}: {team2total} runs");

            if (team1total > team2total)
                Console.WriteLine($"{Teams[0].TeamName} wins!");
            else if (team2total > team1total)
                Console.WriteLine($"{Teams[1].TeamName} wins!");
            else
                Console.WriteLine("It's a tie!");
        }

        public static int SimulateInnings(Team team)
        {
            Console.WriteLine($"\n---- {team.TeamName} Batting ----");
            int totalRuns = 0;
            int wickets = 0;
            Random rand = new Random();

            foreach (var player in team.Members)
            {
                if (wickets >= 2) break; 

                int runs = rand.Next(0, 101); 
                bool isOut = rand.Next(0, 2) == 1; 

                player.CurrentRuns += runs;
                player.AddRuns(runs);
                if (runs >= 100)
                    player.AddHundred();
                else if (runs >= 50)
                    player.AddFifty();

                totalRuns += runs;

                Console.WriteLine($"{player.Name} scored {runs} runs" + (isOut ? " and got out." : " and remained not out."));
                if (isOut) wickets++;
            }

            Console.WriteLine($"Total runs scored by {team.TeamName}: {totalRuns}");
            return totalRuns;
        }

    }
}
