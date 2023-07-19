// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(SignalRWebJobsStartup))]

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    public class SignalRWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddSignalR();
        }
    }
}