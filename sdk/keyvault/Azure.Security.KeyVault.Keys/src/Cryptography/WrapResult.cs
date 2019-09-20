// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about a wrap operation
    /// </summary>
    public class WrapResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string EncryptedKeyPropertyName = "value";

        /// <summary>
        /// The <see cref="KeyBase.Id"/> of the <see cref="Key"/> used to wrap the <see cref="EncryptedKey"/>. This must be stored alongside the <see cref="EncryptedKey"/> as the same key must be used to unwrap it.
        /// </summary>
        public string KeyId { get; private set; }

        /// <summary>
        /// The wrapped key
        /// </summary>
        public byte[] EncryptedKey { get; private set; }

        /// <summary>
        /// The algorithm used. This must be stored alongside the <see cref="EncryptedKey"/> as the same key must be used to unwrap it.
        /// </summary>
        public KeyWrapAlgorithm Algorithm { get; internal set; }

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
