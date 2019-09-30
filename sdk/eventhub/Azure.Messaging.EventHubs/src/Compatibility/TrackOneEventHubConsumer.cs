// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Metadata;

namespace Azure.Messaging.EventHubs.Compatibility
{
    /// <summary>
    ///   A transport client abstraction responsible for wrapping the track one producer as a transport consumer for an
    ///   AMQP-based connections.  It is intended that the public <see cref="EventHubConsumer" /> make use of an instance
    ///   via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.EventHubs.Core.TransportEventHubConsumer" />
    ///
    internal sealed class TrackOneEventHubConsumer : TransportEventHubConsumer
    {
        /// <summary>The active retry policy for the producer.</summary>
        private EventHubRetryPolicy _retryPolicy;

        /// <summary>A lazy instantiation of the producer instance to delegate operation to.</summary>
        private Lazy<TrackOne.PartitionReceiver> _trackOneReceiver;

        /// <summary>
        ///   The track one <see cref="TrackOne.PartitionReceiver" /> for use with this transport producer.
        /// </summary>
        ///
        private TrackOne.PartitionReceiver TrackOneReceiver => _trackOneReceiver.Value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TrackOneEventHubConsumer"/> class.
        /// </summary>
        ///
        /// <param name="trackOneReceiverFactory">A delegate that can be used for creation of the <see cref="TrackOne.PartitionReceiver" /> to which operations are delegated to.</param>
        /// <param name="retryPolicy">The retry policy to use when creating the <see cref="TrackOne.PartitionReceiver" />.</param>
        /// <param name="lastEnqueuedEventProperties">The set of properties for the last event enqueued in a partition; if not requested in the consumer options, it is expected that this is <c>null</c>.</param>
        ///
        /// <remarks>
        ///   As an internal type, this class performs only basic sanity checks against its arguments.  It
        ///   is assumed that callers are trusted and have performed deep validation.
        ///
        ///   Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        ///   creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        ///   caller.
        /// </remarks>
        ///
        public TrackOneEventHubConsumer(Func<EventHubRetryPolicy, TrackOne.PartitionReceiver> trackOneReceiverFactory,
                                        EventHubRetryPolicy retryPolicy,
                                        LastEnqueuedEventProperties lastEnqueuedEventProperties) : base(lastEnqueuedEventProperties)
        {
            Argument.AssertNotNull(trackOneReceiverFactory, nameof(trackOneReceiverFactory));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            _retryPolicy = retryPolicy;
            _trackOneReceiver = new Lazy<TrackOne.PartitionReceiver>(() => trackOneReceiverFactory(_retryPolicy), LazyThreadSafetyMode.ExecutionAndPublication);
        }

        /// <summary>
        ///   Updates the active retry policy for the client.
        /// </summary>
        ///
        /// <param name="newRetryPolicy">The retry policy to set as active.</param>
        ///
        public override void UpdateRetryPolicy(EventHubRetryPolicy newRetryPolicy)
        {
            _retryPolicy = newRetryPolicy;

            if (_trackOneReceiver.IsValueCreated)
            {
                TrackOneReceiver.RetryPolicy = new TrackOneRetryPolicy(newRetryPolicy);
            }
        }

        /// <summary>
        ///   Receives a batch of <see cref="EventData" /> from the Event Hub partition.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait to build up the requested message count for the batch; if not specified, the default wait time specified when the consumer was created will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="EventData" /> from the Event Hub partition this consumer is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        public override async Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount,
                                                                        TimeSpan? maximumWaitTime,
                                                                        CancellationToken cancellationToken)
        {
            static EventData TransformEvent(TrackOne.EventData eventData)
            {
                if (!long.TryParse(eventData.LastEnqueuedOffset, out var parsedLastOffset))
                {
                    parsedLastOffset = -1;
                }

                return new EventData(eventData.Body,
                                     eventData.Properties,
                                     eventData.SystemProperties.WithoutTypedMembers(),
                                     eventData.SystemProperties.SequenceNumber,
                                     long.Parse(eventData.SystemProperties.Offset),
                                     new DateTimeOffset(eventData.SystemProperties.EnqueuedTimeUtc),
                                     eventData.SystemProperties.PartitionKey,
                                     (eventData.LastSequenceNumber != default ? eventData.LastSequenceNumber : default(long?)),
                                     (parsedLastOffset >= 0 ? parsedLastOffset : default(long?)),
                                     (eventData.LastEnqueuedTime != default ? new DateTimeOffset(eventData.LastEnqueuedTime) : default(DateTimeOffset?)));
            }

            try
            {
                IEnumerable<EventData> events = ((await TrackOneReceiver.ReceiveAsync(maximumMessageCount, maximumWaitTime).ConfigureAwait(false))
                        ?? Enumerable.Empty<TrackOne.EventData>())
                    .Select(TransformEvent);

                if ((TrackOneReceiver.ReceiverRuntimeMetricEnabled) && (LastEnqueuedEventInformation != null))
                {
                    if (!long.TryParse(TrackOneReceiver.RuntimeInfo.LastEnqueuedOffset, out var parsedOffset))
                    {
                        parsedOffset = -1;
                    }

                    LastEnqueuedEventInformation.UpdateMetrics(
                        TrackOneReceiver.RuntimeInfo.LastSequenceNumber,
                        ((parsedOffset >= 0) ? parsedOffset : default(long?)),
                        ((TrackOneReceiver.RuntimeInfo.LastEnqueuedTimeUtc == DateTime.MinValue) ? default(DateTimeOffset?) : new DateTimeOffset(TrackOneReceiver.RuntimeInfo.LastEnqueuedTimeUtc)),
                        ((TrackOneReceiver.RuntimeInfo.RetrievalTime == DateTime.MinValue) ? default(DateTimeOffset?) : new DateTimeOffset(TrackOneReceiver.RuntimeInfo.RetrievalTime)));
                }

                return events;
            }
            catch (TrackOne.EventHubsException ex)
            {
                throw ex.MapToTrackTwoException();
            }
        }

        /// <summary>
        ///   Closes the connection to the transport client instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public override Task CloseAsync(CancellationToken cancellationToken)
        {
            if (!_trackOneReceiver.IsValueCreated)
            {
                return Task.CompletedTask;
            }

            return TrackOneReceiver.CloseAsync();
        }
    }
}
