using System;
using System.Collections.Generic;
using System.Text;
using static TypewiseAlert.TypewiseAlert;

namespace TypewiseAlert
{
    public interface ISendAlert
    {
        bool Send(BreachType breachType);
    }
}
