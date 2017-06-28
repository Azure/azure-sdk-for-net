// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The interface used to describe common functionality for receiving messages from Queues and Subscriptions.
    /// </summary>
    /// <remarks>
    /// The <see cref="IMessageReceiver" /> provides advanced functionality that is not found in the 
    /// <see cref="IQueueClient" /> or <see cref="ISubscriptionClient" />. For instance, 
    /// <see cref="ReceiveAsync()"/>, which allows you to receive messages on demand, but also requires
    /// you to manually renew locks using <see cref="RenewLockAsync(string)"/>.
    /// </remarks>
    public interface IMessageReceiver : IReceiverClient
    {
        /// <summary>Gets or sets the number of messages that the message receiver can simultaneously request.</summary>
        /// <value>The number of messages that the message receiver can simultaneously request.</value>
        /// <remarks> Takes effect on the next receive call to the server. </remarks>
        int PrefetchCount { get; set; }

        /// <summary>Gets the sequence number of the last peeked message.</summary>
        /// <value>The sequence number of the last peeked message.</value>
        long LastPeekedSequenceNumber { get; }

        /// <summary>
        /// Receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <returns>The asynchronous operation.</returns>
        Task<Message> ReceiveAsync();

        /// <summary>
        /// Receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="serverWaitTime">The time span the server waits for receiving a message before it times out.</param>
        /// <returns>The asynchronous operation.</returns>
        Task<Message> ReceiveAsync(TimeSpan serverWaitTime);

        /// <summary>
        /// Receives an <see cref="IList{Message}"/> of messages using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="maxMessageCount">The maximum number of messages to return in the <see cref="IList{Message}"/>.</param>
        /// <returns>The asynchronous operation.</returns>
        Task<IList<Message>> ReceiveAsync(int maxMessageCount);

        /// <summary>
        /// Receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="maxMessageCount">The maximum number of messages that will be received.</param>
        /// <param name="operationTimeout">The time span the server waits for receiving a message before it times out.</param>
        /// <returns>The asynchronous operation.</returns>
        Task<IList<Message>> ReceiveAsync(int maxMessageCount, TimeSpan operationTimeout);

        /// <summary>
        /// Receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="sequenceNumber">The sequence number of the message that will be received.</param>
        /// <returns>The asynchronous operation.</returns>
        Task<Message> ReceiveBySequenceNumberAsync(long sequenceNumber);

        /// <summary>
        /// Receives an <see cref="IList{Message}"/> of messages using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="sequenceNumbers">An <see cref="IEnumerable{T}"/> containing the sequence numbers to receive.</param>
        /// <returns>The asynchronous operation.</returns>
        Task<IList<Message>> ReceiveBySequenceNumberAsync(IEnumerable<long> sequenceNumbers);

        /// <summary>
        /// Completes a series of <see cref="Message"/> using a list of lock tokens.
        /// </summary>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.</remarks>
        /// <param name="lockTokens">An <see cref="IEnumerable{T}"/> containing the lock tokens of the corresponding messages to complete.</param>
        /// <returns>The asynchronous operation.</returns>
        Task CompleteAsync(IEnumerable<string> lockTokens);

        /// <summary>Indicates that the receiver wants to defer the processing for the message.</summary>
        /// <param name="lockToken">The lock token of the <see cref="Message" />.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>. 
        /// In order to receive this message again in the future, you will need to use <see cref="Message.SystemPropertiesCollection.SequenceNumber"/>.</remarks>
        /// <returns>The asynchronous operation.</returns>
        Task DeferAsync(string lockToken);

        /// <summary>
        /// Renews the lock on the message specified by the lock token. The lock will be renewed based on the setting specified on the queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the <see cref="Message" />.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemProperties"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.</remarks>
        /// <returns>The asynchronous operation.</returns>
        Task<DateTime> RenewLockAsync(string lockToken);

        /// <summary>
        /// Asynchronously reads the next message without changing the state of the receiver or the message source.
        /// </summary>
        /// <returns>The asynchronous operation that returns the <see cref="Message" /> that represents the next message to be read.</returns>
        Task<Message> PeekAsync();

        /// <summary>
        /// Asynchronously reads the next batch of message without changing the state of the receiver or the message source.
        /// </summary>
        /// <param name="maxMessageCount">The number of messages.</param>
        /// <returns>The asynchronous operation that returns a list of <see cref="Message" /> to be read.</returns>
        Task<IList<Message>> PeekAsync(int maxMessageCount);

        /// <summary>
        /// Asynchronously reads the next message without changing the state of the receiver or the message source.
        /// </summary>
        /// <param name="fromSequenceNumber">The sequence number from where to read the message.</param>
        /// <returns>The asynchronous operation that returns the <see cref="Message" /> that represents the next message to be read.</returns>
        Task<Message> PeekBySequenceNumberAsync(long fromSequenceNumber);

        /// <summary>Peeks a batch of messages.</summary>
        /// <param name="fromSequenceNumber">The starting point from which to browse a batch of messages.</param>
        /// <param name="messageCount">The number of messages.</param>
        /// <returns>A batch of messages peeked.</returns>
        Task<IList<Message>> PeekBySequenceNumberAsync(long fromSequenceNumber, int messageCount);
    }
}