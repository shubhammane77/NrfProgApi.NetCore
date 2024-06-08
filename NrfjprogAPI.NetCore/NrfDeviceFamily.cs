using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NrfjprogAPI.NetCore
{
    public enum NrfDeviceFamily
    {
        NRF51_FAMILY = 0,
        NRF52_FAMILY = 1,
        NRF53_FAMILY = 53,
        NRF91_FAMILY = 91,
        UNKNOWN_FAMILY = 99,
        AUTO_FAMILY = 255
    }
}
