// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    /// This provides runtime information of the queue.
    /// </summary>
    public class QueueRuntimeInfo
    {
        internal QueueRuntimeInfo(string name)
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
        public long MessageCount { get; internal set; }

        /// <summary>
        /// Message count details of the sub-queues of the entity.
        /// </summary>
        public MessageCountDetails CountDetails { get; internal set; }

        /// <summary>
        /// Current size of the entity in bytes.
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
        /// The <see cref="DateTimeOffset"/> when the entity was last accessed.
        /// </summary>
        public DateTimeOffset AccessedAt { get; internal set; }
    }
}
