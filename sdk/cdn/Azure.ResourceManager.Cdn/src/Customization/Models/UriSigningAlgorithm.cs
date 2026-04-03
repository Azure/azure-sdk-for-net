// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Backward compatibility: old API used Sha256 instead of SHA256
    public readonly partial struct UriSigningAlgorithm
    {
        [CodeGenMember("SHA256")]
        public static UriSigningAlgorithm Sha256 { get; } = new UriSigningAlgorithm(SHA256Value);
    }
}
