// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class KeyVaultCertificateSource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public KeyVaultCertificateSource
            (
            KeyVaultCertificateSourceType sourceType,
            string subscriptionId,
            string resourceGroupName,
            string vaultName,
            string secretName,
            CertificateUpdateAction updateRule,
            CertificateDeleteAction deleteRule
            ) : this
            (
                subscriptionId,
                resourceGroupName,
                vaultName,
                secretName,
                updateRule,
                deleteRule
            )
        {
            KeyVaultCertificateSourceType = sourceType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public KeyVaultCertificateSourceType KeyVaultCertificateSourceType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
