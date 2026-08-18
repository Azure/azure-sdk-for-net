// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    [NonParallelizable]
    internal class KeyClientProofOfPossessionTests : ContinuousAccessEvaluationTestsBase
    {
        [SetUp]
        public void Setup()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [Test]
        public async Task GetKeyDoesNotRequestProofOfPossessionByDefault()
        {
            TokenRequestContext? lastRequestContext = null;
            KeyClient client = new(
                VaultUri,
                new TokenCredentialStub((context, _) =>
                {
                    lastRequestContext = context;
                    return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(1));
                }, true),
                new KeyClientOptions
                {
                    Transport = new MockTransport(defaultInitialChallenge, CreateGetKeyResponse()),
                });

            Response<KeyVaultKey> response = await client.GetKeyAsync("key").ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(lastRequestContext);
            Assert.IsFalse(lastRequestContext.Value.IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task GetKeyRequestsProofOfPossessionWhenEnabled()
        {
            TokenRequestContext? lastRequestContext = null;
            KeyClient client = new(
                VaultUri,
                new TokenCredentialStub((context, _) =>
                {
                    lastRequestContext = context;
                    return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(1));
                }, true),
                new KeyClientOptions
                {
                    Transport = new MockTransport(defaultInitialChallenge, CreateGetKeyResponse()),
                    EnableProofOfPossession = true,
                });

            Response<KeyVaultKey> response = await client.GetKeyAsync("key").ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(lastRequestContext);
            Assert.IsTrue(lastRequestContext.Value.IsProofOfPossessionEnabled);
        }

        private static MockResponse CreateGetKeyResponse() =>
            new MockResponse(200).WithContent(@"{
                ""key"": {
                    ""kid"": ""https://test.vault.azure.net/keys/key/version"",
                    ""kty"": ""RSA"",
                    ""key_ops"": [""encrypt"", ""decrypt"", ""sign"", ""verify"", ""wrapKey"", ""unwrapKey""],
                    ""n"": ""foo"",
                    ""e"": ""AQAB""
                },
                ""attributes"": {
                    ""enabled"": true,
                    ""created"": 1613807137,
                    ""updated"": 1613807137
                }
            }");
    }
}
