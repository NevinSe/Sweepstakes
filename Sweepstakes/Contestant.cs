using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Contestant
    {
        public string firstName;
        public string lastName;
        public string eMail;
        public int registrationNumber;

        public Contestant()
        {
            this.firstName = UI.GetUserInput("Please enter your first name: ");
            this.lastName = UI.GetUserInput("Please enter your last name: ");
            this.eMail = UI.GetUserInput("Please enter your email: ");
        }
    }
}
