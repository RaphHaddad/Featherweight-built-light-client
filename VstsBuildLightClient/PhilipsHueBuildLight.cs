using System;
using System.Linq;
using Q42.HueApi;

namespace VstsBuildLightClient
{
    internal class PhilipsHueBuildLight : BuildLight
    {
        private readonly LocalHueClient _client;

        public PhilipsHueBuildLight()
        {
            var locator = new HttpBridgeLocator();
            var lightIp = locator.LocateBridgesAsync(new TimeSpan(0, 0, 5)).Result?.FirstOrDefault();
            if (lightIp == null)
            {
                throw new ArgumentException("Can't find Hue build light on network");
            }
            _client = new LocalHueClient(lightIp.IpAddress);
            _client.RegisterAsync("FeatherWeightBuildClient", AppConfiguration.DeviceSettings.Name).Wait();
        }
        internal override void ChangeColourToRed()
        {
            ChangeColour(0.6679, 0.3181);
        }

        internal override void ChangeColourToGreen()
        {
            ChangeColour(0.41, 0.51721);
        }

        internal override void ChangeColourToAmber()
        {
            ChangeColour(0.5425, 0.4196);
        }

        private void ChangeColour(double x, double y)
        {
            var command = new LightCommand().TurnOn().SetColor(x, y);
            _client.SendCommandAsync(command);
        }

        internal override void TurnOff()
        {
            var command = new LightCommand().TurnOff();
            _client.SendCommandAsync(command).Wait();
        }
    }
}
