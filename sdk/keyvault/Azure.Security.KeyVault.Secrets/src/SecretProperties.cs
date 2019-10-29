// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure.Core;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// <see cref="SecretProperties"/> is the resource containing all the properties of the secret except its value.
    /// </summary>
    public class SecretProperties : IJsonDeserializable, IJsonSerializable
    {
        private const string IdPropertyName = "id";
        private const string ContentTypePropertyName = "contentType";
        private const string KidPropertyName = "kid";
        private const string ManagedPropertyName = "managed";
        private const string AttributesPropertyName = "attributes";
        private const string TagsPropertyName = "tags";

        private static readonly JsonEncodedText s_contentTypePropertyNameBytes = JsonEncodedText.Encode(ContentTypePropertyName);
        private static readonly JsonEncodedText s_attributesPropertyNameBytes = JsonEncodedText.Encode(AttributesPropertyName);
        private static readonly JsonEncodedText s_tagsPropertyNameBytes = JsonEncodedText.Encode(TagsPropertyName);

        private ObjectId _identifier;
        private SecretAttributes _attributes;
        private Dictionary<string, string> _tags;
        private string _keyId;

        internal SecretProperties()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretProperties"/> class.
        /// </summary>
        /// <param name="name">The name of the secret.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public SecretProperties(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            _identifier.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretProperties"/> class.
        /// </summary>
        /// <param name="id">The Id of the secret.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> is null.</exception>
        public SecretProperties(Uri id)
        {
            Argument.AssertNotNull(id, nameof(id));

            _identifier.ParseId("secrets", id);
        }

        /// <summary>
        /// Gets the secret identifier.
        /// </summary>
        public Uri Id { get => _identifier.Id; internal set => _identifier.Id = value; }

        /// <summary>
        /// Gets the Key Vault base <see cref="Uri"/>.
        /// </summary>
        public Uri VaultUri { get => _identifier.VaultUri; internal set => _identifier.VaultUri = value; }

        /// <summary>
        /// Gets the name of the secret.
        /// </summary>
        public string Name { get => _identifier.Name; internal set => _identifier.Name = value; }

        /// <summary>
        /// Gets the version of the secret.
        /// </summary>
        public string Version { get => _identifier.Version; internal set => _identifier.Version = value; }

        /// <summary>
        /// Gets or sets the content type of the secret value such as "text/plain" for a password.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets a value indicating whether the secret's lifetime is managed by Key Vault.
        /// If this secret is backing a Key Vault certificate, the value will be true.
        /// </summary>
        public bool Managed { get; internal set; }

        /// <summary>
        /// Gets the key identifier of a key backing a Key Vault certificate if this secret is backing a Key Vault certifcate.
        /// </summary>
        public Uri KeyId
        {
            get => _keyId is null ? null : new Uri(_keyId);
            internal set => _keyId = value?.ToString();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the secret is enabled and useable.
        /// </summary>
        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }

        /// <summary>
        /// Gets or sets a <see cref="DateTimeOffset"/> of when the secret will be valid and can be used.
        /// </summary>
        public DateTimeOffset? NotBefore { get => _attributes.NotBefore; set => _attributes.NotBefore = value; }

        /// <summary>
        /// Gets or sets a <see cref="DateTimeOffset"/> of when the secret will expire and cannot be used.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get => _attributes.ExpiresOn; set => _attributes.ExpiresOn = value; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> of when the secret was created.
        /// </summary>
        public DateTimeOffset? CreatedOn { get => _attributes.CreatedOn; internal set => _attributes.CreatedOn = value; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> of when the secret was updated.
        /// </summary>
        public DateTimeOffset? UpdatedOn { get => _attributes.UpdatedOn; internal set => _attributes.UpdatedOn = value; }

        /// <summary>
        /// Gets the recovery level currently in effect for secrets in the Key Vault.
        /// If "Purgeable", the secret can be permanently deleted by an authorized user;
        /// otherwise, only the service can purge the secret at the end of the retention interval.
        /// </summary>
        /// <value>Possible values include "Purgeable", "Recoverable+Purgeable", "Recoverable", and "Recoverable+ProtectedSubscription".</value>
        public string RecoveryLevel { get => _attributes.RecoveryLevel; internal set => _attributes.RecoveryLevel = value; }

        /// <summary>
        /// Gets a dictionary of tags with specific metadata about the secret.
        /// </summary>
        public IDictionary<string, string> Tags => LazyInitializer.EnsureInitialized(ref _tags);

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                ReadProperty(prop);
            }
        }

        internal void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case IdPropertyName:
                    _identifier.ParseId("secrets", prop.Value.GetString());
                    break;

                case ContentTypePropertyName:
                    ContentType = prop.Value.GetString();
                    break;

                case KidPropertyName:
                    _keyId = prop.Value.GetString();
                    break;

                case ManagedPropertyName:
                    Managed = prop.Value.GetBoolean();
                    break;

                case AttributesPropertyName:
                    _attributes.ReadProperties(prop.Value);
                    break;

                case TagsPropertyName:
                    foreach (JsonProperty tag in prop.Value.EnumerateObject())
                    {
                        Tags[tag.Name] = tag.Value.GetString();
                    }
                    break;
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (ContentType != null)
            {
                json.WriteString(s_contentTypePropertyNameBytes, ContentType);
            }

            if (_attributes.Enabled.HasValue || _attributes.NotBefore.HasValue || _attributes.ExpiresOn.HasValue)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);

                _attributes.WriteProperties(json);

                json.WriteEndObject();
            }

            if (_tags != null && _tags.Count > 0)
            {
                json.WriteStartObject(s_tagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in _tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }

            // KeyId is read-only don't serialize

            // Managed is read-only don't serialize
        }

        void IJsonDeserializable.ReadProperties(JsonElement json) => ReadProperties(json);

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json) => WriteProperties(json);
    }
}
