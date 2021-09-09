// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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