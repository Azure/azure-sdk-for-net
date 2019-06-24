// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Key is the resource consisting of name, <see cref="JsonWebKey"/> properties and its attributes inherited from <see cref="KeyBase"/>.
    /// </summary>
    public class Key : KeyBase
    {
        /// <summary>
        /// As of http://tools.ietf.org/html/draft-ietf-jose-json-web-key-18
        /// </summary>
        public JsonWebKey KeyMaterial { get; set; }

        internal Key() { }

        /// <summary>
        /// Initializes a new instance of the Key class.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        public Key(string name) : base(name) { }

        internal override void ReadProperties(JsonElement json)
        {
            KeyMaterial = null;

            if (json.TryGetProperty("key", out JsonElement key))
            {
                KeyMaterial = new JsonWebKey();
                KeyMaterial.ReadProperties(key);
                ParseId(KeyMaterial.KeyId);
            }

            base.ReadProperties(json);
        }
    }
}
