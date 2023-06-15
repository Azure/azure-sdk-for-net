// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.AppService.Models
{
    internal static partial class AppServiceStorageTypeExtensions
    {
        public static string ToSerialString(this AppServiceStorageType value) => value switch
        {
            AppServiceStorageType.AzureFiles => "AzureFiles",
            AppServiceStorageType.AzureBlob => "AzureBlob",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AppServiceStorageType value.")
        };

        public static AppServiceStorageType ToAppServiceStorageType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AzureFiles")) return AppServiceStorageType.AzureFiles;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AzureBlob")) return AppServiceStorageType.AzureBlob;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AppServiceStorageType value.");
        }
    }
}
