// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The key import parameters.
    /// </summary>
    public class KeyImportOptions : Key
    {
        /// <summary>
        /// Whether it is a hardware key (HSM) or software key.
        /// </summary>
        public bool? Hsm { get; set; }

        /// <summary>
        /// Initializes a new instance of the KeyImportOptions class.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <param name="keyMaterial">The <see cref="JsonWebKey"/> properties of the key.</param>
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
            KeyMaterial?.WriteProperties(json);

            if (Enabled.HasValue || NotBefore.HasValue || Expires.HasValue)
            {
                json.WriteStartObject(AttributesPropertyNameBytes);

                if (Enabled.HasValue)
                {
                    json.WriteBoolean(EnabledPropertyNameBytes, Enabled.Value);
                }

                if (NotBefore.HasValue)
                {
                    json.WriteNumber(NotBeforePropertyNameBytes, NotBefore.Value.ToUnixTimeSeconds());
                }

                if (Expires.HasValue)
                {
                    json.WriteNumber(ExpiresPropertyNameBytes, Expires.Value.ToUnixTimeSeconds());
                }

                json.WriteEndObject();
            }
            if (Tags != null && Tags.Count > 0)
            {
                json.WriteStartObject(TagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in Tags)
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
