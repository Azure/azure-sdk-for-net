// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests.Listeners
{
    public class TestBlobListenerStrategy : IBlobListenerStrategy
    {
        public BlobServiceClient TargetServiceClient;
        public BlobContainerClient ContainerClient;
        internal ITriggerExecutor<BlobTriggerExecutorContext> Executor;
        public void Cancel()
        {
        }

        public void Dispose()
        {
        }

        public void Start()
        {
        }

        Task<TaskSeriesCommandResult> ITaskSeriesCommand.ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new TaskSeriesCommandResult(Task.CompletedTask));
        }

        void IBlobWrittenWatcher.Notify(BlobWithContainer<BlobBaseClient> blobWritten)
        {
        }

        Task IBlobNotificationStrategy.RegisterAsync(
            BlobServiceClient blobServiceClient,
            BlobContainerClient container,
            ITriggerExecutor<BlobTriggerExecutorContext> triggerExecutor,
            CancellationToken cancellationToken)
        {
            TargetServiceClient = blobServiceClient;
            ContainerClient = container;
            Executor = triggerExecutor;
            return Task.CompletedTask;
        }
    }
}
