using System.Runtime.InteropServices;

namespace NrfjprogAPI.NetCore
{
    public partial class NrfProgrammer
    {
        public delegate void msg_callback([MarshalAs(UnmanagedType.LPStr)] string message);
        public static class NativeMethods
        {

            [DllImport(@"NrfjprogAPI/bin/highlevelnrfjprog.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "NRFJPROG_dll_version")]
            internal static extern NrfjprogError NRFJPROG_dll_version(out int major, out int minor, out int micro);

            [DllImport(@"NrfjprogAPI/bin/highlevelnrfjprog.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "NRFJPROG_program")]
            internal static extern NrfjprogError NRFJPROG_program(IntPtr probe, [MarshalAs(UnmanagedType.LPStr)] string path, NrfProgramOptions nrfProgramOptions);

            [DllImport(@"NrfjprogAPI/bin/highlevelnrfjprog.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "NRFJPROG_probe_init")]
            internal static extern NrfjprogError NRFJPROG_probe_init(out IntPtr probe, IntPtr progress, IntPtr log, uint serialNumber, [MarshalAs(UnmanagedType.LPStr)] string jlinkPath);

            [DllImport(@"NrfjprogAPI/bin/highlevelnrfjprog.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "NRFJPROG_probe_uninit")]
            internal static extern NrfjprogError NRFJPROG_probe_uninit(out IntPtr probe);

            [DllImport(@"NrfjprogAPI/bin/highlevelnrfjprog.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "NRFJPROG_get_connected_probes")]
            internal static extern NrfjprogError NRFJPROG_get_connected_probes(uint[] connectedDevices, uint available, ref uint total);

            [DllImport(@"NrfjprogAPI/bin/highlevelnrfjprog.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "NRFJPROG_find_jlink_path")]
            internal static extern NrfjprogError NRFJPROG_find_jlink_path([MarshalAs(UnmanagedType.LPStr)] string path, uint bytes, out uint copiedBytes);

            [DllImport(@"NrfjprogAPI/bin/highlevelnrfjprog.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "NRFJPROG_dll_open")]
            internal static extern NrfjprogError NRFJPROG_dll_open([MarshalAs(UnmanagedType.LPStr)] string jlinkPath, IntPtr log_callback);
            [DllImport(@"NrfjprogAPI/bin/highlevelnrfjprog.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "NRFJPROG_is_dll_open")]
            internal static extern NrfjprogError NRFJPROG_is_dll_open(ref bool isOpen);

            [DllImport(@"NrfjprogAPI/bin/highlevelnrfjprog.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "NRFJPROG_dll_close")]
            internal static extern NrfjprogError NRFJPROG_dll_close();
        }

        public string ReadDllVersion()
        {
            var major = 0;
            var minor = 0;
            var micro = 0;
            var response = NativeMethods.NRFJPROG_dll_version(out major, out minor, out micro);

            return $"{major}.{minor}.{micro}";
        }

        public uint[] ListConnectedDevices(msg_callback callbackFunction)
        {
            try
            {
                OpenDLL(callbackFunction);
                
                uint[] serialNumbers = new uint[10]; // Assuming maximum of 10 probes
                uint total = 0;
                var response = NativeMethods.NRFJPROG_get_connected_probes(serialNumbers, 10, ref total);
                if (response != NrfjprogError.SUCCESS)
                {
                    throw new Exception(response.ToString());
                }
                return serialNumbers;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                NativeMethods.NRFJPROG_dll_close();
            }
        }
        public bool OpenDLL(msg_callback logCallback)
        {
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate<msg_callback>(logCallback);
            var response = NativeMethods.NRFJPROG_dll_open(null, callbackPtr);
            if (response != NrfjprogError.SUCCESS)
            {
                throw new Exception(response.ToString());
            }
            var isOpen = false;
            response = NativeMethods.NRFJPROG_is_dll_open(ref isOpen);
            if (response != NrfjprogError.SUCCESS)
            {
                throw new Exception(response.ToString());
            }
            if (!isOpen)
            {
                throw new Exception("Internal Error..DLL not open.");
            }
            return true;
        }

           public bool ProgramDFU(msg_callback logCallback)
        {
            IntPtr callbackPtr = Marshal.GetFunctionPointerForDelegate<msg_callback>(logCallback);
            var response = NativeMethods.NRFJPROG_dll_open(null, callbackPtr);
            if (response != NrfjprogError.SUCCESS)
            {
                throw new Exception(response.ToString());
            }
            var isOpen = false;
            response = NativeMethods.NRFJPROG_is_dll_open(ref isOpen);
            if (response != NrfjprogError.SUCCESS)
            {
                throw new Exception(response.ToString());
            }
            if (!isOpen)
            {
                throw new Exception("Internal Error..DLL not open.");
            }
            return true;
        }


        public string ProgramModem(uint serialNumber, string dfuPath, string hexFilePath, msg_callback progressCallback, msg_callback logCallback)
        {
            try
            {

                OpenDLL(logCallback);
                IntPtr progCallbackPtr = Marshal.GetFunctionPointerForDelegate<msg_callback>(progressCallback);

                IntPtr logCallbackPtr = IntPtr.Zero;

                IntPtr probe = IntPtr.Zero;
                var result = NativeMethods.NRFJPROG_probe_init(out probe, progCallbackPtr, logCallbackPtr, serialNumber,@"JLink/JLink_x64.dll");
                if (result != NrfjprogError.SUCCESS)
                {
                    return result.ToString();
                }
                NrfProgramOptions nrfProgramOptions = new NrfProgramOptions();
                nrfProgramOptions.verify = NrfVerifyAction.VERIFY_READ;
                nrfProgramOptions.chip_erase_mode = NrfEraseAction.ERASE_ALL;
                nrfProgramOptions.qspi_erase_mode = NrfEraseAction.ERASE_NONE;
                nrfProgramOptions.reset = NrfResetAction.RESET_DEBUG;

                result = NativeMethods.NRFJPROG_program(probe, dfuPath, nrfProgramOptions);
                if (result != NrfjprogError.SUCCESS)
                {
                    throw new Exception($"Error while dfu programming.. {result.ToString()}");
                }

                result = NativeMethods.NRFJPROG_program(probe, hexFilePath, nrfProgramOptions);
                if (result != NrfjprogError.SUCCESS)
                {
                    throw new Exception($"Error while hex programming.. {result.ToString()}");
                }
                result = NativeMethods.NRFJPROG_probe_uninit(out probe);
                if (result != NrfjprogError.SUCCESS)
                {
                    throw new Exception($"Error while unint probe.. {result.ToString()}");
                }
                return result.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                NativeMethods.NRFJPROG_dll_close();
            }
        }
    }
    public class ProgressObject
    {
        public int AmountOfSteps { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Message { get; set; }
        public string Operation { get; set; }
        public int ProgressPercentage { get; set; }
        public int Step { get; set; }
    }
}
