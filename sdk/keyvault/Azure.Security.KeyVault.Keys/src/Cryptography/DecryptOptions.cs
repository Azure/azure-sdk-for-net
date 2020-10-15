// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Options for decrypting ciphertext.
    /// </summary>
    public class DecryptOptions : IJsonSerializable
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DecryptOptions"/> class.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> is null.</exception>
        public DecryptOptions(byte[] ciphertext)
        {
            Argument.AssertNotNull(ciphertext, nameof(ciphertext));

            Ciphertext = ciphertext;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DecryptOptions"/> class.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <param name="iv">The initialization vector for decryption.</param>
        /// <param name="authenticationTag">The authenticated tag resulting from encryption with a symmetric key using AES.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/>, <paramref name="iv"/>, or <paramref name="authenticationTag"/> is null.</exception>
        public DecryptOptions(byte[] ciphertext, byte[] iv, byte[] authenticationTag)
        {
            Argument.AssertNotNull(ciphertext, nameof(ciphertext));
            Argument.AssertNotNull(iv, nameof(iv));
            Argument.AssertNotNull(authenticationTag, nameof(authenticationTag));

            Ciphertext = ciphertext;
            Iv = iv;
            AuthenticationTag = authenticationTag;
        }

        /// <summary>
        /// Gets the ciphertext to decrypt.
        /// </summary>
        public byte[] Ciphertext { get; }

        /// <summary>
        /// Gets the initialization vector for decryption.
        /// </summary>
        public byte[] Iv { get; }

        /// <summary>
        /// Gets the authenticated tag resulting from encryption with a symmetric key using AES.
        /// </summary>
        public byte[] AuthenticationTag { get; }

        /// <summary>
        /// Gets or sets additional data that is authenticated during decryption but not encrypted.
        /// </summary>
        public byte[] AdditionalAuthenticatedData { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        internal EncryptionAlgorithm Algorithm { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString("alg", Algorithm.ToString());

            if (Ciphertext != null)
            {
                json.WriteString("value", Base64Url.Encode(Ciphertext));
            }
            if (Iv != null)
            {
                json.WriteString("iv", Base64Url.Encode(Iv));
            }
            if (AuthenticationTag != null)
            {
                json.WriteString("tag", Base64Url.Encode(AuthenticationTag));
            }
            if (AdditionalAuthenticatedData != null)
            {
                json.WriteString("aad", Base64Url.Encode(AdditionalAuthenticatedData));
            }
        }
    }
}
