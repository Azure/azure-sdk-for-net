// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public readonly partial struct AfdCustomizedCipherSuiteForTls12
    {
        [CodeGenMember("EcdheRSAAES128GCMSHA256")]
        /// <summary> ECDHE-RSA-AES128-GCM-SHA256. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(Ecdhe_Rsa_Aes128_Gcm_Sha256Value);
        [CodeGenMember("EcdheRSAAES256GCMSHA384")]
        /// <summary> ECDHE-RSA-AES256-GCM-SHA384. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(Ecdhe_Rsa_Aes256_Gcm_Sha384Value);
        [CodeGenMember("DHERSAAES256GCMSHA384")]
        /// <summary> DHE-RSA-AES256-GCM-SHA384. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Dhe_Rsa_Aes256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(Dhe_Rsa_Aes256_Gcm_Sha384Value);
        [CodeGenMember("DHERSAAES128GCMSHA256")]
        /// <summary> DHE-RSA-AES128-GCM-SHA256. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Dhe_Rsa_Aes128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(Dhe_Rsa_Aes128_Gcm_Sha256Value);
        [CodeGenMember("EcdheRSAAES128Sha256")]
        /// <summary> ECDHE-RSA-AES128-SHA256. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes128_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls12(Ecdhe_Rsa_Aes128_Sha256Value);
        [CodeGenMember("EcdheRSAAES256SHA384")]
        /// <summary> ECDHE-RSA-AES256-SHA384. </summary>
        public static AfdCustomizedCipherSuiteForTls12 Ecdhe_Rsa_Aes256_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls12(Ecdhe_Rsa_Aes256_Sha384Value);
    }
}