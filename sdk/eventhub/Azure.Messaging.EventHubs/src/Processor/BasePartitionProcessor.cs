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
    ///   will be created by the associated <see cref="EventProcessor" /> for every partition it owns.  This class does
    ///   not perform any kind of processing by itself and a useful partition processor is expected to be derived from it.
    /// </summary>
    ///
    public abstract class BasePartitionProcessor
    {
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
    }
}
