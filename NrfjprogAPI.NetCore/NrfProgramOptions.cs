using System.Runtime.InteropServices;

namespace NrfjprogAPI.NetCore
{
    [StructLayout(LayoutKind.Sequential)]
    public class NrfProgramOptions
    {
        public NrfVerifyAction verify;         /* Select post-program Verify action. */
        public NrfEraseAction chip_erase_mode; /* Select pre-program erase mode for internal flash memories. */
        public NrfEraseAction qspi_erase_mode; /* Select pre-program erase mode for external QSPI memories. */
        public NrfResetAction reset;
    }
}
