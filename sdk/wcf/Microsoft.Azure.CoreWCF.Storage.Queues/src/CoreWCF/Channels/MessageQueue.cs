// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.CoreWCF.Channels
{
    internal class MessageQueue : IQueueBase
    {
        private QueueClient _client;
        private TimeSpan _pollingInterval;
        private readonly ILogger<MessageQueue> _logger;
        public MessageQueue(
            string connectionString,
            string queueName,
            QueueClientOptions queueClientOptions,
            TimeSpan pollingInterval,
            ILogger<MessageQueue> logger)
        {
            _logger = logger;
            _logger.LogInformation(string.Format(CultureInfo.CurrentCulture,
                "MessageQueue constructor: QueueEndPoint: {0} QueueName: {1}",
                AzureQueueStorageChannelHelpers.GetEndpointStringFromConnectionString(connectionString), queueName));

            _pollingInterval = pollingInterval;
            _client = new QueueClient(connectionString, queueName, queueClientOptions);
        }

        public MessageQueue(
            Uri queueUri,
            QueueClientOptions queueClientOptions,
            TimeSpan pollingInterval,
            ILogger<MessageQueue> logger)
        {
            _logger = logger;
            _logger.LogInformation("MessageQueue constructor: QueueEndPoint: " + queueUri.AbsoluteUri);
            _pollingInterval = pollingInterval;
            _client = new QueueClient(queueUri, queueClientOptions);
        }

        public QueueClient QueueClient { get => _client; set => _client = value; }

        public Task<Response> DeleteMessageAsync(string messageId, string popReceipt, CancellationToken cancellationToken = default)
        {
            return _client.DeleteMessageAsync(messageId, popReceipt, cancellationToken);
        }

        public async Task<QueueMessage> ReceiveMessageAsync(TimeSpan? visibilityTimeout = null, CancellationToken cancellationToken = default)
        {
            QueueMessage message = null;
            try
            {
                message = await _client.ReceiveMessageAsync(visibilityTimeout, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.LogDebug(Task.CurrentId + "MessageQueue ReceiveMessageAsync: ReceiveMessageAsync failed with error message: " + e.Message);
            }
            if (message == null)
            {
                await Task.Delay(_pollingInterval).ConfigureAwait(false);
            }
            if (message == null)
            {
                _logger.LogInformation(Task.CurrentId + " MessageQueue ReceiveMessageAsync: Received null message");
            }
            else
            {
                _logger.LogInformation(Task.CurrentId + " MessageQueue ReceiveMessageAsync: Received message with id: " + message.MessageId);
            }
            return message;
        }

        public Task<Response> CreateIfNotExistsAsync(IDictionary<string, string> metadata = default, CancellationToken cancellationToken = default)
        {
            return _client.CreateIfNotExistsAsync(metadata, cancellationToken);
        }
    }
}
