// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.CoreWCF.Channels
{
    internal interface IQueueBase
    {
        public QueueClient queueClient { get; set; }

        public Task<Response> CreateIfNotExistsAsync(IDictionary<string, string> metadata = default, CancellationToken cancellationToken = default);

        public Task<Queues.Models.QueueMessage> ReceiveMessageAsync(TimeSpan? visibilityTimeout = default, CancellationToken cancellationToken = default);

        public Task<Response> DeleteMessageAsync(string messageId, string popReceipt, CancellationToken cancellationToken = default);
    }
}
