// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface that defines common send functionality between different clients.
    /// </summary>
    /// <seealso cref="MessageSender"/>
    /// <seealso cref="QueueClient"/>
    /// <seealso cref="TopicClient"/>
    public interface SenderClient : ClientEntity
    {
        /// <summary>
        /// Sends a message to Service Bus.
        /// </summary>
        Task SendAsync(Message message);

        /// <summary>
        /// Sends a list of messages to Service Bus.
        /// </summary>
        Task SendAsync(IList<Message> messageList);

        /// <summary>
        /// Schedules a message to appear on Service Bus.
        /// </summary>
        /// <param name="scheduleEnqueueTimeUtc">The UTC time that the message should be available for processing</param>
        /// <returns>The sequence number of the message that was scheduled.</returns>
        Task<long> ScheduleMessageAsync(Message message, DateTimeOffset scheduleEnqueueTimeUtc);

        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="Message.SystemPropertiesCollection.SequenceNumber"/> of the message to be cancelled.</param>
        Task CancelScheduledMessageAsync(long sequenceNumber);
    }
}