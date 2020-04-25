// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Collections.Generic;

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
        /// Get a <see cref="SearchIndexClient"/> for the given <paramref name="indexName"/> to use for document operations like querying or adding documents to a Search Index.
        /// </summary>
        /// <param name="indexName">The name of the desired Search Index.</param>
        /// <returns>A SearchIndexClient for the desired Search Index.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="indexName"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="indexName"/> is empty.</exception>
        /// <remarks>
        /// The same request <see cref="HttpPipeline"/> (including authentication and any other configuration) will be used for the
        /// <see cref="SearchIndexClient"/>.
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
        [ForwardsClientCalls]
        public virtual Response<SearchServiceStatistics> GetServiceStatistics(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            ServiceClient.GetServiceStatistics(
                options?.ClientRequestId,
                cancellationToken);

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
        [ForwardsClientCalls]
        public virtual async Task<Response<SearchServiceStatistics>> GetServiceStatisticsAsync(
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await ServiceClient.GetServiceStatisticsAsync(
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);
        #endregion

        #region Data Sources operations
        /// <summary>
        /// Creates a new data source.
        /// </summary>
        /// <param name="dataSource">Required. The <see cref="DataSource"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="DataSource"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSource"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<DataSource> CreateDataSource(
            DataSource dataSource,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            DataSourcesClient.Create(
                dataSource,
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Creates a new data source.
        /// </summary>
        /// <param name="dataSource">Required. The <see cref="DataSource"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="DataSource"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSource"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DataSource>> CreateDataSourceAsync(
            DataSource dataSource,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await DataSourcesClient.CreateAsync(
                dataSource,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a new data source or updates an existing data source.
        /// </summary>
        /// <param name="dataSource">Required. The <see cref="DataSource"/> to create or update.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the data source should be updated based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="DataSource"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSource"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<DataSource> CreateOrUpdateDataSource(
            DataSource dataSource,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            DataSourcesClient.CreateOrUpdate(
                dataSource?.Name,
                dataSource,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken);

        /// <summary>
        /// Creates a new data source or updates an existing data source.
        /// </summary>
        /// <param name="dataSource">Required. The <see cref="DataSource"/> to create or update.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the data source should be updated based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="DataSource"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSource"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DataSource>> CreateOrUpdateDataSourceAsync(
            DataSource dataSource,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await DataSourcesClient.CreateOrUpdateAsync(
                dataSource?.Name,
                dataSource,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes a data source.
        /// </summary>
        /// <param name="dataSourceName">The name of the data source to delete.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the data source should be deleted based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response DeleteDataSource(
            string dataSourceName,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            DataSourcesClient.Delete(
                dataSourceName,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken);

        /// <summary>
        /// Deletes a data source.
        /// </summary>
        /// <param name="dataSourceName">The name of the data source to delete.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the data source should be deleted based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteDataSourceAsync(
            string dataSourceName,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await DataSourcesClient.DeleteAsync(
                dataSourceName,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets a specific <see cref="DataSource"/>.
        /// </summary>
        /// <param name="dataSourceName">Required. The name of the <see cref="DataSource"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="DataSource"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<DataSource> GetDataSource(
            string dataSourceName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            DataSourcesClient.Get(
                dataSourceName,
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Gets a specific <see cref="DataSource"/>.
        /// </summary>
        /// <param name="dataSourceName">Required. The name of the <see cref="DataSource"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="DataSource"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<DataSource>> GetDataSourceAsync(
            string dataSourceName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await DataSourcesClient.GetAsync(
                dataSourceName,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets a list of all data sources.
        /// </summary>
        /// <param name="selectProperties">Optional property names to select. The default is all properties.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="DataSource"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<IReadOnlyList<DataSource>> GetDataSources(
            IEnumerable<string> selectProperties = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Response<ListDataSourcesResult> result = DataSourcesClient.List(
                selectProperties.CommaJoin() ?? Constants.All,
                options?.ClientRequestId,
                cancellationToken);

            return Response.FromValue(result.Value.DataSources, result.GetRawResponse());
        }

        /// <summary>
        /// Gets a list of all data sources.
        /// </summary>
        /// <param name="selectProperties">Optional property names to select. The default is all properties.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="DataSource"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<IReadOnlyList<DataSource>>> GetDataSourcesAsync(
            IEnumerable<string> selectProperties = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Response<ListDataSourcesResult> result = await DataSourcesClient.ListAsync(
                selectProperties.CommaJoin() ?? Constants.All,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(result.Value.DataSources, result.GetRawResponse());
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
        /// The <see cref="Response{T}"/> from the server containing a list of <see cref="TokenInfo"/> for analyzed text.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> or <paramref name="analyzeRequest"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<IReadOnlyList<TokenInfo>> AnalyzeText(
            string indexName,
            AnalyzeRequest analyzeRequest,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Response<AnalyzeResult> result = IndexesClient.Analyze(
                indexName,
                analyzeRequest,
                options?.ClientRequestId,
                cancellationToken);

            return Response.FromValue(result.Value.Tokens, result.GetRawResponse());
        }

        /// <summary>
        /// Shows how an analyzer breaks text into tokens.
        /// </summary>
        /// <param name="indexName">The name of the index used to test an analyzer.</param>
        /// <param name="analyzeRequest">The <see cref="AnalyzeRequest"/> containing the text and analyzer or analyzer components to test.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing a list of <see cref="TokenInfo"/> for analyzed text.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> or <paramref name="analyzeRequest"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<IReadOnlyList<TokenInfo>>> AnalyzeTextAsync(
            string indexName,
            AnalyzeRequest analyzeRequest,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Response<AnalyzeResult> result = await IndexesClient.AnalyzeAsync(
                indexName,
                analyzeRequest,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(result.Value.Tokens, result.GetRawResponse());
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
        [ForwardsClientCalls]
        public virtual Response<SearchIndex> CreateIndex(
            SearchIndex index,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexesClient.Create(
                index,
                options?.ClientRequestId,
                cancellationToken);

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
        [ForwardsClientCalls]
        public virtual async Task<Response<SearchIndex>> CreateIndexAsync(
            SearchIndex index,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexesClient.CreateAsync(
                index,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a new search index or updates an existing index.
        /// </summary>
        /// <param name="index">Required. The <see cref="SearchIndex"/> to create or update.</param>
        /// <param name="allowIndexDowntime">
        /// Optional value indicating whether to allow analyzers, tokenizers, token filters, or character filters to be added to the index by temporarily taking the index
        /// offline for a few seconds. The default is false. This temporarily causes indexing and queries to fail.
        /// Performance and write availability of the index can be impaired for several minutes after the index is updated, or longer for very large indexes.
        /// </param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the index should be updated based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndex"/> that was created or updated.
        /// This may differ slightly from what was passed in since the service may return back fields set to their default values depending on the field type and other properties.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<SearchIndex> CreateOrUpdateIndex(
            SearchIndex index,
            bool allowIndexDowntime = false,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexesClient.CreateOrUpdate(
                index?.Name,
                index,
                allowIndexDowntime,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken);

        /// <summary>
        /// Creates a new search index or updates an existing index.
        /// </summary>
        /// <param name="index">Required. The <see cref="SearchIndex"/> to create or update.</param>
        /// <param name="allowIndexDowntime">
        /// Optional value indicating whether to allow analyzers, tokenizers, token filters, or character filters to be added to the index by temporarily taking the index
        /// offline for a few seconds. The default is false. This temporarily causes indexing and queries to fail.
        /// Performance and write availability of the index can be impaired for several minutes after the index is updated, or longer for very large indexes.
        /// </param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the index should be updated based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndex"/> that was created or updated.
        /// This may differ slightly from what was passed in since the service may return back fields set to their default values depending on the field type and other properties.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SearchIndex>> CreateOrUpdateIndexAsync(
            SearchIndex index,
            bool allowIndexDowntime = false,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexesClient.CreateOrUpdateAsync(
                index?.Name,
                index,
                allowIndexDowntime,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes a search index and all the documents it contains.
        /// </summary>
        /// <param name="indexName">Required. The name of the index to delete.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the index should be deleted based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response DeleteIndex(
            string indexName,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexesClient.Delete(
                indexName,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken);

        /// <summary>
        /// Deletes a search index and all the documents it contains.
        /// </summary>
        /// <param name="indexName">Required. The name of the index to delete.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the index should be deleted based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteIndexAsync(
            string indexName,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexesClient.DeleteAsync(
                indexName,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets a specific <see cref="SearchIndex"/>.
        /// </summary>
        /// <param name="indexName">Required. The name of the index to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndex"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<SearchIndex> GetIndex(
            string indexName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexesClient.Get(
                indexName,
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Gets a specific <see cref="SearchIndex"/>.
        /// </summary>
        /// <param name="indexName">Required. The name of the index to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndex"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SearchIndex>> GetIndexAsync(
            string indexName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexesClient.GetAsync(
                indexName,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets a list of all indexes.
        /// </summary>
        /// <param name="selectProperties">Optional property names to select. The default is all properties.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Pageable{T}"/> from the server containing a list of <see cref="SearchIndex"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Pageable<SearchIndex> GetIndexes(
            IEnumerable<string> selectProperties = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) => PageResponseEnumerator.CreateEnumerable((continuationToken) =>
            {
                if (continuationToken != null)
                {
                    throw new NotSupportedException("A continuation token is unexpected and unsupported at this time.");
                }

                Response<ListIndexesResult> result = IndexesClient.List(
                    selectProperties.CommaJoin() ?? Constants.All,
                    options?.ClientRequestId,
                    cancellationToken);

                return Page<SearchIndex>.FromValues(result.Value.Indexes, null, result.GetRawResponse());
            });

        /// <summary>
        /// Gets a list of all indexes.
        /// </summary>
        /// <param name="selectProperties">Optional property names to select. The default is all properties.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndex"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual AsyncPageable<SearchIndex> GetIndexesAsync(
            IEnumerable<string> selectProperties = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) => PageResponseEnumerator.CreateAsyncEnumerable(async (continuationToken) =>
            {
                if (continuationToken != null)
                {
                    throw new NotSupportedException("A continuation token is unexpected and unsupported at this time.");
                }

                Response<ListIndexesResult> result = await IndexesClient.ListAsync(
                    selectProperties.CommaJoin() ?? Constants.All,
                    options?.ClientRequestId,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Page<SearchIndex>.FromValues(result.Value.Indexes, null, result.GetRawResponse());
            });

        /// <summary>
        /// Gets <see cref="SearchIndexStatistics"/> for the given index, including a document count and storage usage.
        /// </summary>
        /// <param name="indexName">Required. The name of the index.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing <see cref="SearchIndexStatistics"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<SearchIndexStatistics> GetIndexStatistics(
            string indexName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexesClient.GetStatistics(
                indexName,
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Gets <see cref="SearchIndexStatistics"/> for the given index, including a document count and storage usage.
        /// </summary>
        /// <param name="indexName">Required. The name of the index.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing <see cref="SearchIndexStatistics"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SearchIndexStatistics>> GetIndexStatisticsAsync(
            string indexName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexesClient.GetStatisticsAsync(
                indexName,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);
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
        [ForwardsClientCalls]
        public virtual Response<SearchIndexer> CreateIndexer(
            SearchIndexer indexer,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexersClient.Create(
                indexer,
                options?.ClientRequestId,
                cancellationToken);

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
        [ForwardsClientCalls]
        public virtual async Task<Response<SearchIndexer>> CreateIndexerAsync(
            SearchIndexer indexer,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexersClient.CreateAsync(
                indexer,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a new indexer or updates an existing indexer.
        /// </summary>
        /// <param name="indexer">Required. The <see cref="SearchIndexer"/> to create or update.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the indexer should be updated based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexer"/> created.
        /// This may differ slightly from what was passed into the service.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<SearchIndexer> CreateOrUpdateIndexer(
            SearchIndexer indexer,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexersClient.CreateOrUpdate(
                indexer?.Name,
                indexer,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken);

        /// <summary>
        /// Creates a new indexer or updates an existing indexer.
        /// </summary>
        /// <param name="indexer">Required. The <see cref="SearchIndexer"/> to create or update.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the indexer should be updated based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexer"/> created.
        /// This may differ slightly from what was passed into the service.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SearchIndexer>> CreateOrUpdateIndexerAsync(
            SearchIndexer indexer,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexersClient.CreateOrUpdateAsync(
                indexer?.Name,
                indexer,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes an indexer.
        /// </summary>
        /// <param name="indexerName">The name of the indexer to delete.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the indexer should be deleted based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response DeleteIndexer(
            string indexerName,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexersClient.Delete(
                indexerName,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken);

        /// <summary>
        /// Deletes an indexer.
        /// </summary>
        /// <param name="indexerName">The name of the indexer to delete.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the indexer should be deleted based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteIndexerAsync(
            string indexerName,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexersClient.DeleteAsync(
                indexerName,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets a specific <see cref="SearchIndexer"/>.
        /// </summary>
        /// <param name="indexerName">Required. The name of the <see cref="SearchIndexer"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<SearchIndexer> GetIndexer(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexersClient.Get(
                indexerName,
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Gets a specific <see cref="SearchIndexer"/>.
        /// </summary>
        /// <param name="indexerName">Required. The name of the <see cref="SearchIndexer"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SearchIndexer>> GetIndexerAsync(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexersClient.GetAsync(
                indexerName,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets a list of all indexers.
        /// </summary>
        /// <param name="selectProperties">Optional property names to select. The default is all properties.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<IReadOnlyList<SearchIndexer>> GetIndexers(
            IEnumerable<string> selectProperties = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Response<ListIndexersResult> result = IndexersClient.List(
                selectProperties.CommaJoin() ?? Constants.All,
                options?.ClientRequestId,
                cancellationToken);

            return Response.FromValue(result.Value.Indexers, result.GetRawResponse());
        }

        /// <summary>
        /// Gets a list of all indexers.
        /// </summary>
        /// <param name="selectProperties">Optional property names to select. The default is all properties.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<IReadOnlyList<SearchIndexer>>> GetIndexersAsync(
            IEnumerable<string> selectProperties = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Response<ListIndexersResult> result = await IndexersClient.ListAsync(
                selectProperties.CommaJoin() ?? Constants.All,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(result.Value.Indexers, result.GetRawResponse());
        }

        /// <summary>
        /// Gets the current status and execution history of an indexer.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer for which to retrieve status.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="IndexerExecutionInfo"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<IndexerExecutionInfo> GetIndexerStatus(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexersClient.GetStatus(
                indexerName,
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Gets the current status and execution history of an indexer.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer for which to retrieve status.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="IndexerExecutionInfo"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<IndexerExecutionInfo>> GetIndexerStatusAsync(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexersClient.GetStatusAsync(
                indexerName,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Resets the change tracking state associated with an indexer.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer to reset.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response ResetIndexer(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexersClient.Reset(
                indexerName,
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Resets the change tracking state associated with an indexer.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer to reset.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response> ResetIndexerAsync(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexersClient.ResetAsync(
                indexerName,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Run an indexer now.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer to run.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response RunIndexer(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            IndexersClient.Run(
                indexerName,
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Run an indexer now.
        /// </summary>
        /// <param name="indexerName">Required. The name of the indexer to run.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response> RunIndexerAsync(
            string indexerName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await IndexersClient.RunAsync(
                indexerName,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);
        #endregion

        #region Skillsets operations
        /// <summary>
        /// Creates a new skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="Skillset"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="Skillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<Skillset> CreateSkillset(
            Skillset skillset,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            SkillsetsClient.Create(
                skillset,
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Creates a new skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="Skillset"/> to create.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="Skillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<Skillset>> CreateSkillsetAsync(
            Skillset skillset,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SkillsetsClient.CreateAsync(
                skillset,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a new skillset or updates an existing skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="Skillset"/> to create or update.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the skillset should be updated based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="Skillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<Skillset> CreateOrUpdateSkillset(
            Skillset skillset,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            SkillsetsClient.CreateOrUpdate(
                skillset?.Name,
                skillset,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken);

        /// <summary>
        /// Creates a new skillset or updates an existing skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="Skillset"/> to create or update.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the skillset should be updated based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="Skillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<Skillset>> CreateOrUpdateSkillsetAsync(
            Skillset skillset,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SkillsetsClient.CreateOrUpdateAsync(
                skillset?.Name,
                skillset,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes a skillset.
        /// </summary>
        /// <param name="skillsetName">The name of the skillset to delete.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the skillset should be deleted based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response DeleteSkillset(
            string skillsetName,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            SkillsetsClient.Delete(
                skillsetName,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken);

        /// <summary>
        /// Deletes a skillset.
        /// </summary>
        /// <param name="skillsetName">The name of the skillset to delete.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the skillset should be deleted based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteSkillsetAsync(
            string skillsetName,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SkillsetsClient.DeleteAsync(
                skillsetName,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets a specific <see cref="Skillset"/>.
        /// </summary>
        /// <param name="skillsetName">Required. The name of the <see cref="Skillset"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="Skillset"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<Skillset> GetSkillset(
            string skillsetName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            SkillsetsClient.Get(
                skillsetName,
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Gets a specific <see cref="Skillset"/>.
        /// </summary>
        /// <param name="skillsetName">Required. The name of the <see cref="Skillset"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="Skillset"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<Skillset>> GetSkillsetAsync(
            string skillsetName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SkillsetsClient.GetAsync(
                skillsetName,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets a list of all skillsets.
        /// </summary>
        /// <param name="selectProperties">Optional property names to select. The default is all properties.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="Skillset"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<IReadOnlyList<Skillset>> GetSkillsets(
            IEnumerable<string> selectProperties = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Response<ListSkillsetsResult> result = SkillsetsClient.List(
                selectProperties.CommaJoin() ?? Constants.All,
                options?.ClientRequestId,
                cancellationToken);

            return Response.FromValue(result.Value.Skillsets, result.GetRawResponse());
        }

        /// <summary>
        /// Gets a list of all skillsets.
        /// </summary>
        /// <param name="selectProperties">Optional property names to select. The default is all properties.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="Skillset"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<IReadOnlyList<Skillset>>> GetSkillsetsAsync(
            IEnumerable<string> selectProperties = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            Response<ListSkillsetsResult> result = await SkillsetsClient.ListAsync(
                selectProperties.CommaJoin() ?? Constants.All,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(result.Value.Skillsets, result.GetRawResponse());
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
        [ForwardsClientCalls]
        public virtual Response<SynonymMap> CreateSynonymMap(
            SynonymMap synonymMap,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            SynonymMapsClient.Create(
                synonymMap,
                options?.ClientRequestId,
                cancellationToken);

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
        [ForwardsClientCalls]
        public virtual async Task<Response<SynonymMap>> CreateSynonymMapAsync(
            SynonymMap synonymMap,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SynonymMapsClient.CreateAsync(
                synonymMap,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a new synonym map or updates an existing synonym map.
        /// </summary>
        /// <param name="synonymMap">Required. The <see cref="SynonymMap"/> to create or update.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the synonym map should be updated based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SynonymMap"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<SynonymMap> CreateOrUpdateSynonymMap(
            SynonymMap synonymMap,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            SynonymMapsClient.CreateOrUpdate(
                synonymMap?.Name,
                synonymMap,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken);

        /// <summary>
        /// Creates a new synonym map or updates an existing synonym map.
        /// </summary>
        /// <param name="synonymMap">Required. The <see cref="SynonymMap"/> to create or update.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the synonym map should be updated based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SynonymMap"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SynonymMap>> CreateOrUpdateSynonymMapAsync(
            SynonymMap synonymMap,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SynonymMapsClient.CreateOrUpdateAsync(
                synonymMap?.Name,
                synonymMap,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes a synonym map.
        /// </summary>
        /// <param name="synonymMapName">The name of the synonym map to delete.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the synonym map should be deleted based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response DeleteSynonymMap(
            string synonymMapName,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            SynonymMapsClient.Delete(
                synonymMapName,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken);

        /// <summary>
        /// Deletes a synonym map.
        /// </summary>
        /// <param name="synonymMapName">The name of the synonym map to delete.</param>
        /// <param name="accessConditions">Optional match conditions used to determine whether the synonym map should be deleted based on whether it changed.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteSynonymMapAsync(
            string synonymMapName,
            MatchConditions accessConditions = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SynonymMapsClient.DeleteAsync(
                synonymMapName,
                options?.ClientRequestId,
                accessConditions?.IfMatch?.ToString(),
                accessConditions?.IfNoneMatch?.ToString(),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets a specific <see cref="SynonymMap"/>.
        /// </summary>
        /// <param name="synonymMapName">Required. The name of the <see cref="SynonymMap"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SynonymMap"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<SynonymMap> GetSynonymMap(
            string synonymMapName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            SynonymMapsClient.Get(
                synonymMapName,
                options?.ClientRequestId,
                cancellationToken);

        /// <summary>
        /// Gets a specific <see cref="SynonymMap"/>.
        /// </summary>
        /// <param name="synonymMapName">Required. The name of the <see cref="SynonymMap"/> to get.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SynonymMap"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SynonymMap>> GetSynonymMapAsync(
            string synonymMapName,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default) =>
            await SynonymMapsClient.GetAsync(
                synonymMapName,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Gets a list of all synonym maps.
        /// </summary>
        /// <param name="selectProperties">Optional property names to select. The default is all properties.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SynonymMap"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<IReadOnlyList<SynonymMap>> GetSynonymMaps(
            IEnumerable<string> selectProperties = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            string select = SynonymMap.CanonicalizePropertyNames(selectProperties).CommaJoin() ?? Constants.All;

            Response<ListSynonymMapsResult> result = SynonymMapsClient.List(
                select,
                options?.ClientRequestId,
                cancellationToken);

            return Response.FromValue(result.Value.SynonymMaps, result.GetRawResponse());
        }

        /// <summary>
        /// Gets a list of all synonym maps.
        /// </summary>
        /// <param name="selectProperties">Optional property names to select. The default is all properties.</param>
        /// <param name="options">Optional <see cref="SearchRequestOptions"/> to customize the operation's behavior.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SynonymMap"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<IReadOnlyList<SynonymMap>>> GetSynonymMapsAsync(
            IEnumerable<string> selectProperties = null,
            SearchRequestOptions options = null,
            CancellationToken cancellationToken = default)
        {
            string select = SynonymMap.CanonicalizePropertyNames(selectProperties).CommaJoin() ?? Constants.All;

            Response<ListSynonymMapsResult> result = await SynonymMapsClient.ListAsync(
                select,
                options?.ClientRequestId,
                cancellationToken)
                .ConfigureAwait(false);

            return Response.FromValue(result.Value.SynonymMaps, result.GetRawResponse());
        }
        #endregion
    }
}
