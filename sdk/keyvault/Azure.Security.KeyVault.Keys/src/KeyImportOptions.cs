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
        private const string KeyPropertyName = "key";
        private const string TagsPropertyName = "tags";
        private const string HsmPropertyName = "hsm";

        private static readonly JsonEncodedText s_keyPropertyNameBytes = JsonEncodedText.Encode(KeyPropertyName);
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);
        private static readonly JsonEncodedText s_hsmPropertyNameBytes = JsonEncodedText.Encode(HsmPropertyName);

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

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            if (KeyMaterial != null)
            {
                json.WriteStartObject(s_keyPropertyNameBytes);

                KeyMaterial.WriteProperties(json);

                json.WriteEndObject();
            }

            Properties.WriteAttributes(json);

            IDictionary<string, string> tags = Properties.Tags;
            if (tags != null && tags.Count > 0)
            {
                json.WriteStartObject(s_tagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }

            if (Hsm.HasValue)
            {
                json.WriteBoolean(s_hsmPropertyNameBytes, Hsm.Value);
            }
        }
    }
}
