// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO. (constructor)
    /// </summary>
    ///
    public class PartitionOwnership
    {
        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   TODO. (EventHubPath?)
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   TODO. (ConsumerGroup?)
        /// </summary>
        ///
        public string ConsumerGroupName { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public string InstanceId { get; }

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
        ///   TODO. (datetimeoffset?) (LastEnqueuedTime?)
        /// </summary>
        ///
        public long? LastModifiedTime { get; }

        /// <summary>
        ///   TODO. (nullable?)
        /// </summary>
        ///
        public string ETag { get; }
    }
}
