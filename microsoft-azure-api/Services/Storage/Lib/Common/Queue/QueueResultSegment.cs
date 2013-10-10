// -----------------------------------------------------------------------------------------
// <copyright file="QueueResultSegment.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Queue
{
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a segment of <see cref="CloudQueue"/> results, with continuation information for pagination scenarios.
    /// </summary>
    public sealed class QueueResultSegment
    {
        internal QueueResultSegment(IEnumerable<CloudQueue> queues, QueueContinuationToken continuationToken)
        {
            this.Results = queues;
            this.ContinuationToken = continuationToken;
        }

        /// <summary>
        /// Gets an enumerable collection of <see cref="CloudQueue"/> results.
        /// </summary>
        /// <value>An enumerable collection of results.</value>
        public IEnumerable<CloudQueue> Results { get; private set; }

        /// <summary>
        /// Gets the continuation token used to retrieve the next segment of <see cref="CloudQueue"/> results. Returns null if there are no more results.
        /// </summary>
        /// <value>The continuation token.</value>
        public QueueContinuationToken ContinuationToken { get; private set; }
    }
}
