// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventHubProducerClient" />
    ///   to configure its behavior.
    /// </summary>
    ///
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples">Event Hubs samples and discussion</seealso>
    ///
    public class EventHubProducerClientOptions
    {
        /// <summary>The set of options to use for configuring the connection to the Event Hubs service.</summary>
        private EventHubConnectionOptions _connectionOptions = new EventHubConnectionOptions();

        /// <summary>The set of options to govern retry behavior and try timeouts.</summary>
        private EventHubsRetryOptions _retryOptions = new EventHubsRetryOptions();

        /// <summary>
        ///   A unique name used to identify the consumer.  If <c>null</c> or empty, a GUID will be used as the
        ///   identifier.
        /// </summary>
        ///
        /// <value>If not specified, a random unique identifier will be generated.</value>
        ///
        public string Identifier { get; set; }

        /// <summary>
        ///   The options used for configuring the connection to the Event Hubs service.
        /// </summary>
        ///
        public EventHubConnectionOptions ConnectionOptions
        {
            get => _connectionOptions;
            set
            {
                Argument.AssertNotNull(value, nameof(ConnectionOptions));
                _connectionOptions = value;
            }
        }

        /// <summary>
        ///   The set of options to use for determining whether a failed operation should be retried and,
        ///   if so, the amount of time to wait between retry attempts.  These options also control the
        ///   amount of time allowed for publishing events and other interactions with the Event Hubs service.
        /// </summary>
        ///
        public EventHubsRetryOptions RetryOptions
        {
            get => _retryOptions;
            set
            {
                Argument.AssertNotNull(value, nameof(RetryOptions));
                _retryOptions = value;
            }
        }

        /// <summary>
        ///   Indicates whether or not the producer should enable idempotent publishing to the Event Hub partitions.  If
        ///   enabled, the producer will only be able to publish directly to partitions; it will not be able to publish to
        ///   the Event Hubs gateway for automatic partition routing nor using a partition key.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the producer should enable idempotent partition publishing; otherwise, <c>false</c>.  Idempotent partitions
        ///   are disabled by default.
        /// </value>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal bool EnableIdempotentPartitions { get; set; }

        /// <summary>
        ///   The set of options that can be specified to influence publishing behavior specific to the configured Event Hub partition.  These
        ///   options are not necessary in the majority of scenarios and are intended for use with specialized scenarios, such as when
        ///   recovering the state used for idempotent publishing.
        ///
        ///   <para>It is highly recommended that these options only be specified if there is a proven need to do so; Incorrectly configuring these
        ///   values may result in an <see cref="EventHubProducerClient" /> instance that is unable to publish to the Event Hubs.</para>
        /// </summary>
        ///
        /// <value>The default partition options are an empty set.</value>
        ///
        /// <remarks>
        ///   These options are ignored when publishing to the Event Hubs gateway for automatic routing or when using a partition key.
        /// </remarks>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal Dictionary<string, PartitionPublishingOptions> PartitionOptions { get; } = new Dictionary<string, PartitionPublishingOptions>();

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///   Creates a new copy of the current <see cref="EventHubProducerClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventHubProducerClientOptions" />.</returns>
        ///
        internal EventHubProducerClientOptions Clone()
        {
            var copiedOptions = new EventHubProducerClientOptions
            {
                Identifier = Identifier,
                EnableIdempotentPartitions = EnableIdempotentPartitions,
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone()
            };

            foreach (var pair in PartitionOptions)
            {
                copiedOptions.PartitionOptions.Add(pair.Key, pair.Value.Clone());
            }

            return copiedOptions;
        }

        /// <summary>
        ///   Creates the set of flags that represents the features requested by these options.
        /// </summary>
        ///
        /// <returns>The set of features that were requested for the <see cref="EventHubProducerClient" />.</returns>
        ///
        internal TransportProducerFeatures CreateFeatureFlags()
        {
            var features = TransportProducerFeatures.None;

            if (EnableIdempotentPartitions)
            {
                features |= TransportProducerFeatures.IdempotentPublishing;
            }

            return features;
        }

        /// <summary>
        ///   Attempts to retrieve the publishing options for a given partition, returning a
        ///   default in the case that no partition was specified or there were no available options
        ///   for that partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition for which options are requested.</param>
        ///
        /// <returns><c>null</c> in the event that there was no partition specified or no options for the partition; otherwise, the publishing options.</returns>
        ///
        internal PartitionPublishingOptions GetPublishingOptionsOrDefaultForPartition(string partitionId)
        {
            if (string.IsNullOrEmpty(partitionId))
            {
                return default;
            }

            PartitionOptions.TryGetValue(partitionId, out var options);
            return options;
        }
    }
}
