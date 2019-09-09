// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    public class DeletedCertificate : CertificateWithPolicy
    {
        public string RecoveryId { get; private set; }

        public DateTimeOffset? DeletedDate { get; private set; }

        public DateTimeOffset? ScheduledPurgeDate { get; private set; }

        private const string RecoveryIdPropertyName = "recoveryId";
        private const string ScheduledPurgeDatePropertyName = "scheduledPurgeDate";
        private const string DeletedDatePropertyName = "deletedDate";

        internal override void ReadProperty(JsonProperty prop)
        {
            switch(prop.Name)
            {
                case RecoveryIdPropertyName:
                    RecoveryId = prop.Value.GetString();
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
