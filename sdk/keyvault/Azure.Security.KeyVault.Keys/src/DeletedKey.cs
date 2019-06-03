// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    public class DeletedKey : Key
    {
        public string RecoveryId { get; private set; }

        public DateTimeOffset? DeletedDate { get; private set; }

        public DateTimeOffset? ScheduledPurgeDate { get; private set; }

        public DeletedKey(string name) : base(name) { }

        public DeletedKey (string name, string recoveryId, DateTimeOffset? deletedDate, DateTimeOffset? scheduledPurge)
            : base(name)
        {
            RecoveryId = recoveryId;
            DeletedDate = deletedDate;
            ScheduledPurgeDate = scheduledPurge;
        }

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
