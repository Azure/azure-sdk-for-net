// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Core;
using Microsoft.Azure.Amqp;

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
        /// <summary>The active retry policy for the producer.</summary>
        private EventHubRetryPolicy _retryPolicy;

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
        /// <param name="retryPolicy">The retry policy to use when creating the <see cref="TrackOne.EventDataSender" />.</param>
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
        public TrackOneEventHubProducer(Func<EventHubRetryPolicy, TrackOne.EventDataSender> trackOneSenderFactory,
                                        EventHubRetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(nameof(trackOneSenderFactory), trackOneSenderFactory);
            Guard.ArgumentNotNull(nameof(retryPolicy), retryPolicy);

            _retryPolicy = retryPolicy;
            _trackOneSender = new Lazy<TrackOne.EventDataSender>(() => trackOneSenderFactory(_retryPolicy), LazyThreadSafetyMode.PublicationOnly);
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

            if (_trackOneSender.IsValueCreated)
            {
                TrackOneSender.RetryPolicy = new TrackOneRetryPolicy(newRetryPolicy);
            }
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
                await TrackOneSender.SendAsync(events.Select(TransformEvent), sendOptions?.PartitionKey).ConfigureAwait(false);
            }
            catch (TrackOne.EventHubsException ex)
            {
                throw ex.MapToTrackTwoException();
            }
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.
        /// </summary>
        ///
        /// <param name="eventBatch">The set of event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public override async Task SendAsync(EventDataBatch eventBatch,
                                             CancellationToken cancellationToken)
        {
            static TrackOne.EventData TransformMessage(AmqpMessage message) =>
                new TrackOne.EventData(Array.Empty<byte>())
                {
                    AmqpMessage = message
                };

            try
            {
                var events = eventBatch.AsEnumerable<AmqpMessage>().Select(TransformMessage);
                await TrackOneSender.SendAsync(events, eventBatch.SendOptions?.PartitionKey).ConfigureAwait(false);
            }
            catch (TrackOne.EventHubsException ex)
            {
                throw ex.MapToTrackTwoException();
            }
        }

        /// <summary>
        ///   Creates a size-constraint batch to which <see cref="EventData" /> may be added using a try-based pattern.  If an event would
        ///   exceed the maximum allowable size of the batch, the batch will not allow adding the event and signal that scenario using its
        ///   return value.
        ///
        ///   Because events that would violate the size constraint cannot be added, publishing a batch will not trigger an exception when
        ///   attempting to send the events to the Event Hubs service.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider when creating this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="EventDataBatch" /> with the requested <paramref name="options"/>.</returns>
        ///
        /// <seealso cref="CreateBatchAsync(BatchOptions, CancellationToken)" />
        ///
        public override async Task<TransportEventBatch> CreateBatchAsync(BatchOptions options,
                                                                         CancellationToken cancellationToken)
        {
            Guard.ArgumentNotNull(nameof(options), options);

            // Ensure that the underlying AMQP link was created so that the maximum
            // message size was set on the track one sender.

            await TrackOneSender.EnsureLinkAsync().ConfigureAwait(false);

            // Ensure that there was a maximum size populated; if none was provided,
            // default to the maximum size allowed by the link.

            options.MaximumizeInBytes = options.MaximumizeInBytes ?? TrackOneSender.MaxMessageSize;

            Guard.ArgumentInRange(nameof(options.MaximumizeInBytes), options.MaximumizeInBytes.Value, EventHubProducer.MinimumBatchSizeLimit, TrackOneSender.MaxMessageSize);

            return new AmqpEventBatch(new AmqpMessageConverter(), options);
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
