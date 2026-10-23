// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    public class SecretClientLifetimeTests : ClientLifetimeTestsBase<SecretClient, SecretClientOptions>
    {
        protected override SecretClient CreateClient(TokenCredential credential, SecretClientOptions options = null) =>
            options == null ? new SecretClient(VaultUri, credential) : new SecretClient(VaultUri, credential, options);

        protected override SecretClientOptions CreateOptions() => new();

        protected override HttpPipeline GetPipeline(SecretClient client) =>
            ReadField<KeyVaultSecretsClient>(client, "_generated").Pipeline;

        [Test]
        public void SettingsConstructorDoesNotRequireDisposal([Values] bool explicitOptions)
        {
#pragma warning disable SCME0002
            var settings = new SecretClientSettings
            {
                VaultUri = VaultUri,
                Options = explicitOptions ? CreateOptions() : null,
                Credential = new System.ClientModel.Primitives.CredentialSettings(null) { TokenProvider = new MockCredential() }
            };
            var client = new SecretClient(settings);
#pragma warning restore SCME0002
            var lifetime = new DefaultTransportLifetime(GetPipeline(client));
            lifetime.AssertAlive();
            Assert.That(GetUnderlyingTransport(GetPipeline(client)),
                Is.SameAs(GetUnderlyingTransport(GetPipeline(CreateClient(new MockCredential())))));
        }
    }
}
