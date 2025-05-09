// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public readonly partial struct AfdCustomizedCipherSuiteForTls13
    {
        [CodeGenMember("TLSAES128GCMSHA256")]
        /// <summary> TLS_AES_128_GCM_SHA256. </summary>
        public static AfdCustomizedCipherSuiteForTls13 TLS_Aes128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls13(Tls_Aes_128_Gcm_Sha256Value);
        [CodeGenMember("TLSAES256GCMSHA384")]
        /// <summary> TLS_AES_256_GCM_SHA384. </summary>
        public static AfdCustomizedCipherSuiteForTls13 TLS_Aes256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls13(Tls_Aes_256_Gcm_Sha384Value);
    }
}