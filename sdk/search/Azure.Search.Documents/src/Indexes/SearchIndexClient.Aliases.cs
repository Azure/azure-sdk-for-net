// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage indexes on a Search service.
    /// </summary>
    public partial class SearchIndexClient
    {
        private AliasesRestClient _aliasesRestClient;

        /// <summary>
        /// Gets the generated <see cref="AliasesRestClient"/> to make requests.
        /// </summary>
        private AliasesRestClient AliasesClient => LazyInitializer.EnsureInitialized(ref _aliasesRestClient, () => new AliasesRestClient(
            _clientDiagnostics,
            _pipeline,
            Endpoint.AbsoluteUri,
            null,
            _version.ToVersionString())
        );

        /// <summary>
        /// Creates a new search alias.
        /// </summary>
        /// <param name="alias">The definition of the alias to create.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns><see cref="SearchAlias"/> created by the service.</returns>
        public virtual Response<SearchAlias> CreateAlias(SearchAlias alias, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateAlias)}");
            scope.Start();
            try
            {
                return AliasesClient.Create(alias, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new search alias.
        /// </summary>
        /// <param name="alias">The definition of the alias to create.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns><see cref="SearchAlias"/> created by the service.</returns>
        public virtual async Task<Response<SearchAlias>> CreateAliasAsync(SearchAlias alias, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateAlias)}");
            scope.Start();
            try
            {
                return await AliasesClient.CreateAsync(alias, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new search alias or updates an alias if it already exists.
        /// </summary>
        /// <param name="aliasName">The name of the alias to create or update.</param>
        /// <param name="alias">The definition of the alias to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchAlias.ETag"/> does not match the current alias version;
        /// otherwise, the current version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns><see cref="SearchAlias"/> defined by <c>aliasName</c>.</returns>
        public virtual Response<SearchAlias> CreateOrUpdateAlias(string aliasName, SearchAlias alias, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateAlias)}");
            scope.Start();
            try
            {
                return AliasesClient.CreateOrUpdate(aliasName, alias, onlyIfUnchanged ? alias.ETag?.ToString() : null, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new search alias or updates an alias if it already exists.
        /// </summary>
        /// <param name="aliasName">The name of the alias to create or update.</param>
        /// <param name="alias">The definition of the alias to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchAlias.ETag"/> does not match the current alias version;
        /// otherwise, the current version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns><see cref="SearchAlias"/> defined by <c>aliasName</c>.</returns>
        public virtual async Task<Response<SearchAlias>> CreateOrUpdateAliasAsync(string aliasName, SearchAlias alias, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateAlias)}");
            scope.Start();
            try
            {
                return await AliasesClient.CreateOrUpdateAsync(aliasName, alias, onlyIfUnchanged ? alias.ETag?.ToString() : null, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a search alias and its associated mapping to an index. This operation is permanent, with no recovery option. The mapped index is untouched by this operation.
        /// </summary>
        /// <param name="aliasName">The name of the alias to delete.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns><see cref="Response"/> from the service.</returns>
        public virtual Response DeleteAlias(string aliasName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteAlias)}");
            scope.Start();
            try
            {
                return AliasesClient.Delete(aliasName, null, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a search alias and its associated mapping to an index. This operation is permanent, with no recovery option. The mapped index is untouched by this operation.
        /// </summary>
        /// <param name="aliasName">The name of the alias to delete.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns><see cref="Response"/> from the service.</returns>
        public virtual async Task<Response> DeleteAliasAsync(string aliasName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteAlias)}");
            scope.Start();
            try
            {
                return await AliasesClient.DeleteAsync(aliasName, null, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves an alias definition.
        /// </summary>
        /// <param name="aliasName">The name of the alias to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns><see cref="SearchAlias"/> defined by <c>aliasName</c>.</returns>
        public virtual Response<SearchAlias> GetAlias(string aliasName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetAlias)}");
            scope.Start();
            try
            {
                return AliasesClient.Get(aliasName, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves an alias definition.
        /// </summary>
        /// <param name="aliasName">The name of the alias to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns><see cref="SearchAlias"/> defined by <c>aliasName</c>.</returns>
        public virtual async Task<Response<SearchAlias>> GetAliasAsync(string aliasName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetAlias)}");
            scope.Start();
            try
            {
                return await AliasesClient.GetAsync(aliasName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves all alias definitions available for a search service.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Collection of <see cref="SearchAlias"/> available for the search service.</returns>
        public virtual Response<IReadOnlyList<SearchAlias>> GetAliases(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetAliases)}");
            scope.Start();
            try
            {
                Response<ListAliasesResult> result = AliasesClient.List(cancellationToken);
                return Response.FromValue(result.Value.Aliases, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves all alias definitions available for a search service.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Collection of <see cref="SearchAlias"/> available for the search service.</returns>
        public virtual async Task<Response<IReadOnlyList<SearchAlias>>> GetAliasesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetAliases)}");
            scope.Start();
            try
            {
                Response<ListAliasesResult> result = await AliasesClient.ListAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue(result.Value.Aliases, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
