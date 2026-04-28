// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: Use CodeGenMember to rename generated enum members to maintain
    // the underscored naming from the previous SDK (v1.5.1: e.g. Tls_Aes_128_Gcm_Sha256).
    // The TypeSpec generator produces ALL_CAPS names (e.g. TLSAES128GCMSHA256) from spec
    // member names. CodeGenMember maps the generated names to the old underscored names
    // to preserve public API naming compatibility.
    //
    // Cannot rename type from Afd to FrontDoor — this is an inline union type
    // referenced by original name in generated serialization code and in
    // FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet properties.
    public readonly partial struct AfdCustomizedCipherSuiteForTls13
    {
        /// <summary> TLS_AES_128_GCM_SHA256. </summary>
        [CodeGenMember("TLSAES128GCMSHA256")]
        public static AfdCustomizedCipherSuiteForTls13 Tls_Aes_128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls13(TLSAES128GCMSHA256Value);

        /// <summary> TLS_AES_256_GCM_SHA384. </summary>
        [CodeGenMember("TLSAES256GCMSHA384")]
        public static AfdCustomizedCipherSuiteForTls13 Tls_Aes_256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls13(TLSAES256GCMSHA384Value);
    }
}
