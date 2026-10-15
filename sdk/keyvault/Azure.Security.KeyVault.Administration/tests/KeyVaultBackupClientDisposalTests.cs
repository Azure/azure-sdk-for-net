// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class KeyVaultBackupClientDisposalTests : ClientDisposalTestsBase<KeyVaultBackupClient, KeyVaultAdministrationClientOptions>
    {
        protected override KeyVaultBackupClient CreateClient(TokenCredential credential, KeyVaultAdministrationClientOptions options = null) =>
            options == null ? new KeyVaultBackupClient(VaultUri, credential) : new KeyVaultBackupClient(VaultUri, credential, options);

        protected override KeyVaultAdministrationClientOptions CreateOptions() => new();

        protected override HttpPipeline GetPipeline(KeyVaultBackupClient client) => ReadField<KeyVaultRestClient>(client, "_restClient").Pipeline;
    }
}
