using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class EmailLowTemperature: ISendEmail
    {
        public bool SendEmail(string recepient)
        {
            try
            {
                Console.WriteLine("To: {0}\n", recepient);
                Console.WriteLine("Hi, the temperature is too low\n");

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("The email cannot be sent: {0}", ex.Message);

                return false;
            }

            
        }
    }
}
