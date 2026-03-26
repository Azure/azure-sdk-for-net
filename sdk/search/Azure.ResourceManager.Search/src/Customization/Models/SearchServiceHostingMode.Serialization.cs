// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

// NOTE: The following customization is intentionally retained for backward compatibility.
// The first character of the serialized string is lowercase to align with the REST API contract.
namespace Azure.ResourceManager.Search.Models
{
    internal static partial class SearchServiceHostingModeExtensions
    {
        /// <param name="value"> The value to serialize. </param>
        public static string ToSerialString(this SearchServiceHostingMode value) => value switch
        {
            SearchServiceHostingMode.Default => "default",
            SearchServiceHostingMode.HighDensity => "highDensity",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SearchServiceHostingMode value.")
        };

        /// <param name="value"> The value to deserialize. </param>
        public static SearchServiceHostingMode ToSearchServiceHostingMode(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "default"))
            {
                return SearchServiceHostingMode.Default;
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "highDensity"))
            {
                return SearchServiceHostingMode.HighDensity;
            }
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SearchServiceHostingMode value.");
        }
    }
}
