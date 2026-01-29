// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes.Models;

// TODO: Fix this in generator
// namespace Azure.Search.Documents.Indexes
namespace Azure.Azure.Search.Documents.Documents.Indexes
{
    /// <summary>
    /// Customizations for the generated <see cref="SearchIndexerClient"/> - Skillset operations.
    /// </summary>
    public partial class SearchIndexerClient
    {
        #region Skillset operations - Convenience overloads

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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<SearchIndexerSkillset> CreateOrUpdateSkillset(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken) => CreateOrUpdateSkillset(
                skillset,
                onlyIfUnchanged,
                ignoreCacheResetRequirements: null,
                disableCacheReprocessingChangeDetection: null,
                cancellationToken);

        /// <summary>
        /// Creates a new skillset or updates an existing skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="disableCacheReprocessingChangeDetection">Disables cache reprocessing change detection.</param>
        /// <param name="ignoreCacheResetRequirements">Ignores cache reset requirements.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerSkillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<SearchIndexerSkillset> CreateOrUpdateSkillset(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged,
            bool disableCacheReprocessingChangeDetection,
            bool ignoreCacheResetRequirements,
            CancellationToken cancellationToken) => CreateOrUpdateSkillset(
                skillset,
                onlyIfUnchanged,
                ignoreCacheResetRequirements,
                disableCacheReprocessingChangeDetection,
                cancellationToken);

        /// <summary>
        /// Creates a new skillset or updates an existing skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="ignoreCacheResetRequirements">Ignores cache reset requirements.</param>
        /// <param name="disableCacheReprocessingChangeDetection">Disables cache reprocessing change detection.</param>
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
            bool? ignoreCacheResetRequirements = null,
            bool? disableCacheReprocessingChangeDetection = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(skillset, nameof(skillset));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = skillset?.ETag } : null;
            return CreateOrUpdateSkillset(skillset?.Name, skillset, matchConditions, ignoreCacheResetRequirements, disableCacheReprocessingChangeDetection, cancellationToken);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<SearchIndexerSkillset>> CreateOrUpdateSkillsetAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged,
            CancellationToken cancellationToken) => await CreateOrUpdateSkillsetAsync(
                skillset,
                onlyIfUnchanged,
                ignoreCacheResetRequirements: null,
                disableCacheReprocessingChangeDetection: null,
                cancellationToken).
                ConfigureAwait(false);

        /// <summary>
        /// Creates a new skillset or updates an existing skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="disableCacheReprocessingChangeDetection">Disables cache reprocessing change detection.</param>
        /// <param name="ignoreCacheResetRequirements">Ignores cache reset requirements.</param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>
        /// The <see cref="Response{T}"/> from the server containing the <see cref="SearchIndexerSkillset"/> that was created.
        /// This may differ slightly from what was passed in since the service may return back properties set to their default values.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="skillset"/> is null.</exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Search service.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<SearchIndexerSkillset>> CreateOrUpdateSkillsetAsync(
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
            SearchIndexerSkillset skillset,
            bool onlyIfUnchanged,
            bool disableCacheReprocessingChangeDetection,
            bool ignoreCacheResetRequirements,
            CancellationToken cancellationToken) => await CreateOrUpdateSkillsetAsync(
                skillset,
                onlyIfUnchanged,
                ignoreCacheResetRequirements,
                disableCacheReprocessingChangeDetection,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a new skillset or updates an existing skillset.
        /// </summary>
        /// <param name="skillset">Required. The <see cref="SearchIndexerSkillset"/> to create or update.</param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="SearchIndexerSkillset.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="ignoreCacheResetRequirements">Ignores cache reset requirements.</param>
        /// <param name="disableCacheReprocessingChangeDetection">Disables cache reprocessing change detection.</param>
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
            bool? ignoreCacheResetRequirements = null,
            bool? disableCacheReprocessingChangeDetection = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(skillset, nameof(skillset));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = skillset?.ETag } : null;
            return await CreateOrUpdateSkillsetAsync(skillset?.Name, skillset, matchConditions, ignoreCacheResetRequirements, disableCacheReprocessingChangeDetection, cancellationToken).ConfigureAwait(false);
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
            Argument.AssertNotNull(skillsetName, nameof(skillsetName));
            return DeleteSkillset(skillsetName, matchConditions: null, cancellationToken);
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
            Argument.AssertNotNull(skillsetName, nameof(skillsetName));
            return await DeleteSkillsetAsync(skillsetName, matchConditions: null, cancellationToken).ConfigureAwait(false);
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
            Argument.AssertNotNull(skillset, nameof(skillset));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = skillset?.ETag } : null;
            return DeleteSkillset(skillset?.Name, matchConditions, cancellationToken);
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
            Argument.AssertNotNull(skillset, nameof(skillset));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = skillset?.ETag } : null;
            return await DeleteSkillsetAsync(skillset?.Name, matchConditions, cancellationToken).ConfigureAwait(false);
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
            Response<ListSkillsetsResult> result = GetSkillsets(new[] { Constants.All }, cancellationToken);
            return Response.FromValue((IReadOnlyList<SearchIndexerSkillset>)result.Value.Skillsets, result.GetRawResponse());
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
            Response<ListSkillsetsResult> result = await GetSkillsetsAsync(new[] { Constants.All }, cancellationToken).ConfigureAwait(false);
            return Response.FromValue((IReadOnlyList<SearchIndexerSkillset>)result.Value.Skillsets, result.GetRawResponse());
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
            Response<ListSkillsetsResult> result = GetSkillsets(new[] { Constants.NameKey }, cancellationToken);
            IReadOnlyList<string> names = result.Value.Skillsets.Select(value => value.Name).ToArray();
            return Response.FromValue(names, result.GetRawResponse());
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
            Response<ListSkillsetsResult> result = await GetSkillsetsAsync(new[] { Constants.NameKey }, cancellationToken).ConfigureAwait(false);
            IReadOnlyList<string> names = result.Value.Skillsets.Select(value => value.Name).ToArray();
            return Response.FromValue(names, result.GetRawResponse());
        }

        #endregion
    }
}
