﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using Azure.Core;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// This class provides factory methods for the creation of instances
    /// used for Service Bus message processing. It can be overriden to customize
    /// any of the client creation methods.
    /// </summary>
    public class MessagingProvider
    {
        internal ServiceBusOptions Options { get; }

        private readonly ConcurrentDictionary<string, ServiceBusSender> _messageSenderCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusReceiver> _messageReceiverCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusClient> _clientCache = new();

        /// <summary>
        /// Initializes a new instance of <see cref="MessagingProvider"/>.
        /// This is called by the Functions runtime as part of start up.
        /// </summary>
        /// <param name="options">The options that are used to configure the client instances.</param>
        /// <exception cref="ArgumentNullException">The options instance is null.</exception>
        public MessagingProvider(IOptions<ServiceBusOptions> options)
        {
            Options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusClient"/> to use for communicating with the service.
        /// </summary>
        /// <param name="connectionString">The connection string to use for connecting to the
        /// Service Bus namespace.</param>
        /// <param name="options">The set of options to use for configuring the client. These options are
        /// computed from the <see cref="ServiceBusOptions"/> passed to the <see cref="MessagingProvider"/>
        /// constructor.</param>
        /// <returns>The client that will be used by the extension for communicating with the service.</returns>
        protected internal virtual ServiceBusClient CreateClient(string connectionString, ServiceBusClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            Argument.AssertNotNull(options, nameof(options));

            return _clientCache.GetOrAdd(
                connectionString,
                (_) => new ServiceBusClient(connectionString, options));
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusClient"/> to use for communicating with the service.
        /// </summary>
        /// <param name="fullyQualifiedNamespace">The connection string to use for connecting to the
        /// Service Bus namespace.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.
        /// Access controls may be specified by the Service Bus namespace.</param>
        /// <param name="options">The set of options to use for configuring the client. These options are
        /// computed from the <see cref="ServiceBusOptions"/> passed to the <see cref="MessagingProvider"/>
        /// constructor.</param>
        /// <returns>The client that will be used by the extension for communicating with the service.</returns>
        protected internal virtual ServiceBusClient CreateClient(string fullyQualifiedNamespace, TokenCredential credential, ServiceBusClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            return _clientCache.GetOrAdd(
                fullyQualifiedNamespace,
                (_) => new ServiceBusClient(fullyQualifiedNamespace, credential, options));
        }

        /// <summary>
        /// Creates a <see cref="MessageProcessor"/> instance that will be used to process messages.
        /// </summary>
        /// <param name="client">The client that is being used to communicate with the service.</param>
        /// <param name="entityPath">The path to the Service Bus entity that is being received from.</param>
        /// <param name="options">The set of options to use for configuring the processor. These options are
        /// computed from the <see cref="ServiceBusOptions"/> passed to the <see cref="MessagingProvider"/>
        /// constructor.</param>
        /// <returns>A message processor that will be used by the extension.</returns>
        protected internal virtual MessageProcessor CreateMessageProcessor(ServiceBusClient client, string entityPath, ServiceBusProcessorOptions options)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));
            Argument.AssertNotNull(options, nameof(options));

            return new MessageProcessor(CreateProcessor(client, entityPath, options));
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusProcessor"/> instance that will be used to receive messages from the entity.
        /// </summary>
        /// <param name="client">The client that is being used to communicate with the service.</param>
        /// <param name="entityPath">The path to the Service Bus entity that is being received from.</param>
        /// <param name="options">The set of options to use for configuring the processor. These options are
        /// computed from the <see cref="ServiceBusOptions"/> passed to the <see cref="MessagingProvider"/>
        /// constructor.</param>
        /// <remarks>This method is called for functions that bind to a single message.</remarks>
        /// <returns>A <see cref="ServiceBusProcessor"/> that will be used by the extension.</returns>
        protected internal virtual ServiceBusProcessor CreateProcessor(ServiceBusClient client, string entityPath, ServiceBusProcessorOptions options)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));
            Argument.AssertNotNull(options, nameof(options));

            // processors cannot be shared across listeners since there is a limit of 1 event handler in the Service Bus SDK.

            ServiceBusProcessor processor;
            if (ServiceBusEntityPathHelper.ParseEntityType(entityPath) == ServiceBusEntityType.Topic)
            {
                // entityPath for a subscription is "{TopicName}/Subscriptions/{SubscriptionName}"
                ServiceBusEntityPathHelper.ParseTopicAndSubscription(entityPath, out string topic, out string subscription);
                processor = client.CreateProcessor(topic, subscription, options);
            }
            else
            {
                // entityPath for a queue is "{QueueName}"
                processor = client.CreateProcessor(entityPath, options);
            }
            processor.ProcessErrorAsync += Options.ExceptionReceivedHandler;
            return processor;
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSender"/> that will be used to send messages to the queue
        /// or topic.
        /// </summary>
        /// <param name="client">The client that is being used to communicate with the service.</param>
        /// <param name="entityPath">The path to the Service Bus entity that is being received from.</param>
        /// <returns>A sender that the extension will use to send messages.</returns>
        protected internal virtual ServiceBusSender CreateMessageSender(ServiceBusClient client, string entityPath)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return _messageSenderCache.GetOrAdd(entityPath, client.CreateSender(entityPath));
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusReceiver"/> that will be used to receive a batch of messages.
        /// </summary>
        /// <param name="client">The client that is being used to communicate with the service.</param>
        /// <param name="entityPath">The path to the Service Bus entity that is being received from.</param>
        /// <param name="options">The set of options to use for configuring the receiver. These options are
        /// computed from the <see cref="ServiceBusOptions"/> passed to the <see cref="MessagingProvider"/>
        /// constructor.</param>
        /// <remarks>This method is called for functions that bind to multiple messages.</remarks>
        /// <returns>A receiver that will be used by the extension to receive a batch of messages.</returns>
        protected internal virtual ServiceBusReceiver CreateBatchMessageReceiver(ServiceBusClient client, string entityPath, ServiceBusReceiverOptions options)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));
            Argument.AssertNotNull(options, nameof(options));

            return _messageReceiverCache.GetOrAdd(entityPath, (_) => client.CreateReceiver(entityPath, options));
        }

        /// <summary>
        /// Creates a <see cref="SessionMessageProcessor"/> instance that will be used to process messages.
        /// </summary>
        /// <param name="client">The client that is being used to communicate with the service.</param>
        /// <param name="entityPath">The path to the Service Bus entity that is being received from.</param>
        /// <param name="options">The set of options to use for configuring the processor. These options are
        /// computed from the <see cref="ServiceBusOptions"/> passed to the <see cref="MessagingProvider"/>
        /// constructor.</param>
        /// <returns>A message processor that will be used by the extension.</returns>
        protected internal virtual SessionMessageProcessor CreateSessionMessageProcessor(ServiceBusClient client, string entityPath, ServiceBusSessionProcessorOptions options)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));
            Argument.AssertNotNull(options, nameof(options));

            return new SessionMessageProcessor(CreateSessionProcessor(client, entityPath, options));
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusProcessor"/> instance that will be used to receive messages from the entity.
        /// </summary>
        /// <param name="client">The client that is being used to communicate with the service.</param>
        /// <param name="entityPath">The path to the Service Bus entity that is being received from.</param>
        /// <param name="options">The set of options to use for configuring the processor. These options are
        /// computed from the <see cref="ServiceBusOptions"/> passed to the <see cref="MessagingProvider"/>
        /// constructor.</param>
        /// <remarks>This method is called for functions that bind to a single message.</remarks>
        /// <returns>A <see cref="ServiceBusProcessor"/> that will be used by the extension.</returns>
        protected internal virtual ServiceBusSessionProcessor CreateSessionProcessor(ServiceBusClient client, string entityPath, ServiceBusSessionProcessorOptions options)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));
            Argument.AssertNotNull(options, nameof(options));

            ServiceBusSessionProcessor processor;
            if (ServiceBusEntityPathHelper.ParseEntityType(entityPath) == ServiceBusEntityType.Topic)
            {
                // entityPath for a subscription is "{TopicName}/Subscriptions/{SubscriptionName}"
                ServiceBusEntityPathHelper.ParseTopicAndSubscription(entityPath, out string topic, out string subscription);
                processor = client.CreateSessionProcessor(topic, subscription, options);
            }
            else
            {
                // entityPath for a queue is "{QueueName}"
                processor = client.CreateSessionProcessor(entityPath, options);
            }
            processor.ProcessErrorAsync += Options.ExceptionReceivedHandler;
            return processor;
        }
    }
}
