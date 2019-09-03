// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Represents information about an unwrap operation
    /// </summary>
    public class UnwrapResult : Model
    {
        private const string KeyIdPropertyName = "kid";
        private const string KeyPropertyName = "value";

        /// <summary>
        /// The <see cref="KeyBase.Id"/> of the <see cref="Key"/> used to uwrap
        /// </summary>
        public string KeyId { get; private set; }

        /// <summary>
        /// The unwrapped key
        /// </summary>
        public byte[] Key { get; private set; }

        /// <summary>
        /// The algorithm used
        /// </summary>
        public KeyWrapAlgorithm Algorithm { get; internal set; }

        internal override void ReadProperties(JsonElement json)
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

        internal override void WriteProperties(Utf8JsonWriter json) => throw new NotSupportedException();
    }
}
