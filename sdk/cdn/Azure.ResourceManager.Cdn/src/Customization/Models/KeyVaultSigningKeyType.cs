// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Backward compatibility: old API used KeyVaultSigningKey instead of KeyVaultSigningKeyParameters
    public readonly partial struct KeyVaultSigningKeyType
    {
        [CodeGenMember("KeyVaultSigningKeyParameters")]
        public static KeyVaultSigningKeyType KeyVaultSigningKey { get; } = new KeyVaultSigningKeyType(KeyVaultSigningKeyParametersValue);
    }
}
