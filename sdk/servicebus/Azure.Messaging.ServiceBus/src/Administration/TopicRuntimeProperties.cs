// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// Represents the runtime properties of the topic.
    /// </summary>
    public class TopicRuntimeProperties
    {
        internal TopicRuntimeProperties(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The name of the topic.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The <see cref="DateTime"/> at which a message was last sent to the topic.
        /// </summary>
        public DateTimeOffset AccessedAt { get; internal set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> when the entity was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; internal set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> when the entity description was last updated.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; internal set; }

        /// <summary>
        /// The current size of the entity in bytes.
        /// </summary>
        public long SizeInBytes { get; internal set; }

        /// <summary>
        /// The number of subscriptions to the topic.
        /// </summary>
        public int SubscriptionCount { get; internal set; }

        /// <summary>
        /// The number of messages that are scheduled to be enqueued.
        /// </summary>
        public long ScheduledMessageCount { get; internal set; }
    }
}
