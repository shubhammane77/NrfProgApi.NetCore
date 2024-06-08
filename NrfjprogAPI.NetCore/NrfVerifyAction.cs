using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NrfjprogAPI.NetCore
{
    public enum NrfVerifyAction
    {
        VERIFY_NONE = 0, /* Do nothing. */
        VERIFY_READ = 1, /* Verify by reading back contents. */
        VERIFY_HASH = 2, /* Verify by hashing contents, faster than VERIFY_READ. */
    }
}
