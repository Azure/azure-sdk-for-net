// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
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
    }
}
