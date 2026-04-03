// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Backward compatibility: old API used UriSigningKey instead of UrlSigningKey
    public readonly partial struct c
    {
        [CodeGenMember("UrlSigningKey")]
        public static SecretType UriSigningKey { get; } = new SecretType(UrlSigningKeyValue);
    }
}
