// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A receiver responsible for reading <see cref="EventData" /> from a specific Event Hub
    ///   partition and as a member of a specific consumer group.
    ///
    ///   A receiver may be exclusive, which asserts ownership over the partition for the consumer
    ///   group to ensure that only one receiver from that group is reading the from the partition.
    ///   These exclusive receivers are sometimes referred to as "Epoch Receivers."
    ///
    ///   A receiver may also be non-exclusive, allowing multiple receivers from the same consumer
    ///   group to be actively reading events from the partition.  These non-exclusive receivers are
    ///   sometimes referred to as "Non-Epoch Receivers."
    /// </summary>
    ///
    public class EventReceiver : IAsyncDisposable
    {
        /// <summary>
        ///   The identifier of the Event Hub partition that this receiver is associated with.  Events will be read
        ///   only from this partition.
        /// </summary>
        ///
        public string PartitionId { get; protected set; }

        /// <summary>
        ///   The name of the consumer group that this receiver is associated with.  Events will be read
        ///   only in the context of this group.
        /// </summary>
        ///
        public string ConsumerGroup { get; protected set; }

        /// <summary>
        ///   When populated, the priority indicates that a receiver is intended to be the only reader of events for the
        ///   requested partition and an associated consumer group.  To do so, this receiver will attempt to assert ownership
        ///   over the partition; in the case where more than one exclusive receiver attempts to assert ownership for the same
        ///   partition/consumer group pair, the one having a larger priority value will "win."
        ///
        ///   When an exclusive receiver is used, those receivers which are not exclusive or which have a lower priority will either
        ///   not be allowed to be created, if they already exist, will encounter an exception during the next attempted operation.
        /// </summary>
        ///
        /// <value>The priority to associated with an exclusive receiver; for a non-exclusive receiver, this value will be <c>null</c>.</value>
        ///
        public long? ExclusiveReceiverPriority { get; protected set; }

        /// <summary>
        ///   The position of the event in the partition where the receiver should begin reading.
        /// </summary>
        ///
        protected EventPosition StartingPosition { get; set; }

        /// <summary>
        ///   The set of event receiver options used for creation of this receiver.
        /// </summary>
        ///
        protected EventReceiverOptions Options { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventReceiver"/> class.
        /// </summary>
        ///
        /// <param name="connectionType">The type of connection used for communicating with the Event Hubs service.</param>
        /// <param name="eventHubPath">The path of the Event Hub from which events will be received.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="receiverOptions">The set of options to use for this receiver.</param>
        ///
        /// <remarks>
        ///   If the starting event position is not specified in the <paramref name="receiverOptions"/>, the receiver will
        ///   default to ignoring events in the partition that were queued prior to the receiver being created and read only
        ///   events which appear after that point.
        ///
        ///   Because this is a non-public constructor, it is assumed that the <paramref name="receiverOptions" /> passed are
        ///   owned by this instance and are safe from changes made by consumers.  It is considered the responsibility of the
        ///   caller to ensure that any needed cloning of options is performed.
        /// </remarks>
        ///
        internal EventReceiver(TransportType connectionType,
                               string eventHubPath,
                               string partitionId,
                               EventReceiverOptions receiverOptions)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubPath), eventHubPath);
            Guard.ArgumentNotNullOrEmpty(nameof(partitionId), partitionId);
            Guard.ArgumentNotNull(nameof(receiverOptions), receiverOptions);

            //TODO: Connection Type drives the contained receiver used for service operations. For example, an AmqpEventReceiver.

            PartitionId = partitionId;
            StartingPosition = receiverOptions.BeginReceivingAt;
            ExclusiveReceiverPriority = receiverOptions.ExclusiveReceiverPriority;
            Options = receiverOptions.Clone();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventReceiver"/> class.
        /// </summary>
        ///
        protected EventReceiver()
        {
        }

        /// <summary>
        ///   Receives a bach of <see cref="EventData" /> from the the Event Hub partition.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait to build up the requested message count for the batch; if not specified, the default wait time specified when the receiver was created will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>The batch of <see cref="EventData" /> from the Event Hub partition this receiver is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        public virtual Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount,
                                                                 TimeSpan? maximumWaitTime = null,
                                                                 CancellationToken cancellationToken = default) => throw new NotImplementedException();

        /// <summary>
        ///   Closes the receiver.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task CloseAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();

        /// <summary>
        ///   Closes the receiver.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
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
