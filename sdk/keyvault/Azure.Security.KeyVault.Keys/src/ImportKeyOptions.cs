// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The properties needed to import a key.
    /// </summary>
    public class ImportKeyOptions : IJsonSerializable
    {
        private const string KeyPropertyName = "key";
        private const string TagsPropertyName = "tags";
        private const string HsmPropertyName = "hsm";
        private const string ReleasePolicyPropertyName = "release_policy";

        private static readonly JsonEncodedText s_keyPropertyNameBytes = JsonEncodedText.Encode(KeyPropertyName);
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);
        private static readonly JsonEncodedText s_hsmPropertyNameBytes = JsonEncodedText.Encode(HsmPropertyName);
        private static readonly JsonEncodedText s_releasePolicyPropertyNameBytes = JsonEncodedText.Encode(ReleasePolicyPropertyName);

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportKeyOptions"/> class.
        /// </summary>
        /// <param name="name">The name of the key to import.</param>
        /// <param name="keyMaterial">A <see cref="JsonWebKey"/> containing properties of the key to import.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="keyMaterial"/> is null.</exception>
        public ImportKeyOptions(string name, JsonWebKey keyMaterial)
        {
            Argument.AssertNotNull(keyMaterial, nameof(keyMaterial));

            Properties = new KeyProperties(name);
            Key = keyMaterial;
        }

        /// <summary>
        /// Gets the name of the key to import.
        /// </summary>
        public string Name => Properties.Name;

        /// <summary>
        /// Gets the cryptographic key, the key type, and the operations you can perform using the key.
        /// </summary>
        /// <remarks>
        /// See http://tools.ietf.org/html/draft-ietf-jose-json-web-key-18 for specifications of a JSON web key.
        /// </remarks>
        public JsonWebKey Key { get; }

        /// <summary>
        /// Gets or sets a value indicating whether to import the key into a hardware security module (HSM).
        /// </summary>
        public bool? HardwareProtected { get; set; }

        /// <summary>
        /// Gets or sets the policy rules under which the key can be exported.
        /// </summary>
        public KeyReleasePolicy ReleasePolicy { get; set; }

        /// <summary>
        /// Gets additional properties of the <see cref="KeyVaultKey"/>.
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

            if (ReleasePolicy != null)
            {
                json.WriteStartObject(s_releasePolicyPropertyNameBytes);

                ReleasePolicy.WriteProperties(json);

                json.WriteEndObject();
            }
        }
    }
}
