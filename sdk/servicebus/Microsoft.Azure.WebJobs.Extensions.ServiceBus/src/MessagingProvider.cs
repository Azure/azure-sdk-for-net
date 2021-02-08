// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
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
        private readonly ConcurrentDictionary<string, ServiceBusSender> _messageSenderCache = new ConcurrentDictionary<string, ServiceBusSender>();
        private readonly ConcurrentDictionary<string, ServiceBusReceiver> _messageReceiverCache = new ConcurrentDictionary<string, ServiceBusReceiver>();
        private readonly ConcurrentDictionary<string, ServiceBusClient> _clientCache = new ConcurrentDictionary<string, ServiceBusClient>();
        private readonly ConcurrentDictionary<string, ServiceBusProcessor> _processorCache = new ConcurrentDictionary<string, ServiceBusProcessor>();
        private readonly ConcurrentDictionary<string, ServiceBusSessionProcessor> _sessionProcessorCache = new ConcurrentDictionary<string, ServiceBusSessionProcessor>();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="serviceBusOptions">The <see cref="ServiceBusOptions"/>.</param>
        public MessagingProvider(IOptions<ServiceBusOptions> serviceBusOptions)
        {
            _options = serviceBusOptions?.Value ?? throw new ArgumentNullException(nameof(serviceBusOptions));
        }

        /// <summary>
        /// Creates a <see cref="MessageProcessor"/> for the specified ServiceBus entity.
        /// </summary>
        /// <param name="entityPath">The ServiceBus entity to create a <see cref="MessageProcessor"/> for.</param>
        /// <param name="connectionString">The ServiceBus connection string.</param>
        /// <returns>The <see cref="MessageProcessor"/>.</returns>
        public virtual MessageProcessor CreateMessageProcessor(string entityPath, string connectionString)
        {
            if (string.IsNullOrEmpty(entityPath))
            {
                throw new ArgumentNullException(nameof(entityPath));
            }
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            return new MessageProcessor(GetOrAddProcessor(entityPath, connectionString));
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusProcessor"/> for the specified ServiceBus entity.
        /// </summary>
        /// <remarks>
        /// You can override this method to customize the <see cref="ServiceBusProcessor"/>.
        /// </remarks>
        /// <param name="entityPath">The ServiceBus entity to create a <see cref="ServiceBusProcessor"/> for.</param>
        /// <param name="connectionString">The ServiceBus connection string.</param>
        /// <returns></returns>
        public virtual ServiceBusProcessor CreateProcessor(string entityPath, string connectionString)
        {
            if (string.IsNullOrEmpty(entityPath))
            {
                throw new ArgumentNullException(nameof(entityPath));
            }
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            return GetOrAddProcessor(entityPath, connectionString);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusSender"/> for the specified ServiceBus entity.
        /// </summary>
        /// <remarks>
        /// You can override this method to customize the <see cref="ServiceBusSender"/>.
        /// </remarks>
        /// <param name="entityPath">The ServiceBus entity to create a <see cref="ServiceBusSender"/> for.</param>
        /// <param name="connectionString">The ServiceBus connection string.</param>
        /// <returns></returns>
        public virtual ServiceBusSender CreateMessageSender(string entityPath, string connectionString)
        {
            if (string.IsNullOrEmpty(entityPath))
            {
                throw new ArgumentNullException(nameof(entityPath));
            }
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            return GetOrAddMessageSender(entityPath, connectionString);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusReceiver"/> for the specified ServiceBus entity.
        /// </summary>
        /// <remarks>
        /// You can override this method to customize the <see cref="ServiceBusReceiver"/>.
        /// </remarks>
        /// <param name="entityPath">The ServiceBus entity to create a <see cref="ServiceBusReceiver"/> for.</param>
        /// <param name="connectionString">The ServiceBus connection string.</param>
        /// <returns></returns>
        public virtual ServiceBusReceiver CreateBatchMessageReceiver(string entityPath, string connectionString)
        {
            if (string.IsNullOrEmpty(entityPath))
            {
                throw new ArgumentNullException(nameof(entityPath));
            }
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            return GetOrAddMessageReceiver(entityPath, connectionString);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusClient"/> for the specified ServiceBus connection.
        /// </summary>
        /// <remarks>
        /// You can override this method to customize the <see cref="ServiceBusClient"/>.
        /// </remarks>
        /// <param name="connectionString">The ServiceBus connection string.</param>
        /// <returns></returns>
        public virtual ServiceBusClient CreateClient(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            return new ServiceBusClient(connectionString, _options.ToClientOptions());
        }

        /// <summary>
        /// Creates a <see cref="SessionMessageProcessor"/> for the specified ServiceBus entity.
        /// </summary>
        /// <param name="entityPath">The ServiceBus entity to create a <see cref="SessionMessageProcessor"/> for.</param>
        /// <param name="connectionString">The ServiceBus connection string.</param>
        /// <returns></returns>
        public virtual SessionMessageProcessor CreateSessionMessageProcessor(string entityPath, string connectionString)
        {
            if (string.IsNullOrEmpty(entityPath))
            {
                throw new ArgumentNullException(nameof(entityPath));
            }
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            return new SessionMessageProcessor(GetOrAddSessionProcessor(entityPath, connectionString));
        }

        private ServiceBusSender GetOrAddMessageSender(string entityPath, string connectionString)
        {
            ServiceBusClient client = _clientCache.GetOrAdd(connectionString, CreateClient(connectionString));
            return _messageSenderCache.GetOrAdd(entityPath, client.CreateSender(entityPath));
        }

        private ServiceBusReceiver GetOrAddMessageReceiver(string entityPath, string connectionString)
        {
            ServiceBusClient client = _clientCache.GetOrAdd(connectionString, (_) => CreateClient(connectionString));
            return _messageReceiverCache.GetOrAdd(entityPath, (_) => client.CreateReceiver(entityPath, new ServiceBusReceiverOptions
            {
                PrefetchCount = _options.PrefetchCount
            }));
        }

        private ServiceBusProcessor GetOrAddProcessor(string entityPath, string connectionString)
        {
            ServiceBusClient client = _clientCache.GetOrAdd(connectionString, (_) => CreateClient(connectionString));
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

        private ServiceBusSessionProcessor GetOrAddSessionProcessor(string entityPath, string connectionString)
        {
            ServiceBusClient client = _clientCache.GetOrAdd(connectionString, (_) => CreateClient(connectionString));
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

        internal ServiceBusClient CreateSessionClient(string connectionString)
        {
            return _clientCache.GetOrAdd(connectionString, (_) => CreateClient(connectionString));
        }
    }
}
