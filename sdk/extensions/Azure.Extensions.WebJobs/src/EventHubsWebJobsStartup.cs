// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Hosting;

[assembly: WebJobsStartup(typeof(Azure.Extensions.WebJobs.EventHubsWebJobsStartup))]
namespace Azure.Extensions.WebJobs
{
    internal class EventHubsWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup2
    {
        public void Configure(IWebJobsBuilder builder)
        {
        }

        public void Configure(WebJobsBuilderContext context, IWebJobsBuilder builder)
        {
            builder.Services.AddAzureClients(builder => builder.SetConfigurationRoot(context.Configuration));
            builder.AddAzureClients();
        }
    }
}