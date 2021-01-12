// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   A set of information for an Event Hub.
    /// </summary>
    ///
    public class PartitionPublishingProperties
    {
        /// <summary>An empty set of properties.</summary>
        private static PartitionPublishingProperties s_emptyInstance;

        /// <summary>
        ///   Returns a set of properties that represents an empty set of properties
        ///   suitable for use when partitions are not inherently stateful.
        /// </summary>
        ///
        internal static PartitionPublishingProperties Empty
        {
            get
            {
                // The race condition here is benign; because the resulting properties
                // are not mutable, there is not impact to having the reference updated after
                // initial creation.

                s_emptyInstance ??= new PartitionPublishingProperties(false, null, null, null);
                return s_emptyInstance;
            }
        }

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
        public long? ProducerGroupId  { get; }

        /// <summary>
        ///   The owner level of the producer publishing to the associated partition.
        /// </summary>
        ///
        public short? OwnerLevel { get; }

        /// <summary>
        ///   The sequence number assigned to the event that was most recently published to the associated partition
        ///   successfully.
        /// </summary>
        ///
        /// <value>
        ///   The sequence number will be in the range of <c>0</c> - <see cref="int.MaxValue"/> (inclusive) and will
        ///   increase as events are published.  When more than <see cref="int.MaxValue" /> events have been published,
        ///   the sequence number will roll over to <c>0</c>.
        /// </value>
        ///
        public int? LastPublishedSequenceNumber { get; }

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
