// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class ManagedDatabaseColumnResource
    {
        /// <summary> Enables sensitivity recommendations on a given column (recommendations are enabled by default on all columns). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response EnableRecommendationManagedDatabaseSensitivityLabel(CancellationToken cancellationToken = default)
            => EnableRecommendationManagedDatabaseSensitivityLabel(RecommendedSensitivityLabelSource.Recommended, cancellationToken);

        /// <summary> Enables sensitivity recommendations on a given column (recommendations are enabled by default on all columns). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> EnableRecommendationManagedDatabaseSensitivityLabelAsync(CancellationToken cancellationToken = default)
            => await EnableRecommendationManagedDatabaseSensitivityLabelAsync(RecommendedSensitivityLabelSource.Recommended, cancellationToken).ConfigureAwait(false);

        /// <summary> Disables sensitivity recommendations on a given column. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response DisableRecommendationManagedDatabaseSensitivityLabel(CancellationToken cancellationToken = default)
            => DisableRecommendationManagedDatabaseSensitivityLabel(RecommendedSensitivityLabelSource.Recommended, cancellationToken);

        /// <summary> Disables sensitivity recommendations on a given column. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> DisableRecommendationManagedDatabaseSensitivityLabelAsync(CancellationToken cancellationToken = default)
            => await DisableRecommendationManagedDatabaseSensitivityLabelAsync(RecommendedSensitivityLabelSource.Recommended, cancellationToken).ConfigureAwait(false);
    }
}
