// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

namespace Azure.ResourceManager.ApiManagement.Models
{
    // The old SDK used a fixed enum GatewayRegenerateKeyType for the gateway key regeneration
    // request. The generated code uses this type (from @@clientName(KeyType, "TokenGenerationUsedKeyType"))
    // but the gateway-specific usage needs a separate enum with custom serialization helpers.
    // Not spec-fixable: the same TypeSpec union (KeyType) is renamed differently for different
    // usage contexts; this enum serves the gateway-specific context.

    /// <summary> The Key being regenerated. </summary>
    public enum GatewayRegenerateKeyType
    {
        /// <summary> Primary. </summary>
        Primary = 0,

        /// <summary> Secondary. </summary>
        Secondary = 1
    }

    internal static class ApiManagementCompatibilityTypeExtensions
    {
        internal static GatewayRegenerateKeyType ToGatewayRegenerateKeyType(this string value)
            => value?.ToLowerInvariant() switch
            {
                "primary" => GatewayRegenerateKeyType.Primary,
                "secondary" => GatewayRegenerateKeyType.Secondary,
                _ => default
            };

        internal static string ToSerialString(this GatewayRegenerateKeyType value)
            => value switch
            {
                GatewayRegenerateKeyType.Primary => "primary",
                GatewayRegenerateKeyType.Secondary => "secondary",
                _ => null
            };
    }
}
