using System;
using System.Text;

namespace PlayerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Cricket App");
                Console.WriteLine("1. Add Team");
                Console.WriteLine("2. Display Teams");
                Console.WriteLine("3. Match Play");
                Console.WriteLine("4. Display Players");
                Console.WriteLine("5. Update Player Runs");
                Console.WriteLine("6. Show Max Run Player");
                Console.WriteLine("7. Calculate Average Runs");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TeamManager.AddTeam();
                        break;
                     case "2":
                        TeamManager.DisplayTeams();
                        break;
                    case "3":
                        TeamManager.UpdateTeamRunsMadeByPlayers();
                        break;
                    //var players = SerializeData.DeserializePlayers();
                    //foreach (var player in players)
                    //{
                    //    Console.WriteLine(player);
                    //}
                    //break;
                    case "4":
                        PlayerManager.DisplayPlayers();
                        break;
                    //case "4":
                    //    PlayerManager.UpdateFifties();
                    //    break;
                    //case "5":
                    //    PlayerManager.UpdateHundreds();
                    //    break;
                    case "5":
                        PlayerManager.UpdateRuns();
                        break;
                    case "6":
                        PlayerManager.ShowMaxRunPlayer();
                        break;
                    case "7":
                        PlayerManager.CalculateAverageRuns();
                        break;
                    case "8":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
