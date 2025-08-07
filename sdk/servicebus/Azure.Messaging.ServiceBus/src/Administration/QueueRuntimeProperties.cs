// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// Represents the runtime properties of the queue.
    /// </summary>
    public class QueueRuntimeProperties
    {
        internal QueueRuntimeProperties(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The name of the queue.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The total number of messages in the queue.
        /// </summary>
        public long TotalMessageCount { get; internal set; }

        /// <summary>
        /// The number of active messages in the entity.
        /// </summary>
        public long ActiveMessageCount { get; internal set; }

        /// <summary>
        /// The number of dead-lettered messages in the entity.
        /// </summary>
        public long DeadLetterMessageCount { get; internal set; }

        /// <summary>
        /// The number of messages that are scheduled to be enqueued.
        /// </summary>
        public long ScheduledMessageCount { get; internal set; }

        /// <summary>
        /// The number of messages which are yet to be transferred/forwarded to destination entity.
        /// </summary>
        public long TransferMessageCount { get; internal set; }

        /// <summary>
        /// The number of messages transfer-messages which are dead-lettered into transfer-dead-letter subqueue.
        /// </summary>
        public long TransferDeadLetterMessageCount { get; internal set; }

        /// <summary>
        /// The current size of the entity in bytes.
        /// </summary>
        public long SizeInBytes { get; internal set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> when the entity was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; internal set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> when the entity description was last updated.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; internal set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> of the last time a message was sent or
        /// the last time there was a receive request to this queue.
        /// </summary>
        public DateTimeOffset AccessedAt { get; internal set; }
    }
}
