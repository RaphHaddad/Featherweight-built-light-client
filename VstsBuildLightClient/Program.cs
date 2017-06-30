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
            var buildLight = BuildLight.Initialise();

            buildLight.TurnOff();

            var uri = new Uri(AppConfiguration.Url);
            var client = new VssConnection(uri, new VssBasicCredential(string.Empty, AppConfiguration.PersonalKey));


            client.ConnectAsync()
                  .SyncResult();
            var buildClient = client.GetClient<BuildHttpClient>();
            var projectClient = client.GetClient<ProjectHttpClient>();
            var project = projectClient.GetProjects().Result
                                                     .Single(x => x.Name == AppConfiguration.Project);

            try
            {
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
            catch (Exception)
            {
                buildLight.TurnOff();
            }
        }

    }
}