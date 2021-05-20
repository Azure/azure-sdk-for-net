// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using Azure.Core;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// This class provides factory methods for the creation of instances
    /// used for ServiceBus message processing.
    /// </summary>
    public class MessagingProvider
    {
        internal ServiceBusOptions Options { get; }

        private readonly ConcurrentDictionary<string, ServiceBusSender> _messageSenderCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusReceiver> _messageReceiverCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusClient> _clientCache = new();

        protected MessagingProvider()
        {
        }

        public MessagingProvider(IOptions<ServiceBusOptions> options)
        {
            Options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public virtual ServiceBusClient CreateClient(string connectionString)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            return _clientCache.GetOrAdd(
                connectionString,
                (_) => new ServiceBusClient(connectionString, Options.ToClientOptions()));
        }

        public virtual ServiceBusClient CreateClient(string fullyQualifiedNamespace, TokenCredential credential)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNull(credential, nameof(credential));

            return _clientCache.GetOrAdd(
                fullyQualifiedNamespace,
                (_) => new ServiceBusClient(fullyQualifiedNamespace, credential, Options.ToClientOptions()));
        }

        public virtual MessageProcessor CreateMessageProcessor(ServiceBusClient client, string entityPath)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return new MessageProcessor(CreateProcessor(client, entityPath));
        }

        public virtual ServiceBusProcessor CreateProcessor(ServiceBusClient client, string entityPath)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            // processors cannot be shared across listeners since there is a limit of 1 event handler in the Service Bus SDK.

            ServiceBusProcessor processor;
            if (ServiceBusEntityPathHelper.ParseEntityType(entityPath) == ServiceBusEntityType.Topic)
            {
                // entityPath for a subscription is "{TopicName}/Subscriptions/{SubscriptionName}"
                ServiceBusEntityPathHelper.ParseTopicAndSubscription(entityPath, out string topic, out string subscription);
                processor = client.CreateProcessor(topic, subscription, Options.ToProcessorOptions());
            }
            else
            {
                // entityPath for a queue is "{QueueName}"
                processor = client.CreateProcessor(entityPath, Options.ToProcessorOptions());
            }
            processor.ProcessErrorAsync += Options.ExceptionReceivedHandler;
            return processor;
        }

        public virtual ServiceBusSender CreateMessageSender(ServiceBusClient client, string entityPath)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return _messageSenderCache.GetOrAdd(entityPath, client.CreateSender(entityPath));
        }

        public virtual ServiceBusReceiver CreateBatchMessageReceiver(ServiceBusClient client, string entityPath)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return _messageReceiverCache.GetOrAdd(entityPath, (_) => client.CreateReceiver(
                entityPath,
                new ServiceBusReceiverOptions
                {
                    PrefetchCount = Options.PrefetchCount
                }));
        }

        public virtual SessionMessageProcessor CreateSessionMessageProcessor(ServiceBusClient client, string entityPath)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return new SessionMessageProcessor(CreateSessionProcessor(client, entityPath));
        }

        public virtual ServiceBusSessionProcessor CreateSessionProcessor(ServiceBusClient client, string entityPath)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            ServiceBusSessionProcessor processor;
            if (ServiceBusEntityPathHelper.ParseEntityType(entityPath) == ServiceBusEntityType.Topic)
            {
                // entityPath for a subscription is "{TopicName}/Subscriptions/{SubscriptionName}"
                ServiceBusEntityPathHelper.ParseTopicAndSubscription(entityPath, out string topic, out string subscription);
                processor = client.CreateSessionProcessor(topic, subscription, Options.ToSessionProcessorOptions());
            }
            else
            {
                // entityPath for a queue is "{QueueName}"
                processor = client.CreateSessionProcessor(entityPath, Options.ToSessionProcessorOptions());
            }
            processor.ProcessErrorAsync += Options.ExceptionReceivedHandler;
            return processor;
        }
    }
}
