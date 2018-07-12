using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class MarketingFirm
    {
        int numberOfSweepstakes;
        int contestantCount;
        ISweepstakesManager manager;
        public MarketingFirm(ISweepstakesManager manager)
        {
            this.manager = manager;
            CreateSweepstakes();
            PickWinners();
        }
        public void CreateSweepstakes()
        {
            numberOfSweepstakes = int.Parse(UI.GetUserInput("How Many Sweepstakes would you like to make: "));
            for(int i = 0; i < numberOfSweepstakes; i++)
            {
                Sweepstakes sweepstakes = new Sweepstakes(UI.GetUserInput("Enter the name of the sweepstakes: "));
                manager.InsertSweepstakes(sweepstakes);
                contestantCount = int.Parse(UI.GetUserInput($"How Many Contestants would you like to enter in the {sweepstakes.name}: "));
                for(int j = 0; j < contestantCount; j++)
                {
                    Contestant contestant = new Contestant();
                    sweepstakes.RegisterContestant(contestant);
                }
            }
        }
        public void PickWinners()
        {
            for(int i = 0; i < numberOfSweepstakes; i++)
            {
                Console.WriteLine(manager.GetSweepstakes().PickWinner());
                Console.ReadLine();
            }
            
        }
    }
}
