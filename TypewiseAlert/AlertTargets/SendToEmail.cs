using System;
using System.Collections.Generic;
using System.Text;
using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert.AlertTargets
{
    public class SendToEmail : ISendAlert
    {
        static Dictionary<BreachType, ISendEmail> breachAlerters = new Dictionary<BreachType, ISendEmail>{

            {BreachType.TOO_LOW, new EmailLowTemperature() },
            {BreachType.TOO_HIGH, new EmailHighTemparature() },
            {BreachType.NORMAL, new EmailLowTemperature() },

        };

        public bool Send(BreachType breachType)
        {
            string recepient = "a.b@c.com";

            EmailContext emailContext = new EmailContext();

            emailContext.SetBreachAlerter(breachAlerters[breachType]);

            emailContext.SetRecepient(recepient);

            emailContext.Send();

            return emailContext.sent;

        }
    }
}
