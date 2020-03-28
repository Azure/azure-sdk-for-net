// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage and query
    /// indexes and documents, as well as manage other resources, on a Search
    /// Service.
    /// </summary>
    public class SearchServiceClient
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
        /// Gets the generated service level operations to make requests.
        /// </summary>
        private ServiceRestClient Protocol { get; }

        /// <summary>
        /// Initializes a new instance of the SearchServiceClient class for
        /// mocking.
        /// </summary>
        protected SearchServiceClient() { }

        /// <summary>
        /// Initializes a new instance of the SearchServiceClient class.
        /// </summary>
        /// <param name="endpoint">
        /// Required.  The URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="credential">
        /// Required.  The API key credential used to authenticate requests
        /// against the search service.  You need to use an admin key to
        /// perform any operations on the SearchServiceClient.  See
        /// <see href="https://docs.microsoft.com/azure/search/search-security-api-keys"/>
        /// for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="endpoint"/> or
        /// <paramref name="credential"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="endpoint"/> is not using HTTPS.
        /// </exception>
        public SearchServiceClient(Uri endpoint, AzureKeyCredential credential) :
            this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SearchServiceClient class.
        /// </summary>
        /// <param name="endpoint">
        /// Required.  The URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="credential">
        /// Required.  The API key credential used to authenticate requests
        /// against the search service.  You need to use an admin key to
        /// perform any operations on the SearchServiceClient.  See
        /// <see href="https://docs.microsoft.com/azure/search/search-security-api-keys"/>
        /// for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <param name="options">
        /// Client configuration options for connecting to Azure Cognitive
        /// Search.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="endpoint"/> or
        /// <paramref name="credential"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="endpoint"/> is not using HTTPS.
        /// </exception>
        public SearchServiceClient(
            Uri endpoint,
            AzureKeyCredential credential,
            SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new SearchClientOptions();
            Endpoint = endpoint;
            ClientDiagnostics = new ClientDiagnostics(options);
            Pipeline = options.Build(credential);
            Version = options.Version;

            Protocol = new ServiceRestClient(
                ClientDiagnostics,
                Pipeline,
                Endpoint.ToString(),
                Version.ToVersionString());
        }

        /// <summary>
        /// Get a <see cref="SearchIndexClient"/> for the given
        /// <paramref name="indexName"/> to use for document operations like
        /// querying or adding documents to a Search Index.
        /// </summary>
        /// <param name="indexName">
        /// The name of the desired Search Index.
        /// </param>
        /// <returns>
        /// A SearchIndexClient for the desired Search Index.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="indexName"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="indexName"/> is empty.
        /// </exception>
        /// <remarks>
        /// The same request <see cref="HttpPipeline"/> (including
        /// authentication and any other configuration) will be used for the
        /// SearchIndexClient.
        /// </remarks>
        public virtual SearchIndexClient GetSearchIndexClient(string indexName)
        {
            Argument.AssertNotNullOrEmpty(indexName, nameof(indexName));
            return new SearchIndexClient(
                Endpoint,
                indexName,
                Pipeline,
                ClientDiagnostics,
                Version);
        }

        /// <summary>
        /// Gets service level statistics for a Search Service.
        ///
        /// This operation returns the number and type of objects in your
        /// service, the maximum allowed for each object type given the service
        /// tier, actual and maximum storage, and other limits that vary by
        /// tier.  This request pulls information from the service so that you
        /// don't have to look up or calculate service limits.
        ///
        /// Statistics on document count and storage size are collected every
        /// few minutes, not in real time.  Therefore, the statistics returned
        /// by this API may not reflect changes caused by recent indexing
        /// operations.
        /// </summary>
        /// <param name="options">
        /// Options to customize the operation's behavior.
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
        public virtual Response<SearchServiceStatistics> GetStatistics(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            Protocol.GetServiceStatistics(
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Gets service level statistics for a Search Service.
        ///
        /// This operation returns the number and type of objects in your
        /// service, the maximum allowed for each object type given the service
        /// tier, actual and maximum storage, and other limits that vary by
        /// tier.  This request pulls information from the service so that you
        /// don't have to look up or calculate service limits.
        ///
        /// Statistics on document count and storage size are collected every
        /// few minutes, not in real time.  Therefore, the statistics returned
        /// by this API may not reflect changes caused by recent indexing
        /// operations.
        /// </summary>
        /// <param name="options">
        /// Options to customize the operation's behavior.
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
        public virtual async Task<Response<SearchServiceStatistics>> GetStatisticsAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await Protocol.GetServiceStatisticsAsync(
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);
    }
}
