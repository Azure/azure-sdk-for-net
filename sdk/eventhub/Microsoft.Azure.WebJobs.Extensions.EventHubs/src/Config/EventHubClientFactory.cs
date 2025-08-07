// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using Azure.Core;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    internal class EventHubClientFactory
    {
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _componentFactory;
        private readonly EventHubOptions _options;
        private readonly INameResolver _nameResolver;
        private readonly CheckpointClientProvider _checkpointClientProvider;
        private readonly ConcurrentDictionary<string, EventHubProducerClient> _producerCache;
        private readonly ConcurrentDictionary<string, IEventHubConsumerClient> _consumerCache = new();

        public EventHubClientFactory(
            IConfiguration configuration,
            AzureComponentFactory componentFactory,
            IOptions<EventHubOptions> options,
            INameResolver nameResolver,
            AzureEventSourceLogForwarder forwarder,
            CheckpointClientProvider checkpointClientProvider)
        {
            forwarder.Start();
            _configuration = configuration;
            _componentFactory = componentFactory;
            _options = options.Value;
            _nameResolver = nameResolver;
            _checkpointClientProvider = checkpointClientProvider;
            _producerCache = new ConcurrentDictionary<string, EventHubProducerClient>();
        }

        internal EventHubProducerClient GetEventHubProducerClient(string eventHubName, string connection)
        {
            eventHubName = _nameResolver.ResolveWholeString(eventHubName);
            connection = _nameResolver.ResolveWholeString(connection);

            if (!string.IsNullOrWhiteSpace(connection))
            {
                var info = ResolveConnectionInformation(connection);
                eventHubName = NormalizeEventHubName(info.ConnectionString, eventHubName);

                var eventHubProducerClientOptions = new EventHubProducerClientOptions
                {
                    RetryOptions = _options.ClientRetryOptions,
                    ConnectionOptions = _options.ConnectionOptions
                };

                EventHubConnection eventHubConnection;

                if (info.FullyQualifiedEndpoint != null &&
                    info.TokenCredential != null)
                {
                    eventHubConnection = new EventHubConnection(info.FullyQualifiedEndpoint, eventHubName, info.TokenCredential, eventHubProducerClientOptions.ConnectionOptions);
                }
                else
                {
                    eventHubConnection = new EventHubConnection(info.ConnectionString, eventHubName, eventHubProducerClientOptions.ConnectionOptions);
                }

                return _producerCache.GetOrAdd(GenerateCacheKey(eventHubConnection), key =>
                {
                    return new EventHubProducerClient(
                        eventHubConnection,
                        eventHubProducerClientOptions);
                });
            }

            throw new InvalidOperationException("No event hub sender named " + eventHubName);
        }

        internal EventProcessorHost GetEventProcessorHost(string eventHubName, string connection, string consumerGroup, bool singleDispatch)
        {
            consumerGroup ??= EventHubConsumerClient.DefaultConsumerGroupName;

            eventHubName = _nameResolver.ResolveWholeString(eventHubName);
            connection = _nameResolver.ResolveWholeString(connection);
            consumerGroup = _nameResolver.ResolveWholeString(consumerGroup);

            if (!string.IsNullOrEmpty(connection))
            {
                var info = ResolveConnectionInformation(connection);
                eventHubName = NormalizeEventHubName(info.ConnectionString, eventHubName);

                var maxEventBatchSize = singleDispatch ? 1 : _options.MaxEventBatchSize;
                if (info.FullyQualifiedEndpoint != null &&
                    info.TokenCredential != null)
                {
                    return new EventProcessorHost(consumerGroup: consumerGroup,
                        fullyQualifiedNamespace: info.FullyQualifiedEndpoint,
                        eventHubName: eventHubName,
                        credential: info.TokenCredential,
                        options: _options.EventProcessorOptions,
                        eventBatchMaximumCount: maxEventBatchSize,
                        exceptionHandler: _options.ExceptionHandler);
                }

                return new EventProcessorHost(consumerGroup: consumerGroup,
                    connectionString: info.ConnectionString,
                    eventHubName: eventHubName,
                    options: _options.EventProcessorOptions,
                    eventBatchMaximumCount: maxEventBatchSize,
                    exceptionHandler: _options.ExceptionHandler);
            }

            throw new InvalidOperationException("No event hub receiver named " + eventHubName);
        }

        internal IEventHubConsumerClient GetEventHubConsumerClient(string eventHubName, string connection, string consumerGroup)
        {
            consumerGroup ??= EventHubConsumerClient.DefaultConsumerGroupName;
            eventHubName = _nameResolver.ResolveWholeString(eventHubName);
            connection = _nameResolver.ResolveWholeString(connection);
            consumerGroup = _nameResolver.ResolveWholeString(consumerGroup);

            if (!string.IsNullOrEmpty(connection))
            {
                var info = ResolveConnectionInformation(connection);
                eventHubName = NormalizeEventHubName(info.ConnectionString, eventHubName);

                var eventHubConsumerClientOptions = new EventHubConsumerClientOptions
                {
                    RetryOptions = _options.ClientRetryOptions,
                    ConnectionOptions = _options.ConnectionOptions
                };

                EventHubConnection eventHubConnection;

                if (info.FullyQualifiedEndpoint != null &&
                    info.TokenCredential != null)
                {
                    eventHubConnection = new EventHubConnection(info.FullyQualifiedEndpoint, eventHubName, info.TokenCredential, eventHubConsumerClientOptions.ConnectionOptions);
                }
                else
                {
                    eventHubConnection = new EventHubConnection(info.ConnectionString, eventHubName, eventHubConsumerClientOptions.ConnectionOptions);
                }

                return _consumerCache.GetOrAdd(GenerateCacheKey(eventHubConnection, consumerGroup), key =>
                    new EventHubConsumerClientImpl(
                        new EventHubConsumerClient(
                            consumerGroup,
                            eventHubConnection,
                            eventHubConsumerClientOptions)));
            }

            throw new InvalidOperationException("No event hub receiver named " + eventHubName);
        }

        internal BlobContainerClient GetCheckpointStoreClient()
        {
            var client =  _checkpointClientProvider.Get(ConnectionStringNames.Storage);
            return client.GetBlobContainerClient(_options.CheckpointContainer);
        }

        internal static string NormalizeEventHubName(string connectionString, string configuredEventHubName)
        {
            // If an Event Hub was specified as the entity path for the connection string, it
            // should take precedence over the configuration-specified value.

            if (string.IsNullOrEmpty(connectionString))
            {
                return configuredEventHubName;
            }

            var connectionStringProperties = EventHubsConnectionStringProperties.Parse(connectionString);

            if (!string.IsNullOrEmpty(connectionStringProperties.EventHubName))
            {
                return connectionStringProperties.EventHubName;
            }

            return configuredEventHubName;
        }

        private EventHubsConnectionInformation ResolveConnectionInformation(string connection)
        {
            IConfigurationSection connectionSection = _configuration.GetWebJobsConnectionStringSection(connection);
            if (!connectionSection.Exists())
            {
                // A common mistake is for developers to set their `connection` to a full connection string rather
                // than an informational name.  If the value validates as a connection string, redact it to prevent
                // leaking sensitive information.
                if (IsEventHubsConnectionString(connection))
                {
                    connection =  "<< REDACTED >> (a full connection string was incorrectly used instead of a connection setting name)";
                }

                // Not found
                throw new InvalidOperationException($"EventHub account connection string with name '{connection}' does not exist in the settings. " +
                                                    $"Make sure that it is a defined App Setting.");
            }

            if (!string.IsNullOrWhiteSpace(connectionSection.Value))
            {
                return new EventHubsConnectionInformation(connectionSection.Value);
            }

            var fullyQualifiedNamespace = connectionSection["fullyQualifiedNamespace"];
            if (string.IsNullOrWhiteSpace(fullyQualifiedNamespace))
            {
                // Not found
                throw new InvalidOperationException($"Connection should have an 'fullyQualifiedNamespace' property or be a string representing a connection string.");
            }

            var credential = _componentFactory.CreateTokenCredential(connectionSection);

            return new EventHubsConnectionInformation(fullyQualifiedNamespace, credential);
        }

        private static bool IsEventHubsConnectionString(string connectionString)
        {
            try
            {
                var properties = EventHubsConnectionStringProperties.Parse(connectionString);

                return (!string.IsNullOrEmpty(properties.FullyQualifiedNamespace))
                    || (!string.IsNullOrEmpty(properties.SharedAccessKeyName))
                    || (!string.IsNullOrEmpty(properties.SharedAccessKey))
                    || (!string.IsNullOrEmpty(properties.SharedAccessSignature))
                    || (!string.IsNullOrEmpty(properties.EventHubName));
            }
            catch
            {
                return false;
            }
        }

        private static string GenerateCacheKey(EventHubConnection eventHubConnection, string consumerGroup = null) =>
            consumerGroup == null
            ? $"{eventHubConnection.FullyQualifiedNamespace}/{eventHubConnection.EventHubName}"
            : $"{eventHubConnection.FullyQualifiedNamespace}/{eventHubConnection.EventHubName}/{consumerGroup}";

        private record EventHubsConnectionInformation
        {
            public EventHubsConnectionInformation(string connectionString)
            {
                ConnectionString = connectionString;
            }

            public EventHubsConnectionInformation(string fullyQualifiedEndpoint, TokenCredential tokenCredential)
            {
                FullyQualifiedEndpoint = fullyQualifiedEndpoint;
                TokenCredential = tokenCredential;
            }

            public string ConnectionString { get; }
            public string FullyQualifiedEndpoint { get; }
            public TokenCredential TokenCredential { get; }
        }
    }
}