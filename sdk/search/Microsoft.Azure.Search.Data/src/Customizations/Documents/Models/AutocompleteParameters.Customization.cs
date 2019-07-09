// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Search.Common;

namespace Microsoft.Azure.Search.Models
{
    public partial class AutocompleteParameters
    {
        internal AutocompleteRequest ToRequest(string searchText, string suggesterName) =>
            new AutocompleteRequest()
            {
                AutocompleteMode = AutocompleteMode,
                Filter = Filter,
                HighlightPostTag = HighlightPostTag,
                HighlightPreTag = HighlightPreTag,
                MinimumCoverage = MinimumCoverage,
                SearchFields = SearchFields.ToCommaSeparatedString(),
                SearchText = searchText,
                SuggesterName = suggesterName,
                Top = Top,
                UseFuzzyMatching = UseFuzzyMatching
            };
    }
}
