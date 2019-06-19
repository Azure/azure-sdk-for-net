// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A sender responsible for transmitting <see cref="EventData" /> to a specific Event Hub,
    ///   grouped together in batches.  Depending on the options specified at creation, the sender may
    ///   be created to allow event data to be automatically routed to an available partition or specific
    ///   to a partition.
    /// </summary>
    ///
    /// <remarks>
    ///   Allowing automatic routing of partitions is recommended when:
    ///   <para>- The sending of events needs to be highly available.</para>
    ///   <para>- The event data should be evenly distributed among all available partitions.</para>
    ///
    ///   If no partition is specified, the following rules are used for automatically selecting one:
    ///   <para>1) Distribute the events equally amongst all available partitions using a round-robin approach.</para>
    ///   <para>2) If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</para>
    /// </remarks>
    ///
    public class EventSender : IAsyncDisposable
    {
        /// <summary>The maximum allowable size, in bytes, for a batch to be sent.</summary>
        internal const int MinimumBatchSizeLimit = 24;

        /// <summary>The maximum allowable size, in bytes, for a batch to be sent.</summary>
        internal const int MaximumBatchSizeLimit = 4 * 1024 * 1024;

        /// <summary>The set of default batching options to use when no specific options are requested.</summary>
        private static readonly EventBatchingOptions DefaultBatchOptions = new EventBatchingOptions();

        /// <summary>
        ///   The identifier of the Event Hub partition that the <see cref="EventSender" /> is bound to, indicating
        ///   that it will send events to only that partition.
        ///
        ///   If the identifier was not specified at creation, the sender will allow the Event Hubs service to be
        ///   responsible for routing events that are sent to an available partition.
        /// </summary>
        ///
        /// <value>If <c>null</c>, the sender is not specific to a partition and events will be automatically routed; otherwise, the identifier of the partition events will be sent to.</value>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The path of the specific Event Hub that the client is connected to, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubPath { get; }

        /// <summary>
        ///   The set of options used for creation of this sender.
        /// </summary>
        ///
        private EventSenderOptions Options { get; }

        /// <summary>
        ///   An abstracted Event Sender specific to the active protocol and transport intended to perform delegated operations.
        /// </summary>
        ///
        private TransportEventSender InnerSender { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventSender"/> class.
        /// </summary>
        ///
        /// <param name="transportSender">An abstracted Event Sender specific to the active protocol and transport intended to perform delegated operations.</param>
        /// <param name="eventHubPath">The path of the Event Hub to which events will be sent.</param>
        /// <param name="senderOptions">The set of options to use for this receiver.</param>
        ///
        /// <remarks>
        ///   Because this is a non-public constructor, it is assumed that the <paramref name="senderOptions" /> passed are
        ///   owned by this instance and are safe from changes made by consumers.  It is considered the responsibility of the
        ///   caller to ensure that any needed cloning of options is performed.
        /// </remarks>
        ///
        internal EventSender(TransportEventSender transportSender,
                             string eventHubPath,
                             EventSenderOptions senderOptions)
        {
            Guard.ArgumentNotNull(nameof(transportSender), transportSender);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubPath), eventHubPath);
            Guard.ArgumentNotNull(nameof(senderOptions), senderOptions);

            PartitionId = senderOptions.PartitionId;
            EventHubPath = eventHubPath;
            Options = senderOptions;
            InnerSender = transportSender;
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
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, EventBatchingOptions, CancellationToken)"/>
        ///
        public virtual Task SendAsync(IEnumerable<EventData> events,
                                      CancellationToken cancellationToken = default) => SendAsync(events, null, cancellationToken);

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="events">The set of event data to send.</param>
        /// <param name="batchOptions">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendAsync(IEnumerable{EventData}, CancellationToken)" />
        ///
        public virtual Task SendAsync(IEnumerable<EventData> events,
                                      EventBatchingOptions batchOptions,
                                      CancellationToken cancellationToken = default)
        {
            Guard.ArgumentNotNull(nameof(events), events);

            batchOptions = batchOptions ?? DefaultBatchOptions;

            if ((!String.IsNullOrEmpty(PartitionId)) && (!String.IsNullOrEmpty(batchOptions.PartitionKey)))
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, Resources.CannotSendWithPartitionIdAndPartitionKey, PartitionId));
            }

            return InnerSender.SendAsync(events, batchOptions, cancellationToken);
        }

        /// <summary>
        ///   Closes the sender.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task CloseAsync(CancellationToken cancellationToken = default) => InnerSender.CloseAsync(cancellationToken);

        /// <summary>
        ///   Closes the sender.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public virtual void Close(CancellationToken cancellationToken = default) => CloseAsync(cancellationToken).GetAwaiter().GetResult();

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="EventHubClient" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

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
