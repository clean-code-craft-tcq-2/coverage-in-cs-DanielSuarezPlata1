using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class AlerterContext
    {
        public ISendEmail breachAlerter;

        public string recepient;

        public bool sent = false;

        public void SetBreachAlerter(ISendEmail breachAlerter)
        {
            this.breachAlerter = breachAlerter;
            
        }

        public void SetRecepient(string recepient)
        {
            this.recepient = recepient;
        }

        public void Execute()
        {
            this.sent = this.breachAlerter.SendEmail(recepient);
        }
    }
}
