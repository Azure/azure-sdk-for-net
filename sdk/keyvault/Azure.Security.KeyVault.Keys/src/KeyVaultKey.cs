// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// <see cref="KeyVaultKey"/> is the resource consisting of a value and its <see cref="Properties"/>.
    /// </summary>
    public class KeyVaultKey : IJsonDeserializable
    {
        private const string KeyPropertyName = "key";

        internal KeyVaultKey(KeyProperties properties = null)
        {
            Properties = properties ?? new KeyProperties();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultKey"/> class.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        public KeyVaultKey(string name)
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
        public JsonWebKey Key { get; internal set; }

        /// <summary>
        /// Gets or sets the <see cref="KeyType"/> for this <see cref="JsonWebKey"/>.
        /// </summary>
        public KeyType KeyType => Key.KeyType;

        /// <summary>
        /// Gets supported key operations.
        /// </summary>
        public IReadOnlyCollection<KeyOperation> KeyOperations => Key.KeyOps;

        /// <summary>
        /// Additional properties of the <see cref="KeyVaultKey"/>.
        /// </summary>
        public KeyProperties Properties { get; }

        internal virtual void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case KeyPropertyName:
                    Key = new JsonWebKey();
                    Key.ReadProperties(prop.Value);

                    Uri id = new Uri(Key.Id);
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
