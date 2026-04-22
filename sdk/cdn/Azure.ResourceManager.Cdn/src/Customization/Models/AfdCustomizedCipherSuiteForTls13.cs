// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Cdn.Models
{
    // Reason: Backward compatibility — the old SDK (v1.5.1) shipped enum members
    // with underscored names (e.g. Tls_Aes_128_Gcm_Sha256), while the generator
    // now produces ALL_CAPS names (e.g. TLSAES128GCMSHA256).
    // These properties preserve the old public API to avoid breaking existing callers.
    //
    // Cannot rename type from Afd to FrontDoor — this is an inline union type
    // referenced by original name in generated serialization code and in
    // FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet properties.
    // @@clientName has no effect on inline union type references.
    public readonly partial struct AfdCustomizedCipherSuiteForTls13
    {
        /// <summary> Gets the Tls_Aes_128_Gcm_Sha256. </summary>
        public static AfdCustomizedCipherSuiteForTls13 Tls_Aes_128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls13(TLSAES128GCMSHA256Value);

        /// <summary> Gets the Tls_Aes_256_Gcm_Sha384. </summary>
        public static AfdCustomizedCipherSuiteForTls13 Tls_Aes_256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls13(TLSAES256GCMSHA384Value);
    }
}
