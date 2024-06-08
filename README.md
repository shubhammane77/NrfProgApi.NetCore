# NrfProgApi.NetCore
Basic library to program custom NRF boards using JLink of NRF9160 DK board

Use:
Can be added as part of Desktop application eg. WPF

Devices used:
1. NRF9160 DK board - For Jlink use to program Custom modem board.
2. Custom Modem Board - Connected to DK board via 'Debug Output'

Test:
Tested on NRF9160 Custom modem board using DK board. No confirmation for other boards.

Uses:
1. Add NrfjprogAPI.NetCore/NrfjprogAPI.NetCore.csproj reference to your project.
2. Refer ModemProgramming.cs file for programming.

Methods: 
ListConnectedDevices - List connected probes, returns addresses.
ProgramModem - Program Modem firmware zip and hex file
