// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.CoreWCF.Azure.StorageQueues
{
    internal interface IQueueBase
    {
        public QueueClient QueueClient { get; set; }

        public Task<Response> CreateIfNotExistsAsync(IDictionary<string, string> metadata = default, CancellationToken cancellationToken = default);

        public Task<QueueMessage> ReceiveMessageAsync(TimeSpan? visibilityTimeout = default, CancellationToken cancellationToken = default);

        public Task<Response> DeleteMessageAsync(string messageId, string popReceipt, CancellationToken cancellationToken = default);
    }
}
