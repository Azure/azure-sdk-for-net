// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    [NonParallelizable]
    internal class CertificateClientProofOfPossessionTests : ContinuousAccessEvaluationTestsBase
    {
        [SetUp]
        public void Setup()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [Test]
        public async Task GetCertificateDoesNotRequestProofOfPossessionByDefault()
        {
            TokenRequestContext? lastRequestContext = null;
            CertificateClient client = new(
                VaultUri,
                new TokenCredentialStub((context, _) =>
                {
                    lastRequestContext = context;
                    return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(1));
                }, true),
                new CertificateClientOptions
                {
                    Transport = new MockTransport(defaultInitialChallenge, CreateGetCertificateResponse()),
                });

            Response<KeyVaultCertificateWithPolicy> response = await client.GetCertificateAsync("certificate").ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(lastRequestContext);
            Assert.IsFalse(lastRequestContext.Value.IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task GetCertificateRequestsProofOfPossessionWhenEnabled()
        {
            TokenRequestContext? lastRequestContext = null;
            CertificateClient client = new(
                VaultUri,
                new TokenCredentialStub((context, _) =>
                {
                    lastRequestContext = context;
                    return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(1));
                }, true),
                new CertificateClientOptions
                {
                    Transport = new MockTransport(defaultInitialChallenge, CreateGetCertificateResponse()),
                    EnableProofOfPossession = true,
                });

            Response<KeyVaultCertificateWithPolicy> response = await client.GetCertificateAsync("certificate").ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(lastRequestContext);
            Assert.IsTrue(lastRequestContext.Value.IsProofOfPossessionEnabled);
        }

        private static MockResponse CreateGetCertificateResponse() =>
            new MockResponse(200).WithContent(@"{
                ""id"": ""https://test.vault.azure.net/certificates/certificate/version"",
                ""cer"": ""Zm9v"",
                ""attributes"": {
                },
                ""pending"": {
                    ""id"": ""pending""
                }
            }");
    }
}
