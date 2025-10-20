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
        private KnowledgeBasesRestClient _KnowledgeBasesRestClient;

        /// <summary>
        /// Gets the generated <see cref="KnowledgeBasesRestClient"/> to make requests.
        /// </summary>
        private KnowledgeBasesRestClient KnowledgeBasesClient => LazyInitializer.EnsureInitialized(ref _KnowledgeBasesRestClient, () => new KnowledgeBasesRestClient(
            _clientDiagnostics,
            _pipeline,
            Endpoint.AbsoluteUri,
            null,
            _version.ToVersionString())
        );

        #region KnowledgeBases Operations
        /// <summary> Creates a new agent. </summary>
        /// <param name="KnowledgeBase"> The definition of the agent to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="KnowledgeBase"/> is null. </exception>
        public virtual Response<KnowledgeBase> CreateKnowledgeBase(KnowledgeBase KnowledgeBase, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateKnowledgeBase)}");
            scope.Start();
            try
            {
                return KnowledgeBasesClient.Create(KnowledgeBase, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new agent. </summary>
        /// <param name="KnowledgeBase"> The definition of the agent to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="KnowledgeBase"/> is null. </exception>
        public virtual async Task<Response<KnowledgeBase>> CreateKnowledgeBaseAsync(KnowledgeBase KnowledgeBase, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateKnowledgeBase)}");
            scope.Start();
            try
            {
                return await KnowledgeBasesClient.CreateAsync(KnowledgeBase, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new agent or updates an agent if it already exists. </summary>
        /// <param name="KnowledgeBase"> The definition of the agent to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeBase.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="KnowledgeBase"/> is null. </exception>
        public virtual Response<KnowledgeBase> CreateOrUpdateKnowledgeBase(KnowledgeBase KnowledgeBase, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(KnowledgeBase, nameof(KnowledgeBase));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateKnowledgeBase)}");
            scope.Start();
            try
            {
                return KnowledgeBasesClient.CreateOrUpdate(
                    KnowledgeBase?.Name,
                    KnowledgeBase,
                    onlyIfUnchanged ? KnowledgeBase?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new agent or updates an agent if it already exists. </summary>
        /// <param name="KnowledgeBase"> The definition of the agent to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeBase.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="KnowledgeBase"/> is null. </exception>
        public virtual async Task<Response<KnowledgeBase>> CreateOrUpdateKnowledgeBaseAsync(KnowledgeBase KnowledgeBase, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(KnowledgeBase, nameof(KnowledgeBase));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateKnowledgeBase)}");
            scope.Start();
            try
            {
                return await KnowledgeBasesClient.CreateOrUpdateAsync(
                    KnowledgeBase?.Name,
                    KnowledgeBase,
                    onlyIfUnchanged ? KnowledgeBase?.ETag?.ToString() : null,
                    null,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes an existing agent. </summary>
        /// <param name="agentName"> The name of the agent to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
        public virtual Response DeleteKnowledgeBase(string agentName, CancellationToken cancellationToken = default) =>
            DeleteKnowledgeBase(agentName, null, false, cancellationToken);

        //// <summary> Deletes an existing agent. </summary>
        /// <param name="agentName"> The name of the agent to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
        public virtual async Task<Response> DeleteKnowledgeBaseAsync(string agentName, CancellationToken cancellationToken = default) =>
            await DeleteKnowledgeBaseAsync(agentName, null, false, cancellationToken).ConfigureAwait(false);

        /// <summary> Deletes an existing agent. </summary>
        /// <param name="KnowledgeBase"> The definition of the agent to delete. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeBase.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="KnowledgeBase"/> is null. </exception>
        public virtual Response DeleteKnowledgeBase(KnowledgeBase KnowledgeBase, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(KnowledgeBase, nameof(KnowledgeBase));

            return DeleteKnowledgeBase(
                KnowledgeBase?.Name,
                KnowledgeBase?.ETag,
                onlyIfUnchanged,
                cancellationToken);
        }

        /// <summary> Deletes an existing agent. </summary>
        /// <param name="KnowledgeBase"> The definition of the agent to delete. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeBase.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="KnowledgeBase"/> is null. </exception>
        public virtual async Task<Response> DeleteKnowledgeBaseAsync(KnowledgeBase KnowledgeBase, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(KnowledgeBase, nameof(KnowledgeBase));

            return await DeleteKnowledgeBaseAsync(
                KnowledgeBase?.Name,
                KnowledgeBase?.ETag,
                onlyIfUnchanged,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private Response DeleteKnowledgeBase(string agentName, string etag, bool onlyIfUnchanged, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteKnowledgeBase)}");
            scope.Start();
            try
            {
                return KnowledgeBasesClient.Delete(
                    agentName,
                    onlyIfUnchanged ? etag : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private async Task<Response> DeleteKnowledgeBaseAsync(string agentName, string etag, bool onlyIfUnchanged, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteKnowledgeBase)}");
            scope.Start();
            try
            {
                return await KnowledgeBasesClient.DeleteAsync(
                    agentName,
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

        /// <summary> Retrieves an agent definition. </summary>
        /// <param name="agentName"> The name of the agent to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
        public virtual Response<KnowledgeBase> GetKnowledgeBase(string agentName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeBase)}");
            scope.Start();
            try
            {
                return KnowledgeBasesClient.Get(agentName, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an agent definition. </summary>
        /// <param name="agentName"> The name of the agent to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
        public virtual async Task<Response<KnowledgeBase>> GetKnowledgeBaseAsync(string agentName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeBase)}");
            scope.Start();
            try
            {
                return await KnowledgeBasesClient.GetAsync(agentName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Lists all agents available for a search service. </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Pageable{T}"/> from the server containing a list of <see cref="KnowledgeBase"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Pageable<KnowledgeBase> GetKnowledgeBases(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable((continuationToken) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeBases)}");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListKnowledgeBasesResult> result = KnowledgeBasesClient.List(cancellationToken);

                    return Page<KnowledgeBase>.FromValues(result.Value.KnowledgeBases, null, result.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary> Lists all agents available for a search service. </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="KnowledgeBase"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual AsyncPageable<KnowledgeBase> GetKnowledgeBasesAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async (continuationToken) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeBases)}");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListKnowledgeBasesResult> result = await KnowledgeBasesClient.ListAsync(cancellationToken).ConfigureAwait(false);

                    return Page<KnowledgeBase>.FromValues(result.Value.KnowledgeBases, null, result.GetRawResponse());
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
