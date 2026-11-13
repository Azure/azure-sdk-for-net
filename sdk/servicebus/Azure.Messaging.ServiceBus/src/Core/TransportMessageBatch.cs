// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.ServiceBus.Core
{
    /// <summary>
    ///   Provides an abstraction for generalizing a batch of messages so that a dedicated instance may provide operations
    ///   for a specific transport, such as AMQP or JMS.  It is intended that the public <see cref="ServiceBusMessageBatch" /> employ
    ///   a transport batch via containment and delegate operations to it rather than understanding protocol-specific details
    ///   for different transports.
    /// </summary>
    ///
    internal abstract class TransportMessageBatch : IDisposable
    {
        /// <summary>
        ///   The maximum size allowed for the batch, in bytes.  This includes the messages in the batch as
        ///   well as any overhead for the batch itself when sent to the Queue/Topic.
        /// </summary>
        ///
        public abstract long MaxSizeInBytes { get; }

        /// <summary>
        ///   The size of the batch, in bytes, as it will be sent to the Queue/Topic
        /// </summary>
        ///
        public abstract long SizeInBytes { get; }

        /// <summary>
        ///   The count of messages contained in the batch.
        /// </summary>
        ///
        public abstract int Count { get; }

        /// <summary>
        ///   Attempts to add a message to the batch, ensuring that the size
        ///   of the batch does not exceed its maximum.
        /// </summary>
        ///
        /// <param name="message">The message to attempt to add to the batch.</param>
        ///
        /// <returns><c>true</c> if the message was added; otherwise, <c>false</c>.</returns>
        ///
        public abstract bool TryAddMessage(ServiceBusMessage message);

        /// <summary>
        ///   Clears the batch, removing all messages and resetting the
        ///   available size.
        /// </summary>
        ///
        public abstract void Clear();

        /// <summary>
        ///   Represents the batch as a set of the AMQP-specific representations of a message.
        /// </summary>
        ///
        /// <typeparam name="T">The transport-specific message representation being requested.</typeparam>
        ///
        /// <returns>The set of messages as an enumerable of the requested type.</returns>
        ///
        public abstract IReadOnlyCollection<T> AsReadOnly<T>();

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="TransportMessageBatch" />.
        /// </summary>
        ///
        public abstract void Dispose();
    }
}
