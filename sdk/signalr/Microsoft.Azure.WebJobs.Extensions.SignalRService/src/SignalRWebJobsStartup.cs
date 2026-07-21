// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(SignalRWebJobsStartup))]

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Registers the SignalR Service extension with the WebJobs host at startup.
    /// </summary>
    public class SignalRWebJobsStartup : IWebJobsStartup
    {
        /// <summary>
        /// Configures the WebJobs host to use the SignalR Service extension.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> used to configure the host.</param>
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddSignalR();
        }
    }
}