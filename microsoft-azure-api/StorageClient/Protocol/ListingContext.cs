//-----------------------------------------------------------------------
// <copyright file="ListingContext.cs" company="Microsoft">
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
//    Contains code for the ListingContext class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    /// <summary>
    /// Represents the listing context for enumeration operations.
    /// </summary>
    public class ListingContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListingContext"/> class.
        /// </summary>
        /// <param name="prefix">The resource name prefix.</param>
        /// <param name="maxResults">The maximum number of resources to return in a single operation, up to the per-operation limit of 5000.</param>
        public ListingContext(string prefix, int? maxResults)
        {
            this.Prefix = prefix;
            this.MaxResults = maxResults;
            this.Marker = null;
        }

        /// <summary>
        /// Gets or sets the Prefix value.
        /// </summary>
        /// <value>The Prefix value.</value>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the MaxResults value.
        /// </summary>
        /// <value>The MaxResults value.</value>
        public int? MaxResults { get; set; }

        /// <summary>
        /// Gets or sets the Marker value.
        /// </summary>
        /// <value>The Marker value.</value>
        public string Marker { get; set; }
    }
}
