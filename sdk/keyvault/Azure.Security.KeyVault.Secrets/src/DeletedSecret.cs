// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// DeletedSecret is the resource consisting of name, recovery id, deleted date, scheduled purge date and its attributes 
    /// inherited from <see cref="SecretBase"/>.
    /// </summary>
    public class DeletedSecret : SecretBase
    {
        internal DeletedSecret()
        {

        }

        /// <summary>
        /// The identifier of the deleted secret object. This is used to recover the secret.
        /// </summary>
        public string RecoveryId { get; private set; }

        /// <summary>
        /// Time when the secret was deleted, in UTC.
        /// </summary>
        public DateTimeOffset? DeletedDate { get; private set; }

        /// <summary>
        /// Time when the secret is scheduled to be purged, in UTC
        /// </summary>
        public DateTimeOffset? ScheduledPurgeDate { get; private set; }

        internal override void WriteProperties(ref Utf8JsonWriter json)
        {
            base.WriteProperties(ref json);

            if (RecoveryId != null)
            {
                json.WriteString("recoveryId", RecoveryId);
            }

            if (DeletedDate.HasValue)
            {
                json.WriteNumber("deletedDate", DeletedDate.Value.ToUnixTimeMilliseconds());
            }

            if (ScheduledPurgeDate.HasValue)
            {
                json.WriteNumber("scheduledPurgeDate", ScheduledPurgeDate.Value.ToUnixTimeMilliseconds());
            }
        }

        internal override void ReadProperties(JsonElement json)
        {
            base.ReadProperties(json);

            if (json.TryGetProperty("recoveryId", out JsonElement recoveryId))
            {
                RecoveryId = recoveryId.GetString();
            }

            if (json.TryGetProperty("deletedDate", out JsonElement deletedDate))
            {
                DeletedDate = DateTimeOffset.FromUnixTimeMilliseconds(deletedDate.GetInt64());
            }

            if (json.TryGetProperty("scheduledPurgeDate", out JsonElement scheduledPurgeDate))
            {
                ScheduledPurgeDate = DateTimeOffset.FromUnixTimeMilliseconds(scheduledPurgeDate.GetInt64());
            }
        }
    }
}
