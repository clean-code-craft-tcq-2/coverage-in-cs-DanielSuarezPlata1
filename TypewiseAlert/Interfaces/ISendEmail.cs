using System;
using System.Collections.Generic;
using System.Text;

namespace TypewiseAlert
{
    public interface ISendEmail
    {
        bool SendEmail(string recepient);
    }
}
