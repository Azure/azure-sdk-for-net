// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A certificate which has been deleted from the vault
    /// </summary>
    public class DeletedCertificate : KeyVaultCertificateWithPolicy
    {
        private const string RecoveryIdPropertyName = "recoveryId";
        private const string ScheduledPurgeDatePropertyName = "scheduledPurgeDate";
        private const string DeletedOnPropertyName = "deletedDate";

        private string _recoveryId;

        internal DeletedCertificate(CertificateProperties properties = null) : base(properties)
        {
        }

        /// <summary>
        /// Id identifying the deleted certificate
        /// </summary>
        public Uri RecoveryId
        {
            get => new Uri(_recoveryId);
            internal set => _recoveryId = value?.ToString();
        }

        /// <summary>
        /// The time the certificate was deleted in UTC
        /// </summary>
        public DateTimeOffset? DeletedOn { get; internal set; }

        /// <summary>
        /// The time the certificate is scheduled to be permanently deleted in UTC
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
