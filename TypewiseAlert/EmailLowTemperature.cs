using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class EmailLowTemperature: ISendEmail
    {
        public void SendEmail(string recepient)
        {
            Console.WriteLine("To: {}\n", recepient);
            Console.WriteLine("Hi, the temperature is too low\n");
        }
    }
}
