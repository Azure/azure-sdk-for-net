// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Processes events received from the Azure Event Hubs service.  An instance of this class or of a derived class
    ///   will be created by the associated <see cref="EventProcessor{T}" /> for every partition it owns.  This class does
    ///   not perform any kind of processing by itself and a useful partition processor is expected to be derived from it.
    /// </summary>
    ///
    public class BasePartitionProcessor
    {
        /// <summary>
        ///   Initializes the partition processor.
        /// </summary>
        ///
        /// <param name="partitionContext">Contains information about the partition from which events are sourced and provides a means of creating checkpoints for that partition.</param>
        /// 
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task InitializeAsync(PartitionContext partitionContext)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///   Closes the partition processor.
        /// </summary>
        ///
        /// <param name="partitionContext">Contains information about the partition from which events are sourced and provides a means of creating checkpoints for that partition.</param>
        /// <param name="reason">The reason why the partition processor is being closed.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task CloseAsync(PartitionContext partitionContext,
                                       PartitionProcessorCloseReason reason)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///   Processes a set of received <see cref="EventData" />.
        /// </summary>
        ///
        /// <param name="partitionContext">Contains information about the partition from which events are sourced and provides a means of creating checkpoints for that partition.</param>
        /// <param name="events">The received events to be processed.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task ProcessEventsAsync(PartitionContext partitionContext,
                                               IEnumerable<EventData> events,
                                               CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///   Processes an unexpected exception thrown while the associated <see cref="EventProcessor{T}" /> is running.
        /// </summary>
        ///
        /// <param name="partitionContext">Contains information about the partition from which events are sourced and provides a means of creating checkpoints for that partition.</param>
        /// <param name="exception">The exception to be processed.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task ProcessErrorAsync(PartitionContext partitionContext,
                                              Exception exception,
                                              CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
