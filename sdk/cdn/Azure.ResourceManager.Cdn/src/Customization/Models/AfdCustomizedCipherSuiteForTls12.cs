// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Cdn.Models
{
    // Reason: Backward compatibility — the old SDK (v1.5.1) shipped enum members
    // with underscored names (e.g. Ecdhe_Rsa_Aes128_Gcm_Sha256), while the
    // generator now produces ALL_CAPS names (e.g. ECDHERSAAES128GCMSHA256).
    // These properties preserve the old public API to avoid breaking existing callers.
    //
    // Cannot rename type from Afd to FrontDoor — this is an inline union type
    // referenced by original name in generated serialization code and in
    // FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet properties.
    // @@clientName has no effect on inline union type references.
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
