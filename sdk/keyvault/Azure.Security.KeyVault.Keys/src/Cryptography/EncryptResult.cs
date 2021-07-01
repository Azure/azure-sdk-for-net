// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about an encryption operation.
    /// </summary>
    public class EncryptResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string CiphertextPropertyName = "value";
        private const string IvPropertyName = "iv";
        private const string AuthenticationTagPropertyName = "tag";
        private const string AdditionalAuthenticatedDataPropertyName = "aad";

        internal EncryptResult()
        {
        }

        /// <summary>
        /// Gets the key identifier of the <see cref="KeyVaultKey"/> used to encrypt. This must be stored alongside the <see cref="Ciphertext"/> as the same key must be used to decrypt it.
        /// </summary>
        public string KeyId { get; internal set; }

        /// <summary>
        /// Gets the ciphertext that is the result of the encryption.
        /// </summary>
        public byte[] Ciphertext { get; internal set; }

        /// <summary>
        /// Gets the initialization vector for encryption.
        /// </summary>
        public byte[] Iv { get; internal set; }

        /// <summary>
        /// Gets the authentication tag resulting from encryption with a symmetric key including <see cref="EncryptionAlgorithm.A128Gcm"/>, <see cref="EncryptionAlgorithm.A192Gcm"/>, or <see cref="EncryptionAlgorithm.A256Gcm"/>.
        /// </summary>
        public byte[] AuthenticationTag { get; internal set; }

        /// <summary>
        /// Gets additional data that is authenticated during decryption but not encrypted.
        /// </summary>
        public byte[] AdditionalAuthenticatedData { get; internal set; }

        /// <summary>
        /// Gets the <see cref="EncryptionAlgorithm"/> used for encryption. This must be stored alongside the <see cref="Ciphertext"/> as the same algorithm must be used to decrypt it.
        /// </summary>
        public EncryptionAlgorithm Algorithm { get; internal set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyIdPropertyName:
                        KeyId = prop.Value.GetString();
                        break;
                    case CiphertextPropertyName:
                        Ciphertext = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case IvPropertyName:
                        Iv = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case AuthenticationTagPropertyName:
                        AuthenticationTag = Base64Url.Decode(prop.Value.GetString());
                        break;
                    case AdditionalAuthenticatedDataPropertyName:
                        AdditionalAuthenticatedData = Base64Url.Decode(prop.Value.GetString());
                        break;
                }
            }
        }
    }
}
