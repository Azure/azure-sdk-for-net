﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// Name of the key.
        /// </summary>
        public string Name => Properties.Name;

        /// <summary>
        /// Key identifier.
        /// </summary>
        public Uri Id => Properties.Id;

        /// <summary>
        /// Vault base URL.
        /// </summary>
        public Uri VaultUri => Properties.VaultUri;

        /// <summary>
        /// Version of the key.
        /// </summary>
        public string Version => Properties.Version;

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

        void IJsonDeserializable.ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }
    }
}
