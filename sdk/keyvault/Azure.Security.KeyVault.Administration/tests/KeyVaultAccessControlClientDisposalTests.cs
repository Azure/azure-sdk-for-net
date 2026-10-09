// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class KeyVaultAccessControlClientDisposalTests : ClientDisposalTestsBase<KeyVaultAccessControlClient, KeyVaultAdministrationClientOptions>
    {
        protected override KeyVaultAccessControlClient CreateClient(TokenCredential credential, KeyVaultAdministrationClientOptions options = null) =>
            options == null ? new KeyVaultAccessControlClient(VaultUri, credential) : new KeyVaultAccessControlClient(VaultUri, credential, options);

        protected override KeyVaultAdministrationClientOptions CreateOptions() => new();

        protected override HttpPipeline GetPipeline(KeyVaultAccessControlClient client) => client.Pipeline;

        [Test]
        public void DisposeIsSafeForAuthenticationPolicyConstructor()
        {
            using DisposableMockTransport transport = new();
            using KeyVaultAccessControlClient client = new(new BearerTokenAuthenticationPolicy(new MockCredential(), "scope"), VaultUri, new() { Transport = transport });

            DisposeRepeatedly(client, concurrent: true);

            Assert.That(transport.DisposeCount, Is.Zero);
            Assert.That(client.Pipeline, Is.Not.InstanceOf<DisposableHttpPipeline>());
        }

#pragma warning disable SCME0002 // Exercise the experimental settings constructor's different pipeline ownership.
        [Test]
        public void DisposeIsSafeForSettingsConstructor()
        {
            using DisposableMockTransport transport = new();
            using KeyVaultAccessControlClient client = new(new KeyVaultAccessControlClientSettings
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
