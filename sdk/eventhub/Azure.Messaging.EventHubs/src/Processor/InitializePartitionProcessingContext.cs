// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains information about a partition that an <c>EventProcessorClient</c> will be
    ///   processing events from.  It can also be used to specify the position within a partition
    ///   where the associated <c>EventProcessorClient</c> should begin reading events in case
    ///   it cannot find a checkpoint.
    /// </summary>
    ///
    /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor" />
    ///
    public class InitializePartitionProcessingContext
    {
        /// <summary>
        ///   The context of the Event Hub partition this instance is associated with.
        /// </summary>
        ///
        public PartitionContext Context { get; }

        /// <summary>
        ///   The position within a partition where the associated <c>EventProcessorClient</c> should
        ///   begin reading events when no checkpoint can be found.
        /// </summary>
        ///
        public EventPosition DefaultStartingPosition { get; set; } = EventPosition.Earliest;

        /// <summary>
        ///   Initializes a new instance of the <see cref="InitializePartitionProcessingContext"/> class.
        /// </summary>
        ///
        /// <param name="partitionContext">The context of the Event Hub partition this instance is associated with.</param>
        ///
        protected internal InitializePartitionProcessingContext(PartitionContext partitionContext)
        {
            Argument.AssertNotNull(partitionContext, nameof(partitionContext));

            Context = partitionContext;
        }
    }
}
