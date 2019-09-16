// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains the information to reflect the state of event processing for a given Event Hub partition.
    /// </summary>
    ///
    public class Checkpoint
    {
        /// <summary>
        ///   The fully qualified host name for the Event Hubs namespace this checkpoint is
        ///   associated with.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; }

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
        /// <param name="fullyQualifiedNamespace">The fully qualified host name for the Event Hubs namespace this checkpoint is associated with.</param>
        /// <param name="eventHubName">The name of the specific Event Hub this checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this checkpoint is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor{T}" /> instance.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this checkpoint is associated with.</param>
        /// <param name="offset">The offset of the <see cref="EventData" /> this checkpoint is associated with.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the <see cref="EventData" /> this checkpoint is associated with.</param>
        ///
        protected internal Checkpoint(string fullyQualifiedNamespace,
                                      string eventHubName,
                                      string consumerGroup,
                                      string ownerIdentifier,
                                      string partitionId,
                                      long offset,
                                      long sequenceNumber)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(fullyQualifiedNamespace), fullyQualifiedNamespace);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubName), eventHubName);
            Guard.ArgumentNotNullOrEmpty(nameof(consumerGroup), consumerGroup);
            Guard.ArgumentNotNullOrEmpty(nameof(ownerIdentifier), ownerIdentifier);
            Guard.ArgumentNotNullOrEmpty(nameof(partitionId), partitionId);
            Guard.ArgumentAtLeast(nameof(offset), offset, 0);
            Guard.ArgumentAtLeast(nameof(sequenceNumber), sequenceNumber, 0);

            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            OwnerIdentifier = ownerIdentifier;
            PartitionId = partitionId;
            Offset = offset;
            SequenceNumber = sequenceNumber;
        }
    }
}
