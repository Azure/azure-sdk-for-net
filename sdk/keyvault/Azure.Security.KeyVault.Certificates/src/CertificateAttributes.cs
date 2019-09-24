// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    internal struct CertificateAttributes
    {
        private const string EnabledPropertyName = "enabled";
        private const string NotBeforePropertyName = "nbf";
        private const string ExpiresPropertyName = "exp";
        private const string CreatedPropertyName = "created";
        private const string UpdatedPropertyName = "updated";
        private const string RecoveryLevelPropertyName = "recoveryLevel";

        public bool? Enabled { get; set; }

        public DateTimeOffset? NotBefore { get; set; }

        public DateTimeOffset? Expires { get; set; }

        public DateTimeOffset? Created { get; private set; }

        public DateTimeOffset? Updated { get; private set; }

        public string RecoveryLevel { get; private set; }

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
