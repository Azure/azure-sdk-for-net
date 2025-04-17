// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Cipher Suite Type
    /// </summary>
    public enum CipherSuiteType
    {
        /// <summary>
        /// AES-GCM mode w/ 128-bit key, 128-bit tag
        /// </summary>
        A128GCM = 1,
        /// <summary>
        /// AES-GCM mode w/ 256-bit key, 128-bit tag.
        /// </summary>
        A256GCM = 3,
        /// <summary>
        /// AES-CCM mode 128-bit key, 128-bit tag, 13-byte nonce
        /// </summary>
        AESCCM16128128 = 30,
        /// <summary>
        /// AES-CCM mode 256-bit key, 128-bit tag, 13-byte nonce
        /// </summary>
        AESCCM16128256 = 31,
        /// <summary>
        /// AES-CCM mode 128-bit key, 128-bit tag, 7-byte nonce
        /// </summary>
        AESCCM64128128 = 32,
        /// <summary>
        /// AES-CCM mode 256-bit key, 128-bit tag, 7-byte nonce
        /// </summary>
        AESCCM64128256 = 33,
        /// <summary>
        /// AES-CBC w/ 128-bit key
        /// </summary>
        COSEAES128CBC = -17760703,
        /// <summary>
        /// AES-CTR w/ 128-bit key
        /// </summary>
        COSEAES128CTR = -17760704,
        /// <summary>
        /// AES-CBC w/ 256-bit key
        /// </summary>
        COSEAES256CBC = -17760705,
        /// <summary>
        /// AES-CTR w/ 128-bit key
        /// </summary>
        COSEAES256CTR = -17760706
    }
}
