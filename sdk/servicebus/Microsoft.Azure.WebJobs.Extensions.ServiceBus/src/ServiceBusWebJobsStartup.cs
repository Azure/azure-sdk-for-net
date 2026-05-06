// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Hosting;

[assembly: WebJobsStartup(typeof(ServiceBusWebJobsStartup))]

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    internal class ServiceBusWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddServiceBus();
        }
    }
}
