// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private const string ReleasePolicyPropertyName = "release_policy";

        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private static readonly JsonEncodedText s_releasePolicyPropertyNameBytes = JsonEncodedText.Encode(ReleasePolicyPropertyName);

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
        /// <param name="id">The identifier of the key.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is null.</exception>
        public KeyProperties(Uri id)
        {
            Argument.AssertNotNull(id, nameof(id));

            ParseId(id);
        }

        private KeyAttributes _attributes;

        /// <summary>
        /// Gets the name of the key.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the key identifier.
        /// </summary>
        public Uri Id { get; internal set; }

        /// <summary>
        /// Gets the Key Vault base <see cref="Uri"/>.
        /// </summary>
        public Uri VaultUri { get; internal set; }

        /// <summary>
        /// Gets the version of the key.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the key's lifetime is managed by Key Vault.
        /// If this key is backing a Key Vault certificate, the value will be true.
        /// </summary>
        public bool Managed { get; internal set; }

        /// <summary>
        /// Gets a dictionary of tags with specific metadata about the key.
        /// </summary>
        public IDictionary<string, string> Tags => LazyInitializer.EnsureInitialized(ref _tags);

        /// <summary>
        /// Gets or sets a value indicating whether the key is enabled and useable for cryptographic operations.
        /// </summary>
        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }

        /// <summary>
        /// Gets or sets a <see cref="DateTimeOffset"/> indicating when the key will be valid and can be used for cryptographic operations.
        /// </summary>
        public DateTimeOffset? NotBefore { get => _attributes.NotBefore; set => _attributes.NotBefore = value; }

        /// <summary>
        /// Gets or sets a <see cref="DateTimeOffset"/> indicating when the key will expire and cannot be used for cryptographic operations.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get => _attributes.ExpiresOn; set => _attributes.ExpiresOn = value; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the key was created.
        /// </summary>
        public DateTimeOffset? CreatedOn { get => _attributes.CreatedOn; internal set => _attributes.CreatedOn = value; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the key was updated.
        /// </summary>
        public DateTimeOffset? UpdatedOn { get => _attributes.UpdatedOn; internal set => _attributes.UpdatedOn = value; }

        /// <summary>
        /// Gets the number of days a key is retained before being deleted for a soft delete-enabled Key Vault.
        /// </summary>
        public int? RecoverableDays { get => _attributes.RecoverableDays; internal set => _attributes.RecoverableDays = value; }

        /// <summary>
        /// Gets the recovery level currently in effect for keys in the Key Vault.
        /// If <c>Purgeable</c>, the key can be permanently deleted by an authorized user;
        /// otherwise, only the service can purge the keys at the end of the retention interval.
        /// </summary>
        /// <value>Possible values include <c>Purgeable</c>, <c>Recoverable+Purgeable</c>, <c>Recoverable</c>, and <c>Recoverable+ProtectedSubscription</c>.</value>
        public string RecoveryLevel { get => _attributes.RecoveryLevel; internal set => _attributes.RecoveryLevel = value; }

        /// <summary>
        /// Gets or sets a value indicating whether the private key can be exported.
        /// </summary>
        public bool? Exportable { get => _attributes.Exportable; set => _attributes.Exportable = value; }

        /// <summary>
        /// Gets or sets the policy rules under which the key can be exported.
        /// </summary>
        public KeyReleasePolicy ReleasePolicy { get; set; }

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
                case ReleasePolicyPropertyName:
                    ReleasePolicy = new KeyReleasePolicy();
                    ReleasePolicy.ReadProperties(prop.Value);
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

            if (ReleasePolicy != null)
            {
                json.WriteStartObject(s_releasePolicyPropertyNameBytes);

                ReleasePolicy.WriteProperties(json);

                json.WriteEndObject();
            }
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);
    }
}
