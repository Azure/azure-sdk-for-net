// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class KeyVaultSettingsClientDisposalTests : ClientDisposalTestsBase<KeyVaultSettingsClient, KeyVaultAdministrationClientOptions>
    {
        protected override KeyVaultSettingsClient CreateClient(TokenCredential credential, KeyVaultAdministrationClientOptions options = null) =>
            options == null ? new KeyVaultSettingsClient(VaultUri, credential) : new KeyVaultSettingsClient(VaultUri, credential, options);

        protected override KeyVaultAdministrationClientOptions CreateOptions() => new();

        protected override HttpPipeline GetPipeline(KeyVaultSettingsClient client) => ReadField<KeyVaultRestClient>(client, "_restClient").Pipeline;

        [Test]
        public void DisposeIsSafeForRestClientAuthenticationPolicyConstructor()
        {
            using DisposableMockTransport transport = new();
            using KeyVaultRestClient client = new(new BearerTokenAuthenticationPolicy(new MockCredential(), "scope"), VaultUri, new() { Transport = transport });

            DisposeRepeatedly(client, concurrent: true);

            Assert.That(transport.DisposeCount, Is.Zero);
            Assert.That(client.Pipeline, Is.Not.InstanceOf<DisposableHttpPipeline>());
        }
    }
}
