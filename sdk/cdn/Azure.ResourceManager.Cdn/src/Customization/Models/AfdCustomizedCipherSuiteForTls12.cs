// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file uses CodeGenMember to rename enum members to maintain the naming convention from the previous SDK.
    // Reason: The TypeSpec generator removes separators from cipher suite names to produce member names (e.g., ECDHERSAAES128GCMSHA256),
    // but the old SDK used underscore-separated readable names (e.g., Ecdhe_Rsa_Aes128_Gcm_Sha256).
    // CodeGenMember attributes map the generated names to the old names to preserve public API naming compatibility.
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
