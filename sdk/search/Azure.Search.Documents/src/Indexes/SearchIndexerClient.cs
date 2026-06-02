// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    public partial class SearchIndexerClient
    {
        private string _serviceName;

        /// <summary>
        /// Gets the URI endpoint of the Search service.This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// </summary>
        public virtual Uri Endpoint { get => _endpoint; }

        /// <summary>
        /// Gets the name of the Search service.
        /// </summary>
        public virtual string ServiceName =>
            _serviceName ??= Endpoint.GetSearchServiceName();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexerClient"/> class for mocking.
        /// </summary>
        protected SearchIndexerClient()
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
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexerClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, null)
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
        public SearchIndexerClient(Uri endpoint, TokenCredential tokenCredential) : this(endpoint, tokenCredential, null)
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
        public SearchIndexerClient(Uri endpoint, AzureKeyCredential credential, SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new SearchClientOptions();

            _endpoint = endpoint;
            Pipeline = options.Build(credential);
            _apiVersion = options.Version.ToVersionString();
            ClientDiagnostics = new ClientDiagnostics(options);
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
        public SearchIndexerClient(Uri endpoint, TokenCredential tokenCredential, SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

            options ??= new SearchClientOptions();

            _endpoint = endpoint;
            Pipeline = options.Build(tokenCredential);
            _apiVersion = options.Version.ToVersionString();
            ClientDiagnostics = new ClientDiagnostics(options);
        }

        /// <summary> Initializes a new instance of SearchIndexerClient. </summary>
        /// <param name="authenticationPolicy"> The authentication policy to use for pipeline creation. </param>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        internal SearchIndexerClient(HttpPipelinePolicy authenticationPolicy, Uri endpoint, SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            options ??= new SearchClientOptions();

            _endpoint = endpoint;
            Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { authenticationPolicy });
            _apiVersion = options.Version.ToVersionString();
            ClientDiagnostics = new ClientDiagnostics(options, true);
        }

        #region Indexer operations - Convenience overloads

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
        [ForwardsClientCalls]
        public virtual Response<SearchIndexer> CreateOrUpdateIndexer(
            SearchIndexer indexer,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(indexer, nameof(indexer));

            return CreateOrUpdateIndexer(
                indexer?.Name,
                indexer,
                onlyIfUnchanged ? new MatchConditions { IfMatch = indexer?.ETag } : null,
                skipIndexerResetRequirementForCache: null,
                disableCacheReprocessingChangeDetection: null,
                cancellationToken);
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
        [ForwardsClientCalls]
        public virtual async Task<Response<SearchIndexer>> CreateOrUpdateIndexerAsync(
            SearchIndexer indexer,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(indexer, nameof(indexer));

            return await CreateOrUpdateIndexerAsync(
                indexer?.Name,
                indexer,
                onlyIfUnchanged ? new MatchConditions { IfMatch = indexer?.ETag } : null,
                skipIndexerResetRequirementForCache: null,
                disableCacheReprocessingChangeDetection: null,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes an indexer.
        /// </summary>
        /// <param name="indexerName">The name of the <see cref="SearchIndexer"/> to delete.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response DeleteIndexer(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(indexerName, nameof(indexerName));

            return DeleteIndexer(indexerName, matchConditions: null, cancellationToken);
        }

        /// <summary>
        /// Deletes an indexer.
        /// </summary>
        /// <param name="indexerName">The name of the <see cref="SearchIndexer"/> to delete.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexerName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteIndexerAsync(
            string indexerName,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(indexerName, nameof(indexerName));

            return await DeleteIndexerAsync(indexerName, matchConditions: null, cancellationToken).ConfigureAwait(false);
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
        [ForwardsClientCalls]
        public virtual Response DeleteIndexer(
            SearchIndexer indexer,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(indexer, nameof(indexer));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = indexer?.ETag } : null;
            return DeleteIndexer(indexer?.Name, matchConditions, cancellationToken);
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
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteIndexerAsync(
            SearchIndexer indexer,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(indexer, nameof(indexer));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = indexer?.ETag } : null;
            return await DeleteIndexerAsync(indexer?.Name, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a list of all indexers.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<IReadOnlyList<SearchIndexer>> GetIndexers(
            CancellationToken cancellationToken = default)
        {
            Response<ListIndexersResult> result = GetIndexers(new[] { Constants.All }, cancellationToken);
            return Response.FromValue(result.Value.Indexers, result.GetRawResponse());
        }

        /// <summary>
        /// Gets a list of all indexers.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<IReadOnlyList<SearchIndexer>>> GetIndexersAsync(
            CancellationToken cancellationToken = default)
        {
            Response<ListIndexersResult> result = await GetIndexersAsync(new[] { Constants.All }, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(result.Value.Indexers, result.GetRawResponse());
        }

        /// <summary>
        /// Gets a list of all indexer names.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual Response<IReadOnlyList<string>> GetIndexerNames(
            CancellationToken cancellationToken = default)
        {
            Response<ListIndexersResult> result = GetIndexers(new[] { Constants.NameKey }, cancellationToken);
            IReadOnlyList<string> names = result.Value.Indexers.Select(value => value.Name).ToArray();
            return Response.FromValue(names, result.GetRawResponse());
        }

        /// <summary>
        /// Gets a list of all indexer names.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexer"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<IReadOnlyList<string>>> GetIndexerNamesAsync(
            CancellationToken cancellationToken = default)
        {
            Response<ListIndexersResult> result = await GetIndexersAsync(new[] { Constants.NameKey }, cancellationToken).ConfigureAwait(false);
            IReadOnlyList<string> names = result.Value.Indexers.Select(value => value.Name).ToArray();
            return Response.FromValue(names, result.GetRawResponse());
        }

        #endregion
    }
}
