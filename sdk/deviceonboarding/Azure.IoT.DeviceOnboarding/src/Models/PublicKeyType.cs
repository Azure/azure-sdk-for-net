// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Type of Public key
    /// </summary>
    public enum PublicKeyType
    {
        /// <summary>
        /// RSA 2048 with restricted key/exponent (PKCS1 1.5 encoding)
        /// </summary>
        RSA2048RESTR = 1,

        /// <summary>
        /// RSA key, PKCS1, v1.5
        /// </summary>
        RSAPKCS = 5,

        /// <summary>
        /// RSA key, PSS
        /// </summary>
        RSAPSS = 6,

        /// <summary>
        /// ECDSA secp256r1 = NIST-P-256 = prime256v1
        /// </summary>
        SECP256R1 = 10,

        /// <summary>
        /// ECDSA secp384r1 = NIST-P-384
        /// </summary>
        SECP384R1 = 11,
    }
}
