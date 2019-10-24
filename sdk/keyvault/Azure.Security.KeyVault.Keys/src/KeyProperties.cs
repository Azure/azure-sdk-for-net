﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using Azure.Core;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// <see cref="KeyProperties"/> is the resource containing all the properties of the <see cref="KeyVaultKey"/> except <see cref="JsonWebKey"/> properties.
    /// </summary>
    public class KeyProperties : IJsonDeserializable
    {
        private const string KeyIdPropertyName = "kid";
        private const string ManagedPropertyName = "managed";
        private const string AttributesPropertyName = "attributes";
        private const string TagsPropertyName = "tags";

        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);

        internal Dictionary<string, string> _tags;

        internal KeyProperties() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyProperties"/> class.
        /// </summary>
        /// <param name="name">The name of the key.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public KeyProperties(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyProperties"/> class.
        /// </summary>
        /// <param name="id">The Id of the key.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is null.</exception>
        public KeyProperties(Uri id)
        {
            Argument.AssertNotNull(id, nameof(id));

            ParseId(id);
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
        public bool Managed { get; internal set; }

        /// <summary>
        /// A dictionary of tags with specific metadata about the key.
        /// </summary>
        public IDictionary<string, string> Tags => LazyInitializer.EnsureInitialized(ref _tags);

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
        public DateTimeOffset? ExpiresOn { get => _attributes.ExpiresOn; set => _attributes.ExpiresOn = value; }

        /// <summary>
        /// Creation time in UTC.
        /// </summary>
        public DateTimeOffset? CreatedOn { get => _attributes.CreatedOn; internal set => _attributes.CreatedOn = value; }

        /// <summary>
        /// Last updated time in UTC.
        /// </summary>
        public DateTimeOffset? UpdatedOn { get => _attributes.UpdatedOn; internal set => _attributes.UpdatedOn = value; }

        /// <summary>
        /// Reflects the deletion recovery level currently in effect for
        /// keys in the current vault. If it contains 'Purgeable', the
        /// key can be permanently deleted by a privileged user; otherwise,
        /// only the system can purge the key, at the end of the retention
        /// interval. Possible values include: 'Purgeable',
        /// 'Recoverable+Purgeable', 'Recoverable',
        /// 'Recoverable+ProtectedSubscription'
        /// </summary>
        public string RecoveryLevel { get => _attributes.RecoveryLevel; internal set => _attributes.RecoveryLevel = value; }

        /// <summary>
        /// Parses the key identifier into the <see cref="VaultUri"/>, <see cref="Name"/>, and <see cref="Version"/> of the key.
        /// </summary>
        /// <param name="idToParse">The key vault object identifier.</param>
        internal void ParseId(Uri idToParse)
        {
            // We expect an identifier with either 3 or 4 segments: host + collection + name [+ version]
            if (idToParse.Segments.Length != 3 && idToParse.Segments.Length != 4)
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. Bad number of segments: {1}", idToParse, idToParse.Segments.Length));

            if (!string.Equals(idToParse.Segments[1], "keys" + "/", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid ObjectIdentifier: {0}. segment [1] should be 'keys/', found '{1}'", idToParse, idToParse.Segments[1]));

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
                    string id = prop.Value.GetString();
                    Id = new Uri(id);
                    ParseId(Id);
                    break;
                case ManagedPropertyName:
                    Managed = prop.Value.GetBoolean();
                    break;
                case AttributesPropertyName:
                    _attributes.ReadProperties(prop.Value);
                    break;
                case TagsPropertyName:
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
