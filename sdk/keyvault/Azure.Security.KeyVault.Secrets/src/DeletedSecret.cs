// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// Represents a KeyVault secret that has been deleted, allowing it to be recovered, if needed.
    /// </summary>
    public class DeletedSecret : Secret
    {
        private const string RecoveryIdPropertyName = "recoveryId";
        private const string DeletedDatePropertyName = "deletedDate";
        private const string ScheduledPurgeDatePropertyName = "scheduledPurgeDate";

        private static readonly JsonEncodedText s_recoveryIdPropertyNameBytes = JsonEncodedText.Encode(RecoveryIdPropertyName);
        private static readonly JsonEncodedText s_deletedDatePropertyNameBytes = JsonEncodedText.Encode(DeletedDatePropertyName);
        private static readonly JsonEncodedText s_scheduledPurgeDatePropertyNameBytes = JsonEncodedText.Encode(ScheduledPurgeDatePropertyName);

        private string _recoveryId;

        internal DeletedSecret()
        {
        }

        /// <summary>
        /// The identifier of the deleted secret. This is used to recover the secret.
        /// </summary>
        public Uri RecoveryId => new Uri(_recoveryId);

        /// <summary>
        /// The time when the secret was deleted, in UTC.
        /// </summary>
        public DateTimeOffset? DeletedDate { get; private set; }

        /// <summary>
        /// The time when the secret is scheduled to be purged, in UTC
        /// </summary>
        public DateTimeOffset? ScheduledPurgeDate { get; private set; }

        internal override void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case RecoveryIdPropertyName:
                    _recoveryId = prop.Value.GetString();
                    break;

                case DeletedDatePropertyName:
                    DeletedDate = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
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

            if (DeletedDate.HasValue)
            {
                json.WriteNumber(s_deletedDatePropertyNameBytes, DeletedDate.Value.ToUnixTimeSeconds());
            }

            if (ScheduledPurgeDate.HasValue)
            {
                json.WriteNumber(s_scheduledPurgeDatePropertyNameBytes, ScheduledPurgeDate.Value.ToUnixTimeSeconds());
            }
        }
    }
}
