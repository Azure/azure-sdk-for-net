// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   A set of <see cref="ServiceBusMessageBatch" /> with size constraints known up-front,
    ///   intended to be sent to the Queue/Topic as a single batch.
    /// </summary>
    ///
    public sealed class ServiceBusMessageBatch : IDisposable
    {
        /// <summary>
        ///   The maximum size allowed for the batch, in bytes.  This includes the messages in the batch as
        ///   well as any overhead for the batch itself when sent to the Queue/Topic.
        /// </summary>
        ///
        public long MaximumSizeInBytes => InnerBatch.MaximumSizeInBytes;

        /// <summary>
        ///   The size of the batch, in bytes, as it will be sent to the Queue/Topic.
        /// </summary>
        ///
        public long SizeInBytes => InnerBatch.SizeInBytes;

        /// <summary>
        ///   The count of messages contained in the batch.
        /// </summary>
        ///
        public int Count => InnerBatch.Count;

        /// <summary>
        ///   The transport-specific batch responsible for performing the batch operations
        ///   in a manner compatible with the associated <see cref="TransportSender" />.
        /// </summary>
        ///
        private TransportMessageBatch InnerBatch { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusMessageBatch"/> class.
        /// </summary>
        ///
        /// <param name="transportBatch">The  transport-specific batch responsible for performing the batch operations.</param>
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
        internal ServiceBusMessageBatch(TransportMessageBatch transportBatch)
        {
            Argument.AssertNotNull(transportBatch, nameof(transportBatch));

            InnerBatch = transportBatch;
        }

        /// <summary>
        ///   Attempts to add a message to the batch, ensuring that the size
        ///   of the batch does not exceed its maximum.
        /// </summary>
        ///
        /// <param name="message">Message to attempt to add to the batch.</param>
        ///
        /// <returns><c>true</c> if the message was added; otherwise, <c>false</c>.</returns>
        ///
        public bool TryAdd(ServiceBusMessage message)
        {
            return InnerBatch.TryAdd(message);
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusMessageBatch" />.
        /// </summary>
        ///
        public void Dispose() => InnerBatch.Dispose();

        /// <summary>
        ///   Represents the batch as an enumerable set of specific representations of a message.
        /// </summary>
        ///
        /// <typeparam name="T">The specific message representation being requested.</typeparam>
        ///
        /// <returns>The set of messages as an enumerable of the requested type.</returns>
        ///
        internal IEnumerable<T> AsEnumerable<T>() => InnerBatch.AsEnumerable<T>();
    }
}
