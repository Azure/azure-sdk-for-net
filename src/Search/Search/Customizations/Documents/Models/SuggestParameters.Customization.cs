// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class SuggestParameters
    {
        private static readonly IList<string> Empty = new string[0];

        /// <summary>
        /// Converts the SuggestParameters instance to a URL query string.
        /// </summary>
        /// <returns>A URL query string containing all the suggestion parameters.</returns>
        public override string ToString()
        {
            return String.Join("&", this.GetAllOptions());
        }

        internal SuggestParametersPayload ToPayload(string searchText, string suggesterName)
        {
            return new SuggestParametersPayload()
            {
                Filter = this.Filter,
                Fuzzy = this.UseFuzzyMatching.GetValueOrDefault(),
                HighlightPostTag = this.HighlightPostTag,
                HighlightPreTag = this.HighlightPreTag,
                MinimumCoverage = this.MinimumCoverage,
                OrderBy = this.OrderBy.ToCommaSeparatedString(),
                Search = searchText,
                SearchFields = this.SearchFields.ToCommaSeparatedString(),
                Select = (this.Select != null && this.Select.Any()) ? this.Select.ToCommaSeparatedString() : "*",
                SuggesterName = suggesterName,
                Top = this.Top
            };
        }

        private IEnumerable<QueryOption> GetAllOptions()
        {
            if (this.Filter != null)
            {
                yield return new QueryOption("$filter", Uri.EscapeDataString(this.Filter));
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

            if (this.SearchFields != null && this.SearchFields.Any())
            {
                yield return new QueryOption("searchFields", this.SearchFields);
            }

            if (this.Select != null && this.Select.Any())
            {
                yield return new QueryOption("$select", this.Select);
            }
            else
            {
                yield return new QueryOption("$select", "*");
            }

            if (this.Top != null)
            {
                yield return new QueryOption("$top", this.Top.ToString());
            }

            yield return new QueryOption(
                "fuzzy", 
                this.UseFuzzyMatching.GetValueOrDefault().ToString().ToLowerInvariant());
        }
    }
}
