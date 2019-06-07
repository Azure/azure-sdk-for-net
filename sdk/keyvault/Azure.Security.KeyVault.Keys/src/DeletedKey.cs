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

        private const string RecoveryIdPropertyName = "recoveryId";
        private static readonly JsonEncodedText RecoveryIdPropertyNameBytes = JsonEncodedText.Encode(RecoveryIdPropertyName);
        private const string DeletedDatePropertyName = "deletedDate";
        private static readonly JsonEncodedText DeletedDatePropertyNameBytes = JsonEncodedText.Encode(DeletedDatePropertyName);
        private const string ScheduledPurgeDatePropertyName = "scheduledPurgeDate";
        private static readonly JsonEncodedText ScheduledPurgeDatePropertyNameBytes = JsonEncodedText.Encode(ScheduledPurgeDatePropertyName);

        internal override void WriteProperties(Utf8JsonWriter json)
        {
            base.WriteProperties(json);

            if (RecoveryId != null)
            {
                json.WriteString(RecoveryIdPropertyNameBytes, RecoveryId);
            }

            if (DeletedDate.HasValue)
            {
                json.WriteNumber(DeletedDatePropertyNameBytes, DeletedDate.Value.ToUnixTimeMilliseconds());
            }

            if (ScheduledPurgeDate.HasValue)
            {
                json.WriteNumber(ScheduledPurgeDatePropertyNameBytes, ScheduledPurgeDate.Value.ToUnixTimeMilliseconds());
            }
        }

        internal override void ReadProperties(JsonElement json)
        {
            base.ReadProperties(json);
            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case RecoveryIdPropertyName:
                        RecoveryId = prop.Value.GetString();
                        break;
                    case DeletedDatePropertyName:
                        DeletedDate = DateTimeOffset.FromUnixTimeMilliseconds(prop.Value.GetInt64());
                        break;
                    case ScheduledPurgeDatePropertyName:
                        ScheduledPurgeDate = DateTimeOffset.FromUnixTimeMilliseconds(prop.Value.GetInt64());
                        break;
                }
            }
        }
    }
}
