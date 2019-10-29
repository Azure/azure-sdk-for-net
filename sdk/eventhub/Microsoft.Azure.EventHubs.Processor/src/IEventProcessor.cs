// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that must be implemented by event processor classes.
    /// 
    /// <para>Any given instance of an event processor class will only process events from one partition
    /// of one Event Hub. A PartitionContext is provided with each call to the event processor because
    /// some parameters could change, but it will always be the same partition.</para>
    /// 
    /// <para>Although EventProcessorHost is multithreaded, calls to a given instance of an event processor
    /// class are serialized, except for OnError(). OnOpen() is called first, then OnEvents() will be called zero or more
    /// times. When the event processor needs to be shut down, whether because there was a failure
    /// somewhere, or the lease for the partition has been lost, or because the entire processor host
    /// is being shut down, OnClose() is called after the last OnEvents() call returns.</para>
    /// 
    /// <para>OnError() could be called while OnEvents() or OnClose() is executing. No synchronization is attempted
    /// in order to avoid possibly deadlocking.</para>
    /// </summary>
    public interface IEventProcessor
    {
        /// <summary>
        /// Called by processor host to initialize the event processor.
        /// </summary>
        /// <param name="context">Information about the partition that this event processor will process events from.</param>
        Task OpenAsync(PartitionContext context);

        /// <summary>
        /// Called by processor host to indicate that the event processor is being stopped.
        /// </summary>
        /// <param name="context">Information about the partition.</param>
        /// <param name="reason">Reason why the event processor is being stopped.</param>
        Task CloseAsync(PartitionContext context, CloseReason reason);

        /// <summary>
        /// Called by the processor host when a batch of events has arrived.
        /// <para>This is where the real work of the event processor is done.</para>
        /// </summary>
        /// <param name="context">Information about the partition.</param>
        /// <param name="messages">The events to be processed.</param>
        Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages);

        /// <summary>
        /// Called when the underlying client experiences an error while receiving. EventProcessorHost will take
        /// care of recovering from the error and continuing to pump messages, so no action is required from
        /// your code. This method is provided for informational purposes.
        /// </summary>
        /// <param name="context">Information about the partition.</param>
        /// <param name="error">The error that occured.</param>
        Task ProcessErrorAsync(PartitionContext context, Exception error);
    }
}