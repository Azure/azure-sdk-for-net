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
        private readonly DeadLetterQueue _deadLetterQueueSender;
        private readonly QueueMessage _queueMessage;

        public AzureQueueReceiveContext(QueueMessage queueMessage, DeadLetterQueue deadLetterQueueSender)
        {
            _deadLetterQueueSender = deadLetterQueueSender;
            _queueMessage = queueMessage;
        }

        protected override async Task OnAbandonAsync(CancellationToken token)
        {
            await _deadLetterQueueSender.SendMessageAsync(_queueMessage.Body, default).ConfigureAwait(false);
        }

        protected override Task OnCompleteAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
