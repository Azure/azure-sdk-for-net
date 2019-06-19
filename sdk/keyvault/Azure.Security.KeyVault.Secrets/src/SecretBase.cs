// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// SecretBase is the resource containing all the properties of the secret except its value.
    /// </summary>
    public class SecretBase : Model
    {
        private ObjectId _identifier;
        private VaultAttributes _attributes;

        internal SecretBase()
        {

        }

        /// <summary>
        /// Initializes a new instance of the SecretBase class.
        /// </summary>
        /// <param name="name">The name of the secret.</param>
        public SecretBase(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} must not be null or empty", nameof(name));

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
        /// Determines whether the object is enabled.
        /// </summary>
        public bool? Enabled { get => _attributes.Enabled; set => _attributes.Enabled = value; }

        /// <summary>
        /// Not before date in UTC.
        /// </summary>
        public DateTimeOffset? NotBefore { get => _attributes.NotBefore; set => _attributes.NotBefore = value; }

        /// <summary>
        /// Expiry date in UTC.
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

        internal override void ReadProperties(JsonElement json)
        {
            _identifier.ParseId("secrets", json.GetProperty("id").GetString());

            if (json.TryGetProperty("contentType", out JsonElement contentType))
            {
                ContentType = contentType.GetString();
            }

            if (json.TryGetProperty("kid", out JsonElement kid))
            {
                KeyId = kid.GetString();
            }

            if (json.TryGetProperty("managed", out JsonElement managed))
            {
                Managed = managed.GetBoolean();
            }

            if (json.TryGetProperty("attributes", out JsonElement attributes))
            {
                _attributes.ReadProperties(attributes);
            }

            if (json.TryGetProperty("tags", out JsonElement tags))
            {
                Tags = new Dictionary<string, string>();

                foreach (var prop in tags.EnumerateObject())
                {
                    Tags[prop.Name] = prop.Value.GetString();
                }
            }
        }

        internal override void WriteProperties(ref Utf8JsonWriter json)
        {
            if (ContentType != null)
            {
                json.WriteString("contentType", ContentType);
            }

            if (_attributes.Enabled.HasValue || _attributes.NotBefore.HasValue || _attributes.Expires.HasValue)
            {
                json.WriteStartObject("attributes");

                _attributes.WriteProperties(ref json);

                json.WriteEndObject();
            }

            if (Tags != null && Tags.Count > 0)
            {
                json.WriteStartObject("tags");

                foreach (var kvp in Tags)
                {
                    json.WriteString(kvp.Key, kvp.Value);
                }

                json.WriteEndObject();
            }

            // KeyId is read-only don't serialize

            // Managed is read-only don't serialize
        }
    }
}
