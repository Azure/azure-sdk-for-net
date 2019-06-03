// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    public class KeyImportOptions : Key
    {
        public bool? Hsm { get; set; }

        public KeyImportOptions(string name) : base(name) { }

        public KeyImportOptions(string name, JsonWebKey keyMaterial)
            : base(name)
        {
            KeyMaterial = keyMaterial;
        }

        internal override void WriteProperties(ref Utf8JsonWriter json)
        {
            if (KeyMaterial != default)
            {
                KeyMaterial.WriteProperties(ref json);
            }
            if (Enabled.HasValue || NotBefore.HasValue || Expires.HasValue)
            {
                json.WriteStartObject("attributes");

                if (Enabled.HasValue)
                {
                    json.WriteBoolean("enabled", Enabled.Value);
                }

                if (NotBefore.HasValue)
                {
                    json.WriteNumber("nbf", NotBefore.Value.ToUnixTimeMilliseconds());
                }

                if (Expires.HasValue)
                {
                    json.WriteNumber("exp", Expires.Value.ToUnixTimeMilliseconds());
                }

                json.WriteEndObject();
            }
            if (Tags != null && Tags.Count > 0)
            {
                json.WriteStartObject("tags");

                foreach (var kvp in Tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }
            if (Hsm.HasValue)
            {
                json.WriteBoolean("hsm", Hsm.Value);
            }
        }
    }
}
