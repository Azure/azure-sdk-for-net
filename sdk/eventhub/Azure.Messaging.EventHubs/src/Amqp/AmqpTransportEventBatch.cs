// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   A set of events with known size constraints, based on messages to be sent
    ///   using an AMQP-based transport.
    /// </summary>
    ///
    internal abstract class AmqpTransportEventBatch : TransportEventBatch
    {
        /// <summary>The amount of bytes to reserve as overhead for a small message.</summary>
        private const byte OverheadBytesSmallMessage = 5;

        /// <summary>The amount of bytes to reserve as overhead for a large message.</summary>
        private const byte OverheadBytesLargeMessage = 8;

        /// <summary>The maximum number of bytes that a message may be to be considered small.</summary>
        private const byte MaximumBytesSmallMessage = 255;

        /// <summary>
        ///   The maximum size allowed for the batch, in bytes.  This includes the events in the batch as
        ///   well as any overhead for the batch itself when sent to the Event Hubs service.
        /// </summary>
        ///
        public override long MaximumSizeInBytes { get; }

        /// <summary>
        ///   The flags specifying the set of special transport features that have been opted-into.
        /// </summary>
        ///
        public override TransportProducerFeatures ActiveFeatures { get; }

        /// <summary>
        ///   The size of the batch, in bytes, to reserve for the AMQP message overhead.
        /// </summary>
        ///
        protected long ReservedOverheadBytes { get; }

        /// <summary>
        ///   The converter to use for translating <see cref="EventData" /> into the corresponding AMQP message.
        /// </summary>
        ///
        protected AmqpMessageConverter MessageConverter { get; }

        /// <summary>
        ///   The set of options to apply to the batch.
        /// </summary>
        ///
        protected CreateBatchOptions Options { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpTransportEventBatch"/> class.
        /// </summary>
        ///
        /// <param name="messageConverter">The converter to use for translating <see cref="EventData" /> into the corresponding AMQP message.</param>
        /// <param name="options">The set of options to apply to the batch.</param>
        /// <param name="activeFeatures">The flags specifying the set of special transport features have been opted-into.</param>
        ///
        protected AmqpTransportEventBatch(AmqpMessageConverter messageConverter,
                                          CreateBatchOptions options,
                                          TransportProducerFeatures activeFeatures)
        {
            Argument.AssertNotNull(messageConverter, nameof(messageConverter));
            Argument.AssertNotNull(options, nameof(options));
            Argument.AssertNotNull(options.MaximumSizeInBytes, nameof(options.MaximumSizeInBytes));

            MessageConverter = messageConverter;
            Options = options;
            MaximumSizeInBytes = options.MaximumSizeInBytes.Value;
            ActiveFeatures = activeFeatures;

            // Initialize the size by reserving space for the batch envelope.  At this point, the
            // set of batch events is empty, so the message returned will only represent the envelope.

            using AmqpMessage envelope = messageConverter.CreateBatchFromMessages(Array.Empty<AmqpMessage>(), options.PartitionKey);
            ReservedOverheadBytes = envelope.SerializedMessageSize;
        }

        /// <summary>
        ///   Measures an event and calculates the number of bytes that it requires
        ///   if included in the batch.
        /// </summary>
        ///
        /// <param name="eventData">The event to measure.</param>
        ///
        /// <returns>The number of bytes to reserve for the event, if included in the batch.</returns>
        ///
        protected long MeasureBytes(EventData eventData)
        {
            using var message = MessageConverter.CreateMessageFromEvent(eventData);
            return MeasureBytes(message);
        }

        /// <summary>
        ///   Measures an AMQP message and calculates the number of bytes that it requires
        ///   if included in the batch.
        /// </summary>
        ///
        /// <param name="message">The message to measure.</param>
        ///
        /// <returns>The number of bytes to reserve for the message, if included in the batch.</returns>
        ///
        /// <remarks>
        ///   Callers retain ownership over the <paramref name="message" /> and hold responsibility
        ///   for ensuring disposal.
        /// </remarks>
        ///
        protected static long MeasureBytes(AmqpMessage message) =>
            message.SerializedMessageSize
                + (message.SerializedMessageSize <= MaximumBytesSmallMessage
                    ? OverheadBytesSmallMessage
                    : OverheadBytesLargeMessage);
    }
}
