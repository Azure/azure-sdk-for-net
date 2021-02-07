// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Options for encrypting plaintext.
    /// </summary>
    public class EncryptOptions : IJsonSerializable
    {
        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.Rsa15"/> encryption algorithm.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.Rsa15"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions Rsa15Options(byte[] plaintext) =>
            new EncryptOptions(EncryptionAlgorithm.Rsa15, plaintext, null, null);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.RsaOaep"/> encryption algorithm.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.RsaOaep"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions RsaOaepOptions(byte[] plaintext) =>
            new EncryptOptions(EncryptionAlgorithm.RsaOaep, plaintext, null, null);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.RsaOaep256"/> encryption algorithm.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.RsaOaep256"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions RsaOaep256Options(byte[] plaintext) =>
            new EncryptOptions(EncryptionAlgorithm.RsaOaep256, plaintext, null, null);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128Gcm"/> encryption algorithm.
        /// The nonce will be generated automatically and returned in the <see cref="EncryptResult"/> after encryption.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <param name="additionalAuthenticationData">Optional data that is authenticated but not encrypted.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128Gcm"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions A128GcmOptions(byte[] plaintext, byte[] additionalAuthenticationData = null) =>
            new EncryptOptions(EncryptionAlgorithm.A128Gcm, plaintext, null, additionalAuthenticationData);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192Gcm"/> encryption algorithm.
        /// The nonce will be generated automatically and returned in the <see cref="EncryptResult"/> after encryption.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <param name="additionalAuthenticationData">Optional data that is authenticated but not encrypted.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192Gcm"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions A192GcmOptions(byte[] plaintext, byte[] additionalAuthenticationData = null) =>
            new EncryptOptions(EncryptionAlgorithm.A192Gcm, plaintext, null, additionalAuthenticationData);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256Gcm"/> encryption algorithm.
        /// The nonce will be generated automatically and returned in the <see cref="EncryptResult"/> after encryption.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <param name="additionalAuthenticationData">Optional data that is authenticated but not encrypted.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256Gcm"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions A256GcmOptions(byte[] plaintext, byte[] additionalAuthenticationData = null) =>
            new EncryptOptions(EncryptionAlgorithm.A256Gcm, plaintext, null, additionalAuthenticationData);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128Cbc"/> encryption algorithm.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <param name="iv">Optional initialization vector. If null, a cryptographically random initialization vector will be generated using <see cref="RandomNumberGenerator"/>.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128Cbc"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions A128CbcOptions(byte[] plaintext, byte[] iv = null) =>
            new EncryptOptions(EncryptionAlgorithm.A128Cbc, plaintext, iv, null);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192Cbc"/> encryption algorithm.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <param name="iv">Optional initialization vector. If null, a cryptographically random initialization vector will be generated using <see cref="RandomNumberGenerator"/>.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192Cbc"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions A192CbcOptions(byte[] plaintext, byte[] iv = null) =>
            new EncryptOptions(EncryptionAlgorithm.A192Cbc, plaintext, iv, null);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256Cbc"/> encryption algorithm.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <param name="iv">Optional initialization vector. If null, a cryptographically random initialization vector will be generated using <see cref="RandomNumberGenerator"/>.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256Cbc"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions A256CbcOptions(byte[] plaintext, byte[] iv = null) =>
            new EncryptOptions(EncryptionAlgorithm.A256Cbc, plaintext, iv, null);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128CbcPad"/> encryption algorithm with PKCS#7 padding.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <param name="iv">Optional initialization vector. If null, a cryptographically random initialization vector will be generated using <see cref="RandomNumberGenerator"/>.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128CbcPad"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions A128CbcPadOptions(byte[] plaintext, byte[] iv = null) =>
            new EncryptOptions(EncryptionAlgorithm.A128CbcPad, plaintext, iv, null);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192CbcPad"/> encryption algorithm with PKCS#7 padding.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <param name="iv">Optional initialization vector. If null, a cryptographically random initialization vector will be generated using <see cref="RandomNumberGenerator"/>.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192CbcPad"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions A192CbcPadOptions(byte[] plaintext, byte[] iv = null) =>
            new EncryptOptions(EncryptionAlgorithm.A192CbcPad, plaintext, iv, null);

        /// <summary>
        /// Creates an instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256CbcPad"/> encryption algorithm with PKCS#7 padding.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <param name="iv">Optional initialization vector. If null, a cryptographically random initialization vector will be generated using <see cref="RandomNumberGenerator"/>.</param>
        /// <returns>An instance of the <see cref="EncryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256CbcPad"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="plaintext"/> is null.</exception>
        public static EncryptOptions A256CbcPadOptions(byte[] plaintext, byte[] iv = null) =>
            new EncryptOptions(EncryptionAlgorithm.A256CbcPad, plaintext, iv, null);

        internal EncryptOptions(EncryptionAlgorithm algorithm, byte[] plaintext) :
            this(algorithm, plaintext, null, null)
        {
        }

        internal EncryptOptions(EncryptionAlgorithm algorithm, byte[] plaintext, byte[] iv, byte[] additionalAuthenticatedData)
        {
            Argument.AssertNotNull(plaintext, nameof(plaintext));

            Algorithm = algorithm;
            Plaintext = plaintext;
            Iv = iv;
            AdditionalAuthenticatedData = additionalAuthenticatedData;
        }

        /// <summary>
        /// Gets the <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public EncryptionAlgorithm Algorithm { get; }

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

        internal void Initialize()
        {
            // Initialize AES-CBC IV if not specified. This will be used locally or sent remotely.
            // The nonce for AES-GCM is only generated for local operations and will be rejected by the service.
            if (Iv == null && Algorithm.GetAesCbcEncryptionAlgorithm() != null)
            {
                Iv = Crypto.GenerateIv(AesCbc.BlockByteSize);
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString("alg", Algorithm.ToString());
            json.WriteString("value", Base64Url.Encode(Plaintext));

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
