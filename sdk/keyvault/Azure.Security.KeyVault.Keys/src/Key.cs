// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    public class Key : KeyBase
    {
        public JsonWebKey KeyMaterial { get; set; }

        internal Key() { }

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
