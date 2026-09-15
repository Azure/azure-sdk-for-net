// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about a secure unwrap operation.
    /// </summary>
    public class SecureUnwrapResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string KeyPropertyName = "value";

        internal SecureUnwrapResult()
        {
        }

        /// <summary>
        /// Gets the key identifier of the <see cref="KeyVaultKey"/> used to unwrap the key.
        /// </summary>
        public string KeyId { get; internal set; }

        /// <summary>
        /// Gets the unwrapped key.
        /// </summary>
        public byte[] Key { get; internal set; }

        /// <summary>
        /// Gets the <see cref="SecureKeyWrapAlgorithm"/> used.
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
                    case KeyPropertyName:
                        Key = Base64Url.Decode(prop.Value.GetString());
                        break;
                }
            }
        }
    }
}
