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
    public partial class SqlDatabaseColumnResource
    {
        /// <summary> Enables sensitivity recommendations on a given column. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response EnableRecommendationSensitivityLabel(CancellationToken cancellationToken = default)
            => EnableRecommendation(RecommendedSensitivityLabelSource.Recommended, cancellationToken);

        /// <summary> Enables sensitivity recommendations on a given column. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> EnableRecommendationSensitivityLabelAsync(CancellationToken cancellationToken = default)
            => await EnableRecommendationAsync(RecommendedSensitivityLabelSource.Recommended, cancellationToken).ConfigureAwait(false);

        /// <summary> Disables sensitivity recommendations on a given column. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response DisableRecommendationSensitivityLabel(CancellationToken cancellationToken = default)
            => DisableRecommendation(RecommendedSensitivityLabelSource.Recommended, cancellationToken);

        /// <summary> Disables sensitivity recommendations on a given column. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> DisableRecommendationSensitivityLabelAsync(CancellationToken cancellationToken = default)
            => await DisableRecommendationAsync(RecommendedSensitivityLabelSource.Recommended, cancellationToken).ConfigureAwait(false);
    }
}
