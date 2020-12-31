// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// A deleted <see cref="KeyVaultCertificateWithPolicy"/>.
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
        /// Gets the identifier of the deleted certificate.
        /// </summary>
        public Uri RecoveryId
        {
            get => _recoveryId is null ? null : new Uri(_recoveryId);
            internal set => _recoveryId = value?.ToString();
        }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> indicating when the certificate was deleted.
        /// </summary>
        public DateTimeOffset? DeletedOn { get; internal set; }

        /// <summary>
        /// Gets a <see cref="DateTimeOffset"/> for when the deleted certificate will be purged.
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
