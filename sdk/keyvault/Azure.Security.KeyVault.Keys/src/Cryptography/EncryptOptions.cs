// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Options for encrypting plaintext.
    /// </summary>
    public class EncryptOptions : IJsonSerializable
    {
        private const int AesBlockSize = 12;

        private static readonly Lazy<RandomNumberGenerator> s_rng = new Lazy<RandomNumberGenerator>(
            () => RandomNumberGenerator.Create(),
            LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class.
        /// </summary>
        /// <param name="plaintext">The required plaintext to encrypt.</param>
        /// <param name="iv">The initialization vector for encryption. If null, one will be generated for symmetric algorithms like an nonce and returned in <see cref="EncryptResult.Iv"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public EncryptOptions(byte[] plaintext, byte[] iv = null)
        {
            Argument.AssertNotNull(plaintext, nameof(plaintext));

            Plaintext = plaintext;
            Iv = iv;
        }

        /// <summary>
        /// Gets the plaintext to encrypt.
        /// </summary>
        public byte[] Plaintext { get; }

        /// <summary>
        /// Gets the initialization vector for encryption.
        /// </summary>
        public byte[] Iv { get; private set; }

        /// <summary>
        /// Gets or sets additional data that is authenticated during decryption but not encrypted.
        /// </summary>
        public byte[] AdditionalAuthenticatedData { get; set; }

        /// <summary>
        /// Gets the <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        internal EncryptionAlgorithm Algorithm { get; private set; }

        /// <summary>
        /// Sets the <see cref="Algorithm"/> and initializes any other data required by the algorithm.
        /// </summary>
        /// <param name="algorithm">The <see cref="EncryptionAlgorithm"/> to set.</param>
        internal void Initialize(EncryptionAlgorithm algorithm)
        {
            Algorithm = algorithm;

            if (Iv == null && algorithm.RequiresIv())
            {
                Iv = new byte[AesBlockSize];
                s_rng.Value.GetBytes(Iv);
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString("alg", Algorithm.ToString());

            if (Plaintext != null)
            {
                json.WriteString("value", Base64Url.Encode(Plaintext));
            }
            if (Iv != null)
            {
                json.WriteString("iv", Base64Url.Encode(Iv));
            }
            if (AdditionalAuthenticatedData != null)
            {
                json.WriteString("aad", Base64Url.Encode(AdditionalAuthenticatedData));
            }
        }
    }
}
