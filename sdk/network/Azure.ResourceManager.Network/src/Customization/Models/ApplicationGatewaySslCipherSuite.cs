// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ApplicationGatewaySslCipherSuite type. </summary>
    public readonly partial struct ApplicationGatewaySslCipherSuite
    {
        /// <inheritdoc cref="TlsECDiffieHellmanECDsaWithAes128CbcSha"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanECDsaWithAes128CbcSha instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHEECDSAWITHAES128CBCSHA => TlsECDiffieHellmanECDsaWithAes128CbcSha;
        /// <inheritdoc cref="TlsECDiffieHellmanECDsaWithAes128CbcSha256"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanECDsaWithAes128CbcSha256 instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHEECDSAWITHAES128CBCSHA256 => TlsECDiffieHellmanECDsaWithAes128CbcSha256;
        /// <inheritdoc cref="TlsECDiffieHellmanECDsaWithAes128GcmSha256"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanECDsaWithAes128GcmSha256 instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHEECDSAWITHAES128GCMSHA256 => TlsECDiffieHellmanECDsaWithAes128GcmSha256;
        /// <inheritdoc cref="TlsECDiffieHellmanECDsaWithAes256CbcSha"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanECDsaWithAes256CbcSha instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHEECDSAWITHAES256CBCSHA => TlsECDiffieHellmanECDsaWithAes256CbcSha;
        /// <inheritdoc cref="TlsECDiffieHellmanECDsaWithAes256CbcSha384"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanECDsaWithAes256CbcSha384 instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHEECDSAWITHAES256CBCSHA384 => TlsECDiffieHellmanECDsaWithAes256CbcSha384;
        /// <inheritdoc cref="TlsECDiffieHellmanECDsaWithAes256GcmSha384"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanECDsaWithAes256GcmSha384 instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHEECDSAWITHAES256GCMSHA384 => TlsECDiffieHellmanECDsaWithAes256GcmSha384;
        /// <inheritdoc cref="TlsECDiffieHellmanRsaWithAes128CbcSha"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanRsaWithAes128CbcSha instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHERSAWITHAES128CBCSHA => TlsECDiffieHellmanRsaWithAes128CbcSha;
        /// <inheritdoc cref="TlsECDiffieHellmanRsaWithAes128CbcSha256"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanRsaWithAes128CbcSha256 instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHERSAWITHAES128CBCSHA256 => TlsECDiffieHellmanRsaWithAes128CbcSha256;
        /// <inheritdoc cref="TlsECDiffieHellmanRsaWithAes128GcmSha256"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanRsaWithAes128GcmSha256 instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHERSAWITHAES128GCMSHA256 => TlsECDiffieHellmanRsaWithAes128GcmSha256;
        /// <inheritdoc cref="TlsECDiffieHellmanRsaWithAes256CbcSha"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanRsaWithAes256CbcSha instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHERSAWITHAES256CBCSHA => TlsECDiffieHellmanRsaWithAes256CbcSha;
        /// <inheritdoc cref="TlsECDiffieHellmanRsaWithAes256CbcSha384"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanRsaWithAes256CbcSha384 instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHERSAWITHAES256CBCSHA384 => TlsECDiffieHellmanRsaWithAes256CbcSha384;
        /// <inheritdoc cref="TlsECDiffieHellmanRsaWithAes256GcmSha384"/>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("This property is deprecated and it will be removed in a future version. Please use TlsECDiffieHellmanRsaWithAes256GcmSha384 instead.")]
        public static ApplicationGatewaySslCipherSuite TLSECDHERSAWITHAES256GCMSHA384 => TlsECDiffieHellmanRsaWithAes256GcmSha384;
    }
}
