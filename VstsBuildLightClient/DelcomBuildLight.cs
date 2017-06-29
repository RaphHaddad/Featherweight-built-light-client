using System.IO;
using System.Text;

namespace VstsBuildLightClient
{
    internal class DelcomBuildLight : BuildLight
    {
        private readonly uint _device;

        public DelcomBuildLight()
        {
            var deviceName = new StringBuilder(Delcom.MAXDEVICENAMELEN);
            var doesDeviceExist = Delcom.DelcomGetNthDevice(Delcom.USBDELVI, 0, deviceName);
            if (doesDeviceExist == 0)
            {
                throw new IOException("Device does not exist");
            }
            _device = Delcom.DelcomOpenDevice(deviceName, 0);
        }
        internal override void ChangeColourToRed()
        {
            Delcom.DelcomLEDControl(_device, Delcom.REDLED, Delcom.LEDON);
        }

        internal override void ChangeColourToGreen()
        {
            Delcom.DelcomLEDControl(_device, Delcom.GREENLED, Delcom.LEDON);
        }

        internal override void ChangeColourToAmber()
        {
            Delcom.DelcomLEDControl(_device, Delcom.YELLOWLED, Delcom.LEDON);
        }

        internal override void TurnOff()
        {
            Delcom.DelcomLEDControl(_device, Delcom.BLUELED, Delcom.LEDOFF);
        }
    }
}
