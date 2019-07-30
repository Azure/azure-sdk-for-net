// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

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

        internal void ReadProperties(JsonElement json)
        {
            if (json.TryGetProperty("enabled", out JsonElement enabled))
            {
                Enabled = enabled.GetBoolean();
            }

            if (json.TryGetProperty("nbf", out JsonElement nbf))
            {
                if (nbf.ValueKind == JsonValueKind.Null)
                {
                    NotBefore = null;
                }
                else
                {
                    NotBefore = DateTimeOffset.Parse(nbf.GetString(), CultureInfo.InvariantCulture);
                }
            }

            if (json.TryGetProperty("exp", out JsonElement exp))
            {
                if (exp.ValueKind == JsonValueKind.Null)
                {
                    Expires = null;
                }
                else
                {
                    Expires = DateTimeOffset.Parse(exp.GetString(), CultureInfo.InvariantCulture);
                }
            }

            if (json.TryGetProperty("created", out JsonElement created))
            {
                if (created.ValueKind == JsonValueKind.Null)
                {
                    Created = null;
                }
                else
                {
                    Created = DateTimeOffset.Parse(created.GetString(), CultureInfo.InvariantCulture);
                }
            }

            if (json.TryGetProperty("updated", out JsonElement updated))
            {
                if (updated.ValueKind == JsonValueKind.Null)
                {
                    Updated = null;
                }
                else
                {
                    Updated = DateTimeOffset.Parse(updated.GetString(), CultureInfo.InvariantCulture);
                }
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
                json.WriteNumber("nbf", NotBefore.Value.ToUnixTimeMilliseconds());
            }

            if (Expires.HasValue)
            {
                json.WriteNumber("exp", Expires.Value.ToUnixTimeMilliseconds());
            }

            // Created is read-only don't serialize
            // Updated is read-only don't serialize
            // RecoveryLevel is read-only don't serialize
        }
    }
}
