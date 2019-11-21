// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains information about a partition that an <see cref="EventProcessorClient" /> will be
    ///   processing events from.  It can also be used to specify the position within a partition
    ///   where the associated <see cref="EventProcessorClient" /> should begin reading events in case
    ///   it cannot find a checkpoint.
    /// </summary>
    ///
    public class PartitionInitializingEventArgs
    {
        /// <summary>
        ///   The context of the Event Hub partition this instance is associated with.
        /// </summary>
        ///
        public PartitionContext Partition { get; }

        /// <summary>
        ///   The position within a partition where the associated <see cref="EventProcessorClient" /> should
        ///   begin reading events when no checkpoint can be found.
        /// </summary>
        ///
        public EventPosition DefaultStartingPosition { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionInitializingEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="partition">The context of the Event Hub partition this instance is associated with.</param>
        /// <param name="defaultStartingPosition">The position within a partition where the associated <see cref="EventProcessorClient" /> should begin reading events when no checkpoint can be found.</param>
        ///
        protected internal PartitionInitializingEventArgs(PartitionContext partition,
                                                          EventPosition defaultStartingPosition)
        {
            Argument.AssertNotNull(partition, nameof(partition));

            Partition = partition;
            DefaultStartingPosition = defaultStartingPosition;
        }
    }
}
