// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   The set of state associated with stateful publishing to a partition, such as when
    ///   idempotency is enabled.
    /// </summary>
    ///
    internal class PartitionPublishingState
    {
        /// <summary>
        ///   The identifier of the partition whose state is represented.
        /// </summary>
        ///
        /// <remarks>
        ///   This class is not intended to be used with its <see cref="PublishingGuard" />
        ///   for synchronizing access; it does not provide any inherent thread safety guarantees.
        /// </remarks>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   Indicates whether or not the state has been initialized.
        /// </summary>
        ///
        /// <value><c>true</c> if this instance is initialized; otherwise, <c>false</c>.</value>
        ///
        public bool IsInitialized => (ProducerGroupId.HasValue && OwnerLevel.HasValue && LastPublishedSequenceNumber.HasValue);

        /// <summary>
        ///   The primitive for synchronizing access for publishing to the partition.
        /// </summary>
        ///
        public SemaphoreSlim PublishingGuard { get; } = new SemaphoreSlim(1, 1);

        /// <summary>
        ///   The identifier of the producer group for which publishing is being performed.
        /// </summary>
        ///
        public long? ProducerGroupId  { get; set; }

        /// <summary>
        ///   The owner level for which publishing is being performed.
        /// </summary>
        ///
        public short? OwnerLevel { get; set; }

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
        public int? LastPublishedSequenceNumber { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionPublishingState"/> class.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition whose state is represented.</param>
        ///
        public PartitionPublishingState(string partitionId) => PartitionId = partitionId;
    }
}
