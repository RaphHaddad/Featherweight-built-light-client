﻿using System;
using System.Linq;
using System.Threading;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;

namespace VstsBuildLightClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new VstsConfiguration();
            var uri = new Uri(config.Url);
            var client = new VssConnection(uri, new VssBasicCredential(string.Empty, config.PersonalKey));
            client.ConnectAsync().SyncResult();
            var buildClient = client.GetClient<BuildHttpClient>();
            var projectClient = client.GetClient<ProjectHttpClient>();
            var project = projectClient.GetProjects().Result
                                                     .Single(x => x.Name == config.Project);
            var buildLight = BuildLight.Initialise(config.BuildLight);

            while (true)
            {
                var lastBuildResult = buildClient.GetBuildsAsync(project.Id)
                                                 .Result
                                                 .OrderBy(x => x.FinishTime)
                                                 .Last()
                                                 .Result;


                switch (lastBuildResult)
                {
                    case BuildResult.Succeeded:
                        buildLight.ChangeColourToGreen();
                        break;
                    case BuildResult.PartiallySucceeded:
                        buildLight.ChangeColourToAmber();
                        break;
                    default:
                        buildLight.ChangeColourToRed();
                        break;
                }
                Thread.Sleep(2000);
            }
        }

    }

    internal abstract class BuildLight
    {
        internal virtual void ChangeColourToRed()
        {
            
        }

        internal virtual void ChangeColourToGreen()
        {

        }

        internal virtual void ChangeColourToAmber()
        {

        }

        internal static BuildLight Initialise(VstsConfiguration.BuildLights buildLight)
        {
            if (buildLight == VstsConfiguration.BuildLights.Console)
            {
                return new ConsoleBuildLight();
            }
            return null;
        }
    }

    internal class ConsoleBuildLight : BuildLight
    {
        internal override void ChangeColourToGreen()
        {
            Console.WriteLine("Build is good");
        }

        internal override void ChangeColourToAmber()
        {
            Console.WriteLine("Build is partially successful");
        }

        internal override void ChangeColourToRed()
        {
            Console.WriteLine("Build has failed");
        }
    }
}