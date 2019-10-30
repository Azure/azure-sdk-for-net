// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

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
        ///   The fully qualified Event Hubs namespace this partition ownership is associated with.  This
        ///   is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; }

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
        ///   The identifier of the associated <see cref="EventProcessorClient" /> instance.
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
        ///   The offset of the last <see cref="EventData" /> received by the associated partition processor
        ///   upon ownership update.
        /// </summary>
        ///
        public long? Offset { get; set; }

        /// <summary>
        ///   The sequence number of the last <see cref="EventData" /> received by the associated partition processor
        ///   upon ownership update.
        /// </summary>
        ///
        public long? SequenceNumber { get; set; }

        /// <summary>
        ///   The date and time, in UTC, that the last update was made to this ownership.
        /// </summary>
        ///
        public DateTimeOffset? LastModifiedTime { get; set; }

        /// <summary>
        ///   The entity tag needed to update this ownership.
        /// </summary>
        ///
        public string ETag { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionOwnership"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this partition ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub this partition ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this partition ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessorClient" /> instance.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this partition ownership is associated with.</param>
        /// <param name="offset">The offset of the last <see cref="EventData" /> received by the associated partition processor.</param>
        /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> received by the associated partition processor.</param>
        /// <param name="lastModifiedTime">The date and time, in UTC, that the last update was made to this ownership.</param>
        /// <param name="eTag">The entity tag needed to update this ownership.</param>
        ///
        protected internal PartitionOwnership(string fullyQualifiedNamespace,
                                              string eventHubName,
                                              string consumerGroup,
                                              string ownerIdentifier,
                                              string partitionId,
                                              long? offset = null,
                                              long? sequenceNumber = null,
                                              DateTimeOffset? lastModifiedTime = null,
                                              string eTag = null)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(ownerIdentifier, nameof(ownerIdentifier));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));

            if (offset.HasValue)
            {
                Argument.AssertAtLeast(offset.Value, 0, nameof(offset));
            }

            if (sequenceNumber.HasValue)
            {
                Argument.AssertAtLeast(sequenceNumber.Value, 0, nameof(sequenceNumber));
            }

            FullyQualifiedNamespace = fullyQualifiedNamespace;
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
