using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class EmailLowTemperature: ISendEmail
    {
        public bool SendEmail(string recepient)
        {
            Console.WriteLine("To: {0}\n", recepient);
            Console.WriteLine("Hi, the temperature is too low\n");

            return true;
        }
    }
}
