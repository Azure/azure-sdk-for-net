// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    public partial class SearchParameters
    {
        private static readonly IList<string> Empty = new string[0];

        /// <summary>
        /// Gets or sets the list of facet expressions to apply to the search query. Each facet expression contains a
        /// field name, optionally followed by a comma-separated list of name:value pairs.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798927.aspx"/>
        /// </summary>
        [JsonProperty(PropertyName = "facets")]
        public IList<string> Facets { get; set; }

        /// <summary>
        /// Converts the SearchParameters instance to a URL query string.
        /// </summary>
        /// <returns>A URL query string containing all the search parameters.</returns>
        public override string ToString()
        {
            return String.Join("&", this.GetAllOptions());
        }

        internal SearchParametersPayload ToPayload(string searchText)
        {
            return new SearchParametersPayload()
            {
                Count = IncludeTotalResultCount.GetValueOrDefault(),
                Facets = Facets ?? Empty,
                Filter = Filter,
                Highlight = HighlightFields.ToCommaSeparatedString(),
                HighlightPostTag = HighlightPostTag,
                HighlightPreTag = HighlightPreTag,
                MinimumCoverage = MinimumCoverage,
                OrderBy = OrderBy.ToCommaSeparatedString(),
                ScoringParameters = ScoringParameters ?? Empty,
                ScoringProfile = ScoringProfile,
                Search = searchText,
                SearchFields = SearchFields.ToCommaSeparatedString(),
                SearchMode = SearchMode.GetValueOrDefault(),
                Select = Select.ToCommaSeparatedString(),
                Skip = Skip,
                Top = Top
            };
        }

        private IEnumerable<QueryOption> GetAllOptions()
        {
            yield return new QueryOption(
                "$count", 
                this.IncludeTotalResultCount.GetValueOrDefault().ToString().ToLowerInvariant());

            foreach (string facetExpr in this.Facets ?? Empty)
            {
                yield return new QueryOption("facet", Uri.EscapeDataString(facetExpr));
            }

            if (this.Filter != null)
            {
                yield return new QueryOption("$filter", Uri.EscapeDataString(this.Filter));
            }

            if (this.HighlightFields != null && this.HighlightFields.Any())
            {
                yield return new QueryOption("highlight", this.HighlightFields);
            }

            if (this.HighlightPreTag != null)
            {
                yield return new QueryOption("highlightPreTag", Uri.EscapeDataString(this.HighlightPreTag));
            }

            if (this.HighlightPostTag != null)
            {
                yield return new QueryOption("highlightPostTag", Uri.EscapeDataString(this.HighlightPostTag));
            }

            if (this.MinimumCoverage != null)
            {
                yield return new QueryOption("minimumCoverage", this.MinimumCoverage.ToString());
            }

            if (this.OrderBy != null && this.OrderBy.Any())
            {
                yield return new QueryOption("$orderby", this.OrderBy);
            }

            foreach (string scoringParameterExpr in this.ScoringParameters ?? Empty)
            {
                yield return new QueryOption("scoringParameter", scoringParameterExpr);
            }

            if (this.ScoringProfile != null)
            {
                yield return new QueryOption("scoringProfile", this.ScoringProfile);
            }

            if (this.SearchFields != null && this.SearchFields.Any())
            {
                yield return new QueryOption("searchFields", this.SearchFields);
            }

            yield return new QueryOption(
                "searchMode",
                (this.SearchMode.GetValueOrDefault() == Models.SearchMode.Any) ? "any" : "all");

            if (this.Select != null && this.Select.Any())
            {
                yield return new QueryOption("$select", this.Select);
            }

            if (this.Skip != null)
            {
                yield return new QueryOption("$skip", this.Skip.ToString());
            }

            if (this.Top != null)
            {
                yield return new QueryOption("$top", this.Top.ToString());
            }
        }
    }
}
