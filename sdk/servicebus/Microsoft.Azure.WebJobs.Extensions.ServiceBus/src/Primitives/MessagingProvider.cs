// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using Azure.Core;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// This class provides factory methods for the creation of instances
    /// used for ServiceBus message processing.
    /// </summary>
    public class MessagingProvider
    {
        private readonly ServiceBusOptions _options;

        private readonly ConcurrentDictionary<string, ServiceBusSender> _messageSenderCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusReceiver> _messageReceiverCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusClient> _clientCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusProcessor> _processorCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusSessionProcessor> _sessionProcessorCache = new();

        protected MessagingProvider()
        {
        }

        public MessagingProvider(
            IOptions<ServiceBusOptions> options,
            AzureEventSourceLogForwarder forwarder)
        {
            forwarder.Start();
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public virtual ServiceBusClient CreateClient(string connectionString)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            return _clientCache.GetOrAdd(
                connectionString,
                (_) => new ServiceBusClient(connectionString, _options.ToClientOptions()));
        }

        public virtual ServiceBusClient CreateClient(string fullyQualifiedNamespace, TokenCredential credential)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNull(credential, nameof(credential));

            return _clientCache.GetOrAdd(
                fullyQualifiedNamespace,
                (_) => new ServiceBusClient(fullyQualifiedNamespace, credential, _options.ToClientOptions()));
        }

        public virtual MessageProcessor CreateMessageProcessor(ServiceBusClient client, string entityPath)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return new MessageProcessor(GetOrAddProcessor(client, entityPath), GetOrAddMessageReceiver(client, entityPath));
        }

        internal ServiceBusProcessor CreateProcessor(ServiceBusClient client, string entityPath)
        {
            return GetOrAddProcessor(client, entityPath);
        }

        public virtual ServiceBusSender CreateMessageSender(ServiceBusClient client, string entityPath)
        {
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return _messageSenderCache.GetOrAdd(entityPath, client.CreateSender(entityPath));
        }

        public virtual ServiceBusReceiver CreateBatchMessageReceiver(ServiceBusClient client, string entityPath)
        {
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return _messageReceiverCache.GetOrAdd(entityPath, (_) => client.CreateReceiver(
                entityPath,
                new ServiceBusReceiverOptions
                {
                    PrefetchCount = _options.PrefetchCount
                }));
        }

        public virtual SessionMessageProcessor CreateSessionMessageProcessor(ServiceBusClient client, string entityPath)
        {
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return new SessionMessageProcessor(client, GetOrAddSessionProcessor(client, entityPath));
        }

        public virtual ServiceBusSessionProcessor CreateSessionProcessor(ServiceBusClient client, string entityPath)
        {
            return GetOrAddSessionProcessor(client, entityPath);
        }

        private ServiceBusReceiver GetOrAddMessageReceiver(ServiceBusClient client, string entityPath)
        {
            return _messageReceiverCache.GetOrAdd(entityPath, (_) => client.CreateReceiver(
                entityPath,
                new ServiceBusReceiverOptions
                {
                    PrefetchCount = _options.PrefetchCount
                }));
        }

        private ServiceBusProcessor GetOrAddProcessor(ServiceBusClient client, string entityPath)
        {
            return _processorCache.GetOrAdd(entityPath, (_) =>
            {
                ServiceBusProcessor processor;
                if (ServiceBusEntityPathHelper.ParseEntityType(entityPath) == EntityType.Topic)
                {
                    // entityPath for a subscription is "{TopicName}/Subscriptions/{SubscriptionName}"
                    ServiceBusEntityPathHelper.ParseTopicAndSubscription(entityPath, out string topic, out string subscription);
                    processor = client.CreateProcessor(topic, subscription, _options.ToProcessorOptions());
                }
                else
                {
                    // entityPath for a queue is "{QueueName}"
                    processor = client.CreateProcessor(entityPath, _options.ToProcessorOptions());
                }
                processor.ProcessErrorAsync += _options.ExceptionReceivedHandler;
                return processor;
            });
        }

        private ServiceBusSessionProcessor GetOrAddSessionProcessor(ServiceBusClient client, string entityPath)
        {
            return _sessionProcessorCache.GetOrAdd(entityPath, (_) =>
            {
                ServiceBusSessionProcessor processor;
                if (ServiceBusEntityPathHelper.ParseEntityType(entityPath) == EntityType.Topic)
                {
                    // entityPath for a subscription is "{TopicName}/Subscriptions/{SubscriptionName}"
                    ServiceBusEntityPathHelper.ParseTopicAndSubscription(entityPath, out string topic, out string subscription);
                    processor = client.CreateSessionProcessor(topic, subscription, _options.ToSessionProcessorOptions());
                }
                else
                {
                    // entityPath for a queue is "{QueueName}"
                    processor = client.CreateSessionProcessor(entityPath, _options.ToSessionProcessorOptions());
                }
                processor.ProcessErrorAsync += _options.ExceptionReceivedHandler;
                return processor;
            });
        }
    }
}
