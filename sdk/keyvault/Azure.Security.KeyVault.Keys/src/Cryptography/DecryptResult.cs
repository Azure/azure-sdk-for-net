// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about an dencryption operation
    /// </summary>
    public class DecryptResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string PlaintextPropertyName = "value";

        /// <summary>
        /// The <see cref="KeyBase.Id"/> of the <see cref="Key"/> used to decrypt
        /// </summary>
        public string KeyId { get; private set; }

        /// <summary>
        /// The decrypted data
        /// </summary>
        public byte[] Plaintext { get; private set; }

        /// <summary>
        /// The algorithm used for the decryption
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
                    case PlaintextPropertyName:
                        Plaintext = Base64Url.Decode(prop.Value.GetString());
                        break;
                }
            }
        }
    }
}
