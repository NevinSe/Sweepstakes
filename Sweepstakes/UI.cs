using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    static class UI
    {
        public static string GetUserInput(string message)
        {
            Console.Write($"{message}");
            try
            {
                return Console.ReadLine().Trim();
            }
            catch
            {
                Console.WriteLine("Not a valid input");
                GetUserInput(message);
                return "";
            }
           
        }
        public static ISweepstakesManager ManagementSelection()
        {
            string manageStlye = UI.GetUserInput("Please choose the type of Sweepstakes management you would like to use ('Stack' or 'Queue'): ");
            if (manageStlye == "Stack")
            {
                return new SweepstakesStacksManager();
            }
            else if (manageStlye == "Queue")
            {
                return new SweepstakesQueueManager();

            }
            else
            {
                Console.WriteLine("Invalid");
                ManagementSelection();
                return null;
            }
        }
        public static void EmailWinner(Contestant contestant)
        {
            MailAddress fromAddress = new MailAddress("nevin.seibel.test@gmail.com", "Nevin");
            MailAddress toAddress = new MailAddress(contestant.eMail, contestant.firstName);
            string myPassword = "donthackme1";
            string subject = "You Won";
            string body = "You Won $50 bajillion dollars";
            SmtpClient smtpServer = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, myPassword)
            };
            using (MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtpServer.Send(message);
            }
        }
    }
}
