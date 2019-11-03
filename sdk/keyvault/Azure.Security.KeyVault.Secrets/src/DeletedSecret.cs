// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// Represents a Key Vault secret that has been deleted, allowing it to be recovered, if needed.
    /// </summary>
    public class DeletedSecret : KeyVaultSecret
    {
        private const string RecoveryIdPropertyName = "recoveryId";
        private const string DeletedOnPropertyName = "deletedDate";
        private const string ScheduledPurgeDatePropertyName = "scheduledPurgeDate";

        private static readonly JsonEncodedText s_recoveryIdPropertyNameBytes = JsonEncodedText.Encode(RecoveryIdPropertyName);
        private static readonly JsonEncodedText s_deletedOnPropertyNameBytes = JsonEncodedText.Encode(DeletedOnPropertyName);
        private static readonly JsonEncodedText s_scheduledPurgeDatePropertyNameBytes = JsonEncodedText.Encode(ScheduledPurgeDatePropertyName);

        private string _recoveryId;

        internal DeletedSecret(SecretProperties properties = null) : base(properties)
        {
        }

        /// <summary>
        /// Gets a <see cref="Uri"/> of the deleted secret that can be used to recover it.
        /// </summary>
        public Uri RecoveryId
        {
            get => _recoveryId is null ? null : new Uri(_recoveryId);
            internal set => _recoveryId = value?.ToString();
        }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> of when the secret was deleted.
        /// </summary>
        public DateTimeOffset? DeletedOn { get; internal set; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> for when the deleted secret will be purged.
        /// </summary>
        public DateTimeOffset? ScheduledPurgeDate { get; internal set; }

        internal override void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case RecoveryIdPropertyName:
                    _recoveryId = prop.Value.GetString();
                    break;

                case DeletedOnPropertyName:
                    DeletedOn = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    break;

                case ScheduledPurgeDatePropertyName:
                    ScheduledPurgeDate = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    break;

                default:
                    base.ReadProperty(prop);
                    break;
            }
        }

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            base.WriteProperties(json);

            if (RecoveryId != null)
            {
                json.WriteString(s_recoveryIdPropertyNameBytes, RecoveryId.ToString());
            }

            if (DeletedOn.HasValue)
            {
                json.WriteNumber(s_deletedOnPropertyNameBytes, DeletedOn.Value.ToUnixTimeSeconds());
            }

            if (ScheduledPurgeDate.HasValue)
            {
                json.WriteNumber(s_scheduledPurgeDatePropertyNameBytes, ScheduledPurgeDate.Value.ToUnixTimeSeconds());
            }
        }
    }
}
