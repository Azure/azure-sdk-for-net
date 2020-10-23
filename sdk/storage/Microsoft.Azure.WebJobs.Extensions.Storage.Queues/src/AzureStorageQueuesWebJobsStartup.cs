// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Hosting;

[assembly: WebJobsStartup(typeof(AzureStorageQueuesWebJobsStartup))]

namespace Microsoft.Azure.WebJobs.Extensions.Storage
{
    /// <inheritdoc cref="IWebJobsStartup"/>
    public class AzureStorageQueuesWebJobsStartup : IWebJobsStartup
    {
        /// <inheritdoc/>
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddAzureStorageQueues();
        }
    }
}
