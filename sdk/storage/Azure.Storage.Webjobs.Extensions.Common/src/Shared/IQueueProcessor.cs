// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Host.Executors;

namespace Microsoft.Azure.WebJobs.Host.Queues.Listeners
{
    internal interface IQueueProcessor
    {
        public event EventHandler<PoisonMessageEventArgs> MessageAddedToPoisonQueue;

        public QueuesOptions QueuesOptions { get; }

        public Task<bool> BeginProcessingMessageAsync(QueueMessage message, CancellationToken cancellationToken);

        public Task CompleteProcessingMessageAsync(QueueMessage message, FunctionResult result, CancellationToken cancellationToken);
    }
}
