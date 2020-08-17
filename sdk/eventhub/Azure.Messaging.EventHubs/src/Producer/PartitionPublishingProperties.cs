// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   A set of information for an Event Hub.
    /// </summary>
    ///
    public class PartitionPublishingProperties
    {
        /// <summary>
        ///   Indicates whether or not idempotent publishing is enabled for the producer and, by extension, the associated partition.
        /// </summary>
        ///
        /// <value><c>true</c> if the idempotent publishing is enabled; otherwise, <c>false</c>.</value>
        ///
        public bool IsIdempotentPublishingEnabled { get; }

        /// <summary>
        ///   The identifier of the producer group for which this producer is publishing to the associated partition.
        /// </summary>
        ///
        public long? ProducerGroupId  { get; set; }

        /// <summary>
        ///   The owner level of this producer for publishing to the associated partition.
        /// </summary>
        ///
        public short? OwnerLevel { get; set; }

        /// <summary>
        ///   The sequence number assigned to the event that was most recently published to the associated partition
        ///   successfully.
        /// </summary>
        ///
        public int? LastPublishedSequenceNumber   { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubProperties"/> class.
        /// </summary>
        ///
        /// <param name="isIdempotentPublishingEnabled">Indicates whether idempotent publishing is enabled.</param>
        /// <param name="producerGroupId">The identifier of the producer group associated with the partition.</param>
        /// <param name="ownerLevel">The owner level associated with the partition.</param>
        /// <param name="lastPublishedSequenceNumber">The sequence number assigned to the event that was last successfully published to the partition.</param>
        ///
        protected internal PartitionPublishingProperties(bool isIdempotentPublishingEnabled,
                                                         long? producerGroupId,
                                                         short? ownerLevel,
                                                         int? lastPublishedSequenceNumber) =>
            (IsIdempotentPublishingEnabled, ProducerGroupId, OwnerLevel, LastPublishedSequenceNumber) = (isIdempotentPublishingEnabled, producerGroupId, ownerLevel, lastPublishedSequenceNumber);
    }
}
