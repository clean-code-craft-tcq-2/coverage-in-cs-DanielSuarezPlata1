using System;
using System.Collections.Generic;
using System.Text;
using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert
{
    public class SendToController: ISendAlert
    {

        public bool Send(BreachType breachType)
        {
            try
            {
                const ushort header = 0xfeed;

                Console.WriteLine("{0} : {1}\n", header, breachType);

                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Cannot be sent to controller: {0}", ex.Message);

                return false;
            }
            
        }

    }
}
