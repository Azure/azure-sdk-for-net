// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Common;

    /// <summary>
    /// Parameters for filtering, sorting, fuzzy matching, and other
    /// suggestions query behaviors.
    /// </summary>
    public partial class SuggestParameters
    {
        private static readonly IList<string> Empty = new string[0];

        public IList<string> Select { get; set; }

        internal SuggestParametersPayload ToPayload(string searchText, string suggesterName) =>
            new SuggestParametersPayload()
            {
                Filter = Filter,
                Fuzzy = UseFuzzyMatching,
                HighlightPostTag = HighlightPostTag,
                HighlightPreTag = HighlightPreTag,
                MinimumCoverage = MinimumCoverage,
                OrderBy = OrderBy.ToCommaSeparatedString(),
                Search = searchText,
                SearchFields = SearchFields.ToCommaSeparatedString(),
                Select = SelectStr,
                SuggesterName = suggesterName,
                Top = Top
            };
    }
}
