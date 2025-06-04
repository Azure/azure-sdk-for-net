// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Search.Models
{
    internal static partial class SearchSkuNameExtensions
    {
        public static string ToSerialString(this SearchSkuName value) => value switch
        {
            SearchSkuName.Free => "free",
            SearchSkuName.Basic => "basic",
            SearchSkuName.Standard => "standard",
            SearchSkuName.Standard2 => "standard2",
            SearchSkuName.Standard3 => "standard3",
            SearchSkuName.StorageOptimizedL1 => "storage_optimized_l1",
            SearchSkuName.StorageOptimizedL2 => "storage_optimized_l2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SearchSkuName value.")
        };

        public static SearchSkuName ToSearchSkuName(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "free")) return SearchSkuName.Free;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "basic")) return SearchSkuName.Basic;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "standard")) return SearchSkuName.Standard;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "standard2")) return SearchSkuName.Standard2;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "standard3")) return SearchSkuName.Standard3;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "storage_optimized_l1")) return SearchSkuName.StorageOptimizedL1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "storage_optimized_l2")) return SearchSkuName.StorageOptimizedL2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SearchSkuName value.");
        }
    }
}
