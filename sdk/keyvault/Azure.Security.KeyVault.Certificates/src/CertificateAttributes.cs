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
        private const string RecoverableDaysPropertyName = "recoverableDays";
        private const string RecoveryLevelPropertyName = "recoveryLevel";

        public bool? Enabled { get; set; }

        public DateTimeOffset? NotBefore { get; set; }

        public DateTimeOffset? ExpiresOn { get; set; }

        public DateTimeOffset? CreatedOn { get; internal set; }

        public DateTimeOffset? UpdatedOn { get; internal set; }

        public int? RecoverableDays { get; internal set; }

        public string RecoveryLevel { get; internal set; }

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
                        ExpiresOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;

                    case CreatedPropertyName:
                        CreatedOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;

                    case UpdatedPropertyName:
                        UpdatedOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                        break;

                    case RecoverableDaysPropertyName:
                        RecoverableDays = prop.Value.GetInt32();
                        break;

                    case RecoveryLevelPropertyName:
                        RecoveryLevel = prop.Value.GetString();
                        break;
                }
            }
        }
    }
}
