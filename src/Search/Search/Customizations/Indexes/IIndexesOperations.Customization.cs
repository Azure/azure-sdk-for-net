// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    public partial interface IIndexesOperations
    {
        /// <summary>
        /// Creates a new index client for querying and managing documents in a given index.
        /// </summary>
        /// <param name="indexName">The name of the index.</param>
        /// <returns>A new <c cref="Microsoft.Azure.Search.SearchIndexClient">SearchIndexClient</c> instance.</returns>
        /// <remarks>
        /// The new client is configured with full read-write access to the index. If you are only planning to use the
        /// client for query operations, we recommend directly creating a 
        /// <c cref="Microsoft.Azure.Search.SearchIndexClient">SearchIndexClient</c> instance instead.
        /// </remarks>
        SearchIndexClient GetClient(string indexName);
    }
}
