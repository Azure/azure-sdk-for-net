//-----------------------------------------------------------------------
// <copyright file="QueueEntry.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the QueueEntry class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Specialized;

    /// <summary>
    /// Represents a queue item returned in the XML response for a queue listing operation.
    /// </summary>
    public class QueueEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueEntry"/> class.
        /// </summary>
        /// <param name="name">The name of the queue.</param>
        /// <param name="attributes">The queue's attributes.</param>
        internal QueueEntry(string name, QueueAttributes attributes)
        {
            this.Name = name;
            this.Attributes = attributes;
        }

        /// <summary>
        /// Gets the name of the queue.
        /// </summary>
        /// <value>The queue name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the queue's attributes.
        /// </summary>
        /// <value>The queue's attributes.</value>
        public QueueAttributes Attributes { get; internal set; }
    }
}
