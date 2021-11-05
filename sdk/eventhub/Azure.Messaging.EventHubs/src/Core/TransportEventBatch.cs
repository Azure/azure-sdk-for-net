// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   Provides an abstraction for generalizing a batch of events so that a dedicated instance may provide operations
    ///   for a specific transport, such as AMQP or JMS.  It is intended that the public <see cref="EventDataBatch" /> employ
    ///   a transport batch via containment and delegate operations to it rather than understanding protocol-specific details
    ///   for different transports.
    /// </summary>
    ///
    internal abstract class TransportEventBatch : IDisposable
    {
        /// <summary>
        ///   The maximum size allowed for the batch, in bytes.  This includes the events in the batch as
        ///   well as any overhead for the batch itself when sent to the Event Hubs service.
        /// </summary>
        ///
        public abstract long MaximumSizeInBytes { get; }

        /// <summary>
        ///   The size of the batch, in bytes, as it will be sent to the Event Hubs
        ///   service.
        /// </summary>
        ///
        public abstract long SizeInBytes { get; }

        /// <summary>
        ///   The flags specifying the set of special transport features that have been opted-into.
        /// </summary>
        ///
        public abstract TransportProducerFeatures ActiveFeatures { get; }

        /// <summary>
        ///   The count of events contained in the batch.
        /// </summary>
        ///
        public abstract int Count { get; }

        /// <summary>
        ///   Attempts to add an event to the batch, ensuring that the size
        ///   of the batch does not exceed its maximum.
        /// </summary>
        ///
        /// <param name="eventData">The event to attempt to add to the batch.</param>
        ///
        /// <returns><c>true</c> if the event was added; otherwise, <c>false</c>.</returns>
        ///
        public abstract bool TryAdd(EventData eventData);

        /// <summary>
        ///   Clears the batch, removing all events and resetting the
        ///   available size.
        /// </summary>
        ///
        public abstract void Clear();

        /// <summary>
        ///   Represents the batch as an enumerable set of transport-specific
        ///   representations of an event.
        /// </summary>
        ///
        /// <typeparam name="T">The transport-specific event representation being requested.</typeparam>
        ///
        /// <returns>The set of events as an enumerable of the requested type.</returns>
        ///
        public abstract IEnumerable<T> AsEnumerable<T>();

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="TransportEventBatch" />.
        /// </summary>
        ///
        public abstract void Dispose();
    }
}
