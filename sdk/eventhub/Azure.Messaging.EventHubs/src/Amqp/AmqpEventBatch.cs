// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
    internal class AmqpEventBatch : TransportEventBatch
    {
        /// <summary>The amount of bytes to reserve as overhead for a small message.</summary>
        private const byte OverheadBytesSmallMessage = 5;

        /// <summary>The amount of bytes to reserve as overhead for a large message.</summary>
        private const byte OverheadBytesLargeMessage = 8;

        /// <summary>The maximum number of bytes that a message may be to be considered small.</summary>
        private const byte MaximumBytesSmallMessage = 255;

        /// <summary>The size of the batch, in bytes, to reserve for the AMQP message overhead.</summary>
        private readonly long ReservedSize;

        /// <summary>A flag that indicates whether or not the instance has been disposed.</summary>
        private volatile bool _disposed;

        /// <summary>The size of the batch, in bytes, as it will be sent via the AMQP transport.</summary>
        private long _sizeBytes;

        /// <summary>
        ///   The maximum size allowed for the batch, in bytes.  This includes the events in the batch as
        ///   well as any overhead for the batch itself when sent to the Event Hubs service.
        /// </summary>
        ///
        public override long MaximumSizeInBytes { get; }

        /// <summary>
        ///   The size of the batch, in bytes, as it will be sent to the Event Hubs
        ///   service.
        /// </summary>
        ///
        public override long SizeInBytes => _sizeBytes;

        /// <summary>
        ///   The flags specifying the set of special transport features that have been opted-into.
        /// </summary>
        ///
        public override TransportProducerFeatures ActiveFeatures { get; }

        /// <summary>
        ///   The count of events contained in the batch.
        /// </summary>
        ///
        public override int Count => BatchEvents.Count;

        /// <summary>
        ///   The converter to use for translating <see cref="EventData" /> into the corresponding AMQP message.
        /// </summary>
        ///
        private AmqpMessageConverter MessageConverter { get; }

        /// <summary>
        ///   The set of options to apply to the batch.
        /// </summary>
        ///
        private CreateBatchOptions Options { get; }

        /// <summary>
        ///   The set of events that have been added to the batch.
        /// </summary>
        ///
        private List<EventData> BatchEvents { get; } = new List<EventData>();

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpEventBatch"/> class.
        /// </summary>
        ///
        /// <param name="messageConverter">The converter to use for translating <see cref="EventData" /> into the corresponding AMQP message.</param>
        /// <param name="options">The set of options to apply to the batch.</param>
        /// <param name="activeFeatures">The flags specifying the set of special transport features have been opted-into.</param>
        ///
        public AmqpEventBatch(AmqpMessageConverter messageConverter,
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

            // Initialize the size by reserving space for the batch envelope.

            using AmqpMessage envelope = messageConverter.CreateBatchFromEvents(Enumerable.Empty<EventData>(), options.PartitionKey);
            ReservedSize = envelope.SerializedMessageSize;
            _sizeBytes = ReservedSize;
        }

        /// <summary>
        ///   Attempts to add an event to the batch, ensuring that the size
        ///   of the batch does not exceed its maximum.
        /// </summary>
        ///
        /// <param name="eventData">The event to attempt to add to the batch.</param>
        ///
        /// <returns><c>true</c> if the event was added; otherwise, <c>false</c>.</returns>
        ///
        public override bool TryAdd(EventData eventData)
        {
            Argument.AssertNotNull(eventData, nameof(eventData));
            Argument.AssertNotDisposed(_disposed, nameof(EventDataBatch));

            // Reserve space for producer-owned fields that correspond to special
            // features, if enabled.

            if ((ActiveFeatures & TransportProducerFeatures.IdempotentPublishing) != 0)
            {
                eventData.PendingPublishSequenceNumber = int.MaxValue;
                eventData.PendingProducerGroupId = long.MaxValue;
                eventData.PendingProducerOwnerLevel = short.MaxValue;
            }

            try
            {
                using var eventMessage = MessageConverter.CreateMessageFromEvent(eventData, Options.PartitionKey);

                // Calculate the size for the event, based on the AMQP message size and accounting for a
                // bit of reserved overhead size.

                var size = _sizeBytes
                    + eventMessage.SerializedMessageSize
                    + (eventMessage.SerializedMessageSize <= MaximumBytesSmallMessage
                        ? OverheadBytesSmallMessage
                        : OverheadBytesLargeMessage);

                if (size > MaximumSizeInBytes)
                {
                    return false;
                }

                _sizeBytes = size;
                BatchEvents.Add(eventData);

                return true;
            }
            finally
            {
                eventData.ClearPublishingState();
            }
        }

        /// <summary>
        ///   Clears the batch, removing all events and resetting the
        ///   available size.
        /// </summary>
        ///
        public override void Clear()
        {
            BatchEvents.Clear();
            _sizeBytes = ReservedSize;
        }

        /// <summary>
        ///   Represents the batch as an enumerable set of transport-specific
        ///   representations of an event.
        /// </summary>
        ///
        /// <typeparam name="T">The transport-specific event representation being requested.</typeparam>
        ///
        /// <returns>The set of events as an enumerable of the requested type.</returns>
        ///
        public override IEnumerable<T> AsEnumerable<T>()
        {
            if (typeof(T) != typeof(EventData))
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedTransportEventType, typeof(T).Name));
            }

            return (IEnumerable<T>)BatchEvents;
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="AmqpEventBatch" />.
        /// </summary>
        ///
        public override void Dispose()
        {
            _disposed = true;
            Clear();
        }
    }
}
