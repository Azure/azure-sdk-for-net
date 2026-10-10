// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.KeyVault.Models
{
    // ManagedHsmSkuName became an extensible enum in API version 2026-05-15, so the generator no
    // longer emits ManagedHsmSkuName.Serialization.cs. ManagedHsmSku.Serialization.cs is still
    // generated against the closed-enum shape and calls these two helpers, so they are restored
    // here until the emitter is fixed. The behavior is identical to the generated versions.
    internal static partial class ManagedHsmSkuNameExtensions
    {
        public static string ToSerialString(this ManagedHsmSkuName value) => value.ToString();

        public static ManagedHsmSkuName ToManagedHsmSkuName(this string value) => new ManagedHsmSkuName(value);
    }
}
