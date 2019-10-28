// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Represents a Key Vault key that has been deleted, allowing it to be recovered, if needed.
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
        /// Gets a <see cref="Uri"/> of the deleted key that can be used to recover it.
        /// </summary>
        public Uri RecoveryId
        {
            get => _recoveryId is null ? null : new Uri(_recoveryId);
            internal set => _recoveryId = value?.ToString();
        }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> of when the key was deleted.
        /// </summary>
        public DateTimeOffset? DeletedOn { get; internal set; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> for when the deleted key will be purged.
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
