// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Metadata;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   Allows events from a specific partition of an Event Hub, and in the context
    ///   of a specific consumer group, to be read with a greater level of control over
    ///   communication with the Event Hubs service than is offered by other event consumers.
    /// </summary>
    ///
    /// <remarks>
    ///   It is recommended that the <see cref="EventProcessorClient" /> or <see cref="EventHubConsumerClient" />
    ///   be used for reading and processing events for the majority of scenarios.  The partition receiver is
    ///   intended to enable scenarios with special needs which require more direct control.
    /// </remarks>
    ///
    /// <seealso cref="EventProcessorClient" />
    /// <seealso cref="EventHubConsumerClient.ReadEventsFromPartitionAsync(string, EventPosition, CancellationToken)"/>
    /// <seealso cref="EventHubConsumerClient.ReadEventsFromPartitionAsync(string, EventPosition, TimeSpan?, CancellationToken)"/>
    ///
    public class PartitionReceiver : IAsyncDisposable
    {
        /// <summary>
        ///   The name of the Event Hub that the receiver is connected to, specific to the
        ///   Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group that this receiver is associated with.  Events will be read
        ///   only in the context of this group.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition that this receiver is associated with.  Events will be read
        ///   only from this partition.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="PartitionReceiver"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the receiver is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed { get; protected set; }

        /// <summary>
        ///   The transport consumer that is used for operations performed against
        ///   the Event Hubs service.
        /// </summary>
        ///
        private TransportConsumer InnerConsumer { get; }

        /// <summary>
        ///   A flag indicating whether or not the transport consumer is tracking last enqueued event information.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the consumer is tracking the last enqueued event; otherwise, <c>false</c>.
        /// </value>
        ///
        private bool TrackingLastEnqueuedEvent { get; }

        /// <summary>
        ///   The default amount of time to wait for the requested amount of messages when receiving; if this
        ///   period elapses before the requested amount of messages were available or received, then the set of
        ///   messages that were received will be returned.
        /// </summary>
        ///
        private TimeSpan DefaultMaximumReceiveWaitTime { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this receiver is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the receiver with.</param>
        /// <param name="trackingLastEnqueuedEvent">A flag indicating whether or not the <paramref name="transportConsumer" /> is tracking last enqueued event information.</param>
        /// <param name="defaultMaximumReceiveWaitTime">The default amount of time to wait for the requested amount of messages when receiving.</param>
        /// <param name="transportConsumer">The transport consumer that is used for operations performed against the Event Hubs service.</param>
        ///
        internal PartitionReceiver(string consumerGroup,
                                   string partitionId,
                                   string eventHubName,
                                   bool trackingLastEnqueuedEvent,
                                   TimeSpan defaultMaximumReceiveWaitTime,
                                   TransportConsumer transportConsumer) : this(consumerGroup, partitionId, eventHubName)
        {
            Argument.AssertNotNull(transportConsumer, nameof(transportConsumer));

            TrackingLastEnqueuedEvent = trackingLastEnqueuedEvent;
            DefaultMaximumReceiveWaitTime = defaultMaximumReceiveWaitTime;
            InnerConsumer = transportConsumer;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PartitionReceiver"/> class.
        /// </summary>
        ///
        /// <param name="consumerGroup">The name of the consumer group this receiver is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the receiver with.</param>
        ///
        protected PartitionReceiver(string consumerGroup,
                                    string partitionId,
                                    string eventHubName)
        {
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));

            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            PartitionId = partitionId;
        }

        /// <summary>
        ///   A set of information about the last enqueued event of a partition, as observed by the receiver as
        ///   events are received from the Event Hubs service.  This is only available if the associated <see cref="EventHubConsumerClient" />
        ///   was created with <see cref="EventHubConsumerClientOptions.TrackLastEnqueuedEventInformation" /> set.
        /// </summary>
        ///
        /// <remarks>
        ///   When information about the partition's last enqueued event is being tracked, each event received from the Event Hubs
        ///   service will carry metadata about the partition that it otherwise would not. This results in a small amount of
        ///   additional network bandwidth consumption that is generally a favorable trade-off when considered
        ///   against periodically making requests for partition properties using an Event Hub client.
        /// </remarks>
        ///
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked without <see cref="EventHubConsumerClientOptions.TrackLastEnqueuedEventInformation" /> set on the associated client.</exception>
        ///
        public virtual LastEnqueuedEventProperties ReadLastEnqueuedEventInformation()
        {
            if (!TrackingLastEnqueuedEvent)
            {
                throw new InvalidOperationException(Resources.TrackLastEnqueuedEventInformationNotSet);
            }

            return new LastEnqueuedEventProperties(InnerConsumer.LastReceivedEvent);
        }

        /// <summary>
        ///   Receives a batch of <see cref="EventData" /> from the Event Hub partition.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait to build up the requested message count for the batch; if not specified, the per-try timeout specified by the retry policy will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="EventData" /> from the Event Hub partition this consumer is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        public virtual Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount,
                                                                 TimeSpan? maximumWaitTime = default,
                                                                 CancellationToken cancellationToken = default)
        {
            maximumWaitTime ??= DefaultMaximumReceiveWaitTime;

            Argument.AssertInRange(maximumMessageCount, 1, int.MaxValue, nameof(maximumMessageCount));
            Argument.AssertNotNegative(maximumWaitTime.Value, nameof(maximumWaitTime));

            return InnerConsumer.ReceiveAsync(maximumMessageCount, maximumWaitTime.Value, cancellationToken);
        }

        /// <summary>
        ///   Closes the receiver.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            IsClosed = true;

            try
            {
                await InnerConsumer.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
            {
                IsClosed = InnerConsumer.IsClosed;
                throw;
            }
        }

        /// <summary>
        ///   Closes the receiver.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public virtual void Close(CancellationToken cancellationToken = default) => CloseAsync(cancellationToken).GetAwaiter().GetResult();

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="PartitionReceiver" />,
        ///   including ensuring that the receiver itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
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
