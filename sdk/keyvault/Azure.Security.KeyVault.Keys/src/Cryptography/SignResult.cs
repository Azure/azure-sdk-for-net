// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about a sign operation.
    /// </summary>
    public class SignResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string SignaturePropertyName = "value";

        internal SignResult()
        {
        }

        /// <summary>
        /// Gets the key identifier of the <see cref="KeyVaultKey"/> used to sign. This must be stored alongside the <see cref="Signature"/> as the same key must be used to verify it.
        /// </summary>
        public string KeyId { get; internal set; }

        /// <summary>
        /// Gets the signature.
        /// </summary>
        public byte[] Signature { get; internal set; }

        /// <summary>
        /// Gets the algorithm used to sign. This must be stored alongside the <see cref="Signature"/> as the same algorithm must be used to verify it.
        /// </summary>
        public SignatureAlgorithm Algorithm { get; internal set; }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case KeyIdPropertyName:
                        KeyId = prop.Value.GetString();
                        break;
                    case SignaturePropertyName:
                        Signature = Base64Url.Decode(prop.Value.GetString());
                        break;
                }
            }
        }
    }
}
