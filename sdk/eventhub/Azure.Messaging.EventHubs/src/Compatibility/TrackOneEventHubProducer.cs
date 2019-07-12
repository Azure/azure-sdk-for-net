// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Compatibility
{
    /// <summary>
    ///   A transport client abstraction responsible for wrapping the track one producer as a transport producer for
    ///   AMQP-based connections.  It is intended that the public <see cref="EventHubProducer" /> make use of an instance
    ///   via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.EventHubs.Core.TransportEventHubProducer" />
    ///
    internal sealed class TrackOneEventHubProducer : TransportEventHubProducer
    {
        /// <summary>A lazy instantiation of the producer instance to delegate operation to.</summary>
        private Lazy<TrackOne.EventDataSender> _trackOneSender;

        /// <summary>
        ///   The track one <see cref="TrackOne.EventDataSender" /> for use with this transport producer.
        /// </summary>
        ///
        private TrackOne.EventDataSender TrackOneSender => _trackOneSender.Value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TrackOneEventHubProducer"/> class.
        /// </summary>
        ///
        /// <param name="trackOneSenderFactory">A delegate that can be used for creation of the <see cref="TrackOne.EventDataSender" /> to which operations are delegated to.</param>
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
        public TrackOneEventHubProducer(Func<TrackOne.EventDataSender> trackOneSenderFactory)
        {
            Guard.ArgumentNotNull(nameof(trackOneSenderFactory), trackOneSenderFactory);
            _trackOneSender = new Lazy<TrackOne.EventDataSender>(trackOneSenderFactory, LazyThreadSafetyMode.PublicationOnly);
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="events">The set of event data to send.</param>
        /// <param name="sendOptions">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public override async Task SendAsync(IEnumerable<EventData> events,
                                             SendOptions sendOptions,
                                             CancellationToken cancellationToken)
        {
            static TrackOne.EventData TransformEvent(EventData eventData) =>
                new TrackOne.EventData(eventData.Body.ToArray())
                {
                    Properties = eventData.Properties
                };

            try
            {
                await TrackOneSender.SendAsync(events.Select(TransformEvent), sendOptions?.PartitionKey);
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
            if (!_trackOneSender.IsValueCreated)
            {
                return Task.CompletedTask;
            }

            return TrackOneSender.CloseAsync();
        }
    }
}
