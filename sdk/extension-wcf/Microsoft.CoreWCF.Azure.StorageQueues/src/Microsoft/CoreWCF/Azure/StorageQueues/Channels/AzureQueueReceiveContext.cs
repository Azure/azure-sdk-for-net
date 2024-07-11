// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues.Models;
using CoreWCF.Channels;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Channels
{
    internal class AzureQueueReceiveContext : ReceiveContext
    {
        private readonly MessageQueue _queueClient;
        private readonly QueueMessage _queueMessage;
        private readonly TimeSpan _pollingInterval;
        private readonly ILogger<AzureQueueReceiveContext> _logger;

        public AzureQueueReceiveContext(
            MessageQueue queueClient,
            QueueMessage queueMessage,
            TimeSpan pollingInterval,
            ILogger<AzureQueueReceiveContext> _azureQueueReceiveContextLogger)
        {
            _queueClient = queueClient;
            _queueMessage = queueMessage;
            _pollingInterval = pollingInterval;
            _logger = _azureQueueReceiveContextLogger;
        }

        protected override async Task OnAbandonAsync(CancellationToken token)
        {
            bool deadLettered = false;
            do
            {
                try
                {
                    await _queueClient.SendToDeadLetterQueueAsync(_queueMessage.MessageId, _queueMessage.Body, token).ConfigureAwait(false);
                    _logger.LogDebug("OnAbandonAsync: Dead lettered message with id: " + _queueMessage.MessageId);
                    deadLettered = true;
                    break;
                }
                catch (Exception e)
                {
                    _logger.LogWarning("OnAbandonAsync: Exception: " + e.Message);
                    await Task.Delay(_pollingInterval).ConfigureAwait(false);
                }
            }
            while (token.CanBeCanceled && !token.IsCancellationRequested);
            if (deadLettered)
            {
                await DeleteMessage(token).ConfigureAwait(false);
            }
        }

        protected override Task OnCompleteAsync(CancellationToken token)
        {
            return DeleteMessage(token);
        }

        private async Task DeleteMessage(CancellationToken token)
        {
            do
            {
                try
                {
                    await _queueClient.DeleteMessageAsync(_queueMessage.MessageId, _queueMessage.PopReceipt, token).ConfigureAwait(false);
                    _logger.LogDebug("DeleteMessage: Deleted message with id: " + _queueMessage.MessageId);
                }
                catch (Exception e)
                {
                    _logger.LogWarning("DeleteMessage: Exception: " + e.Message);
                    await Task.Delay(_pollingInterval).ConfigureAwait(false);
                }
            }
            while (token.CanBeCanceled && !token.IsCancellationRequested);
        }
    }
}
