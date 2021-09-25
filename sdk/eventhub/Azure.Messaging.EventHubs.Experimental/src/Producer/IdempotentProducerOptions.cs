// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="IdempotentProducer" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class IdempotentProducerOptions
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
        public string Identifier { get; set; }

        /// <summary>
        ///   Indicates whether or not the producer should enable idempotent publishing to the Event Hub partitions.  If
        ///   enabled, the producer will only be able to publish directly to partitions; it will not be able to publish to
        ///   the Event Hubs gateway for automatic partition routing nor using a partition key.
        /// </summary>
        ///
        /// <value><c>true</c> if the producer should enable idempotent partition publishing; otherwise, <c>false</c>.</value>
        ///
        public bool EnableIdempotentPartitions { get; set; }

        /// <summary>
        ///   The set of options that can be specified to influence publishing behavior specific to the configured Event Hub partition.  These
        ///   options are not necessary in the majority of scenarios and are intended for use with specialized scenarios, such as when
        ///   recovering the state used for idempotent publishing.
        ///
        ///   <para>It is highly recommended that these options only be specified if there is a proven need to do so; Incorrectly configuring these
        ///   values may result in an <see cref="EventHubProducerClient" /> instance that is unable to publish to the Event Hubs.</para>
        /// </summary>
        ///
        /// <remarks>
        ///   These options are ignored when publishing to the Event Hubs gateway for automatic routing or when using a partition key.
        /// </remarks>
        ///
        public Dictionary<string, PartitionPublishingOptions> PartitionOptions { get; } = new Dictionary<string, PartitionPublishingOptions>();

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
        internal EventHubProducerClientOptions ToCoreOptions()
        {
            var copiedOptions = new EventHubProducerClientOptions
            {
                Identifier = Identifier,
                EnableIdempotentPartitions = EnableIdempotentPartitions,
                ConnectionOptions = ConnectionOptions,
                RetryOptions = RetryOptions,
            };

            foreach (var pair in PartitionOptions)
            {
                copiedOptions.PartitionOptions.Add(pair.Key, pair.Value.ToCoreOptions());
            }

            return copiedOptions;
        }
    }
}
