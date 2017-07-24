using System;
using Busylight;

namespace VstsBuildLightClient
{
    internal class KuandoBuildLight : BuildLight
    {
        private readonly SDK _busylight;

        public KuandoBuildLight()
        {
            _busylight = new SDK();
            if (!_busylight.IsOmegaConnected)
            {
                throw new Exception("Omega light is not connected");
            }
        }
        internal override void ChangeColourToRed()
        {
            _busylight.Light(BusylightColor.Red);
        }

        internal override void ChangeColourToGreen()
        {
            _busylight.Light(BusylightColor.Green);
        }

        internal override void ChangeColourToAmber()
        {
            _busylight.Light(BusylightColor.Yellow);
        }

        internal override void TurnOff()
        {
            _busylight.Light(BusylightColor.Off);
        }
    }
}
