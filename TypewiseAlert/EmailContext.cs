using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public class EmailContext
    {
        public ISendEmail _breachAlerter;

        public string _recepient;

        public bool sent = false;

        public void SetBreachAlerter(ISendEmail breachAlerter)
        {
            this._breachAlerter = breachAlerter;
            
        }

        public void SetRecepient(string recepient)
        {
            this._recepient = recepient;
        }

        public void Send()
        {
            this.sent = this._breachAlerter.SendEmail(this._recepient);
        }
    }
}
