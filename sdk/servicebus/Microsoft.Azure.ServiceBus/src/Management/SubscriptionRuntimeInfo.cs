// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;

    /// <summary>
    /// This provides runtime information of the subscription.
    /// </summary>
    public class SubscriptionRuntimeInfo
    {
        internal SubscriptionRuntimeInfo(string topicPath, string subscriptionName)
        {
            this.TopicPath = topicPath;
            this.SubscriptionName = subscriptionName;
        }

        /// <summary>
        /// The path of the topic.
        /// </summary>
        public string TopicPath { get; internal set; }

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
        public MessageCountDetails MessageCountDetails { get; internal set; }

        /// <summary>
        /// The <see cref="DateTime"/> when the entity was last accessed.
        /// </summary>
        public DateTime AccessedAt { get; internal set; }

        /// <summary>
        /// The <see cref="DateTime"/> when the entity was created.
        /// </summary>
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// The <see cref="DateTime"/> when the entity description was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; internal set; }
    }
}
