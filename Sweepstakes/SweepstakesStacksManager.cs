using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class SweepstakesStacksManager : ISweepstakesManager
    {
        Stack<Sweepstakes> sweepstakesStack;
        public SweepstakesStacksManager()
        {
            sweepstakesStack = new Stack<Sweepstakes>();
        }
        public Sweepstakes GetSweepstakes()
        {
            return sweepstakesStack.Pop();
        }

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            sweepstakesStack.Push(sweepstakes);
        }
    }
}
