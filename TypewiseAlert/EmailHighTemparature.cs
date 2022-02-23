using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class EmailHighTemparature : ISendEmail
    {
        public void SendEmail(string recepient)
        {
            Console.WriteLine("To: {}\n", recepient);
            Console.WriteLine("Hi, the temperature is too high\n");

        }
    }
}
