// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    internal struct VaultAttributes
    {
        /// <summary>
        /// Specifies whether the secret is enabled and useable.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Identifies the time (in UTC) before which the secret data should not be retrieved.
        /// </summary>
        public System.DateTimeOffset? NotBefore { get; set; }

        /// <summary>
        /// Identifies the expiration time (in UTC) on or after which the secret data should not be retrieved.
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

        internal void ReadProperties(JsonElement json)
        {
            if (json.TryGetProperty("enabled", out JsonElement enabled))
            {
                Enabled = enabled.GetBoolean();
            }

            if (json.TryGetProperty("nbf", out JsonElement nbf))
            {
                NotBefore = DateTimeOffset.FromUnixTimeSeconds(nbf.GetInt64());
            }

            if (json.TryGetProperty("exp", out JsonElement exp))
            {
                Expires = DateTimeOffset.FromUnixTimeSeconds(exp.GetInt64());
            }

            if (json.TryGetProperty("created", out JsonElement created))
            {
                Created = DateTimeOffset.FromUnixTimeSeconds(created.GetInt64());
            }

            if (json.TryGetProperty("updated", out JsonElement updated))
            {
                Updated = DateTimeOffset.FromUnixTimeSeconds(updated.GetInt64());
            }

            if (json.TryGetProperty("recoveryLevel", out JsonElement recoveryLevel))
            {
                RecoveryLevel = recoveryLevel.GetString();
            }
        }

        internal void WriteProperties(ref Utf8JsonWriter json)
        {
            if (Enabled.HasValue)
            {
                json.WriteBoolean("enabled", Enabled.Value);
            }

            if (NotBefore.HasValue)
            {
                json.WriteNumber("nbf", NotBefore.Value.ToUnixTimeSeconds());
            }

            if (Expires.HasValue)
            {
                json.WriteNumber("exp", Expires.Value.ToUnixTimeSeconds());
            }

            // Created is read-only don't serialize
            // Updated is read-only don't serialize
            // RecoveryLevel is read-only don't serialize
        }
    }

}
