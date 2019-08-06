// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains all the information needed to describe the status of the owner of a partition.  It's used by
    ///   <see cref="PartitionManager" /> to claim ownership of a partition and to list existing ownership.
    /// </summary>
    ///
    public class PartitionOwnership
    {
        /// <summary>
        ///   The name of the specific Event Hub this partition ownership is associated with, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group this partition ownership is associated with.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   The identifier of the associated <see cref="EventProcessor" /> instance.
        /// </summary>
        ///
        public string OwnerIdentifier { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition this partition ownership is associated with.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   TODO: purpose not clear yet.
        /// </summary>
        ///
        internal long OwnerLevel { get; }

        /// <summary>
        ///   The offset of the last <see cref="EventData" /> received by the associated <see cref="IPartitionProcessor" />
        ///   upon ownership update.
        /// </summary>
        ///
        public long? Offset { get; }

        /// <summary>
        ///   The sequence number of the last <see cref="EventData" /> received by the associated <see cref="IPartitionProcessor" />
        ///   upon ownership update.
        /// </summary>
        ///
        public long? SequenceNumber { get; }

        /// <summary>
        ///   The date and time, in UTC, that the last update was made to this ownership.
        /// </summary>
        ///
        public DateTimeOffset? LastModifiedTime { get; }

        /// <summary>
        ///   The entity tag needed to update this ownership.
        /// </summary>
        ///
        public string ETag { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionOwnership"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the specific Event Hub this partition ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this partition ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor" /> instance.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this partition ownership is associated with.</param>
        /// <param name="offset">The offset of the last <see cref="EventData" /> received by the associated <see cref="IPartitionProcessor" />.</param>
        /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> received by the associated <see cref="IPartitionProcessor" />.</param>
        /// <param name="lastModifiedTime">The date and time, in UTC, that the last update was made to this ownership.</param>
        /// <param name="eTag">The entity tag needed to update this ownership.</param>
        ///
        internal PartitionOwnership(string eventHubName,
                                    string consumerGroup,
                                    string ownerIdentifier,
                                    string partitionId,
                                    long? offset = null,
                                    long? sequenceNumber = null,
                                    DateTimeOffset? lastModifiedTime = null,
                                    string eTag = null)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubName), eventHubName);
            Guard.ArgumentNotNullOrEmpty(nameof(consumerGroup), consumerGroup);
            Guard.ArgumentNotNullOrEmpty(nameof(ownerIdentifier), ownerIdentifier);
            Guard.ArgumentNotNullOrEmpty(nameof(partitionId), partitionId);

            if (offset.HasValue)
            {
                Guard.ArgumentInRange(nameof(offset), offset.Value, 0, Int64.MaxValue);
            }

            if (sequenceNumber.HasValue)
            {
                Guard.ArgumentInRange(nameof(sequenceNumber), sequenceNumber.Value, 0, Int64.MaxValue);
            }

            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            OwnerIdentifier = ownerIdentifier;
            PartitionId = partitionId;
            Offset = offset;
            SequenceNumber = sequenceNumber;
            LastModifiedTime = lastModifiedTime;
            ETag = eTag;
        }
    }
}
