// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.Indexes;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage and query
    /// indexes and documents, as well as manage other resources, on a Search
    /// Service.
    /// </summary>
    public class SearchServiceClient
    {
        private ServiceRestClient _serviceClient;

        /// <summary>
        /// Gets the URI endpoint of the Search service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// </summary>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// The name of the Search service, lazily obtained from the
        /// <see cref="Endpoint"/>.
        /// </summary>
        private string _serviceName = null;

        /// <summary>
        /// Gets the name of the Search service.
        /// </summary>
        public virtual string ServiceName =>
            _serviceName ??= Endpoint.GetSearchServiceName();

        /// <summary>
        /// Gets the authenticated <see cref="HttpPipeline"/> used for sending
        /// requests to the Search service.
        /// </summary>
        internal HttpPipeline Pipeline { get; }

        /// <summary>
        /// Gets the <see cref="Azure.Core.Pipeline.ClientDiagnostics"/> used
        /// to provide tracing support for the client library.
        /// </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary>
        /// Gets the REST API version of the Search service to use when making
        /// requests.
        /// </summary>
        internal SearchClientOptions.ServiceVersion Version { get; }

        /// <summary>
        /// Gets the generated <see cref="ServiceRestClient"/> to make requests.
        /// </summary>
        private ServiceRestClient ServiceClient => LazyInitializer.EnsureInitialized(ref _serviceClient, () => new ServiceRestClient(
            ClientDiagnostics,
            Pipeline,
            Endpoint.ToString(),
            Version.ToVersionString())
        );

        /// <summary>
        /// Initializes a new instance of the SearchServiceClient class for
        /// mocking.
        /// </summary>
        protected SearchServiceClient() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchServiceClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="credential">
        /// Required. The API key credential used to authenticate requests against the Search service.
        /// You need to use an admin key to perform any operations on the SearchServiceClient.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys"/> for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchServiceClient(Uri endpoint, AzureKeyCredential credential) :
            this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchServiceClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="credential">
        /// Required. The API key credential used to authenticate requests against the Search service.
        /// You need to use an admin key to perform any operations on the SearchServiceClient.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys"/> for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <param name="options">Client configuration options for connecting to Azure Cognitive Search.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
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
        }

        /// <summary>
        /// Gets a <see cref="SearchClient"/> for the given <paramref name="indexName"/> to use for document operations like querying or adding documents to a Search Index.
        /// </summary>
        /// <param name="indexName">The name of the desired Search Index.</param>
        /// <returns>A SearchClient for the desired Search Index.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="indexName"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="indexName"/> is empty.</exception>
        /// <remarks>
        /// The same request <see cref="HttpPipeline"/> (including authentication and any other configuration) will be used for the <see cref="SearchClient"/>.
        /// </remarks>
        public virtual SearchClient GetSearchClient(string indexName)
        {
            Argument.AssertNotNullOrEmpty(indexName, nameof(indexName));
            return new SearchClient(
                Endpoint,
                indexName,
                Pipeline,
                ClientDiagnostics,
                Version);
        }

        /// <summary>
        /// Gets a <see cref="SearchIndexClient"/> to manage Search indexes using the same <see cref="Endpoint"/>.
        /// </summary>
        /// <returns>A <see cref="SearchIndexClient"/> to manage Search indexes using the same <see cref="Endpoint"/>.</returns>
        /// <remarks>
        /// The same request <see cref="HttpPipeline"/> (including authentication and any other configuration) will be used for the <see cref="SearchIndexClient"/>.
        /// </remarks>
        public virtual SearchIndexClient GetSearchIndexClient() => new SearchIndexClient(this);

        /// <summary>
        /// Gets a <see cref="SearchIndexerClient"/> to manage Search indexers using the same <see cref="Endpoint"/>.
        /// </summary>
        /// <returns>A <see cref="SearchIndexerClient"/> to manage Search indexers using the same <see cref="Endpoint"/>.</returns>
        /// <remarks>
        /// The same request <see cref="HttpPipeline"/> (including authentication and any other configuration) will be used for the <see cref="SearchIndexerClient"/>.
        /// </remarks>
        public virtual SearchIndexerClient GetSearchIndexerClient() => new SearchIndexerClient(this);

        /// <summary>
        /// Gets a <see cref="SearchIndexerDataSourceClient"/> to manage Search indexer data sources using the same <see cref="Endpoint"/>.
        /// </summary>
        /// <returns>A <see cref="SearchIndexerDataSourceClient"/> to manage Search indexer data sources using the same <see cref="Endpoint"/>.</returns>
        /// <remarks>
        /// The same request <see cref="HttpPipeline"/> (including authentication and any other configuration) will be used for the <see cref="SearchIndexerDataSourceClient"/>.
        /// </remarks>
        public virtual SearchIndexerDataSourceClient GetSearchIndexerDataSourceClient() => new SearchIndexerDataSourceClient(this);

        /// <summary>
        /// Gets a <see cref="SearchIndexerSkillsetClient"/> to manage Search indexer skillsets using the same <see cref="Endpoint"/>.
        /// </summary>
        /// <returns>A <see cref="SearchIndexerSkillsetClient"/> to manage Search indexer skillsets using the same <see cref="Endpoint"/>.</returns>
        /// <remarks>
        /// The same request <see cref="HttpPipeline"/> (including authentication and any other configuration) will be used for the <see cref="SearchIndexerSkillsetClient"/>.
        /// </remarks>
        public virtual SearchIndexerSkillsetClient GetSearchIndexerSkillsetCllient() => new SearchIndexerSkillsetClient(this);

        /// <summary>
        /// Gets a <see cref="SynonymMapClient"/> to manage synonym maps using the same <see cref="Endpoint"/>.
        /// </summary>
        /// <returns>A <see cref="SynonymMapClient"/> to manage synonym maps using the same <see cref="Endpoint"/>.</returns>
        /// <remarks>
        /// The same request <see cref="HttpPipeline"/> (including authentication and any other configuration) will be used for the <see cref="SynonymMapClient"/>.
        /// </remarks>
        public virtual SynonymMapClient GetSynonymMapClient() => new SynonymMapClient(this);

        /// <summary>
        /// <para>
        /// Gets service level statistics for a Search service.
        /// </para>
        /// <para>
        /// This operation returns the number and type of objects in your
        /// service, the maximum allowed for each object type given the service
        /// tier, actual and maximum storage, and other limits that vary by
        /// tier. This request pulls information from the service so that you
        /// don't have to look up or calculate service limits.
        /// </para>
        /// <para>
        /// Statistics on document count and storage size are collected every
        /// few minutes, not in real time. Therefore, the statistics returned
        /// by this API may not reflect changes caused by recent indexing
        /// operations.
        /// </para>
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing <see cref="SearchServiceStatistics"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchServiceStatistics> GetStatistics(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetStatistics)}");
            scope.Start();
            try
            {
                return ServiceClient.GetServiceStatistics(
                    options?.ClientRequestId,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// <para>
        /// Gets service level statistics for a Search service.
        /// </para>
        /// <para>
        /// This operation returns the number and type of objects in your
        /// service, the maximum allowed for each object type given the service
        /// tier, actual and maximum storage, and other limits that vary by
        /// tier. This request pulls information from the service so that you
        /// don't have to look up or calculate service limits.
        /// </para>
        /// <para>
        /// Statistics on document count and storage size are collected every
        /// few minutes, not in real time. Therefore, the statistics returned
        /// by this API may not reflect changes caused by recent indexing
        /// operations.
        /// </para>
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing <see cref="SearchServiceStatistics"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchServiceStatistics>> GetStatisticsAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetStatistics)}");
            scope.Start();
            try
            {
                return await ServiceClient.GetServiceStatisticsAsync(
                    options?.ClientRequestId,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
