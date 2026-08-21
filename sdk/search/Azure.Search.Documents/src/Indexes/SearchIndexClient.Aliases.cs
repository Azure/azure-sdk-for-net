// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage indexes on a Search service.
    /// This partial class contains customizations for Alias operations that extend the generated client.
    /// </summary>
    public partial class SearchIndexClient
    {
        #region Alias Customizations

        /// <summary> Lists all aliases available for a search service. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BinaryData> GetAliases(RequestContext context) =>
            GetAliases(search: default, pageSize: default, searchType: default, context: context);

        /// <summary> Lists all aliases available for a search service. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BinaryData> GetAliasesAsync(RequestContext context) =>
            GetAliasesAsync(search: default, pageSize: default, searchType: default, context: context);

        /// <summary>
        /// Creates a new search alias or updates an alias if it already exists.
        /// </summary>
        /// <param name="alias">The definition of the alias to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchAlias.ETag"/> does not match the current alias version;
        /// otherwise, the current version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns><see cref="SearchAlias"/> defined by <c>aliasName</c>.</returns>
        [ForwardsClientCalls]
        public virtual Response<SearchAlias> CreateOrUpdateAlias(SearchAlias alias, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default) =>
            CreateOrUpdateAlias(alias.Name, alias, onlyIfUnchanged ? new MatchConditions { IfMatch = alias.ETag } : null, cancellationToken);

        /// <summary>
        /// Creates a new search alias or updates an alias if it already exists.
        /// </summary>
        /// <param name="alias">The definition of the alias to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchAlias.ETag"/> does not match the current alias version;
        /// otherwise, the current version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns><see cref="SearchAlias"/> defined by <c>aliasName</c>.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<SearchAlias>> CreateOrUpdateAliasAsync(SearchAlias alias, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default) =>
            await CreateOrUpdateAliasAsync(alias.Name, alias, onlyIfUnchanged ? new MatchConditions { IfMatch = alias.ETag } : null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Deletes a search alias and its associated mapping to an index. This operation is permanent, with no recovery option. The mapped index is untouched by this operation.
        /// </summary>
        /// <param name="alias">The definition of the alias to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchAlias.ETag"/> does not match the current alias version;
        /// otherwise, the current version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns><see cref="Response"/> from the service.</returns>
        [ForwardsClientCalls]
        public virtual Response DeleteAlias(SearchAlias alias, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default) =>
             DeleteAlias(alias.Name, onlyIfUnchanged ? new MatchConditions { IfMatch = alias.ETag } : null, cancellationToken);

        /// <summary>
        /// Deletes a search alias and its associated mapping to an index. This operation is permanent, with no recovery option. The mapped index is untouched by this operation.
        /// </summary>
        /// <param name="alias">The definition of the alias to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchAlias.ETag"/> does not match the current alias version;
        /// otherwise, the current version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns><see cref="Response"/> from the service.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteAliasAsync(SearchAlias alias, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default) =>
            await DeleteAliasAsync(alias.Name, onlyIfUnchanged ? new MatchConditions { IfMatch = alias.ETag } : null, cancellationToken).ConfigureAwait(false);
        #endregion
    }
}
