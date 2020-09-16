// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Azure.Storage.Blobs;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal interface IBlobNotificationStrategy : ITaskSeriesCommand, IBlobWrittenWatcher
    {
        Task RegisterAsync(BlobServiceClient blobServiceClient, BlobContainerClient container, ITriggerExecutor<BlobTriggerExecutorContext> triggerExecutor,
            CancellationToken cancellationToken);
    }
}
