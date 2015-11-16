// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    public static partial class DocumentsOperationsExtensions
    {
        /// <summary>
        /// Retrieves the next page of search results from the Azure Search index. 
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="continuationToken">
        /// Encapsulates the state required to fetch the next page of search results from the index.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
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
        public static DocumentSearchResult ContinueSearch(
            this IDocumentsOperations operations, 
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return Task.Factory.StartNew(s => ((IDocumentsOperations)s).ContinueSearchAsync(continuationToken, searchRequestOptions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves the next page of search results from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="continuationToken">
        /// Encapsulates the state required to fetch the next page of search results from the index.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
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
        public static async Task<DocumentSearchResult> ContinueSearchAsync(
            this IDocumentsOperations operations,
            SearchContinuationToken continuationToken, 
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DocumentSearchResult> result = await operations.ContinueSearchWithHttpMessagesAsync(continuationToken, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Retrieves the next page of search results from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="continuationToken">
        /// Encapsulates the state required to fetch the next page of search results from the index.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
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
        public static DocumentSearchResult<T> ContinueSearch<T>(
            this IDocumentsOperations operations, 
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
            where T : class
        {
            return Task.Factory.StartNew(s => ((IDocumentsOperations)s).ContinueSearchAsync<T>(continuationToken, searchRequestOptions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves the next page of search results from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="continuationToken">
        /// Encapsulates the state required to fetch the next page of search results from the index.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
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
        public static async Task<DocumentSearchResult<T>> ContinueSearchAsync<T>(
            this IDocumentsOperations operations,
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            AzureOperationResponse<DocumentSearchResult<T>> result = await operations.ContinueSearchWithHttpMessagesAsync<T>(continuationToken, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
