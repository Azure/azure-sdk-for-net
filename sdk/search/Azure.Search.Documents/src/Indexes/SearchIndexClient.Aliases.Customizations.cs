// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Utilities;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage indexes on a Search service.
    /// This partial class contains customizations for Alias operations that extend the generated client.
    /// </summary>
    public partial class SearchIndexClient
    {
        #region Alias Customizations

        /// <summary>
        /// Creates a new search alias or updates an alias if it already exists.
        /// </summary>
        /// <param name="alias">The definition of the alias to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchAlias.ETag"/> does not match the current alias version;
        /// otherwise, the current version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns><see cref="SearchAlias"/> created or updated by the service.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="alias"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchAlias> CreateOrUpdateAlias(
            SearchAlias alias,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(alias, nameof(alias));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = alias.ETag } : null;
            return CreateOrUpdateAlias(alias.Name, alias, matchConditions, cancellationToken);
        }

        /// <summary>
        /// Creates a new search alias or updates an alias if it already exists.
        /// </summary>
        /// <param name="alias">The definition of the alias to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchAlias.ETag"/> does not match the current alias version;
        /// otherwise, the current version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns><see cref="SearchAlias"/> created or updated by the service.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="alias"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchAlias>> CreateOrUpdateAliasAsync(
            SearchAlias alias,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(alias, nameof(alias));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = alias.ETag } : null;
            return await CreateOrUpdateAliasAsync(alias.Name, alias, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves an alias definition.
        /// </summary>
        /// <param name="aliasName">The name of the alias to retrieve.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns><see cref="SearchAlias"/> defined by <paramref name="aliasName"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="aliasName"/> is null or empty.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchAlias> GetAlias(string aliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(aliasName, nameof(aliasName));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetAlias)}");
            scope.Start();
            try
            {
                Response response = GetAlias(aliasName, cancellationToken.ToRequestContext());
                return Response.FromValue((SearchAlias)response, response);
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
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns><see cref="SearchAlias"/> defined by <paramref name="aliasName"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="aliasName"/> is null or empty.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchAlias>> GetAliasAsync(string aliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(aliasName, nameof(aliasName));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetAlias)}");
            scope.Start();
            try
            {
                Response response = await GetAliasAsync(aliasName, cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return Response.FromValue((SearchAlias)response, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all alias definitions available for a search service.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Pageable{T}"/> from the server containing a list of <see cref="SearchAlias"/> objects.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Pageable<SearchAlias> GetAliases(CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<BinaryData, SearchAlias>(
                GetAliases(cancellationToken.ToRequestContext()),
                bd => SearchAlias.DeserializeSearchAlias(JsonDocument.Parse(bd).RootElement, ModelSerializationExtensions.WireOptions));
        }

        /// <summary>
        /// Gets a list of all alias definitions available for a search service.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="AsyncPageable{T}"/> from the server containing a list of <see cref="SearchAlias"/> objects.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual AsyncPageable<SearchAlias> GetAliasesAsync(CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<BinaryData, SearchAlias>(
                GetAliasesAsync(cancellationToken.ToRequestContext()),
                bd => SearchAlias.DeserializeSearchAlias(JsonDocument.Parse(bd).RootElement, ModelSerializationExtensions.WireOptions));
        }

        #endregion
    }
}
