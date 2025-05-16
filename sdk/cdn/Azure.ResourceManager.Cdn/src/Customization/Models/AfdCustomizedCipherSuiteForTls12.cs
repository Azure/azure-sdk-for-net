// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public readonly partial struct AfdCustomizedCipherSuiteForTls12
    {
        /// <summary> ECDHE_RSA_AES128_GCM_SHA256. </summary>
        [CodeGenMember("EcdheRSAAES128GCMSHA256")]
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(Ecdhe_Rsa_Aes128_Gcm_Sha256Value);
        /// <summary> ECDHE_RSA_AES256_GCM_SHA384. </summary>
        [CodeGenMember("EcdheRSAAES256GCMSHA384")]
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(Ecdhe_Rsa_Aes256_Gcm_Sha384Value);
        /// <summary> DHE_RSA_AES256_GCM_SHA384. </summary>
        [CodeGenMember("DHERSAAES256GCMSHA384")]
        public static AfdCustomizedCipherSuiteForTls12 Dhe_Rsa_Aes256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(Dhe_Rsa_Aes256_Gcm_Sha384Value);
        /// <summary> DHE_RSA_AES128_GCM_SHA256. </summary>
        [CodeGenMember("DHERSAAES128GCMSHA256")]
        public static AfdCustomizedCipherSuiteForTls12 Dhe_Rsa_Aes128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(Dhe_Rsa_Aes128_Gcm_Sha256Value);
        /// <summary> ECDHE_RSA_AES128_SHA256. </summary>
        [CodeGenMember("EcdheRSAAES128Sha256")]
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes128_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(Ecdhe_Rsa_Aes128_Sha256Value);
        /// <summary> ECDHE_RSA_AES256_SHA384. </summary>
        [CodeGenMember("EcdheRSAAES256SHA384")]
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes256_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(Ecdhe_Rsa_Aes256_Sha384Value);
    }
}