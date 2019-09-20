// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    internal struct CertificateAttributes
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
        private const string NotBeforePropertyName = "nbf";
        private const string ExpiresPropertyName = "exp";
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
    }
}
