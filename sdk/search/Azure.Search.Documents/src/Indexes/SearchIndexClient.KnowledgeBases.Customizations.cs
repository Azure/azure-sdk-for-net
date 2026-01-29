// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Utilities;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage knowledge bases on a Search service.
    /// </summary>
    public partial class SearchIndexClient
    {
        #region KnowledgeBases Operations

        /// <summary> Creates a new knowledge base. </summary>
        /// <param name="knowledgeBase"> The definition of the knowledge base to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBase"/> is null. </exception>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeBase"/> that was created.
        /// </returns>
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
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeBase"/> that was created.
        /// </returns>
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
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeBase"/> that was created or updated.
        /// </returns>
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
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeBase"/> that was created or updated.
        /// </returns>
        public virtual async Task<Response<KnowledgeBase>> CreateOrUpdateKnowledgeBaseAsync(KnowledgeBase knowledgeBase, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeBase, nameof(knowledgeBase));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeBase?.ETag } : null;
            return await CreateOrUpdateKnowledgeBaseAsync(knowledgeBase?.Name, knowledgeBase, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Deletes an existing knowledge base. </summary>
        /// <param name="knowledgeBaseName"> The name of the knowledge base to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBaseName"/> is null. </exception>
        public virtual Response DeleteKnowledgeBase(string knowledgeBaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));

            return DeleteKnowledgeBase(knowledgeBaseName, matchConditions: null, cancellationToken);
        }

        /// <summary> Deletes an existing knowledge base. </summary>
        /// <param name="knowledgeBaseName"> The name of the knowledge base to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBaseName"/> is null. </exception>
        public virtual async Task<Response> DeleteKnowledgeBaseAsync(string knowledgeBaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));

            return await DeleteKnowledgeBaseAsync(knowledgeBaseName, matchConditions: null, cancellationToken).ConfigureAwait(false);
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
        public virtual Response DeleteKnowledgeBase(KnowledgeBase knowledgeBase, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeBase, nameof(knowledgeBase));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeBase?.ETag } : null;
            return DeleteKnowledgeBase(knowledgeBase?.Name, matchConditions, cancellationToken);
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
        public virtual async Task<Response> DeleteKnowledgeBaseAsync(KnowledgeBase knowledgeBase, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeBase, nameof(knowledgeBase));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeBase?.ETag } : null;
            return await DeleteKnowledgeBaseAsync(knowledgeBase?.Name, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Retrieves a knowledge base definition. </summary>
        /// <param name="knowledgeBaseName"> The name of the knowledge base to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBaseName"/> is null. </exception>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeBase"/>.
        /// </returns>
        public virtual Response<KnowledgeBase> GetKnowledgeBase(string knowledgeBaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));

            Response response = GetKnowledgeBase(knowledgeBaseName, cancellationToken.ToRequestContext());
            return Response.FromValue((KnowledgeBase)response, response);
        }

        /// <summary> Retrieves a knowledge base definition. </summary>
        /// <param name="knowledgeBaseName"> The name of the knowledge base to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeBaseName"/> is null. </exception>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeBase"/>.
        /// </returns>
        public virtual async Task<Response<KnowledgeBase>> GetKnowledgeBaseAsync(string knowledgeBaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));

            Response response = await GetKnowledgeBaseAsync(knowledgeBaseName, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((KnowledgeBase)response, response);
        }

        /// <summary> Lists all knowledge bases available for a search service. </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Pageable{T}"/> from the server containing a list of <see cref="KnowledgeBase"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Pageable<KnowledgeBase> GetKnowledgeBases(CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<BinaryData, KnowledgeBase>(
                GetKnowledgeBases(cancellationToken.ToRequestContext()),
                bd => KnowledgeBase.DeserializeKnowledgeBase(JsonDocument.Parse(bd).RootElement, ModelSerializationExtensions.WireOptions));
        }

        /// <summary> Lists all knowledge bases available for a search service. </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="AsyncPageable{T}"/> from the server containing a list of <see cref="KnowledgeBase"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual AsyncPageable<KnowledgeBase> GetKnowledgeBasesAsync(CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<BinaryData, KnowledgeBase>(
                GetKnowledgeBasesAsync(cancellationToken.ToRequestContext()),
                bd => KnowledgeBase.DeserializeKnowledgeBase(JsonDocument.Parse(bd).RootElement, ModelSerializationExtensions.WireOptions));
        }

        #endregion
    }
}
