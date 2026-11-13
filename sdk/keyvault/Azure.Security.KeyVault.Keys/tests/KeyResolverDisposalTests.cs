// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyResolverDisposalTests : ClientDisposalTestsBase<KeyResolver, CryptographyClientOptions>
    {
        protected override KeyResolver CreateClient(TokenCredential credential, CryptographyClientOptions options = null) =>
            options == null ? new KeyResolver(credential) : new KeyResolver(credential, options);

        protected override CryptographyClientOptions CreateOptions() => new();

        protected override HttpPipeline GetPipeline(KeyResolver client) => ReadField<HttpPipeline>(client, "_pipeline");

        [Test]
        public async Task DisposingResolvedChildDoesNotDisposeResolverOrSibling([Values] bool isAsync, [Values] bool canGetKey)
        {
            ResponsePolicy policy = new(request => request.Method == RequestMethod.Get
                ? canGetKey
                    ? new MockResponse(200).WithJson("""{"key":{"kid":"https://disposal.vault.azure.net/keys/key/version","kty":"oct-HSM"}}""")
                    : new MockResponse(403)
                : new MockResponse(200).WithJson("""{"kid":"https://disposal.vault.azure.net/keys/key/version","value":"dGVzdA"}"""));
            CryptographyClientOptions options = new();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            using KeyResolver parent = CreateClient(new MockCredential(), options);
            Uri keyId = new(VaultUri, "/keys/key/version");
            using CryptographyClient child = isAsync ? await parent.ResolveAsync(keyId) : parent.Resolve(keyId);
            HttpPipeline pipeline = GetPipeline(parent);
            Assert.That(GetKeyVaultPipeline(child), Is.SameAs(pipeline));
            DefaultTransportLifetime lifetime = new(pipeline);

            DisposeRepeatedly(child, concurrent: true);
            lifetime.AssertAlive();
            using CryptographyClient sibling = isAsync ? await parent.ResolveAsync(keyId) : parent.Resolve(keyId);
            Assert.That(GetKeyVaultPipeline(sibling), Is.SameAs(pipeline));
            WrapResult result = isAsync
                ? await sibling.WrapKeyAsync(KeyWrapAlgorithm.A256KW, new byte[] { 1, 2, 3, 4 })
                : sibling.WrapKey(KeyWrapAlgorithm.A256KW, new byte[] { 1, 2, 3, 4 });
            Assert.That(result.EncryptedKey, Is.EqualTo(new byte[] { 116, 101, 115, 116 }));

            DisposeRepeatedly(sibling);
            lifetime.AssertAlive();
            DisposeRepeatedly(parent, concurrent: true);
            lifetime.AssertDisposedOnce();
            DisposeRepeatedly(child);
            DisposeRepeatedly(sibling);
            lifetime.AssertDisposedOnce();
        }
    }
}
