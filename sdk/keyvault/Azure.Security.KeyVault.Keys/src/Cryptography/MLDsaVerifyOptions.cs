// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Options for verifying a signature with a post-quantum ML-DSA (AKP) key using
    /// <see cref="CryptographyClient.Verify(MLDsaVerifyOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="Signature"/> is always required. Exactly one of <see cref="Message"/> or
    /// <see cref="ExternalMu"/> must be set. When <see cref="ExternalMu"/> is specified,
    /// <see cref="Context"/> must not be set. The algorithm is inferred from the key and is not
    /// specified by the caller.
    /// </remarks>
    public class MLDsaVerifyOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MLDsaVerifyOptions"/> class.
        /// </summary>
        public MLDsaVerifyOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MLDsaVerifyOptions"/> class for verifying a message signature.
        /// </summary>
        /// <param name="message">The message corresponding to the <paramref name="signature"/>.</param>
        /// <param name="signature">The signature to verify.</param>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> or <paramref name="signature"/> is null.</exception>
        public MLDsaVerifyOptions(byte[] message, byte[] signature)
        {
            Argument.AssertNotNull(message, nameof(message));
            Argument.AssertNotNull(signature, nameof(signature));

            Message = message;
            Signature = signature;
        }

        /// <summary>
        /// Gets or sets the message corresponding to the <see cref="Signature"/>. Mutually exclusive with <see cref="ExternalMu"/>.
        /// </summary>
        public byte[] Message { get; set; }

        /// <summary>
        /// Gets or sets the signature to verify. This value is required.
        /// </summary>
        public byte[] Signature { get; set; }

        /// <summary>
        /// Gets or sets the pre-computed 64-byte mu value corresponding to the <see cref="Signature"/>.
        /// Mutually exclusive with <see cref="Message"/> and cannot be combined with <see cref="Context"/>.
        /// </summary>
        public byte[] ExternalMu { get; set; }

        /// <summary>
        /// Gets or sets an optional context of up to 255 bytes. Cannot be used with <see cref="ExternalMu"/>.
        /// </summary>
        public byte[] Context { get; set; }
    }
}
