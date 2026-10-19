// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyClientLifetimeTests : ClientLifetimeTestsBase<KeyClient, KeyClientOptions>
    {
        protected override KeyClient CreateClient(TokenCredential credential, KeyClientOptions options = null) =>
            options == null ? new KeyClient(VaultUri, credential) : new KeyClient(VaultUri, credential, options);

        protected override KeyClientOptions CreateOptions() => new();

        protected override HttpPipeline GetPipeline(KeyClient client) => GetKeyVaultPipeline(client);

        [Test]
        public async Task CryptographyChildrenRetainPipelineWithoutParentReference([Values] bool isAsync)
        {
            ResponsePolicy policy = new(request => request.Method == RequestMethod.Get
                ? new MockResponse(200).WithJson("""{"key":{"kid":"https://lifetime.vault.azure.net/keys/key/version","kty":"oct-HSM"}}""")
                : new MockResponse(200).WithJson("""{"kid":"https://lifetime.vault.azure.net/keys/key/version","value":"dGVzdA"}"""));
            KeyClientOptions options = new();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            KeyClient parent = CreateClient(new MockCredential(), options);
            CryptographyClient child = parent.GetCryptographyClient("key");
            CryptographyClient sibling = parent.GetCryptographyClient("key");
            HttpPipeline pipeline = GetPipeline(parent);
            Assert.That(GetKeyVaultPipeline(child), Is.SameAs(pipeline));
            Assert.That(GetKeyVaultPipeline(sibling), Is.SameAs(pipeline));
            DefaultTransportLifetime lifetime = new(pipeline);

            KeyVaultKey key = isAsync ? await parent.GetKeyAsync("key") : parent.GetKey("key");
            Assert.That(key.Name, Is.EqualTo("key"));
            parent = null;
            WrapResult result = isAsync
                ? await sibling.WrapKeyAsync(KeyWrapAlgorithm.A256KW, new byte[] { 1, 2, 3, 4 })
                : sibling.WrapKey(KeyWrapAlgorithm.A256KW, new byte[] { 1, 2, 3, 4 });
            Assert.That(result.EncryptedKey, Is.EqualTo(new byte[] { 116, 101, 115, 116 }));

            sibling = null;
            lifetime.AssertAlive();
            result = isAsync
                ? await child.WrapKeyAsync(KeyWrapAlgorithm.A256KW, new byte[] { 1, 2, 3, 4 })
                : child.WrapKey(KeyWrapAlgorithm.A256KW, new byte[] { 1, 2, 3, 4 });
            Assert.That(result.EncryptedKey, Is.EqualTo(new byte[] { 116, 101, 115, 116 }));
            lifetime.AssertAlive();
        }
    }
}
