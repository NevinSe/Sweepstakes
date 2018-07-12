using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Sweepstakes
    {
        public string name;
        private Random rng = new Random();
        private Dictionary<int, Contestant> sweepstakesDictionary;
        public Sweepstakes(string name)
        {
            this.name = name;
            sweepstakesDictionary = new Dictionary<int, Contestant>();
        }
        public void RegisterContestant(Contestant contestant)
        {
            sweepstakesDictionary.Add(sweepstakesDictionary.Count()+1, contestant);
            
        }
        public string PickWinner()
        {
            int winner = RandomNumber();
            System.Threading.Thread.Sleep(20);
            //UI.EmailWinner(sweepstakesDictionary[winner]);
            return $"The winner of the {this.name} is {sweepstakesDictionary[winner].firstName} {sweepstakesDictionary[winner].lastName}!";
        }
        public int RandomNumber()
        {
            int winningNumber = rng.Next(1, sweepstakesDictionary.Count());
            return winningNumber;
        }
        public void PrintContestantInfo(Contestant contestant)
        {
            Console.WriteLine($"This contestant's name is {contestant.firstName} {contestant.lastName}");
            Console.WriteLine($"This contestant's email is {contestant.eMail}");
            Console.WriteLine($"This contestant's registration number is {contestant.registrationNumber}");
        }
    }
}
