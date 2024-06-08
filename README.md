# NrfProgApi.NetCore
Basic program to program custom NRF boards using NRF9160 DK board using JLink

Devices used:
1. NRF9160 DK board - For Jlink use to program Custom modem board.
2. Custom Modem Board - Connected to DK board via 'Debug Output'


Uses:
1. Add NrfjprogAPI.NetCore/NrfjprogAPI.NetCore.csproj reference to your project.
2. Refer ModemProgramming.cs file for programming.

Methods: 

ListConnectedDevices - List connected probes, returns addresses.
ProgramModem - Program Modem firmware zip and hex file