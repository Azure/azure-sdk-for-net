// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Represents a KeyVault key that has been deleted, allowing it to be recovered, if needed.
    /// </summary>
    public class DeletedKey : KeyVaultKey
    {
        private const string RecoveryIdPropertyName = "recoveryId";
        private const string DeletedOnPropertyName = "deletedDate";
        private const string ScheduledPurgeDatePropertyName = "scheduledPurgeDate";

        private string _recoveryId;

        internal DeletedKey(KeyProperties properties = null) : base(properties)
        {
        }

        internal DeletedKey(string name) : base(name)
        {
        }

        /// <summary>
        /// The identifier of the deleted key. This is used to recover the key.
        /// </summary>
        public Uri RecoveryId
        {
            get => _recoveryId is null ? null : new Uri(_recoveryId);
            internal set => _recoveryId = value?.ToString();
        }

        /// <summary>
        /// The time when the key was deleted, in UTC.
        /// </summary>
        public DateTimeOffset? DeletedOn { get; internal set; }

        /// <summary>
        /// The time when the key is scheduled to be purged, in UTC
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
    }
}
