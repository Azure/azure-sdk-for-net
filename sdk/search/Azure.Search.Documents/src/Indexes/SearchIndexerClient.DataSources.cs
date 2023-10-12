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

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage and query
    /// indexes and documents, as well as manage other resources, on a Search
    /// Service.
    /// </summary>
    public partial class SearchIndexerClient
    {
        private DataSourcesRestClient _dataSourcesClient;

        /// <summary>
        /// Gets the generated <see cref="DataSourcesRestClient"/> to make requests.
        /// </summary>
        private DataSourcesRestClient DataSourcesClient => LazyInitializer.EnsureInitialized(ref _dataSourcesClient, () => new DataSourcesRestClient(
            _clientDiagnostics,
            _pipeline,
            Endpoint.AbsoluteUri,
            null,
            _version.ToVersionString())
        );

        /// <summary>
        /// Creates a new data source connection.
        /// </summary>
        /// <param name="dataSourceConnection">Required. The <see cref="SearchIndexerDataSourceConnection"/> to create.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerDataSourceConnection"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerDataSourceConnection> CreateDataSourceConnection(
            SearchIndexerDataSourceConnection dataSourceConnection,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(dataSourceConnection, nameof(dataSourceConnection));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateDataSourceConnection)}");
            scope.Start();
            try
            {
                return DataSourcesClient.Create(
                    dataSourceConnection,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new data source connection.
        /// </summary>
        /// <param name="dataSourceConnection">Required. The <see cref="SearchIndexerDataSourceConnection"/> to create.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerDataSourceConnection"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerDataSourceConnection>> CreateDataSourceConnectionAsync(
            SearchIndexerDataSourceConnection dataSourceConnection,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(dataSourceConnection, nameof(dataSourceConnection));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateDataSourceConnection)}");
            scope.Start();
            try
            {
                return await DataSourcesClient.CreateAsync(
                    dataSourceConnection,
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
        public virtual Response<SearchIndexerDataSourceConnection> CreateOrUpdateDataSourceConnection(
            SearchIndexerDataSourceConnection dataSourceConnection,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(dataSourceConnection, nameof(dataSourceConnection));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateOrUpdateDataSourceConnection)}");
            scope.Start();
            try
            {
                return DataSourcesClient.CreateOrUpdate(
                    dataSourceConnection?.Name,
                    dataSourceConnection,
                    onlyIfUnchanged ? dataSourceConnection?.ETag?.ToString() : null,
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
        public virtual async Task<Response<SearchIndexerDataSourceConnection>> CreateOrUpdateDataSourceConnectionAsync(
            SearchIndexerDataSourceConnection dataSourceConnection,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(dataSourceConnection, nameof(dataSourceConnection));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateOrUpdateDataSourceConnection)}");
            scope.Start();
            try
            {
                return await DataSourcesClient.CreateOrUpdateAsync(
                    dataSourceConnection?.Name,
                    dataSourceConnection,
                    onlyIfUnchanged ? dataSourceConnection?.ETag?.ToString() : null,
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
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(dataSourceConnectionName, nameof(dataSourceConnectionName));

            return DeleteDataSourceConnection(
                dataSourceConnectionName,
                null,
                false,
                cancellationToken);
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
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(dataSourceConnectionName, nameof(dataSourceConnectionName));

            return await DeleteDataSourceConnectionAsync(
                dataSourceConnectionName,
                null,
                false,
                cancellationToken)
                .ConfigureAwait(false);
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
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(dataSourceConnection, nameof(dataSourceConnection));

            return DeleteDataSourceConnection(
                dataSourceConnection?.Name,
                dataSourceConnection?.ETag,
                onlyIfUnchanged,
                cancellationToken);
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
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(dataSourceConnection, nameof(dataSourceConnection));

            return await DeleteDataSourceConnectionAsync(
                dataSourceConnection?.Name,
                dataSourceConnection?.ETag,
                onlyIfUnchanged,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private Response DeleteDataSourceConnection(
            string dataSourceConnectionName,
            ETag? etag,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(DeleteDataSourceConnection)}");
            scope.Start();
            try
            {
                return DataSourcesClient.Delete(
                    dataSourceConnectionName,
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

        private async Task<Response> DeleteDataSourceConnectionAsync(
            string dataSourceConnectionName,
            ETag? etag,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(DeleteDataSourceConnection)}");
            scope.Start();
            try
            {
                return await DataSourcesClient.DeleteAsync(
                    dataSourceConnectionName,
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
        /// Gets a specific <see cref="SearchIndexerDataSourceConnection"/>.
        /// </summary>
        /// <param name="dataSourceConnectionName">Required. The name of the <see cref="SearchIndexerDataSourceConnection"/> to get.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerDataSourceConnection"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnectionName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerDataSourceConnection> GetDataSourceConnection(
            string dataSourceConnectionName,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(dataSourceConnectionName, nameof(dataSourceConnectionName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetDataSourceConnection)}");
            scope.Start();
            try
            {
                return DataSourcesClient.Get(
                    dataSourceConnectionName,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a specific <see cref="SearchIndexerDataSourceConnection"/>.
        /// </summary>
        /// <param name="dataSourceConnectionName">Required. The name of the <see cref="SearchIndexerDataSourceConnection"/> to get.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerDataSourceConnection"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="dataSourceConnectionName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerDataSourceConnection>> GetDataSourceConnectionAsync(
            string dataSourceConnectionName,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(dataSourceConnectionName, nameof(dataSourceConnectionName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetDataSourceConnection)}");
            scope.Start();
            try
            {
                return await DataSourcesClient.GetAsync(
                    dataSourceConnectionName,
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
        /// Gets a list of all data source connections.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSourceConnection"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<SearchIndexerDataSourceConnection>> GetDataSourceConnections(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetDataSourceConnections)}");
            scope.Start();
            try
            {
                Response<ListDataSourcesResult> result = DataSourcesClient.List(
                    Constants.All,
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
        /// Gets a list of all data source connections.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSourceConnection"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<SearchIndexerDataSourceConnection>>> GetDataSourceConnectionsAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetDataSourceConnections)}");
            scope.Start();
            try
            {
                Response<ListDataSourcesResult> result = await DataSourcesClient.ListAsync(
                    Constants.All,
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
        /// Gets a list of all data source connection names.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSourceConnection"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<string>> GetDataSourceConnectionNames(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetDataSourceConnectionNames)}");
            scope.Start();
            try
            {
                Response<ListDataSourcesResult> result = DataSourcesClient.List(
                    Constants.NameKey,
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
        /// Gets a list of all data source connection names.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerDataSourceConnection"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetDataSourceConnectionNamesAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetDataSourceConnectionNames)}");
            scope.Start();
            try
            {
                Response<ListDataSourcesResult> result = await DataSourcesClient.ListAsync(
                    Constants.NameKey,
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
    }
}
