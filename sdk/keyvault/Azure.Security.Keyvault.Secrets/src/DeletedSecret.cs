using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Azure.Security.KeyVault.Secrets
{
    public class DeletedSecret : SecretBase
    {
        internal DeletedSecret()
        {

        }

        public string RecoveryId { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public DateTime? ScheduledPurgeDate { get; private set; }

        internal override void WriteProperties(ref Utf8JsonWriter json)
        {
            base.WriteProperties(ref json);

            if (RecoveryId != null)
            {
                json.WriteString("recoveryId", RecoveryId);
            }

            if (DeletedDate.HasValue)
            {
                json.WriteNumber("deletedDate", new DateTimeOffset(DeletedDate.Value).ToUnixTimeMilliseconds());
            }

            if (ScheduledPurgeDate.HasValue)
            {
                json.WriteNumber("scheduledPurgeDate", new DateTimeOffset(ScheduledPurgeDate.Value).ToUnixTimeMilliseconds());
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
                DeletedDate = DateTimeOffset.FromUnixTimeMilliseconds(deletedDate.GetInt64()).UtcDateTime;
            }

            if (json.TryGetProperty("scheduledPurgeDate", out JsonElement scheduledPurgeDate))
            {
                ScheduledPurgeDate = DateTimeOffset.FromUnixTimeMilliseconds(scheduledPurgeDate.GetInt64()).UtcDateTime;
            }


        }
    }
}
