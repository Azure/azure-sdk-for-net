// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public readonly partial struct AfdCustomizedCipherSuiteForTls13
    {
        /// <summary> TLS_AES_128_GCM_SHA256. </summary>
        [CodeGenMember("TLSAES128GCMSHA256")]
        public static AfdCustomizedCipherSuiteForTls13 Tls_Aes_128_Gcm_Sha256 { get; } = new AfdCustomizedCipherSuiteForTls13(Tls_Aes_128_Gcm_Sha256Value);
        /// <summary> TLS_AES_256_GCM_SHA384. </summary>
        [CodeGenMember("TLSAES256GCMSHA384")]
        public static AfdCustomizedCipherSuiteForTls13 Tls_Aes_256_Gcm_Sha384 { get; } = new AfdCustomizedCipherSuiteForTls13(Tls_Aes_256_Gcm_Sha384Value);
    }
}