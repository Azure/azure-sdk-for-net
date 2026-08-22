// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.HardwareSecurityModules.Models
{
    // Workaround for a code generator defect: CloudHsmClusterSkuName is generated as an
    // extensible enum (readonly partial struct), so the generator no longer emits the fixed-enum
    // helpers ToSerialString/ToCloudHsmClusterSkuName. The generated CloudHsmClusterSku
    // serialization still calls them, which breaks the build. These shims reproduce exactly what
    // the generator emits for other extensible enums (Name.ToString() / new T(string)).
    internal static class CloudHsmClusterSkuNameExtensions
    {
        public static string ToSerialString(this CloudHsmClusterSkuName value) => value.ToString();

        public static CloudHsmClusterSkuName ToCloudHsmClusterSkuName(this string value) => new CloudHsmClusterSkuName(value);
    }
}
