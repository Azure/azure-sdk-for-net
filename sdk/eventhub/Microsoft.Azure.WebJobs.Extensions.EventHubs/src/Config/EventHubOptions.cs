// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    public class EventHubOptions : IOptionsFormatter
    {
        public EventHubOptions()
        {
            MaxEventBatchSize = 10;
            MinEventBatchSize = 1;
            MaxWaitTime = 60;
            ConnectionOptions = new EventHubConnectionOptions()
            {
                TransportType = EventHubsTransportType.AmqpTcp
            };
            EventProcessorOptions = new EventProcessorOptions()
            {
                TrackLastEnqueuedEventProperties = false,
                MaximumWaitTime = TimeSpan.FromMinutes(1),
                LoadBalancingStrategy = LoadBalancingStrategy.Greedy,
                PrefetchCount = 300,
                DefaultStartingPosition = EventPosition.Earliest,
                ConnectionOptions = ConnectionOptions
            };
            InitialOffsetOptions = new InitialOffsetOptions();
        }

        internal EventProcessorOptions EventProcessorOptions { get; }

        internal EventHubConnectionOptions ConnectionOptions { get; }

        /// <summary>
        ///   The type of protocol and transport that will be used for communicating with the Event Hubs
        ///   service.
        /// </summary>
        ///
        public EventHubsTransportType TransportType
        {
            get => ConnectionOptions.TransportType;
            set => ConnectionOptions.TransportType = value;
        }

        /// <summary>
        ///   The proxy to use for communication over web sockets.
        /// </summary>
        ///
        /// <remarks>
        ///   A proxy cannot be used for communication over TCP; if web sockets are not in
        ///   use, specifying a proxy is an invalid option.
        /// </remarks>
        public IWebProxy WebProxy
        {
            get => ConnectionOptions.Proxy;
            set => ConnectionOptions.Proxy = value;
        }

        /// <summary>
        ///   The address to use for establishing a connection to the Event Hubs service, allowing network requests to be
        ///   routed through any application gateways or other paths needed for the host environment.
        /// </summary>
        ///
        /// <value>
        ///   This address will override the default endpoint of the Event Hubs namespace when making the network request
        ///   to the service.  The default endpoint specified in a connection string or by a fully qualified namespace will
        ///   still be needed to negotiate the connection with the Event Hubs service.
        /// </value>
        ///
        public Uri CustomEndpointAddress
        {
            get => ConnectionOptions.CustomEndpointAddress;
            set => ConnectionOptions.CustomEndpointAddress = value;
        }

        /// <summary>
        ///   The set of options to use for determining whether a failed operation should be retried and,
        ///   if so, the amount of time to wait between retry attempts.  These options also control the
        ///   amount of time allowed for receiving event batches and other interactions with the Event Hubs service.
        /// </summary>
        ///
        public EventHubsRetryOptions ClientRetryOptions
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

        private int _maxEventBatchSize;

        /// <summary>
        /// Gets or sets the maximum number of events delivered in a batch. This setting applies only to functions that
        /// receive multiple events. Default 10.
        /// </summary>
        public int MaxEventBatchSize
        {
            get => _maxEventBatchSize;

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Batch size must be larger than 0.");
                }
                _maxEventBatchSize = value;
            }
        }

        private int _minEventBatchSize;

        /// <summary>
        /// Gets or sets the minimum number of events delivered in a batch. TODO.
        /// </summary>
        public int MinEventBatchSize
        {
            get => _minEventBatchSize;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Batch size must be larger than or equal to 0.");
                }
                if (value > MaxEventBatchSize)
                {
                    throw new ArgumentException("Maximum batch size must be larger than minimum batch size.");
                }
                _minEventBatchSize = value;
            }
        }

        private int _maxWaitTime;

        /// <summary>
        /// Gets or sets the minimum number of events delivered in a batch. TODO.
        /// </summary>
        public int MaxWaitTime
        {
            get => _maxWaitTime;

            set
            {
                _maxWaitTime = value;
            }
        }

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

        /// <summary>
        /// Gets or sets the Azure Blobs container name that the event processor uses to coordinate load balancing listening on an event hub.
        /// </summary>
        internal string CheckpointContainer { get; set; } =  "azure-webjobs-eventhub";

        internal Action<ExceptionReceivedEventArgs> ExceptionHandler { get; set; }

        /// <summary>
        /// Returns a string representation of this <see cref="EventHubOptions"/> instance.
        /// </summary>
        /// <returns>A string representation of this <see cref="EventHubOptions"/> instance.</returns>
        string IOptionsFormatter.Format()
        {
            JObject options = new JObject
                {
                    { nameof(MaxEventBatchSize), MaxEventBatchSize },
                    { nameof(MinEventBatchSize), MinEventBatchSize },
                    { nameof(MaxWaitTime), MaxWaitTime },
                    { nameof(BatchCheckpointFrequency), BatchCheckpointFrequency },
                    { nameof(TransportType),  TransportType.ToString()},
                    { nameof(WebProxy),  WebProxy is WebProxy proxy ? proxy.Address.AbsoluteUri : string.Empty },
                    { nameof(ClientRetryOptions), ConstructRetryOptions() },
                    { nameof(TrackLastEnqueuedEventProperties), TrackLastEnqueuedEventProperties },
                    { nameof(PrefetchCount), PrefetchCount },
                    { nameof(PrefetchSizeInBytes), PrefetchSizeInBytes },
                    { nameof(PartitionOwnershipExpirationInterval), PartitionOwnershipExpirationInterval },
                    { nameof(LoadBalancingUpdateInterval), LoadBalancingUpdateInterval },
                    { nameof(InitialOffsetOptions), ConstructInitialOffsetOptions() },
                };
            // Only include if not null since it would otherwise not round-trip correctly due to
            // https://github.com/dotnet/runtime/issues/36510. Once this issue is fixed, it can be included
            // unconditionally.
            if (CustomEndpointAddress != null)
            {
                options.Add(nameof(CustomEndpointAddress), CustomEndpointAddress?.AbsoluteUri);
            }

            return options.ToString(Formatting.Indented);
        }

        private JObject ConstructRetryOptions() =>
            new JObject
            {
                { nameof(EventHubsRetryOptions.Mode), ClientRetryOptions.Mode.ToString() },
                { nameof(EventHubsRetryOptions.TryTimeout), ClientRetryOptions.TryTimeout },
                { nameof(EventHubsRetryOptions.Delay), ClientRetryOptions.Delay },
                { nameof(EventHubsRetryOptions.MaximumDelay), ClientRetryOptions.MaximumDelay },
                { nameof(EventHubsRetryOptions.MaximumRetries), ClientRetryOptions.MaximumRetries },
            };

        private JObject ConstructInitialOffsetOptions() =>
            new JObject
                {
                    { nameof(InitialOffsetOptions.Type), InitialOffsetOptions.Type.ToString() },
                    { nameof(InitialOffsetOptions.EnqueuedTimeUtc), InitialOffsetOptions.EnqueuedTimeUtc },
                };
    }
}
