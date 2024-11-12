// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// This provides runtime properties of the subscription.
    /// </summary>
    public class SubscriptionRuntimeProperties
    {
        internal SubscriptionRuntimeProperties(string topicName, string subscriptionName)
        {
            TopicName = topicName;
            SubscriptionName = subscriptionName;
        }

        /// <summary>
        /// The name of the topic.
        /// </summary>
        public string TopicName { get; internal set; }

        /// <summary>
        /// The name of subscription.
        /// </summary>
        public string SubscriptionName { get; internal set; }

        /// <summary>
        /// The total number of messages in the subscription.
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
        /// The number of messages which are yet to be transferred/forwarded to destination entity.
        /// </summary>
        public long TransferMessageCount { get; internal set; }

        /// <summary>
        /// The number of messages transfer-messages which are dead-lettered into transfer-dead-letter subqueue.
        /// </summary>
        public long TransferDeadLetterMessageCount { get; internal set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> of the last time there was a receive request to this subscription.
        /// </summary>
        public DateTimeOffset AccessedAt { get; internal set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> when the entity was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; internal set; }

        /// <summary>
        /// The <see cref="DateTime"/> when the entity description was last updated.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; internal set; }
    }
}
