// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public class Checkpoint
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
        ///   TODO.
        /// </summary>
        ///
        public long Offset { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public long SequenceNumber { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public Checkpoint(string eventHubName,
                          string consumerGroup,
                          string instanceId,
                          string partitionId,
                          long offset,
                          long sequenceNumber)
        {
            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            InstanceId = instanceId;
            PartitionId = partitionId;
            Offset = offset;
            SequenceNumber = sequenceNumber;
        }
    }
}
