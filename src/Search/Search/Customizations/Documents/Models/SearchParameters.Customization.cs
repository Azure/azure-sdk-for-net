// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;

namespace Microsoft.Azure.Search.Models
{
    public partial class SearchParameters
    {
        private IList<string> _facets = new LazyList<string>();

        /// <summary>
        /// Gets or sets the list of facet expressions to apply to the search query. Each facet expression contains a
        /// field name, optionally followed by a comma-separated list of name:value pairs.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        public IList<string> Facets
        {
            get { return this._facets; }
            set { this._facets = value; }
        }

        /// <summary>
        /// Converts the SearchParameters instance to a URL query string.
        /// </summary>
        /// <returns>A URL query string containing all the search parameters.</returns>
        public override string ToString()
        {
            return String.Join("&", GetAllOptions());
        }

        internal SearchParametersPayload ToPayload(string searchText)
        {
            return new SearchParametersPayload()
            {
                Count = IncludeTotalResultCount,
                Facets = Facets,
                Filter = Filter,
                Highlight = HighlightFields.ToCommaSeparatedString(),
                HighlightPostTag = HighlightPostTag,
                HighlightPreTag = HighlightPreTag,
                MinimumCoverage = MinimumCoverage,
                OrderBy = OrderBy.ToCommaSeparatedString(),
                ScoringParameters = ScoringParameters,
                ScoringProfile = ScoringProfile,
                Search = searchText,
                SearchFields = SearchFields.ToCommaSeparatedString(),
                SearchMode = SearchMode,
                Select = Select.ToCommaSeparatedString(),
                Skip = Skip,
                Top = Top
            };
        }

        private IEnumerable<QueryOption> GetAllOptions()
        {
            yield return new QueryOption("$count", IncludeTotalResultCount.ToString().ToLowerInvariant());

            foreach (string facetExpr in Facets)
            {
                yield return new QueryOption("facet", Uri.EscapeDataString(facetExpr));
            }

            if (Filter != null)
            {
                yield return new QueryOption("$filter", Uri.EscapeDataString(Filter));
            }

            if (HighlightFields.Any())
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

            if (OrderBy.Any())
            {
                yield return new QueryOption("$orderby", OrderBy);
            }

            foreach (string scoringParameterExpr in ScoringParameters)
            {
                yield return new QueryOption("scoringParameter", scoringParameterExpr);
            }

            if (ScoringProfile != null)
            {
                yield return new QueryOption("scoringProfile", ScoringProfile);
            }

            if (SearchFields.Any())
            {
                yield return new QueryOption("searchFields", SearchFields);
            }

            yield return new QueryOption("searchMode", SearchIndexClient.SearchModeToString(SearchMode));

            if (Select.Any())
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
