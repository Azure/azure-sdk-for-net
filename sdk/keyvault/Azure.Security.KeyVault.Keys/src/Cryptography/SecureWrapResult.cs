// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about a secure wrap operation.
    /// </summary>
    public class SecureWrapResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string EncryptedKeyPropertyName = "value";

        internal SecureWrapResult()
        {
        }

        /// <summary>
        /// Gets the key identifier of the <see cref="KeyVaultKey"/> used to wrap the <see cref="EncryptedKey"/>. This must be stored alongside the <see cref="EncryptedKey"/> as the same key must be used to unwrap it.
        /// </summary>
        public string KeyId { get; internal set; }

        /// <summary>
        /// Gets the wrapped key.
        /// </summary>
        public byte[] EncryptedKey { get; internal set; }

        /// <summary>
        /// Gets the <see cref="SecureKeyWrapAlgorithm"/> used. This must be stored alongside the <see cref="EncryptedKey"/> as the same algorithm must be used to unwrap it.
        /// </summary>
        public SecureKeyWrapAlgorithm Algorithm { get; internal set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyIdPropertyName:
                        KeyId = prop.Value.GetString();
                        break;
                    case EncryptedKeyPropertyName:
                        EncryptedKey = Base64Url.Decode(prop.Value.GetString());
                        break;
                }
            }
        }
    }
}
