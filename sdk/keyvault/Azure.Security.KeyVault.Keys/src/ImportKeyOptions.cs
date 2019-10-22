// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The key import parameters.
    /// </summary>
    public class ImportKeyOptions : IJsonSerializable
    {
        private const string KeyPropertyName = "key";
        private const string TagsPropertyName = "tags";
        private const string HsmPropertyName = "hsm";

        private static readonly JsonEncodedText s_keyPropertyNameBytes = JsonEncodedText.Encode(KeyPropertyName);
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);
        private static readonly JsonEncodedText s_hsmPropertyNameBytes = JsonEncodedText.Encode(HsmPropertyName);

        /// <summary>
        /// Initializes a new instance of the KeyImportOptions class.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <param name="keyMaterial">The <see cref="JsonWebKey"/> properties of the key.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="keyMaterial"/> is null.</exception>
        public ImportKeyOptions(string name, JsonWebKey keyMaterial)
        {
            Argument.AssertNotNull(keyMaterial, nameof(keyMaterial));

            Properties = new KeyProperties(name);
            Key = keyMaterial;
        }

        /// <summary>
        /// Key identifier.
        /// </summary>
        public Uri Id => Properties.Id;

        /// <summary>
        /// Name of the key.
        /// </summary>
        public string Name => Properties.Name;

        /// <summary>
        /// The cryptographic keys, the key type, and operations you can perform using the key.
        /// </summary>
        /// <remarks>
        /// See http://tools.ietf.org/html/draft-ietf-jose-json-web-key-18 for specifications of a JSON web key.
        /// </remarks>
        public JsonWebKey Key { get; }

        /// <summary>
        /// Whether it is a hardware-protected key (HSM) or software key.
        /// </summary>
        public bool? HardwareProtected { get; set; }

        /// <summary>
        /// Additional properties of the <see cref="KeyVaultKey"/>.
        /// </summary>
        public KeyProperties Properties { get; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Key != null)
            {
                json.WriteStartObject(s_keyPropertyNameBytes);

                Key.WriteProperties(json);

                json.WriteEndObject();
            }

            Properties.WriteAttributes(json);

            if (Properties._tags != null && Properties._tags.Count > 0)
            {
                json.WriteStartObject(s_tagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in Properties._tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }

            if (HardwareProtected.HasValue)
            {
                json.WriteBoolean(s_hsmPropertyNameBytes, HardwareProtected.Value);
            }
        }
    }
}
