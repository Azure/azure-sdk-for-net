// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the old constructor and SourceType property to KeyVaultCertificateSource for backward API compatibility with the previous SDK.
    // Reason: The old SDK used the KeyVaultCertificateSourceType struct as the discriminator (sourceType),
    // with the constructor signature (sourceType, subscriptionId, ..., deleteRule).
    // After the TypeSpec migration, the discriminator was changed to the string-typed TypeName property.
    // The old API is preserved here and bridges to TypeName.
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
            SourceType = sourceType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public KeyVaultCertificateSourceType SourceType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}
