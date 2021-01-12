// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about a decrypt operation.
    /// </summary>
    public class DecryptResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string PlaintextPropertyName = "value";

        internal DecryptResult()
        {
        }

        /// <summary>
        /// Gets the key identifier of the <see cref="KeyVaultKey"/> used to decrypt.
        /// </summary>
        public string KeyId { get; internal set; }

        /// <summary>
        /// Gets the decrypted data.
        /// </summary>
        public byte[] Plaintext { get; internal set; }

        /// <summary>
        /// Gets the <see cref="EncryptionAlgorithm"/> used for the decryption.
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
