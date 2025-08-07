// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Hosting;

[assembly: WebJobsStartup(typeof(WebPubSubForSocketIOWebJobsStartup))]
namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal class WebPubSubForSocketIOWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddSocketIO();
        }
    }
}
