// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Parameters for filtering, sorting, fuzzy matching, and other
    /// suggestions query behaviors.
    /// </summary>
    public partial class SuggestParameters
    {
        internal SuggestParameters EnsureSelect()
        {
            IList<string> newSelect = EnsureSelect(Select);

            if (newSelect == Select)
            {
                return this;
            }

            var clone = (SuggestParameters)MemberwiseClone();
            clone.Select = newSelect;
            return clone;
        }

        internal SuggestRequest ToRequest(string searchText, string suggesterName) =>
            new SuggestRequest()
            {
                Filter = Filter,
                Fuzzy = UseFuzzyMatching,
                HighlightPostTag = HighlightPostTag,
                HighlightPreTag = HighlightPreTag,
                MinimumCoverage = MinimumCoverage,
                OrderBy = OrderBy.ToCommaSeparatedString(),
                Search = searchText,
                SearchFields = SearchFields.ToCommaSeparatedString(),
                Select = EnsureSelect(Select).ToCommaSeparatedString(),
                SuggesterName = suggesterName,
                Top = Top
            };

        private static IList<string> EnsureSelect(IList<string> select) => (select != null && select.Any()) ? select : new[] { "*" };
    }
}
