// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal interface IBlobNotificationStrategy : ITaskSeriesCommand, IBlobWrittenWatcher
    {
        Task RegisterAsync(BlobServiceClient blobServiceClient, BlobContainerClient container, ITriggerExecutor<BlobTriggerExecutorContext> triggerExecutor,
            CancellationToken cancellationToken);
    }
}
