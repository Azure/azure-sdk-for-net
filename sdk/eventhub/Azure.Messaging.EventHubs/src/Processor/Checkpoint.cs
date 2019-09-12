// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains the information to reflect the state of event processing for a given Event Hub partition.
    /// </summary>
    ///
    public class Checkpoint
    {
        /// <summary>
        ///   The name of the specific Event Hub this checkpoint is associated with, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group this checkpoint is associated with.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   The identifier of the associated <see cref="EventProcessor{T}" /> instance.
        /// </summary>
        ///
        public string OwnerIdentifier { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition this checkpoint is associated with.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The offset of the <see cref="EventData" /> this checkpoint is associated with.
        /// </summary>
        ///
        public long Offset { get; }

        /// <summary>
        ///   The sequence number assigned to the <see cref="EventData" /> this checkpoint is associated with.
        /// </summary>
        ///
        public long SequenceNumber { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="Checkpoint"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the specific Event Hub this checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this checkpoint is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor{T}" /> instance.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this checkpoint is associated with.</param>
        /// <param name="offset">The offset of the <see cref="EventData" /> this checkpoint is associated with.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the <see cref="EventData" /> this checkpoint is associated with.</param>
        ///
        protected internal Checkpoint(string eventHubName,
                                      string consumerGroup,
                                      string ownerIdentifier,
                                      string partitionId,
                                      long offset,
                                      long sequenceNumber)
        {
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(ownerIdentifier, nameof(ownerIdentifier));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertAtLeast(offset, 0, nameof(offset));
            Argument.AssertAtLeast(sequenceNumber, 0, nameof(sequenceNumber));

            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            OwnerIdentifier = ownerIdentifier;
            PartitionId = partitionId;
            Offset = offset;
            SequenceNumber = sequenceNumber;
        }
    }
}
