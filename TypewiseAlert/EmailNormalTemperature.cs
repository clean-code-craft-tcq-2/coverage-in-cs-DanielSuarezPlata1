using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class EmailNormalTemperature : ISendEmail
    {
        public bool SendEmail(string recepient)
        {
            Console.WriteLine("All ok :)");

            return true;
        }
    }
}
