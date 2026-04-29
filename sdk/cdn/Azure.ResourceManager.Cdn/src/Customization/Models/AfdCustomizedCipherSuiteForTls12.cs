// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: Use CodeGenMember to rename generated enum members to maintain
    // the underscored naming from the previous SDK (v1.5.1: e.g. Ecdhe_Rsa_Aes128_Gcm_Sha256).
    // The TypeSpec generator produces ALL_CAPS names (e.g. ECDHERSAAES128GCMSHA256) from
    // spec member names. CodeGenMember maps the generated names to the old underscored names
    // to preserve public API naming compatibility.
    //
    // Cannot rename type from Afd to FrontDoor — this is an inline union type
    // referenced by original name in generated serialization code and in
    // FrontDoorCustomDomainHttpsCustomizedCipherSuiteSet properties.
    public readonly partial struct AfdCustomizedCipherSuiteForTls12
    {
        /// <summary> ECDHE_RSA_AES128_GCM_SHA256. </summary>
        [CodeGenMember("ECDHERSAAES128GCMSHA256")]
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(ECDHERSAAES128GCMSHA256Value);

        /// <summary> ECDHE_RSA_AES256_GCM_SHA384. </summary>
        [CodeGenMember("ECDHERSAAES256GCMSHA384")]
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(ECDHERSAAES256GCMSHA384Value);

        /// <summary> DHE_RSA_AES256_GCM_SHA384. </summary>
        [CodeGenMember("DHERSAAES256GCMSHA384")]
        public static AfdCustomizedCipherSuiteForTls12 Dhe_Rsa_Aes256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(DHERSAAES256GCMSHA384Value);

        /// <summary> DHE_RSA_AES128_GCM_SHA256. </summary>
        [CodeGenMember("DHERSAAES128GCMSHA256")]
        public static AfdCustomizedCipherSuiteForTls12 Dhe_Rsa_Aes128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(DHERSAAES128GCMSHA256Value);

        /// <summary> ECDHE_RSA_AES128_SHA256. </summary>
        [CodeGenMember("ECDHERSAAES128SHA256")]
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes128_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(ECDHERSAAES128SHA256Value);

        /// <summary> ECDHE_RSA_AES256_SHA384. </summary>
        [CodeGenMember("ECDHERSAAES256SHA384")]
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes256_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(ECDHERSAAES256SHA384Value);
    }
}
