// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using Azure.Core;
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
        private readonly ConcurrentDictionary<string, EventHubProducerClient> _producerCache;
        private readonly ConcurrentDictionary<string, IEventHubConsumerClient> _consumerCache = new();

        public EventHubClientFactory(
            IConfiguration configuration,
            AzureComponentFactory componentFactory,
            IOptions<EventHubOptions> options,
            INameResolver nameResolver,
            AzureEventSourceLogForwarder forwarder)
        {
            forwarder.Start();
            _configuration = configuration;
            _componentFactory = componentFactory;
            _options = options.Value;
            _nameResolver = nameResolver;
            _producerCache = new ConcurrentDictionary<string, EventHubProducerClient>();
        }

        internal EventHubProducerClient GetEventHubProducerClient(string eventHubName, string connection)
        {
            eventHubName = _nameResolver.ResolveWholeString(eventHubName);
            connection = _nameResolver.ResolveWholeString(connection);

            return _producerCache.GetOrAdd(eventHubName, key =>
            {
                if (!string.IsNullOrWhiteSpace(connection))
                {
                    var info = ResolveConnectionInformation(connection);

                    if (info.FullyQualifiedEndpoint != null &&
                        info.TokenCredential != null)
                    {
                        return new EventHubProducerClient(
                            info.FullyQualifiedEndpoint,
                            eventHubName,
                            info.TokenCredential,
                            new EventHubProducerClientOptions
                            {
                                RetryOptions = _options.ClientRetryOptions,
                                ConnectionOptions = _options.ConnectionOptions
                            });
                    }

                    return new EventHubProducerClient(
                        NormalizeConnectionString(info.ConnectionString, eventHubName),
                        new EventHubProducerClientOptions
                        {
                            RetryOptions = _options.ClientRetryOptions,
                            ConnectionOptions = _options.ConnectionOptions
                        });
                }

                throw new InvalidOperationException("No event hub sender named " + eventHubName);
            });
        }

        internal EventProcessorHost GetEventProcessorHost(string eventHubName, string connection, string consumerGroup)
        {
            consumerGroup ??= EventHubConsumerClient.DefaultConsumerGroupName;

            eventHubName = _nameResolver.ResolveWholeString(eventHubName);
            connection = _nameResolver.ResolveWholeString(connection);
            consumerGroup = _nameResolver.ResolveWholeString(consumerGroup);

            if (!string.IsNullOrEmpty(connection))
            {
                var info = ResolveConnectionInformation(connection);

                if (info.FullyQualifiedEndpoint != null &&
                    info.TokenCredential != null)
                {
                    return new EventProcessorHost(consumerGroup: consumerGroup,
                        fullyQualifiedNamespace: info.FullyQualifiedEndpoint,
                        eventHubName: eventHubName,
                        credential: info.TokenCredential,
                        options: _options.EventProcessorOptions,
                        eventBatchMaximumCount: _options.MaxBatchSize,
                        exceptionHandler: _options.ExceptionHandler);
                }

                return new EventProcessorHost(consumerGroup: consumerGroup,
                    connectionString: NormalizeConnectionString(info.ConnectionString, eventHubName),
                    eventHubName: eventHubName,
                    options: _options.EventProcessorOptions,
                    eventBatchMaximumCount: _options.MaxBatchSize,
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

            return _consumerCache.GetOrAdd(eventHubName, name =>
            {
                EventHubConsumerClient client = null;

                if (!string.IsNullOrEmpty(connection))
                {
                    var info = ResolveConnectionInformation(connection);

                    if (info.FullyQualifiedEndpoint != null &&
                        info.TokenCredential != null)
                    {
                        client = new EventHubConsumerClient(
                            consumerGroup,
                            info.FullyQualifiedEndpoint,
                            eventHubName,
                            info.TokenCredential,
                            new EventHubConsumerClientOptions
                            {
                                RetryOptions = _options.ClientRetryOptions,
                                ConnectionOptions = _options.ConnectionOptions
                            });
                    }
                    else
                    {
                        client = new EventHubConsumerClient(
                            consumerGroup,
                            NormalizeConnectionString(info.ConnectionString, eventHubName),
                            new EventHubConsumerClientOptions
                            {
                                RetryOptions = _options.ClientRetryOptions,
                                ConnectionOptions = _options.ConnectionOptions
                            });
                    }
                }

                if (client != null)
                {
                    return new EventHubConsumerClientImpl(client);
                }

                throw new InvalidOperationException("No event hub receiver named " + eventHubName);
            });
        }

        internal BlobContainerClient GetCheckpointStoreClient()
        {
            var section = _configuration.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);
            var options = _componentFactory.CreateClientOptions(typeof(BlobClientOptions), null, section);
            var credential = _componentFactory.CreateTokenCredential(section);
            var client = (BlobServiceClient)_componentFactory.CreateClient(typeof(BlobServiceClient), section, credential, options);

            return client.GetBlobContainerClient(_options.CheckpointContainer);
        }

        internal static string NormalizeConnectionString(string originalConnectionString, string eventHubName)
        {
            var connectionString = ConnectionString.Parse(originalConnectionString);

            if (!connectionString.ContainsSegmentKey("EntityPath"))
            {
                connectionString.Add("EntityPath", eventHubName);
            }

            return connectionString.ToString();
        }

        private EventHubsConnectionInformation ResolveConnectionInformation(string connection)
        {
            IConfigurationSection connectionSection = _configuration.GetWebJobsConnectionStringSection(connection);
            if (!connectionSection.Exists())
            {
                // Not found
                throw new InvalidOperationException($"EventHub account connection string '{connection}' does not exist." +
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