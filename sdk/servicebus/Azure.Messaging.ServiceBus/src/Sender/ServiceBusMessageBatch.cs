// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Shared;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

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
        public long MaxSizeInBytes => _innerBatch.MaxSizeInBytes;

        /// <summary>
        ///   The size of the batch, in bytes, as it will be sent to the Queue/Topic.
        /// </summary>
        ///
        public long SizeInBytes => _innerBatch.SizeInBytes;

        /// <summary>
        ///   The count of messages contained in the batch.
        /// </summary>
        ///
        public int Count => _innerBatch.Count;

        /// <summary>
        ///   The transport-specific batch responsible for performing the batch operations
        ///   in a manner compatible with the associated <see cref="TransportSender" />.
        /// </summary>
        ///
        private readonly TransportMessageBatch _innerBatch;

        private readonly MessagingClientDiagnostics _clientDiagnostics;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusMessageBatch"/> class.
        /// </summary>
        ///
        /// <param name="transportBatch">The  transport-specific batch responsible for performing the batch operations.</param>
        /// <param name="clientDiagnostics">The entity scope used for instrumentation.</param>
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
        internal ServiceBusMessageBatch(TransportMessageBatch transportBatch, MessagingClientDiagnostics clientDiagnostics)
        {
            Argument.AssertNotNull(transportBatch, nameof(transportBatch));
            _innerBatch = transportBatch;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        ///   Attempts to add a message to the batch, ensuring that the size
        ///   of the batch does not exceed its maximum.
        /// </summary>
        ///
        /// <param name="message">The message to attempt to add to the batch.</param>
        ///
        /// <returns><c>true</c> if the message was added; otherwise, <c>false</c>.</returns>
        ///
        /// <remarks>
        ///   When a message is accepted into the batch, changes made to its properties
        ///   will not be reflected in the batch nor will any state transitions be reflected
        ///   to the original instance.
        ///
        ///   Note: Any <see cref="ReadOnlyMemory{T}" />, byte array, or <see cref="BinaryData" />
        ///   instance associated with the event is referenced by the batch and must remain valid and
        ///   unchanged until the batch is disposed.
        /// </remarks>
        ///
        /// <exception cref="InvalidOperationException">
        ///   When a batch is sent, it will be locked for the duration of that operation.  During this time,
        ///   no messages may be added to the batch.  Calling <c>TryAdd</c> while the batch is being sent will
        ///   result in an <see cref="InvalidOperationException" /> until the send has completed.
        /// </exception>
        ///
        /// <exception cref="System.Runtime.Serialization.SerializationException">
        ///   Occurs when the <paramref name="message"/> has a member in its <see cref="ServiceBusMessage.ApplicationProperties"/> collection that is an
        ///   unsupported type for serialization.  See the <see cref="ServiceBusMessage.ApplicationProperties"/> remarks for details.
        /// </exception>
        ///
        public bool TryAddMessage(ServiceBusMessage message)
        {
            lock (_syncGuard)
            {
                AssertNotLocked();

                _clientDiagnostics.InstrumentMessage(message.ApplicationProperties, DiagnosticProperty.MessageActivityName, out var _, out var _);
                return _innerBatch.TryAddMessage(message);
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
                _innerBatch.Dispose();
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
                _innerBatch.Clear();
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
        internal IReadOnlyCollection<T> AsReadOnly<T>() => _innerBatch.AsReadOnly<T>();

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
