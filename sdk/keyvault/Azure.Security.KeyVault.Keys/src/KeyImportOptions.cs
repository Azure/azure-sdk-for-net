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

        private const string AttributesPropertyName = "attributes";
        private static readonly JsonEncodedText AttributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private const string EnabledPropertyName = "enabled";
        private static readonly JsonEncodedText EnabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);
        private const string NotBeforePropertyName = "nbf";
        private static readonly JsonEncodedText NotBeforePropertyNameBytes = JsonEncodedText.Encode(NotBeforePropertyName);
        private const string ExpiresPropertyName = "exp";
        private static readonly JsonEncodedText ExpiresPropertyNameBytes = JsonEncodedText.Encode(ExpiresPropertyName);
        private const string TagsPropertyName = "tags";
        private static readonly JsonEncodedText TagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);
        private const string HsmPropertyName = "hsm";
        private static readonly JsonEncodedText HsmPropertyNameBytes = JsonEncodedText.Encode(HsmPropertyName);

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            if (KeyMaterial != default)
            {
                KeyMaterial.WriteProperties(json);
            }
            if (Enabled.HasValue || NotBefore.HasValue || Expires.HasValue)
            {
                json.WriteStartObject(AttributesPropertyNameBytes);

                if (Enabled.HasValue)
                {
                    json.WriteBoolean(EnabledPropertyNameBytes, Enabled.Value);
                }

                if (NotBefore.HasValue)
                {
                    json.WriteNumber(NotBeforePropertyNameBytes, NotBefore.Value.ToUnixTimeMilliseconds());
                }

                if (Expires.HasValue)
                {
                    json.WriteNumber(ExpiresPropertyNameBytes, Expires.Value.ToUnixTimeMilliseconds());
                }

                json.WriteEndObject();
            }
            if (Tags != null && Tags.Count > 0)
            {
                json.WriteStartObject(TagsPropertyNameBytes);

                foreach (var kvp in Tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }
            if (Hsm.HasValue)
            {
                json.WriteBoolean(HsmPropertyNameBytes, Hsm.Value);
            }
        }
    }
}
