// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains all the information needed to describe the status of the owner of a partition.  It's used by
    ///   <see cref="IPartitionManager" /> to claim ownership of a partition and to list existing ownership.
    /// </summary>
    ///
    public class PartitionOwnership
    {
        /// <summary>
        ///   The path of the specific Event Hub this partition ownership is associated with, relative
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
        public string InstanceId { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition this partition ownership is associated with.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public long OwnerLevel { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public long? Offset { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public long? SequenceNumber { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public long? LastModifiedTime { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public string ETag { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionOwnership"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The path of the specific Event Hub this partition ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this partition ownership is associated with.</param>
        /// <param name="instanceId">The identifier of the associated <see cref="EventProcessor" /> instance.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition this partition ownership is associated with.</param>
        /// <param name="ownerLevel">TODO.</param>
        /// <param name="offset">TODO.</param>
        /// <param name="sequenceNumber">TODO.</param>
        /// <param name="lastModifiedTime">TODO.</param>
        /// <param name="eTag">TODO.</param>
        ///
        public PartitionOwnership(string eventHubName,
                                  string consumerGroup,
                                  string instanceId,
                                  string partitionId,
                                  long ownerLevel,
                                  long? offset = null,
                                  long? sequenceNumber = null,
                                  long? lastModifiedTime = null,
                                  string eTag = null)
        {
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            InstanceId = instanceId;
            PartitionId = partitionId;
            OwnerLevel = ownerLevel;
            Offset = offset;
            SequenceNumber = sequenceNumber;
            LastModifiedTime = lastModifiedTime;
            ETag = eTag;
        }
    }
}
