// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// Extension methods for <see cref="FeatureFlagClient"/> and its related models.
    /// </summary>
    public static class FeatureFlagClientExtensions
    {
        /// <summary>
        /// Enumerate the values a <see cref="Page{T}"/> at a time, if they satisfy the match conditions for each page.
        /// This can be used to efficiently check for changes to a cache of pages of feature flags. This may make multiple
        /// service requests.
        /// </summary>
        /// <param name="pageable">The pageable object.</param>
        /// <param name="conditions">The match conditions. Conditions are applied to pages one by one in enumeration order.</param>
        /// <param name="continuationToken"> A continuation token indicating where to resume paging or null to begin paging from the beginning.</param>
        /// <param name="pageSizeHint">
        /// The number of items per <see cref="Page{T}"/> that should be requested (from service operations that support it). It's not guaranteed
        /// that the value will be respected.
        /// </param>
        /// <returns>An async sequence of <see cref="Page{T}"/>s.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the pageable used does not support this operation. Only objects returned by the
        /// <see cref="FeatureFlagClient.GetFeatureFlagsAsync(FeatureFlagSelector, CancellationToken)"/>
        /// support it.
        /// </exception>
        public static IAsyncEnumerable<Page<FeatureFlag>> AsPages(this AsyncPageable<FeatureFlag> pageable, IEnumerable<MatchConditions> conditions, string continuationToken = null, int? pageSizeHint = null)
        {
            Argument.AssertNotNull(conditions, nameof(conditions));

            var conditionalPageable = pageable as AsyncConditionalPageable<FeatureFlag>;

            if (conditionalPageable is null)
            {
                throw new InvalidOperationException("Operation not supported by this pageable object.");
            }

            return conditionalPageable.AsPages(conditions, continuationToken, pageSizeHint);
        }

        /// <summary>
        /// Enumerate the values a <see cref="Page{T}"/> at a time, if they satisfy the match conditions for each page.
        /// This can be used to efficiently check for changes to a cache of pages of feature flags. This may make multiple
        /// service requests.
        /// </summary>
        /// <param name="pageable">The pageable object.</param>
        /// <param name="conditions">The match conditions. Conditions are applied to pages one by one in enumeration order.</param>
        /// <param name="continuationToken"> A continuation token indicating where to resume paging or null to begin paging from the beginning.</param>
        /// <param name="pageSizeHint">
        /// The number of items per <see cref="Page{T}"/> that should be requested (from service operations that support it). It's not guaranteed
        /// that the value will be respected.
        /// </param>
        /// <returns>A sequence of <see cref="Page{T}"/>s.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the pageable used does not support this operation. Only objects returned by the
        /// <see cref="FeatureFlagClient.GetFeatureFlags(FeatureFlagSelector, CancellationToken)"/>
        /// support it.
        /// </exception>
        public static IEnumerable<Page<FeatureFlag>> AsPages(this Pageable<FeatureFlag> pageable, IEnumerable<MatchConditions> conditions, string continuationToken = null, int? pageSizeHint = null)
        {
            Argument.AssertNotNull(conditions, nameof(conditions));

            var conditionalPageable = pageable as ConditionalPageable<FeatureFlag>;

            if (conditionalPageable is null)
            {
                throw new InvalidOperationException("Operation not supported by this pageable object.");
            }

            return conditionalPageable.AsPages(conditions, continuationToken, pageSizeHint);
        }
    }
}
