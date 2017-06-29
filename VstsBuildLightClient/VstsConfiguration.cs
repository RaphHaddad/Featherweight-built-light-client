using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace VstsBuildLightClient
{
    internal class VstsConfiguration
    {
        internal VstsConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();

            Url = config["vsts_url"];
            PersonalKey = config["vsts_ personal_key"];
            Project = config["vsts_project"];
            var buildLight = config["build_light"];

            if (buildLight.Equals("console", StringComparison.InvariantCultureIgnoreCase))
            {
                BuildLight = BuildLights.Console;
            }
            else if (buildLight.Equals("delcom", StringComparison.InvariantCultureIgnoreCase))
            {
                BuildLight = BuildLights.Delcom;
            }
            else
            {
                throw new ArgumentException($"{buildLight} is not a valid Build Light value in settings");
            }
        }

        internal string Url { get; } 
        internal string PersonalKey { get; }
        internal string Project { get; }
        internal BuildLights BuildLight { get; }

        internal enum BuildLights
        {
            Console,
            Delcom,
            Kuanda
        }
    }
}