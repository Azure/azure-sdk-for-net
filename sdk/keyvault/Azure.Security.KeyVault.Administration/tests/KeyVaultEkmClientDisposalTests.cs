// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class KeyVaultEkmClientDisposalTests : ClientDisposalTestsBase<KeyVaultEkmClient, KeyVaultAdministrationClientOptions>
    {
        protected override KeyVaultEkmClient CreateClient(TokenCredential credential, KeyVaultAdministrationClientOptions options = null) =>
            options == null ? new KeyVaultEkmClient(VaultUri, credential) : new KeyVaultEkmClient(VaultUri, credential, options);

        protected override KeyVaultAdministrationClientOptions CreateOptions() => new();

        protected override HttpPipeline GetPipeline(KeyVaultEkmClient client) => client.Pipeline;

        [Test]
        public void DisposeIsSafeForAuthenticationPolicyConstructor()
        {
            using DisposableMockTransport transport = new();
            using KeyVaultEkmClient client = new(new BearerTokenAuthenticationPolicy(new MockCredential(), "scope"), VaultUri, new() { Transport = transport });

            DisposeRepeatedly(client, concurrent: true);

            Assert.That(transport.DisposeCount, Is.Zero);
            Assert.That(client.Pipeline, Is.Not.InstanceOf<DisposableHttpPipeline>());
        }

#pragma warning disable SCME0002 // Exercise the experimental settings constructor's different pipeline ownership.
        [Test]
        public void DisposeIsSafeForSettingsConstructor()
        {
            using DisposableMockTransport transport = new();
            using KeyVaultEkmClient client = new(new KeyVaultEkmClientSettings
            {
                VaultBaseUrl = VaultUri,
                Options = new() { Transport = transport }
            });

            DisposeRepeatedly(client, concurrent: true);

            Assert.That(transport.DisposeCount, Is.Zero);
            Assert.That(client.Pipeline, Is.Not.InstanceOf<DisposableHttpPipeline>());
        }
#pragma warning restore SCME0002
    }
}
