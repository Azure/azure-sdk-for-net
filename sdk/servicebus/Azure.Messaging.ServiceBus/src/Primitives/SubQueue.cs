// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Represents the possible system subqueues that can be received from.
    /// </summary>
    public enum SubQueue
    {
        /// <summary>
        /// No subqueue, the queue itself will be received from.
        /// </summary>
        None = 0,

        /// <summary>
        /// The dead-letter subqueue contains messages that have been dead-lettered.
        /// <see href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-dead-letter-queues#moving-messages-to-the-dlq"/>
        /// </summary>
        DeadLetter = 1,

        /// <summary>
        /// The transfer dead-letter subqueue contains messages that have been dead-lettered when
        /// the following conditions apply:
        /// <list type="bullet">
        /// <item>
        /// <description>A message passes through more than four queues or topics that are chained together.</description>
        /// </item>
        /// <item>
        /// <description>The destination queue or topic is disabled or deleted.</description>
        /// </item>
        /// <item>
        /// <description>The destination queue or topic exceeds the maximum entity size.</description>
        /// </item>
        /// </list>
        /// <seealso href="https://learn.microsoft.com/azure/service-bus-messaging/service-bus-dead-letter-queues#dead-lettering-in-forwardto-or-sendvia-scenarios"/>
        /// </summary>
        TransferDeadLetter = 2
    }
}
