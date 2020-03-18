// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Describes a Session object. <see cref="ServiceBusSessionManager"/> can be used to perform operations on sessions.
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Service Bus Sessions, also called 'Groups' in the AMQP 1.0 protocol, are unbounded sequences of related messages. ServiceBus guarantees ordering of messages in a session.
    /// </para>
    /// <para>
    /// Any sender can create a session when submitting messages into a Topic or Queue by setting the <see cref="ServiceBusMessage.SessionId"/> property on Message to some
    /// application defined unique identifier. At the AMQP 1.0 protocol level, this value maps to the group-id property.
    /// </para>
    /// <para>
    /// Sessions come into existence when there is at least one message with the session's SessionId in the Queue or Topic subscription.
    /// Once a Session exists, there is no defined moment or gesture for when the session expires or disappears.
    /// </para>
    /// </remarks>
    public class ServiceBusSessionManager
    {
        /// <summary>
        /// An abstracted Service Bus transport-specific receiver that is associated with the
        /// Service Bus gateway; intended to perform delegated operations.
        /// </summary>
        private readonly TransportReceiver _receiver;
        private readonly string _identifier;

        /// <summary>
        /// The Session Id associated with the receiver.
        /// </summary>
        public string SessionId => _receiver.SessionId;

        /// <summary>
        /// Gets the DateTime that the current receiver is locked until.
        /// </summary>
        public DateTimeOffset LockedUntil => _receiver.SessionLockedUntil;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusSessionManager"/> class.
        /// </summary>
        ///
        /// <param name="receiver">
        /// An abstracted Service Bus transport-specific receiver that is associated with the
        /// Service Bus gateway; intended to perform delegated operations.
        /// </param>
        /// <param name="identifier"></param>
        internal ServiceBusSessionManager(
            TransportReceiver receiver,
            string identifier)
        {
            _receiver = receiver;
            _identifier = identifier;
        }

        /// <summary>
        /// Gets the session state.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The session state as byte array.</returns>
        public virtual async Task<byte[]> GetStateAsync(
            CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(new byte[4]).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set a custom state on the session which can be later retrieved using <see cref="GetStateAsync"/>
        /// </summary>
        ///
        /// <param name="sessionState">A byte array of session state</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>This state is stored on Service Bus forever unless you set an empty state on it.</remarks>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public virtual async Task SetStateAsync(byte[] sessionState,
            CancellationToken cancellationToken = default)
        {
            await Task.Delay(1).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renews the lock on the session specified by the <see cref="SessionId"/>. The lock will be renewed based on the setting specified on the entity.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// <para>
        /// When you get session receiver, the session is locked for this receiver by the service for a duration as specified during the Queue/Subscription creation.
        /// If processing of the session requires longer than this duration, the session-lock needs to be renewed.
        /// For each renewal, it resets the time the session is locked by the LockDuration set on the Entity.
        /// </para>
        /// <para>
        /// Renewal of session renews all the messages in the session as well. Each individual message need not be renewed.
        /// </para>
        /// </remarks>
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.RenewSessionLockStart(_identifier, SessionId);
            try
            {
                await _receiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                ServiceBusEventSource.Log.RenewSessionLockException(_identifier, exception);
                throw;
            }
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.RenewSessionLockComplete(_identifier);
        }
    }
}
