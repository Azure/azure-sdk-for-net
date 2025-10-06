// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to query an index and
    /// upload, merge, or delete documents.
    /// </summary>
    public class SearchClient
    {
        private readonly HttpPipeline _pipeline;
        private string _serviceName;

        /// <summary>
        /// Gets the URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// </summary>
        /// <remarks>
        /// This is not the URI of the Search Index.  You could construct that
        /// URI with "{Endpoint}/indexes/{IndexName}" if needed.
        /// </remarks>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// Gets the name of the Search Service.
        /// </summary>
        public virtual string ServiceName =>
            _serviceName ??= Endpoint.GetSearchServiceName();

        /// <summary>
        /// Gets the name of the Search Index.
        /// </summary>
        public virtual string IndexName { get; }

        /// <summary>
        /// Gets an <see cref="ObjectSerializer"/> that can be used to
        /// customize the serialization of strongly typed models.
        /// </summary>
        internal ObjectSerializer Serializer { get; }

        /// <summary>
        /// The HTTP pipeline for sending and receiving REST requests and responses.
        /// </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary>
        /// Gets the <see cref="Azure.Core.Pipeline.ClientDiagnostics"/> used
        /// to provide tracing support for the client library.
        /// </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary>
        /// Gets the REST API version of the Search Service to use when making
        /// requests.
        /// </summary>
        private SearchClientOptions.ServiceVersion Version { get; }

        /// <summary>
        /// Gets the generated document operations to make requests.
        /// </summary>
        private DocumentsRestClient Protocol { get; }

        #region ctors
        /// <summary>
        /// Initializes a new instance of the SearchClient class for
        /// mocking.
        /// </summary>
        protected SearchClient() { }

        /// <summary>
        /// Initializes a new instance of the SearchClient class for
        /// querying an index and uploading, merging, or deleting documents.
        /// </summary>
        /// <param name="endpoint">
        /// Required.  The URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="indexName">
        /// Required.  The name of the Search Index.
        /// </param>
        /// <param name="credential">
        /// Required.  The API key credential used to authenticate requests
        /// against the search service.  You need to use an admin key to
        /// modify the documents in a Search Index.  See
        /// <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see>
        /// for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="endpoint"/>,
        /// <paramref name="indexName"/>, or <paramref name="credential"/> is
        /// null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="endpoint"/> is not using HTTPS or
        /// the <paramref name="indexName"/> is empty.
        /// </exception>
        public SearchClient(
            Uri endpoint,
            string indexName,
            AzureKeyCredential credential) :
            this(endpoint, indexName, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SearchClient class for
        /// querying an index and uploading, merging, or deleting documents.
        /// </summary>
        /// <param name="endpoint">
        /// Required.  The URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="indexName">
        /// Required.  The name of the Search Index.
        /// </param>
        /// <param name="tokenCredential">
        /// Required.  The token credential used to authenticate requests against the Search service.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-rbac">Use role-based authorization in Azure Cognitive Search</see> for
        /// more information about role-based authorization in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="endpoint"/>,
        /// <paramref name="indexName"/>, or <paramref name="tokenCredential"/> is
        /// null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="endpoint"/> is not using HTTPS or
        /// the <paramref name="indexName"/> is empty.
        /// </exception>
        public SearchClient(
            Uri endpoint,
            string indexName,
            TokenCredential tokenCredential) :
            this(endpoint, indexName, tokenCredential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SearchClient class for
        /// querying an index and uploading, merging, or deleting documents.
        /// </summary>
        /// <param name="endpoint">
        /// Required.  The URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="indexName">
        /// Required.  The name of the Search Index.
        /// </param>
        /// <param name="credential">
        /// Required.  The API key credential used to authenticate requests
        /// against the search service.  You need to use an admin key to
        /// modify the documents in a Search Index.  See
        /// <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see>
        /// for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <param name="options">
        /// Client configuration options for connecting to Azure Cognitive
        /// Search.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="endpoint"/>,
        /// <paramref name="indexName"/>, or <paramref name="credential"/> is
        /// null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="endpoint"/> is not using HTTPS or
        /// the <paramref name="indexName"/> is empty.
        /// </exception>
        public SearchClient(
            Uri endpoint,
            string indexName,
            AzureKeyCredential credential,
            SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNullOrEmpty(indexName, nameof(indexName));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new SearchClientOptions();
            Endpoint = endpoint;
            IndexName = indexName;
            Serializer = options.Serializer;
            ClientDiagnostics = new ClientDiagnostics(options);
            _pipeline = options.Build(credential);
            Version = options.Version;

            Protocol = new DocumentsRestClient(
                ClientDiagnostics,
                _pipeline,
                endpoint.AbsoluteUri,
                indexName,
                null,
                Version.ToVersionString());
        }

        /// <summary>
        /// Initializes a new instance of the SearchClient class for
        /// querying an index and uploading, merging, or deleting documents.
        /// </summary>
        /// <param name="endpoint">
        /// Required.  The URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="indexName">
        /// Required.  The name of the Search Index.
        /// </param>
        /// <param name="tokenCredential">
        /// Required.  The token credential used to authenticate requests against the Search service.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-rbac">Use role-based authorization in Azure Cognitive Search</see> for
        /// more information about role-based authorization in Azure Cognitive Search.
        /// </param>
        /// <param name="options">
        /// Client configuration options for connecting to Azure Cognitive
        /// Search.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="endpoint"/>,
        /// <paramref name="indexName"/>, or <paramref name="tokenCredential"/> is
        /// null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="endpoint"/> is not using HTTPS or
        /// the <paramref name="indexName"/> is empty.
        /// </exception>
        public SearchClient(
            Uri endpoint,
            string indexName,
            TokenCredential tokenCredential,
            SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNullOrEmpty(indexName, nameof(indexName));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

            options ??= new SearchClientOptions();
            Endpoint = endpoint;
            IndexName = indexName;
            Serializer = options.Serializer;
            ClientDiagnostics = new ClientDiagnostics(options);
            _pipeline = options.Build(tokenCredential);
            Version = options.Version;

            Protocol = new DocumentsRestClient(
                ClientDiagnostics,
                _pipeline,
                endpoint.AbsoluteUri,
                indexName,
                null,
                Version.ToVersionString());
        }

        /// <summary>
        /// Initializes a new instance of the SearchClient class from a
        /// <see cref="SearchIndexClient"/>.
        /// </summary>
        /// <param name="endpoint">
        /// Required.  The URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="indexName">
        /// Required.  The name of the Search Index.
        /// </param>
        /// <param name="serializer">
        /// An optional customized serializer to use for search documents.
        /// </param>
        /// <param name="pipeline">
        /// The authenticated <see cref="HttpPipeline"/> used for sending
        /// requests to the Search Service.
        /// </param>
        /// <param name="diagnostics">
        /// The <see cref="Azure.Core.Pipeline.ClientDiagnostics"/> used to
        /// provide tracing support for the client library.
        /// </param>
        /// <param name="version">
        /// The REST API version of the Search Service to use when making
        /// requests.
        /// </param>
        internal SearchClient(
            Uri endpoint,
            string indexName,
            ObjectSerializer serializer,
            HttpPipeline pipeline,
            ClientDiagnostics diagnostics,
            SearchClientOptions.ServiceVersion version)
        {
            Debug.Assert(endpoint != null);
            Debug.Assert(string.Equals(endpoint.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase));
            Debug.Assert(!string.IsNullOrEmpty(indexName));
            Debug.Assert(pipeline != null);
            Debug.Assert(diagnostics != null);
            Debug.Assert(
                SearchClientOptions.ServiceVersion.V2020_06_30 <= version &&
                version <= SearchClientOptions.LatestVersion);

            Endpoint = endpoint;
            IndexName = indexName;
            Serializer = serializer;
            ClientDiagnostics = diagnostics;
            _pipeline = pipeline;
            Version = version;

            Protocol = new DocumentsRestClient(
                ClientDiagnostics,
                _pipeline,
                endpoint.AbsoluteUri,
                IndexName,
                null,
                Version.ToVersionString());
        }

        /// <summary>
        /// Get a SearchIndexClient with the same pipeline.
        /// </summary>
        /// <returns>A SearchIndexClient.</returns>
        internal SearchIndexClient GetSearchIndexClient() =>
            new SearchIndexClient(
                Endpoint,
                Serializer,
                _pipeline,
                ClientDiagnostics,
                Version);
        #endregion ctors

        #region GetDocumentCount
        /// <summary>
        /// Retrieves a count of the number of documents in this search index.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>The number of documents in the search index.</returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        public virtual Response<long> GetDocumentCount(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(GetDocumentCount)}");
            scope.Start();
            try
            {
                return Protocol.Count(
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves a count of the number of documents in this search index.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>The number of documents in the search index.</returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        public virtual async Task<Response<long>> GetDocumentCountAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(GetDocumentCount)}");
            scope.Start();
            try
            {
                return await Protocol.CountAsync(
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion GetDocumentCount

        #region GetDocument
        /// <summary>
        /// Retrieves a document from Azure Cognitive Search.  This is useful
        /// when a user clicks on a specific search result, and you want to
        /// look up specific details about that document. You can only get one
        /// document at a time.  Use Search to get multiple documents in a
        /// single request.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/lookup-document">Lookup Document</see>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="key">
        /// Required.  An string value that uniquely identifies each document
        /// in the index.  The key is sometimes referred to as a document ID.
        /// See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/naming-rules">Naming rules</see>
        /// for the rules for constructing valid document keys.
        /// </param>
        /// <param name="options">
        /// Options to customize the operation's behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// The document corresponding to the <paramref name="key"/>.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// The generic overloads of the <see cref="GetDocument"/> and
        /// <see cref="GetDocumentAsync"/> methods support mapping of Azure
        /// Search field types to .NET types via the type parameter
        /// <typeparamref name="T"/>.  Note that all search field types except
        /// collections are nullable, so we recommend using nullable types for
        /// the properties of <typeparamref name="T"/>. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public virtual Response<T> GetDocument<T>(
            string key,
            GetDocumentOptions options = null,
            CancellationToken cancellationToken = default) =>
            GetDocumentInternal<T>(
                key,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Retrieves a document from Azure Cognitive Search.  This is useful
        /// when a user clicks on a specific search result, and you want to
        /// look up specific details about that document. You can only get one
        /// document at a time.  Use Search to get multiple documents in a
        /// single request.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/lookup-document">Lookup Document</see>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="key">
        /// Required.  An string value that uniquely identifies each document
        /// in the index.  The key is sometimes referred to as a document ID.
        /// See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/naming-rules">Naming rules</see>
        /// for the rules for constructing valid document keys.
        /// </param>
        /// <param name="options">
        /// Options to customize the operation's behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// The document corresponding to the <paramref name="key"/>.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// The <see cref="GetDocument"/> and <see cref="GetDocumentAsync"/>
        /// methods support mapping of Azure Search field types to .NET types
        /// via the type parameter <typeparamref name="T"/>.  Note that all
        /// search field types except collections are nullable, so we recommend
        /// using nullable types for the properties of <typeparamref name="T"/>.
        /// The type mapping is as follows:
        /// <list type="table">
        /// <listheader>
        /// <term>Search field type</term>
        /// <description>.NET type</description>
        /// </listheader>
        /// <item>
        /// <term>Edm.String</term>
        /// <description><see cref="String"/> (string in C# and F#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Boolean</term>
        /// <description><see cref="Nullable{Boolean}"/> (bool? in C#,\
        /// Nullable&lt;bool&gt; in F#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Double</term>
        /// <description><see cref="Nullable{Double}"/> (double? in C#,
        /// Nullable&lt;float&gt; in F#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Int32</term>
        /// <description><see cref="Nullable{Int32}"/> (int? in C#,
        /// Nullable&lt;int&gt; in F#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Int64</term>
        /// <description><see cref="Nullable{Int64}"/> (long? in C#,
        /// Nullable&lt;int64&gt; in F#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.DateTimeOffset</term>
        /// <description>
        /// <see cref="Nullable{DateTimeOffset}"/> (DateTimeOffset? in
        /// C#, Nullable&lt;DateTimeOffset&gt; in F#) or
        /// System.Nullable&lt;System.DateTime&gt; (DateTime? in C#,
        /// Nullable&lt;DateTime&gt; in F#). Both types work, although we
        /// recommend using DateTimeOffset.  When retrieving documents,
        /// DateTime values will always be in UTC. When indexing documents,
        /// DateTime values are interpreted as follows:
        /// <list type="table">
        /// <item>
        /// <term>UTC DateTime</term>
        /// <description>Sent as-is to the index.</description>
        /// </item>
        /// <item>
        /// <term>Local DateTime</term>
        /// <description>Converted to UTC before being sent to the index.
        /// </description>
        /// </item>
        /// <item>
        /// <term>DateTime with unspecified time zone</term>
        /// <description>Assumed to be UTC and sent as-is to the index.
        /// </description>
        /// </item>
        /// </list>
        /// </description>
        /// </item>
        /// <item>
        /// <term>Edm.GeographyPoint</term>
        /// <description> Azure.Core.GeoJson.GeoPoint
        /// </description>
        /// </item>
        /// <item>
        /// <term>Edm.ComplexType</term>
        /// <description>
        /// Any type that can be deserialized from the JSON objects in the
        /// complex field.  This can be a value type or a reference type, but
        /// we recommend using a reference type since complex fields are
        /// nullable in Azure Cognitive Search.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.String)</term>
        /// <description><see cref="IEnumerable{String}"/> (seq&lt;string&gt;
        /// in F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.Boolean)</term>
        /// <description><see cref="IEnumerable{Boolean}"/> (seq&lt;bool&gt; in
        /// F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.Double)</term>
        /// <description><see cref="IEnumerable{Double}"/> (seq&lt;float&gt; in
        /// F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.Int32)</term>
        /// <description><see cref="IEnumerable{Int32}"/> (seq&lt;int&gt; in
        /// F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.Int64)</term>
        /// <description><see cref="IEnumerable{Int64}"/> (seq&lt;int64&gt; in
        /// F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.DateTimeOffset)</term>
        /// <description>
        /// <see cref="IEnumerable{DateTimeOffset}"/> or
        /// <see cref="IEnumerable{DateTime}"/> (seq&lt;DateTimeOffset&gt; or
        /// seq&lt;DateTime&gt; in F#). Both types work, although we recommend
        /// using <see cref="IEnumerable{DateTimeOffset}"/>.  See the notes
        /// above on Edm.DateTimeOffset for details.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.GeographyPoint)</term>
        /// <description>sequence of Azure.Core.GeoJson.GeoPoint
        /// (seq&lt;GeoPoint&gt; in F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.ComplexType)</term>
        /// <description>
        /// <see cref="IEnumerable{T}"/> (seq&lt;T&gt; in F#) where T is any
        /// type that can be deserialized from the JSON objects in the complex
        /// collection field. This can be a value type or a reference type.
        /// </description>
        /// </item>
        /// </list>
        /// You can also use the dynamic <see cref="SearchDocument"/> as your
        /// <typeparamref name="T"/> and we will attempt to map JSON types in
        /// the response payload to .NET types. This mapping does not
        /// have the benefit of precise type information from the index, so the
        /// mapping is not always correct. In particular, be aware of the
        /// following cases:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Any numeric value without a decimal point will be deserialized to
        /// a <see cref="Int32"/> (int in C#, int32 in F#) if it can be
        /// converted or a <see cref="Int64"/> (long in C#, int64 in F#)
        /// otherwise.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Special double-precision floating point values such as NaN and
        /// Infinity will be deserialized as type <see cref="String"/> rather
        /// than <see cref="Double"/>, even if they are in arrays with regular
        /// floating point values.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any Edm.DateTimeOffset field will be deserialized as a
        /// <see cref="DateTimeOffset"/>, not <see cref="DateTime"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any empty JSON array will be deserialized as an array of
        /// <see cref="Object"/> (object[] in C#, obj[] in F#).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Complex fields will be recursively deserialized into instances of
        /// type <see cref="SearchDocument"/>.  Similarly, complex collection
        /// fields will be deserialized into arrays of such instances.
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        public virtual async Task<Response<T>> GetDocumentAsync<T>(
            string key,
            GetDocumentOptions options = null,
            CancellationToken cancellationToken = default) =>
            await GetDocumentInternal<T>(
                key,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        private async Task<Response<T>> GetDocumentInternal<T>(
            string key,
            GetDocumentOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            if (key == null)
            { throw new ArgumentNullException(nameof(key)); }
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(GetDocument)}");
            scope.Start();
            try
            {
                using HttpMessage message = Protocol.CreateGetRequest(key, options?.SelectedFieldsOrNull);
                if (async)
                {
                    await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _pipeline.Send(message, cancellationToken);
                }
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            T value = await message.Response.ContentStream.DeserializeAsync<T>(
                                Serializer,
                                async,
                                cancellationToken)
                                .ConfigureAwait(false);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new RequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        #endregion Get

        #region Search
        /// <summary>
        /// Searches for documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="searchText">
        /// A full-text search query expression;  Use "*" or omit this
        /// parameter to match all documents.  See
        /// <see href="https://docs.microsoft.com/azure/search/query-simple-syntax">Simple query syntax in Azure Cognitive Search</see>
        /// for more information about search query syntax.
        /// </param>
        /// <param name="options">
        /// Options that allow specifying filtering, sorting, faceting, paging,
        /// and other search query behaviors.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// Search and SearchAsync methods support mapping of search field
        /// types to .NET types via the type parameter T.  You can provide your
        /// own type <typeparamref name="T"/> or use the dynamic
        /// <see cref="SearchDocument"/>. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// Azure Cognitive Search might not be able to include all results in
        /// a single response in which case <see cref="SearchResults{T}.GetResults"/>
        /// will automatically continue making additional requests as you
        /// enumerate through the results.  You can also process the results a
        /// page at a time with the <see cref="Pageable{T}.AsPages(string, int?)"/>
        /// method.
        /// </para>
        /// </remarks>
        public virtual Response<SearchResults<T>> Search<T>(
            string searchText,
            SearchOptions options = null,
            CancellationToken cancellationToken = default) =>
            SearchInternal<T>(
                searchText,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Searches for documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="searchText">
        /// A full-text search query expression;  Use "*" or omit this
        /// parameter to match all documents.  See
        /// <see href="https://docs.microsoft.com/azure/search/query-simple-syntax">Simple query syntax in Azure Cognitive Search</see>
        /// for more information about search query syntax.
        /// </param>
        /// <param name="options">
        /// Options that allow specifying filtering, sorting, faceting, paging,
        /// and other search query behaviors.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// Search and SearchAsync methods support mapping of search field
        /// types to .NET types via the type parameter T.  You can provide your
        /// own type <typeparamref name="T"/> or use the dynamic
        /// <see cref="SearchDocument"/>. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// Azure Cognitive Search might not be able to include all results in
        /// a single response in which case
        /// <see cref="SearchResults{T}.GetResultsAsync"/> will automatically
        /// continue making additional requests as you enumerate through the
        /// results.  You can also process the results a page at a time with
        /// the <see cref="AsyncPageable{T}.AsPages(string, int?)"/> method.
        /// </para>
        /// </remarks>
        public async virtual Task<Response<SearchResults<T>>> SearchAsync<T>(
            string searchText,
            SearchOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SearchInternal<T>(
                searchText,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Searches for documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="options">
        /// Options that allow specifying filtering, sorting, faceting, paging,
        /// and other search query behaviors.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// Search and SearchAsync methods support mapping of search field
        /// types to .NET types via the type parameter T.  You can provide your
        /// own type <typeparamref name="T"/> or use the dynamic
        /// <see cref="SearchDocument"/>. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// Azure Cognitive Search might not be able to include all results in
        /// a single response in which case <see cref="SearchResults{T}.GetResults"/>
        /// will automatically continue making additional requests as you
        /// enumerate through the results.  You can also process the results a
        /// page at a time with the <see cref="Pageable{T}.AsPages(string, int?)"/>
        /// method.
        /// </para>
        /// </remarks>
        public virtual Response<SearchResults<T>> Search<T>(
            SearchOptions options,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return SearchInternal<T>(
                null,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();
        }

        /// <summary>
        /// Searches for documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/search-documents">Search Documents</see>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="options">
        /// Options that allow specifying filtering, sorting, faceting, paging,
        /// and other search query behaviors.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the documents matching the query.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// Search and SearchAsync methods support mapping of search field
        /// types to .NET types via the type parameter T.  You can provide your
        /// own type <typeparamref name="T"/> or use the dynamic
        /// <see cref="SearchDocument"/>. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// Azure Cognitive Search might not be able to include all results in
        /// a single response in which case
        /// <see cref="SearchResults{T}.GetResultsAsync"/> will automatically
        /// continue making additional requests as you enumerate through the
        /// results.  You can also process the results a page at a time with
        /// the <see cref="AsyncPageable{T}.AsPages(string, int?)"/> method.
        /// </para>
        /// </remarks>
        public async virtual Task<Response<SearchResults<T>>> SearchAsync<T>(
            SearchOptions options,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return await SearchInternal<T>(
                null,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private async Task<Response<SearchResults<T>>> SearchInternal<T>(
            string searchText,
            SearchOptions options,
            bool async,
            CancellationToken cancellationToken = default)
        {
            if (options != null && searchText != null)
            {
                options = options.Clone();
                options.SearchText = searchText;
            }
            else if (options == null)
            {
                options = new SearchOptions() { SearchText = searchText };
            }
            return await SearchInternal<T>(
                options,
                $"{nameof(SearchClient)}.{nameof(Search)}",
                async,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private async Task<Response<SearchResults<T>>> SearchInternal<T>(
            SearchOptions options,
            string operationName,
            bool async,
            CancellationToken cancellationToken = default)
        {
            Debug.Assert(options != null);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope(operationName);
            scope.Start();
            try
            {
                using HttpMessage message = Protocol.CreateSearchPostRequest(options);
                if (async)
                {
                    await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _pipeline.Send(message, cancellationToken);
                }
                switch (message.Response.Status)
                {
                    case 200:
                    case 206:
                        {
                            // Deserialize the results
                            SearchResults<T> results = await SearchResults<T>.DeserializeAsync(
                                message.Response.ContentStream,
                                Serializer,
                                async,
                                cancellationToken)
                                .ConfigureAwait(false);

                            // Cache the client and raw response so we can abstract
                            // away server-side paging
                            results.ConfigurePaging(this, message.Response);

                            return Response.FromValue(results, message.Response);
                        }
                    default:
                        throw new RequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        #endregion Search

        #region Suggest
        /// <summary>
        /// Executes a "search-as-you-type" query consisting of a partial text
        /// input (three character minimum).  It returns matching text found in
        /// suggester-aware fields.  Azure Cognitive Search looks for matching
        /// values in fields that are predefined in a Suggester.  For example,
        /// if you enable suggestions on a city field, typing "sea" produces
        /// documents containing "Seattle", "Sea Tac", and "Seaside" (all
        /// actual city names) for that field.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/suggestions">Suggestions</see>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="searchText">
        /// The search text to use to suggest documents. Must be at least 1
        /// character, and no more than 100 characters.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection
        /// that's part of the index definition.
        /// </param>
        /// <param name="options">
        /// Options for filtering, sorting, and other suggestions query
        /// behaviors.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing suggestion query results from an index.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// Suggest and SuggestAsync methods support mapping of search field
        /// types to .NET types via the type parameter T.  You can provide your
        /// own type <typeparamref name="T"/> or use the dynamic
        /// <see cref="SearchDocument"/>. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public virtual Response<SuggestResults<T>> Suggest<T>(
            string searchText,
            string suggesterName,
            SuggestOptions options = null,
            CancellationToken cancellationToken = default) =>
            SuggestInternal<T>(
                searchText,
                suggesterName,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Executes a "search-as-you-type" query consisting of a partial text
        /// input (three character minimum).  It returns matching text found in
        /// suggester-aware fields.  Azure Cognitive Search looks for matching
        /// values in fields that are predefined in a Suggester.  For example,
        /// if you enable suggestions on a city field, typing "sea" produces
        /// documents containing "Seattle", "Sea Tac", and "Seaside" (all
        /// actual city names) for that field.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/suggestions">Suggestions</see>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="searchText">
        /// The search text to use to suggest documents. Must be at least 1
        /// character, and no more than 100 characters.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection
        /// that's part of the index definition.
        /// </param>
        /// <param name="options">
        /// Options for filtering, sorting, and other suggestions query
        /// behaviors.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing suggestion query results from an index.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// Suggest and SuggestAsync methods support mapping of search field
        /// types to .NET types via the type parameter T.  You can provide your
        /// own type <typeparamref name="T"/> or use the dynamic
        /// <see cref="SearchDocument"/>. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public virtual async Task<Response<SuggestResults<T>>> SuggestAsync<T>(
            string searchText,
            string suggesterName,
            SuggestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SuggestInternal<T>(
                searchText,
                suggesterName,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        private async Task<Response<SuggestResults<T>>> SuggestInternal<T>(
            string searchText,
            string suggesterName,
            SuggestOptions options,
            bool async,
            CancellationToken cancellationToken = default)
        {
            options = options != null ? options.Clone() : new SuggestOptions();
            options.SearchText = searchText;
            options.SuggesterName = suggesterName;

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(Suggest)}");
            scope.Start();
            try
            {
                using HttpMessage message = Protocol.CreateSuggestPostRequest(options);
                if (async)
                {
                    await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _pipeline.Send(message, cancellationToken);
                }
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            SuggestResults<T> suggestions = await SuggestResults<T>.DeserializeAsync(
                                message.Response.ContentStream,
                                Serializer,
                                async,
                                cancellationToken)
                                .ConfigureAwait(false);
                            return Response.FromValue(suggestions, message.Response);
                        }
                    default:
                        throw new RequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        #endregion Suggest

        #region Autocomplete
        /// <summary>
        /// Suggests query terms based on input text and matching documents in
        /// the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/autocomplete">Autocomplete</see>
        /// </summary>
        /// <param name="searchText">
        /// The search text on which to base autocomplete results.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection
        /// that's part of the index definition.
        /// </param>
        /// <param name="options">
        /// Options that allow specifying autocomplete behaviors, like fuzzy
        /// matching.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>The result of Autocomplete query.</returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        public virtual Response<AutocompleteResults> Autocomplete(
            string searchText,
            string suggesterName,
            AutocompleteOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(Autocomplete)}");
            scope.Start();
            try
            {
                return AutocompleteInternal(
                    searchText,
                    suggesterName,
                    options,
                    async: false,
                    cancellationToken)
                    .EnsureCompleted();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Suggests query terms based on input text and matching documents in
        /// the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/autocomplete">Autocomplete</see>
        /// </summary>
        /// <param name="searchText">
        /// The search text on which to base autocomplete results.
        /// </param>
        /// <param name="suggesterName">
        /// The name of the suggester as specified in the suggesters collection
        /// that's part of the index definition.
        /// </param>
        /// <param name="options">
        /// Options that allow specifying autocomplete behaviors, like fuzzy
        /// matching.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>The result of Autocomplete query.</returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        public virtual async Task<Response<AutocompleteResults>> AutocompleteAsync(
            string searchText,
            string suggesterName,
            AutocompleteOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(Autocomplete)}");
            scope.Start();
            try
            {
                return await AutocompleteInternal(
                    searchText,
                    suggesterName,
                    options,
                    async: true,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private async Task<Response<AutocompleteResults>> AutocompleteInternal(
            string searchText,
            string suggesterName,
            AutocompleteOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            options = options != null ? options.Clone() : new AutocompleteOptions();
            options.SearchText = searchText;
            options.SuggesterName = suggesterName;

            return async ?
                await Protocol.AutocompletePostAsync(options, cancellationToken).ConfigureAwait(false) :
                Protocol.AutocompletePost(options, cancellationToken);
        }
        #endregion Autocomplete

        #region IndexDocuments
        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the search
        /// index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents">Add, Update or Delete Documents</see>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="batch">
        /// The batch of document index actions.
        /// </param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// The generic overloads of the IndexDocuments and IndexDocumentsAsync
        /// methods support mapping of search field types to .NET types via the
        /// type parameter T. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// individual <see cref="RequestFailedException"/>s wrapped into an
        /// <see cref="AggregateException"/> that's thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual Response<IndexDocumentsResult> IndexDocuments<T>(
            IndexDocumentsBatch<T> batch,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexDocumentsInternal<T>(
                batch,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the search
        /// index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents">Add, Update or Delete Documents</see>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="batch">
        /// The batch of document index actions.
        /// </param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// The generic overloads of the IndexDocuments and IndexDocumentsAsync
        /// methods support mapping of search field types to .NET types via the
        /// type parameter T. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// individual <see cref="RequestFailedException"/>s wrapped into an
        /// <see cref="AggregateException"/> that's thrown on partial failure.
        /// </para>
        /// </remarks>>
        public async virtual Task<Response<IndexDocumentsResult>> IndexDocumentsAsync<T>(
            IndexDocumentsBatch<T> batch,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexDocumentsInternal<T>(
                batch,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        private async Task<Response<IndexDocumentsResult>> IndexDocumentsInternal<T>(
            IndexDocumentsBatch<T> batch,
            IndexDocumentsOptions options,
            bool async,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(batch, nameof(batch));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(IndexDocuments)}");
            scope.Start();
            try
            {
                // Create the message
                using HttpMessage message = _pipeline.CreateMessage();
                {
                    Request request = message.Request;
                    request.Method = RequestMethod.Post;
                    RawRequestUriBuilder uri = new RawRequestUriBuilder();
                    uri.AppendRaw(Endpoint.AbsoluteUri, false);
                    uri.AppendRaw("/indexes('", false);
                    uri.AppendRaw(IndexName, true);
                    uri.AppendRaw("')", false);
                    uri.AppendPath("/docs/search.index", false);
                    uri.AppendQuery("api-version", Version.ToVersionString(), true);
                    request.Uri = uri;
                    request.Headers.Add("Accept", "application/json; odata.metadata=none");
                    request.Headers.Add("Content-Type", "application/json");
                    Utf8JsonRequestContent content = new Utf8JsonRequestContent();
                    await batch.SerializeAsync(
                        content.JsonWriter,
                        Serializer,
                        JsonSerialization.SerializerOptions,
                        async,
                        cancellationToken)
                        .ConfigureAwait(false);
                    request.Content = content;
                }

                // Send the request
                if (async)
                {
                    await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _pipeline.Send(message, cancellationToken);
                }

                // Parse the response
                switch (message.Response.Status)
                {
                    case 200:
                    case 207: // Process partial failures the same as successes
                        {
                            // Parse the results
                            using JsonDocument document = async ?
                                await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false) :
                                JsonDocument.Parse(message.Response.ContentStream, default);
                            IndexDocumentsResult value = IndexDocumentsResult.DeserializeIndexDocumentsResult(document.RootElement);

                            // Optionally throw an exception if any individual
                            // write failed
                            if (options?.ThrowOnAnyError == true)
                            {
                                List<RequestFailedException> failures = new List<RequestFailedException>();
                                List<string> failedKeys = new List<string>();
                                foreach (IndexingResult result in value.Results)
                                {
                                    if (!result.Succeeded)
                                    {
                                        failedKeys.Add(result.Key);
                                        var ex = new RequestFailedException(result.Status, result.ErrorMessage);
                                        ex.Data["Key"] = result.Key;
                                        failures.Add(ex);
                                    }
                                }
                                if (failures.Count > 0)
                                {
                                    throw new AggregateException(
                                        $"Failed to index document(s): " + string.Join(", ", failedKeys) + ".",
                                        failures);
                                }
                            }

                            // TODO: #10593 - Ensure input and output document
                            // order is in sync while batching (this is waiting on
                            // both our broader batching story and adding something
                            // on the client that can potentially indicate the Key
                            // column since we have no way to tell that at present.)

                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new RequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        #endregion IndexDocuments

        #region Index Documents Conveniences
        /// <summary>
        /// Upload documents to the index as a batch.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to upload.</param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// The generic overloads of the UploadDocuments and UploadDocumentsAsync
        /// methods support mapping of search field types to .NET types via the
        /// type parameter T. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual Response<IndexDocumentsResult> UploadDocuments<T>(
            IEnumerable<T> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(UploadDocuments)}");
            scope.Start();
            try
            {
                return IndexDocuments<T>(
                    IndexDocumentsBatch.Upload<T>(documents),
                    options,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Upload documents to the index as a batch.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to upload.</param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// The generic overloads of the UploadDocuments and UploadDocumentsAsync
        /// methods support mapping of search field types to .NET types via the
        /// type parameter T. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual async Task<Response<IndexDocumentsResult>> UploadDocumentsAsync<T>(
            IEnumerable<T> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(UploadDocuments)}");
            scope.Start();
            try
            {
                return await IndexDocumentsAsync<T>(
                    IndexDocumentsBatch.Upload<T>(documents),
                    options,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Merge documents to the index as a batch.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to merge.</param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// The generic overloads of the MergeDocuments and MergeDocumentsAsync
        /// methods support mapping of search field types to .NET types via the
        /// type parameter T. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual Response<IndexDocumentsResult> MergeDocuments<T>(
            IEnumerable<T> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(MergeDocuments)}");
            scope.Start();
            try
            {
                return IndexDocuments<T>(
                    IndexDocumentsBatch.Merge<T>(documents),
                    options,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Merge documents to the index as a batch.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to merge.</param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// The generic overloads of the MergeDocuments and MergeDocumentsAsync
        /// methods support mapping of search field types to .NET types via the
        /// type parameter T. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual async Task<Response<IndexDocumentsResult>> MergeDocumentsAsync<T>(
            IEnumerable<T> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(MergeDocuments)}");
            scope.Start();
            try
            {
                return await IndexDocumentsAsync<T>(
                    IndexDocumentsBatch.Merge<T>(documents),
                    options,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Merge or upload documents to the index as a batch.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to merge or upload.</param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// The generic overloads of the MergeOrUploadDocuments and
        /// MergeOrUploadDocumentsAsync methods support mapping of search field
        /// types to .NET types via the type parameter T. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual Response<IndexDocumentsResult> MergeOrUploadDocuments<T>(
            IEnumerable<T> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(MergeOrUploadDocuments)}");
            scope.Start();
            try
            {
                return IndexDocuments<T>(
                    IndexDocumentsBatch.MergeOrUpload<T>(documents),
                    options,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Merge or upload documents to the index as a batch.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to merge or upload.</param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// The generic overloads of the MergeOrUploadDocuments and
        /// MergeOrUploadDocumentsAsync methods support mapping of search field
        /// types to .NET types via the type parameter T. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual async Task<Response<IndexDocumentsResult>> MergeOrUploadDocumentsAsync<T>(
            IEnumerable<T> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(MergeOrUploadDocuments)}");
            scope.Start();
            try
            {
                return await IndexDocumentsAsync<T>(
                    IndexDocumentsBatch.MergeOrUpload<T>(documents),
                    options,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete documents from the index as a batch.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to delete.</param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// The generic overloads of the DeleteDocuments and DeleteDocumentsAsync
        /// methods support mapping of search field types to .NET types via the
        /// type parameter T. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual Response<IndexDocumentsResult> DeleteDocuments<T>(
            IEnumerable<T> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(DeleteDocuments)}");
            scope.Start();
            try
            {
                return IndexDocuments<T>(
                    IndexDocumentsBatch.Delete<T>(documents),
                    options,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete documents from the index as a batch.
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">The documents to delete.</param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// The generic overloads of the DeleteDocuments and DeleteDocumentsAsync
        /// methods support mapping of search field types to .NET types via the
        /// type parameter T. See
        /// <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual async Task<Response<IndexDocumentsResult>> DeleteDocumentsAsync<T>(
            IEnumerable<T> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(DeleteDocuments)}");
            scope.Start();
            try
            {
                return await IndexDocumentsAsync<T>(
                    IndexDocumentsBatch.Delete<T>(documents),
                    options,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete documents from the index as a batch given only their keys.
        /// </summary>
        /// <param name="keyName">
        /// The name of the key field that uniquely identifies documents in
        /// the index.
        /// </param>
        /// <param name="keyValues">
        /// The keys of the documents to delete.
        /// </param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual Response<IndexDocumentsResult> DeleteDocuments(
            string keyName,
            IEnumerable<string> keyValues,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(DeleteDocuments)}");
            scope.Start();
            try
            {
                return IndexDocuments(
                    IndexDocumentsBatch.Delete(keyName, keyValues),
                    options,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete documents from the index as a batch given only their keys.
        /// </summary>
        /// <param name="keyName">
        /// The name of the key field that uniquely identifies documents in
        /// the index.
        /// </param>
        /// <param name="keyValues">
        /// The keys of the documents to delete.
        /// </param>
        /// <param name="options">
        /// Options that allow specifying document indexing behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// Response containing the status of operations for all actions in the
        /// batch of actions.
        /// </returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        /// <remarks>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual async Task<Response<IndexDocumentsResult>> DeleteDocumentsAsync(
            string keyName,
            IEnumerable<string> keyValues,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchClient)}.{nameof(DeleteDocuments)}");
            scope.Start();
            try
            {
                return await IndexDocumentsAsync(
                    IndexDocumentsBatch.Delete(keyName, keyValues),
                    options,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion Index Documents Conveniences
    }
}
