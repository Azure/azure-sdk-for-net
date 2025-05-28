// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Type of Public Key Encoding
    /// </summary>
    public enum PublicKeyEncoding
    {
        /// <summary>
        /// applies to crypto with its own encoding (e.g., Intel® EPID)
        /// </summary>
        CRYPTO = 0,

        /// <summary>
        /// X509 DER encoding, applies to RSA and ECDSA
        /// </summary>
        X509 = 1,

        /// <summary>
        /// OSE x5chain, an ordered chain of X.509 certificates
        /// </summary>
        COSEX5CHAIN = 2,

        /// <summary>
        /// COSE key encoding
        /// </summary>
        COSEKEY = 3,
    }
}
