// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    /// <summary>
    /// Message count details of the sub-queues of the entity.
    /// </summary>
    public class MessageCountDetails
    {
        /// <summary>
        /// The number of active messages in the entity.
        /// </summary>
        public long ActiveMessageCount { get; internal set; }

        /// <summary>
        /// The number of dead-lettered messages in the entity.
        /// </summary>
        public long DeadLetterMessageCount { get; internal set; }

        /// <summary>
        /// The number of messages which are yet to be scheduled.
        /// </summary>
        public long ScheduledMessageCount { get; internal set; }

        /// <summary>
        /// The number of messages which are yet to be transferred/forwarded to destination entity.
        /// </summary>
        public long TransferMessageCount { get; internal set; }

        /// <summary>
        /// The number of messages transfer-messages which are dead-lettered into transfer-dead-letter sub-queue.
        /// </summary>
        public long TransferDeadLetterMessageCount { get; internal set; }
    }
}
