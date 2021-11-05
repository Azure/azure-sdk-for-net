// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about a verify operation.
    /// </summary>
    public class VerifyResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string ValidPropertyName = "value";

        internal VerifyResult()
        {
        }

        /// <summary>
        /// Gets the key identifier of the <see cref="KeyVaultKey"/> used to verify.
        /// </summary>
        public string KeyId { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the specified signature is valid.
        /// </summary>
        public bool IsValid { get; internal set; }

        /// <summary>
        /// Gets the <see cref="SignatureAlgorithm"/>.
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
                    case ValidPropertyName:
                        IsValid = prop.Value.GetBoolean();
                        break;
                }
            }
        }
    }
}
