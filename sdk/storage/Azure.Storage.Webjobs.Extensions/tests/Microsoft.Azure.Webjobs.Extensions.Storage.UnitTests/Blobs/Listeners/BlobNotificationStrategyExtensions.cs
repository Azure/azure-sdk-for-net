// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests.Blobs.Listeners
{
    internal static class BlobNotificationStrategyExtensions
    {
        public static TaskSeriesCommandResult Execute(this IBlobListenerStrategy strategy)
        {
            if (strategy == null)
            {
                throw new ArgumentNullException("strategy");
            }

            return strategy.ExecuteAsync(CancellationToken.None).GetAwaiter().GetResult();
        }

        public static void Register(this IBlobListenerStrategy strategy, BlobServiceClient blobServiceClient, BlobContainerClient container,
            ITriggerExecutor<BlobTriggerExecutorContext> triggerExecutor)
        {
            if (strategy == null)
            {
                throw new ArgumentNullException("strategy");
            }

            strategy.RegisterAsync(blobServiceClient, container, triggerExecutor, CancellationToken.None).GetAwaiter().GetResult();
        }

        public static void Start(this IBlobListenerStrategy strategy, BlobContainerClient container,
            ITriggerExecutor<BlobBaseClient> triggerExecutor)
        {
            if (strategy == null)
            {
                throw new ArgumentNullException("strategy");
            }

            strategy.Start();
        }
    }
}
