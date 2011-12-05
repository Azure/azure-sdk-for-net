//-----------------------------------------------------------------------
// <copyright file="QueueEntry.cs" company="Microsoft">
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
