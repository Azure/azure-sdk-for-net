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
        private const string RecoverableDaysPropertyName = "recoverableDays";
        private const string RecoveryLevelPropertyName = "recoveryLevel";
        private const string ExportablePropertyName = "exportable";

        private static readonly JsonEncodedText s_enabledPropertyNameBytes = JsonEncodedText.Encode(EnabledPropertyName);
        private static readonly JsonEncodedText s_notBeforePropertyNameBytes = JsonEncodedText.Encode(NotBeforePropertyName);
        private static readonly JsonEncodedText s_expiresPropertyNameBytes = JsonEncodedText.Encode(ExpiresPropertyName);
        private static readonly JsonEncodedText s_exportablePropertyNameBytes = JsonEncodedText.Encode(ExportablePropertyName);

        public bool? Enabled { get; set; }

        public DateTimeOffset? NotBefore { get; set; }

        public DateTimeOffset? ExpiresOn { get; set; }

        public DateTimeOffset? CreatedOn { get; internal set; }

        public DateTimeOffset? UpdatedOn { get; internal set; }

        public int? RecoverableDays { get; internal set; }

        public string RecoveryLevel { get; internal set; }

        public bool? Exportable { get; internal set; }

        internal bool ShouldSerialize =>
            Enabled.HasValue &&
            NotBefore.HasValue &&
            ExpiresOn.HasValue &&
            Exportable.HasValue;

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
                    case ExportablePropertyName:
                        Exportable = prop.Value.GetBoolean();
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

            if (ExpiresOn.HasValue)
            {
                json.WriteNumber(s_expiresPropertyNameBytes, ExpiresOn.Value.ToUnixTimeSeconds());
            }

            if (Exportable.HasValue)
            {
                json.WriteBoolean(s_exportablePropertyNameBytes, Exportable.Value);
            }

            // Created is read-only don't serialize
            // Updated is read-only don't serialize
            // RecoverableDays is read-only don't serialize
            // RecoveryLevel is read-only don't serialize
        }
    }
}
