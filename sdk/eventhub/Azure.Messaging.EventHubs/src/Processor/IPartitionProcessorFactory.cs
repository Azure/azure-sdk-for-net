// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   TODO.
    /// </summary>
    ///
    public interface IPartitionProcessorFactory
    {
        /// <summary>
        ///   TODO.
        /// </summary>
        ///
        public IPartitionProcessor CreateEventProcessor(PartitionContext partitionContext,
                                                        CheckpointManager checkpointManager);
    }
}
