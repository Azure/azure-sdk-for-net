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

    /// <summary>
    /// Operations for querying an index and uploading, merging, and deleting documents.
    /// <see href="https://docs.microsoft.com/rest/api/searchservice/Document-operations" />
    /// </summary>
    public static class DocumentsOperationsExtensions
    {
        /// <summary>
        /// Queries the number of documents in the search index.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        public static long Count(
            this IDocumentsOperations operations,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.CountAsync(searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Queries the number of documents in the search index.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<long> CountAsync(
            this IDocumentsOperations operations,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CountWithHttpMessagesAsync(searchRequestOptions, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Queries the number of documents in the search index.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        public static AutocompleteResult Autocomplete(
            this IDocumentsOperations operations, 
            string searchText,
            string suggesterName,
            AutocompleteParameters autocompleteParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.AutocompleteAsync(searchText, suggesterName, autocompleteParameters, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Queries the number of documents in the search index.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<AutocompleteResult> AutocompleteAsync(
            this IDocumentsOperations operations,
            string searchText,
            string suggesterName,
            AutocompleteParameters autocompleteParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.AutocompleteWithHttpMessagesAsync(searchText, suggesterName, autocompleteParameters, searchRequestOptions, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Retrieves the next page of search results from the search index. 
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
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
        /// <para>
        /// The non-generic overloads of the ContinueSearch, ContinueSearchAsync, and
        /// ContinueSearchWithHttpMessagesAsync methods make a best-effort attempt to map JSON types in the response
        /// payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </para>
        /// <para>
        /// If Azure Cognitive Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <see cref="DocumentSearchResult&lt;T&gt;.ContinuationToken" />
        /// for more information.
        /// </para>
        /// <para>
        /// Note that this method is not meant to help you implement paging of search results. You can implement
        /// paging using the <see cref="SearchParameters.Top" /> and <see cref="SearchParameters.Skip" />
        /// parameters to the
        /// <see cref="IDocumentsOperations.SearchWithHttpMessagesAsync&lt;T&gt;(string, SearchParameters, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)" />
        /// method.
        /// </para>
        /// </remarks>
        public static DocumentSearchResult<Document> ContinueSearch(
            this IDocumentsOperations operations, 
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.ContinueSearchAsync(continuationToken, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves the next page of search results from the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
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
        /// <para>
        /// The non-generic overloads of the ContinueSearch, ContinueSearchAsync, and
        /// ContinueSearchWithHttpMessagesAsync methods make a best-effort attempt to map JSON types in the response
        /// payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </para>
        /// <para>
        /// If Azure Cognitive Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <see cref="DocumentSearchResult&lt;T&gt;.ContinuationToken" />
        /// for more information.
        /// </para>
        /// <para>
        /// Note that this method is not meant to help you implement paging of search results. You can implement
        /// paging using the <see cref="SearchParameters.Top" /> and <see cref="SearchParameters.Skip" />
        /// parameters to the
        /// <see cref="IDocumentsOperations.SearchWithHttpMessagesAsync&lt;T&gt;(string, SearchParameters, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)" />
        /// method.
        /// </para>
        /// </remarks>
        public static async Task<DocumentSearchResult<Document>> ContinueSearchAsync(
            this IDocumentsOperations operations,
            SearchContinuationToken continuationToken, 
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DocumentSearchResult<Document>> result = await operations.ContinueSearchWithHttpMessagesAsync(continuationToken, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Retrieves the next page of search results from the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
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
        /// <para>
        /// The generic overloads of the ContinueSearch, ContinueSearchAsync, and ContinueSearchWithHttpMessagesAsync
        /// methods support mapping of search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// If Azure Cognitive Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <see cref="DocumentSearchResult&lt;T&gt;.ContinuationToken" />
        /// for more information.
        /// </para>
        /// <para>
        /// Note that this method is not meant to help you implement paging of search results. You can implement
        /// paging using the <see cref="SearchParameters.Top" /> and <see cref="SearchParameters.Skip" />
        /// parameters to the
        /// <see cref="IDocumentsOperations.SearchWithHttpMessagesAsync&lt;T&gt;(string, SearchParameters, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)" />
        /// method.
        /// </para>
        /// </remarks>
        public static DocumentSearchResult<T> ContinueSearch<T>(
            this IDocumentsOperations operations, 
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.ContinueSearchAsync<T>(continuationToken, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves the next page of search results from the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
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
        /// <para>
        /// The generic overloads of the ContinueSearch, ContinueSearchAsync, and ContinueSearchWithHttpMessagesAsync
        /// methods support mapping of search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// If Azure Cognitive Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <see cref="DocumentSearchResult&lt;T&gt;.ContinuationToken" />
        /// for more information.
        /// </para>
        /// <para>
        /// Note that this method is not meant to help you implement paging of search results. You can implement
        /// paging using the <see cref="SearchParameters.Top" /> and <see cref="SearchParameters.Skip" />
        /// parameters to the
        /// <see cref="IDocumentsOperations.SearchWithHttpMessagesAsync&lt;T&gt;(string, SearchParameters, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)" />
        /// method.
        /// </para>
        /// </remarks>
        public static async Task<DocumentSearchResult<T>> ContinueSearchAsync<T>(
            this IDocumentsOperations operations,
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DocumentSearchResult<T>> result = await operations.ContinueSearchWithHttpMessagesAsync<T>(continuationToken, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Retrieves a document from the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/lookup-document">Lookup Document</see>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See 
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/naming-rules">Naming rules</see> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will be missing from the
        /// returned document. All retrievable fields are included in the result by default.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// The requested document.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods make a best-effort
        /// attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static Document Get(
            this IDocumentsOperations operations,
            string key,
            IEnumerable<string> selectedFields = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.GetAsync(key, selectedFields, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a document from the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/lookup-document">Lookup Document</see>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See 
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/naming-rules">Naming rules</see> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will be missing from the
        /// returned document.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The requested document.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods make a best-effort
        /// attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static async Task<Document> GetAsync(
            this IDocumentsOperations operations,
            string key,
            IEnumerable<string> selectedFields = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<Document> result = await operations.GetWithHttpMessagesAsync(key, selectedFields ?? DocumentsOperations.SelectAll, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Retrieves a document from the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/lookup-document">Lookup Document</see>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/naming-rules">Naming rules</see> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will have null or default as its
        /// corresponding property value in the returned object. All retrievable fields are included in the result by
        /// default.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// The requested document.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods support mapping of Azure
        /// Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static T Get<T>(
            this IDocumentsOperations operations,
            string key,
            IEnumerable<string> selectedFields = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.GetAsync<T>(key, selectedFields, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a document from the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/lookup-document">Lookup Document</see>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/naming-rules">Naming rules</see> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will have null or default as its
        /// corresponding property value in the returned object. All retrievable fields are included in the result by
        /// default.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The requested document.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods support mapping of Azure
        /// Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static async Task<T> GetAsync<T>(
            this IDocumentsOperations operations,
            string key,
            IEnumerable<string> selectedFields = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<T> result = await operations.GetWithHttpMessagesAsync<T>(key, selectedFields ?? DocumentsOperations.SelectAll, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents">Add, Update or Delete Documents</see>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <see cref="IndexBatchException.IndexingResults" /> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <remarks>
        /// The non-generic overloads of the Index, IndexAsync, and IndexWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        public static DocumentIndexResult Index(
            this IDocumentsOperations operations,
            IndexBatch<Document> batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.IndexAsync(batch, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents">Add, Update or Delete Documents</see>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <see cref="IndexBatchException.IndexingResults" /> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <remarks>
        /// The non-generic overloads of the Index, IndexAsync, and IndexWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        public static async Task<DocumentIndexResult> IndexAsync(
            this IDocumentsOperations operations,
            IndexBatch<Document> batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DocumentIndexResult> result = await operations.IndexWithHttpMessagesAsync(batch, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents">Add, Update or Delete Documents</see>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <see cref="IndexBatchException.IndexingResults" /> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Index and IndexAsync methods support mapping of search field types to
        /// .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentIndexResult Index<T>(
            this IDocumentsOperations operations,
            IndexBatch<T> batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.IndexAsync<T>(batch, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents">Add, Update or Delete Documents</see>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <see cref="IndexBatchException.IndexingResults" /> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Index and IndexAsync methods support mapping of search field types to
        /// .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static async Task<DocumentIndexResult> IndexAsync<T>(
            this IDocumentsOperations operations,
            IndexBatch<T> batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DocumentIndexResult> result = await operations.IndexWithHttpMessagesAsync<T>(batch, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Searches for documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://docs.microsoft.com/azure/search/query-simple-syntax">Simple query syntax in Azure Cognitive Search</see> for more information about search
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
        /// <para>
        /// The non-generic overloads of the Search, SearchAsync, and SearchWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </para>
        /// <para>
        /// If Azure Cognitive Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <see cref="DocumentSearchResult&lt;T&gt;.ContinuationToken" />
        /// for more information.
        /// </para>
        /// </remarks>
        public static DocumentSearchResult<Document> Search(
            this IDocumentsOperations operations,
            string searchText,
            SearchParameters searchParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.SearchAsync(searchText, searchParameters, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches for documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="searchText">
        /// A full-text search query expression; Use null or "*" to match all documents. See
        /// <see href="https://docs.microsoft.com/azure/search/query-simple-syntax">Simple query syntax in Azure Cognitive Search</see> for more information about search
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
        /// <para>
        /// The non-generic overloads of the Search, SearchAsync, and SearchWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </para>
        /// <para>
        /// If Azure Cognitive Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <see cref="DocumentSearchResult&lt;T&gt;.ContinuationToken" />
        /// for more information.
        /// </para>
        /// </remarks>
        public static async Task<DocumentSearchResult<Document>> SearchAsync(
            this IDocumentsOperations operations,
            string searchText,
            SearchParameters searchParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DocumentSearchResult<Document>> result = await operations.SearchWithHttpMessagesAsync(searchText, searchParameters ?? new SearchParameters(), searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Searches for documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
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
        /// <see href="https://docs.microsoft.com/azure/search/query-simple-syntax">Simple query syntax in Azure Cognitive Search</see> for more information about search
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
        /// <para>
        /// The generic overloads of the Search, SearchAsync, and SearchWithHttpMessagesAsync methods support mapping
        /// of search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// If Azure Cognitive Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <see cref="DocumentSearchResult&lt;T&gt;.ContinuationToken" />
        /// for more information.
        /// </para>
        /// </remarks>
        public static DocumentSearchResult<T> Search<T>(
            this IDocumentsOperations operations,
            string searchText,
            SearchParameters searchParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.SearchAsync<T>(searchText, searchParameters, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Searches for documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
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
        /// <see href="https://docs.microsoft.com/azure/search/query-simple-syntax">Simple query syntax in Azure Cognitive Search</see> for more information about search
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
        /// <para>
        /// The generic overloads of the Search, SearchAsync, and SearchWithHttpMessagesAsync methods support mapping
        /// of search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// If Azure Cognitive Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <see cref="DocumentSearchResult&lt;T&gt;.ContinuationToken" />
        /// for more information.
        /// </para>
        /// </remarks>
        public static async Task<DocumentSearchResult<T>> SearchAsync<T>(
            this IDocumentsOperations operations,
            string searchText,
            SearchParameters searchParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DocumentSearchResult<T>> result = await operations.SearchWithHttpMessagesAsync<T>(searchText, searchParameters ?? new SearchParameters(), searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/suggestions">Suggestions</see>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <param name="suggestParameters">
        /// Parameters to further refine the suggestion query.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Suggest, SuggestAsync, and SuggestWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static DocumentSuggestResult<Document> Suggest(
            this IDocumentsOperations operations,
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.SuggestAsync(searchText, suggesterName, suggestParameters, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/suggestions">Suggestions</see>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <param name="suggestParameters">
        /// Parameters to further refine the suggestion query.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Suggest, SuggestAsync, and SuggestWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static async Task<DocumentSuggestResult<Document>> SuggestAsync(
            this IDocumentsOperations operations,
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DocumentSuggestResult<Document>> result = await operations.SuggestWithHttpMessagesAsync(searchText, suggesterName, suggestParameters ?? new SuggestParameters(), searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/suggestions">Suggestions</see>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <param name="suggestParameters">
        /// Parameters to further refine the suggestion query.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Suggest, SuggestAsync, and SuggestWithHttpMessagesAsync methods support
        /// mapping of search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentSuggestResult<T> Suggest<T>(
            this IDocumentsOperations operations,
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.SuggestAsync<T>(searchText, suggesterName, suggestParameters, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/suggestions">Suggestions</see>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
        /// </param>
        /// <param name="suggestParameters">
        /// Parameters to further refine the suggestion query.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Suggest, SuggestAsync, and SuggestWithHttpMessagesAsync methods support
        /// mapping of search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static async Task<DocumentSuggestResult<T>> SuggestAsync<T>(
            this IDocumentsOperations operations,
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DocumentSuggestResult<T>> result = await operations.SuggestWithHttpMessagesAsync<T>(searchText, suggesterName, suggestParameters ?? new SuggestParameters(), searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
