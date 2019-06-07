// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    internal struct KeyAttributes
    {
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets not before date in UTC.
        /// </summary>
        public System.DateTimeOffset? NotBefore { get; set; }

        /// <summary>
        /// Gets or sets expiry date in UTC.
        /// </summary>
        public System.DateTimeOffset? Expires { get; set; }

        /// <summary>
        /// Gets creation time in UTC.
        /// </summary>
        public System.DateTimeOffset? Created { get; private set; }

        /// <summary>
        /// Gets last updated time in UTC.
        /// </summary>
        public System.DateTimeOffset? Updated { get; private set; }

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

        private const string EnabledPropertyName = "enabled";
        private static readonly JsonEncodedText EnabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);
        private const string NotBeforePropertyName = "nbf";
        private static readonly JsonEncodedText NotBeforePropertyNameBytes = JsonEncodedText.Encode(NotBeforePropertyName);
        private const string ExpiresPropertyName = "exp";
        private static readonly JsonEncodedText ExpiresPropertyNameBytes = JsonEncodedText.Encode(ExpiresPropertyName);
        private const string CreatedPropertyName = "created";
        private const string UpdatedPropertyName = "updated";
        private const string RecoveryLevelPropertyName = "recoveryLevel";

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
                        NotBefore = DateTimeOffset.Parse(prop.Value.GetString());
                        break;
                    case ExpiresPropertyName:
                        Expires = DateTimeOffset.Parse(prop.Value.GetString());
                        break;
                    case CreatedPropertyName:
                        Created = DateTimeOffset.Parse(prop.Value.GetString());
                        break;
                    case UpdatedPropertyName:
                        Updated = DateTimeOffset.Parse(prop.Value.GetString());
                        break;
                    case RecoveryLevelPropertyName:
                        RecoveryLevel = prop.Value.GetString();
                        break;
                }
            }
        }

        internal void WriteProperties(ref Utf8JsonWriter json)
        {
            if (Enabled.HasValue)
            {
                json.WriteBoolean(EnabledPropertyNameBytes, Enabled.Value);
            }

            if (NotBefore.HasValue)
            {
                json.WriteNumber(NotBeforePropertyNameBytes, NotBefore.Value.ToUnixTimeMilliseconds());
            }

            if (Expires.HasValue)
            {
                json.WriteNumber(ExpiresPropertyNameBytes, Expires.Value.ToUnixTimeMilliseconds());
            }

            // Created is read-only don't serialize
            // Updated is read-only don't serialize
            // RecoveryLevel is read-only don't serialize
        }
    }
}
