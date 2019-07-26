// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public class PartitionOwnership
    {
        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public string InstanceId { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   TODO. (validate value)
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
        ///   TODO. (datetimeoffset?) (LastEnqueuedTime?)
        /// </summary>
        ///
        public long? LastModifiedTime { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public string ETag { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
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
