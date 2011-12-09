//-----------------------------------------------------------------------
// <copyright file="QueueAttributes.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
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
