// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Common;

    internal static class AutocompleteParametersExtensions
    {
        private static readonly IList<string> Empty = new string[0];

        internal static AutocompleteRequest ToRequest(this AutocompleteParameters parameters, string searchText, string suggesterName) =>
            new AutocompleteRequest()
            {
                AutocompleteMode = parameters?.AutocompleteMode,
                Filter = parameters?.Filter,
                HighlightPostTag = parameters?.HighlightPostTag,
                HighlightPreTag = parameters?.HighlightPreTag,
                MinimumCoverage = parameters?.MinimumCoverage,
                SearchFields = parameters?.SearchFields.ToCommaSeparatedString(),
                SearchText = searchText,
                SuggesterName = suggesterName,
                Top = parameters?.Top,
                UseFuzzyMatching = parameters?.UseFuzzyMatching
            };
    }
}
