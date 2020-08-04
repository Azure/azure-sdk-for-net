// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

[assembly: WebJobsStartup(typeof(Azure.Extensions.WebJobs.AzureClientsWebJobsStartup))]
namespace Azure.Extensions.WebJobs
{
    internal class AzureClientsWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddAzureClients(builder =>
                builder.SetConfigurationRoot(provider => provider.GetRequiredService<IConfiguration>()
                    .GetWebJobsRootConfiguration()
                    .GetSection("azure")));
            builder.AddAzureClients();
        }
     }
}
