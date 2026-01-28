// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes.Models;

// TODO: Fix this in generator
// namespace Azure.Search.Documents.Indexes
namespace Azure.Azure.Search.Documents.Documents.Indexes
{
    /// <summary>
    /// Customizations for the generated <see cref="SearchIndexerClient"/> - Indexer operations.
    /// </summary>
    public partial class SearchIndexerClient
    {
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<SearchIndexer> CreateOrUpdateIndexer(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            SearchIndexer indexer,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken) => CreateOrUpdateIndexer(
                indexer,
                onlyIfUnchanged,
                ignoreCacheResetRequirements: null,
                disableCacheReprocessingChangeDetection: null,
                cancellationToken);

        /// <summary>
        /// Creates a new indexer or updates an existing indexer.
        /// </summary>
        /// <param name="indexer">Required. The <see cref="SearchIndexer"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexer.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="disableCacheReprocessingChangeDetection">Disables cache reprocessing change detection.</param>
        /// <param name="ignoreCacheResetRequirements">Ignores cache reset requirements.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexer"/> created.
        /// This may differ slightly from what was passed into the service.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<SearchIndexer> CreateOrUpdateIndexer(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            SearchIndexer indexer,
            bool onlyIfUnchanged,
            bool disableCacheReprocessingChangeDetection,
            bool ignoreCacheResetRequirements,
            CancellationToken cancellationToken) => CreateOrUpdateIndexer(
                indexer,
                onlyIfUnchanged,
                ignoreCacheResetRequirements,
                disableCacheReprocessingChangeDetection,
                cancellationToken);

        /// <summary>
        /// Creates a new indexer or updates an existing indexer.
        /// </summary>
        /// <param name="indexer">Required. The <see cref="SearchIndexer"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexer.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="ignoreCacheResetRequirements">Ignores cache reset requirements.</param>
        /// <param name="disableCacheReprocessingChangeDetection">Disables cache reprocessing change detection.</param>
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
            bool? ignoreCacheResetRequirements = null,
            bool? disableCacheReprocessingChangeDetection = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(indexer, nameof(indexer));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = indexer?.ETag } : null;
            return CreateOrUpdateIndexer(indexer?.Name, indexer, matchConditions, ignoreCacheResetRequirements, disableCacheReprocessingChangeDetection, cancellationToken);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<SearchIndexer>> CreateOrUpdateIndexerAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            SearchIndexer indexer,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken) => await CreateOrUpdateIndexerAsync(
                indexer,
                onlyIfUnchanged,
                ignoreCacheResetRequirements: null,
                disableCacheReprocessingChangeDetection: null,
                cancellationToken).
                ConfigureAwait(false);

        /// <summary>
        /// Creates a new indexer or updates an existing indexer.
        /// </summary>
        /// <param name="indexer">Required. The <see cref="SearchIndexer"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexer.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="disableCacheReprocessingChangeDetection">Disables cache reprocessing change detection.</param>
        /// <param name="ignoreCacheResetRequirements">Ignores cache reset requirements.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexer"/> created.
        /// This may differ slightly from what was passed into the service.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="indexer"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<SearchIndexer>> CreateOrUpdateIndexerAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            SearchIndexer indexer,
            bool onlyIfUnchanged,
            bool disableCacheReprocessingChangeDetection,
            bool ignoreCacheResetRequirements,
            CancellationToken cancellationToken) => await CreateOrUpdateIndexerAsync(
                indexer,
                onlyIfUnchanged,
                ignoreCacheResetRequirements,
                disableCacheReprocessingChangeDetection,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a new indexer or updates an existing indexer.
        /// </summary>
        /// <param name="indexer">Required. The <see cref="SearchIndexer"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexer.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="ignoreCacheResetRequirements">Ignores cache reset requirements.</param>
        /// <param name="disableCacheReprocessingChangeDetection">Disables cache reprocessing change detection.</param>
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
            bool? ignoreCacheResetRequirements = null,
            bool? disableCacheReprocessingChangeDetection = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(indexer, nameof(indexer));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = indexer?.ETag } : null;
            return await CreateOrUpdateIndexerAsync(indexer?.Name, indexer, matchConditions, ignoreCacheResetRequirements, disableCacheReprocessingChangeDetection, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<IReadOnlyList<SearchIndexer>> GetIndexers(
            CancellationToken cancellationToken = default)
        {
            Response<ListIndexersResult> result = GetIndexers(new[] { Constants.All }, cancellationToken);
            return Response.FromValue((IReadOnlyList<SearchIndexer>)result.Value.Indexers, result.GetRawResponse());
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
            Response<ListIndexersResult> result = await GetIndexersAsync(new[] { Constants.All }, cancellationToken).ConfigureAwait(false);
            return Response.FromValue((IReadOnlyList<SearchIndexer>)result.Value.Indexers, result.GetRawResponse());
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
