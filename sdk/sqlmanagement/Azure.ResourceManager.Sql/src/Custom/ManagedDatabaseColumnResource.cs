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
        // New parameter added to the method, to avoid breaking change, we keep the original method and invoke the new method with default value for the new parameter.
        /// <summary> Enables sensitivity recommendations on a given column (recommendations are enabled by default on all columns). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response EnableRecommendationManagedDatabaseSensitivityLabel(CancellationToken cancellationToken = default)
            => EnableRecommendationManagedDatabaseSensitivityLabel(RecommendedSensitivityLabelSource.Recommended, cancellationToken);

        // New parameter added to the method, to avoid breaking change, we keep the original method and invoke the new method with default value for the new parameter.
        /// <summary> Enables sensitivity recommendations on a given column (recommendations are enabled by default on all columns). </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> EnableRecommendationManagedDatabaseSensitivityLabelAsync(CancellationToken cancellationToken = default)
            => await EnableRecommendationManagedDatabaseSensitivityLabelAsync(RecommendedSensitivityLabelSource.Recommended, cancellationToken).ConfigureAwait(false);

        // New parameter added to the method, to avoid breaking change, we keep the original method and invoke the new method with default value for the new parameter.
        /// <summary> Disables sensitivity recommendations on a given column. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response DisableRecommendationManagedDatabaseSensitivityLabel(CancellationToken cancellationToken = default)
            => DisableRecommendationManagedDatabaseSensitivityLabel(RecommendedSensitivityLabelSource.Recommended, cancellationToken);

        // New parameter added to the method, to avoid breaking change, we keep the original method and invoke the new method with default value for the new parameter.
        /// <summary> Disables sensitivity recommendations on a given column. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> DisableRecommendationManagedDatabaseSensitivityLabelAsync(CancellationToken cancellationToken = default)
            => await DisableRecommendationManagedDatabaseSensitivityLabelAsync(RecommendedSensitivityLabelSource.Recommended, cancellationToken).ConfigureAwait(false);
    }
}
