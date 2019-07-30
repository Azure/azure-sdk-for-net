// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Creates instances of <see cref="IPartitionProcessor" />.
    /// </summary>
    ///
    /// <remarks>
    ///   An instance of a class implementing this interface is provided by the user in the <see cref="EventProcessor" />
    ///   constructor.
    /// </remarks>
    ///
    public interface IPartitionProcessorFactory
    {
        /// <summary>
        ///   Creates an instance of a class implementing the <see cref="IPartitionProcessor" /> interface.
        /// </summary>
        ///
        /// <param name="partitionContext">Contains information about the partition the <see cref="IPartitionProcessor" /> will be associated with.</param>
        /// <param name="checkpointManager">Passed to the <see cref="IPartitionProcessor" /> so it can create checkpoints when processing events.</param>
        ///
        /// <returns>A partition processor instance.</returns>
        ///
        public IPartitionProcessor CreatePartitionProcessor(PartitionContext partitionContext,
                                                            CheckpointManager checkpointManager);
    }
}
