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

        // Set default values for non-nullable types
        partial void CustomInit()
        {
            IncludeTotalResultCount = false;
            QueryType = QueryType.Simple;
            SearchMode = SearchMode.Any;
            ScoringParameters = new List<ScoringParameter>();
        }

        private IList<ScoringParameter> _scoringParameters;

        public IList<ScoringParameter> ScoringParameters { get { return _scoringParameters; } set { _scoringParameters = value; ScoringParameterStrings = _scoringParameters.Any() ? _scoringParameters.Select(p => p.ToString()).ToList() : null; } }

        internal SearchParametersPayload ToPayload(string searchText) =>
            new SearchParametersPayload()
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

        internal static SearchParameters FromDictionary(Dictionary<string, List<string>> parameters)
        {
            List<string> values = new List<string>();

            int? Top = null;
            if (parameters.TryGetValue("$top", out values))
            {
                Top = Convert.ToInt32(values.First());
            }

            int? Skip = null;
            if (parameters.TryGetValue("$skip", out values))
            {
                Skip = Convert.ToInt32(values.First());
            }

            QueryType? queryType = null;
            if (parameters.TryGetValue("queryType", out values))
            {
                queryType = values.First().ParseQueryType();
            }

            SearchMode? searchMode = null;
            if (parameters.TryGetValue("searchMode", out values))
            {
                searchMode = values.First().ParseSearchMode();
            }

            return new SearchParameters()
            {
                QueryType = queryType ?? queryType.Value,
                SearchMode = searchMode ?? searchMode.Value,
                HighlightPreTag = parameters.TryGetValue("highlightPreTag", out values) ? values.First() : null,
                HighlightPostTag = parameters.TryGetValue("highlightPostTag", out values) ? values.First() : null,
                SearchFields = parameters.TryGetValue("searchFields", out values) ? values : null,
                IncludeTotalResultCount = parameters.TryGetValue("$count", out values) ? Convert.ToBoolean(values.First()) : false,
                Top = Top,
                Skip = Skip,
                Select = parameters.TryGetValue("$select", out values) ? values : null,
                OrderBy = parameters.TryGetValue("$orderby", out values) ? values : null,
                Filter = parameters.TryGetValue("$filter", out values) ? values.First() : null,
                ScoringProfile = parameters.TryGetValue("scoringProfile", out values) ? values.First() : null,
                ScoringParameterStrings = parameters.TryGetValue("scoringParameter", out values) ? values : null
            };
        }

    }
}
