using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace VstsBuildLightClient
{
    internal static class AppConfiguration
    {
        static AppConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();

            Url = config["vsts_url"];
            PersonalKey = config["vsts_ personal_key"];
            Project = config["vsts_project"];
            BuildDefinitions = config.GetSection("builds_definitions").GetChildren()
                                                                      .Select(x => int.Parse(x.Value));
            var buildLight = config["build_light"];

            if (buildLight.Equals("console", StringComparison.InvariantCultureIgnoreCase))
            {
                BuildLight = BuildLights.Console;
            }
            else if (buildLight.Equals("delcom", StringComparison.InvariantCultureIgnoreCase))
            {
                BuildLight = BuildLights.Delcom;
            }
            else if (buildLight.Equals("hue", StringComparison.InvariantCultureIgnoreCase))
            {
                BuildLight = BuildLights.PhilipsHue;
                DeviceSettings.Name = config["build_light_settings:device_name"];
            }
            else if (buildLight.Equals("kuando", StringComparison.InvariantCultureIgnoreCase))
            {
                BuildLight = BuildLights.Kuando;
            }
            else
            {
                throw new ArgumentException($"{buildLight} is not a valid Build Light value in settings");
            }
        }

        internal static string Url { get; } 
        internal static string PersonalKey { get; }
        internal static string Project { get; }
        internal static BuildLights BuildLight { get; }
        internal static IEnumerable<int> BuildDefinitions { get;  }

        internal enum BuildLights
        {
            Console,
            Delcom,
            Kuando,
            PhilipsHue
        }

        internal static class DeviceSettings
        {
            internal static string Name { get; set; }
        }
    }
}