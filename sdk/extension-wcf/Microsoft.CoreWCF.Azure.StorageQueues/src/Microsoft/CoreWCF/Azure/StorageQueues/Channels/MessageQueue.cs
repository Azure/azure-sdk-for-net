// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Channels
{
    internal class MessageQueue
    {
        private QueueClient _client;
        private TimeSpan _pollingInterval;
        private string _deadLetterQueueName;
        private ILogger<DeadLetterQueue> _dlqLogger;
        private AzureQueueStorageQueueTransport _parent;
        private DeadLetterQueue _deadLetterQueue;
        private DeadLetterQueue _rawDeadLetterQueue;
        private readonly ILogger<MessageQueue> _logger;

        public MessageQueue(
            AzureQueueStorageQueueTransport azureQueueStorageQueueTransport,
            TimeSpan pollingInterval,
            ILogger<MessageQueue> logger,
            string deadLetterQueueName,
            ILogger<DeadLetterQueue> dlqLogger)
        {
            _logger = logger;
            _parent = azureQueueStorageQueueTransport;
            _pollingInterval = pollingInterval;
            _deadLetterQueueName = deadLetterQueueName;
            _dlqLogger = dlqLogger;
        }

        internal async Task InitAsync(CancellationToken cancellationToken)
        {
              if (_client is not null)
                return;

            var tokenContainer = await _parent.CreateAndOpenTokenProviderAsync(cancellationToken).ConfigureAwait(false);
            QueueClient queueClient = await _parent.GetQueueClientAsync(_parent.BaseAddress, tokenContainer, forceEncodingNone: false, cancellationToken).ConfigureAwait(false);
            Uri deadLetterQueueUri = CreateDeadLetterQueueUri(queueClient.Uri, _deadLetterQueueName);
            var deadLetterQueueClient = await _parent.GetDeadLetterQueueClientAsync(deadLetterQueueUri, tokenContainer, forceEncodingNone: false, cancellationToken).ConfigureAwait(false);
            bool createRawDlqClient = _parent.QueueMessageEncoding == QueueMessageEncoding.Base64;
            var rawDeadLetterQueueClient = createRawDlqClient ? await _parent.GetDeadLetterQueueClientAsync(deadLetterQueueUri, tokenContainer, forceEncodingNone: true, cancellationToken).ConfigureAwait(false)
                                                              : deadLetterQueueClient;
            if (_parent.QueueClientConfigureDelegate is not null)
            {
                var configuredQueueClient = _parent.QueueClientConfigureDelegate(queueClient);
                if (configuredQueueClient is not null)
                {
                    queueClient = configuredQueueClient;
                }

                configuredQueueClient = _parent.QueueClientConfigureDelegate(deadLetterQueueClient);
                if (configuredQueueClient is not null)
                {
                    deadLetterQueueClient = configuredQueueClient;
                }

                if (createRawDlqClient) // If we didn't create it, we're using the regular DLQ client and don't need to do this
                {
                    configuredQueueClient = _parent.QueueClientConfigureDelegate(rawDeadLetterQueueClient);
                    if (configuredQueueClient is not null)
                    {
                        rawDeadLetterQueueClient = configuredQueueClient;
                    }
                }
            }
            _client = queueClient;
            _deadLetterQueue = new DeadLetterQueue(deadLetterQueueClient, _dlqLogger);
            _rawDeadLetterQueue = createRawDlqClient ? new DeadLetterQueue(rawDeadLetterQueueClient, _dlqLogger) : _deadLetterQueue;
            await CreateIfNotExistsAsync(null, cancellationToken).ConfigureAwait(false);
            await _deadLetterQueue.CreateIfNotExistsAsync(null, cancellationToken ).ConfigureAwait(false);
        }

        private Uri CreateDeadLetterQueueUri(Uri baseAddress, string deadLetterQueueName)
        {
            var uriBuilder = new UriBuilder(baseAddress);
            var splitPath = uriBuilder.Path.Split(new[] { '/' }, StringSplitOptions.None);
            splitPath[splitPath.Length - 1] = deadLetterQueueName;
            uriBuilder.Path = string.Join("/", splitPath);
            return uriBuilder.Uri;
        }

        public QueueClient QueueClient { get => _client; set => _client = value; }

        public Task<Response> DeleteMessageAsync(string messageId, string popReceipt, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation(Task.CurrentId + " Deleting message with Id " + messageId + " from Queue");
            return _client.DeleteMessageAsync(messageId, popReceipt, cancellationToken);
        }

        public async Task<QueueMessage> ReceiveMessageAsync(TimeSpan? visibilityTimeout = null, CancellationToken cancellationToken = default)
        {
            Debug.Assert(_client is not null);
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

        internal Task SendToDeadLetterQueueAsync(string messageId, BinaryData body, CancellationToken token)
        {
            _dlqLogger.LogDebug(Task.CurrentId + " Sending message with Id " + messageId + " to DLQ");
            return _deadLetterQueue.SendMessageAsync(body, token);
        }

        // This variant always uses MessageEncoding.None. This is needed for when the encoding of the message doesn't
        // match how the CoreWCF endpoint has been configured and the message is sent to the MessageDecodingFailed
        // event handler. If the endpoint is configured to Base64 and an unencded message is received, using a QueueClient
        // configured for Base64 will cause the unencoded message to be encoded before placing in the queue. This can cause
        // 2 problems. First, it becomes unclear why the message was rejected (if using a custom binding with Base64 MessageEncoding
        // and TextMessageEncodingBindingElement). Second, Base64 encoding grows a message size by ~30% and then it might not
        // be possible to put it in the DLQ.
        internal Task SendRawToDeadLetterQueueAsync(string messageId, BinaryData body, CancellationToken token)
        {
            _dlqLogger.LogDebug(Task.CurrentId + " Sending raw message with Id " + messageId + " to DLQ");
            return _rawDeadLetterQueue.SendMessageAsync(body, token);
        }
    }
}
