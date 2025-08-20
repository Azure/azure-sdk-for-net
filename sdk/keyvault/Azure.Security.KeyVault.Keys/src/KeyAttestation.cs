// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The key attestation information.
    /// </summary>
    public class KeyAttestation
    {
        /// <summary>
        /// Creates a new instance of the <see cref="KeyAttestation"/> class.
        /// </summary>
        public KeyAttestation()
        {
        }

        /// <summary>
        /// Gets or sets a base64url-encoded string containing certificates in PEM format, used for attestation validation.
        /// </summary>
        public byte[] CertificatePemFile { get; set; }

        /// <summary>
        /// Gets or sets the attestation blob bytes encoded as a base64 URL string corresponding to the private key value.
        /// </summary>
        public byte[] PrivateKeyAttestation { get; set; }

        /// <summary>
        /// Gets or sets the attestation blob bytes encoded as a base64 URL string.
        /// In the case of an asymmetric key, this corresponds to the public key value.
        /// </summary>
        public byte[] PublicKeyAttestation { get; set; }

        /// <summary>
        /// Gets or sets the version of the attestation.
        /// </summary>
        public string Version { get; set; }
    }
}