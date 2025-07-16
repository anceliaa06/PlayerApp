using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerApp
{
    public class PlayerManager
    {
        public static List<Player> Players = SerializeData.DeserializePlayers();

        public static void AddPlayer()
        {
            Console.WriteLine("Enter Player's Jersey Number: ");
            int jerseyNumber = int.Parse(Console.ReadLine());
            
            if (Players.Any(p => p.JerseyNumber == jerseyNumber))
            {
                Console.WriteLine("A player with this jersey number already exists. Please use a unique jersey number.");
                return;
            }
            Console.WriteLine("Enter Player's Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Player's Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Player's Current Runs: ");
            int currentRuns = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number of matches played");
            int matchCount = Convert.ToInt32(Console.ReadLine());

            Player p = new Player(jerseyNumber, name, age, currentRuns, 0, 0, 0, matchCount);

            Players.Add(p);
            SerializeData.SerializePlayers(Players);
            Console.WriteLine("Player added successfully!");
        }

        public static void DisplayPlayers()
        {
            if (Players.Count == 0)
            {
                Console.WriteLine("No Players to display.");
                return;
            }

            Console.WriteLine("\nPlayers List:");
            foreach (var player in Players)
            {
                Console.WriteLine($"Jersey Number: {player.JerseyNumber}, Name: {player.Name}, Age: {player.Age}, Fifties: {player.Fifties}, Hundreds: {player.Hundreds}, Runs: {player.Runs}");
            }
        }

        public static void UpdateRuns()
        {
            Console.WriteLine("Enter Jersey Number: ");
            int jersey = int.Parse(Console.ReadLine());

            var player = Players.FirstOrDefault(p => p.JerseyNumber == jersey);
            if (player == null)
            {
                Console.WriteLine("Player not found.");
                return;
            }

            Random rand = new Random();
            int randomVal = rand.Next(1, 125);
            Console.WriteLine($"Number of runs taken by the player: {randomVal}");

            player.AddRuns(randomVal);

            if (randomVal >= 100)
            {
                player.AddHundred();
                Console.WriteLine($"{player.Name} hit a 100");
            }
            else if (randomVal >= 50)
            {
                player.AddFifty();
                Console.WriteLine($"{player.Name} hit 50");
            }
            else
            {
                Console.WriteLine($"{player.Name} hit {randomVal} runs.");
            }

            player.MatchCount++;

            Console.WriteLine($"\nUpdated runs for {player.Name}:");
            Console.WriteLine($"Total Runs: {player.Runs}, Fifties: {player.Fifties}, Hundreds: {player.Hundreds}");
            SerializeData.SerializePlayers(Players);
        }

        public static void ShowMaxRunPlayer()
        {
            var maxRunPlayer = Players.OrderByDescending(p => p.Runs).FirstOrDefault();
            if (maxRunPlayer != null)
            {
                Console.WriteLine($"Player with max runs: {maxRunPlayer.Name}, Runs: {maxRunPlayer.Runs}");
            }
            else
            {
                Console.WriteLine("No players found.");
            }
        }

        public static void CalculateAverageRuns()
        {
            if (Players.Count == 0)
            {
                Console.WriteLine("No players available to calculate average.");
                return;
            }

            double totalRuns = Players.Sum(p => p.Runs);
            int totalMatches = Players.Sum(p => p.MatchCount);

            if (totalMatches == 0)
            {
                Console.WriteLine("Match count is zero.");
                return;
            }

            double averageRunsPerMatch = totalRuns / totalMatches;
            Console.WriteLine($"Average Runs per Match: {averageRunsPerMatch}");
        }
    }
}
