// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Security.KeyVault.Secrets.Models;

namespace Azure.Security.KeyVault.Secrets
{
    [ModelReaderWriterBuildable(typeof(SecretBundle))]
    public partial class AzureSecurityKeyVaultSecretsContext
    {
    }
}
