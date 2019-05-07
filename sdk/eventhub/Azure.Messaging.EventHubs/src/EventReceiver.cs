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
    //TODO: This class is not in scope for the June Preview; hide or remove it once the implementation begins.

    /// <summary>
    ///   A receiver responsible for reading <see cref="EventData" /> from a specific Event Hub
    ///   across all available partitions, and as a member of a specific consumer group.
    ///
    ///   A receiver may be exclusive, which asserts ownership over the partition for the consumer
    ///   group to ensure that only one receiver from that group is reading the from the partition.
    ///   These exclusive receivers are sometimes referred to as "Epoch Receivers."
    ///
    ///   A receiver may also be non-exclusive, allowing multiple receivers from the same consumer
    ///   group to be actively reading events from the partition.  These non-exclusive receivers are
    ///   sometimes referred to as "Non-epoch Receivers."
    /// </summary>
    ///
    public class EventReceiver
    {
        /// <summary>
        ///   The name of the consumer group that this receiver is associated with.  Events will be read
        ///   only in the context of this group.
        /// </summary>
        ///
        public string ConsumerGroupName { get; protected set; }

        /// <summary>
        ///   Indicates that the receiver is the only reader of events for the requested partition and associated
        ///   consumer group.
        /// </summary>
        ///
        /// <value><c>true</c> if the receiver is exclusive; otherwise, <c>false</c>.</value>
        ///
        public bool IsExclusiveReceiver { get; protected set; }

        /// <summary>
        ///   The relative priority of the receiver within the associated consumer group, used to resolve conflicting requests for partition ownership when using exclusive receivers.
        /// </summary>
        ///
        /// <value>This value is expected to be <c>null</c> if the receiver is not intended to be exclusive; an exclusive receiver must have a value.</value>
        ///
        public long? Priority { get; protected set; }

        /// <summary>
        ///   A snapshot of the state of which events have been received across each partition in the Event Hub known by the current receiver.
        ///   If kept updated, this checkpoint is intended to mark the position of the last events read so that a new reciever can be created which
        ///   begins reading where this receiver stopped.
        /// </summary>
        ///
        /// <value>If <see cref="ReceiverOptions.UpdateInformationOnReceive" /> is <c>true</c>, this information will be refreshed when events are received; otherwise, this will not be populated.</value>
        ///
        public ReceiverCheckpoint LastReceivedCheckpoint { get; protected set; }

        /// <summary>
        ///   The position across partitions where the receiver should begin reading.
        /// </summary>
        ///
        protected ReceiverCheckpoint StartingCheckpoint { get; set; }

        /// <summary>
        ///   The set of event receiver options used for creation of this receiver.
        /// </summary>
        ///
        protected ReceiverOptions ReceiverOptions { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventReceiver"/> class.
        /// </summary>
        ///
        /// <param name="connectionType">The type of connection used for communicating with the Event Hubs service.</param>
        /// <param name="eventHubPath">The path of the Event Hub from which events will be received.</param>
        /// <param name="startReceivingAt">The position of the event where the receiver should begin reading events.</param>
        /// <param name="receiverOptions">The set of options to use for this receiver.</param>
        ///
        protected internal EventReceiver(ConnectionType         connectionType,
                                             string             eventHubPath,
                                             ReceiverCheckpoint startReceivingAt,
                                             ReceiverOptions    receiverOptions)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubPath), eventHubPath);
            Guard.ArgumentNotNull(nameof(startReceivingAt), startReceivingAt);

            //TODO: Validate and clone the options (to avoid any changes on the options being carried over)
            //TODO: Connection Type drives the contained receiver used for service operations. For example, an AmqpEventReceiver.
            //TODO: Retrieve and partition information and populate the dictionary based on it.

            StartingCheckpoint = startReceivingAt;
            ReceiverOptions = receiverOptions;
            IsExclusiveReceiver = receiverOptions.IsExclusiveReceiver;
            LastReceivedCheckpoint = startReceivingAt;

            Priority = receiverOptions.IsExclusiveReceiver
                ? receiverOptions.ExclusiveReceiverPriority
                : (long?)null;
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
        public virtual Task<IEnumerable<EventData>> ReceiveAsync(int               maximumMessageCount,
                                                                 TimeSpan?         maximumWaitTime = null,
                                                                 CancellationToken cancellationToken = default) =>
            Task.FromResult<IEnumerable<EventData>>(new[] { new EventData(System.Text.Encoding.UTF8.GetBytes("Sample")), new EventData(System.Text.Encoding.UTF8.GetBytes("Other")) });

        /// <summary>
        ///   Closes the receiver.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request for cancelling the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task CloseAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        /// <summary>
        ///   Closes receiver.
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
