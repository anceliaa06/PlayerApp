using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlayerApp
{
    public static class SerializeData
    {
        private static readonly string playerPath = "player.json";
        private static readonly string teamPath = "team.json";

        public static void SerializePlayers(List<Player> players)
        {
            try
            {
                string json = JsonConvert.SerializeObject(players, Formatting.Indented);
                File.WriteAllText(playerPath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during player serialization: {ex.Message}");
            }
        }

        public static List<Player> DeserializePlayers()
        {
            try
            {
                if (!File.Exists(playerPath)) return new List<Player>();
                string json = File.ReadAllText(playerPath);
                return JsonConvert.DeserializeObject<List<Player>>(json) ?? new List<Player>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during player deserialization: {ex.Message}");
                return new List<Player>();
            }
        }

        public static void SerializeTeams(List<Team> teams)
        {
            try
            {
                string json = JsonConvert.SerializeObject(teams, Formatting.Indented);
                File.WriteAllText(teamPath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during team serialization: {ex.Message}");
            }
        }

        public static List<Team> DeserializeTeams()
        {
            try
            {
                if (!File.Exists(teamPath)) return new List<Team>();
                string json = File.ReadAllText(teamPath);
                return JsonConvert.DeserializeObject<List<Team>>(json) ?? new List<Team>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during team deserialization: {ex.Message}");
                return new List<Team>();
            }
        }
    }
}
