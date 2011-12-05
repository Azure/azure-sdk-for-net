//-----------------------------------------------------------------------
// <copyright file="BlobListingContext.cs" company="Microsoft">
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
//    Contains code for the BlobListingContext class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Provides a set of parameters for a blob listing operation.
    /// </summary>
    public class BlobListingContext : ListingContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobListingContext"/> class.
        /// </summary>
        /// <param name="prefix">The blob prefix.</param>
        /// <param name="maxResults">The maximum number of results to return.</param>
        /// <param name="delimiter">The blob delimiter.</param>
        /// <param name="include">The include parameter.</param>
        public BlobListingContext(string prefix, int? maxResults, string delimiter, BlobListingDetails include)
            : base(prefix, maxResults)
        {
            this.Delimiter = delimiter;
            this.Include = include;
        }

        /// <summary>
        /// Gets or sets the delimiter for a blob listing operation.
        /// </summary>
        /// <value>The delimiter to use to traverse the virtual hierarchy of blobs.</value>
        /// <remarks>
        /// The delimiter parameter enables the caller to traverse the blob namespace by using a user-configured delimiter. 
        /// Using this parameter, it is possible to traverse a virtual hierarchy of blobs as though it were a file system. 
        /// </remarks>
        public string Delimiter { get; set; }

        /// <summary>
        /// Gets or sets the details for the listing operation, which indicates the types of data to include in the 
        /// response.
        /// </summary>
        /// <value>The details to include in the listing operation.</value>
        /// <remarks>
        /// The include parameter specifies that the response should include one or more of the following subsets: snapshots,
        /// metadata, uncommitted blobs.
        /// </remarks>
        public BlobListingDetails Include { get; set; }
    }
}
