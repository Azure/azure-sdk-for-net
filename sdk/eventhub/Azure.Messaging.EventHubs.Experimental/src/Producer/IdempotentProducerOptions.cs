// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="IdempotentProducer" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class IdempotentProducerOptions : EventHubProducerClientOptions
    {
        /// <summary>
        ///   Indicates whether or not the producer should enable idempotent publishing to the Event Hub partitions.  If
        ///   enabled, the producer will only be able to publish directly to partitions; it will not be able to publish to
        ///   the Event Hubs gateway for automatic partition routing nor using a partition key.
        /// </summary>
        ///
        /// <value><c>true</c> if the producer should enable idempotent partition publishing; otherwise, <c>false</c>.</value>
        ///
        public new bool EnableIdempotentPartitions
        {
            get => base.EnableIdempotentPartitions;
            set => base.EnableIdempotentPartitions = value;
        }

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
        public new Dictionary<string, PartitionPublishingOptions> PartitionOptions => base.PartitionOptions;
    }
}
