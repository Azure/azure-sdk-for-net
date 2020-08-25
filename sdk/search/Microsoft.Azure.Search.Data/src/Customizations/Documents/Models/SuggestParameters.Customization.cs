// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Search.Common;

namespace Microsoft.Azure.Search.Models
{
    public partial class SuggestParameters
    {
        /// <summary>
        /// Returns this instance if it has a non-null <see cref="SuggestParameters.Select" /> property,
        /// or a new instance with Select set to "*" otherwise.
        /// </summary>
        /// <returns>A <see cref="SuggestParameters" /> instance that has a
        /// non-null <see cref="SuggestParameters.Select" /> property</returns>
        public SuggestParameters EnsureSelect()
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
                UseFuzzyMatching = UseFuzzyMatching,
                HighlightPostTag = HighlightPostTag,
                HighlightPreTag = HighlightPreTag,
                MinimumCoverage = MinimumCoverage,
                OrderBy = OrderBy.ToCommaSeparatedString(),
                SearchText = searchText,
                SearchFields = SearchFields.ToCommaSeparatedString(),
                Select = EnsureSelect(Select).ToCommaSeparatedString(),
                SuggesterName = suggesterName,
                Top = Top
            };

        private static IList<string> EnsureSelect(IList<string> select) =>
            (select != null && select.Any()) ? select : new[] { "*" };
    }
}
