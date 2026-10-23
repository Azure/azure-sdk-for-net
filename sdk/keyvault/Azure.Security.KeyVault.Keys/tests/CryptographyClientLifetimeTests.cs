// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class CryptographyClientLifetimeTests : ClientLifetimeTestsBase<CryptographyClient, CryptographyClientOptions>
    {
        protected override CryptographyClient CreateClient(TokenCredential credential, CryptographyClientOptions options = null)
        {
            Uri keyId = new(VaultUri, "/keys/key/version");
            return options == null ? new CryptographyClient(keyId, credential) : new CryptographyClient(keyId, credential, options);
        }

        protected override CryptographyClientOptions CreateOptions() => new();

        protected override HttpPipeline GetPipeline(CryptographyClient client) => GetKeyVaultPipeline(client);

        [Test]
        public void LocalOnlyClientDoesNotRequireDisposal([Values] bool explicitOptions)
        {
            using Aes aes = Aes.Create();
            aes.KeySize = 256;
            JsonWebKey key = new(aes);
            CryptographyClient client = explicitOptions
                ? new CryptographyClient(key, new LocalCryptographyClientOptions())
                : new CryptographyClient(key);
            byte[] plaintext = new byte[16];
            WrapResult wrapped = client.WrapKey(KeyWrapAlgorithm.A256KW, plaintext);
            Assert.That(client.UnwrapKey(KeyWrapAlgorithm.A256KW, wrapped.EncryptedKey).Key, Is.EqualTo(plaintext));

            Assert.That(client, Is.Not.InstanceOf<IDisposable>());
            Assert.That(GetPipeline(client), Is.Null);
            Assert.That(aes.KeySize, Is.EqualTo(256));
        }
    }
}
