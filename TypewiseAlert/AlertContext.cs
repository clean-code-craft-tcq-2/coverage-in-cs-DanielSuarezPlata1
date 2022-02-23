using System;
using System.Collections.Generic;
using System.Text;
using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert
{
    public class AlertContext
    {
        public ISendAlert _alertTarget;

        public BreachType _breachType;

        public bool sent = false;

        public void SetTarget(ISendAlert target)
        {
            this._alertTarget = target;
        }

        public void SetBreachType(BreachType breachType)
        {
            this._breachType = breachType;
        }

        public void Send()
        {
            this.sent = this._alertTarget.Send(this._breachType);
        }
    }
}
