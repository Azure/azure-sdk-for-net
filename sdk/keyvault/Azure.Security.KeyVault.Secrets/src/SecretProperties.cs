// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// SecretBase is the resource containing all the properties of the secret except its value.
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
        private VaultAttributes _attributes;

        internal SecretProperties()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SecretBase class.
        /// </summary>
        /// <param name="name">The name of the secret.</param>
        public SecretProperties(string name)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            _identifier.Name = name;
        }

        /// <summary>
        /// Secret identifier.
        /// </summary>
        public Uri Id => _identifier.Id;

        /// <summary>
        /// Vault base URL.
        /// </summary>
        public Uri Vault => _identifier.Vault;

        /// <summary>
        /// Name of the secret.
        /// </summary>
        public string Name => _identifier.Name;

        /// <summary>
        /// Version of the secret.
        /// </summary>
        public string Version => _identifier.Version;

        /// <summary>
        /// Content type of the secret value such as a password.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Set to true if the secret's lifetime is managed by key vault. If this
        /// is a secret backing a KV certificate, then managed will be true.
        /// </summary>
        public bool? Managed { get; private set; }

        /// <summary>
        /// If this is a secret backing a KV certificate, then this field specifies
        /// the corresponding key backing the KV certificate.
        /// </summary>
        public string KeyId { get; private set; }

        /// <summary>
        /// Specifies whether the secret is enabled and useable.
        /// </summary>
        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }

        /// <summary>
        /// Identifies the time (in UTC) before which the secret data should not be retrieved.
        /// </summary>
        public DateTimeOffset? NotBefore { get => _attributes.NotBefore; set => _attributes.NotBefore = value; }

        /// <summary>
        /// Identifies the expiration time (in UTC) on or after which the secret data should not be retrieved.
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
        /// secrets in the current vault. If it contains 'Purgeable', the
        /// secret can be permanently deleted by a privileged user; otherwise,
        /// only the system can purge the secret, at the end of the retention
        /// interval. Possible values include: 'Purgeable',
        /// 'Recoverable+Purgeable', 'Recoverable',
        /// 'Recoverable+ProtectedSubscription'
        /// </summary>
        public string RecoveryLevel => _attributes.RecoveryLevel;

        /// <summary>
        /// A dictionary of tags with specific metadata about the secret.
        /// </summary>
        public IDictionary<string, string> Tags { get; private set; } = new Dictionary<string, string>();

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
                    KeyId = prop.Value.GetString();
                    break;

                case ManagedPropertyName:
                    Managed = prop.Value.GetBoolean();
                    break;

                case AttributesPropertyName:
                    _attributes.ReadProperties(prop.Value);
                    break;

                case TagsPropertyName:
                    Tags = new Dictionary<string, string>();
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

            if (_attributes.Enabled.HasValue || _attributes.NotBefore.HasValue || _attributes.Expires.HasValue)
            {
                json.WriteStartObject(s_attributesPropertyNameBytes);

                _attributes.WriteProperties(json);

                json.WriteEndObject();
            }

            if (Tags != null && Tags.Count > 0)
            {
                json.WriteStartObject(s_tagsPropertyNameBytes);

                foreach (KeyValuePair<string, string> kvp in Tags)
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
