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
    internal class ServiceBusClientFactory
    {
        private readonly ServiceBusOptions _options;
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _componentFactory;

        private readonly ConcurrentDictionary<string, ServiceBusSender> _messageSenderCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusReceiver> _messageReceiverCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusClient> _clientCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusProcessor> _processorCache = new();
        private readonly ConcurrentDictionary<string, ServiceBusSessionProcessor> _sessionProcessorCache = new();

        protected ServiceBusClientFactory()
        {
        }

        public ServiceBusClientFactory(
            IConfiguration configuration,
            AzureComponentFactory componentFactory,
            IOptions<ServiceBusOptions> options,
            AzureEventSourceLogForwarder forwarder)
        {
            forwarder.Start();
            _configuration = configuration;
            _componentFactory = componentFactory;
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public virtual MessageProcessor CreateMessageProcessor(string entityPath, string connection)
        {
            return new MessageProcessor(GetOrAddProcessor(entityPath, connection));
        }

        public ServiceBusProcessor CreateProcessor(string entityPath, string connection)
        {
            return GetOrAddProcessor(entityPath, connection);
        }

        public ServiceBusSender CreateMessageSender(string entityPath, string connection)
        {
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return GetOrAddMessageSender(entityPath, connection);
        }

        public virtual ServiceBusReceiver CreateBatchMessageReceiver(string entityPath, string connection)
        {
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return GetOrAddMessageReceiver(entityPath, connection);
        }

        public SessionMessageProcessor CreateSessionMessageProcessor(string entityPath, string connection)
        {
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));

            return new SessionMessageProcessor(GetOrAddSessionProcessor(entityPath, connection));
        }

        public ServiceBusAdministrationClient CreateAdministrationClient(string entityPath, string connection)
        {
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));
            var connectionInfo = ResolveConnectionInformation(connection);
            if (connectionInfo.ConnectionString != null)
            {
                return new ServiceBusAdministrationClient(connectionInfo.ConnectionString);
            }
            else
            {
                return new ServiceBusAdministrationClient(connectionInfo.FullyQualifiedNamespace, connectionInfo.Credential);
            }
        }

        private ServiceBusSender GetOrAddMessageSender(string entityPath, string connection)
        {
            ServiceBusClient client = GetOrCreateClient(connection);
            return _messageSenderCache.GetOrAdd(entityPath, client.CreateSender(entityPath));
        }

        private ServiceBusReceiver GetOrAddMessageReceiver(string entityPath, string connection)
        {
            ServiceBusClient client = GetOrCreateClient(connection);

            return _messageReceiverCache.GetOrAdd(entityPath, (_) => client.CreateReceiver(
                entityPath,
                new ServiceBusReceiverOptions
            {
                PrefetchCount = _options.PrefetchCount
            }));
        }

        private ServiceBusProcessor GetOrAddProcessor(string entityPath, string connection)
        {
            ServiceBusClient client = GetOrCreateClient(connection);

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

        private ServiceBusSessionProcessor GetOrAddSessionProcessor(string entityPath, string connection)
        {
            ServiceBusClient client = GetOrCreateClient(connection);

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

        internal ServiceBusClient CreateSessionClient(string connection) =>
            GetOrCreateClient(connection);

        private ServiceBusClient GetOrCreateClient(string connection)
        {
            var connectionInfo = ResolveConnectionInformation(connection);
            if (connectionInfo.ConnectionString != null)
            {
                return _clientCache.GetOrAdd(
                    connectionInfo.ConnectionString,
                    (_) => new ServiceBusClient(connectionInfo.ConnectionString, _options.ToClientOptions()));
            }
            else
            {
                return _clientCache.GetOrAdd(
                    connectionInfo.FullyQualifiedNamespace,
                    (_) => new ServiceBusClient(connectionInfo.FullyQualifiedNamespace, connectionInfo.Credential, _options.ToClientOptions()));
            }
        }

        private ServiceBusConnectionInformation ResolveConnectionInformation(string connection)
        {
            var connectionSetting = connection ?? Constants.DefaultConnectionStringName;
            IConfigurationSection connectionSection = _configuration.GetWebJobsConnectionStringSection(connectionSetting);
            if (!connectionSection.Exists())
            {
                // Not found
                throw new InvalidOperationException($"Service Bus account connection string '{connectionSetting}' does not exist. " +
                                                    $"Make sure that it is a defined App Setting.");
            }

            if (!string.IsNullOrWhiteSpace(connectionSection.Value))
            {
                return new ServiceBusConnectionInformation(connectionSection.Value);
            }
            else
            {
                string fullyQualifiedNamespace = connectionSection["fullyQualifiedNamespace"];
                if (string.IsNullOrWhiteSpace(fullyQualifiedNamespace))
                {
                    // Not found
                    throw new InvalidOperationException($"Connection should have an 'fullyQualifiedNamespace' property or be a " +
                        $"string representing a connection string.");
                }

                TokenCredential credential = _componentFactory.CreateTokenCredential(connectionSection);
                return new ServiceBusConnectionInformation(fullyQualifiedNamespace, credential);
            }
        }

        private record ServiceBusConnectionInformation
        {
            public ServiceBusConnectionInformation(string connectionString)
            {
                ConnectionString = connectionString;
            }

            public ServiceBusConnectionInformation(string fullyQualifiedNamespace, TokenCredential tokenCredential)
            {
                FullyQualifiedNamespace = fullyQualifiedNamespace;
                Credential = tokenCredential;
            }

            public string ConnectionString { get; }
            public string FullyQualifiedNamespace { get; }
            public TokenCredential Credential { get; }
        }
    }
}
