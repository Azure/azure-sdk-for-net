// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A set of <see cref="EventData" /> with size constraints known up-front,
    ///   intended to be sent to the Event Hubs service as a single batch.
    /// </summary>
    ///
    public sealed class EventDataBatch : IDisposable
    {
        /// <summary>
        ///   The maximum size allowed for the batch, in bytes.  This includes the events in the batch as
        ///   well as any overhead for the batch itself when sent to the Event Hubs service.
        /// </summary>
        ///
        public long MaximumSizeInBytes => InnerBatch.MaximumSizeInBytes;

        /// <summary>
        ///   The size of the batch, in bytes, as it will be sent to the Event Hubs
        ///   service.
        /// </summary>
        ///
        public long SizeInBytes => InnerBatch.SizeInBytes;

        /// <summary>
        ///   The count of events contained in the batch.
        /// </summary>
        ///
        public int Count => InnerBatch.Count;

        /// <summary>
        ///   The set of options that should be used when publishing the batch.
        /// </summary>
        ///
        internal SendOptions SendOptions { get; }

        /// <summary>
        ///   The transport-specific batch responsible for performing the batch operations
        ///   in a manner compatible with the associated <see cref="TransportProducer" />.
        /// </summary>
        ///
        private TransportEventBatch InnerBatch { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventDataBatch"/> class.
        /// </summary>
        ///
        /// <param name="transportBatch">The  transport-specific batch responsible for performing the batch operations.</param>
        /// <param name="sendOptions">The set of options that should be used when publishing the batch.</param>
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
        internal EventDataBatch(TransportEventBatch transportBatch,
                                SendOptions sendOptions)
        {
            Argument.AssertNotNull(transportBatch, nameof(transportBatch));
            Argument.AssertNotNull(sendOptions, nameof(sendOptions));

            InnerBatch = transportBatch;
            SendOptions = sendOptions;
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
        public bool TryAdd(EventData eventData)
        {
            bool instrumented = EventDataInstrumentation.InstrumentEvent(eventData);
            bool added = InnerBatch.TryAdd(eventData);

            if (!added && instrumented)
            {
                EventDataInstrumentation.ResetEvent(eventData);
            }

            return added;
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="EventDataBatch" />.
        /// </summary>
        ///
        public void Dispose() => InnerBatch.Dispose();

        /// <summary>
        ///   Represents the batch as an enumerable set of specific representations of an event.
        /// </summary>
        ///
        /// <typeparam name="T">The specific event representation being requested.</typeparam>
        ///
        /// <returns>The set of events as an enumerable of the requested type.</returns>
        ///
        internal IEnumerable<T> AsEnumerable<T>() => InnerBatch.AsEnumerable<T>();
    }
}
