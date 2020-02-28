// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   A set of <see cref="ServiceBusMessageBatch" /> with size constraints known up-front,
    ///   intended to be sent to the Event Hubs service as a single batch.
    /// </summary>
    ///
    public sealed class ServiceBusMessageBatch : IDisposable, IEnumerable
    {
        /// <summary>
        ///   The maximum size allowed for the batch, in bytes.  This includes the events in the batch as
        ///   well as any overhead for the batch itself when sent to the Event Hubs service.
        /// </summary>
        ///
        public long MaximumSizeInBytes { get; }

        /// <summary>
        ///   The size of the batch, in bytes, as it will be sent to the Event Hubs
        ///   service.
        /// </summary>
        ///
        public long SizeInBytes { get; }

        /// <summary>
        ///   The count of events contained in the batch.
        /// </summary>
        ///
        public int Count { get; }

        ///// <summary>
        /////   The set of options that should be used when publishing the batch.
        ///// </summary>
        /////
        //internal SendEventOptions SendOptions { get; }

        ///// <summary>
        /////   The transport-specific batch responsible for performing the batch operations
        /////   in a manner compatible with the associated <see cref="TransportProducer" />.
        ///// </summary>
        /////
        //private TransportEventBatch InnerBatch { get; }

        ///// <summary>
        /////   Initializes a new instance of the <see cref="ServiceBusMessageBatch"/> class.
        ///// </summary>
        /////
        ///// <param name="transportBatch">The  transport-specific batch responsible for performing the batch operations.</param>
        ///// <param name="sendOptions">The set of options that should be used when publishing the batch.</param>
        /////
        ///// <remarks>
        /////   As an internal type, this class performs only basic sanity checks against its arguments.  It
        /////   is assumed that callers are trusted and have performed deep validation.
        /////
        /////   Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        /////   creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        /////   caller.
        ///// </remarks>
        /////
        //internal EventDataBatch(TransportEventBatch transportBatch,
        //                        SendEventOptions sendOptions)
        //{
        //    Argument.AssertNotNull(transportBatch, nameof(transportBatch));
        //    Argument.AssertNotNull(sendOptions, nameof(sendOptions));

        //    InnerBatch = transportBatch;
        //    SendOptions = sendOptions;
        //}

        /// <summary>
        ///   Attempts to add an event to the batch, ensuring that the size
        ///   of the batch does not exceed its maximum.
        /// </summary>
        ///
        /// <param name="message">The event to attempt to add to the batch.</param>
        ///
        /// <returns><c>true</c> if the event was added; otherwise, <c>false</c>.</returns>
        ///
        public bool TryAdd(ServiceBusMessage message)
        {
            return true;
            //bool instrumented = EventDataInstrumentation.InstrumentEvent(eventData);
            //bool added = InnerBatch.TryAdd(eventData);

            //if (!added && instrumented)
            //{
            //    EventDataInstrumentation.ResetEvent(eventData);
            //}

            //return added;
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusMessageBatch" />.
        /// </summary>
        ///
        public void Dispose() { }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        /////   Represents the batch as an enumerable set of specific representations of an event.
        ///// </summary>
        /////
        ///// <typeparam name="T">The specific event representation being requested.</typeparam>
        /////
        ///// <returns>The set of events as an enumerable of the requested type.</returns>
        /////
        //internal IEnumerable<T> AsEnumerable<T>() => InnerBatch.AsEnumerable<T>();
    }
}
