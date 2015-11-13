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

    public partial interface IDocumentsOperations
    {
        /// <summary>
        /// Retrieves the next page of search results from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <param name="continuationToken">
        /// Encapsulates the state required to fetch the next page of search results from the index.
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
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the ContinueSearch, ContinueSearchAsync, and
        /// ContinueSearchWithHttpMessagesAsync methods make a best-effort attempt to map JSON types in the response
        /// payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        Task<AzureOperationResponse<DocumentSearchResult>> ContinueSearchWithHttpMessagesAsync(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves the next page of search results from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name="continuationToken">
        /// Encapsulates the state required to fetch the next page of search results from the index.
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
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the ContinueSearch, ContinueSearchAsync, and ContinueSearchWithHttpMessagesAsync
        /// methods support mapping of Azure Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        Task<AzureOperationResponse<DocumentSearchResult<T>>> ContinueSearchWithHttpMessagesAsync<T>(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class;
    }
}
