//-----------------------------------------------------------------------
// <copyright file="QueueMessage.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the QueueMessage class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a message retrieved from a queue.
    /// </summary>
    public class QueueMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMessage"/> class.
        /// </summary>
        internal QueueMessage()
        {
        }

        /// <summary>
        /// Gets the message expiration time.
        /// </summary>
        /// <value>The message expiration time.</value>
        public DateTime ExpirationTime { get; internal set; }

        /// <summary>
        /// Gets the message ID.
        /// </summary>
        /// <value>The message ID.</value>
        public string Id { get; internal set; }

        /// <summary>
        /// Gets the time the message was added to the queue.
        /// </summary>
        /// <value>The message insertion time.</value>
        public DateTime InsertionTime { get; internal set; }

        /// <summary>
        /// Gets the time the message is next visible.
        /// </summary>
        /// <value>The time the message is next visible.</value>
        public DateTime? TimeNextVisible { get; internal set; }

        /// <summary>
        /// Gets the pop receipt for the message.
        /// </summary>
        /// <value>The message's pop receipt.</value>
        public string PopReceipt { get; internal set; }

        /// <summary>
        /// Gets the text of the message.
        /// </summary>
        /// <value>The message text.</value>
        public string Text { get; internal set; }

        /// <summary>
        /// Gets the number of times this message has been dequeued.
        /// </summary>
        /// <value>The dequeue count.</value>
        public int DequeueCount { get; internal set; }
    }
}
