// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Qumulo.Models
{
    // Retained for the public compatibility APIs that use StorageSku.
    // The current service API uses the string-valued StorageSkuName property, so this conversion is no longer generated.
    internal static partial class StorageSkuExtensions
    {
        public static string ToSerialString(this StorageSku value) => value switch
        {
            StorageSku.Standard => "Standard",
            StorageSku.Performance => "Performance",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StorageSku value.")
        };

        public static StorageSku ToStorageSku(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Standard"))
            {
                return StorageSku.Standard;
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Performance"))
            {
                return StorageSku.Performance;
            }
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StorageSku value.");
        }
    }
}
