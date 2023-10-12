// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage and query
    /// indexes and documents, as well as manage other resources, on a Search
    /// Service.
    /// </summary>
    public partial class SearchIndexerClient
    {
        private SkillsetsRestClient _skillsetsClient;

        /// <summary>
        /// Gets the generated <see cref="SkillsetsRestClient"/> to make requests.
        /// </summary>
        private SkillsetsRestClient SkillsetsClient => LazyInitializer.EnsureInitialized(ref _skillsetsClient, () => new SkillsetsRestClient(
            _clientDiagnostics,
            _pipeline,
            Endpoint.AbsoluteUri,
            null,
            _version.ToVersionString())
        );

        /// <summary>
        /// Creates a new skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerSkillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerSkillset> CreateSkillset(
            SearchIndexerSkillset skillset,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateSkillset)}");
            scope.Start();
            try
            {
                return SkillsetsClient.Create(
                    skillset,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerSkillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerSkillset>> CreateSkillsetAsync(
            SearchIndexerSkillset skillset,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateSkillset)}");
            scope.Start();
            try
            {
                return await SkillsetsClient.CreateAsync(
                    skillset,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new skillset or updates an existing skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerSkillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerSkillset> CreateOrUpdateSkillset(
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(skillset, nameof(skillset));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateOrUpdateSkillset)}");
            scope.Start();
            try
            {
                return SkillsetsClient.CreateOrUpdate(
                    skillset?.Name,
                    skillset,
                    onlyIfUnchanged ? skillset?.ETag?.ToString() : null,
                    null,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new skillset or updates an existing skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerSkillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerSkillset>> CreateOrUpdateSkillsetAsync(
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(skillset, nameof(skillset));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(CreateOrUpdateSkillset)}");
            scope.Start();
            try
            {
                return await SkillsetsClient.CreateOrUpdateAsync(
                    skillset?.Name,
                    skillset,
                    onlyIfUnchanged ? skillset?.ETag?.ToString() : null,
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

        /// <summary>
        /// Deletes a skillset.
        /// </summary>
        /// <param name="skillsetName">The name of the <see cref="SearchIndexerSkillset"/> to delete.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteSkillset(
            string skillsetName,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(skillsetName, nameof(skillsetName));

            return DeleteSkillset(
                skillsetName,
                null,
                false,
                cancellationToken);
        }

        /// <summary>
        /// Deletes a skillset.
        /// </summary>
        /// <param name="skillsetName">The name of the <see cref="SearchIndexerSkillset"/> to delete.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteSkillsetAsync(
            string skillsetName,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(skillsetName, nameof(skillsetName));

            return await DeleteSkillsetAsync(
                skillsetName,
                null,
                false,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes a skillset.
        /// </summary>
        /// <param name="skillset">The <see cref="SearchIndexerSkillset"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response DeleteSkillset(
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(skillset, nameof(skillset));

            return DeleteSkillset(
                skillset?.Name,
                skillset?.ETag,
                onlyIfUnchanged,
                cancellationToken);
        }

        /// <summary>
        /// Deletes a skillset.
        /// </summary>
        /// <param name="skillset">The <see cref="SearchIndexerSkillset"/> to delete.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response> DeleteSkillsetAsync(
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged = false,
            CancellationToken cancellationToken = default)
        {
            // The REST client uses a different parameter name that would be confusing to reference.
            Argument.AssertNotNull(skillset, nameof(skillset));

            return await DeleteSkillsetAsync(
                skillset?.Name,
                skillset?.ETag,
                onlyIfUnchanged,
                cancellationToken)
                .ConfigureAwait(false);
        }

        private Response DeleteSkillset(
            string skillsetName,
            ETag? etag,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(DeleteSkillset)}");
            scope.Start();
            try
            {
                return SkillsetsClient.Delete(
                    skillsetName,
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

        private async Task<Response> DeleteSkillsetAsync(
            string skillsetName,
            ETag? etag,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(DeleteSkillset)}");
            scope.Start();
            try
            {
                return await SkillsetsClient.DeleteAsync(
                    skillsetName,
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

        /// <summary>
        /// Gets a specific <see cref="SearchIndexerSkillset"/>.
        /// </summary>
        /// <param name="skillsetName">Required. The name of the <see cref="SearchIndexerSkillset"/> to get.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerSkillset"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<SearchIndexerSkillset> GetSkillset(
            string skillsetName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetSkillset)}");
            scope.Start();
            try
            {
                return SkillsetsClient.Get(
                    skillsetName,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a specific <see cref="SearchIndexerSkillset"/>.
        /// </summary>
        /// <param name="skillsetName">Required. The name of the <see cref="SearchIndexerSkillset"/> to get.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing the requested <see cref="SearchIndexerSkillset"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillsetName"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<SearchIndexerSkillset>> GetSkillsetAsync(
            string skillsetName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetSkillset)}");
            scope.Start();
            try
            {
                return await SkillsetsClient.GetAsync(
                    skillsetName,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all skillsets.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerSkillset"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<SearchIndexerSkillset>> GetSkillsets(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetSkillsets)}");
            scope.Start();
            try
            {
                Response<ListSkillsetsResult> result = SkillsetsClient.List(
                    Constants.All,
                    cancellationToken);

                return Response.FromValue(result.Value.Skillsets, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all skillsets.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerSkillset"/>.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<SearchIndexerSkillset>>> GetSkillsetsAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetSkillsets)}");
            scope.Start();
            try
            {
                Response<ListSkillsetsResult> result = await SkillsetsClient.ListAsync(
                    Constants.All,
                    cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(result.Value.Skillsets, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all skillset names.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerSkillset"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual Response<IReadOnlyList<string>> GetSkillsetNames(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetSkillsetNames)}");
            scope.Start();
            try
            {
                Response<ListSkillsetsResult> result = SkillsetsClient.List(
                    Constants.NameKey,
                    cancellationToken);

                IReadOnlyList<string> names = result.Value.Skillsets.Select(value => value.Name).ToArray();
                return Response.FromValue(names, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all skillset names.
        /// </summary>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response{T}"/> from the server containing a list of <see cref="SearchIndexerSkillset"/> names.</returns>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetSkillsetNamesAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SearchIndexerClient)}.{nameof(GetSkillsetNames)}");
            scope.Start();
            try
            {
                Response<ListSkillsetsResult> result = await SkillsetsClient.ListAsync(
                    Constants.NameKey,
                    cancellationToken)
                    .ConfigureAwait(false);

                IReadOnlyList<string> names = result.Value.Skillsets.Select(value => value.Name).ToArray();
                return Response.FromValue(names, result.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
