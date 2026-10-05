// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Security.KeyVault.Secrets.Models;

namespace Azure.Security.KeyVault.Secrets
{
    // TODO: Remove this buildable model once https://github.com/Azure/azure-sdk-for-net/issues/63576 is fixed.
    [ModelReaderWriterBuildable(typeof(SecretBundle))]
    public partial class AzureSecurityKeyVaultSecretsContext
    {
    }
}
