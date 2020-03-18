// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to query an index and
    /// upload, merge, or delete documents.
    /// </summary>
    public class SearchIndexClient
    {
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
        /// The name of the Search Service, lazily obtained from the
        /// <see cref="Endpoint"/>.
        /// </summary>
        private string _serviceName = null;

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
        /// Gets the authenticated <see cref="HttpPipeline"/> used for sending
        /// requests to the Search Service.
        /// </summary>
        private HttpPipeline Pipeline { get; }

        /// <summary>
        /// Gets the <see cref="Azure.Core.Pipeline.ClientDiagnostics"/> used
        /// to provide tracing support for the client library.
        /// </summary>
        private ClientDiagnostics ClientDiagnostics { get; }

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
        /// Initializes a new instance of the SearchIndexClient class for
        /// mocking.
        /// </summary>
        protected SearchIndexClient() { }

        /// <summary>
        /// Initializes a new instance of the SearchIndexClient class for
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
        /// <see href="https://docs.microsoft.com/azure/search/search-security-api-keys"/>
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
        public SearchIndexClient(
            Uri endpoint,
            string indexName,
            AzureKeyCredential credential) :
            this(endpoint, indexName, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SearchIndexClient class for
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
        /// <see href="https://docs.microsoft.com/azure/search/search-security-api-keys"/>
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
        public SearchIndexClient(
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
            ClientDiagnostics = new ClientDiagnostics(options);
            Pipeline = options.Build(credential);
            Version = options.Version;

            Protocol = new DocumentsRestClient(
                ClientDiagnostics,
                Pipeline,
                endpoint.ToString(),
                IndexName,
                Version.ToVersionString());
        }

        /// <summary>
        /// Initializes a new instance of the SearchIndexClient class from a
        /// <see cref="SearchServiceClient"/>.
        /// </summary>
        /// <param name="endpoint">
        /// Required.  The URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="indexName">
        /// Required.  The name of the Search Index.
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
        internal SearchIndexClient(
            Uri endpoint,
            string indexName,
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
                SearchClientOptions.ServiceVersion.V2019_05_06_Preview <= version &&
                version <= SearchClientOptions.LatestVersion);

            Endpoint = endpoint;
            IndexName = indexName;
            ClientDiagnostics = diagnostics;
            Pipeline = pipeline;
            Version = version;

            Protocol = new DocumentsRestClient(
                ClientDiagnostics,
                Pipeline,
                endpoint.ToString(),
                IndexName,
                Version.ToVersionString());
        }
        #endregion ctors

        #region GetDocumentCount
        /// <summary>
        /// Retrieves a count of the number of documents in this search index.
        /// </summary>
        /// <param name="options">
        /// Options to customize the operation's behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>The number of documents in the search index.</returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        [ForwardsClientCalls]
        public virtual Response<long> GetDocumentCount(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            Protocol.Count(
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Retrieves a count of the number of documents in this search index.
        /// </summary>
        /// <param name="options">
        /// Options to customize the operation's behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>The number of documents in the search index.</returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<long>> GetDocumentCountAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await Protocol.CountAsync(
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);
        #endregion GetDocumentCount

        #region GetDocument
        /// <summary>
        /// Retrieves a document from Azure Cognitive Search.  This is useful
        /// when a user clicks on a specific search result, and you want to
        /// look up specific details about that document. You can only get one
        /// document at a time.  Use Search to get multiple documents in a
        /// single request.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Lookup-Document"/>
        /// </summary>
        /// <param name="key">
        /// Required.  An string value that uniquely identifies each document
        /// in the index.  The key is sometimes referred to as a document ID.
        /// See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Naming-rules"/>
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
        /// The non-generic overloads of the GetDocument and GetDocumentAsync
        /// that return a <see cref="SearchDocument"/> make a best-effort
        /// attempt to map JSON types in the response payload to .NET types.
        /// See <see cref="GetDocumentAsync(string, GetDocumentOptions, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public virtual Response<SearchDocument> GetDocument(
            string key,
            GetDocumentOptions options = null,
            CancellationToken cancellationToken = default) =>
            GetDocumentInternal<SearchDocument>(
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
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Lookup-Document"/>
        /// </summary>
        /// <param name="key">
        /// Required.  An string value that uniquely identifies each document
        /// in the index.  The key is sometimes referred to as a document ID.
        /// See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Naming-rules"/>
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
        /// The non-generic overloads of the GetDocument and GetDocumentAsync
        /// that return a <see cref="SearchDocument"/> make a best-effort
        /// attempt to map JSON types in the response payload to .NET types.
        /// This mapping does not have the benefit of precise type information
        /// from the index, so the mapping is not always correct. In
        /// particular, be aware of the following cases:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Any numeric value without a decimal point will be deserialized to
        /// a System.Int32 (int in C#, int32 in F#) if it can be converted or
        /// a System.Int64 (long in C#, int64 in F#) otherwise.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Special double-precision floating point values such as NaN and
        /// Infinity will be deserialized as type System.String rather than
        /// System.Double, even if they are in arrays with regular floating
        /// point values.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any string field with a value formatted like a DateTimeOffset will
        /// be deserialized incorrectly. This applies to such values in arrays
        /// of strings as well.  We recommend storing such values in
        /// Edm.DateTimeOffset fields rather than Edm.String fields.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any Edm.DateTimeOffset field will be deserialized as a
        /// System.DateTimeOffset, not System.DateTime.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any empty JSON array will be deserialized as an array of
        /// System.Object (object[] in C#, obj[] in F#).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Any array of a primitive type will be deserialized as an array of
        /// its corresponding .NET type, not as an array of System.Object,
        /// unless the values cannot all be deserialized to the same type. For
        /// example, the arrays [3.14, "NaN"] and
        /// ["hello", "2016-10-10T17:41:05.123-07:00"] will both deserialize as
        /// arrays of System.Object (object[] in C#, obj[] in F#).  This is
        /// because special double values always deserialize as strings, while
        /// strings that look like DateTimeOffset always deserialize as
        /// DateTimeOffset.
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
        public virtual async Task<Response<SearchDocument>> GetDocumentAsync(
            string key,
            GetDocumentOptions options = null,
            CancellationToken cancellationToken = default) =>
            await GetDocumentInternal<SearchDocument>(
                key,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves a document from Azure Cognitive Search.  This is useful
        /// when a user clicks on a specific search result, and you want to
        /// look up specific details about that document. You can only get one
        /// document at a time.  Use Search to get multiple documents in a
        /// single request.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Lookup-Document"/>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="key">
        /// Required.  An string value that uniquely identifies each document
        /// in the index.  The key is sometimes referred to as a document ID.
        /// See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Naming-rules"/>
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
        /// The generic overloads of the GetDocument and GetDocumentAsync
        /// methods support mapping of Azure Search field types to .NET types
        /// via the type parameter T.  Note that all search field types except
        /// collections are nullable, so we recommend using nullable types for
        /// the properties of T. See
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
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Lookup-Document"/>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="key">
        /// Required.  An string value that uniquely identifies each document
        /// in the index.  The key is sometimes referred to as a document ID.
        /// See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Naming-rules"/>
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
        /// The generic overloads of the GetDocument and GetDocumentAsync
        /// methods support mapping of Azure Search field types to .NET types
        /// via the type parameter T.  Note that all search field types except
        /// collections are nullable, so we recommend using nullable types for
        /// the properties of T.  The type mapping is as follows:
        /// <list type="table">
        /// <listheader>
        /// <term>Search field type</term>
        /// <description>.NET type</description>
        /// </listheader>
        /// <item>
        /// <term>Edm.String</term>
        /// <description>System.String (string in C# and F#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Boolean</term>
        /// <description>System.Nullable&lt;System.Boolean&gt; (bool? in C#,\
        /// Nullable&lt;bool&gt; in F#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Double</term>
        /// <description>System.Nullable&lt;System.Double&gt; (double? in C#,
        /// Nullable&lt;float&gt; in F#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Int32</term>
        /// <description>System.Nullable&lt;System.Int32&gt; (int? in C#,
        /// Nullable&lt;int&gt; in F#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.Int64</term>
        /// <description>System.Nullable&lt;System.Int64&gt; (long? in C#,
        /// Nullable&lt;int64&gt; in F#)</description>
        /// </item>
        /// <item>
        /// <term>Edm.DateTimeOffset</term>
        /// <description>
        /// System.Nullable&lt;System.DateTimeOffset&gt; (DateTimeOffset? in
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
        /// <description>Currently treated as a complex object but will soon be
        /// replaced with something like Microsoft.Spatial.GeographyPoint
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
        /// <description>IEnumerable&lt;System.String&gt; (seq&lt;string&gt;
        /// in F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.Boolean)</term>
        /// <description>IEnumerable&lt;System.Boolean&gt; (seq&lt;bool&gt; in
        /// F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.Double)</term>
        /// <description>IEnumerable&lt;System.Double&gt; (seq&lt;float&gt; in
        /// F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.Int32)</term>
        /// <description>IEnumerable&lt;System.Int32&gt; (seq&lt;int&gt; in
        /// F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.Int64)</term>
        /// <description>IEnumerable&lt;System.Int64&gt; (seq&lt;int64&gt; in
        /// F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.DateTimeOffset)</term>
        /// <description>
        /// IEnumerable&lt;System.DateTimeOffset&gt; or
        /// IEnumerable&lt;System.DateTime&gt; (seq&lt;DateTimeOffset&gt; or
        /// seq&lt;DateTime&gt; in F#). Both types work, although we recommend
        /// using IEnumerable&lt;System.DateTimeOffset&gt;.  See the notes
        /// above on Edm.DateTimeOffset for details.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.GeographyPoint)</term>
        /// <description>Currently treated like Collection(Edm.ComplexType) but
        /// will soon be replaced with something more like
        /// IEnumerable&lt;Microsoft.Spatial.GeographyPoint&gt;
        /// (seq&lt;GeographyPoint&gt; in F#)</description>
        /// </item>
        /// <item>
        /// <term>Collection(Edm.ComplexType)</term>
        /// <description>
        /// IEnumerable&lt;U&gt; (seq&lt;U&gt; in F#) where U is any type that
        /// can be deserialized from the JSON objects in the complex collection
        /// field. This can be a value type or a reference type.
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
            if (key == null) { throw new ArgumentNullException(nameof(key)); }
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetDocument)}");
            scope.Start();
            try
            {
                using HttpMessage message = Protocol.CreateGetRequest(key, options?.SelectedFieldsOrNull, options?.ClientRequestId);
                if (async)
                {
                    await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    Pipeline.Send(message, cancellationToken);
                }
                switch (message.Response.Status)
                {
                    case 200:
                    {
                        T value = async ?
                            await message.Response.ContentStream.DeserializeAsync<T>(cancellationToken).ConfigureAwait(false) :
                            message.Response.ContentStream.Deserialize<T>();
                        return Response.FromValue(value, message.Response);
                    }
                    default:
                        throw async ?
                            await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false) :
                            ClientDiagnostics.CreateRequestFailedException(message.Response);
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
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Search-Documents"/>
        /// </summary>
        /// <param name="searchText">
        /// A full-text search query expression;  Use "*" or omit this
        /// parameter to match all documents.  See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Simple-query-syntax-in-Azure-Search"/>
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
        /// The non-generic overloads of the Search and SearchAsync methods
        /// make a best-effort attempt to map JSON types in the response
        /// payload to .NET types. See
        /// <see cref="GetDocumentAsync(string, GetDocumentOptions, CancellationToken)"/>
        /// for more information.
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
        public virtual Response<SearchResults<SearchDocument>> Search(
            string searchText,
            SearchOptions options = null,
            CancellationToken cancellationToken = default) =>
            SearchInternal<SearchDocument>(
                searchText,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Searches for documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Search-Documents"/>
        /// </summary>
        /// <param name="searchText">
        /// A full-text search query expression;  Use "*" or omit this
        /// parameter to match all documents.  See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Simple-query-syntax-in-Azure-Search"/>
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
        /// The non-generic overloads of the Search and SearchAsync methods
        /// make a best-effort attempt to map JSON types in the response
        /// payload to .NET types. See
        /// <see cref="GetDocumentAsync(string, GetDocumentOptions, CancellationToken)"/>
        /// for more information.
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
        public async virtual Task<Response<SearchResults<SearchDocument>>> SearchAsync(
            string searchText,
            SearchOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SearchInternal<SearchDocument>(
                searchText,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Searches for documents in the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Search-Documents"/>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="searchText">
        /// A full-text search query expression;  Use "*" or omit this
        /// parameter to match all documents.  See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Simple-query-syntax-in-Azure-Search"/>
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
        /// The generic overloads of the Search and SearchAsync methods support
        /// mapping of search field types to .NET types via the type parameter
        /// T. See  <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
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
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Search-Documents"/>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="searchText">
        /// A full-text search query expression;  Use "*" or omit this
        /// parameter to match all documents.  See
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Simple-query-syntax-in-Azure-Search"/>
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
        /// The generic overloads of the Search and SearchAsync methods support
        /// mapping of search field types to .NET types via the type parameter
        /// T. See  <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
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

        private async Task<Response<SearchResults<T>>> SearchInternal<T>(
            string searchText,
            SearchOptions options,
            bool async,
            CancellationToken cancellationToken = default)
        {
            options ??= new SearchOptions();
            options.SearchText = searchText;

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(Search)}");
            scope.Start();
            try
            {
                using HttpMessage message = Protocol.CreateSearchPostRequest(options.ClientRequestId, options);
                if (async)
                {
                    await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    Pipeline.Send(message, cancellationToken);
                }
                switch (message.Response.Status)
                {
                    case 200:
                    {
                        // Deserialize the results
                        SearchResults<T> results = async ?
                            await message.Response.ContentStream.DeserializeAsync<SearchResults<T>>(cancellationToken).ConfigureAwait(false) :
                            message.Response.ContentStream.Deserialize<SearchResults<T>>();

                        // Cache the client and raw response so we can abstract
                        // away server-side paging
                        results.ConfigurePaging(this, message.Response);

                        return Response.FromValue(results, message.Response);
                    }
                    default:
                        throw async ?
                            await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false) :
                            ClientDiagnostics.CreateRequestFailedException(message.Response);
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
        /// <see href="https://docs.microsoft.com/en-us/rest/api/searchservice/suggestions"/>
        /// </summary>
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
        /// The non-generic overloads of the Suggest and SuggestAsync methods
        /// make a best-effort attempt to map JSON types in the response
        /// payload to .NET types. See
        /// <see cref="GetDocumentAsync(string, GetDocumentOptions, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public virtual Response<SuggestResults<SearchDocument>> Suggest(
            string searchText,
            string suggesterName,
            SuggestOptions options = null,
            CancellationToken cancellationToken = default) =>
            SuggestInternal<SearchDocument>(
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
        /// <see href="https://docs.microsoft.com/en-us/rest/api/searchservice/suggestions"/>
        /// </summary>
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
        /// The non-generic overloads of the Suggest and SuggestAsync methods
        /// make a best-effort attempt to map JSON types in the response
        /// payload to .NET types. See
        /// <see cref="GetDocumentAsync(string, GetDocumentOptions, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public virtual async Task<Response<SuggestResults<SearchDocument>>> SuggestAsync(
            string searchText,
            string suggesterName,
            SuggestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SuggestInternal<SearchDocument>(
                searchText,
                suggesterName,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Executes a "search-as-you-type" query consisting of a partial text
        /// input (three character minimum).  It returns matching text found in
        /// suggester-aware fields.  Azure Cognitive Search looks for matching
        /// values in fields that are predefined in a Suggester.  For example,
        /// if you enable suggestions on a city field, typing "sea" produces
        /// documents containing "Seattle", "Sea Tac", and "Seaside" (all
        /// actual city names) for that field.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/searchservice/suggestions"/>
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
        /// The generic overloads of the Suggest and SuggestAsync methods support
        /// mapping of search field types to .NET types via the type parameter
        /// T. See  <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
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
        /// <see href="https://docs.microsoft.com/en-us/rest/api/searchservice/suggestions"/>
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
        /// The generic overloads of the Suggest and SuggestAsync methods support
        /// mapping of search field types to .NET types via the type parameter
        /// T. See  <see cref="GetDocumentAsync{T}(string, GetDocumentOptions, CancellationToken)"/>
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
            options ??= new SuggestOptions();
            options.SearchText = searchText;
            options.SuggesterName = suggesterName;

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(Suggest)}");
            scope.Start();
            try
            {
                using HttpMessage message = Protocol.CreateSuggestPostRequest(options.ClientRequestId, options);
                if (async)
                {
                    await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    Pipeline.Send(message, cancellationToken);
                }
                switch (message.Response.Status)
                {
                    case 200:
                    {
                        SuggestResults<T> suggestions = async ?
                            await message.Response.ContentStream.DeserializeAsync<SuggestResults<T>>(cancellationToken).ConfigureAwait(false) :
                            message.Response.ContentStream.Deserialize<SuggestResults<T>>();
                        return Response.FromValue(suggestions, message.Response);
                    }
                    default:
                        throw async ?
                            await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false) :
                            ClientDiagnostics.CreateRequestFailedException(message.Response);
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
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Autocomplete"/>
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
        [ForwardsClientCalls]
        public virtual Response<AutocompleteResults> Autocomplete(
            string searchText,
            string suggesterName,
            AutocompleteOptions options = null,
            CancellationToken cancellationToken = default) =>
            AutocompleteInternal(
                searchText,
                suggesterName,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Suggests query terms based on input text and matching documents in
        /// the search index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Autocomplete"/>
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
        [ForwardsClientCalls]
        public virtual async Task<Response<AutocompleteResults>> AutocompleteAsync(
            string searchText,
            string suggesterName,
            AutocompleteOptions options = null,
            CancellationToken cancellationToken = default) =>
            await AutocompleteInternal(
                searchText,
                suggesterName,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        private async Task<Response<AutocompleteResults>> AutocompleteInternal(
            string searchText,
            string suggesterName,
            AutocompleteOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            options ??= new AutocompleteOptions();
            options.SearchText = searchText;
            options.SuggesterName = suggesterName;

            return async ?
                await Protocol.AutocompletePostAsync(options.ClientRequestId, options, cancellationToken).ConfigureAwait(false) :
                Protocol.AutocompletePost(options.ClientRequestId, options, cancellationToken);
        }
        #endregion Autocomplete

        #region IndexDocuments
        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the search
        /// index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents"/>
        /// </summary>
        /// <param name="documents">
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
        /// The non-generic overloads of the Index and IndexAsync methods make
        /// a best-effort attempt to map JSON types in the response payload to
        /// .NET types.  See
        /// <see cref="GetDocumentAsync(string, GetDocumentOptions, CancellationToken)"/>
        /// for more information.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual Response<IndexDocumentsResult> IndexDocuments(
            IndexDocumentsBatch<SearchDocument> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexDocumentsInternal<SearchDocument>(
                documents,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the search
        /// index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents"/>
        /// </summary>
        /// <param name="documents">
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
        /// The non-generic overloads of the Index and IndexAsync methods make
        /// a best-effort attempt to map JSON types in the response payload to
        /// .NET types.  See
        /// <see cref="GetDocumentAsync(string, GetDocumentOptions, CancellationToken)"/>
        /// for more information.
        /// </para>
        /// <para>
        /// By default, an exception will only be thrown if the entire request
        /// fails.  Individual failures are described in the
        /// <see cref="IndexDocumentsResult.Results"/> collection.  You can set
        /// <see cref="IndexDocumentsOptions.ThrowOnAnyError"/> if you want
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public async virtual Task<Response<IndexDocumentsResult>> IndexDocumentsAsync(
            IndexDocumentsBatch<SearchDocument> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexDocumentsInternal<SearchDocument>(
                documents,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the search
        /// index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents"/>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">
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
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public virtual Response<IndexDocumentsResult> IndexDocuments<T>(
            IndexDocumentsBatch<T> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexDocumentsInternal<T>(
                documents,
                options,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the search
        /// index.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents"/>
        /// </summary>
        /// <typeparam name="T">
        /// The .NET type that maps to the index schema. Instances of this type
        /// can be retrieved as documents from the index.
        /// </typeparam>
        /// <param name="documents">
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
        /// exceptions thrown on partial failure.
        /// </para>
        /// </remarks>
        public async virtual Task<Response<IndexDocumentsResult>> IndexDocumentsAsync<T>(
            IndexDocumentsBatch<T> documents,
            IndexDocumentsOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexDocumentsInternal<T>(
                documents,
                options,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        private async Task<Response<IndexDocumentsResult>> IndexDocumentsInternal<T>(
            IndexDocumentsBatch<T> documents,
            IndexDocumentsOptions options,
            bool async,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(documents, nameof(documents));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(IndexDocuments)}");
            scope.Start();
            try
            {
                // Create the message
                using HttpMessage message = Pipeline.CreateMessage();
                {
                    Request request = message.Request;
                    request.Method = RequestMethod.Post;
                    RawRequestUriBuilder uri = new RawRequestUriBuilder();
                    uri.AppendRaw(Endpoint.ToString(), false);
                    uri.AppendRaw("/indexes('", false);
                    uri.AppendRaw(IndexName, true);
                    uri.AppendRaw("')", false);
                    uri.AppendPath("/docs/search.index", false);
                    uri.AppendQuery("api-version", Version.ToVersionString(), true);
                    request.Uri = uri;
                    if (options?.ClientRequestId != null)
                    {
                        request.ClientRequestId = options?.ClientRequestId.ToString();
                    }
                    request.Headers.Add("Content-Type", "application/json");
                    using Utf8JsonRequestContent content = new Utf8JsonRequestContent();
                    content.JsonWriter.WriteObjectValue(documents);
                    request.Content = content;
                }

                // Send the request
                if (async)
                {
                    await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    Pipeline.Send(message, cancellationToken);
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

                        // TODO: #10593 - Ensure input and output document order is in sync while batching
                        // (waiting until we figure out the broader batching
                        // story)

                        // Optionally throw an exception if any individual
                        // write failed
                        if (options?.ThrowOnAnyError == true)
                        {
                            foreach (IndexingResult result in value.Results)
                            {
                                if (!result.Succeeded)
                                {
                                    // TODO: #10594 - Aggregate the failed operations into a single exception
                                    // (waiting until we figure out the broader
                                    // batching story)
                                    throw new RequestFailedException(result.Status, result.ErrorMessage);
                                }
                            }
                        }
                        return Response.FromValue(value, message.Response);
                    }
                    default:
                        throw async ?
                            await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false) :
                            ClientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        #endregion IndexDocuments
    }
}
