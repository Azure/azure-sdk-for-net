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
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <param name="searchParameters">
        /// Parameters to further refine the search query.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Search, SearchAsync, and SearchWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static DocumentSearchResult Search(
            this IDocumentsOperations operations, 
            string searchText,
            SearchParameters searchParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return Task.Factory.StartNew(s => ((IDocumentsOperations)s).SearchAsync(searchText, searchParameters, searchRequestOptions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <param name="searchParameters">
        /// Parameters to further refine the search query.
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
        /// The non-generic overloads of the Search, SearchAsync, and SearchWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static async Task<DocumentSearchResult> SearchAsync(
            this IDocumentsOperations operations,
            string searchText,
            SearchParameters searchParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DocumentSearchResult> result = await operations.SearchWithHttpMessagesAsync(searchText, searchParameters ?? new SearchParameters(), searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <param name="searchParameters">
        /// Parameters to further refine the search query.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Search, SearchAsync, and SearchWithHttpMessagesAsync methods support mapping
        /// of Azure Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentSearchResult<T> Search<T>(
            this IDocumentsOperations operations,
            string searchText,
            SearchParameters searchParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
            where T : class
        {
            return Task.Factory.StartNew(s => ((IDocumentsOperations)s).SearchAsync<T>(searchText, searchParameters, searchRequestOptions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://msdn.microsoft.com/library/azure/dn798920.aspx"/> for more information about search
        /// query syntax.
        /// </param>
        /// <param name="searchParameters">
        /// Parameters to further refine the search query.
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
        /// The generic overloads of the Search, SearchAsync, and SearchWithHttpMessagesAsync methods support mapping
        /// of Azure Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static async Task<DocumentSearchResult<T>> SearchAsync<T>(
            this IDocumentsOperations operations,
            string searchText,
            SearchParameters searchParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            AzureOperationResponse<DocumentSearchResult<T>> result = await operations.SearchWithHttpMessagesAsync<T>(searchText, searchParameters ?? new SearchParameters(), searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
