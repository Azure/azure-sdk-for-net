//-----------------------------------------------------------------------
// <copyright file="QueueAttributes.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the QueueAttributes class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Represents a queue's attributes.
    /// </summary>
    public class QueueAttributes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueAttributes"/> class.
        /// </summary>
        public QueueAttributes()
        {
            this.Metadata = new NameValueCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueAttributes"/> class.
        /// </summary>
        /// <param name="other">The attributes to clone.</param>
        public QueueAttributes(QueueAttributes other)
        {
            if (other.Metadata != null)
            {
                this.Metadata = new NameValueCollection(other.Metadata);
            }
            else
            {
                this.Metadata = new NameValueCollection();
            }

            this.Uri = other.Uri;
        }

        /// <summary>
        /// Gets the queue's user-defined metadata.
        /// </summary>
        /// <value>The queue's user-defined metadata.</value>
        public NameValueCollection Metadata { get; internal set; }

        /// <summary>
        /// Gets the URI for the queue.
        /// </summary>
        /// <value>The queue's URI.</value>
        public Uri Uri { get; internal set; }
    }
}
