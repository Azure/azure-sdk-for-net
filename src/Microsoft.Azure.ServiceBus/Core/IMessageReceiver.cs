// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMessageReceiver : IReceiverClient
    {
        int PrefetchCount { get; set; }

        long LastPeekedSequenceNumber { get; }

        Task<Message> ReceiveAsync();

        /// <summary>
        /// Receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="serverWaitTime">The time span the server waits for receiving a message before it times out.</param>
        /// <returns>The asynchronous operation.</returns>
        Task<Message> ReceiveAsync(TimeSpan serverWaitTime);

        Task<IList<Message>> ReceiveAsync(int maxMessageCount);

        /// <summary>
        /// Receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="maxMessageCount">The maximum number of messages that will be received.</param>
        /// <param name="serverWaitTime">The time span the server waits for receiving a message before it times out.</param>
        /// <returns>The asynchronous operation.</returns>
        Task<IList<Message>> ReceiveAsync(int maxMessageCount, TimeSpan serverWaitTime);

        Task<Message> ReceiveBySequenceNumberAsync(long sequenceNumber);

        Task<IList<Message>> ReceiveBySequenceNumberAsync(IEnumerable<long> sequenceNumbers);

        Task CompleteAsync(IEnumerable<string> lockTokens);

        Task DeferAsync(string lockToken);

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