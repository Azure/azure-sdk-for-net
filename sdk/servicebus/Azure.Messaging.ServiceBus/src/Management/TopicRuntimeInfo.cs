﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    /// This provides runtime information of the topic.
    /// </summary>
    public class TopicRuntimeInfo
    {
        internal TopicRuntimeInfo(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The name of the topic.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The <see cref="DateTime"/> when the entity was last accessed.
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
        /// Current size of the entity in bytes.
        /// </summary>
        public long SizeInBytes { get; internal set; }

        /// <summary>
        /// Number of subscriptions to the topic.
        /// </summary>
        public int SubscriptionCount { get; internal set; }
    }
}
