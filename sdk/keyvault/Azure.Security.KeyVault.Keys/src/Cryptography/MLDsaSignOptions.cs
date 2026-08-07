// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Options for signing with a post-quantum ML-DSA (AKP) key using
    /// <see cref="CryptographyClient.Sign(MLDsaSignOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    /// <remarks>
    /// Exactly one of <see cref="Message"/> or <see cref="ExternalMu"/> must be set.
    /// When <see cref="ExternalMu"/> is specified, <see cref="Context"/> must not be set.
    /// The algorithm is inferred from the key and is not specified by the caller.
    /// </remarks>
    public class MLDsaSignOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MLDsaSignOptions"/> class.
        /// </summary>
        public MLDsaSignOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MLDsaSignOptions"/> class for signing a message.
        /// </summary>
        /// <param name="message">The message to sign.</param>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> is null.</exception>
        public MLDsaSignOptions(byte[] message)
        {
            Argument.AssertNotNull(message, nameof(message));

            Message = message;
        }

        /// <summary>
        /// Gets or sets the message to sign. Mutually exclusive with <see cref="ExternalMu"/>.
        /// </summary>
        public byte[] Message { get; set; }

        /// <summary>
        /// Gets or sets the pre-computed 64-byte mu value to sign. Mutually exclusive with
        /// <see cref="Message"/> and cannot be combined with <see cref="Context"/>.
        /// </summary>
        public byte[] ExternalMu { get; set; }

        /// <summary>
        /// Gets or sets an optional context of up to 255 bytes. Cannot be used with <see cref="ExternalMu"/>.
        /// </summary>
        public byte[] Context { get; set; }
    }
}
