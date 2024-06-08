using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NrfjprogAPI.NetCore
{
    public enum NrfResetAction
    {
        RESET_NONE = 0,
        RESET_SYSTEM = 1,
        RESET_DEBUG = 2,
        RESET_PIN = 3,
        RESET_HARD = 4
    }
}
