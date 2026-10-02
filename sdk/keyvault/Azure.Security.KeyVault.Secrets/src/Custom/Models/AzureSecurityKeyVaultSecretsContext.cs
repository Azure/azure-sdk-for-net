// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Security.KeyVault.Secrets.Models;

namespace Azure.Security.KeyVault.Secrets
{
    [ModelReaderWriterBuildable(typeof(BackupSecretResult))]
    [ModelReaderWriterBuildable(typeof(DeletedSecretBundle))]
    [ModelReaderWriterBuildable(typeof(DeletedSecretItem))]
    [ModelReaderWriterBuildable(typeof(DeletedSecretListResult))]
    [ModelReaderWriterBuildable(typeof(SecretAttributesBundle))]
    [ModelReaderWriterBuildable(typeof(SecretBundle))]
    [ModelReaderWriterBuildable(typeof(SecretItem))]
    [ModelReaderWriterBuildable(typeof(SecretListResult))]
    [ModelReaderWriterBuildable(typeof(SecretRestoreParameters))]
    [ModelReaderWriterBuildable(typeof(SecretSetParameters))]
    public partial class AzureSecurityKeyVaultSecretsContext
    {
    }
}
