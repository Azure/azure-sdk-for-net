// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage indexes on a Search service.
    /// </summary>
    public partial class SearchIndexClient
    {
        private KnowledgeSourcesRestClient _knowledgeSourcesRestClient;

        /// <summary>
        /// Gets the generated <see cref="KnowledgeSourcesRestClient"/> to make requests.
        /// </summary>
        private KnowledgeSourcesRestClient KnowledgeSourcesClient => LazyInitializer.EnsureInitialized(ref _knowledgeSourcesRestClient, () => new KnowledgeSourcesRestClient(
            _clientDiagnostics,
            _pipeline,
            Endpoint.AbsoluteUri,
            null,
            _version.ToVersionString())
        );

        #region KnowledgeSources Operations
        /// <summary> Creates a new knowledge source. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeSource"/> is null. </exception>
        public virtual Response<KnowledgeSource> CreateKnowledgeSource(KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateKnowledgeSource)}");
            scope.Start();
            try
            {
                return KnowledgeSourcesClient.Create(knowledgeSource, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new knowledge source. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeSource"/> is null. </exception>
        public virtual async Task<Response<KnowledgeSource>> CreateKnowledgeSourceAsync(KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateKnowledgeSource)}");
            scope.Start();
            try
            {
                return await KnowledgeSourcesClient.CreateAsync(knowledgeSource, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new knowledge source or updates an knowledge source if it already exists. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeSource"/> is null. </exception>
        public virtual Response<KnowledgeSource> CreateOrUpdateKnowledgeSource(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateKnowledgeSource)}");
            scope.Start();
            try
            {
                return KnowledgeSourcesClient.CreateOrUpdate(
                    knowledgeSource?.Name,
                    knowledgeSource,
                    onlyIfUnchanged ? knowledgeSource?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new knowledge source or updates an knowledge source if it already exists. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeSource"/> is null. </exception>
        public virtual async Task<Response<KnowledgeSource>> CreateOrUpdateKnowledgeSourceAsync(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateKnowledgeSource)}");
            scope.Start();
            try
            {
                return await KnowledgeSourcesClient.CreateOrUpdateAsync(
                    knowledgeSource?.Name,
                    knowledgeSource,
                    onlyIfUnchanged ? knowledgeSource?.ETag?.ToString() : null,
                    null,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes an existing knowledge source. </summary>
        /// <param name="sourceName"> The name of the knowledge source to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/> is null. </exception>
        public virtual Response DeleteKnowledgeSource(string sourceName, CancellationToken cancellationToken = default) =>
            DeleteKnowledgeSource(sourceName, null, false, cancellationToken);

        /// <summary> Deletes an existing knowledge source. </summary>
        /// <param name="sourceName"> The name of the knowledge source to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/> is null. </exception>
        public virtual async Task<Response> DeleteKnowledgeSourceAsync(string sourceName, CancellationToken cancellationToken = default) =>
            await DeleteKnowledgeSourceAsync(sourceName, null, false, cancellationToken).ConfigureAwait(false);

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

            return DeleteKnowledgeSource(
                knowledgeSource?.Name,
                knowledgeSource?.ETag,
                onlyIfUnchanged,
                cancellationToken);
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

            return await DeleteKnowledgeSourceAsync(
                knowledgeSource?.Name,
                knowledgeSource?.ETag,
                onlyIfUnchanged,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private Response DeleteKnowledgeSource(string sourceName, ETag? etag, bool onlyIfUnchanged, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteKnowledgeSource)}");
            scope.Start();
            try
            {
                return KnowledgeSourcesClient.Delete(
                    sourceName,
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

        private async Task<Response> DeleteKnowledgeSourceAsync(string sourceName, ETag? etag, bool onlyIfUnchanged, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteKnowledgeSource)}");
            scope.Start();
            try
            {
                return await KnowledgeSourcesClient.DeleteAsync(
                    sourceName,
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

        /// <summary> Retrieves a knowledge source definition. </summary>
        /// <param name="sourceName"> The name of the knowledge source to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/> is null. </exception>
        public virtual Response<KnowledgeSource> GetKnowledgeSource(string sourceName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeSource)}");
            scope.Start();
            try
            {
                return KnowledgeSourcesClient.Get(sourceName, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves a knowledge source definition. </summary>
        /// <param name="sourceName"> The name of the knowledge source to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/> is null. </exception>
        public virtual async Task<Response<KnowledgeSource>> GetKnowledgeSourceAsync(string sourceName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeSource)}");
            scope.Start();
            try
            {
                return await KnowledgeSourcesClient.GetAsync(sourceName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Lists all knowledge sources available for a search service. </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Pageable{T}"/> from the server containing a list of <see cref="KnowledgeSource"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Pageable<KnowledgeSource> GetKnowledgeSources(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable((continuationToken) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeSources)}");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListKnowledgeSourcesResult> result = KnowledgeSourcesClient.List(cancellationToken);

                    return Page<KnowledgeSource>.FromValues(result.Value.KnowledgeSources, null, result.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary> Lists all knowledge sources available for a search service. </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="KnowledgeSource"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual AsyncPageable<KnowledgeSource> GetKnowledgeSourcesAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async (continuationToken) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeSources)}");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListKnowledgeSourcesResult> result = await KnowledgeSourcesClient.ListAsync(cancellationToken).ConfigureAwait(false);

                    return Page<KnowledgeSource>.FromValues(result.Value.KnowledgeSources, null, result.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }
        #endregion
    }
}
