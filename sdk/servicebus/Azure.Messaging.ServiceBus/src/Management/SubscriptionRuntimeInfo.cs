// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    /// This provides runtime information of the subscription.
    /// </summary>
    public class SubscriptionRuntimeInfo
    {
        internal SubscriptionRuntimeInfo(string topicName, string subscriptionName)
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
        public long MessageCount { get; internal set; }

        /// <summary>
        /// Message count details of the sub-queues of the entity.
        /// </summary>
        public MessageCountDetails CountDetails { get; internal set; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> when the entity was last accessed.
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
