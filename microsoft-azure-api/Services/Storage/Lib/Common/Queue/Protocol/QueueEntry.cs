// -----------------------------------------------------------------------------------------
// <copyright file="QueueEntry.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Queue.Protocol
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a queue item returned in the XML response for a queue listing operation.
    /// </summary>
#if RTMD
    internal
#else
    public
#endif
 sealed class QueueEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueEntry"/> class.
        /// </summary>
        internal QueueEntry()
        {
        }

        /// <summary>
        /// Gets the user-defined metadata for the queue.
        /// </summary>
        /// <value>The queue's metadata, as a collection of name-value pairs.</value>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Gets the name of the queue.
        /// </summary>
        /// <value>The queue's name.</value>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the queue's URI.
        /// </summary>
        /// <value>The absolute URI to the queue.</value>
        public Uri Uri { get; internal set; }
    }
}
