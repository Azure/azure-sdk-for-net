// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Storage.Queues;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Channels
{
    internal class DeadLetterQueue
    {
        private QueueClient _client;
        private readonly ILogger<DeadLetterQueue> _logger;

        public DeadLetterQueue(
            QueueClient queueClient,
            ILogger<DeadLetterQueue> logger)
        {
            _logger = logger;
            _logger.LogInformation("DeadLetterQueue constructor: QueueEndPoint: " + queueClient.Uri);
            _client = queueClient;
        }

        public async Task SendMessageAsync(BinaryData binaryData, CancellationToken token)
        {
            try
            {
                await _client.SendMessageAsync(binaryData, default, default, token).ConfigureAwait(false);
                _logger.LogInformation(Task.CurrentId + " DeadLetterQueue SendMessageAsync: Sent message with data length: " + binaryData.ToMemory().Length);
            }
            catch (Exception e)
            {
                _logger.LogDebug(Task.CurrentId + "DeadLetterQueue SendMessageAsync: SendMessageAsync failed with error message: " + e.Message);
                throw AzureQueueStorageChannelHelpers.ConvertTransferException(e);
            }
        }

        public Task<Response> CreateIfNotExistsAsync(IDictionary<string, string> metadata = default, CancellationToken cancellationToken = default)
        {
            return _client.CreateIfNotExistsAsync(metadata, cancellationToken);
        }
    }
}
