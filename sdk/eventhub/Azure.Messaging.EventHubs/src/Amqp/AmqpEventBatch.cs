// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
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
    internal class AmqpEventBatch : AmqpTransportEventBatch
    {
        /// <summary>A flag that indicates whether or not the instance has been disposed.</summary>
        private volatile bool _disposed;

        /// <summary>The size of the batch, in bytes, as it will be sent via the AMQP transport.</summary>
        private long _sizeBytes;

        /// <summary>The set of events that have been added to the batch, in their <see cref="AmqpMessage" /> serialized format.</summary>
        private List<AmqpMessage> _batchMessages = new();

        /// <summary>
        ///   The size of the batch, in bytes, as it will be sent to the Event Hubs
        ///   service.
        /// </summary>
        ///
        public override long SizeInBytes => _sizeBytes;

        /// <summary>
        ///   The count of events contained in the batch.
        /// </summary>
        ///
        public override int Count => _batchMessages.Count;

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
                              TransportProducerFeatures activeFeatures) : base(messageConverter, options, activeFeatures)
        {
            _sizeBytes = ReservedOverheadBytes;
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

            // Calculate the size for the event, based on the AMQP message size and accounting for a
            // bit of reserved overhead size.

            var message = MessageConverter.CreateMessageFromEvent(eventData, Options.PartitionKey);
            var size = _sizeBytes + MeasureBytes(message);

            if (size > MaximumSizeInBytes)
            {
                message.Dispose();
                return false;
            }

            _sizeBytes = size;
            _batchMessages.Add(message);

            return true;
        }

        /// <summary>
        ///   Clears the batch, removing all events and resetting the
        ///   available size.
        /// </summary>
        ///
        public override void Clear()
        {
            foreach (var message in _batchMessages)
            {
                message.Dispose();
            }

            _batchMessages.Clear();
            _sizeBytes = ReservedOverheadBytes;
        }

        /// <summary>
        ///   Represents the batch as a set of the AMQP-specific representations of an event.
        /// </summary>
        ///
        /// <typeparam name="T">The transport-specific event representation being requested.</typeparam>
        ///
        /// <returns>The set of events as an enumerable of the requested type.</returns>
        ///
        public override IReadOnlyCollection<T> AsReadOnlyCollection<T>()
        {
            if (typeof(T) != typeof(AmqpMessage))
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedTransportEventType, typeof(T).Name));
            }

            return _batchMessages as IReadOnlyCollection<T>;
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
