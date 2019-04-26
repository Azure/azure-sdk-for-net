// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The MessageReceiver can be used to receive messages from Queues and Subscriptions and acknowledge them.
    /// </summary>
    /// <example>
    /// Create a new MessageReceiver to receive a message from a Subscription
    /// <code>
    /// IMessageReceiver messageReceiver = new MessageReceiver(
    ///     namespaceConnectionString,
    ///     EntityNameHelper.FormatSubscriptionPath(topicName, subscriptionName),
    ///     ReceiveMode.PeekLock);
    /// </code>
    ///
    /// Receive a message from the Subscription.
    /// <code>
    /// var message = await messageReceiver.ReceiveAsync();
    /// await messageReceiver.CompleteAsync(message.SystemProperties.LockToken);
    /// </code>
    /// </example>
    /// <remarks>
    /// The MessageReceiver provides advanced functionality that is not found in the
    /// <see cref="QueueClient" /> or <see cref="SubscriptionClient" />. For instance,
    /// <see cref="ReceiveAsync()"/>, which allows you to receive messages on demand, but also requires
    /// you to manually renew locks using <see cref="RenewLockAsync(Message)"/>.
    /// </remarks>
    /// <seealso cref="MessageReceiver"/>
    /// <seealso cref="QueueClient"/>
    /// <seealso cref="SubscriptionClient"/>
    public interface IMessageReceiver : IReceiverClient
    {
        /// <summary>Gets the sequence number of the last peeked message.</summary>
        /// <seealso cref="PeekAsync()"/>
        long LastPeekedSequenceNumber { get; }

        /// <summary>
        /// Receive a message from the entity defined by <see cref="IClientEntity.Path"/> using <see cref="ReceiveMode"/> mode.
        /// </summary>
        /// <returns>The message received. Returns null if no message is found.</returns>
        /// <remarks>Operation will time out after duration of <see cref="ClientEntity.OperationTimeout"/></remarks>
        Task<Message> ReceiveAsync();

        /// <summary>
        /// Receive a message from the entity defined by <see cref="IClientEntity.Path"/> using <see cref="ReceiveMode"/> mode.
        /// </summary>
        /// <param name="operationTimeout">The time span the client waits for receiving a message before it times out.</param>
        /// <returns>The message received. Returns null if no message is found.</returns>
        /// <remarks>
        /// The parameter <paramref name="operationTimeout"/> includes the time taken by the receiver to establish a connection
        /// (either during the first receive or when connection needs to be re-established). If establishing the connection
        /// times out, this will throw <see cref="ServiceBusTimeoutException"/>.
        /// </remarks>
        Task<Message> ReceiveAsync(TimeSpan operationTimeout);

        /// <summary>
        /// Receives a maximum of <paramref name="maxMessageCount"/> messages from the entity defined by <see cref="IClientEntity.Path"/> using <see cref="ReceiveMode"/> mode.
        /// </summary>
        /// <param name="maxMessageCount">The maximum number of messages that will be received.</param>
        /// <returns>List of messages received. Returns null if no message is found.</returns>
        /// <remarks>Receiving less than <paramref name="maxMessageCount"/> messages is not an indication of empty entity.</remarks>
        Task<IList<Message>> ReceiveAsync(int maxMessageCount);

        /// <summary>
        /// Receives a maximum of <paramref name="maxMessageCount"/> messages from the entity defined by <see cref="IClientEntity.Path"/> using <see cref="ReceiveMode"/> mode.
        /// </summary>
        /// <param name="maxMessageCount">The maximum number of messages that will be received.</param>
        /// <param name="operationTimeout">The time span the client waits for receiving a message before it times out.</param>
        /// <returns>List of messages received. Returns null if no message is found.</returns>
        /// <remarks>Receiving less than <paramref name="maxMessageCount"/> messages is not an indication of empty entity.
        /// The parameter <paramref name="operationTimeout"/> includes the time taken by the receiver to establish a connection
        /// (either during the first receive or when connection needs to be re-established). If establishing the connection
        /// times out, this will throw <see cref="ServiceBusTimeoutException"/>.
        /// </remarks>
        Task<IList<Message>> ReceiveAsync(int maxMessageCount, TimeSpan operationTimeout);

        /// <summary>
        /// Receives a specific deferred message identified by <paramref name="sequenceNumber"/>.
        /// </summary>
        /// <param name="sequenceNumber">The sequence number of the message that will be received.</param>
        /// <returns>Message identified by sequence number <paramref name="sequenceNumber"/>. Returns null if no such message is found.
        /// Throws if the message has not been deferred.</returns>
        /// <seealso cref="DeferAsync"/>
        Task<Message> ReceiveDeferredMessageAsync(long sequenceNumber);

        /// <summary>
        /// Receives a <see cref="IList{Message}"/> of deferred messages identified by <paramref name="sequenceNumbers"/>.
        /// </summary>
        /// <param name="sequenceNumbers">An <see cref="IEnumerable{T}"/> containing the sequence numbers to receive.</param>
        /// <returns>Messages identified by sequence number are returned. Returns null if no messages are found.
        /// Throws if the messages have not been deferred.</returns>
        /// <seealso cref="DeferAsync"/>
        Task<IList<Message>> ReceiveDeferredMessageAsync(IEnumerable<long> sequenceNumbers);

        /// <summary>
        /// Completes a series of <see cref="Message"/> using a list of lock tokens. This will delete the message from the service.
        /// </summary>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// </remarks>
        /// <param name="lockTokens">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        /// This operation can only be performed on messages that were received by this receiver.
        Task CompleteAsync(IEnumerable<string> lockTokens);

        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        /// <param name="lockToken">The lock token of the <see cref="Message" />.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while deferring the message.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// In order to receive this message again in the future, you will need to save the <see cref="Message.SystemPropertiesCollection.SequenceNumber"/>
        /// and receive it using <see cref="ReceiveDeferredMessageAsync(long)"/>.
        /// Deferring messages does not impact message's expiration, meaning that deferred messages can still expire.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        Task DeferAsync(string lockToken, IDictionary<string, object> propertiesToModify = null);

        /// <summary>
        /// Renews the lock on the message. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        /// <remarks>
        /// When a message is received in <see cref="ServiceBus.ReceiveMode.PeekLock"/> mode, the message is locked on the server for this
        /// receiver instance for a duration as specified during the Queue/Subscription creation (LockDuration).
        /// If processing of the message requires longer than this duration, the lock needs to be renewed.
        /// For each renewal, it resets the time the message is locked by the LockDuration set on the Entity.
        /// </remarks>
        Task RenewLockAsync(Message message);

        /// <summary>
        /// Renews the lock on the message. The lock will be renewed based on the setting specified on the queue.
        /// <returns>New lock token expiry date and time in UTC format.</returns>
        /// </summary>
        /// <param name="lockToken">Lock token associated with the message.</param>
        /// <remarks>
        /// When a message is received in <see cref="ServiceBus.ReceiveMode.PeekLock"/> mode, the message is locked on the server for this
        /// receiver instance for a duration as specified during the Queue/Subscription creation (LockDuration).
        /// If processing of the message requires longer than this duration, the lock needs to be renewed.
        /// For each renewal, it resets the time the message is locked by the LockDuration set on the Entity.
        /// </remarks>
        Task<DateTime> RenewLockAsync(string lockToken);

        /// <summary>
        /// Fetches the next active message without changing the state of the receiver or the message source.
        /// </summary>
        /// <remarks>
        /// The first call to <see cref="PeekAsync()"/> fetches the first active message for this receiver. Each subsequent call
        /// fetches the subsequent message in the entity.
        /// Unlike a received messaged, peeked message will not have lock token associated with it, and hence it cannot be Completed/Abandoned/Deferred/Deadlettered/Renewed.
        /// Also, unlike <see cref="ReceiveAsync()"/>, this method will fetch even Deferred messages (but not Deadlettered message)
        /// </remarks>
        /// <returns>The <see cref="Message" /> that represents the next message to be read. Returns null when nothing to peek.</returns>
        Task<Message> PeekAsync();

        /// <summary>
        /// Fetches the next batch of active messages without changing the state of the receiver or the message source.
        /// </summary>
        /// <remarks>
        /// The first call to <see cref="PeekAsync()"/> fetches the first active message for this receiver. Each subsequent call
        /// fetches the subsequent message in the entity.
        /// Unlike a received message, peeked message will not have lock token associated with it, and hence it cannot be Completed/Abandoned/Deferred/Deadlettered/Renewed.
        /// Also, unlike <see cref="ReceiveAsync()"/>, this method will fetch even Deferred messages (but not Deadlettered message)
        /// </remarks>
        /// <returns>List of <see cref="Message" /> that represents the next message to be read. Returns null when nothing to peek.</returns>
        Task<IList<Message>> PeekAsync(int maxMessageCount);

        /// <summary>
        /// Asynchronously reads the next message without changing the state of the receiver or the message source.
        /// </summary>
        /// <param name="fromSequenceNumber">The sequence number from where to read the message.</param>
        /// <returns>The asynchronous operation that returns the <see cref="Message" /> that represents the next message to be read.</returns>
        Task<Message> PeekBySequenceNumberAsync(long fromSequenceNumber);

        /// <summary>Peeks a batch of messages.</summary>
        /// <param name="fromSequenceNumber">The starting point from which to browse a batch of messages.</param>
        /// <returns>A batch of messages peeked.</returns>
        Task<IList<Message>> PeekBySequenceNumberAsync(long fromSequenceNumber, int messageCount);
    }
}