using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class AlerterContext
    {
        public ISendEmail strategy;

        public string recepient;

        public void SetStrategy(ISendEmail sendEmail)
        {
            this.strategy = sendEmail;
            
        }

        public void SetRecepient(string recepient)
        {
            this.recepient = recepient;
        }

        public void Execute()
        {
            this.strategy.SendEmail(recepient);
        }
    }
}
