using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NrfjprogAPI.NetCore
{
    public enum NrfEraseAction
    {
        ERASE_NONE = 0, /* Do nothing. */
        ERASE_ALL = 1, /* Erase whole chip. */
        ERASE_PAGES = 2, /* Erase specified sectors, excluding UICR. */
        ERASE_PAGES_INCLUDING_UICR = 3, /* Erase specified sectors, with UICR support. */
        ERASE_UICR = 4, /* Erase UICR */
        ERASE_CTRL_AP = 5  /* Erase using ctrl-ap */
    }
}
