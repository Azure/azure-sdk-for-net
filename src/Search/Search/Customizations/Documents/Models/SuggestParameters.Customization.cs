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
    public partial class SuggestParameters
    {
        /// <summary>
        /// Converts the SuggestParameters instance to a URL query string.
        /// </summary>
        /// <returns>A URL query string containing all the suggestion parameters.</returns>
        public override string ToString()
        {
            return String.Join("&", GetAllOptions());
        }

        internal SuggestParametersPayload ToPayload(string searchText, string suggesterName)
        {
            return new SuggestParametersPayload()
            {
                Filter = Filter,
                Fuzzy = UseFuzzyMatching,
                HighlightPostTag = HighlightPostTag,
                HighlightPreTag = HighlightPreTag,
                MinimumCoverage = MinimumCoverage,
                OrderBy = OrderBy.ToCommaSeparatedString(),
                Search = searchText,
                SearchFields = SearchFields.ToCommaSeparatedString(),
                Select = Select.Any() ? Select.ToCommaSeparatedString() : "*",
                SuggesterName = suggesterName,
                Top = Top
            };
        }

        private IEnumerable<QueryOption> GetAllOptions()
        {
            if (Filter != null)
            {
                yield return new QueryOption("$filter", Uri.EscapeDataString(Filter));
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

            if (SearchFields.Any())
            {
                yield return new QueryOption("searchFields", SearchFields);
            }

            if (Select.Any())
            {
                yield return new QueryOption("$select", Select);
            }
            else
            {
                yield return new QueryOption("$select", "*");
            }

            if (Top != null)
            {
                yield return new QueryOption("$top", Top.ToString());
            }

            yield return new QueryOption("fuzzy", UseFuzzyMatching.ToString().ToLowerInvariant());
        }
    }
}
