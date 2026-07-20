// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Ssl cipher suites enums. </summary>
    public readonly partial struct ApplicationGatewaySslCipherSuite : IEquatable<ApplicationGatewaySslCipherSuite>
    {
#pragma warning disable CA1707
        /// <summary> TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES256CBCSHA384")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes256CbcSha384 { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanRsaWithAes256CbcSha384Value);
        /// <summary> TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES128CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes128CbcSha256 { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanRsaWithAes128CbcSha256Value);
        /// <summary> TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES256CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes256CbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanRsaWithAes256CbcShaValue);
        /// <summary> TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES128CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes128CbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanRsaWithAes128CbcShaValue);
        /// <summary> TLS_DHE_RSA_WITH_AES_256_GCM_SHA384. </summary>
        [CodeGenMember("TLSDHERSAWithAES256GCMSHA384")]
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes256GcmSha384 { get; } = new ApplicationGatewaySslCipherSuite(TlsDHERsaWithAes256GcmSha384Value);
        /// <summary> TLS_DHE_RSA_WITH_AES_128_GCM_SHA256. </summary>
        [CodeGenMember("TLSDHERSAWithAES128GCMSHA256")]
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes128GcmSha256 { get; } = new ApplicationGatewaySslCipherSuite(TlsDHERsaWithAes128GcmSha256Value);
        /// <summary> TLS_DHE_RSA_WITH_AES_256_CBC_SHA. </summary>
        [CodeGenMember("TLSDHERSAWithAES256CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes256CbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsDHERsaWithAes256CbcShaValue);
        /// <summary> TLS_DHE_RSA_WITH_AES_128_CBC_SHA. </summary>
        [CodeGenMember("TLSDHERSAWithAES128CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsDHERsaWithAes128CbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsDHERsaWithAes128CbcShaValue);
        /// <summary> TLS_RSA_WITH_AES_256_GCM_SHA384. </summary>
        [CodeGenMember("TLSRSAWithAES256GCMSHA384")]
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes256GcmSha384 { get; } = new ApplicationGatewaySslCipherSuite(TlsRsaWithAes256GcmSha384Value);
        /// <summary> TLS_RSA_WITH_AES_128_GCM_SHA256. </summary>
        [CodeGenMember("TLSRSAWithAES128GCMSHA256")]
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes128GcmSha256 { get; } = new ApplicationGatewaySslCipherSuite(TlsRsaWithAes128GcmSha256Value);
        /// <summary> TLS_RSA_WITH_AES_256_CBC_SHA256. </summary>
        [CodeGenMember("TLSRSAWithAES256CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes256CbcSha256 { get; } = new ApplicationGatewaySslCipherSuite(TlsRsaWithAes256CbcSha256Value);
        /// <summary> TLS_RSA_WITH_AES_128_CBC_SHA256. </summary>
        [CodeGenMember("TLSRSAWithAES128CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes128CbcSha256 { get; } = new ApplicationGatewaySslCipherSuite(TlsRsaWithAes128CbcSha256Value);
        /// <summary> TLS_RSA_WITH_AES_256_CBC_SHA. </summary>
        [CodeGenMember("TLSRSAWithAES256CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes256CbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsRsaWithAes256CbcShaValue);
        /// <summary> TLS_RSA_WITH_AES_128_CBC_SHA. </summary>
        [CodeGenMember("TLSRSAWithAES128CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsRsaWithAes128CbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsRsaWithAes128CbcShaValue);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES256GCMSHA384")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes256GcmSha384 { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanECDsaWithAes256GcmSha384Value);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES128GCMSHA256")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes128GcmSha256 { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanECDsaWithAes128GcmSha256Value);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES256CBCSHA384")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes256CbcSha384 { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanECDsaWithAes256CbcSha384Value);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES128CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes128CbcSha256 { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanECDsaWithAes128CbcSha256Value);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES256CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes256CbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanECDsaWithAes256CbcShaValue);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES128CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanECDsaWithAes128CbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanECDsaWithAes128CbcShaValue);
        /// <summary> TLS_DHE_DSS_WITH_AES_256_CBC_SHA256. </summary>
        [CodeGenMember("TLSDHEDSSWithAES256CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes256CbcSha256 { get; } = new ApplicationGatewaySslCipherSuite(TlsDheDssWithAes256CbcSha256Value);
        /// <summary> TLS_DHE_DSS_WITH_AES_128_CBC_SHA256. </summary>
        [CodeGenMember("TLSDHEDSSWithAES128CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes128CbcSha256 { get; } = new ApplicationGatewaySslCipherSuite(TlsDheDssWithAes128CbcSha256Value);
        /// <summary> TLS_DHE_DSS_WITH_AES_256_CBC_SHA. </summary>
        [CodeGenMember("TLSDHEDSSWithAES256CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes256CbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsDheDssWithAes256CbcShaValue);
        /// <summary> TLS_DHE_DSS_WITH_AES_128_CBC_SHA. </summary>
        [CodeGenMember("TLSDHEDSSWithAES128CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsDheDssWithAes128CbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsDheDssWithAes128CbcShaValue);
        /// <summary> TLS_RSA_WITH_3DES_EDE_CBC_SHA. </summary>
        [CodeGenMember("TLSRSAWith3DESEDECBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsRsaWith3DesEdeCbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsRsaWith3DesEdeCbcShaValue);
        /// <summary> TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA. </summary>
        [CodeGenMember("TLSDHEDSSWith3DESEDECBCSHA")]
        public static ApplicationGatewaySslCipherSuite TlsDheDssWith3DesEdeCbcSha { get; } = new ApplicationGatewaySslCipherSuite(TlsDheDssWith3DesEdeCbcShaValue);
        /// <summary> TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES128GCMSHA256")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes128GcmSha256 { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanRsaWithAes128GcmSha256Value);
        /// <summary> TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES256GCMSHA384")]
        public static ApplicationGatewaySslCipherSuite TlsECDiffieHellmanRsaWithAes256GcmSha384 { get; } = new ApplicationGatewaySslCipherSuite(TlsECDiffieHellmanRsaWithAes256GcmSha384Value);
#pragma warning restore CA1707
    }
}
