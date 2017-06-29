using System;
using System.Text;
using System.Runtime.InteropServices;

/// <summary>
/// taken from delcom website
/// </summary>
public class Delcom
{
    // Delcom USB Devices
    public const uint USBIODS = 1;
    public const uint USBDELVI = 2;
    public const uint USBNDSPY = 3;

    // USBDELVI LED MODES
    public const byte LEDOFF = 0;
    public const byte LEDON = 1;
    public const byte LEDFLASH = 2;

    // USBDELVI LED COlORS
    public const byte GREENLED = 0;
    public const byte REDLED = 1;
    public const byte BLUELED = 2;
    public const byte YELLOWLED = 4;

    // Device Name Maximum Length
    public const int MAXDEVICENAMELEN = 512;

    // USB Packet Structures

    // USB Data IO Packact
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketStructure
    {
        public byte Recipient;
        public byte DeviceModel;
        public byte MajorCmd;
        public byte MinorCmd;
        public byte DataLSB;
        public byte DataMSB;
        public byte Length;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] DATA;      //Data 1 .. 8
    }



    // Return data struture
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DataExtStructure
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] DATA;      //Data 1 .. 8
    }



    // Delcom DLL Fucnctions - See the DelcomDLL.pdf for documentation
    // http://www.delcom-eng.com/productdetails.asp?PartNumber=890510

    // Gets the DelcomDLL verison


    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomGetDLLVersion")]
    public static extern float DelcomGetDLLVersion();


    // Sets the verbose controll - used for debugging
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomVerboseControl")]
    public static extern int DelcomVerboseControl(uint Mode, StringBuilder caption);


    // Gets the DLL date
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomGetDLLDate")]
    public static extern int DelcomGetDLLDate(StringBuilder DateString);


    // Generic Functions

    //Gets DeviceCount
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomGetDeviceCount")]
    public static extern int DelcomGetDeviceCount(uint ProductType);

    // Gets Nth Device
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomGetNthDevice")]
    public static extern int DelcomGetNthDevice(uint ProductType, uint NthDevice, StringBuilder DeviceName);

    // Open Device
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomOpenDevice")]
    public static extern uint DelcomOpenDevice(StringBuilder DeviceName, int Mode);

    // Close Device
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomCloseDevice")]
    public static extern int DelcomCloseDevice(uint DeviceHandle);



    // Read USB Device Version
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomReadDeviceVersion")]
    public static extern int DelcomReadDeviceVersion(uint DeviceHandle);


    // Read USB Device SerialNumber
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomReadDeviceSerialNum")]
    public static extern int DelcomReadDeviceSerialNum(StringBuilder DeviceName, uint DeviceHandle);


    // Send USB Packet
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomSendPacket")]
    public static extern int DelcomSendPacket(uint DeviceHandle, ref PacketStructure PacketOut, out PacketStructure PacketIn);


    // USBDELVI - Visual Indicator Functions

    // Set LED Functions
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomLEDControl")]
    public static extern int DelcomLEDControl(uint DeviceHandle, int Color, int Mode);


    // Set LED Freq/Duty functions
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomLoadLedFreqDuty")]
    public static extern int DelcomLoadLedFreqDuty(uint DeviceHandle, byte Color, byte Low, byte High);


    // Set Auto Confirm Mode
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomEnableAutoConfirm")]
    public static extern int DelcomEnableAutoConfirm(uint DeviceHandle, int Mode);


    // Set Auto Clear Mode
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomEnableAutoClear(")]
    public static extern int DelcomEnableAutoClear(uint DeviceHandle, int Mode);



    // Set Buzzer Function
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomBuzzer")]
    public static extern int DelcomBuzzer(uint DeviceHandle, byte Mode, byte Freq, byte Repeat, byte OnTime, byte OffTime);


    // Set LED Phase Delay
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomLoadInitialPhaseDelay")]
    public static extern int DelcomLoadInitialPhaseDelay(uint DeviceHandle, byte Color, byte Delay);


    // Set Led Sync Functions
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomSyncLeds")]
    public static extern int DelcomSyncLeds(uint DeviceHandle);



    // Set LED PreScalar Functions
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomLoadPreScalar")]
    public static extern int DelcomLoadPreScalar(uint DeviceHandle, byte PreScalar);



    // Get Button Status
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomGetButtonStatus")]
    public static extern int DelcomGetButtonStatus(uint DeviceHandle);


    // Set LED Power
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomLEDPower")]
    public static extern int DelcomLEDPower(uint DeviceHandle, int Color, int Power);



    // USBIODS - USB IO Functions

    // Set Ports
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomWritePin")]
    public static extern int DelcomWritePin(uint DeviceHandle, byte Port, byte Pin, byte Value);


    // Set Ports
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomWritePorts")]
    public static extern int DelcomWritePorts(uint DeviceHandle, byte Port0, byte Port1);



    // Get Ports 
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomReadPorts")]
    public static extern int DelcomReadPorts(uint DeviceHandle, out byte Port0, out byte Port1);



    // Set 64Bit Value
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomWrite64Bit")]
    public static extern int DelcomWrite64Bit(uint DeviceHandle, ref DataExtStructure DataExt);


    // Get 64Bit Value
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomRead64Bit")]
    public static extern int DelcomRead64Bit(uint DeviceHandle, out DataExtStructure DataExt);


    // Write I2C Functions 
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomWriteI2C")]
    public static extern int DelcomWriteI2C(uint DeviceHandle, byte CmdAdd, byte Length, DataExtStructure DataExt);


    // Read I2C Functions
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomReadI2C")]
    public static extern int DelcomReadI2C(uint DeviceHandle, byte CmdAdd, byte Length, out DataExtStructure DataExt);


    // Get I2C Slect Read 
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomSelReadI2C")]
    public static extern int DelcomSelReadI2C(uint DeviceHandle, byte SetAddCmd, byte Address, byte ReadCmd, byte Length, out DataExtStructure DataExt);

    // Read I2C EEPROM Functions
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomReadI2CEEPROM")]
    public static extern int DelcomReadI2CEEPROM(uint DeviceHandle, uint Address, uint size, byte Ctrlcode, out StringBuilder Data);

    // Write I2C EEPROM Functions
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomwriteI2CEEPROM")]
    public static extern int DelcomWriteI2CEEPROM(uint DeviceHandle, uint Address, uint size, byte Ctrlcode, byte WriteDelay, out StringBuilder Data);


    // Setup RS232 Mode
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomRS232Ctrl")]
    public static extern int DelcomRS232Ctrl(uint DeviceHandle, int Mode, int Value);



    // Write RS232 Function
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomWriteRS232")]
    public static extern int DelcomWriteRS232(uint DeviceHandle, int Length, ref DataExtStructure DataExt);


    // Read RS232 Function
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomReadRS232")]
    public static extern int DelcomReadRS232(uint DeviceHandle, out DataExtStructure DataExt);

    // SPI Write Function
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomSPIWrite")]
    public static extern int DelcomSPIWrite(uint DeviceHandle, uint ClockCount, out DataExtStructure DataExt);
    // SPI SetClock Function
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomSPISetClock")]
    public static extern int DelcomSPISetClock(uint DeviceHandle, uint ClockPeriod);
    // SPI Read Function
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomSPIRead")]
    public static extern int DelcomSPIRead(uint DeviceHandle, out DataExtStructure DataExt);
    // SPI Write8Read64 Function
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomSPIWr8Read64")]
    public static extern int DelcomSPIWr8Read64(uint DeviceHandle, uint WeData, uint ClockCount, out DataExtStructure DataExt);






    // USBNDSPY Functions

    // Set Numeric Mode
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomNumericMode")]
    public static extern int DelcomNumericMode(uint DeviceHandle, byte Mode, byte Rate);


    // Set Numeric Scan Rate
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomNumericScanRate")]
    public static extern int DelcomNumericScanRate(uint DeviceHandle, byte ScanRate);


    // Setup Numeric Digits
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomNumericSetup")]
    public static extern int DelcomNumericSetup(uint DeviceHandle, byte Digits);


    // Set Numeric Raw Mode
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomNumericRaw")]
    public static extern int DelcomNumericRaw(uint DeviceHandle, StringBuilder Str);


    // Set Numeric Integer Mode
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomNumericInteger")]
    public static extern int DelcomNumericInteger(uint DeviceHandle, int Number, int Base);



    // Set Numeric Hexdecimal Mode
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomNumericHexaDecimal")]
    public static extern int DelcomNumericHexaDecimal(uint DeviceHandle, int Number, int Base);


    // Set Numeric Double Mode
    [DllImport("DelcomDrivers\\delcomdll.dll", EntryPoint = "DelcomNumericDouble(")]
    public static extern int DelcomNumericDouble(uint DeviceHandle, double Number, int Base);


}       // end of class

