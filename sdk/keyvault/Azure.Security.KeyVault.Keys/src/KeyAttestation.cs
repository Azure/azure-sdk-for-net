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
        /// Gets a base64url-encoded string containing certificates in PEM format, used for attestation validation.
        /// </summary>
        public ReadOnlyMemory<byte> CertificatePemFile { get; internal set; }

        /// <summary>
        /// Gets the attestation blob bytes encoded as a base64 URL string corresponding to the private key value.
        /// </summary>
        public ReadOnlyMemory<byte> PrivateKeyAttestation { get; internal set; }

        /// <summary>
        /// Gets the attestation blob bytes encoded as a base64 URL string.
        /// In the case of an asymmetric key, this corresponds to the public key value.
        /// </summary>
        public ReadOnlyMemory<byte> PublicKeyAttestation { get; internal set; }

        /// <summary>
        /// Gets the version of the attestation.
        /// </summary>
        public string Version { get; internal set; }
    }
}
