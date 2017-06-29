using System.IO;
using Microsoft.Extensions.Configuration;

namespace VstsBuildLightClient
{
    public class VstsConfiguration
    {
        public VstsConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();

            Url = config["vsts_url"];
            PersonalKey = config["vsts_ personal_key"];
            Project = config["vsts_project"];
        }

        public string Url { get; } 
        public string PersonalKey { get; }
        public string Project { get; }
    }
}