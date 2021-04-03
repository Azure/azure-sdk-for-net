// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// TODO: Remove this custom serializer when enabling Semantic search
    /// </summary>
    internal static partial class SearchQueryTypeExtensions
    {
        public static string ToSerialString(this SearchQueryType value) => value switch
        {
            SearchQueryType.Simple => "simple",
            SearchQueryType.Full => "full",
            // SearchQueryType.Semantic => "semantic",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, $"Unknown {nameof(SearchQueryType)} value.")
        };

        public static SearchQueryType ToSearchQueryType(this string value)
        {
            if (string.Equals(value, "simple", StringComparison.InvariantCultureIgnoreCase))
                return SearchQueryType.Simple;
            if (string.Equals(value, "full", StringComparison.InvariantCultureIgnoreCase))
                return SearchQueryType.Full;
            //if (string.Equals(value, "semantic", StringComparison.InvariantCultureIgnoreCase))
            //    return SearchQueryType.Semantic;
            throw new ArgumentOutOfRangeException(nameof(value), value, $"Unknown {nameof(SearchQueryType)} value.");
        }
    }
}
