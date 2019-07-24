// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO. (create constructor?)
    /// </summary>
    ///
    public class Checkpoint
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
        public long Offset { get; }

        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public long SequenceNumber { get; }
    }
}
