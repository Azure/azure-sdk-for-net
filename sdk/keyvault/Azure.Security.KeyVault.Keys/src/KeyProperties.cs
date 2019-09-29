// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// <see cref="KeyProperties"/> is the resource containing all the properties of the <see cref="Key"/> except <see cref="JsonWebKey"/> properties.
    /// </summary>
    public class KeyProperties : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string ManagedPropertyName = "managed";
        private const string AttributesPropertyName = "attributes";
        private const string TagsPropertyName = "tags";

        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);

        internal KeyProperties() { }

        /// <summary>
        /// Initializes a new instance of the KeyBase class.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        public KeyProperties(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        private KeyAttributes _attributes;

        /// <summary>
        /// Name of the key.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Key identifier.
        /// </summary>
        public Uri Id { get; internal set; }

        /// <summary>
        /// Vault base URL.
        /// </summary>
        public Uri VaultUri { get; internal set; }

        /// <summary>
        /// Version of the key.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// Set to true if the key's lifetime is managed by key vault. If this
        /// is a key backing a KV certificate, then managed will be true.
        /// </summary>
        public bool Managed { get; private set; }

        /// <summary>
        /// A dictionary of tags with specific metadata about the key.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Specifies whether the key is enabled and useable for cryptographic operations.
        /// </summary>
        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }

        /// <summary>
        /// Identifies the time (in UTC) before which the key must not be used for cryptographic operations.
        /// </summary>
        public DateTimeOffset? NotBefore { get => _attributes.NotBefore; set => _attributes.NotBefore = value; }

        /// <summary>
        /// Identifies the expiration time (in UTC) on or after which the key must not be used.
        /// </summary>
        public DateTimeOffset? Expires { get => _attributes.Expires; set => _attributes.Expires = value; }

        /// <summary>
        /// Creation time in UTC.
        /// </summary>
        public DateTimeOffset? Created => _attributes.Created;

        /// <summary>
        /// Last updated time in UTC.
        /// </summary>
        public DateTimeOffset? Updated => _attributes.Updated;

        /// <summary>
        /// Reflects the deletion recovery level currently in effect for
        /// keys in the current vault. If it contains 'Purgeable', the
        /// key can be permanently deleted by a privileged user; otherwise,
        /// only the system can purge the key, at the end of the retention
        /// interval. Possible values include: 'Purgeable',
        /// 'Recoverable+Purgeable', 'Recoverable',
        /// 'Recoverable+ProtectedSubscription'
        /// </summary>
        public string RecoveryLevel => _attributes.RecoveryLevel;

        /// <summary>
        /// Parses the key identifier into the vaultUri, name, and version of the key.
        /// </summary>
        /// <param name="id">The key vault object identifier.</param>
        internal void ParseId(string id)
        {
            var idToParse = new Uri(id, UriKind.Absolute);

            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (idToParse.Segments.Length != 3 && idToParse.Segments.Length != 4)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", id, idToParse.Segments.Length));

            if (!string.Equals(idToParse.Segments[1], "keys" + "/", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be 'keys/', found '{1}'", id, idToParse.Segments[1]));

            Id = idToParse;
            VaultUri = new Uri($"{idToParse.Scheme}://{idToParse.Authority}");
            Name = idToParse.Segments[2].Trim('/');
            Version = (idToParse.Segments.Length == 4) ? idToParse.Segments[3].TrimEnd('/') : null;
        }

        internal void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case KeyIdPropertyName:
                    ParseId(prop.Value.GetString());
                    break;
                case ManagedPropertyName:
                    Managed = prop.Value.GetBoolean();
                    break;
                case AttributesPropertyName:
                    _attributes.ReadProperties(prop.Value);
                    break;
                case TagsPropertyName:
                    Tags = new Dictionary<string, string>();
                    foreach (JsonProperty tagProp in prop.Value.EnumerateObject())
                    {
                        Tags[tagProp.Name] = tagProp.Value.GetString();
                    }
                    break;
            }
        }

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }

        internal void WriteAttributes(Utf8JsonWriter json)
        {
            if (_attributes.ShouldSerialize)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);

                _attributes.WriteProperties(json);

                json.WriteEndObject();
            }
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);
    }
}
