// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A certificate which has been deleted from the vault
    /// </summary>
    public class DeletedCertificate : CertificateWithPolicy
    {
        private const string RecoveryIdPropertyName = "recoveryId";
        private const string ScheduledPurgeDatePropertyName = "scheduledPurgeDate";
        private const string DeletedDatePropertyName = "deletedDate";

        private string _recoveryId;

        /// <summary>
        /// Id identifying the deleted certificate
        /// </summary>
        public Uri RecoveryId => new Uri(_recoveryId);

        /// <summary>
        /// The time the certificate was deleted in UTC
        /// </summary>
        public DateTimeOffset? DeletedDate { get; private set; }

        /// <summary>
        /// The time the certificate is scheduled to be permanently deleted in UTC
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
    }
}
