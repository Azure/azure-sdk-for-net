// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Utilities;

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
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeSource"/> that was created.
        /// </returns>
        public virtual Response<KnowledgeSource> CreateKnowledgeSource(KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            Response response = CreateKnowledgeSource(knowledgeSource, cancellationToken.ToRequestContext());
            return Response.FromValue((KnowledgeSource)response, response);
        }

        /// <summary> Creates a new knowledge source. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeSource"/> is null. </exception>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeSource"/> that was created.
        /// </returns>
        public virtual async Task<Response<KnowledgeSource>> CreateKnowledgeSourceAsync(KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            Response response = await CreateKnowledgeSourceAsync(knowledgeSource, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((KnowledgeSource)response, response);
        }

        /// <summary> Creates a new knowledge source or updates a knowledge source if it already exists. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeSource"/> is null. </exception>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeSource"/> that was created or updated.
        /// </returns>
        public virtual Response<KnowledgeSource> CreateOrUpdateKnowledgeSource(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeSource?.ETag } : null;
            return CreateOrUpdateKnowledgeSource(knowledgeSource?.Name, knowledgeSource, matchConditions, cancellationToken);
        }

        /// <summary> Creates a new knowledge source or updates a knowledge source if it already exists. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeSource"/> is null. </exception>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeSource"/> that was created or updated.
        /// </returns>
        public virtual async Task<Response<KnowledgeSource>> CreateOrUpdateKnowledgeSourceAsync(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeSource?.ETag } : null;
            return await CreateOrUpdateKnowledgeSourceAsync(knowledgeSource?.Name, knowledgeSource, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Deletes an existing knowledge source. </summary>
        /// <param name="sourceName"> The name of the knowledge source to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/> is null. </exception>
        public virtual Response DeleteKnowledgeSource(string sourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sourceName, nameof(sourceName));

            return DeleteKnowledgeSource(sourceName, matchConditions: null, cancellationToken);
        }

        /// <summary> Deletes an existing knowledge source. </summary>
        /// <param name="sourceName"> The name of the knowledge source to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/> is null. </exception>
        public virtual async Task<Response> DeleteKnowledgeSourceAsync(string sourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sourceName, nameof(sourceName));

            return await DeleteKnowledgeSourceAsync(sourceName, matchConditions: null, cancellationToken).ConfigureAwait(false);
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
        public virtual async Task<Response> DeleteKnowledgeSourceAsync(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeSource?.ETag } : null;
            return await DeleteKnowledgeSourceAsync(knowledgeSource?.Name, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Retrieves a knowledge source definition. </summary>
        /// <param name="sourceName"> The name of the knowledge source to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/> is null. </exception>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeSource"/>.
        /// </returns>
        public virtual Response<KnowledgeSource> GetKnowledgeSource(string sourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sourceName, nameof(sourceName));

            Response response = GetKnowledgeSource(sourceName, cancellationToken.ToRequestContext());
            return Response.FromValue((KnowledgeSource)response, response);
        }

        /// <summary> Retrieves a knowledge source definition. </summary>
        /// <param name="sourceName"> The name of the knowledge source to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/> is null. </exception>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeSource"/>.
        /// </returns>
        public virtual async Task<Response<KnowledgeSource>> GetKnowledgeSourceAsync(string sourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sourceName, nameof(sourceName));

            Response response = await GetKnowledgeSourceAsync(sourceName, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((KnowledgeSource)response, response);
        }

        /// <summary> Lists all knowledge sources available for a search service. </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Pageable{T}"/> from the server containing a list of <see cref="KnowledgeSource"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Pageable<KnowledgeSource> GetKnowledgeSources(CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<BinaryData, KnowledgeSource>(
                GetKnowledgeSources(cancellationToken.ToRequestContext()),
                bd => KnowledgeSource.DeserializeKnowledgeSource(JsonDocument.Parse(bd).RootElement, ModelSerializationExtensions.WireOptions));
        }

        /// <summary> Lists all knowledge sources available for a search service. </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="AsyncPageable{T}"/> from the server containing a list of <see cref="KnowledgeSource"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual AsyncPageable<KnowledgeSource> GetKnowledgeSourcesAsync(CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<BinaryData, KnowledgeSource>(
                GetKnowledgeSourcesAsync(cancellationToken.ToRequestContext()),
                bd => KnowledgeSource.DeserializeKnowledgeSource(JsonDocument.Parse(bd).RootElement, ModelSerializationExtensions.WireOptions));
        }

        /// <summary> Returns the current status and synchronization history of a knowledge source. </summary>
        /// <param name="sourceName"> The name of the knowledge source for which to retrieve status. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/> is null. </exception>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeSourceStatus"/>.
        /// </returns>
        public virtual Response<KnowledgeSourceStatus> GetKnowledgeSourceStatus(string sourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sourceName, nameof(sourceName));

            Response response = GetKnowledgeSourceStatus(sourceName, cancellationToken.ToRequestContext());
            return Response.FromValue((KnowledgeSourceStatus)response, response);
        }

        /// <summary> Returns the current status and synchronization history of a knowledge source. </summary>
        /// <param name="sourceName"> The name of the knowledge source for which to retrieve status. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/> is null. </exception>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="KnowledgeSourceStatus"/>.
        /// </returns>
        public virtual async Task<Response<KnowledgeSourceStatus>> GetKnowledgeSourceStatusAsync(string sourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sourceName, nameof(sourceName));

            Response response = await GetKnowledgeSourceStatusAsync(sourceName, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((KnowledgeSourceStatus)response, response);
        }

        #endregion
    }
}
