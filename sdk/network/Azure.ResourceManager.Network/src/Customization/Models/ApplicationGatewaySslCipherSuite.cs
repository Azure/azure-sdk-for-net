// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Ssl cipher suites enums. </summary>
    public readonly partial struct ApplicationGatewaySslCipherSuite : IEquatable<ApplicationGatewaySslCipherSuite>
    {
#pragma warning disable CA1707
        /// <summary> TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES256CBCSHA384")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384 { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384Value);
        /// <summary> TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES128CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256 { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256Value);
        /// <summary> TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES256CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_RSA_WITH_AES_256_CBC_SHAValue);
        /// <summary> TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES128CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_RSA_WITH_AES_128_CBC_SHAValue);
        /// <summary> TLS_DHE_RSA_WITH_AES_256_GCM_SHA384. </summary>
        [CodeGenMember("TLSDHERSAWithAES256GCMSHA384")]
        public static ApplicationGatewaySslCipherSuite TLS_DHE_RSA_WITH_AES_256_GCM_SHA384 { get; } = new ApplicationGatewaySslCipherSuite(TLS_DHE_RSA_WITH_AES_256_GCM_SHA384Value);
        /// <summary> TLS_DHE_RSA_WITH_AES_128_GCM_SHA256. </summary>
        [CodeGenMember("TLSDHERSAWithAES128GCMSHA256")]
        public static ApplicationGatewaySslCipherSuite TLS_DHE_RSA_WITH_AES_128_GCM_SHA256 { get; } = new ApplicationGatewaySslCipherSuite(TLS_DHE_RSA_WITH_AES_128_GCM_SHA256Value);
        /// <summary> TLS_DHE_RSA_WITH_AES_256_CBC_SHA. </summary>
        [CodeGenMember("TLSDHERSAWithAES256CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_DHE_RSA_WITH_AES_256_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_DHE_RSA_WITH_AES_256_CBC_SHAValue);
        /// <summary> TLS_DHE_RSA_WITH_AES_128_CBC_SHA. </summary>
        [CodeGenMember("TLSDHERSAWithAES128CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_DHE_RSA_WITH_AES_128_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_DHE_RSA_WITH_AES_128_CBC_SHAValue);
        /// <summary> TLS_RSA_WITH_AES_256_GCM_SHA384. </summary>
        [CodeGenMember("TLSRSAWithAES256GCMSHA384")]
        public static ApplicationGatewaySslCipherSuite TLS_RSA_WITH_AES_256_GCM_SHA384 { get; } = new ApplicationGatewaySslCipherSuite(TLS_RSA_WITH_AES_256_GCM_SHA384Value);
        /// <summary> TLS_RSA_WITH_AES_128_GCM_SHA256. </summary>
        [CodeGenMember("TLSRSAWithAES128GCMSHA256")]
        public static ApplicationGatewaySslCipherSuite TLS_RSA_WITH_AES_128_GCM_SHA256 { get; } = new ApplicationGatewaySslCipherSuite(TLS_RSA_WITH_AES_128_GCM_SHA256Value);
        /// <summary> TLS_RSA_WITH_AES_256_CBC_SHA256. </summary>
        [CodeGenMember("TLSRSAWithAES256CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TLS_RSA_WITH_AES_256_CBC_SHA256 { get; } = new ApplicationGatewaySslCipherSuite(TLS_RSA_WITH_AES_256_CBC_SHA256Value);
        /// <summary> TLS_RSA_WITH_AES_128_CBC_SHA256. </summary>
        [CodeGenMember("TLSRSAWithAES128CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TLS_RSA_WITH_AES_128_CBC_SHA256 { get; } = new ApplicationGatewaySslCipherSuite(TLS_RSA_WITH_AES_128_CBC_SHA256Value);
        /// <summary> TLS_RSA_WITH_AES_256_CBC_SHA. </summary>
        [CodeGenMember("TLSRSAWithAES256CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_RSA_WITH_AES_256_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_RSA_WITH_AES_256_CBC_SHAValue);
        /// <summary> TLS_RSA_WITH_AES_128_CBC_SHA. </summary>
        [CodeGenMember("TLSRSAWithAES128CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_RSA_WITH_AES_128_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_RSA_WITH_AES_128_CBC_SHAValue);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES256GCMSHA384")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384 { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384Value);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES128GCMSHA256")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256 { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256Value);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES256CBCSHA384")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384 { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384Value);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES128CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256 { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256Value);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES256CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHAValue);
        /// <summary> TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA. </summary>
        [CodeGenMember("TLSEcdheEcdsaWithAES128CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHAValue);
        /// <summary> TLS_DHE_DSS_WITH_AES_256_CBC_SHA256. </summary>
        [CodeGenMember("TLSDHEDSSWithAES256CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TLS_DHE_DSS_WITH_AES_256_CBC_SHA256 { get; } = new ApplicationGatewaySslCipherSuite(TLS_DHE_DSS_WITH_AES_256_CBC_SHA256Value);
        /// <summary> TLS_DHE_DSS_WITH_AES_128_CBC_SHA256. </summary>
        [CodeGenMember("TLSDHEDSSWithAES128CBCSHA256")]
        public static ApplicationGatewaySslCipherSuite TLS_DHE_DSS_WITH_AES_128_CBC_SHA256 { get; } = new ApplicationGatewaySslCipherSuite(TLS_DHE_DSS_WITH_AES_128_CBC_SHA256Value);
        /// <summary> TLS_DHE_DSS_WITH_AES_256_CBC_SHA. </summary>
        [CodeGenMember("TLSDHEDSSWithAES256CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_DHE_DSS_WITH_AES_256_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_DHE_DSS_WITH_AES_256_CBC_SHAValue);
        /// <summary> TLS_DHE_DSS_WITH_AES_128_CBC_SHA. </summary>
        [CodeGenMember("TLSDHEDSSWithAES128CBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_DHE_DSS_WITH_AES_128_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_DHE_DSS_WITH_AES_128_CBC_SHAValue);
        /// <summary> TLS_RSA_WITH_3DES_EDE_CBC_SHA. </summary>
        [CodeGenMember("TLSRSAWith3DESEDECBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_RSA_WITH_3DES_EDE_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_RSA_WITH_3DES_EDE_CBC_SHAValue);
        /// <summary> TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA. </summary>
        [CodeGenMember("TLSDHEDSSWith3DESEDECBCSHA")]
        public static ApplicationGatewaySslCipherSuite TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA { get; } = new ApplicationGatewaySslCipherSuite(TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHAValue);
        /// <summary> TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES128GCMSHA256")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256 { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256Value);
        /// <summary> TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384. </summary>
        [CodeGenMember("TLSEcdheRSAWithAES256GCMSHA384")]
        public static ApplicationGatewaySslCipherSuite TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384 { get; } = new ApplicationGatewaySslCipherSuite(TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384Value);
#pragma warning restore CA1707
    }
}
