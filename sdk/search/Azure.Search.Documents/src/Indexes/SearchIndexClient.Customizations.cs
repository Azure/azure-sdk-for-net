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
    /// Customizations for the generated <see cref="SearchIndexClient"/>.
    /// Azure Cognitive Search client that can be used to manage indexes on a Search service.
    /// </summary>
    public partial class SearchIndexClient
    {
        private SearchClientOptions.ServiceVersion _version;
        private ObjectSerializer _serializer;
        private string _serviceName;

        /// <summary>
        /// Gets the URI endpoint of the Search service. This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// </summary>
        public virtual Uri Endpoint => _endpoint;

        /// <summary>
        /// Gets the name of the Search service.
        /// </summary>
        public virtual string ServiceName =>
            _serviceName ??= _endpoint.GetSearchServiceName();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexClient"/> class for mocking.
        /// </summary>
        protected SearchIndexClient()
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
        /// <param name="tokenCredential">
        /// Required. The token credential used to authenticate requests against the Search service.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-rbac">Use role-based authorization in Azure Cognitive Search</see> for more information about role-based authorization in Azure Cognitive Search.
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="tokenCredential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexClient(Uri endpoint, TokenCredential tokenCredential) :
            this(endpoint, tokenCredential, null)
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
            _endpoint = endpoint;
            _keyCredential = credential;
            _serializer = options.Serializer;
            ClientDiagnostics = new ClientDiagnostics(options);
            Pipeline = options.Build(credential);
            _version = options.Version;
            _apiVersion = options.Version.ToVersionString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexClient"/> class.
        /// </summary>
        /// <param name="endpoint">Required. The URI endpoint of the Search service. This is likely to be similar to "https://{search_service}.search.windows.net". The URI must use HTTPS.</param>
        /// <param name="tokenCredential">
        /// Required. The token credential used to authenticate requests against the Search service.
        /// See <see href="https://docs.microsoft.com/azure/search/search-security-rbac">Use role-based authorization in Azure Cognitive Search</see> for more information about role-based authorization in Azure Cognitive Search.
        /// </param>
        /// <param name="options">Client configuration options for connecting to Azure Cognitive Search.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="endpoint"/> or <paramref name="tokenCredential"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="endpoint"/> is not using HTTPS.</exception>
        public SearchIndexClient(
            Uri endpoint,
            TokenCredential tokenCredential,
            SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            endpoint.AssertHttpsScheme(nameof(endpoint));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

            options ??= new SearchClientOptions();
            _endpoint = endpoint;
            _tokenCredential = tokenCredential;
            _serializer = options.Serializer;
            ClientDiagnostics = new ClientDiagnostics(options);
            Pipeline = options.Build(tokenCredential);
            _version = options.Version;
            _apiVersion = options.Version.ToVersionString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchIndexClient"/> class from a
        /// <see cref="SearchClient"/>.
        /// </summary>
        /// <param name="endpoint">
        /// Required. The URI endpoint of the Search Service.
        /// </param>
        /// <param name="serializer">
        /// An optional customized serializer to use for search documents.
        /// </param>
        /// <param name="pipeline">
        /// The authenticated <see cref="HttpPipeline"/> used for sending
        /// requests to the Search Service.
        /// </param>
        /// <param name="diagnostics">
        /// The <see cref="ClientDiagnostics"/> used to provide tracing support
        /// for the client library.
        /// </param>
        /// <param name="version">
        /// The REST API version of the Search Service to use when making
        /// requests.
        /// </param>
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

            _endpoint = endpoint;
            _serializer = serializer;
            ClientDiagnostics = diagnostics;
            Pipeline = pipeline;
            _version = version;
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
                _endpoint,
                indexName,
                _serializer,
                Pipeline,
                ClientDiagnostics,
                _version);
        }

        #region Index operations - Convenience overloads

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
            Argument.AssertNotNull(index, nameof(index));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = index?.ETag } : null;
            return CreateOrUpdateIndex(index?.Name, index, matchConditions, allowIndexDowntime, cancellationToken);
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
            Argument.AssertNotNull(index, nameof(index));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = index?.ETag } : null;
            return await CreateOrUpdateIndexAsync(index?.Name, index, matchConditions, allowIndexDowntime, cancellationToken).ConfigureAwait(false);
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
            CancellationToken cancellationToken = default) =>
            DeleteIndex(indexName, matchConditions: null, cancellationToken);

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
            CancellationToken cancellationToken = default) =>
            await DeleteIndexAsync(indexName, matchConditions: null, cancellationToken).ConfigureAwait(false);

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
            Argument.AssertNotNull(index, nameof(index));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = index?.ETag } : null;
            return DeleteIndex(index?.Name, matchConditions, cancellationToken);
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
            Argument.AssertNotNull(index, nameof(index));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = index?.ETag } : null;
            return await DeleteIndexAsync(index?.Name, matchConditions, cancellationToken).ConfigureAwait(false);
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
                using DiagnosticScope scope = ClientDiagnostics.CreateScope("SearchIndexClient.GetIndexNames");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    // Get only names by specifying the select parameter
                    Pageable<SearchIndex> result = GetIndexes(new[] { Constants.NameKey }, cancellationToken);
                    IReadOnlyList<string> names = result.Select(value => value.Name).ToArray();
                    return Page<string>.FromValues(names, null, null);
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
        /// <returns>The <see cref="AsyncPageable{T}"/> from the server containing a list of <see cref="SearchIndex"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual AsyncPageable<string> GetIndexNamesAsync(
            CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async (continuationToken) =>
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope("SearchIndexClient.GetIndexNames");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    // Get only names by specifying the select parameter
                    AsyncPageable<SearchIndex> result = GetIndexesAsync(new[] { Constants.NameKey }, cancellationToken);
                    List<string> names = new List<string>();
                    await foreach (SearchIndex index in result.ConfigureAwait(false))
                    {
                        names.Add(index.Name);
                    }
                    return Page<string>.FromValues(names, null, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        #endregion

        #region SynonymMaps operations - Convenience overloads

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
            Argument.AssertNotNull(synonymMap, nameof(synonymMap));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = synonymMap?.ETag } : null;
            return CreateOrUpdateSynonymMap(synonymMap?.Name, synonymMap, matchConditions, cancellationToken);
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
            Argument.AssertNotNull(synonymMap, nameof(synonymMap));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = synonymMap?.ETag } : null;
            return await CreateOrUpdateSynonymMapAsync(synonymMap?.Name, synonymMap, matchConditions, cancellationToken).ConfigureAwait(false);
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
            CancellationToken cancellationToken = default) =>
            DeleteSynonymMap(synonymMapName, matchConditions: null, cancellationToken);

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
            CancellationToken cancellationToken = default) =>
            await DeleteSynonymMapAsync(synonymMapName, matchConditions: null, cancellationToken).ConfigureAwait(false);

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
            Argument.AssertNotNull(synonymMap, nameof(synonymMap));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = synonymMap?.ETag } : null;
            return DeleteSynonymMap(synonymMap?.Name, matchConditions, cancellationToken);
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
            Argument.AssertNotNull(synonymMap, nameof(synonymMap));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = synonymMap?.ETag } : null;
            return await DeleteSynonymMapAsync(synonymMap?.Name, matchConditions, cancellationToken).ConfigureAwait(false);
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SearchIndexClient.GetSynonymMaps");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = GetSynonymMaps(select: null, cancellationToken);
                return Response.FromValue((IReadOnlyList<SynonymMap>)result.Value.SynonymMaps, result.GetRawResponse());
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SearchIndexClient.GetSynonymMaps");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = await GetSynonymMapsAsync(select: null, cancellationToken).ConfigureAwait(false);
                return Response.FromValue((IReadOnlyList<SynonymMap>)result.Value.SynonymMaps, result.GetRawResponse());
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SearchIndexClient.GetSynonymMapNames");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = GetSynonymMaps(new[] { Constants.NameKey }, cancellationToken);
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SearchIndexClient.GetSynonymMapNames");
            scope.Start();
            try
            {
                Response<ListSynonymMapsResult> result = await GetSynonymMapsAsync(new[] { Constants.NameKey }, cancellationToken).ConfigureAwait(false);
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

        #region AnalyzeText - Convenience overload

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
            Argument.AssertNotNullOrEmpty(indexName, nameof(indexName));
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SearchIndexClient.AnalyzeText");
            scope.Start();
            try
            {
                Response response = AnalyzeText(indexName, options, cancellationToken.ToRequestContext());
                AnalyzeResult result = (AnalyzeResult) response;
                return Response.FromValue((IReadOnlyList<AnalyzedTokenInfo>)result.Tokens, response);
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
            Argument.AssertNotNullOrEmpty(indexName, nameof(indexName));
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("SearchIndexClient.AnalyzeText");
            scope.Start();
            try
            {
                Response response = await AnalyzeTextAsync(indexName, options, cancellationToken.ToRequestContext()).ConfigureAwait(false);
                AnalyzeResult result = (AnalyzeResult) response;
                return Response.FromValue((IReadOnlyList<AnalyzedTokenInfo>)result.Tokens, response);
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
