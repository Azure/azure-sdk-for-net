// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file uses CodeGenMember to rename enum members to maintain the naming convention from the previous SDK.
    // Reason: The TypeSpec generator removes separators from cipher suite names to produce member names (e.g., TLSAES128GCMSHA256),
    // but the old SDK used underscore-separated readable names (e.g., Tls_Aes_128_Gcm_Sha256).
    // CodeGenMember attributes map the generated names to the old names to preserve public API naming compatibility.
    // Note: AfdCustomizedCipherSuiteForTls13 is an inline union type used within FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet.
    // The MPG generator does not generate a standalone file for this type, so @@clientName cannot rename it.
    // The type name retains the original "Afd" prefix from the TypeSpec spec.
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
