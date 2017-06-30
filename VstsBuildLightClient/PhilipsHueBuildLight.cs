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
            var lightIp = locator.LocateBridgesAsync(new TimeSpan(0, 0, 5)).Result.First();
            _client = new LocalHueClient(lightIp.IpAddress);
            _client.RegisterAsync("FeatherWeightBuildClient", "get the device name from here").Wait();
        }
        internal override void ChangeColourToRed()
        {
            var command = new LightCommand().TurnOn().SetColor(0.6679, 0.3181);
            _client.SendCommandAsync(command);
        }

        internal override void ChangeColourToGreen()
        {
            var command = new LightCommand().TurnOn().SetColor(0.41, 0.51721);
            _client.SendCommandAsync(command);
        }

        internal override void ChangeColourToAmber()
        {
            var command = new LightCommand().TurnOn().SetColor(0.5425, 0.4196);
            _client.SendCommandAsync(command);
        }

        internal override void TurnOff()
        {
            var command = new LightCommand().TurnOff();
            _client.SendCommandAsync(command).Wait();
        }
    }
}
