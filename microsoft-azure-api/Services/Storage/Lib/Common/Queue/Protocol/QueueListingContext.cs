// -----------------------------------------------------------------------------------------
// <copyright file="QueueListingContext.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    /// <summary>
    /// Provides a set of parameters for a queue listing operation.
    /// </summary>
#if RTMD
    internal
#else
    public
#endif
        sealed class QueueListingContext : ListingContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueListingContext"/> class.
        /// </summary>
        /// <param name="prefix">The queue prefix.</param>
        /// <param name="maxResults">The maximum number of results to return.</param>
        /// <param name="include">The include parameter.</param>
        public QueueListingContext(string prefix, int? maxResults, QueueListingDetails include)
            : base(prefix, maxResults)
        {
            this.Include = include;
        }

        /// <summary>
        /// Gets or sets the details for the listing operation, which indicates the types of data to include in the 
        /// response.
        /// </summary>
        /// <value>The details to include in the listing operation.</value>
        public QueueListingDetails Include { get; set; }
    }
}
