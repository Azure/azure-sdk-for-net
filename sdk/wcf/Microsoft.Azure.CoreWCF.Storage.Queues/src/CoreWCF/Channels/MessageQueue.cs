// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.CoreWCF.Channels
{
    internal class MessageQueue : IQueueBase
    {
        private QueueClient _client;

        public MessageQueue(string connectionString, string queueName, QueueClientOptions queueClientOptions)
        {
            _client = new QueueClient(connectionString, queueName, queueClientOptions);
        }

        public MessageQueue(Uri queueUri)
        {
            _client = new QueueClient(queueUri);
        }

        public QueueClient queueClient { get => _client; set => _client = value; }

        public Task<Response> DeleteMessageAsync(string messageId, string popReceipt, CancellationToken cancellationToken = default)
        {
            return _client.DeleteMessageAsync(messageId, popReceipt, cancellationToken);
        }

        public Task<Response<QueueMessage>> ReceiveMessageAsync(TimeSpan? visibilityTimeout = null, CancellationToken cancellationToken = default)
        {
            return _client.ReceiveMessageAsync(visibilityTimeout, cancellationToken);
        }

        public Task<Response> CreateIfNotExistsAsync(IDictionary<string, string> metadata = default, CancellationToken cancellationToken = default)
        {
            return _client.CreateIfNotExistsAsync(metadata, cancellationToken);
        }
    }
}
