// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace Azure.Storage.CoreWCF.Channels
{
    internal class MessageQueue : IQueueBase
    {
        private QueueClient _client;

        public MessageQueue(string connectionString, string queueName)
        {
            _client = new QueueClient(connectionString, queueName);
        }

        public QueueClient queueClient { get => _client; set => _client = value; }

        public Response DeleteMessage(string messageId, string popReceipt, CancellationToken cancellationToken = default)
        {
            return _client.DeleteMessage(messageId, popReceipt, cancellationToken);
        }

        public Task<Response<QueueMessage>> ReceiveMessageAsync(TimeSpan? visibilityTimeout = null, CancellationToken cancellationToken = default)
        {
            return _client.ReceiveMessageAsync(visibilityTimeout, cancellationToken);
        }
    }
}
