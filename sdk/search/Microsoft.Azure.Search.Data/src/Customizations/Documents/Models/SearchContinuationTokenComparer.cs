// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models.Internal
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Compares two <see cref="SearchContinuationToken" /> instances for equality.
    /// </summary>
    /// <para>
    /// This class is part of the internal implementation of the Azure Cognitive Search .NET SDK. It is not intended to be used directly by
    /// application code.
    /// </para>
    public class SearchContinuationTokenComparer : IEqualityComparer<SearchContinuationToken>
    {
        /// <summary>
        /// Compares the two given continuation tokens for equality.
        /// </summary>
        /// <param name="first">The first continuation token to compare.</param>
        /// <param name="second">The second continuation token to compare.</param>
        /// <returns><c>true</c> if the two tokens are equal, <c>false</c> otherwise.</returns>
        public bool Equals(SearchContinuationToken first, SearchContinuationToken second) =>
            first?.NextLink == second?.NextLink &&
            NextPageParametersEquals(first?.NextPageParameters, second?.NextPageParameters);

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The object for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public int GetHashCode(SearchContinuationToken obj) => obj?.GetHashCode() ?? 0;

        private static bool NextPageParametersEquals(SearchRequest first, SearchRequest second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if ((first == null) != (second == null))
            {
                return false;
            }

            return
                first.IncludeTotalResultCount == second.IncludeTotalResultCount &&
                ((first.Facets == null && second.Facets == null) || first.Facets.SequenceEqual(second.Facets)) &&
                first.Filter == second.Filter &&
                first.HighlightFields == second.HighlightFields &&
                first.HighlightPostTag == second.HighlightPostTag &&
                first.HighlightPreTag == second.HighlightPreTag &&
                first.MinimumCoverage == second.MinimumCoverage &&
                first.OrderBy == second.OrderBy &&
                first.QueryType == second.QueryType &&
                ((first.ScoringParameters == null && second.ScoringParameters == null) ||
                  first.ScoringParameters.SequenceEqual(second.ScoringParameters)) &&
                first.ScoringProfile == second.ScoringProfile &&
                first.SearchText == second.SearchText &&
                first.SearchFields == second.SearchFields &&
                first.SearchMode == second.SearchMode &&
                first.Select == second.Select &&
                first.Skip == second.Skip &&
                first.Top == second.Top;
        }
    }
}
