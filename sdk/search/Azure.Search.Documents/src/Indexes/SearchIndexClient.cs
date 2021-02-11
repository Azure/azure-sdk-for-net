// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage indexes on a Search service.
    /// </summary>
    public class SearchIndexClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SearchClientOptions.ServiceVersion _version;
        private readonly ObjectSerializer _serializer;

        private SearchServiceRestClient _serviceClient;
        private IndexesRestClient _indexesClient;
        private SynonymMapsRestClient _synonymMapsClient;
        private string _serviceName;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexClient"/> class for mocking.
        /// </summary>
        protected SearchIndexClient() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="credential">
        /// Required. The API key credential used to authenticate requests against the Search service.
        /// You need to use an admin key to perform any operations on the SearchIndexClient.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see> for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexClient(Uri endpoint, AzureKeyCredential credential) :
            this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="credential">
        /// Required. The API key credential used to authenticate requests against the Search service.
        /// You need to use an admin key to perform any operations on the SearchIndexClient.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see> for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <param name="options">Client configuration options for connecting to Azure Cognitive Search.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexClient(
            Uri endpoint,
            AzureKeyCredential credential,
            SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new SearchClientOptions();
            Endpoint = endpoint;
            _serializer = options.Serializer;
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = options.Build(credential);
            _version = options.Version;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="serializer">An optional customized serializer to use for search documents.</param>
        /// <param name="pipeline">The authenticated <see cref="HttpPipeline"/> used for sending requests to the Search Service.</param>
        /// <param name="diagnostics">The <see cref="Azure.Core.Pipeline.ClientDiagnostics"/> used to provide tracing support for the client library.</param>
        /// <param name="version">The REST API version of the Search Service to use when making requests.</param>
        internal SearchIndexClient(
            Uri endpoint,
            ObjectSerializer serializer,
            HttpPipeline pipeline,
            ClientDiagnostics diagnostics,
            SearchClientOptions.ServiceVersion version)
        {
            Debug.Assert(endpoint != null);
            Debug.Assert(string.Equals(endpoint.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase));
            Debug.Assert(pipeline != null);
            Debug.Assert(diagnostics != null);
            Debug.Assert(
                SearchClientOptions.ServiceVersion.V2020_06_30 <= version &&
                version <= SearchClientOptions.LatestVersion);

            Endpoint = endpoint;
            _serializer = serializer;
            _clientDiagnostics = diagnostics;
            _pipeline = pipeline;
            _version = version;
        }

        /// <summary>
        /// Gets the URI endpoint of the Search service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// </summary>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// Gets the name of the Search service.
        /// </summary>
        public virtual string ServiceName =>
            _serviceName ??= Endpoint.GetSearchServiceName();

        /// <summary>
        /// Gets the generated <see cref="SearchServiceRestClient"/> to make requests.
        /// </summary>
        private SearchServiceRestClient ServiceClient => LazyInitializer.EnsureInitialized(ref _serviceClient, () => new SearchServiceRestClient(
            _clientDiagnostics,
            _pipeline,
            Endpoint.ToString(),
            null,
            _version.ToVersionString())
        );

        /// <summary>
        /// Gets the generated <see cref="IndexesRestClient"/> to make requests.
        /// </summary>
        private IndexesRestClient IndexesClient => LazyInitializer.EnsureInitialized(ref _indexesClient, () => new IndexesRestClient(
            _clientDiagnostics,
            _pipeline,
            Endpoint.ToString(),
            null,
            _version.ToVersionString())
        );

        /// <summary>
        /// Gets the generated <see cref="SynonymMapsRestClient"/> to make requests.
        /// </summary>
        private SynonymMapsRestClient SynonymMapsClient => LazyInitializer.EnsureInitialized(ref _synonymMapsClient, () => new SynonymMapsRestClient(
            _clientDiagnostics,
            _pipeline,
            Endpoint.ToString(),
            null,
            _version.ToVersionString())
        );

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
                _serializer,
                _pipeline,
                _clientDiagnostics,
                _version);
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing <see cref="SearchServiceStatistics"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchServiceStatistics> GetServiceStatistics(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetServiceStatistics)}");
            scope.Start();
            try
            {
                return ServiceClient.GetServiceStatistics(
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing <see cref="SearchServiceStatistics"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchServiceStatistics>> GetServiceStatisticsAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetServiceStatistics)}");
            scope.Start();
            try
            {
                return await ServiceClient.GetServiceStatisticsAsync(
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

        #region Index operations
        /// <summary>
        /// Shows how an analyzer breaks text into tokens.
        /// </summary>
        /// <param name="indexName">The name of the index used to test an analyzer.</param>
        /// <param name="options">The <see cref="AnalyzeTextOptions"/> containing the text and analyzer or analyzer components to test.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing a list of <see cref="AnalyzedTokenInfo"/> for analyzed text.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<AnalyzedTokenInfo>> AnalyzeText(
            string indexName,
            AnalyzeTextOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(AnalyzeText)}");
            scope.Start();
            try
            {
                Response<AnalyzeResult> result = IndexesClient.Analyze(
                    indexName,
                    options,
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
        /// <param name="options">The <see cref="AnalyzeTextOptions"/> containing the text and analyzer or analyzer components to test.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing a list of <see cref="AnalyzedTokenInfo"/> for analyzed text.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> or <paramref name="options"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<AnalyzedTokenInfo>>> AnalyzeTextAsync(
            string indexName,
            AnalyzeTextOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(AnalyzeText)}");
            scope.Start();
            try
            {
                Response<AnalyzeResult> result = await IndexesClient.AnalyzeAsync(
                    indexName,
                    options,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndex"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back fields set to their default values depending on the field type and other properties.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndex> CreateIndex(
            SearchIndex index,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateIndex)}");
            scope.Start();
            try
            {
                return IndexesClient.Create(
                    index,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndex"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back fields set to their default values depending on the field type and other properties.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndex>> CreateIndexAsync(
            SearchIndex index,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateIndex)}");
            scope.Start();
            try
            {
                return await IndexesClient.CreateAsync(
                    index,
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
            CancellationToken cancellationToken = default)
        {
            // Generated client validates indexName parameter first, which is not a parameter of this method.
            Argument.AssertNotNull(index, nameof(index));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateIndex)}");
            scope.Start();
            try
            {
                return IndexesClient.CreateOrUpdate(
                    index?.Name,
                    index,
                    allowIndexDowntime,
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
            CancellationToken cancellationToken = default)
        {
            // Generated client validates indexName parameter first, which is not a parameter of this method.
            Argument.AssertNotNull(index, nameof(index));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateIndex)}");
            scope.Start();
            try
            {
                return await IndexesClient.CreateOrUpdateAsync(
                    index?.Name,
                    index,
                    allowIndexDowntime,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteIndex(
            string indexName,
            CancellationToken cancellationToken = default) => DeleteIndex(
                indexName,
                null,
                false,
                cancellationToken);

        /// <summary>
        /// Deletes a search index and all the documents it contains.
        /// </summary>
        /// <param name="indexName">Required. The name of the <see cref="SearchIndex"/> to delete.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteIndexAsync(
            string indexName,
            CancellationToken cancellationToken = default) => await DeleteIndexAsync(
                indexName,
                null,
                false,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes a search index and all the documents it contains.
        /// </summary>
        /// <param name="index">Required. The <see cref="SearchIndex"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndex.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteIndex(
            SearchIndex index,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // Generated client validates indexName parameter first, which is not a parameter of this method.
            Argument.AssertNotNull(index, nameof(index));

            return DeleteIndex(
                index?.Name,
                index?.ETag,
                onlyIfUnchanged,
                cancellationToken);
        }

        /// <summary>
        /// Deletes a search index and all the documents it contains.
        /// </summary>
        /// <param name="index">Required. The <see cref="SearchIndex"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndex.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="index"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteIndexAsync(
            SearchIndex index,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // Generated client validates indexName parameter first, which is not a parameter of this method.
            Argument.AssertNotNull(index, nameof(index));

            return await DeleteIndexAsync(
                index?.Name,
                index?.ETag,
                onlyIfUnchanged,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private Response DeleteIndex(
            string indexName,
            ETag? etag,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteIndex)}");
            scope.Start();
            try
            {
                return IndexesClient.Delete(
                    indexName,
                    onlyIfUnchanged ? etag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private async Task<Response> DeleteIndexAsync(
            string indexName,
            ETag? etag,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteIndex)}");
            scope.Start();
            try
            {
                return await IndexesClient.DeleteAsync(
                    indexName,
                    onlyIfUnchanged ? etag?.ToString() : null,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndex"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndex> GetIndex(
            string indexName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetIndex)}");
            scope.Start();
            try
            {
                return IndexesClient.Get(
                    indexName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndex"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndex>> GetIndexAsync(
            string indexName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetIndex)}");
            scope.Start();
            try
            {
                return await IndexesClient.GetAsync(
                    indexName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Pageable{T}"/> from the server containing a list of <see cref="SearchIndex"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Pageable<SearchIndex> GetIndexes(
            CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable((continuationToken) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetIndexes)}");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListIndexesResult> result = IndexesClient.List(
                        Constants.All,
                        cancellationToken);

                    return Page<SearchIndex>.FromValues(result.Value.Indexes, null, result.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Gets a list of all indexes.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndex"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual AsyncPageable<SearchIndex> GetIndexesAsync(
            CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async (continuationToken) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetIndexes)}");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListIndexesResult> result = await IndexesClient.ListAsync(
                            Constants.All,
                            cancellationToken)
                        .ConfigureAwait(false);

                    return Page<SearchIndex>.FromValues(result.Value.Indexes, null, result.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Gets a list of all index names.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Pageable{T}"/> from the server containing a list of <see cref="SearchIndex"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Pageable<string> GetIndexNames(
            CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable((continuationToken) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetIndexNames)}");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListIndexesResult> result = IndexesClient.List(
                        Constants.NameKey,
                        cancellationToken);

                    IReadOnlyList<string> names = result.Value.Indexes.Select(value => value.Name).ToArray();
                    return Page<string>.FromValues(names, null, result.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Gets a list of all index names.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndex"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual AsyncPageable<string> GetIndexNamesAsync(
            CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async (continuationToken) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetIndexNames)}");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListIndexesResult> result = await IndexesClient.ListAsync(
                            Constants.NameKey,
                            cancellationToken)
                        .ConfigureAwait(false);

                    IReadOnlyList<string> names = result.Value.Indexes.Select(value => value.Name).ToArray();
                    return Page<string>.FromValues(names, null, result.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Gets <see cref="SearchIndexStatistics"/> for the given index, including a document count and storage usage.
        /// </summary>
        /// <param name="indexName">Required. The name of the index.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing <see cref="SearchIndexStatistics"/> names.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexStatistics> GetIndexStatistics(
            string indexName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetIndexStatistics)}");
            scope.Start();
            try
            {
                return IndexesClient.GetStatistics(
                    indexName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing <see cref="SearchIndexStatistics"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexStatistics>> GetIndexStatisticsAsync(
            string indexName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetIndexStatistics)}");
            scope.Start();
            try
            {
                return await IndexesClient.GetStatisticsAsync(
                    indexName,
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

        #region SynonymMaps operations
        /// <summary>
        /// Creates a new synonym map.
        /// </summary>
        /// <param name="synonymMap">Required. The <see cref="SynonymMap"/> to create.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SynonymMap"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SynonymMap> CreateSynonymMap(
            SynonymMap synonymMap,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateSynonymMap)}");
            scope.Start();
            try
            {
                return SynonymMapsClient.Create(
                    synonymMap,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SynonymMap"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SynonymMap>> CreateSynonymMapAsync(
            SynonymMap synonymMap,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateSynonymMap)}");
            scope.Start();
            try
            {
                return await SynonymMapsClient.CreateAsync(
                    synonymMap,
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
            CancellationToken cancellationToken = default)
        {
            // Generated client validates indexName parameter first, which is not a parameter of this method.
            Argument.AssertNotNull(synonymMap, nameof(synonymMap));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateSynonymMap)}");
            scope.Start();
            try
            {
                return SynonymMapsClient.CreateOrUpdate(
                    synonymMap?.Name,
                    synonymMap,
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
            CancellationToken cancellationToken = default)
        {
            // Generated client validates indexName parameter first, which is not a parameter of this method.
            Argument.AssertNotNull(synonymMap, nameof(synonymMap));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateSynonymMap)}");
            scope.Start();
            try
            {
                return await SynonymMapsClient.CreateOrUpdateAsync(
                    synonymMap?.Name,
                    synonymMap,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> or <see cref="SynonymMap.Name"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteSynonymMap(
            string synonymMapName,
            CancellationToken cancellationToken = default) => DeleteSynonymMap(
                synonymMapName,
                null,
                false,
                cancellationToken);

        /// <summary>
        /// Deletes a synonym map.
        /// </summary>
        /// <param name="synonymMapName">The name of a <see cref="SynonymMap"/> to delete.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> or <see cref="SynonymMap.Name"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteSynonymMapAsync(
            string synonymMapName,
            CancellationToken cancellationToken = default) => await DeleteSynonymMapAsync(
                synonymMapName,
                null,
                false,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Deletes a synonym map.
        /// </summary>
        /// <param name="synonymMap">The <see cref="SynonymMap"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SynonymMap.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> or <see cref="SynonymMap.Name"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteSynonymMap(
            SynonymMap synonymMap,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // Generated client validates indexName parameter first, which is not a parameter of this method.
            Argument.AssertNotNull(synonymMap, nameof(synonymMap));

            return DeleteSynonymMap(
                synonymMap?.Name,
                synonymMap?.ETag,
                onlyIfUnchanged,
                cancellationToken);
        }

        /// <summary>
        /// Deletes a synonym map.
        /// </summary>
        /// <param name="synonymMap">The <see cref="SynonymMap"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SynonymMap.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMap"/> or <see cref="SynonymMap.Name"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteSynonymMapAsync(
            SynonymMap synonymMap,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // Generated client validates indexName parameter first, which is not a parameter of this method.
            Argument.AssertNotNull(synonymMap, nameof(synonymMap));

            return await DeleteSynonymMapAsync(
                synonymMap?.Name,
                synonymMap?.ETag,
                onlyIfUnchanged,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private Response DeleteSynonymMap(
            string synonymMapName,
            ETag? etag,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteSynonymMap)}");
            scope.Start();
            try
            {
                return SynonymMapsClient.Delete(
                    synonymMapName,
                    onlyIfUnchanged ? etag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private async Task<Response> DeleteSynonymMapAsync(
            string synonymMapName,
            ETag? etag,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteSynonymMap)}");
            scope.Start();
            try
            {
                return await SynonymMapsClient.DeleteAsync(
                    synonymMapName,
                    onlyIfUnchanged ? etag?.ToString() : null,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SynonymMap"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SynonymMap> GetSynonymMap(
            string synonymMapName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetSynonymMap)}");
            scope.Start();
            try
            {
                return SynonymMapsClient.Get(
                    synonymMapName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SynonymMap"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="synonymMapName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SynonymMap>> GetSynonymMapAsync(
            string synonymMapName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetSynonymMap)}");
            scope.Start();
            try
            {
                return await SynonymMapsClient.GetAsync(
                    synonymMapName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SynonymMap"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<SynonymMap>> GetSynonymMaps(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetSynonymMaps)}");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = SynonymMapsClient.List(
                    Constants.All,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SynonymMap"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<SynonymMap>>> GetSynonymMapsAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetSynonymMaps)}");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = await SynonymMapsClient.ListAsync(
                    Constants.All,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SynonymMap"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<string>> GetSynonymMapNames(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetSynonymMapNames)}");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = SynonymMapsClient.List(
                    Constants.NameKey,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SynonymMap"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetSynonymMapNamesAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetSynonymMapNames)}");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = await SynonymMapsClient.ListAsync(
                    Constants.NameKey,
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
