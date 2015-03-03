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

namespace Microsoft.Azure.Search.Models
{
    public partial class SearchParameters
    {
        /// <summary>
        /// Converts the SearchParameters instance to a URL query string.
        /// </summary>
        /// <returns>A URL query string containing all the search parameters.</returns>
        public override string ToString()
        {
            return String.Join("&", GetAllOptions());
        }

        private IEnumerable<QueryOption> GetAllOptions()
        {
            yield return new QueryOption("$count", IncludeTotalResultCount.ToString().ToLowerInvariant());

            foreach (string facetExpr in Facets)
            {
                yield return new QueryOption("facet", facetExpr);
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
