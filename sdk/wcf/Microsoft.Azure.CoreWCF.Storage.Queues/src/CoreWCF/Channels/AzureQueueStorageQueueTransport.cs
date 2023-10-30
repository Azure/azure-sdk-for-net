// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Queues;
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

        public AzureQueueStorageQueueTransport(
            IServiceDispatcher serviceDispatcher,
            IServiceProvider serviceProvider,
            AzureQueueStorageTransportBindingElement azureQueueStorageTransportBindingElement)
        {
            if (string.IsNullOrEmpty(azureQueueStorageTransportBindingElement.ConnectionString) &&
                    (serviceDispatcher.BaseAddress == null || string.IsNullOrEmpty(serviceDispatcher.BaseAddress.AbsoluteUri)))
            {
                throw new ArgumentException("Connection string and Uri Endpoint both cannot be empty.");
            }

            string extractedQueueName = AzureQueueStorageChannelHelpers.ExtractAndValidateQueueName(
                serviceDispatcher.BaseAddress,
                azureQueueStorageTransportBindingElement);

            QueueClientOptions queueClientOptions = new QueueClientOptions();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            if (httpClientFactory != null)
            {
                var httpClient = httpClientFactory.CreateClient(serviceDispatcher.Host.Description.ServiceType.FullName);
                HttpClientTransport httpClientTransport = new HttpClientTransport(httpClient);
                queueClientOptions.Transport = httpClientTransport;
            }

            if (!string.IsNullOrEmpty(azureQueueStorageTransportBindingElement.ConnectionString))
            {
                _queueClient = new MessageQueue(
                    azureQueueStorageTransportBindingElement.ConnectionString,
                    extractedQueueName,
                    queueClientOptions);

                _deadLetterQueueClient = new DeadLetterQueue(
                    azureQueueStorageTransportBindingElement.ConnectionString,
                    azureQueueStorageTransportBindingElement.DeadLetterQueueName);
            }
            else
            {
                _queueClient = new MessageQueue(serviceDispatcher.BaseAddress);
                _deadLetterQueueClient = new DeadLetterQueue(
                    AzureQueueStorageChannelHelpers.CreateEndpointUriForQueue(
                        serviceDispatcher.BaseAddress,
                        azureQueueStorageTransportBindingElement.DeadLetterQueueName));
            }

            _queueClient.CreateIfNotExistsAsync();
            _deadLetterQueueClient.CreateIfNotExistsAsync();
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

            var receiveContext = new AzureQueueReceiveContext(_queueClient, _deadLetterQueueClient, queueMessage);
            context.ReceiveContext = receiveContext;

            return context;
        }
    }
}
