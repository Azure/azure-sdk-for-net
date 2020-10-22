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
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.Rsa15"/> encryption algorithm.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.Rsa15"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> is null.</exception>
        public static DecryptOptions Rsa15Options(byte[] ciphertext) =>
            new DecryptOptions(EncryptionAlgorithm.Rsa15, ciphertext);

        /// <summary>
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.RsaOaep"/> encryption algorithm.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.RsaOaep"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> is null.</exception>
        public static DecryptOptions RsaOaepOptions(byte[] ciphertext) =>
            new DecryptOptions(EncryptionAlgorithm.RsaOaep, ciphertext);

        /// <summary>
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.RsaOaep256"/> encryption algorithm.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.RsaOaep256"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> is null.</exception>
        public static DecryptOptions RsaOaep256Options(byte[] ciphertext) =>
            new DecryptOptions(EncryptionAlgorithm.RsaOaep256, ciphertext);

        /// <summary>
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128Gcm"/> encryption algorithm.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <param name="iv">The initialization vector (or nonce) generated during encryption.</param>
        /// <param name="authenticationTag">The authentication tag generated during encryption.</param>
        /// <param name="additionalAuthenticationData">Optional data that is authenticated but not encrypted.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128Gcm"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/>, <paramref name="iv"/>, or <paramref name="authenticationTag"/> is null.</exception>
        public static DecryptOptions A128GcmOptions(byte[] ciphertext, byte[] iv, byte[] authenticationTag, byte[] additionalAuthenticationData = null) =>
            new DecryptOptions(EncryptionAlgorithm.A128Gcm, ciphertext, iv, authenticationTag, additionalAuthenticationData);

        /// <summary>
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192Gcm"/> encryption algorithm.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <param name="iv">The initialization vector (or nonce) generated during encryption.</param>
        /// <param name="authenticationTag">The authentication tag generated during encryption.</param>
        /// <param name="additionalAuthenticationData">Optional data that is authenticated but not encrypted.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192Gcm"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/>, <paramref name="iv"/>, or <paramref name="authenticationTag"/> is null.</exception>
        public static DecryptOptions A192GcmOptions(byte[] ciphertext, byte[] iv, byte[] authenticationTag, byte[] additionalAuthenticationData = null) =>
            new DecryptOptions(EncryptionAlgorithm.A192Gcm, ciphertext, iv, authenticationTag, additionalAuthenticationData);

        /// <summary>
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256Gcm"/> encryption algorithm.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <param name="iv">The initialization vector (or nonce) generated during encryption.</param>
        /// <param name="authenticationTag">The authentication tag generated during encryption.</param>
        /// <param name="additionalAuthenticationData">Optional data that is authenticated but not encrypted.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256Gcm"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/>, <paramref name="iv"/>, or <paramref name="authenticationTag"/> is null.</exception>
        public static DecryptOptions A256GcmOptions(byte[] ciphertext, byte[] iv, byte[] authenticationTag, byte[] additionalAuthenticationData = null) =>
            new DecryptOptions(EncryptionAlgorithm.A256Gcm, ciphertext, iv, authenticationTag, additionalAuthenticationData);

        /// <summary>
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128Cbc"/> encryption algorithm.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <param name="iv">The initialization vector used during encryption.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128Cbc"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> or <paramref name="iv"/> is null.</exception>
        public static DecryptOptions A128CbcOptions(byte[] ciphertext, byte[] iv) =>
            new DecryptOptions(EncryptionAlgorithm.A128Cbc, ciphertext, iv);

        /// <summary>
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192Cbc"/> encryption algorithm.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <param name="iv">The initialization vector used during encryption.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192Cbc"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> or <paramref name="iv"/> is null.</exception>
        public static DecryptOptions A192CbcOptions(byte[] ciphertext, byte[] iv) =>
            new DecryptOptions(EncryptionAlgorithm.A192Cbc, ciphertext, iv);

        /// <summary>
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256Cbc"/> encryption algorithm.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <param name="iv">The initialization vector used during encryption.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256Cbc"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> or <paramref name="iv"/> is null.</exception>
        public static DecryptOptions A256CbcOptions(byte[] ciphertext, byte[] iv) =>
            new DecryptOptions(EncryptionAlgorithm.A256Cbc, ciphertext, iv);

        /// <summary>
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128CbcPad"/> encryption algorithm with PKCS#7 padding.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <param name="iv">The initialization vector used during encryption.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A128CbcPad"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> or <paramref name="iv"/> is null.</exception>
        public static DecryptOptions A128CbcPadOptions(byte[] ciphertext, byte[] iv) =>
            new DecryptOptions(EncryptionAlgorithm.A128CbcPad, ciphertext, iv);

        /// <summary>
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192CbcPad"/> encryption algorithm with PKCS#7 padding.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <param name="iv">The initialization vector used during encryption.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A192CbcPad"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> or <paramref name="iv"/> is null.</exception>
        public static DecryptOptions A192CbcPadOptions(byte[] ciphertext, byte[] iv) =>
            new DecryptOptions(EncryptionAlgorithm.A192CbcPad, ciphertext, iv);

        /// <summary>
        /// Creates an instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256CbcPad"/> encryption algorithm with PKCS#7 padding.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt.</param>
        /// <param name="iv">The initialization vector used during encryption.</param>
        /// <returns>An instance of the <see cref="DecryptOptions"/> class for the <see cref="EncryptionAlgorithm.A256CbcPad"/> encryption algorithm.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> or <paramref name="iv"/> is null.</exception>
        public static DecryptOptions A256CbcPadOptions(byte[] ciphertext, byte[] iv) =>
            new DecryptOptions(EncryptionAlgorithm.A256CbcPad, ciphertext, iv);

        internal DecryptOptions(EncryptionAlgorithm algorithm, byte[] ciphertext)
        {
            Argument.AssertNotNull(ciphertext, nameof(ciphertext));

            Algorithm = algorithm;
            Ciphertext = ciphertext;
        }

        internal DecryptOptions(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv)
        {
            Argument.AssertNotNull(ciphertext, nameof(ciphertext));
            Argument.AssertNotNull(iv, nameof(iv));

            Algorithm = algorithm;
            Ciphertext = ciphertext;
            Iv = iv;
        }

        internal DecryptOptions(EncryptionAlgorithm algorithm, byte[] ciphertext, byte[] iv, byte[] authenticationTag, byte[] additionalAuthenticatedData)
        {
            Argument.AssertNotNull(ciphertext, nameof(ciphertext));
            Argument.AssertNotNull(iv, nameof(iv));
            Argument.AssertNotNull(authenticationTag, nameof(authenticationTag));

            Algorithm = algorithm;
            Ciphertext = ciphertext;
            Iv = iv;
            AuthenticationTag = authenticationTag;
            AdditionalAuthenticatedData = additionalAuthenticatedData;
        }

        /// <summary>
        /// Gets or sets the <see cref="EncryptionAlgorithm"/>.
        /// </summary>
        public EncryptionAlgorithm Algorithm { get; }

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

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            json.WriteString("alg", Algorithm.ToString());
            json.WriteString("value", Base64Url.Encode(Ciphertext));

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
