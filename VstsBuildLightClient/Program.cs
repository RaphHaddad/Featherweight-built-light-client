using System;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.OAuth;
using Microsoft.VisualStudio.Services.WebApi;
using Microsoft.VisualStudio.Services;

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

            var lastBuildResult = buildClient.GetBuildsAsync(project.Id)
                                             .Result
                                             .OrderBy(x => x.FinishTime)
                                             .Last()
                                             .Result;


            Console.Read();
        }

    }
}