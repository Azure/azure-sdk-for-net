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
        /// The total number of SQL filters across all subscriptions of the topic.
        /// </summary>
        /// <remarks>
        /// This count is served only by the 2024-05 (or later) service API version and by
        /// regions that have deployed the topic filter-count feature. When the client targets
        /// an earlier <see cref="ServiceBusAdministrationClientOptions.ServiceVersion"/>, or the
        /// region does not yet serve it, this value defaults to 0.
        /// </remarks>
        public int SqlFilterCount { get; internal set; }

        /// <summary>
        /// The total number of correlation filters across all subscriptions of the topic.
        /// </summary>
        /// <remarks>
        /// This count is served only by the 2024-05 (or later) service API version and by
        /// regions that have deployed the topic filter-count feature. When the client targets
        /// an earlier <see cref="ServiceBusAdministrationClientOptions.ServiceVersion"/>, or the
        /// region does not yet serve it, this value defaults to 0.
        /// </remarks>
        public int CorrelationFilterCount { get; internal set; }

        /// <summary>
        /// The number of messages that are scheduled to be enqueued.
        /// </summary>
        public long ScheduledMessageCount { get; internal set; }
    }
}
