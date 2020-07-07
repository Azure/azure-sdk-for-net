// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs.Host.Queues
{
    /// <summary>
    /// Event argument class for when poison messages
    /// are added to a poison queue.
    /// </summary>
    public class PoisonMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="message">The poison message</param>
        /// <param name="poisonQueue">The poison queue</param>
        public PoisonMessageEventArgs(CloudQueueMessage message, CloudQueue poisonQueue)
        {
            Message = message;
            PoisonQueue = poisonQueue;
        }

        /// <summary>
        /// The poison message
        /// </summary>
        public CloudQueueMessage Message { get; private set; }

        /// <summary>
        /// The poison queue
        /// </summary>
        public CloudQueue PoisonQueue { get; private set; }
    }
}
