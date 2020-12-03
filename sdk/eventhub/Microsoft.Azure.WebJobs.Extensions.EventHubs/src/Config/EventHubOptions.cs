// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    public class EventHubOptions : IOptionsFormatter
    {
        // Event Hub Names are case-insensitive.
        // The same path can have multiple connection strings with different permissions (sending and receiving),
        // so we track senders and receivers separately and infer which one to use based on the EventHub (sender) vs. EventHubTrigger (receiver) attribute.
        // Connection strings may also encapsulate different endpoints.

        // The client cache must be thread safe because clients are accessed/added on the function
        private readonly ConcurrentDictionary<string, EventHubProducerClient> _clients = new ConcurrentDictionary<string, EventHubProducerClient>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, ReceiverCreds> _receiverCreds = new Dictionary<string, ReceiverCreds>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Name of the blob container that the EventHostProcessor instances uses to coordinate load balancing listening on an event hub.
        /// Each event hub gets its own blob prefix within the container.
        /// </summary>
        public string LeaseContainerName { get; set; } = "azure-webjobs-eventhub";

        private int _batchCheckpointFrequency = 1;

        public EventHubOptions()
        {
            MaxBatchSize = 10;
            InvokeProcessorAfterReceiveTimeout = false;
            EventProcessorOptions = new EventProcessorOptions()
            {
                MaximumWaitTime = TimeSpan.FromMinutes(1),
                PrefetchCount = 300,
                DefaultStartingPosition = EventPosition.Earliest,
            };
        }

        /// <summary>
        /// Gets or sets the number of batches to process before creating an EventHub cursor checkpoint. Default 1.
        /// </summary>
        public int BatchCheckpointFrequency
        {
            get => _batchCheckpointFrequency;

            set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Batch checkpoint frequency must be larger than 0.");
                }
                _batchCheckpointFrequency = value;
            }
        }

        private int _maxBatchSize;

        /// <summary>
        /// Gets or sets the maximum number of events delivered in a batch. Default 10.
        /// </summary>
        public int MaxBatchSize
        {
            get => _maxBatchSize;

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Batch checkpoint frequency must be larger than 0.");
                }
                _maxBatchSize = value;
            }
        }

        public bool InvokeProcessorAfterReceiveTimeout { get; set; }

        public EventProcessorOptions EventProcessorOptions { get; }

        private Action<ExceptionReceivedEventArgs> _exceptionHandler;

        internal void SetExceptionHandler(Action<ExceptionReceivedEventArgs> exceptionHandler)
        {
            if (exceptionHandler == null)
            {
                throw new ArgumentNullException(nameof(exceptionHandler));
            }

            _exceptionHandler = exceptionHandler;
        }

        /// <summary>
        /// Add an existing client for sending messages to an event hub.  Infer the eventHub name from client.path
        /// </summary>
        /// <param name="eventHubName">name of the event hub</param>
        /// <param name="client"></param>
        private void AddEventHubProducerClient(string eventHubName, EventHubProducerClient client)
        {
            if (eventHubName == null)
            {
                throw new ArgumentNullException(nameof(eventHubName));
            }
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _clients[eventHubName] = client;
        }

        /// <summary>
        /// Add a connection for sending messages to an event hub. Connect via the connection string.
        /// </summary>
        /// <param name="eventHubName">name of the event hub. </param>
        /// <param name="sendConnectionString">connection string for sending messages. If this includes an EntityPath, it takes precedence over the eventHubName parameter.</param>
        public void AddSender(string eventHubName, string sendConnectionString)
        {
            if (eventHubName == null)
            {
                throw new ArgumentNullException(nameof(eventHubName));
            }
            if (sendConnectionString == null)
            {
                throw new ArgumentNullException(nameof(sendConnectionString));
            }

            var client = new EventHubProducerClient(NormalizeConnectionString(sendConnectionString, eventHubName));
            AddEventHubProducerClient(eventHubName, client);
        }

        /// <summary>
        /// Add a connection for listening on events from an event hub. Connect via the connection string and use the SDK's built-in storage account.
        /// </summary>
        /// <param name="eventHubName">name of the event hub</param>
        /// <param name="receiverConnectionString">connection string for receiving messages. This can encapsulate other service bus properties like the namespace and endpoints.</param>
        public void AddReceiver(string eventHubName, string receiverConnectionString)
        {
            if (eventHubName == null)
            {
                throw new ArgumentNullException(nameof(eventHubName));
            }
            if (receiverConnectionString == null)
            {
                throw new ArgumentNullException(nameof(receiverConnectionString));
            }

            this._receiverCreds[eventHubName] = new ReceiverCreds
            {
                EventHubConnectionString = receiverConnectionString
            };
        }

        /// <summary>
        /// Add a connection for listening on events from an event hub. Connect via the connection string and use the supplied storage account
        /// </summary>
        /// <param name="eventHubName">name of the event hub</param>
        /// <param name="receiverConnectionString">connection string for receiving messages</param>
        /// <param name="storageConnectionString">storage connection string that the EventProcessorHost client will use to coordinate multiple listener instances. </param>
        public void AddReceiver(string eventHubName, string receiverConnectionString, string storageConnectionString)
        {
            if (eventHubName == null)
            {
                throw new ArgumentNullException(nameof(eventHubName));
            }
            if (receiverConnectionString == null)
            {
                throw new ArgumentNullException(nameof(receiverConnectionString));
            }
            if (storageConnectionString == null)
            {
                throw new ArgumentNullException(nameof(storageConnectionString));
            }

            this._receiverCreds[eventHubName] = new ReceiverCreds
            {
                EventHubConnectionString = receiverConnectionString,
                StorageConnectionString = storageConnectionString
            };
        }

        internal EventHubProducerClient GetEventHubProducerClient(IConfiguration configuration, string eventHubName, string connection, AzureComponentFactory componentFactory)
        {
            EventHubProducerClient client;

            if (_clients.TryGetValue(eventHubName, out client))
            {
                return client;
            }
            else if (!string.IsNullOrWhiteSpace(connection))
            {
                return _clients.GetOrAdd(eventHubName, key =>
                {
                    var info = ResolveConnectionInformation(connection, configuration, componentFactory);

                    if (info.FullyQualifiedEndpoint != null &&
                        info.TokenCredential != null)
                    {
                        return new EventHubProducerClient(info.FullyQualifiedEndpoint, eventHubName, info.TokenCredential);
                    }

                    return new EventHubProducerClient(NormalizeConnectionString(info.ConnectionString, eventHubName));
                });
            }

            throw new InvalidOperationException("No event hub sender named " + eventHubName);
        }

        // Lookup a listener for receiving events given the name provided in the [EventHubTrigger] attribute.
        internal EventProcessorHost GetEventProcessorHost(IConfiguration configuration, string eventHubName, string connection, string consumerGroup, AzureComponentFactory componentFactory)
        {
            ReceiverCreds creds;
            if (_receiverCreds.TryGetValue(eventHubName, out creds))
            {
                consumerGroup ??= EventHubConsumerClient.DefaultConsumerGroupName;

                return new EventProcessorHost(consumerGroup: consumerGroup,
                    connectionString: creds.EventHubConnectionString,
                    eventHubName: eventHubName,
                    options: this.EventProcessorOptions,
                    eventBatchMaximumCount: _maxBatchSize,
                    invokeProcessorAfterReceiveTimeout: InvokeProcessorAfterReceiveTimeout,
                    exceptionHandler: _exceptionHandler);
            }
            else if (!string.IsNullOrEmpty(connection))
            {
                var info = ResolveConnectionInformation(connection, configuration, componentFactory);

                if (info.FullyQualifiedEndpoint != null &&
                    info.TokenCredential != null)
                {
                    return new EventProcessorHost(consumerGroup: consumerGroup,
                        fullyQualifiedNamespace: info.FullyQualifiedEndpoint,
                        eventHubName: eventHubName,
                        credential: info.TokenCredential,
                        options: this.EventProcessorOptions,
                        eventBatchMaximumCount: _maxBatchSize,
                        invokeProcessorAfterReceiveTimeout: InvokeProcessorAfterReceiveTimeout,
                        exceptionHandler: _exceptionHandler);
                }

                return new EventProcessorHost(consumerGroup: consumerGroup,
                    connectionString: NormalizeConnectionString(info.ConnectionString, eventHubName),
                    eventHubName: eventHubName,
                    options: this.EventProcessorOptions,
                    eventBatchMaximumCount: _maxBatchSize,
                    invokeProcessorAfterReceiveTimeout: InvokeProcessorAfterReceiveTimeout,
                    exceptionHandler: _exceptionHandler);
            }

            throw new InvalidOperationException("No event hub receiver named " + eventHubName);
        }

        internal IEventHubConsumerClient GetEventHubConsumerClient(IConfiguration configuration, string eventHubName, string connection, string consumerGroup, AzureComponentFactory componentFactory)
        {
            consumerGroup ??= EventHubConsumerClient.DefaultConsumerGroupName;

            EventHubConsumerClient client = null;
            if (_receiverCreds.TryGetValue(eventHubName, out var creds))
            {
                client = new EventHubConsumerClient(consumerGroup, creds.EventHubConnectionString, eventHubName);
            }
            else if (!string.IsNullOrEmpty(connection))
            {
                var info = ResolveConnectionInformation(connection, configuration, componentFactory);

                if (info.FullyQualifiedEndpoint != null &&
                    info.TokenCredential != null)
                {
                    client = new EventHubConsumerClient(consumerGroup, info.FullyQualifiedEndpoint, eventHubName, info.TokenCredential);
                }
                else
                {
                    client = new EventHubConsumerClient(consumerGroup, NormalizeConnectionString(info.ConnectionString, eventHubName));
                }
            }

            if (client != null)
            {
                return new EventHubConsumerClientImpl(client);
            }

            throw new InvalidOperationException("No event hub receiver named " + eventHubName);
        }

        internal string GetCheckpointStoreConnectionString(IConfiguration config, string eventHubName)
        {
            string storageConnectionString = null;
            if (_receiverCreds.TryGetValue(eventHubName, out var creds))
            {
                storageConnectionString = creds.StorageConnectionString;
            }

            // Fall back to default if not explicitly registered
            return storageConnectionString ?? config.GetWebJobsConnectionString(ConnectionStringNames.Storage);
        }

        private static string NormalizeConnectionString(string originalConnectionString, string eventHubName)
        {
            var connectionString = ConnectionString.Parse(originalConnectionString);

            if (!connectionString.ContainsSegmentKey("EntityPath"))
            {
                connectionString.Add("EntityPath", eventHubName);
            }

            return connectionString.ToString();
        }

        private static EventHubsConnectionInformation ResolveConnectionInformation(string connection, IConfiguration configuration, AzureComponentFactory azureComponentFactory)
        {
            IConfigurationSection connectionSection = configuration.GetWebJobsConnectionStringSection(connection);
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

            var credential = azureComponentFactory.CreateTokenCredential(connectionSection);

            return new EventHubsConnectionInformation(fullyQualifiedNamespace, credential);
        }


        private static string EscapeStorageCharacter(char character)
        {
            var ordinalValue = (ushort)character;
            if (ordinalValue < 0x100)
            {
                return string.Format(CultureInfo.InvariantCulture, ":{0:X2}", ordinalValue);
            }
            else
            {
                return string.Format(CultureInfo.InvariantCulture, "::{0:X4}", ordinalValue);
            }
        }

        // Escape a blob path.
        // For diagnostics, we want human-readble strings that resemble the input.
        // Inputs are most commonly alphanumeric with a fex extra chars (dash, underscore, dot).
        // Escape character is a ':', which is also escaped.
        // Blob names are case sensitive; whereas input is case insensitive, so normalize to lower.
        private static string EscapeBlobPath(string path)
        {
            StringBuilder sb = new StringBuilder(path.Length);
            foreach (char c in path)
            {
                if (c >= 'a' && c <= 'z')
                {
                    sb.Append(c);
                }
                else if (c == '-' || c == '_' || c == '.')
                {
                    // Potentially common carahcters.
                    sb.Append(c);
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    sb.Append((char)(c - 'A' + 'a')); // ToLower
                }
                else if (c >= '0' && c <= '9')
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append(EscapeStorageCharacter(c));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get the blob prefix used with EventProcessorHost for a given event hub.
        /// </summary>
        /// <param name="eventHubName">the event hub path</param>
        /// <param name="serviceBusNamespace">the event hub's service bus namespace.</param>
        /// <returns>a blob prefix path that can be passed to EventProcessorHost.</returns>
        /// <remarks>
        /// An event hub is defined by it's path and namespace. The namespace is extracted from the connection string.
        /// This must be an injective one-to-one function because:
        /// 1. multiple machines listening on the same event hub must use the same blob prefix. This means it must be deterministic.
        /// 2. different event hubs must not resolve to the same path.
        /// </remarks>
        public static string GetBlobPrefix(string eventHubName, string serviceBusNamespace)
        {
            if (eventHubName == null)
            {
                throw new ArgumentNullException(nameof(eventHubName));
            }
            if (serviceBusNamespace == null)
            {
                throw new ArgumentNullException(nameof(serviceBusNamespace));
            }

            string key = EscapeBlobPath(serviceBusNamespace) + "/" + EscapeBlobPath(eventHubName) + "/";
            return key;
        }

        public string Format()
        {
            JObject eventProcessorOptions = null;
            if (EventProcessorOptions != null)
            {
                eventProcessorOptions = new JObject
                {
                    { nameof(EventProcessorOptions.TrackLastEnqueuedEventProperties), EventProcessorOptions.TrackLastEnqueuedEventProperties },
                    { nameof(EventProcessorOptions.PrefetchCount), EventProcessorOptions.PrefetchCount },
                    { nameof(EventProcessorOptions.MaximumWaitTime), EventProcessorOptions.MaximumWaitTime }
                };
            }

            JObject options = new JObject
            {
                { nameof(MaxBatchSize), MaxBatchSize },
                { nameof(InvokeProcessorAfterReceiveTimeout), InvokeProcessorAfterReceiveTimeout },
                { nameof(BatchCheckpointFrequency), BatchCheckpointFrequency },
                { nameof(EventProcessorOptions), eventProcessorOptions },
            };

            return options.ToString(Formatting.Indented);
        }

        // Hold credentials for a given eventHub name.
        // Multiple consumer groups (and multiple listeners) on the same hub can share the same credentials.
        private class ReceiverCreds
        {
            // Required.
            public string EventHubConnectionString { get; set; }

            // Optional. If not found, use the stroage from JobHostConfiguration
            public string StorageConnectionString { get; set; }
        }

        private class EventHubsConnectionInformation
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
