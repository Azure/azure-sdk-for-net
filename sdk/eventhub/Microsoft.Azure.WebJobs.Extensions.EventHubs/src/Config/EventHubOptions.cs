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
            MaxEventBatchSize = 100;
            MinEventBatchSize = 1;
            MaxWaitTime = TimeSpan.FromSeconds(60);
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
        /// receive multiple events. Default 100.
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
        /// Gets or sets the minimum number of events desired for a batch. This setting applies only to functions that
        /// receive multiple events. This value must be less than <see cref="MaxEventBatchSize"/> and is used in
        /// conjunction with <see cref="MaxWaitTime"/>. Default 1.
        /// </summary>
        /// <remarks>
        /// The minimum size is not a strict guarantee, as a partial batch will be dispatched if a full batch cannot be
        /// prepared before the <see cref="MaxWaitTime"/> has elapsed.  Partial batches are also likely for the first invocation
        /// of the function after scaling takes place.
        /// </remarks>
        public int MinEventBatchSize
        {
            get => _minEventBatchSize;

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Batch size must be larger than or equal to 1.");
                }
                _minEventBatchSize = value;
            }
        }

        private TimeSpan _maxWaitTime;

        /// <summary>
        /// Gets or sets the maximum time that the trigger should wait to fill a batch before invoking the function.
        /// This is only considered when <see cref="MinEventBatchSize"/> is set to larger than 1 and is otherwise unused.
        /// If less than <see cref="MinEventBatchSize" /> events were available before the wait time elapses, the function
        /// will be invoked with a partial batch.  Default is 60 seconds.  The longest allowed wait time is 10 minutes.
        /// </summary>
        /// <remarks>
        /// This interval is not a strict guarantee for the exact timing on which the function will be invoked. There is a small
        /// margin of error due to timer precision. When scaling takes place, the first invocation with a partial
        /// batch may take place more quickly or may take up to twice the configured <see cref="MaxWaitTime"/>.
        /// </remarks>
        public TimeSpan MaxWaitTime
        {
            get => _maxWaitTime;

            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentException("Max Wait Time must be larger than or equal to 0.");
                }
                if (value > TimeSpan.FromMinutes(10))
                {
                    throw new ArgumentException("Max Wait Time must be less than or equal to 10 minutes.");
                }
                _maxWaitTime = value;
            }
        }

        private int? _targetUnprocessedEventThreshold;

        /// <summary>
        /// Get or sets the target number of unprocessed events per worker for Event Hub-triggered functions. This is used in target-based scaling to override the default scaling threshold inferred from the <see cref="MaxEventBatchSize" /> option.
        ///
        /// If TargetUnprocessedEventThreshold is set, the total unprocessed event count will be divided by this value to determine the number of worker instances, which will then be rounded up to a worker instance count that creates a balanced partition distribution.
        /// </summary>
        public int? TargetUnprocessedEventThreshold
        {
            get => _targetUnprocessedEventThreshold;

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Unprocessed Event Threshold must be larger than 0.");
                }
                _targetUnprocessedEventThreshold = value;
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
                    { nameof(TargetUnprocessedEventThreshold), TargetUnprocessedEventThreshold },
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
