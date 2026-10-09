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
    /// Azure Cognitive Search client that can be used to manage knowledge bases on a Search service.
    /// </summary>
    public partial class SearchIndexClient
    {
        #region KnowledgeBases Operations

        /// <summary> Lists all knowledge bases available for a search service. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BinaryData> GetKnowledgeBases(RequestContext context) =>
            GetKnowledgeBases(search: default, pageSize: default, searchType: default, context: context);

        /// <summary> Lists all knowledge bases available for a search service. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BinaryData> GetKnowledgeBasesAsync(RequestContext context) =>
            GetKnowledgeBasesAsync(search: default, pageSize: default, searchType: default, context: context);

        /// <summary> Creates a new knowledge base. </summary>
        /// <param name="knowledgeBase"> The definition of the knowledge base to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBase"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<KnowledgeBase> CreateKnowledgeBase(KnowledgeBase knowledgeBase, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeBase, nameof(knowledgeBase));

            Response response = CreateKnowledgeBase(knowledgeBase, cancellationToken.ToRequestContext());
            return Response.FromValue((KnowledgeBase)response, response);
        }

        /// <summary> Creates a new knowledge base. </summary>
        /// <param name="knowledgeBase"> The definition of the knowledge base to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBase"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<KnowledgeBase>> CreateKnowledgeBaseAsync(KnowledgeBase knowledgeBase, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeBase, nameof(knowledgeBase));

            Response response = await CreateKnowledgeBaseAsync(knowledgeBase, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((KnowledgeBase)response, response);
        }

        /// <summary> Creates a new knowledge base or updates a knowledge base if it already exists. </summary>
        /// <param name="knowledgeBase"> The definition of the knowledge base to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeBase.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeBase"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<KnowledgeBase> CreateOrUpdateKnowledgeBase(KnowledgeBase knowledgeBase, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeBase, nameof(knowledgeBase));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeBase?.ETag } : null;
            return CreateOrUpdateKnowledgeBase(knowledgeBase?.Name, knowledgeBase, matchConditions, cancellationToken);
        }

        /// <summary> Creates a new knowledge base or updates a knowledge base if it already exists. </summary>
        /// <param name="knowledgeBase"> The definition of the knowledge base to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeBase.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeBase"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<KnowledgeBase>> CreateOrUpdateKnowledgeBaseAsync(KnowledgeBase knowledgeBase, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeBase, nameof(knowledgeBase));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeBase?.ETag } : null;
            return await CreateOrUpdateKnowledgeBaseAsync(knowledgeBase?.Name, knowledgeBase, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Deletes an existing knowledge base. </summary>
        /// <param name="knowledgeBase"> The definition of the knowledge base to delete. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeBase.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBase"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response DeleteKnowledgeBase(KnowledgeBase knowledgeBase, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeBase, nameof(knowledgeBase));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeBase.ETag } : null;
            return DeleteKnowledgeBase(knowledgeBase.Name, matchConditions, cancellationToken);
        }

        /// <summary> Deletes an existing knowledge base. </summary>
        /// <param name="knowledgeBase"> The definition of the knowledge base to delete. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeBase.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBase"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteKnowledgeBaseAsync(KnowledgeBase knowledgeBase, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeBase, nameof(knowledgeBase));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeBase.ETag } : null;
            return await DeleteKnowledgeBaseAsync(knowledgeBase.Name, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}
