// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A sender responsible for transmitting <see cref="EventData" /> to a specific Event Hub,
    ///   indendepently or grouped together as a single batch.  Data may be sent to a specific
    ///   partition or allowed to be automatically routed to an available partition.
    /// </summary>
    ///
    public class EventSender
    {
        /// <summary>The maximum allowable size, in bytes, for a batch to be sent.</summary>
        internal const int MinimumBatchSizeLimit = 24;

        /// <summary>The maximum allowable size, in bytes, for a batch to be sent.</summary>
        internal const int MaximumBatchSizeLimit = 4 * 1024 * 1024;

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventSender"/> class.
        /// </summary>
        ///
        /// <param name="connectionType">The type of connection used for communicating with the Event Hubs service.</param>
        /// <param name="eventHubPath">The path of the Event Hub to which events will be sent.</param>
        /// <param name="senderOptions">The set of options to use for this receiver.</param>
        ///
        protected internal EventSender(ConnectionType connectionType,
                                       string         eventHubPath,
                                       SenderOptions  senderOptions)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubPath), eventHubPath);

            //TODO: Validate and clone the options (to avoid any changes on the options being carried over)
            //TODO: Connection Type drives the contained receiver used for service operations. For example, an AmqpEventSender.
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventSender"/> class.
        /// </summary>
        ///
        protected EventSender()
        {
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="events">The set of event data to send.</param>
        /// <param name="partitionId">The identifier of the partition to which the event should be sent.  If not specified, a partition will be automatically selected.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <remarks>
        ///   Allowing automatic selection of a partition is recommended when:
        ///   <para>- The sending of events needs to be highly available.</para>
        ///   <para>- The event data should be evenly distributed among all available partitions.</para>
        ///
        ///   If no partition is specified, the following rules are used for automatically selecting one:
        ///   <para>1) Distribute the events equally amongst all available partitions using a round-robin approach.</para>
        ///   <para>2) If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</para>
        /// </remarks>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, EventBatchingOptions, CancellationToken)"/>
        /// <seealso cref="SendAsync(IEnumerable{EventData}, string, EventBatchingOptions, CancellationToken)"/>
        ///
        public virtual Task SendAsync(IEnumerable<EventData> events,
                                      string                 partitionId = default,
                                      CancellationToken      cancellationToken = default) => Task.CompletedTask;

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="events">The set of event data to send.</param>
        /// <param name="batchOptions">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <remarks>
        ///   Allowing automatic selection of a partition is recommended when:
        ///   <para>- The sending of events needs to be highly available.</para>
        ///   <para>- The event data should be evenly distributed among all available partitions.</para>
        ///
        ///   If no partition is specified, the following rules are used for automatically selecting one:
        ///   <para>1) Distribute the events equally amongst all available partitions using a round-robin approach.</para>
        ///   <para>2) If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</para>
        /// </remarks>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, string, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{EventData}, string, EventBatchingOptions, CancellationToken)"/>
        ///
        public virtual Task SendAsync(IEnumerable<EventData> events,
                                      EventBatchingOptions   batchOptions,
                                      CancellationToken      cancellationToken = default) => Task.CompletedTask;

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="events">The set of event data to send.</param>
        /// <param name="batchOptions">The set of options to consider when sending this batch.</param>
        /// <param name="partitionId">The identifier of the partition to which the event should be sent.  If not specified, a partition will be automatically selected.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <remarks>
        ///   Allowing automatic selection of a partition is recommended when:
        ///   <para>- The sending of events needs to be highly available.</para>
        ///   <para>- The event data should be evenly distributed among all available partitions.</para>
        ///
        ///   If no partition is specified, the following rules are used for automatically selecting one:
        ///   <para>1) Distribute the events equally amongst all available partitions using a round-robin approach.</para>
        ///   <para>2) If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</para>
        /// </remarks>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, string, CancellationToken)" />
        /// <seealso cref="SendAsync(IEnumerable{EventData}, EventBatchingOptions, CancellationToken)"/>
        ///
        public virtual Task SendAsync(IEnumerable<EventData> events,
                                      string                 partitionId,
                                      EventBatchingOptions   batchOptions,
                                      CancellationToken      cancellationToken = default) => Task.CompletedTask;

        /// <summary>
        ///   Closes the sender.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task CloseAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        /// <summary>
        ///   Closes the sender.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        public virtual void Close(CancellationToken cancellationToken = default) => CloseAsync(cancellationToken).GetAwaiter().GetResult();

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
