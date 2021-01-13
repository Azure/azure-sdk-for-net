// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   The set of options that can be specified for an <see cref="EventHubProducerClient" />
    ///   to influence its behavior when publishing directly to an Event Hub partition.
    /// </summary>
    ///
    /// <remarks>
    ///   These options are ignored when publishing to the Event Hubs gateway for automatic
    ///   routing or when using a partition key.
    /// </remarks>
    ///
    public class PartitionPublishingOptions
    {
        /// <summary>
        ///   The identifier of the producer group that this producer is associated with when publishing to the associated partition.
        ///   Events will be published in the context of this group.
        /// </summary>
        ///
        /// <value>The identifier of the producer group to associate with the partition; if <c>null</c>, the Event Hubs service will control the value.</value>
        ///
        /// <remarks>
        ///   The producer group is only recognized and relevant when certain features of the producer are enabled.  For example, it is used by
        ///   idempotent publishing.
        /// </remarks>
        ///
        /// <seealso cref="EventHubProducerClientOptions.EnableIdempotentPartitions" />
        ///
        public long? ProducerGroupId  { get; set; }

        /// <summary>
        ///   The owner level indicates that a publishing is intended to be performed exclusively for events in the
        ///   requested partition in the context of the associated producer group.  To do so, publishing will attempt to assert ownership
        ///   over the partition; in the case where more than one publisher in the producer group attempts to assert ownership for the same
        ///   partition, the one having a larger <see cref="OwnerLevel"/> value will "win".
        ///
        ///   <para>When an owner level is specified, other exclusive publishers which have a lower owner level within the context of the same producer
        ///   group will either not be allowed to be created or, if they already exist, will encounter an exception during the next attempted operation.  Should
        ///   there be multiple producers in the producer group with the same owner level, each of them will be able to publish to the partition.</para>
        ///
        ///   <para>Producers with no owner level or which belong to a different producer group are permitted to publish to the associated partition without
        /// restriction or awareness of other exclusive producers.</para>
        /// </summary>
        ///
        /// <value>The relative priority to associate with an exclusive publisher; if <c>null</c>, the Event Hubs service will control the value.</value>
        ///
        /// <remarks>
        ///   The owner level is only recognized and relevant when certain features of the producer are enabled.  For example, it is used by
        ///   idempotent publishing.
        ///
        ///   <para>An <see cref="EventHubsException"/> will occur if an <see cref="EventHubProducerClient"/> is unable to read events from the
        ///   requested Event Hub partition for the given consumer group.  In this case, the <see cref="EventHubsException.FailureReason"/>
        ///   will be set to <see cref="EventHubsException.FailureReason.ProducerDisconnected"/>.</para>
        /// </remarks>
        ///
        /// <seealso cref="EventHubsException" />
        /// <seealso cref="EventHubsException.FailureReason.ProducerDisconnected" />
        /// <seealso cref="EventHubProducerClientOptions.EnableIdempotentPartitions" />
        ///
        public short? OwnerLevel { get; set; }

        /// <summary>
        ///   The starting number that should be used for the automatic sequencing of events for the associated partition, when published by this producer.
        /// </summary>
        ///
        /// <value>
        ///     <para>The starting sequence number to associate with the partition; if <c>null</c>, the Event Hubs service will control the value.</para>
        ///
        ///     <para>The sequence number will be in the range of <c>0</c> - <see cref="int.MaxValue"/> (inclusive) and will increase as events are published.
        ///     When more than <see cref="int.MaxValue" /> events have been published, the sequence number will roll over to <c>0</c>.</para>
        /// </value>
        ///
        /// <remarks>
        ///   The starting sequence number is only recognized and relevant when certain features of the producer are enabled.  For example, it is used by
        ///   idempotent publishing.
        /// </remarks>
        ///
        /// <seealso cref="EventHubProducerClientOptions.EnableIdempotentPartitions" />
        ///
        public int? StartingSequenceNumber { get; set; }

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
        ///   Creates a new copy of the current <see cref="PartitionPublishingOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="PartitionPublishingOptions" />.</returns>
        ///
        internal PartitionPublishingOptions Clone() =>
            new PartitionPublishingOptions
            {
                ProducerGroupId = ProducerGroupId,
                OwnerLevel = OwnerLevel,
                StartingSequenceNumber = StartingSequenceNumber
            };
    }
}
