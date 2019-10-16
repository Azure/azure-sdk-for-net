// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    internal struct KeyAttributes
    {
        private const string EnabledPropertyName = "enabled";
        private const string NotBeforePropertyName = "nbf";
        private const string ExpiresPropertyName = "exp";
        private const string CreatedPropertyName = "created";
        private const string UpdatedPropertyName = "updated";
        private const string RecoveryLevelPropertyName = "recoveryLevel";

        private static readonly JsonEncodedText s_enabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);
        private static readonly JsonEncodedText s_notBeforePropertyNameBytes = JsonEncodedText.Encode(NotBeforePropertyName);
        private static readonly JsonEncodedText s_expiresPropertyNameBytes = JsonEncodedText.Encode(ExpiresPropertyName);

        /// <summary>
        /// Specifies whether the key is enabled and useable for cryptographic operations.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Identifies the time (in UTC) before which the key must not be used for cryptographic operations.
        /// </summary>
        public DateTimeOffset? NotBefore { get; set; }

        /// <summary>
        /// Identifies the expiration time (in UTC) on or after which the key must not be used.
        /// </summary>
        public DateTimeOffset? Expires { get; set; }

        /// <summary>
        /// Gets creation time in UTC.
        /// </summary>
        public DateTimeOffset? Created { get; private set; }

        /// <summary>
        /// Gets last updated time in UTC.
        /// </summary>
        public DateTimeOffset? Updated { get; private set; }

        /// <summary>
        /// Gets reflects the deletion recovery level currently in effect for
        /// secrets in the current vault. If it contains 'Purgeable', the
        /// secret can be permanently deleted by a privileged user; otherwise,
        /// only the system can purge the secret, at the end of the retention
        /// interval. Possible values include: 'Purgeable',
        /// 'Recoverable+Purgeable', 'Recoverable',
        /// 'Recoverable+ProtectedSubscription'
        /// </summary>
        public string RecoveryLevel { get; private set; }

        internal bool ShouldSerialize => Enabled.HasValue && NotBefore.HasValue && Expires.HasValue;

        internal void ReadProperties(JsonElement json)
        {
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case EnabledPropertyName:
                        Enabled = prop.Value.GetBoolean();
                        break;
                    case NotBeforePropertyName:
                        NotBefore = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                    case ExpiresPropertyName:
                        Expires = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                    case CreatedPropertyName:
                        Created = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                    case UpdatedPropertyName:
                        Updated = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;
                    case RecoveryLevelPropertyName:
                        RecoveryLevel = prop.Value.GetString();
                        break;
                }
            }
        }

        internal void WriteProperties(Utf8JsonWriter json)
        {
            if (Enabled.HasValue)
            {
                json.WriteBoolean(s_enabledPropertyNameBytes, Enabled.Value);
            }

            if (NotBefore.HasValue)
            {
                json.WriteNumber(s_notBeforePropertyNameBytes, NotBefore.Value.ToUnixTimeSeconds());
            }

            if (Expires.HasValue)
            {
                json.WriteNumber(s_expiresPropertyNameBytes, Expires.Value.ToUnixTimeSeconds());
            }

            // Created is read-only don't serialize
            // Updated is read-only don't serialize
            // RecoveryLevel is read-only don't serialize
        }
    }
}
