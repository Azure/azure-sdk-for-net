// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage knowledge sources on a Search service.
    /// </summary>
    public partial class SearchIndexClient
    {
        #region KnowledgeSources Operations

        /// <summary> Creates a new knowledge source. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeSource"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<KnowledgeSource> CreateKnowledgeSource(KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            Response response = CreateKnowledgeSource(knowledgeSource, cancellationToken.ToRequestContext());
            return Response.FromValue((KnowledgeSource)response, response);
        }

        /// <summary> Creates a new knowledge source. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeSource"/> is null. </exception>ls]
        public virtual async Task<Response<KnowledgeSource>> CreateKnowledgeSourceAsync(KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            Response response = await CreateKnowledgeSourceAsync(knowledgeSource, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((KnowledgeSource)response, response);
        }

        /// <summary> Creates a new knowledge source or updates an knowledge source if it already exists. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeSource"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<KnowledgeSource> CreateOrUpdateKnowledgeSource(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeSource?.ETag } : null;
            return CreateOrUpdateKnowledgeSource(knowledgeSource?.Name, knowledgeSource, matchConditions, cancellationToken);
        }

        /// <summary> Creates a new knowledge source or updates an knowledge source if it already exists. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeSource"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<KnowledgeSource>> CreateOrUpdateKnowledgeSourceAsync(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeSource?.ETag } : null;
            return await CreateOrUpdateKnowledgeSourceAsync(knowledgeSource?.Name, knowledgeSource, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Deletes an existing knowledge source. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to delete. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeSource"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response DeleteKnowledgeSource(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeSource?.ETag } : null;
            return DeleteKnowledgeSource(knowledgeSource?.Name, matchConditions, cancellationToken);
        }

        /// <summary> Deletes an existing knowledge source. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to delete. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeSource"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteKnowledgeSourceAsync(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeSource?.ETag } : null;
            return await DeleteKnowledgeSourceAsync(knowledgeSource?.Name, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}
