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

    /// <summary>
    /// Defines operations for querying an index and uploading, merging, and deleting documents.
    /// <see href="https://msdn.microsoft.com/library/azure/dn800962.aspx" />
    /// </summary>
    public interface IDocumentsOperations
    {
        /// <summary>
        /// Queries the number of documents in the Azure Search index.
        /// </summary>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<long>> CountWithHttpMessagesAsync(
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), 
            Dictionary<string, List<string>> customHeaders = null, 
            CancellationToken cancellationToken = default(CancellationToken));

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
        /// <para>
        /// The non-generic overloads of the ContinueSearch, ContinueSearchAsync, and
        /// ContinueSearchWithHttpMessagesAsync methods make a best-effort attempt to map JSON types in the response
        /// payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </para>
        /// <para>
        /// If Azure Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <c cref="DocumentSearchResultBase&lt;TResult,TDoc&gt;.ContinuationToken">DocumentSearchResultBase.ContinuationToken</c>
        /// for more information.
        /// </para>
        /// <para>
        /// Note that this method is not meant to help you implement paging of search results. You can implement
        /// paging using the <c cref="SearchParameters.Top">Top</c> and <c cref="SearchParameters.Skip">Skip</c>
        /// parameters to the
        /// <c cref="IDocumentsOperations.SearchWithHttpMessagesAsync&lt;T&gt;(string, SearchParameters, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)">Search</c>
        /// method.
        /// </para>
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
        /// <para>
        /// The generic overloads of the ContinueSearch, ContinueSearchAsync, and ContinueSearchWithHttpMessagesAsync
        /// methods support mapping of Azure Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// If Azure Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <c cref="DocumentSearchResultBase&lt;TResult,TDoc&gt;.ContinuationToken">DocumentSearchResultBase.ContinuationToken</c>
        /// for more information.
        /// </para>
        /// <para>
        /// Note that this method is not meant to help you implement paging of search results. You can implement
        /// paging using the <c cref="SearchParameters.Top">Top</c> and <c cref="SearchParameters.Skip">Skip</c>
        /// parameters to the
        /// <c cref="IDocumentsOperations.SearchWithHttpMessagesAsync&lt;T&gt;(string, SearchParameters, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)">Search</c>
        /// method.
        /// </para>
        /// </remarks>
        Task<AzureOperationResponse<DocumentSearchResult<T>>> ContinueSearchWithHttpMessagesAsync<T>(
            SearchContinuationToken continuationToken,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class;

        /// <summary>
        /// Retrieves a document from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/>
        /// </summary>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will be missing from the
        /// returned document.
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
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods make a best-effort
        /// attempt to map JSON types in the response payload to .NET types. This mapping does not have the benefit of
        /// precise type information from the index, so the mapping is not always correct. In particular, be aware of
        /// the following cases:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Any numeric value without a decimal point will be deserialized to System.Int64 (long in C#).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Special double-precision floating point values such as NaN and Infinity will be deserialized as type
        /// System.String rather than System.Double.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any string field with a value formatted like a DateTimeOffset will be deserialized incorrectly. We
        /// recommend storing such values in Edm.DateTimeOffset fields rather than Edm.String fields.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any Edm.DateTimeOffset field will be deserialized as a System.DateTimeOffset, not System.DateTime.
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        Task<AzureOperationResponse<Document>> GetWithHttpMessagesAsync(
            string key, 
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null, 
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves a document from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will have null or default as its
        /// corresponding property value in the returned object.
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
        /// Response containing the document.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods support mapping of Azure
        /// Search field types to .NET types via the type parameter T. Note that all Azure Search field types except
        /// collections are nullable, so we recommend using nullable primitive types for the properties of type T.
        /// The type mapping is as follows:
        /// <list type="table">
        /// <listheader>
        /// <term>Azure Search field type</term>
        /// <description>.NET type</description>
        /// </listheader>
        /// <item>
        /// <term>Edm.String</term>
        /// <description>System.String (string in C#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.String)</term>
        /// <description>IEnumerable&lt;System.String&gt;</description>
        /// </item>
        /// <item>
        /// <term>Edm.Boolean</term>
        /// <description>System.Nullable&lt;System.Boolean&gt; (bool? in C#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Double</term>
        /// <description>System.Nullable&lt;System.Double&gt; (double? in C#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Int32</term>
        /// <description>System.Nullable&lt;System.Int32&gt; (int? in C#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Int64</term>
        /// <description>System.Nullable&lt;System.Int64&gt; (long? in C#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.DateTimeOffset</term>
        /// <description>
        /// System.Nullable&lt;System.DateTimeOffset&gt; (DateTimeOffset? in C#) or
        /// System.Nullable&lt;System.DateTime&gt; (DateTime? in C#). Both types work, although we recommend using
        /// DateTimeOffset. When retrieving documents, DateTime values will always be in UTC. When indexing documents,
        /// DateTime values are interpreted as follows:
        /// <list type="table">
        /// <item>
        /// <term>UTC DateTime</term>
        /// <description>Sent as-is to the index.</description>
        /// </item>
        /// <item>
        /// <term>Local DateTime</term>
        /// <description>Converted to UTC before being sent to the index.</description>
        /// </item>
        /// <item>
        /// <term>DateTime with unspecified time zone</term>
        /// <description>Assumed to be UTC and sent as-is to the index.</description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <term>Edm.GeographyPoint</term>
        /// <description><c cref="Microsoft.Spatial.GeographyPoint">Microsoft.Spatial.GeographyPoint</c></description>
        /// </item>
        /// </list> 
        /// </remarks>
        Task<AzureOperationResponse<T>> GetWithHttpMessagesAsync<T>(
            string key,
            IEnumerable<string> selectedFields,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class;

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/>
        /// </summary>
        /// <param name="batch">
        /// The batch of index actions.
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
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <c cref="IndexBatchException.IndexingResults">IndexResult</c> property. This property reports the status
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
        Task<AzureOperationResponse<DocumentIndexResult>> IndexWithHttpMessagesAsync(
            IndexBatch batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name="batch">
        /// The batch of index actions.
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
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <c cref="IndexBatchException.IndexingResults">IndexResult</c> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Index, IndexAsync, and IndexWithHttpMessagesAsync methods support mapping of
        /// Azure Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        Task<AzureOperationResponse<DocumentIndexResult>> IndexWithHttpMessagesAsync<T>(
            IndexBatch<T> batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class;

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
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
        /// <para>
        /// The non-generic overloads of the Search, SearchAsync, and SearchWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </para>
        /// <para>
        /// If Azure Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <c cref="DocumentSearchResultBase&lt;TResult,TDoc&gt;.ContinuationToken">DocumentSearchResultBase.ContinuationToken</c>
        /// for more information.
        /// </para>
        /// </remarks>
        Task<AzureOperationResponse<DocumentSearchResult>> SearchWithHttpMessagesAsync(
            string searchText,
            SearchParameters searchParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Searches for documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
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
        /// <para>
        /// The generic overloads of the Search, SearchAsync, and SearchWithHttpMessagesAsync methods support mapping
        /// of Azure Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// If Azure Search can't include all results in a single response, the response returned will include a
        /// continuation token that can be passed to ContinueSearch to retrieve more results.
        /// See <c cref="DocumentSearchResultBase&lt;TResult,TDoc&gt;.ContinuationToken">DocumentSearchResultBase.ContinuationToken</c>
        /// for more information.
        /// </para>
        /// </remarks>
        Task<AzureOperationResponse<DocumentSearchResult<T>>> SearchWithHttpMessagesAsync<T>(
            string searchText,
            SearchParameters searchParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class;

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798936.aspx"/>
        /// </summary>
        /// <param name="searchText">
        /// The search text on which to base suggestions.
        /// </param>
        /// <param name="suggestParameters">
        /// Parameters to further refine the suggestion query.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection that's part of the index definition.
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
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Suggest, SuggestAsync, and SuggestWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        Task<AzureOperationResponse<DocumentSuggestResult>> SuggestWithHttpMessagesAsync(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Suggests query terms based on input text and matching documents in the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798936.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
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
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// Response containing the suggested text and documents matching the query.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Suggest, SuggestAsync, and SuggestWithHttpMessagesAsync methods support
        /// mapping of Azure Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        Task<AzureOperationResponse<DocumentSuggestResult<T>>> SuggestWithHttpMessagesAsync<T>(
            string searchText,
            string suggesterName,
            SuggestParameters suggestParameters,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            Dictionary<string, List<string>> customHeaders = null,
            CancellationToken cancellationToken = default(CancellationToken)) where T : class;
    }
}
