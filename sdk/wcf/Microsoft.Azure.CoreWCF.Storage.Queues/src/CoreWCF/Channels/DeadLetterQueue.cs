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
    internal class DeadLetterQueue : IQueueBase
    {
        private QueueClient _client;
        private readonly ILogger<DeadLetterQueue> _logger;

        public DeadLetterQueue(
            string connectionString,
            string queueName,
            QueueClientOptions queueClientOptions,
            ILogger<DeadLetterQueue> logger)
        {
            _logger = logger;
            _logger.LogInformation(string.Format(CultureInfo.CurrentCulture,
                "DeadLetterQueue constructor: QueueEndPoint: {0} QueueName: {1}",
                AzureQueueStorageChannelHelpers.GetEndpointStringFromConnectionString(connectionString), queueName));
            _client = new QueueClient(connectionString, queueName, queueClientOptions);
        }

        public DeadLetterQueue(
            Uri queueUri,
            QueueClientOptions queueClientOptions,
            ILogger<DeadLetterQueue> logger)
        {
            _logger = logger;
            _logger.LogInformation("DeadLetterQueue constructor: QueueEndPoint: " + queueUri.AbsoluteUri);
            _client = new QueueClient(queueUri, queueClientOptions);
        }

        public QueueClient QueueClient { get => _client; set => _client = value; }

        public Task<Response> DeleteMessageAsync(
            string messageId,
            string popReceipt,
            CancellationToken cancellationToken = default)
        {
            return _client.DeleteMessageAsync(messageId, popReceipt, cancellationToken);
        }

        public Task<QueueMessage> ReceiveMessageAsync(
            TimeSpan? visibilityTimeout = null,
            CancellationToken cancellationToken = default)
        {
            return Task.FromException<QueueMessage>(new NotImplementedException());
        }

        public async Task SendMessageAsync(
            BinaryData binaryData,
            CancellationToken token)
        {
            try
            {
                await _client.SendMessageAsync(binaryData, default, default, token).ConfigureAwait(false);
                _logger.LogInformation(Task.CurrentId + " DeadLetterQueue SendMessageAsync: Sent message with data: " + binaryData.ToString());
            }
            catch (Exception e)
            {
                _logger.LogDebug(Task.CurrentId + "DeadLetterQueue SendMessageAsync: SendMessageAsync failed with error message: " + e.Message);
                throw AzureQueueStorageChannelHelpers.ConvertTransferException(e);
            }
        }

        public Task<Response> CreateIfNotExistsAsync(
            IDictionary<string, string> metadata = default,
            CancellationToken cancellationToken = default)
        {
            return _client.CreateIfNotExistsAsync(metadata, cancellationToken);
        }
    }
}
