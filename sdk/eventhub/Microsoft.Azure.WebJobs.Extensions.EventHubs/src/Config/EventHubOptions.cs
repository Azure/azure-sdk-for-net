// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
            MaxBatchSize = 10;
            EventProcessorOptions = new EventProcessorOptions()
            {
                TrackLastEnqueuedEventProperties = false,
                MaximumWaitTime = TimeSpan.FromMinutes(1),
                LoadBalancingStrategy = LoadBalancingStrategy.Greedy,
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
        /// Gets or sets a value indication whether a single-dispatch trigger bindings are enabled.
        /// </summary>
        internal bool IsSingleDispatchEnabled { get; set; }

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
                    { nameof(MaxBatchSize), MaxBatchSize },
                    { nameof(BatchCheckpointFrequency), BatchCheckpointFrequency },
                    { nameof(ConnectionOptions), ConstructConnectionOptions() },
                    { nameof(ClientRetryOptions), ConstructRetryOptions() },
                    { nameof(TrackLastEnqueuedEventProperties), TrackLastEnqueuedEventProperties },
                    { nameof(PrefetchCount), PrefetchCount },
                    { nameof(PrefetchSizeInBytes), PrefetchSizeInBytes },
                    { nameof(PartitionOwnershipExpirationInterval), PartitionOwnershipExpirationInterval },
                    { nameof(LoadBalancingUpdateInterval), LoadBalancingUpdateInterval },
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
