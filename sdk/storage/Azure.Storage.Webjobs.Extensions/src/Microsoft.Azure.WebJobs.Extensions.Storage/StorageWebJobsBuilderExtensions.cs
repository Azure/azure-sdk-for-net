// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Extensions.Hosting
{
    /// <summary>
    /// TODO.
    /// </summary>
    public static class StorageWebJobsBuilderExtensions
    {
        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configureQueues"></param>
        /// <param name="configureBlobs"></param>
        /// <returns></returns>
        public static IWebJobsBuilder AddAzureStorage(this IWebJobsBuilder builder, Action<QueuesOptions> configureQueues = null, Action<BlobsOptions> configureBlobs = null)
        {
            builder.AddAzureStorageQueues(configureQueues);
            builder.AddAzureStorageBlobs(configureBlobs);

            return builder;
        }
    }
}
