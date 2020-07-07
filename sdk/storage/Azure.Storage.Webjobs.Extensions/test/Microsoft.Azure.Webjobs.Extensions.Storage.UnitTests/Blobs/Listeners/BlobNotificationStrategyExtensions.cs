// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.Storage.Blob;

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

        public static void Register(this IBlobListenerStrategy strategy, CloudBlobContainer container,
            ITriggerExecutor<BlobTriggerExecutorContext> triggerExecutor)
        {
            if (strategy == null)
            {
                throw new ArgumentNullException("strategy");
            }

            strategy.RegisterAsync(container, triggerExecutor, CancellationToken.None).GetAwaiter().GetResult();
        }

        public static void Start(this IBlobListenerStrategy strategy, CloudBlobContainer container,
            ITriggerExecutor<ICloudBlob> triggerExecutor)
        {
            if (strategy == null)
            {
                throw new ArgumentNullException("strategy");
            }

            strategy.Start();
        }
    }
}
