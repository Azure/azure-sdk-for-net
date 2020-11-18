// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace Microsoft.Azure.WebJobs.Host.Queues
{
    /// <summary>
    /// Event argument class for when poison messages
    /// are added to a poison queue.
    /// </summary>
#if STORAGE_WEBJOBS_PUBLIC_QUEUE_PROCESSOR
    public class PoisonMessageEventArgs : EventArgs
#else
    internal class PoisonMessageEventArgs : EventArgs
#endif
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="message">The poison message</param>
        /// <param name="poisonQueue">The poison queue</param>
        public PoisonMessageEventArgs(QueueMessage message, QueueClient poisonQueue)
        {
            Message = message;
            PoisonQueue = poisonQueue;
        }

        /// <summary>
        /// The poison message
        /// </summary>
        public QueueMessage Message { get; private set; }

        /// <summary>
        /// The poison queue
        /// </summary>
        public QueueClient PoisonQueue { get; private set; }
    }
}
