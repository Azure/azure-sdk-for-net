// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        internal EncryptResult()
        {
        }

        /// <summary>
        /// Gets the <see cref="KeyProperties.Id"/> of the <see cref="KeyVaultKey"/> used to encrypt. This must be stored alongside the <see cref="Ciphertext"/> as the same key must be used to decrypt it.
        /// </summary>
        public string KeyId { get; internal set; }

        /// <summary>
        /// Gets the ciphertext that is the result of the encryption.
        /// </summary>
        public byte[] Ciphertext { get; internal set; }

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
                }
            }
        }
    }
}
