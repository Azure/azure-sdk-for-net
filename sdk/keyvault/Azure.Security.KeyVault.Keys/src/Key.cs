// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// <see cref="Key"/> is the resource consisting of a value and its <see cref="Properties"/>.
    /// </summary>
    public class Key : IJsonDeserializable, IJsonSerializable
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
        /// As of http://tools.ietf.org/html/draft-ietf-jose-json-web-key-18
        /// </summary>
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
                    Properties.ParseId(KeyMaterial.KeyId);
                    break;

                default:
                    Properties.ReadProperty(prop);
                    break;
            }
        }

        internal virtual void WriteProperties(Utf8JsonWriter json)
        {
        }

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
