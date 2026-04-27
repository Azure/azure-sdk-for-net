// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Reason: Backward compatibility — the old SDK (v1.5.1) shipped enum members
    // with underscored names (e.g. Ecdhe_Rsa_Aes128_Gcm_Sha256). The new TypeSpec
    // generator produces ALL_CAPS names (e.g. ECDHERSAAES128GCMSHA256), which
    // duplicate the underscored names that shipped in v1.5.1. The generator-
    // produced duplicates are suppressed below via [CodeGenSuppress], and the
    // underscored members are re-added to preserve the v1.5.1 public API.
    //
    // Cannot rename type from Afd to FrontDoor — this is an inline union type
    // referenced by original name in generated serialization code and in
    // FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet properties.
    [CodeGenSuppress("ECDHERSAAES128GCMSHA256")]
    [CodeGenSuppress("ECDHERSAAES256GCMSHA384")]
    [CodeGenSuppress("DHERSAAES256GCMSHA384")]
    [CodeGenSuppress("DHERSAAES128GCMSHA256")]
    [CodeGenSuppress("ECDHERSAAES128SHA256")]
    [CodeGenSuppress("ECDHERSAAES256SHA384")]
    public readonly partial struct AfdCustomizedCipherSuiteForTls12
    {
        /// <summary> Gets the Ecdhe_Rsa_Aes128_Gcm_Sha256. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(ECDHERSAAES128GCMSHA256Value);

        /// <summary> Gets the Ecdhe_Rsa_Aes256_Gcm_Sha384. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(ECDHERSAAES256GCMSHA384Value);

        /// <summary> Gets the Dhe_Rsa_Aes256_Gcm_Sha384. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Dhe_Rsa_Aes256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(DHERSAAES256GCMSHA384Value);

        /// <summary> Gets the Dhe_Rsa_Aes128_Gcm_Sha256. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Dhe_Rsa_Aes128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(DHERSAAES128GCMSHA256Value);

        /// <summary> Gets the Ecdhe_Rsa_Aes128_Sha256. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes128_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(ECDHERSAAES128SHA256Value);

        /// <summary> Gets the Ecdhe_Rsa_Aes256_Sha384. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes256_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(ECDHERSAAES256SHA384Value);
    }
}
