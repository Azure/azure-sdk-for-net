// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;

    /// <summary>
    /// This provides runtime information of the queue.
    /// </summary>
    public class QueueRuntimeInfo
    {
        internal QueueRuntimeInfo(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// The path of the queue.
        /// </summary>
        public string Path { get; internal set; }

        /// <summary>
        /// The total number of messages in the queue.
        /// </summary>
        public long MessageCount { get; internal set; }

        /// <summary>
        /// Message count details of the sub-queues of the entity.
        /// </summary>
        public MessageCountDetails MessageCountDetails { get; internal set; }

        /// <summary>
        /// Current size of the entity in bytes.
        /// </summary>
        public long SizeInBytes { get; internal set; }

        /// <summary>
        /// The <see cref="DateTime"/> when the entity was created.
        /// </summary>
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// The <see cref="DateTime"/> when the entity description was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; internal set; }

        /// <summary>
        /// The <see cref="DateTime"/> when the entity was last accessed.
        /// </summary>
        public DateTime AccessedAt { get; internal set; }
    }
}
