// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    public class SecretClientDisposalTests : ClientDisposalTestsBase<SecretClient, SecretClientOptions>
    {
        protected override SecretClient CreateClient(TokenCredential credential, SecretClientOptions options = null) =>
            options == null ? new SecretClient(VaultUri, credential) : new SecretClient(VaultUri, credential, options);

        protected override SecretClientOptions CreateOptions() => new();

        protected override HttpPipeline GetPipeline(SecretClient client) =>
            ReadField<KeyVaultSecretsClient>(client, "_generated").Pipeline;
    }
}
