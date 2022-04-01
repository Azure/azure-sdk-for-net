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
    ///   using an AMQP-based transport appropriate for idempotent publishing.
    /// </summary>
    ///
    internal class IdempotentAmqpEventBatch : AmqpTransportEventBatch
    {
        /// <summary>A flag that indicates whether or not the instance has been disposed.</summary>
        private volatile bool _disposed;

        /// <summary>The size of the batch, in bytes, as it will be sent via the AMQP transport.</summary>
        private long _sizeBytes;

        /// <summary>The set of events that have been added to the batch, in their <see cref="AmqpMessage" /> serialized format.</summary>
        private List<AmqpMessage> _batchMessages;

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
        public override int Count => BatchEvents.Count;

        /// <summary>
        ///     The set of events that have been accepted into the batch.
        /// </summary>
        ///
        protected IList<EventData> BatchEvents { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpEventBatch"/> class.
        /// </summary>
        ///
        /// <param name="messageConverter">The converter to use for translating <see cref="EventData" /> into the corresponding AMQP message.</param>
        /// <param name="options">The set of options to apply to the batch.</param>
        /// <param name="activeFeatures">The flags specifying the set of special transport features have been opted-into.</param>
        ///
        public IdempotentAmqpEventBatch(AmqpMessageConverter messageConverter,
                                        CreateBatchOptions options,
                                        TransportProducerFeatures activeFeatures) : this(messageConverter, options, activeFeatures, new List<EventData>())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpEventBatch"/> class.
        /// </summary>
        ///
        /// <param name="messageConverter">The converter to use for translating <see cref="EventData" /> into the corresponding AMQP message.</param>
        /// <param name="options">The set of options to apply to the batch.</param>
        /// <param name="activeFeatures">The flags specifying the set of special transport features have been opted-into.</param>
        /// <param name="eventBackingStore">The backing store for holding events in the batch.</param>
        ///
        protected IdempotentAmqpEventBatch(AmqpMessageConverter messageConverter,
                                           CreateBatchOptions options,
                                           TransportProducerFeatures activeFeatures,
                                           IList<EventData> eventBackingStore) : base(messageConverter, options, activeFeatures)
        {
            _sizeBytes = ReservedOverheadBytes;
            BatchEvents = eventBackingStore;
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

            // Reserve space for producer-owned fields that correspond to idempotent publishing
            // metadata needed by the service.

            eventData.PendingPublishSequenceNumber = int.MaxValue;
            eventData.PendingProducerGroupId = long.MaxValue;
            eventData.PendingProducerOwnerLevel = short.MaxValue;

            try
            {
                var size = _sizeBytes + MeasureBytes(eventData);

                if (size > MaximumSizeInBytes)
                {
                    return false;
                }

                // Clone the event when accepting into the batch to ensure
                // that its size does change if the original reference is
                // mutated.

                _sizeBytes = size;
                BatchEvents.Add(eventData.Clone());

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
            if ((_batchMessages != null) && (_batchMessages.Count > 0))
            {
                foreach (var message in _batchMessages)
                {
                    message.Dispose();
                }
            }

            BatchEvents.Clear();
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
            if (typeof(T) == typeof(EventData))
            {
                return BatchEvents as IReadOnlyCollection<T>;
            }
            else if (typeof(T) == typeof(AmqpMessage))
            {
                // The AMQP messages must be recreated for each transform request to
                // ensure that the idempotent publishing properties are current and correct.
                //
                // This is a safe pattern, because the method is internal and only invoked
                // during a send operation, during which the batch is locked to prevent
                // changes or parallel attempts to send.
                //
                // Multiple requests to produce the collection would happen if this batch instance
                // is being published more than once, which is only valid if a call to SendAsync fails
                // across all retries, making it a fairly rare occurrence.

                if (_batchMessages != null)
                {
                    foreach (var message in _batchMessages)
                    {
                        message.Dispose();
                    }
                }

                _batchMessages = new(BatchEvents.Count);

                // Serialize the events in the batch into their AMQP transport format.  Because
                // the batch holds responsibility for disposing these, hold onto the references.

                foreach (var eventData in BatchEvents)
                {
                    _batchMessages.Add(MessageConverter.CreateMessageFromEvent(eventData));
                }

                return _batchMessages as IReadOnlyCollection<T>;
            }

            throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedTransportEventType, typeof(T).Name));
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
