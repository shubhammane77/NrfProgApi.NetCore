namespace NrfjprogAPI.NetCore
{
    public enum NrfDeviceVersion
    {
        UNKNOWN = 0,

        /* nRF51 versions. */
        /* See http://infocenter.nordicsemi.com/topic/com.nordic.infocenter.nrf51/dita/nrf51/pdflinks/nrf51_comp_matrix.html
         */
        NRF51xxx_xxAA_REV1 = 1,
        NRF51xxx_xxAA_REV2 = 2,

        NRF51xxx_xxAA_REV3 = 3,
        NRF51xxx_xxAB_REV3 = 4,
        NRF51xxx_xxAC_REV3 = 5,

        NRF51802_xxAA_REV3 = 6,
        NRF51801_xxAB_REV3 = 17,

        /* nRF52805 versions. */
        NRF52805_xxAA_REV1 = 0x05280500,
        NRF52805_xxAA_REV2 = 0x05280501,
        NRF52805_xxAA_FUTURE = 0x052805FF,

        /* nRF52810 versions. */
        /* See
           http://infocenter.nordicsemi.com/topic/com.nordic.infocenter.nrf52/dita/nrf52/compatibility_matrix/nrf52810_comp_matrix.html
         */
        NRF52810_xxAA_REV1 = 13,
        NRF52810_xxAA_REV2 = 0x05281001,
        NRF52810_xxAA_REV3 = 0x05281002,
        NRF52810_xxAA_FUTURE = 14,

        /* nRF52811 versions. */
        NRF52811_xxAA_REV1 = 0x05281100,
        NRF52811_xxAA_REV2 = 0x05281101,
        NRF52811_xxAA_FUTURE = 0x052811FF,

        /* nRF52820 versions. */
        NRF52820_xxAA_ENGB = 0x05282003,
        NRF52820_xxAA_REV1 = 0x05282000,
        NRF52820_xxAA_REV2 = 0x05282001,
        NRF52820_xxAA_REV3 = 0x05282002,
        NRF52820_xxAA_FUTURE = 0x052820FF,

        /* nRF52832 versions. */
        /* See
           http://infocenter.nordicsemi.com/topic/com.nordic.infocenter.nrf52/dita/nrf52/compatibility_matrix/nrf52832_comp_matrix.html
         */
        NRF52832_xxAA_ENGA = 7,
        NRF52832_xxAA_ENGB = 8,
        NRF52832_xxAA_REV1 = 9,
        NRF52832_xxAA_REV2 = 19,
        NRF52832_xxAA_REV3 = 0x05283201,
        NRF52832_xxAA_FUTURE = 11,

        NRF52832_xxAB_REV1 = 15,
        NRF52832_xxAB_REV2 = 20,
        NRF52832_xxAB_REV3 = 0x05283211,
        NRF52832_xxAB_FUTURE = 16,

        /* nRF52833 versions. */
        NRF52833_xxAA_REV1 = 0x05283300,
        NRF52833_xxAA_REV2 = 0x05283301,
        NRF52833_xxAA_REV3 = 0x05283302,
        NRF52833_xxAA_FUTURE = 0x052833FF,


        /* nRF52840 versions. */
        /* See
           http://infocenter.nordicsemi.com/topic/com.nordic.infocenter.nrf52/dita/nrf52/compatibility_matrix/nrf52840_comp_matrix.html
         */
        NRF52840_xxAA_ENGA = 10,
        NRF52840_xxAA_ENGB = 21,
        NRF52840_xxAA_REV1 = 18,
        NRF52840_xxAA_REV2 = 0x05284003,
        NRF52840_xxAA_REV3 = 0x05284004,
        NRF52840_xxAA_FUTURE = 12,

        /* nRF53XXX versions */
        NRF5340_xxAA_ENGA = 0x05340000,
        NRF5340_xxAA_ENGB = 0x05340001,
        NRF5340_xxAA_ENGC = 0x05340002,
        NRF5340_xxAA_ENGD = 0x05340003,
        NRF5340_xxAA_REV1 = 0x05340003,
        NRF5340_xxAA_FUTURE = 0x053400FF,


        /* NRF9120 versions */
        NRF9120_xxAA_REV3 = 0x09120002,
        NRF9120_xxAA_FUTURE = 0x091200FF,

        /* NRF9160 versions. */
        NRF9160_xxAA_REV1 = 0x09160000,
        NRF9160_xxAA_REV2 = 0x09160001,
        NRF9160_xxAA_FUTURE = 0x091600FF,
    }
}
