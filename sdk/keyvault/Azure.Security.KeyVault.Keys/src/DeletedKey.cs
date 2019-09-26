// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Represents a KeyVault key that has been deleted, allowing it to be recovered, if needed.
    /// </summary>
    public class DeletedKey : Key
    {
        private const string RecoveryIdPropertyName = "recoveryId";
        private const string DeletedDatePropertyName = "deletedDate";
        private const string ScheduledPurgeDatePropertyName = "scheduledPurgeDate";

        internal DeletedKey()
        {
        }

        internal DeletedKey(string name) : base(name)
        {
        }

        /// <summary>
        /// The identifier of the deleted key. This is used to recover the key.
        /// </summary>
        public Uri RecoveryId { get; private set; }

        /// <summary>
        /// The time when the key was deleted, in UTC.
        /// </summary>
        public DateTimeOffset? DeletedDate { get; private set; }

        /// <summary>
        /// The time when the key is scheduled to be purged, in UTC
        /// </summary>
        public DateTimeOffset? ScheduledPurgeDate { get; private set; }

        internal override void ReadProperty(JsonProperty prop)
        {
            switch (prop.Name)
            {
                case RecoveryIdPropertyName:
                    string recoveryId = prop.Value.GetString();
                    RecoveryId = new Uri(recoveryId);
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
    }
}
