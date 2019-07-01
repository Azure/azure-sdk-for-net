// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public partial class SearchParameters
    {
        private static readonly IList<string> Empty = new string[0];

        internal SearchRequest ToRequest(string searchText) =>
            new SearchRequest()
            {
                IncludeTotalResultCount = IncludeTotalResultCount,
                Facets = Facets ?? Empty,
                Filter = Filter,
                HighlightFields = HighlightFields.ToCommaSeparatedString(),
                HighlightPostTag = HighlightPostTag,
                HighlightPreTag = HighlightPreTag,
                MinimumCoverage = MinimumCoverage,
                OrderBy = OrderBy.ToCommaSeparatedString(),
                QueryType = QueryType,
                ScoringParameters = ScoringParameters?.Select(p => p.ToString())?.ToList() ?? Empty,
                ScoringProfile = ScoringProfile,
                SearchText = searchText,
                SearchFields = SearchFields.ToCommaSeparatedString(),
                SearchMode = SearchMode,
                Select = Select.ToCommaSeparatedString(),
                Skip = Skip,
                Top = Top
            };
    }
}
