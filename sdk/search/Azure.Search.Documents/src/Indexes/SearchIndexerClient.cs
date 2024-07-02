// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage and query
    /// indexes and documents, as well as manage other resources, on a Search
    /// Service.
    /// </summary>
    public partial class SearchIndexerClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SearchClientOptions.ServiceVersion _version;
        private IndexersRestClient _indexersClient;
        private string _serviceName;

        /// <summary>
        /// The HTTP pipeline for sending and receiving REST requests and responses.
        /// </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

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
        /// Initializes a new instance of the <see cref="SearchIndexerClient"/> class for mocking.
        /// </summary>
        protected SearchIndexerClient() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexerClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="credential">
        /// Required. The API key credential used to authenticate requests against the Search service.
        /// You need to use an admin key to perform any operations on the SearchIndexerClient.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see> for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexerClient(Uri endpoint, AzureKeyCredential credential) :
            this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexerClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="tokenCredential">
        /// Required.The token credential used to authenticate requests against the Search service.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-rbac">Use role-based authorization in Azure Cognitive Search</see> for more information about role-based authorization in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="tokenCredential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexerClient(Uri endpoint, TokenCredential tokenCredential) :
            this(endpoint, tokenCredential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexerClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="credential">
        /// Required. The API key credential used to authenticate requests against the Search service.
        /// You need to use an admin key to perform any operations on the SearchIndexerClient.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see> for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <param name="options">Client configuration options for connecting to Azure Cognitive Search.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexerClient(
            Uri endpoint,
            AzureKeyCredential credential,
            SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new SearchClientOptions();
            Endpoint = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = options.Build(credential);
            _version = options.Version;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexerClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="tokenCredential">
        /// Required. The token credential used to authenticate requests against the Search service.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-rbac">Use role-based authorization in Azure Cognitive Search</see> for more information about role-based authorization in Azure Cognitive Search.
        /// </param>
        /// <param name="options">Client configuration options for connecting to Azure Cognitive Search.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="tokenCredential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexerClient(
            Uri endpoint,
            TokenCredential tokenCredential,
            SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

            options ??= new SearchClientOptions();
            Endpoint = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = options.Build(tokenCredential);
            _version = options.Version;
        }

        /// <summary>
        /// Gets the generated <see cref="IndexersRestClient"/> to make requests.
        /// </summary>
        private IndexersRestClient IndexersClient => LazyInitializer.EnsureInitialized(ref _indexersClient, () => new IndexersRestClient(
            _clientDiagnostics,
            _pipeline,
            Endpoint.AbsoluteUri,
            null,
            _version.ToVersionString())
        );

        /// <summary>
        /// Creates a new indexer.
        /// </summary>
        /// <param name="indexer">Required. The <see cref="SearchIndex"/> to create.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexer"/> created.
        /// This may differ slightly from what was passed into the service.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexer> CreateIndexer(
            SearchIndexer indexer,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.Create(
                    indexer,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexer"/> created.
        /// This may differ slightly from what was passed into the service.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexer>> CreateIndexerAsync(
            SearchIndexer indexer,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.CreateAsync(
                    indexer,
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
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(indexer, nameof(indexer));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateOrUpdateIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.CreateOrUpdate(
                    indexer?.Name,
                    indexer,
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
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(indexer, nameof(indexer));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateOrUpdateIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.CreateOrUpdateAsync(
                    indexer?.Name,
                    indexer,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteIndexer(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(indexerName, nameof(indexerName));

            return DeleteIndexer(
                indexerName,
                null,
                false,
                cancellationToken);
        }

        /// <summary>
        /// Deletes an indexer.
        /// </summary>
        /// <param name="indexerName">The name of the <see cref="SearchIndexer"/> to delete.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteIndexerAsync(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(indexerName, nameof(indexerName));

            return await DeleteIndexerAsync(
                indexerName,
                null,
                false,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes an indexer.
        /// </summary>
        /// <param name="indexer">The <see cref="SearchIndexer"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexer.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteIndexer(
            SearchIndexer indexer,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(indexer, nameof(indexer));

            return DeleteIndexer(
                indexer?.Name,
                indexer?.ETag,
                onlyIfUnchanged,
                cancellationToken);
        }

        /// <summary>
        /// Deletes an indexer.
        /// </summary>
        /// <param name="indexer">The <see cref="SearchIndexer"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexer.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteIndexerAsync(
            SearchIndexer indexer,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(indexer, nameof(indexer));

            return await DeleteIndexerAsync(
                indexer?.Name,
                indexer?.ETag,
                onlyIfUnchanged,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private Response DeleteIndexer(
            string indexerName,
            ETag? etag,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(DeleteIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.Delete(
                    indexerName,
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

        private async Task<Response> DeleteIndexerAsync(
            string indexerName,
            ETag? etag,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(DeleteIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.DeleteAsync(
                    indexerName,
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
        /// Gets a specific <see cref="SearchIndexer"/>.
        /// </summary>
        /// <param name="indexerName">Required. The name of the <see cref="SearchIndexer"/> to get.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexer> GetIndexer(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.Get(
                    indexerName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexer>> GetIndexerAsync(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.GetAsync(
                    indexerName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<SearchIndexer>> GetIndexers(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetIndexers)}");
            scope.Start();
            try
            {
                Response<ListIndexersResult> result = IndexersClient.List(
                    Constants.All,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<SearchIndexer>>> GetIndexersAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetIndexers)}");
            scope.Start();
            try
            {
                Response<ListIndexersResult> result = await IndexersClient.ListAsync(
                    Constants.All,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<string>> GetIndexerNames(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetIndexerNames)}");
            scope.Start();
            try
            {
                Response<ListIndexersResult> result = IndexersClient.List(
                    Constants.NameKey,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetIndexerNamesAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetIndexerNames)}");
            scope.Start();
            try
            {
                Response<ListIndexersResult> result = await IndexersClient.ListAsync(
                    Constants.NameKey,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerStatus"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerStatus> GetIndexerStatus(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetIndexerStatus)}");
            scope.Start();
            try
            {
                return IndexersClient.GetStatus(
                    indexerName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerStatus"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerStatus>> GetIndexerStatusAsync(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetIndexerStatus)}");
            scope.Start();
            try
            {
                return await IndexersClient.GetStatusAsync(
                    indexerName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response ResetIndexer(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(ResetIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.Reset(
                    indexerName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> ResetIndexerAsync(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(ResetIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.ResetAsync(
                    indexerName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response RunIndexer(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(RunIndexer)}");
            scope.Start();
            try
            {
                return IndexersClient.Run(
                    indexerName,
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> RunIndexerAsync(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(RunIndexer)}");
            scope.Start();
            try
            {
                return await IndexersClient.RunAsync(
                    indexerName,
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
