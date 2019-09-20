// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about a verify operation
    /// </summary>
    public class VerifyResult : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string ValidPropertyName = "value";

        /// <summary>
        /// The <see cref="KeyBase.Id"/> of the <see cref="Key"/> used to decrypt
        /// </summary>
        public string KeyId { get; internal set; }

        /// <summary>
        /// The result of the verification, true if the signature was valid otherwise false.
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// The algorithm used
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
