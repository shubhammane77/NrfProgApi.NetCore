using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NrfjprogAPI.NetCore
{
    public enum NrfjprogError
    {
        SUCCESS = 0,

        /* PC Issues */
        OUT_OF_MEMORY = -1,

        /* Wrong use of dll errors. */
        INVALID_OPERATION = -2,
        INVALID_PARAMETER = -3,
        INVALID_DEVICE_FOR_OPERATION = -4,
        WRONG_FAMILY_FOR_DEVICE = -5,
        UNKNOWN_DEVICE = -6,
        INVALID_SESSION = -7,

        /* Connection issues. */
        EMULATOR_NOT_CONNECTED = -10,
        CANNOT_CONNECT = -11,
        LOW_VOLTAGE = -12,
        NO_EMULATOR_CONNECTED = -13,

        /* Device issues. */
        NVMC_ERROR = -20,
        RECOVER_FAILED = -21,

        /* Operation not available. */
        NOT_AVAILABLE_BECAUSE_PROTECTION = -90,
        NOT_AVAILABLE_BECAUSE_MPU_CONFIG = -91,
        NOT_AVAILABLE_BECAUSE_COPROCESSOR_DISABLED = -92,
        NOT_AVAILABLE_BECAUSE_TRUST_ZONE = -93,
        NOT_AVAILABLE_BECAUSE_BPROT = -94,

        /* JlinkARM DLL errors. */
        JLINKARM_DLL_NOT_FOUND = -100,
        JLINKARM_DLL_COULD_NOT_BE_OPENED = -101,
        JLINKARM_DLL_ERROR = -102,
        JLINKARM_DLL_TOO_OLD = -103,
        JLINKARM_DLL_READ_ERROR = -104,
        JLINKARM_DLL_TIME_OUT_ERROR = -105,

        /* UART DFU errors */
        SERIAL_PORT_NOT_FOUND = -110,
        SERIAL_PORT_PERMISSION_ERROR = -111,
        SERIAL_PORT_WRITE_ERROR = -112,
        SERIAL_PORT_READ_ERROR = -113,
        SERIAL_PORT_RESOURCE_ERROR = -114,
        SERIAL_PORT_NOT_OPEN_ERROR = -115,

        /* nrfjprog sub DLL errors. */
        NRFJPROG_SUB_DLL_NOT_FOUND = -150,
        NRFJPROG_SUB_DLL_COULD_NOT_BE_OPENED = -151,
        NRFJPROG_SUB_DLL_COULD_NOT_LOAD_FUNCTIONS = -152,
        NRFJPROG_HOST_EXE_NOT_FOUND = -153,

        /* High Level DLL */
        VERIFY_ERROR = -160,
        RAM_IS_OFF_ERROR = -161,

        /* File errors */
        FILE_OPERATION_FAILED = -162,
        FILE_PARSING_ERROR = -170,
        FILE_UNKNOWN_FORMAT_ERROR = -171,
        FILE_INVALID_ERROR = -172,
        UNKNOWN_MEMORY_ERROR = -173,
        CONFIG_TYPE_ERROR = -174,
        CONFIG_SYNTAX_ERROR = -175,
        CONFIG_PROPERTY_MISSING_ERROR = -176,

        /* DFU errors */
        TIME_OUT = -220,
        DFU_ERROR = -221,

        /* Internal Error */
        INTERNAL_ERROR = -254,

        /* Not implemented. */
        NOT_IMPLEMENTED_ERROR = -255,
    }
}
