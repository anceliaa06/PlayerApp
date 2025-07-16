using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerApp
{
    public class Player
    {
        public int JerseyNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Fifties { get; set; }
        public int Hundreds { get; set; }
        public int CurrentRuns { get; set; }
        public int FinalRuns { get; set; }
        public int MatchCount { get; set; }
        public int Runs { get; set; } 

        

        public Player(int jerseyNumber, string name, int age, int currentRuns, int finalRuns, int fifties, int hundreds, int matchCount)
        {
            JerseyNumber = jerseyNumber;
            Name = name;
            Age = age;
            Fifties = fifties;
            Hundreds = hundreds;
            CurrentRuns = currentRuns;
            FinalRuns = finalRuns;
            MatchCount = matchCount;
        }

        public override string ToString()
        {
            return $"Jersey Number: {JerseyNumber}, Name: {Name}, Age: {Age}, Fifties: {Fifties}, Hundreds: {Hundreds}, Runs: {Runs}";
        }

        public void AddRuns(int value)
        {
            CurrentRuns += value;
            Runs += value;
        }

        public void AddFifty()
        {
            Fifties++;
            
        }

        public void AddHundred()
        {
            Hundreds++;
            
        }
    }
}
