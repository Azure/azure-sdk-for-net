// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Queue.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.Storage.CoreWCF.Channels
{
    internal class AzureQueueStorageQueueTransport : IQueueTransport
    {
        private MessageQueue _queueClient;
        private DeadLetterQueue _deadLetterQueueClient;
        private ILogger<AzureQueueStorageQueueTransport> _logger;
        private Uri _baseAddress;
        private TimeSpan _receiveMessageVisibilityTimeout;

        public AzureQueueStorageQueueTransport(IServiceDispatcher serviceDispatcher, IServiceProvider serviceProvider, AzureQueueStorageTransportBindingElement azureQueueStorageTransportBindingElement)
        {
            _queueClient = serviceProvider.GetRequiredService<MessageQueue>();
            _deadLetterQueueClient = serviceProvider.GetRequiredService<DeadLetterQueue>();
            _logger = serviceProvider.GetRequiredService<ILogger<AzureQueueStorageQueueTransport>>();
            _baseAddress = serviceDispatcher.BaseAddress;
            _receiveMessageVisibilityTimeout = azureQueueStorageTransportBindingElement.MaxReceivedTimeout;
        }

        public int ConcurrencyLevel => 1;

        public async ValueTask<QueueMessageContext> ReceiveQueueMessageContextAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _logger.LogInformation("Receiving message from Azure queue storage");

            QueueMessage queueMessage = await _queueClient.ReceiveMessageAsync(_receiveMessageVisibilityTimeout, cancellationToken).ConfigureAwait(false);
            if (queueMessage == null)
            {
                return null;
            }
            _queueClient.DeleteMessage(queueMessage.MessageId, queueMessage.PopReceipt);
            var reader = PipeReader.Create(new ReadOnlySequence<byte>(queueMessage.Body.ToMemory()));
            return GetContext(reader, new EndpointAddress(_baseAddress), queueMessage);
        }

        private AzureQueueStorageMessageContext GetContext(PipeReader reader, EndpointAddress endpointAddress, QueueMessage queueMessage)
        {
            var context = new AzureQueueStorageMessageContext
            {
                QueueMessageReader = reader,
                LocalAddress = endpointAddress
            };

            var receiveContext = new AzureQueueReceiveContext(queueMessage, _deadLetterQueueClient);
            context.ReceiveContext = receiveContext;

            return context;
        }
    }
}
