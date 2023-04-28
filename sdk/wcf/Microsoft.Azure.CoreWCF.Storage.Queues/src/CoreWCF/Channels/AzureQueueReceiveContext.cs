// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.CoreWCF.Channels;
using System;
using System.Threading.Tasks;
using System.Threading;
using Azure.Storage.Queues.Models;

namespace CoreWCF.Channels
{
    internal class AzureQueueReceiveContext : ReceiveContext
    {
        private readonly MessageQueue _queueClient;
        private readonly DeadLetterQueue _deadLetterQueueSender;
        private readonly QueueMessage _queueMessage;

        public AzureQueueReceiveContext(MessageQueue queueClient, DeadLetterQueue deadLetterQueueSender, QueueMessage queueMessage)
        {
            _queueClient = queueClient;
            _deadLetterQueueSender = deadLetterQueueSender;
            _queueMessage = queueMessage;
        }

        protected override async Task OnAbandonAsync(CancellationToken token)
        {
            await _deadLetterQueueSender.SendMessageAsync(_queueMessage.Body, default).ConfigureAwait(false);
        }

        protected override async Task OnCompleteAsync(CancellationToken token)
        {
            await _queueClient.DeleteMessageAsync(_queueMessage.MessageId, _queueMessage.PopReceipt).ConfigureAwait(false);
        }
    }
}
