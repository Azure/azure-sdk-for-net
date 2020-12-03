// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   A set of <see cref="ServiceBusMessage" /> with size constraints known up-front,
    ///   intended to be sent to the Queue/Topic as a single batch.
    ///   A <see cref="ServiceBusMessageBatch"/> can be created using
    ///   <see cref="ServiceBusSender.CreateMessageBatchAsync(System.Threading.CancellationToken)"/>.
    ///   Messages can be added to the batch using the <see cref="TryAddMessage"/> method on the batch.
    /// </summary>
    ///
    public sealed class ServiceBusMessageBatch : IDisposable
    {
        /// <summary>An object instance to use as the synchronization root for ensuring the thread-safety of operations.</summary>
        private readonly object _syncGuard = new object();

        /// <summary>A flag indicating that the batch is locked, such as when in use during a send batch operation.</summary>
        private bool _locked;

        /// <summary>
        ///   The maximum size allowed for the batch, in bytes.  This includes the messages in the batch as
        ///   well as any overhead for the batch itself when sent to the Queue/Topic.
        /// </summary>
        ///
        public long MaxSizeInBytes => InnerBatch.MaxSizeInBytes;

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
        public bool TryAddMessage(ServiceBusMessage message)
        {
            lock (_syncGuard)
            {
                AssertNotLocked();
                return InnerBatch.TryAddMessage(message);
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusMessageBatch" />.
        /// </summary>
        ///
        public void Dispose()
        {
            lock (_syncGuard)
            {
                AssertNotLocked();
                InnerBatch.Dispose();
            }
        }

        /// <summary>
        ///   Clears the batch, removing all messages and resetting the
        ///   available size.
        /// </summary>
        ///
        internal void Clear()
        {
            lock (_syncGuard)
            {
                AssertNotLocked();
                InnerBatch.Clear();
            }
        }

        /// <summary>
        ///   Represents the batch as an enumerable set of specific representations of a message.
        /// </summary>
        ///
        /// <typeparam name="T">The specific message representation being requested.</typeparam>
        ///
        /// <returns>The set of messages as an enumerable of the requested type.</returns>
        ///
        internal IEnumerable<T> AsEnumerable<T>() => InnerBatch.AsEnumerable<T>();

        /// <summary>
        ///   Locks the batch to prevent new messages from being added while a service
        ///   operation is active.
        /// </summary>
        ///
        internal void Lock()
        {
            lock (_syncGuard)
            {
                _locked = true;
            }
        }

        /// <summary>
        ///   Unlocks the batch, allowing new messages to be added.
        /// </summary>
        ///
        internal void Unlock()
        {
            lock (_syncGuard)
            {
                _locked = false;
            }
        }

        /// <summary>
        ///   Validates that the batch is not in a locked state, triggering an
        ///   invalid operation if it is.
        /// </summary>
        ///
        /// <exception cref="InvalidOperationException">Occurs when the batch is locked.</exception>
        ///
        private void AssertNotLocked()
        {
            if (_locked)
            {
                throw new InvalidOperationException(Resources.MessageBatchIsLocked);
            }
        }
    }
}
