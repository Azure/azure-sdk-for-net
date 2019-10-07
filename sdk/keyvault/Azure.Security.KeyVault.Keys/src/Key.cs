// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// <see cref="Key"/> is the resource consisting of a value and its <see cref="Properties"/>.
    /// </summary>
    public class Key : IJsonDeserializable
    {
        private const string KeyPropertyName = "key";

        internal Key()
        {
            Properties = new KeyProperties();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        public Key(string name)
        {
            Properties = new KeyProperties(name);
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
        public JsonWebKey KeyMaterial { get; set; }

        /// <summary>
        /// Gets or sets the attributes of the <see cref="Key"/>.
        /// </summary>
        public KeyProperties Properties { get; }

        internal virtual void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case KeyPropertyName:
                    KeyMaterial = new JsonWebKey();
                    KeyMaterial.ReadProperties(prop.Value);

                    Uri id = new Uri(KeyMaterial.Id);
                    Properties.ParseId(id);
                    break;

                default:
                    Properties.ReadProperty(prop);
                    break;
            }
        }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }
    }
}
