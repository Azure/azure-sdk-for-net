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
        private KnowledgeAgentsRestClient _knowledgeAgentsRestClient;

        /// <summary>
        /// Gets the generated <see cref="KnowledgeAgentsRestClient"/> to make requests.
        /// </summary>
        private KnowledgeAgentsRestClient KnowledgeAgentsClient => LazyInitializer.EnsureInitialized(ref _knowledgeAgentsRestClient, () => new KnowledgeAgentsRestClient(
            _clientDiagnostics,
            _pipeline,
            Endpoint.AbsoluteUri,
            null,
            _version.ToVersionString())
        );

        #region KnowledgeAgents Operations
        /// <summary> Creates a new agent. </summary>
        /// <param name="knowledgeAgent"> The definition of the agent to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeAgent"/> is null. </exception>
        public virtual Response<KnowledgeAgent> CreateKnowledgeAgent(KnowledgeAgent knowledgeAgent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateKnowledgeAgent)}");
            scope.Start();
            try
            {
                return KnowledgeAgentsClient.Create(knowledgeAgent, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new agent. </summary>
        /// <param name="knowledgeAgent"> The definition of the agent to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeAgent"/> is null. </exception>
        public virtual async Task<Response<KnowledgeAgent>> CreateKnowledgeAgentAsync(KnowledgeAgent knowledgeAgent, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateKnowledgeAgent)}");
            scope.Start();
            try
            {
                return await KnowledgeAgentsClient.CreateAsync(knowledgeAgent, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new agent or updates an agent if it already exists. </summary>
        /// <param name="knowledgeAgent"> The definition of the agent to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeAgent.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeAgent"/> is null. </exception>
        public virtual Response<KnowledgeAgent> CreateOrUpdateKnowledgeAgent(KnowledgeAgent knowledgeAgent, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeAgent, nameof(knowledgeAgent));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateKnowledgeAgent)}");
            scope.Start();
            try
            {
                return KnowledgeAgentsClient.CreateOrUpdate(
                    knowledgeAgent?.Name,
                    knowledgeAgent,
                    onlyIfUnchanged ? knowledgeAgent?.ETag?.ToString() : null,
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
        /// <param name="knowledgeAgent"> The definition of the agent to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeAgent.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeAgent"/> is null. </exception>
        public virtual async Task<Response<KnowledgeAgent>> CreateOrUpdateKnowledgeAgentAsync(KnowledgeAgent knowledgeAgent, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeAgent, nameof(knowledgeAgent));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(CreateOrUpdateKnowledgeAgent)}");
            scope.Start();
            try
            {
                return await KnowledgeAgentsClient.CreateOrUpdateAsync(
                    knowledgeAgent?.Name,
                    knowledgeAgent,
                    onlyIfUnchanged ? knowledgeAgent?.ETag?.ToString() : null,
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
        public virtual Response DeleteKnowledgeAgent(string agentName, CancellationToken cancellationToken = default) =>
            DeleteKnowledgeAgent(agentName, null, false, cancellationToken);

        //// <summary> Deletes an existing agent. </summary>
        /// <param name="agentName"> The name of the agent to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
        public virtual async Task<Response> DeleteKnowledgeAgentAsync(string agentName, CancellationToken cancellationToken = default) =>
            await DeleteKnowledgeAgentAsync(agentName, null, false, cancellationToken).ConfigureAwait(false);

        /// <summary> Deletes an existing agent. </summary>
        /// <param name="knowledgeAgent"> The definition of the agent to delete. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeAgent.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeAgent"/> is null. </exception>
        public virtual Response DeleteKnowledgeAgent(KnowledgeAgent knowledgeAgent, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeAgent, nameof(knowledgeAgent));

            return DeleteKnowledgeAgent(
                knowledgeAgent?.Name,
                knowledgeAgent?.ETag,
                onlyIfUnchanged,
                cancellationToken);
        }

        /// <summary> Deletes an existing agent. </summary>
        /// <param name="knowledgeAgent"> The definition of the agent to delete. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeAgent.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeAgent"/> is null. </exception>
        public virtual async Task<Response> DeleteKnowledgeAgentAsync(KnowledgeAgent knowledgeAgent, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeAgent, nameof(knowledgeAgent));

            return await DeleteKnowledgeAgentAsync(
                knowledgeAgent?.Name,
                knowledgeAgent?.ETag,
                onlyIfUnchanged,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private Response DeleteKnowledgeAgent(string agentName, ETag? etag, bool onlyIfUnchanged, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteKnowledgeAgent)}");
            scope.Start();
            try
            {
                return KnowledgeAgentsClient.Delete(
                    agentName,
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

        private async Task<Response> DeleteKnowledgeAgentAsync(string agentName, ETag? etag, bool onlyIfUnchanged, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(DeleteKnowledgeAgent)}");
            scope.Start();
            try
            {
                return await KnowledgeAgentsClient.DeleteAsync(
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
        public virtual Response<KnowledgeAgent> GetKnowledgeAgent(string agentName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeAgent)}");
            scope.Start();
            try
            {
                return KnowledgeAgentsClient.Get(agentName, cancellationToken);
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
        public virtual async Task<Response<KnowledgeAgent>> GetKnowledgeAgentAsync(string agentName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeAgent)}");
            scope.Start();
            try
            {
                return await KnowledgeAgentsClient.GetAsync(agentName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Lists all agents available for a search service. </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Pageable{T}"/> from the server containing a list of <see cref="KnowledgeAgent"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Pageable<KnowledgeAgent> GetKnowledgeAgents(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable((continuationToken) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeAgents)}");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListKnowledgeAgentsResult> result = KnowledgeAgentsClient.List(cancellationToken);

                    return Page<KnowledgeAgent>.FromValues(result.Value.KnowledgeAgents, null, result.GetRawResponse());
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
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="KnowledgeAgent"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual AsyncPageable<KnowledgeAgent> GetKnowledgeAgentsAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async (continuationToken) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexClient)}.{nameof(GetKnowledgeAgents)}");
                scope.Start();
                try
                {
                    if (continuationToken != null)
                    {
                        throw new NotSupportedException("A continuation token is unsupported.");
                    }

                    Response<ListKnowledgeAgentsResult> result = await KnowledgeAgentsClient.ListAsync(cancellationToken).ConfigureAwait(false);

                    return Page<KnowledgeAgent>.FromValues(result.Value.KnowledgeAgents, null, result.GetRawResponse());
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
