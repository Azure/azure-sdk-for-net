// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Reason: Backward compatibility — the old SDK (v1.5.1) shipped enum members
    // with underscored names (e.g. Tls_Aes_128_Gcm_Sha256). The new TypeSpec
    // generator produces ALL_CAPS names (e.g. TLSAES128GCMSHA256), which
    // duplicate the underscored names that shipped in v1.5.1. The generator-
    // produced duplicates are suppressed below via [CodeGenSuppress], and the
    // underscored members are re-added to preserve the v1.5.1 public API.
    //
    // Cannot rename type from Afd to FrontDoor — this is an inline union type
    // referenced by original name in generated serialization code and in
    // FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet properties.
    [CodeGenSuppress("TLSAES128GCMSHA256")]
    [CodeGenSuppress("TLSAES256GCMSHA384")]
    public readonly partial struct AfdCustomizedCipherSuiteForTls13
    {
        /// <summary> Gets the Tls_Aes_128_Gcm_Sha256. </summary>
        public static AfdCustomizedCipherSuiteForTls13 Tls_Aes_128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls13(TLSAES128GCMSHA256Value);

        /// <summary> Gets the Tls_Aes_256_Gcm_Sha384. </summary>
        public static AfdCustomizedCipherSuiteForTls13 Tls_Aes_256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls13(TLSAES256GCMSHA384Value);
    }
}
