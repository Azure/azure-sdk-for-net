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
    internal class DeadLetterQueue : IQueueBase
    {
        private QueueClient _client;

        public DeadLetterQueue(string connectionString, string queueName)
        {
            _client = new QueueClient(connectionString, queueName);
        }

        public DeadLetterQueue(Uri queueUri)
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

        public async Task SendMessageAsync(BinaryData binaryData, TimeSpan timeSpan)
        {
            CancellationTokenSource cts = new(timeSpan);

            try
            {
                await _client.SendMessageAsync(binaryData, default, default, cts.Token).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw AzureQueueStorageChannelHelpers.ConvertTransferException(e);
            }
            finally
            {
                cts.Dispose();
            }
        }

        public Task<Response> CreateIfNotExistsAsync(IDictionary<string, string> metadata = default, CancellationToken cancellationToken = default)
        {
            return _client.CreateIfNotExistsAsync(metadata, cancellationToken);
        }
    }
}
