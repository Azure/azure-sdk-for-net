// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;

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
    }
}
