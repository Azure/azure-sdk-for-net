// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Search
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
        private DocumentsClient Operations { get; }

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
            SearchApiKeyCredential credential) :
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
            SearchApiKeyCredential credential,
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

            Operations = new DocumentsClient(
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
            Debug.Assert(SearchClientOptions.ServiceVersion.V2019_05_06 <= version &&
                version <= SearchClientOptions.LatestVersion);

            Endpoint = endpoint;
            IndexName = indexName;
            ClientDiagnostics = diagnostics;
            Pipeline = pipeline;
            Version = version;

            Operations = new DocumentsClient(
                ClientDiagnostics,
                Pipeline,
                endpoint.ToString(),
                IndexName,
                Version.ToVersionString());
        }

        /// <summary>
        /// Retrieves a count of the number of documents in this search index.
        /// </summary>
        /// <param name="clientRequestId">
        /// An optional caller-defined value that identifies the given request.
        /// If specified, this will be included in response information as a
        /// way to map the request.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>The service level statistics.</returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        [ForwardsClientCalls]
        public virtual Response<long> GetCount(
            Guid? clientRequestId = null,
            CancellationToken cancellationToken = default) =>
            Operations.Count(
                clientRequestId,
                cancellationToken);

        /// <summary>
        /// Retrieves a count of the number of documents in this search index.
        /// </summary>
        /// <param name="clientRequestId">
        /// An optional caller-defined value that identifies the given request.
        /// If specified, this will be included in response information as a
        /// way to map the request.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>The service level statistics.</returns>
        /// <exception cref="RequestFailedException">
        /// Thrown when a failure is returned by the Search Service.
        /// </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<long>> GetCountAsync(
            Guid? clientRequestId = null,
            CancellationToken cancellationToken = default) =>
            await Operations.CountAsync(
                clientRequestId,
                cancellationToken)
                .ConfigureAwait(false);
    }
}
