// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(AuthEventWebJobsStartup))]
namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Entry point for our trigger and bindings.</summary>
    internal class AuthEventWebJobsStartup : IWebJobsStartup
    {
        /// <summary>Configures the specified builder.</summary>
        /// <param name="builder">The builder.</param>
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<AuthEventConfigProvider>();
        }
    }
}
