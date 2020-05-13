// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Collections.Generic;
using System.Linq;

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
        private DataSourcesRestClient _dataSourcesClient;
        private IndexesRestClient _indexesClient;
        private IndexersRestClient _indexersClient;
        private SkillsetsRestClient _skillsetsClient;
        private SynonymMapsRestClient _synonymMapsClient;

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
        private HttpPipeline Pipeline { get; }

        /// <summary>
        /// Gets the <see cref="Azure.Core.Pipeline.ClientDiagnostics"/> used
        /// to provide tracing support for the client library.
        /// </summary>
        private ClientDiagnostics ClientDiagnostics { get; }

        /// <summary>
        /// Gets the REST API version of the Search service to use when making
        /// requests.
        /// </summary>
        private SearchClientOptions.ServiceVersion Version { get; }

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
        /// Gets the generated <see cref="DataSourcesRestClient"/> to make requests.
        /// </summary>
        private DataSourcesRestClient DataSourcesClient => LazyInitializer.EnsureInitialized(ref _dataSourcesClient, () => new DataSourcesRestClient(
            ClientDiagnostics,
            Pipeline,
            Endpoint.ToString(),
            Version.ToVersionString())
        );

        /// <summary>
        /// Gets the generated <see cref="IndexesRestClient"/> to make requests.
        /// </summary>
        private IndexesRestClient IndexesClient => LazyInitializer.EnsureInitialized(ref _indexesClient, () => new IndexesRestClient(
            ClientDiagnostics,
            Pipeline,
            Endpoint.ToString(),
            Version.ToVersionString())
        );

        /// <summary>
        /// Gets the generated <see cref="IndexersRestClient"/> to make requests.
        /// </summary>
        private IndexersRestClient IndexersClient => LazyInitializer.EnsureInitialized(ref _indexersClient, () => new IndexersRestClient(
            ClientDiagnostics,
            Pipeline,
            Endpoint.ToString(),
            Version.ToVersionString())
        );

        /// <summary>
        /// Gets the generated <see cref="SkillsetsRestClient"/> to make requests.
        /// </summary>
        private SkillsetsRestClient SkillsetsClient => LazyInitializer.EnsureInitialized(ref _skillsetsClient, () => new SkillsetsRestClient(
            ClientDiagnostics,
            Pipeline,
            Endpoint.ToString(),
            Version.ToVersionString())
        );

        /// <summary>
        /// Gets the generated <see cref="SynonymMapsRestClient"/> to make requests.
        /// </summary>
        private SynonymMapsRestClient SynonymMapsClient => LazyInitializer.EnsureInitialized(ref _synonymMapsClient, () => new SynonymMapsRestClient(
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
        /// Initializes a new instance of the SearchServiceClient class.
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
        /// Initializes a new instance of the SearchServiceClient class.
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
        /// Get a <see cref="SearchClient"/> for the given <paramref name="indexName"/> to use for document operations like querying or adding documents to a Search Index.
        /// </summary>
        /// <param name="indexName">The name of the desired Search Index.</param>
        /// <returns>A SearchClient for the desired Search Index.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="indexName"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="indexName"/> is empty.</exception>
        /// <remarks>
        /// The same request <see cref="HttpPipeline"/> (including authentication and any other configuration) will be used for the
        /// <see cref="SearchClient"/>.
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

        #region Service operations

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
        public virtual Response<SearchServiceStatistics> GetServiceStatistics(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetServiceStatistics)}");
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
        public virtual async Task<Response<SearchServiceStatistics>> GetServiceStatisticsAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetServiceStatistics)}");
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
        #endregion

        #region Data Sources operations
        /// <summary>
        /// Creates a new data source.
        /// </summary>
        /// <param name="dataSource">Required. The <see cref="SearchIndexerDataSource"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerDataSource"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSource"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerDataSource> CreateDataSource(
            SearchIndexerDataSource dataSource,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateDataSource)}");
            scope.Start();
            try
            {
                return DataSourcesClient.Create(
                    dataSource,
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
        /// Creates a new data source.
        /// </summary>
        /// <param name="dataSource">Required. The <see cref="SearchIndexerDataSource"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerDataSource"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSource"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerDataSource>> CreateDataSourceAsync(
            SearchIndexerDataSource dataSource,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateDataSource)}");
            scope.Start();
            try
            {
                return await DataSourcesClient.CreateAsync(
                    dataSource,
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

        /// <summary>
        /// Creates a new data source or updates an existing data source.
        /// </summary>
        /// <param name="dataSource">Required. The <see cref="SearchIndexerDataSource"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerDataSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerDataSource"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSource"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerDataSource> CreateOrUpdateDataSource(
            SearchIndexerDataSource dataSource,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateOrUpdateDataSource)}");
            scope.Start();
            try
            {
                return DataSourcesClient.CreateOrUpdate(
                    dataSource?.Name,
                    dataSource,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? dataSource?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new data source or updates an existing data source.
        /// </summary>
        /// <param name="dataSource">Required. The <see cref="SearchIndexerDataSource"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerDataSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerDataSource"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSource"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerDataSource>> CreateOrUpdateDataSourceAsync(
            SearchIndexerDataSource dataSource,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateOrUpdateDataSource)}");
            scope.Start();
            try
            {
                return await DataSourcesClient.CreateOrUpdateAsync(
                    dataSource?.Name,
                    dataSource,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? dataSource?.ETag?.ToString() : null,
                    null,
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
        /// Deletes a data source.
        /// </summary>
        /// <param name="dataSourceName">The name of the <see cref="SearchIndexerDataSource"/> to delete.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteDataSource(
            string dataSourceName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteDataSource)}");
            scope.Start();
            try
            {
                return DataSourcesClient.Delete(
                    dataSourceName,
                    options?.ClientRequestId,
                    null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a data source.
        /// </summary>
        /// <param name="dataSourceName">The name of the <see cref="SearchIndexerDataSource"/> to delete.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteDataSourceAsync(
            string dataSourceName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteDataSource)}");
            scope.Start();
            try
            {
                return await DataSourcesClient.DeleteAsync(
                    dataSourceName,
                    options?.ClientRequestId,
                    null,
                    null,
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
        /// Deletes a data source.
        /// </summary>
        /// <param name="dataSource">The <see cref="SearchIndexerDataSource"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerDataSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSource"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteDataSource(
            SearchIndexerDataSource dataSource,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteDataSource)}");
            scope.Start();
            try
            {
                return DataSourcesClient.Delete(
                    dataSource?.Name,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? dataSource?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a data source.
        /// </summary>
        /// <param name="dataSource">The <see cref="SearchIndexerDataSource"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerDataSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSource"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteDataSourceAsync(
            SearchIndexerDataSource dataSource,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteDataSource)}");
            scope.Start();
            try
            {
                return await DataSourcesClient.DeleteAsync(
                    dataSource?.Name,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? dataSource?.ETag?.ToString() : null,
                    null,
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
        /// Gets a specific <see cref="SearchIndexerDataSource"/>.
        /// </summary>
        /// <param name="dataSourceName">Required. The name of the <see cref="SearchIndexerDataSource"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerDataSource"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerDataSource> GetDataSource(
            string dataSourceName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetDataSource)}");
            scope.Start();
            try
            {
                return DataSourcesClient.Get(
                    dataSourceName,
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
        /// Gets a specific <see cref="SearchIndexerDataSource"/>.
        /// </summary>
        /// <param name="dataSourceName">Required. The name of the <see cref="SearchIndexerDataSource"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerDataSource"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerDataSource>> GetDataSourceAsync(
            string dataSourceName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetDataSource)}");
            scope.Start();
            try
            {
                return await DataSourcesClient.GetAsync(
                    dataSourceName,
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

        /// <summary>
        /// Gets a list of all data sources.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSource"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<SearchIndexerDataSource>> GetDataSources(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetDataSources)}");
            scope.Start();
            try
            {
                Response<ListDataSourcesResult> result = DataSourcesClient.List(
                    Constants.All,
                    options?.ClientRequestId,
                    cancellationToken);

                return Response.FromValue(result.Value.DataSources, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all data sources.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSource"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<SearchIndexerDataSource>>> GetDataSourcesAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetDataSources)}");
            scope.Start();
            try
            {
                Response<ListDataSourcesResult> result = await DataSourcesClient.ListAsync(
                    Constants.All,
                    options?.ClientRequestId,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(result.Value.DataSources, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all data source names.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSource"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<string>> GetDataSourceNames(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetDataSourceNames)}");
            scope.Start();
            try
            {
                Response<ListDataSourcesResult> result = DataSourcesClient.List(
                    Constants.NameKey,
                    options?.ClientRequestId,
                    cancellationToken);

                IReadOnlyList<string> names = result.Value.DataSources.Select(value => value.Name).ToArray();
                return Response.FromValue(names, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all data source names.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSource"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetDataSourceNamesAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetDataSourceNames)}");
            scope.Start();
            try
            {
                Response<ListDataSourcesResult> result = await DataSourcesClient.ListAsync(
                    Constants.NameKey,
                    options?.ClientRequestId,
                    cancellationToken)
                    .ConfigureAwait(false);

                IReadOnlyList<string> names = result.Value.DataSources.Select(value => value.Name).ToArray();
                return Response.FromValue(names, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion

        #region Index operations
        /// <summary>
        /// Shows how an analyzer breaks text into tokens.
        /// </summary>
        /// <param name="indexName">The name of the index used to test an analyzer.</param>
        /// <param name="analyzeRequest">The <see cref="AnalyzeRequest"/> containing the text and analyzer or analyzer components to test.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing a list of <see cref="AnalyzedTokenInfo"/> for analyzed text.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> or <paramref name="analyzeRequest"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<AnalyzedTokenInfo>> AnalyzeText(
            string indexName,
            AnalyzeRequest analyzeRequest,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(AnalyzeText)}");
            scope.Start();
            try
            {
                Response<AnalyzeResult> result = IndexesClient.Analyze(
                    indexName,
                    analyzeRequest,
                    options?.ClientRequestId,
                    cancellationToken);

                return Response.FromValue(result.Value.Tokens, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Shows how an analyzer breaks text into tokens.
        /// </summary>
        /// <param name="indexName">The name of the index used to test an analyzer.</param>
        /// <param name="analyzeRequest">The <see cref="AnalyzeRequest"/> containing the text and analyzer or analyzer components to test.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing a list of <see cref="AnalyzedTokenInfo"/> for analyzed text.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> or <paramref name="analyzeRequest"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<AnalyzedTokenInfo>>> AnalyzeTextAsync(
            string indexName,
            AnalyzeRequest analyzeRequest,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(AnalyzeText)}");
            scope.Start();
            try
            {
                Response<AnalyzeResult> result = await IndexesClient.AnalyzeAsync(
                    indexName,
                    analyzeRequest,
                    options?.ClientRequestId,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(result.Value.Tokens, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new search index.
        /// </summary>
        /// <param name="index">Required. The <see cref="SearchIndex"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndex"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back fields set to their default values depending on the field type and other properties.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndex> CreateIndex(
            SearchIndex index,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateIndex)}");
            scope.Start();
            try
            {
                return IndexesClient.Create(
                    index,
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
        /// Creates a new search index.
        /// </summary>
        /// <param name="index">Required. The <see cref="SearchIndex"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndex"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back fields set to their default values depending on the field type and other properties.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndex>> CreateIndexAsync(
            SearchIndex index,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateIndex)}");
            scope.Start();
            try
            {
                return await IndexesClient.CreateAsync(
                    index,
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

        /// <summary>
        /// Creates a new search index or updates an existing index.
        /// </summary>
        /// <param name="index">Required. The <see cref="SearchIndex"/> to create or update.</param>
        /// <param name="allowIndexDowntime">
        /// Optional value indicating whether to allow analyzers, tokenizers, token filters, or character filters to be added to the index by temporarily taking the index
        /// offline for a few seconds. The default is false. This temporarily causes indexing and queries to fail.
        /// Performance and write availability of the index can be impaired for several minutes after the index is updated, or longer for very large indexes.
        /// </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndex.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndex"/> that was created or updated.
        /// This may differ slightly from what was passed in since the service may return back fields set to their default values depending on the field type and other properties.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndex> CreateOrUpdateIndex(
            SearchIndex index,
            bool allowIndexDowntime = false,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateOrUpdateIndex)}");
            scope.Start();
            try
            {
                return IndexesClient.CreateOrUpdate(
                    index?.Name,
                    index,
                    allowIndexDowntime,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? index?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new search index or updates an existing index.
        /// </summary>
        /// <param name="index">Required. The <see cref="SearchIndex"/> to create or update.</param>
        /// <param name="allowIndexDowntime">
        /// Optional value indicating whether to allow analyzers, tokenizers, token filters, or character filters to be added to the index by temporarily taking the index
        /// offline for a few seconds. The default is false. This temporarily causes indexing and queries to fail.
        /// Performance and write availability of the index can be impaired for several minutes after the index is updated, or longer for very large indexes.
        /// </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndex.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndex"/> that was created or updated.
        /// This may differ slightly from what was passed in since the service may return back fields set to their default values depending on the field type and other properties.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndex>> CreateOrUpdateIndexAsync(
            SearchIndex index,
            bool allowIndexDowntime = false,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateOrUpdateIndex)}");
            scope.Start();
            try
            {
                return await IndexesClient.CreateOrUpdateAsync(
                    index?.Name,
                    index,
                    allowIndexDowntime,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? index?.ETag?.ToString() : null,
                    null,
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
        /// Deletes a search index and all the documents it contains.
        /// </summary>
        /// <param name="indexName">Required. The name of the <see cref="SearchIndex"/> to delete.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteIndex(
            string indexName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteIndex)}");
            scope.Start();
            try
            {
                return IndexesClient.Delete(
                    indexName,
                    options?.ClientRequestId,
                    null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a search index and all the documents it contains.
        /// </summary>
        /// <param name="indexName">Required. The name of the <see cref="SearchIndex"/> to delete.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteIndexAsync(
            string indexName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteIndex)}");
            scope.Start();
            try
            {
                return await IndexesClient.DeleteAsync(
                    indexName,
                    options?.ClientRequestId,
                    null,
                    null,
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
        /// Deletes a search index and all the documents it contains.
        /// </summary>
        /// <param name="index">Required. The <see cref="SearchIndex"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndex.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteIndex(
            SearchIndex index,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteIndex)}");
            scope.Start();
            try
            {
                return IndexesClient.Delete(
                    index?.Name,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? index?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a search index and all the documents it contains.
        /// </summary>
        /// <param name="index">Required. The <see cref="SearchIndex"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndex.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteIndexAsync(
            SearchIndex index,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteIndex)}");
            scope.Start();
            try
            {
                return await IndexesClient.DeleteAsync(
                    index?.Name,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? index?.ETag?.ToString() : null,
                    null,
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
        /// Gets a specific <see cref="SearchIndex"/>.
        /// </summary>
        /// <param name="indexName">Required. The name of the index to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndex"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndex> GetIndex(
            string indexName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndex)}");
            scope.Start();
            try
            {
                return IndexesClient.Get(
                    indexName,
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
        /// Gets a specific <see cref="SearchIndex"/>.
        /// </summary>
        /// <param name="indexName">Required. The name of the index to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndex"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndex>> GetIndexAsync(
            string indexName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndex)}");
            scope.Start();
            try
            {
                return await IndexesClient.GetAsync(
                    indexName,
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

        /// <summary>
        /// Gets a list of all indexes.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Pageable{T}"/> from the server containing a list of <see cref="SearchIndex"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Pageable<SearchIndex> GetIndexes(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexes)}");
            scope.Start();
            try
            {
                return PageResponseEnumerator.CreateEnumerable((continuationToken) =>
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListIndexesResult> result = IndexesClient.List(
                        Constants.All,
                        options?.ClientRequestId,
                        cancellationToken);

                    return Page<SearchIndex>.FromValues(result.Value.Indexes, null, result.GetRawResponse());
                });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all indexes.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndex"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual AsyncPageable<SearchIndex> GetIndexesAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexes)}");
            scope.Start();
            try
            {
                return PageResponseEnumerator.CreateAsyncEnumerable(async (continuationToken) =>
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListIndexesResult> result = await IndexesClient.ListAsync(
                        Constants.All,
                        options?.ClientRequestId,
                        cancellationToken)
                        .ConfigureAwait(false);

                    return Page<SearchIndex>.FromValues(result.Value.Indexes, null, result.GetRawResponse());
                });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all index names.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Pageable{T}"/> from the server containing a list of <see cref="SearchIndex"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Pageable<string> GetIndexNames(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexNames)}");
            scope.Start();
            try
            {
                return PageResponseEnumerator.CreateEnumerable((continuationToken) =>
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListIndexesResult> result = IndexesClient.List(
                        Constants.NameKey,
                        options?.ClientRequestId,
                        cancellationToken);

                    IReadOnlyList<string> names = result.Value.Indexes.Select(value => value.Name).ToArray();
                    return Page<string>.FromValues(names, null, result.GetRawResponse());
                });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all index names.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndex"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual AsyncPageable<string> GetIndexNamesAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexNames)}");
            scope.Start();
            try
            {
                return PageResponseEnumerator.CreateAsyncEnumerable(async (continuationToken) =>
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListIndexesResult> result = await IndexesClient.ListAsync(
                        Constants.NameKey,
                        options?.ClientRequestId,
                        cancellationToken)
                        .ConfigureAwait(false);

                    IReadOnlyList<string> names = result.Value.Indexes.Select(value => value.Name).ToArray();
                    return Page<string>.FromValues(names, null, result.GetRawResponse());
                });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets <see cref="SearchIndexStatistics"/> for the given index, including a document count and storage usage.
        /// </summary>
        /// <param name="indexName">Required. The name of the index.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing <see cref="SearchIndexStatistics"/> names.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexStatistics> GetIndexStatistics(
            string indexName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexStatistics)}");
            scope.Start();
            try
            {
                return IndexesClient.GetStatistics(
                    indexName,
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
        /// Gets <see cref="SearchIndexStatistics"/> for the given index, including a document count and storage usage.
        /// </summary>
        /// <param name="indexName">Required. The name of the index.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing <see cref="SearchIndexStatistics"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexStatistics>> GetIndexStatisticsAsync(
            string indexName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexStatistics)}");
            scope.Start();
            try
            {
                return await IndexesClient.GetStatisticsAsync(
                    indexName,
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
        #endregion

        #region Indexer operations
        /// <summary>
        /// Creates a new indexer.
        /// </summary>
        /// <param name="indexer">Required. The <see cref="SearchIndex"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexer"/> created.
        /// This may differ slightly from what was passed into the service.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexer> CreateIndexer(
            SearchIndexer indexer,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.Create(
                    indexer,
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
        /// Creates a new indexer.
        /// </summary>
        /// <param name="indexer">Required. The <see cref="SearchIndexer"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexer"/> created.
        /// This may differ slightly from what was passed into the service.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexer>> CreateIndexerAsync(
            SearchIndexer indexer,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.CreateAsync(
                    indexer,
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

        /// <summary>
        /// Creates a new indexer or updates an existing indexer.
        /// </summary>
        /// <param name="indexer">Required. The <see cref="SearchIndexer"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexer.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexer"/> created.
        /// This may differ slightly from what was passed into the service.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexer> CreateOrUpdateIndexer(
            SearchIndexer indexer,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateOrUpdateIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.CreateOrUpdate(
                    indexer?.Name,
                    indexer,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? indexer?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new indexer or updates an existing indexer.
        /// </summary>
        /// <param name="indexer">Required. The <see cref="SearchIndexer"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexer.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexer"/> created.
        /// This may differ slightly from what was passed into the service.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexer>> CreateOrUpdateIndexerAsync(
            SearchIndexer indexer,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateOrUpdateIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.CreateOrUpdateAsync(
                    indexer?.Name,
                    indexer,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? indexer?.ETag?.ToString() : null,
                    null,
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
        /// Deletes an indexer.
        /// </summary>
        /// <param name="indexerName">The name of the <see cref="SearchIndexer"/> to delete.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteIndexer(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.Delete(
                    indexerName,
                    options?.ClientRequestId,
                    null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes an indexer.
        /// </summary>
        /// <param name="indexerName">The name of the <see cref="SearchIndexer"/> to delete.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteIndexerAsync(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.DeleteAsync(
                    indexerName,
                    options?.ClientRequestId,
                    null,
                    null,
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
        /// Deletes an indexer.
        /// </summary>
        /// <param name="indexer">The <see cref="SearchIndexer"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexer.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteIndexer(
            SearchIndexer indexer,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.Delete(
                    indexer?.Name,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? indexer?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes an indexer.
        /// </summary>
        /// <param name="indexer">The <see cref="SearchIndexer"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexer.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteIndexerAsync(
            SearchIndexer indexer,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.DeleteAsync(
                    indexer?.Name,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? indexer?.ETag?.ToString() : null,
                    null,
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
        /// Gets a specific <see cref="SearchIndexer"/>.
        /// </summary>
        /// <param name="indexerName">Required. The name of the <see cref="SearchIndexer"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexer> GetIndexer(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.Get(
                    indexerName,
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
        /// Gets a specific <see cref="SearchIndexer"/>.
        /// </summary>
        /// <param name="indexerName">Required. The name of the <see cref="SearchIndexer"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexer>> GetIndexerAsync(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.GetAsync(
                    indexerName,
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

        /// <summary>
        /// Gets a list of all indexers.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<SearchIndexer>> GetIndexers(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexers)}");
            scope.Start();
            try
            {
                Response<ListIndexersResult> result = IndexersClient.List(
                    Constants.All,
                    options?.ClientRequestId,
                    cancellationToken);

                return Response.FromValue(result.Value.Indexers, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all indexers.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<SearchIndexer>>> GetIndexersAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexers)}");
            scope.Start();
            try
            {
                Response<ListIndexersResult> result = await IndexersClient.ListAsync(
                    Constants.All,
                    options?.ClientRequestId,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(result.Value.Indexers, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all indexer names.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<string>> GetIndexerNames(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexerNames)}");
            scope.Start();
            try
            {
                Response<ListIndexersResult> result = IndexersClient.List(
                    Constants.NameKey,
                    options?.ClientRequestId,
                    cancellationToken);

                IReadOnlyList<string> names = result.Value.Indexers.Select(value => value.Name).ToArray();
                return Response.FromValue(names, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all indexer names.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetIndexerNamesAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexerNames)}");
            scope.Start();
            try
            {
                Response<ListIndexersResult> result = await IndexersClient.ListAsync(
                    Constants.NameKey,
                    options?.ClientRequestId,
                    cancellationToken)
                    .ConfigureAwait(false);

                IReadOnlyList<string> names = result.Value.Indexers.Select(value => value.Name).ToArray();
                return Response.FromValue(names, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the current status and execution history of an indexer.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer for which to retrieve status.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerStatus"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerStatus> GetIndexerStatus(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexerStatus)}");
            scope.Start();
            try
            {
                return IndexersClient.GetStatus(
                    indexerName,
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
        /// Gets the current status and execution history of an indexer.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer for which to retrieve status.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerStatus"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerStatus>> GetIndexerStatusAsync(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetIndexerStatus)}");
            scope.Start();
            try
            {
                return await IndexersClient.GetStatusAsync(
                    indexerName,
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

        /// <summary>
        /// Resets the change tracking state associated with an indexer.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer to reset.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response ResetIndexer(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(ResetIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.Reset(
                    indexerName,
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
        /// Resets the change tracking state associated with an indexer.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer to reset.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> ResetIndexerAsync(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(ResetIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.ResetAsync(
                    indexerName,
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

        /// <summary>
        /// Run an indexer now.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer to run.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response RunIndexer(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(RunIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.Run(
                    indexerName,
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
        /// Run an indexer now.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer to run.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> RunIndexerAsync(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(RunIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.RunAsync(
                    indexerName,
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
        #endregion

        #region Skillsets operations
        /// <summary>
        /// Creates a new skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerSkillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerSkillset> CreateSkillset(
            SearchIndexerSkillset skillset,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateSkillset)}");
            scope.Start();
            try
            {
                return SkillsetsClient.Create(
                    skillset,
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
        /// Creates a new skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerSkillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerSkillset>> CreateSkillsetAsync(
            SearchIndexerSkillset skillset,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateSkillset)}");
            scope.Start();
            try
            {
                return await SkillsetsClient.CreateAsync(
                    skillset,
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

        /// <summary>
        /// Creates a new skillset or updates an existing skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerSkillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerSkillset> CreateOrUpdateSkillset(
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateOrUpdateSkillset)}");
            scope.Start();
            try
            {
                return SkillsetsClient.CreateOrUpdate(
                    skillset?.Name,
                    skillset,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? skillset?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new skillset or updates an existing skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerSkillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerSkillset>> CreateOrUpdateSkillsetAsync(
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateOrUpdateSkillset)}");
            scope.Start();
            try
            {
                return await SkillsetsClient.CreateOrUpdateAsync(
                    skillset?.Name,
                    skillset,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? skillset?.ETag?.ToString() : null,
                    null,
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
        /// Deletes a skillset.
        /// </summary>
        /// <param name="skillsetName">The name of the <see cref="SearchIndexerSkillset"/> to delete.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteSkillset(
            string skillsetName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteSkillset)}");
            scope.Start();
            try
            {
                return SkillsetsClient.Delete(
                    skillsetName,
                    options?.ClientRequestId,
                    null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a skillset.
        /// </summary>
        /// <param name="skillsetName">The name of the <see cref="SearchIndexerSkillset"/> to delete.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteSkillsetAsync(
            string skillsetName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteSkillset)}");
            scope.Start();
            try
            {
                return await SkillsetsClient.DeleteAsync(
                    skillsetName,
                    options?.ClientRequestId,
                    null,
                    null,
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
        /// Deletes a skillset.
        /// </summary>
        /// <param name="skillset">The <see cref="SearchIndexerSkillset"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteSkillset(
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteSkillset)}");
            scope.Start();
            try
            {
                return SkillsetsClient.Delete(
                    skillset?.Name,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? skillset?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a skillset.
        /// </summary>
        /// <param name="skillset">The <see cref="SearchIndexerSkillset"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteSkillsetAsync(
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteSkillset)}");
            scope.Start();
            try
            {
                return await SkillsetsClient.DeleteAsync(
                    skillset?.Name,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? skillset?.ETag?.ToString() : null,
                    null,
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
        /// Gets a specific <see cref="SearchIndexerSkillset"/>.
        /// </summary>
        /// <param name="skillsetName">Required. The name of the <see cref="SearchIndexerSkillset"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerSkillset"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerSkillset> GetSkillset(
            string skillsetName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSkillset)}");
            scope.Start();
            try
            {
                return SkillsetsClient.Get(
                    skillsetName,
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
        /// Gets a specific <see cref="SearchIndexerSkillset"/>.
        /// </summary>
        /// <param name="skillsetName">Required. The name of the <see cref="SearchIndexerSkillset"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerSkillset"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerSkillset>> GetSkillsetAsync(
            string skillsetName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSkillset)}");
            scope.Start();
            try
            {
                return await SkillsetsClient.GetAsync(
                    skillsetName,
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

        /// <summary>
        /// Gets a list of all skillsets.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerSkillset"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<SearchIndexerSkillset>> GetSkillsets(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSkillsets)}");
            scope.Start();
            try
            {
                Response<ListSkillsetsResult> result = SkillsetsClient.List(
                    Constants.All,
                    options?.ClientRequestId,
                    cancellationToken);

                return Response.FromValue(result.Value.Skillsets, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all skillsets.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerSkillset"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<SearchIndexerSkillset>>> GetSkillsetsAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSkillsets)}");
            scope.Start();
            try
            {
                Response<ListSkillsetsResult> result = await SkillsetsClient.ListAsync(
                    Constants.All,
                    options?.ClientRequestId,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(result.Value.Skillsets, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all skillset names.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerSkillset"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<string>> GetSkillsetNames(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSkillsetNames)}");
            scope.Start();
            try
            {
                Response<ListSkillsetsResult> result = SkillsetsClient.List(
                    Constants.NameKey,
                    options?.ClientRequestId,
                    cancellationToken);

                IReadOnlyList<string> names = result.Value.Skillsets.Select(value => value.Name).ToArray();
                return Response.FromValue(names, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all skillset names.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerSkillset"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetSkillsetNamesAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSkillsetNames)}");
            scope.Start();
            try
            {
                Response<ListSkillsetsResult> result = await SkillsetsClient.ListAsync(
                    Constants.NameKey,
                    options?.ClientRequestId,
                    cancellationToken)
                    .ConfigureAwait(false);

                IReadOnlyList<string> names = result.Value.Skillsets.Select(value => value.Name).ToArray();
                return Response.FromValue(names, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion

        #region SynonymMaps operations
        /// <summary>
        /// Creates a new synonym map.
        /// </summary>
        /// <param name="synonymMap">Required. The <see cref="SynonymMap"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SynonymMap"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SynonymMap> CreateSynonymMap(
            SynonymMap synonymMap,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateSynonymMap)}");
            scope.Start();
            try
            {
                return SynonymMapsClient.Create(
                    synonymMap,
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
        /// Creates a new synonym map.
        /// </summary>
        /// <param name="synonymMap">Required. The <see cref="SynonymMap"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SynonymMap"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SynonymMap>> CreateSynonymMapAsync(
            SynonymMap synonymMap,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateSynonymMap)}");
            scope.Start();
            try
            {
                return await SynonymMapsClient.CreateAsync(
                    synonymMap,
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

        /// <summary>
        /// Creates a new synonym map or updates an existing synonym map.
        /// </summary>
        /// <param name="synonymMap">Required. The <see cref="SynonymMap"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SynonymMap.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SynonymMap"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SynonymMap> CreateOrUpdateSynonymMap(
            SynonymMap synonymMap,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateOrUpdateSynonymMap)}");
            scope.Start();
            try
            {
                return SynonymMapsClient.CreateOrUpdate(
                    synonymMap?.Name,
                    synonymMap,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? synonymMap?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new synonym map or updates an existing synonym map.
        /// </summary>
        /// <param name="synonymMap">Required. The <see cref="SynonymMap"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SynonymMap.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SynonymMap"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SynonymMap>> CreateOrUpdateSynonymMapAsync(
            SynonymMap synonymMap,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(CreateOrUpdateSynonymMap)}");
            scope.Start();
            try
            {
                return await SynonymMapsClient.CreateOrUpdateAsync(
                    synonymMap?.Name,
                    synonymMap,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? synonymMap?.ETag?.ToString() : null,
                    null,
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
        /// Deletes a synonym map.
        /// </summary>
        /// <param name="synonymMapName">The name of a <see cref="SynonymMap"/> to delete.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> or <see cref="SynonymMap.Name"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteSynonymMap(
            string synonymMapName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteSynonymMap)}");
            scope.Start();
            try
            {
                return SynonymMapsClient.Delete(
                    synonymMapName,
                    options?.ClientRequestId,
                    null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a synonym map.
        /// </summary>
        /// <param name="synonymMapName">The name of a <see cref="SynonymMap"/> to delete.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> or <see cref="SynonymMap.Name"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteSynonymMapAsync(
            string synonymMapName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteSynonymMap)}");
            scope.Start();
            try
            {
                return await SynonymMapsClient.DeleteAsync(
                    synonymMapName,
                    options?.ClientRequestId,
                    null,
                    null,
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
        /// Deletes a synonym map.
        /// </summary>
        /// <param name="synonymMap">The <see cref="SynonymMap"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SynonymMap.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> or <see cref="SynonymMap.Name"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteSynonymMap(
            SynonymMap synonymMap,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteSynonymMap)}");
            scope.Start();
            try
            {
                return SynonymMapsClient.Delete(
                    synonymMap?.Name,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? synonymMap?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a synonym map.
        /// </summary>
        /// <param name="synonymMap">The <see cref="SynonymMap"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SynonymMap.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> or <see cref="SynonymMap.Name"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteSynonymMapAsync(
            SynonymMap synonymMap,
            bool onlyIfUnchanged = false,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(DeleteSynonymMap)}");
            scope.Start();
            try
            {
                return await SynonymMapsClient.DeleteAsync(
                    synonymMap?.Name,
                    options?.ClientRequestId,
                    onlyIfUnchanged ? synonymMap?.ETag?.ToString() : null,
                    null,
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
        /// Gets a specific <see cref="SynonymMap"/>.
        /// </summary>
        /// <param name="synonymMapName">Required. The name of the <see cref="SynonymMap"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SynonymMap"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SynonymMap> GetSynonymMap(
            string synonymMapName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSynonymMap)}");
            scope.Start();
            try
            {
                return SynonymMapsClient.Get(
                    synonymMapName,
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
        /// Gets a specific <see cref="SynonymMap"/>.
        /// </summary>
        /// <param name="synonymMapName">Required. The name of the <see cref="SynonymMap"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SynonymMap"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SynonymMap>> GetSynonymMapAsync(
            string synonymMapName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSynonymMap)}");
            scope.Start();
            try
            {
                return await SynonymMapsClient.GetAsync(
                    synonymMapName,
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

        /// <summary>
        /// Gets a list of all synonym maps.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SynonymMap"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<SynonymMap>> GetSynonymMaps(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSynonymMaps)}");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = SynonymMapsClient.List(
                    Constants.All,
                    options?.ClientRequestId,
                    cancellationToken);

                return Response.FromValue(result.Value.SynonymMaps, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all synonym maps.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SynonymMap"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<SynonymMap>>> GetSynonymMapsAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSynonymMaps)}");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = await SynonymMapsClient.ListAsync(
                    Constants.All,
                    options?.ClientRequestId,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(result.Value.SynonymMaps, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all synonym map names.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SynonymMap"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<string>> GetSynonymMapNames(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSynonymMapNames)}");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = SynonymMapsClient.List(
                    Constants.NameKey,
                    options?.ClientRequestId,
                    cancellationToken);

                IReadOnlyList<string> names = result.Value.SynonymMaps.Select(value => value.Name).ToArray();
                return Response.FromValue(names, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all synonym map names.
        /// </summary>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SynonymMap"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetSynonymMapNamesAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchServiceClient)}.{nameof(GetSynonymMapNames)}");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = await SynonymMapsClient.ListAsync(
                    Constants.NameKey,
                    options?.ClientRequestId,
                    cancellationToken)
                    .ConfigureAwait(false);

                IReadOnlyList<string> names = result.Value.SynonymMaps.Select(value => value.Name).ToArray();
                return Response.FromValue(names, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        #endregion
    }
}
