// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Models;

    public partial interface IIndexersOperations
    {
        /// <summary>
        /// Creates a new Azure Search indexer or updates an indexer if it already
        /// exists.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Create-Indexer" />
        /// </summary>
        /// <param name='indexer'>
        /// The definition of the indexer to create or update.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='accessCondition'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response.
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null.
        /// </exception>
        /// <returns>
        /// A response object containing the response body and response headers.
        /// </returns>
        Task<AzureOperationResponse<Indexer>> CreateOrUpdateWithHttpMessagesAsync(Indexer indexer, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Determines whether or not the given indexer exists in the Azure Search service.
        /// </summary>
        /// <param name="indexerName">
        /// The name of the indexer.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response.
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null.
        /// </exception>
        /// <returns>
        /// A response with the value <c>true</c> if the indexer exists; <c>false</c> otherwise.
        /// </returns>
        Task<AzureOperationResponse<bool>> ExistsWithHttpMessagesAsync(string indexerName, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
