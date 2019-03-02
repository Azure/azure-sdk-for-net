// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Parameters for filtering, sorting, faceting, paging, and other search
    /// query behaviors.
    /// </summary>
    public partial class SearchParameters
    {
        private static readonly IList<string> Empty = new string[0];

        private IList<string> ScoringParameterStrings => ScoringParameters?.Select(p => p.ToString())?.ToList() ?? Empty;

        /// <summary>
        /// Converts the SearchParameters instance to a URL query string.
        /// </summary>
        /// <returns>A URL query string containing all the search parameters.</returns>
        public override string ToString() => String.Join("&", GetAllOptions());

        internal SearchRequest ToRequest(string searchText) =>
            new SearchRequest()
            {
                Count = IncludeTotalResultCount,
                Facets = Facets ?? Empty,
                Filter = Filter,
                Highlight = HighlightFields.ToCommaSeparatedString(),
                HighlightPostTag = HighlightPostTag,
                HighlightPreTag = HighlightPreTag,
                MinimumCoverage = MinimumCoverage,
                OrderBy = OrderBy.ToCommaSeparatedString(),
                QueryType = QueryType,
                ScoringParameters = ScoringParameterStrings,
                ScoringProfile = ScoringProfile,
                Search = searchText,
                SearchFields = SearchFields.ToCommaSeparatedString(),
                SearchMode = SearchMode,
                Select = Select.ToCommaSeparatedString(),
                Skip = Skip,
                Top = Top
            };

        private IEnumerable<QueryOption> GetAllOptions()
        {
            yield return new QueryOption("$count", IncludeTotalResultCount.ToString().ToLowerInvariant());

            foreach (string facetExpr in Facets ?? Empty)
            {
                yield return new QueryOption("facet", Uri.EscapeDataString(facetExpr));
            }

            if (Filter != null)
            {
                yield return new QueryOption("$filter", Uri.EscapeDataString(Filter));
            }

            if (HighlightFields != null && HighlightFields.Any())
            {
                yield return new QueryOption("highlight", HighlightFields);
            }

            if (HighlightPreTag != null)
            {
                yield return new QueryOption("highlightPreTag", Uri.EscapeDataString(HighlightPreTag));
            }

            if (HighlightPostTag != null)
            {
                yield return new QueryOption("highlightPostTag", Uri.EscapeDataString(HighlightPostTag));
            }

            if (MinimumCoverage != null)
            {
                yield return new QueryOption("minimumCoverage", MinimumCoverage.ToString());
            }

            if (OrderBy != null && OrderBy.Any())
            {
                yield return new QueryOption("$orderby", OrderBy);
            }

            yield return new QueryOption("queryType", (QueryType == Models.QueryType.Simple) ? "simple" : "full");

            foreach (string scoringParameterExpr in ScoringParameterStrings)
            {
                yield return new QueryOption("scoringParameter", scoringParameterExpr);
            }

            if (ScoringProfile != null)
            {
                yield return new QueryOption("scoringProfile", ScoringProfile);
            }

            if (SearchFields != null && SearchFields.Any())
            {
                yield return new QueryOption("searchFields", SearchFields);
            }

            yield return new QueryOption("searchMode", (SearchMode == Models.SearchMode.Any) ? "any" : "all");

            if (Select != null && Select.Any())
            {
                yield return new QueryOption("$select", Select);
            }

            if (Skip != null)
            {
                yield return new QueryOption("$skip", Skip.ToString());
            }

            if (Top != null)
            {
                yield return new QueryOption("$top", Top.ToString());
            }
        }
    }
}
