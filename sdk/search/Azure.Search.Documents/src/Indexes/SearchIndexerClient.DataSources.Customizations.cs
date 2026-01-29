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
    /// Customizations for the generated <see cref="SearchIndexerClient"/> - DataSource operations.
    /// </summary>
    public partial class SearchIndexerClient
    {
        #region DataSource operations - Convenience overloads

        /// <summary>
        /// Creates a new data source or updates an existing data source connection.
        /// </summary>
        /// <param name="dataSourceConnection">Required. The <see cref="SearchIndexerDataSourceConnection"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerDataSourceConnection.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerDataSourceConnection"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<SearchIndexerDataSourceConnection> CreateOrUpdateDataSourceConnection(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            SearchIndexerDataSourceConnection dataSourceConnection,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken) => CreateOrUpdateDataSourceConnection(
                dataSourceConnection,
                onlyIfUnchanged,
                ignoreCacheResetRequirements: null,
                cancellationToken);

        /// <summary>
        /// Creates a new data source or updates an existing data source connection.
        /// </summary>
        /// <param name="dataSourceConnection">Required. The <see cref="SearchIndexerDataSourceConnection"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerDataSourceConnection.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="ignoreCacheResetRequirements"><c>True</c> if the cache reset requirements should be ignored.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerDataSourceConnection"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerDataSourceConnection> CreateOrUpdateDataSourceConnection(
            SearchIndexerDataSourceConnection dataSourceConnection,
            bool onlyIfUnchanged = false,
            bool? ignoreCacheResetRequirements = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataSourceConnection, nameof(dataSourceConnection));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = dataSourceConnection?.ETag } : null;
            return CreateOrUpdateDataSourceConnection(dataSourceConnection?.Name, dataSourceConnection, matchConditions, ignoreCacheResetRequirements, cancellationToken);
        }

        /// <summary>
        /// Creates a new data source or updates an existing data source connection.
        /// </summary>
        /// <param name="dataSourceConnection">Required. The <see cref="SearchIndexerDataSourceConnection"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerDataSourceConnection.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerDataSourceConnection"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<SearchIndexerDataSourceConnection>> CreateOrUpdateDataSourceConnectionAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            SearchIndexerDataSourceConnection dataSourceConnection,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken) => await CreateOrUpdateDataSourceConnectionAsync(
                dataSourceConnection,
                onlyIfUnchanged,
                ignoreCacheResetRequirements: null,
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a new data source or updates an existing data source connection.
        /// </summary>
        /// <param name="dataSourceConnection">Required. The <see cref="SearchIndexerDataSourceConnection"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerDataSourceConnection.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="ignoreCacheResetRequirements"><c>True</c> if the cache reset requirements should be ignored.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerDataSourceConnection"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerDataSourceConnection>> CreateOrUpdateDataSourceConnectionAsync(
            SearchIndexerDataSourceConnection dataSourceConnection,
            bool onlyIfUnchanged = false,
            bool? ignoreCacheResetRequirements = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataSourceConnection, nameof(dataSourceConnection));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = dataSourceConnection?.ETag } : null;
            return await CreateOrUpdateDataSourceConnectionAsync(dataSourceConnection?.Name, dataSourceConnection, matchConditions, ignoreCacheResetRequirements, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a data source connection.
        /// </summary>
        /// <param name="dataSourceConnectionName">The name of the <see cref="SearchIndexerDataSourceConnection"/> to delete.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnectionName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteDataSourceConnection(
            string dataSourceConnectionName,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataSourceConnectionName, nameof(dataSourceConnectionName));
            return DeleteDataSourceConnection(dataSourceConnectionName, matchConditions: null, cancellationToken);
        }

        /// <summary>
        /// Deletes a data source connection.
        /// </summary>
        /// <param name="dataSourceConnectionName">The name of the <see cref="SearchIndexerDataSourceConnection"/> to delete.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnectionName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteDataSourceConnectionAsync(
            string dataSourceConnectionName,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataSourceConnectionName, nameof(dataSourceConnectionName));
            return await DeleteDataSourceConnectionAsync(dataSourceConnectionName, matchConditions: null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a data source connection.
        /// </summary>
        /// <param name="dataSourceConnection">The <see cref="SearchIndexerDataSourceConnection"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerDataSourceConnection.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteDataSourceConnection(
            SearchIndexerDataSourceConnection dataSourceConnection,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataSourceConnection, nameof(dataSourceConnection));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = dataSourceConnection?.ETag } : null;
            return DeleteDataSourceConnection(dataSourceConnection?.Name, matchConditions, cancellationToken);
        }

        /// <summary>
        /// Deletes a data source connection.
        /// </summary>
        /// <param name="dataSourceConnection">The <see cref="SearchIndexerDataSourceConnection"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerDataSourceConnection.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteDataSourceConnectionAsync(
            SearchIndexerDataSourceConnection dataSourceConnection,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataSourceConnection, nameof(dataSourceConnection));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = dataSourceConnection?.ETag } : null;
            return await DeleteDataSourceConnectionAsync(dataSourceConnection?.Name, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a list of all data source connections.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSourceConnection"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<SearchIndexerDataSourceConnection>> GetDataSourceConnections(
            CancellationToken cancellationToken = default)
        {
            Response<ListDataSourcesResult> result = GetDataSourceConnections(new[] { Constants.All }, cancellationToken);
            return Response.FromValue((IReadOnlyList<SearchIndexerDataSourceConnection>)result.Value.DataSources, result.GetRawResponse());
        }

        /// <summary>
        /// Gets a list of all data source connections.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSourceConnection"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<SearchIndexerDataSourceConnection>>> GetDataSourceConnectionsAsync(
            CancellationToken cancellationToken = default)
        {
            Response<ListDataSourcesResult> result = await GetDataSourceConnectionsAsync(new[] { Constants.All }, cancellationToken).ConfigureAwait(false);
            return Response.FromValue((IReadOnlyList<SearchIndexerDataSourceConnection>)result.Value.DataSources, result.GetRawResponse());
        }

        /// <summary>
        /// Gets a list of all data source connection names.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSourceConnection"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<string>> GetDataSourceConnectionNames(
            CancellationToken cancellationToken = default)
        {
            Response<ListDataSourcesResult> result = GetDataSourceConnections(new[] { Constants.NameKey }, cancellationToken);
            IReadOnlyList<string> names = result.Value.DataSources.Select(value => value.Name).ToArray();
            return Response.FromValue(names, result.GetRawResponse());
        }

        /// <summary>
        /// Gets a list of all data source connection names.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSourceConnection"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetDataSourceConnectionNamesAsync(
            CancellationToken cancellationToken = default)
        {
            Response<ListDataSourcesResult> result = await GetDataSourceConnectionsAsync(new[] { Constants.NameKey }, cancellationToken).ConfigureAwait(false);
            IReadOnlyList<string> names = result.Value.DataSources.Select(value => value.Name).ToArray();
            return Response.FromValue(names, result.GetRawResponse());
        }

        #endregion
    }
}
