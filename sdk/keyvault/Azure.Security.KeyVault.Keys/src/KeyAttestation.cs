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
        /// Gets or sets the attestation blob bytes encoded as base64url string corresponding to a private key.
        /// </summary>
        public byte[] PrivateKeyAttestation { get; set; }

        /// <summary>
        /// Gets or sets the attestation blob bytes encoded as base64url string corresponding to a public key in case of asymmetric key.
        /// </summary>
        public byte[] PublicKeyAttestation { get; set; }

        /// <summary>
        /// Gets or sets the version of the attestation.
        /// </summary>
        public string Version { get; set; }
    }
}