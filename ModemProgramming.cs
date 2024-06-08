using NrfjprogAPI.NetCore;
using System;
using static NrfjprogAPI.NetCore.NrfProgrammer;


namespace NrfProgApi
{
    public class ModemProgramming
    {

        private msg_callback logCallback;
        private static msg_callback progressCallback;


        public ModemProgramming()
        {


            nrfProgrammer = new NrfProgrammer();
            logCallback = (message) =>
          {

              Console.WriteLine(message);
          };

            progressCallback = (message) =>
           {

               ProgressObject jsonObject = JsonConvert.DeserializeObject<ProgressObject>(message);
               Console.WriteLine(jsonObject);
           };

        }

        public void Program()
        {
            var dllVersion = nrfProgrammer.ReadDllVersion();
            var connectedDevices = nrfProgrammer.ListConnectedDevices(logCallback);
            HardwareList = connectedDevices.Where(x => x != 0).Select(x => x.ToString()).ToList();
            var deviceId = uint.Parse(HardwareList[0]);
            var connectResult = nrfProgrammer.ProgramModem(deviceId,
                Path.Combine($"{FIRMWAREDOWNLOAD_PATH}\\{Firmware}\\mfw_nrf9160_1.3.5.zip"), // Path to modem firmware zip file from https://www.nordicsemi.com/Products/Development-hardware/nRF9160-DK/Download 
                Path.Combine($"{FIRMWAREDOWNLOAD_PATH}\\{Firmware}\\{Firmware}.hex"), // Path to your hex file
                progressCallback, logCallback);
            if (connectResult != "SUCCESS")
            {

                return;
            }

        }


    }



}
