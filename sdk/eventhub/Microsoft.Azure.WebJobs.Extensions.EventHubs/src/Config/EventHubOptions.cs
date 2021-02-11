// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    public class EventHubOptions : IOptionsFormatter
    {
        /// <summary>
        /// Name of the blob container that the EventHostProcessor instances uses to coordinate load balancing listening on an event hub.
        /// Each event hub gets its own blob prefix within the container.
        /// </summary>
        public const string LeaseContainerName = "azure-webjobs-eventhub";

        public EventHubOptions()
        {
            MaxBatchSize = 10;
            InvokeFunctionAfterReceiveTimeout = false;
            EventProcessorOptions = new EventProcessorOptions()
            {
                LoadBalancingStrategy = LoadBalancingStrategy.Greedy,
                TrackLastEnqueuedEventProperties = false,
                MaximumWaitTime = TimeSpan.FromMinutes(1),
                PrefetchCount = 300,
                DefaultStartingPosition = EventPosition.Earliest,
            };
            InitialOffsetOptions = new InitialOffsetOptions();
        }

        internal EventProcessorOptions EventProcessorOptions { get; }

        /// <summary>
        ///   The options used for configuring the connection to the Event Hubs service.
        /// </summary>
        ///
        public EventHubConnectionOptions ConnectionOptions
        {
            get => EventProcessorOptions.ConnectionOptions;
            set => EventProcessorOptions.ConnectionOptions = value;
        }

        /// <summary>
        ///   The set of options to use for determining whether a failed operation should be retried and,
        ///   if so, the amount of time to wait between retry attempts.  These options also control the
        ///   amount of time allowed for receiving event batches and other interactions with the Event Hubs service.
        /// </summary>
        ///
        public EventHubsRetryOptions RetryOptions
        {
            get => EventProcessorOptions.RetryOptions;
            set => EventProcessorOptions.RetryOptions = value;
        }

        private int _batchCheckpointFrequency = 1;

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
                    throw new ArgumentException("Batch size must be larger than 0.");
                }
                _maxBatchSize = value;
            }
        }

        /// <summary>
        /// Returns whether the function would be triggered when a receive timeout occurs.
        /// </summary>
        public bool InvokeFunctionAfterReceiveTimeout { get; set; }

        /// <summary>
        /// Gets the initial offset options to apply when processing. This only applies
        /// when no checkpoint information is available.
        /// </summary>
        public InitialOffsetOptions InitialOffsetOptions { get; }

        /// <inheritdoc cref="EventProcessorOptions.TrackLastEnqueuedEventProperties"/>
        public bool TrackLastEnqueuedEventProperties
        {
            get => EventProcessorOptions.TrackLastEnqueuedEventProperties;
            set => EventProcessorOptions.TrackLastEnqueuedEventProperties = value;
        }

        /// <inheritdoc cref="EventProcessorOptions.PrefetchCount"/>
        public int PrefetchCount
        {
            get => EventProcessorOptions.PrefetchCount;
            set => EventProcessorOptions.PrefetchCount = value;
        }

        /// <inheritdoc cref="EventProcessorOptions.PrefetchSizeInBytes"/>
        public long? PrefetchSizeInBytes
        {
            get => EventProcessorOptions.PrefetchSizeInBytes;
            set => EventProcessorOptions.PrefetchSizeInBytes = value;
        }

        /// <inheritdoc cref="EventProcessorOptions.Identifier"/>
        public string ProcessorIdentifier
        {
            get => EventProcessorOptions.Identifier;
            set => EventProcessorOptions.Identifier = value;
        }

        /// <summary>
        ///   The maximum amount of time to wait for events to become available. If <see cref="InvokeFunctionAfterReceiveTimeout"/> is true,
        ///   the function will be triggered with an empty <see cref="EventData"/>.
        /// </summary>
        public TimeSpan MaximumWaitTime
        {
            get => EventProcessorOptions.MaximumWaitTime.Value;
            set => EventProcessorOptions.MaximumWaitTime = value;
        }

        /// <inheritdoc cref="EventProcessorOptions.PartitionOwnershipExpirationInterval"/>
        public TimeSpan PartitionOwnershipExpirationInterval
        {
            get => EventProcessorOptions.PartitionOwnershipExpirationInterval;
            set => EventProcessorOptions.PartitionOwnershipExpirationInterval = value;
        }

        /// <inheritdoc cref="EventProcessorOptions.LoadBalancingUpdateInterval"/>
        public TimeSpan LoadBalancingUpdateInterval
        {
            get => EventProcessorOptions.LoadBalancingUpdateInterval;
            set => EventProcessorOptions.LoadBalancingUpdateInterval = value;
        }

        /// <inheritdoc cref="EventProcessorOptions.LoadBalancingStrategy"/>
        public LoadBalancingStrategy LoadBalancingStrategy
        {
            get => EventProcessorOptions.LoadBalancingStrategy;
            set => EventProcessorOptions.LoadBalancingStrategy = value;
        }

        /// <summary>
        /// Gets or sets the Azure Blobs container name that the event processor uses to coordinate load balancing listening on an event hub.
        /// </summary>
        internal string CheckpointContainer { get; set; } = LeaseContainerName;

        internal Action<ExceptionReceivedEventArgs> ExceptionHandler { get; set; }

        // Event Hub Names are case-insensitive.
        // The same path can have multiple connection strings with different permissions (sending and receiving),
        // so we track senders and receivers separately and infer which one to use based on the EventHub (sender) vs. EventHubTrigger (receiver) attribute.
        // Connection strings may also encapsulate different endpoints.
        internal Dictionary<string, EventHubProducerClient> RegisteredProducers { get; } = new ();
        internal Dictionary<string, ReceiverCredentials> RegisteredConsumerCredentials { get; } = new ();

        /// <summary>
        /// Add an existing client for sending messages to an event hub.
        /// </summary>
        /// <param name="eventHubName">name of the event hub</param>
        /// <param name="client"></param>
        internal void AddEventHubProducerClient(string eventHubName, EventHubProducerClient client)
        {
            if (eventHubName == null)
            {
                throw new ArgumentNullException(nameof(eventHubName));
            }
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            RegisteredProducers[eventHubName] = client;
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

            var client = new EventHubProducerClient(
                EventHubClientFactory.NormalizeConnectionString(sendConnectionString, eventHubName),
                new EventHubProducerClientOptions()
                {
                    ConnectionOptions = ConnectionOptions,
                    RetryOptions = RetryOptions
                });

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

            RegisteredConsumerCredentials[eventHubName] = new ReceiverCredentials
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

            RegisteredConsumerCredentials[eventHubName] = new ReceiverCredentials
            {
                EventHubConnectionString = receiverConnectionString,
                StorageConnectionString = storageConnectionString
            };
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
            JObject options = new JObject
                {
                    { nameof(MaxBatchSize), MaxBatchSize },
                    { nameof(InvokeFunctionAfterReceiveTimeout), InvokeFunctionAfterReceiveTimeout },
                    { nameof(BatchCheckpointFrequency), BatchCheckpointFrequency },
                    { nameof(ConnectionOptions), ConstructConnectionOptions() },
                    { nameof(RetryOptions), ConstructRetryOptions() },
                    { nameof(ProcessorIdentifier), ProcessorIdentifier },
                    { nameof(TrackLastEnqueuedEventProperties), TrackLastEnqueuedEventProperties },
                    { nameof(PrefetchCount), PrefetchCount },
                    { nameof(PrefetchSizeInBytes), PrefetchSizeInBytes },
                    { nameof(MaximumWaitTime), MaximumWaitTime },
                    { nameof(PartitionOwnershipExpirationInterval), PartitionOwnershipExpirationInterval },
                    { nameof(LoadBalancingUpdateInterval), LoadBalancingUpdateInterval },
                    { nameof(LoadBalancingStrategy), LoadBalancingStrategy.ToString() },
                    { nameof(InitialOffsetOptions), ConstructInitialOffsetOptions() },
                };
            return options.ToString(Formatting.Indented);
        }

        private JObject ConstructConnectionOptions() =>
            new JObject
        {
            { nameof(EventHubConnectionOptions.TransportType), ConnectionOptions.TransportType.ToString() },
            { nameof(EventHubConnectionOptions.Proxy), ConnectionOptions.Proxy?.ToString() ?? string.Empty},
        };

        private JObject ConstructRetryOptions() =>
            new JObject
            {
                { nameof(EventHubsRetryOptions.Mode), RetryOptions.Mode.ToString() },
                { nameof(EventHubsRetryOptions.TryTimeout), RetryOptions.TryTimeout },
                { nameof(EventHubsRetryOptions.Delay), RetryOptions.Delay },
                { nameof(EventHubsRetryOptions.MaximumDelay), RetryOptions.MaximumDelay },
                { nameof(EventHubsRetryOptions.MaximumRetries), RetryOptions.MaximumRetries },
            };

        private JObject ConstructInitialOffsetOptions() =>
            new JObject
                {
                    { nameof(InitialOffsetOptions.Type), InitialOffsetOptions.Type },
                    { nameof(InitialOffsetOptions.EnqueuedTimeUTC), InitialOffsetOptions.EnqueuedTimeUTC },
                };

        // Hold credentials for a given eventHub name.
        // Multiple consumer groups (and multiple listeners) on the same hub can share the same credentials.
        internal class ReceiverCredentials
        {
            // Required.
            public string EventHubConnectionString { get; set; }

            // Optional. If not found, use the stroage from JobHostConfiguration
            public string StorageConnectionString { get; set; }
        }
    }
}
