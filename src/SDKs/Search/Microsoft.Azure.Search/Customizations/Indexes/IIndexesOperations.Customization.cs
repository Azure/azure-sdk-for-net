// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    public partial interface IIndexesOperations
    {
        /// <summary>
        /// Creates a new Azure Search index or updates an index if it already
        /// exists.
        /// </summary>
        /// <param name='index'>
        /// The definition of the index to create or update.
        /// </param>
        /// <param name='allowIndexDowntime'>
        /// Allows new analyzers, tokenizers, token filters, or char filters
        /// to be added to an index by taking the index offline for at least
        /// a few seconds. This temporarily causes indexing and query
        /// requests to fail. Performance and write availability of the index
        /// can be impaired for several minutes after the index is updated,
        /// or longer for very large indexes.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='accessCondition'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Index>> CreateOrUpdateWithHttpMessagesAsync(Index index, bool? allowIndexDowntime = default(bool?), SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Determines whether or not the given index exists in the Azure Search service.
        /// </summary>
        /// <param name="indexName">
        /// The name of the index.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// A response with the value <c>true</c> if the index exists; <c>false</c> otherwise.
        /// </returns>
        Task<AzureOperationResponse<bool>> ExistsWithHttpMessagesAsync(string indexName, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

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
        ISearchIndexClient GetClient(string indexName);
    }
}
