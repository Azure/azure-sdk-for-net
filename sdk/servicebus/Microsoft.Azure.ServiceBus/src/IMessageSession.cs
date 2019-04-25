// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Threading.Tasks;
    using Core;

    /// <summary>
    /// Describes a Session object. IMessageSession can be used to perform operations on sessions.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Service Bus Sessions, also called 'Groups' in the AMQP 1.0 protocol, are unbounded sequences of related messages. ServiceBus guarantees ordering of messages in a session.
    /// </para>
    /// <para>
    /// Any sender can create a session when submitting messages into a Topic or Queue by setting the <see cref="Message.SessionId"/> property on Message to some
    /// application defined unique identifier. At the AMQP 1.0 protocol level, this value maps to the group-id property.
    /// </para>
    /// <para>
    /// Sessions come into existence when there is at least one message with the session's SessionId in the Queue or Topic subscription.
    /// Once a Session exists, there is no defined moment or gesture for when the session expires or disappears.
    /// </para>
    /// </remarks>
    public interface IMessageSession : IMessageReceiver
    {
        /// <summary>
        /// Gets the SessionId.
        /// </summary>
        string SessionId { get; }

        /// <summary>
        /// Gets the time that the session identified by <see cref="SessionId"/> is locked until for this client.
        /// </summary>
        DateTime LockedUntilUtc { get; }

        /// <summary>
        /// Gets the session state.
        /// </summary>
        /// <returns>The session state as byte array.</returns>
        Task<byte[]> GetStateAsync();

        /// <summary>
        /// Set a custom state on the session which can be later retrieved using <see cref="GetStateAsync"/>
        /// </summary>
        /// <param name="sessionState">A byte array of session state</param>
        /// <remarks>This state is stored on Service Bus forever unless you set an empty state on it.</remarks>
        Task SetStateAsync(byte[] sessionState);

        /// <summary>
        /// Renews the lock on the session specified by the <see cref="SessionId"/>. The lock will be renewed based on the setting specified on the entity.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When you accept a session, the session is locked for this client instance by the service for a duration as specified during the Queue/Subscription creation.
        /// If processing of the session requires longer than this duration, the session-lock needs to be renewed. 
        /// For each renewal, it resets the time the session is locked by the LockDuration set on the Entity.
        /// </para>
        /// <para>
        /// Renewal of session renews all the messages in the session as well. Each individual message need not be renewed.
        /// </para>
        /// </remarks>
        Task RenewSessionLockAsync();
    }
}