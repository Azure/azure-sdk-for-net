// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class MsalConfidentialClientTests
    {
        [Test]
        public void CreateClientRespectsCaeConfig(
            [Values(true, false)] bool enableCae,
            [Values(true, false)] bool async)
        {
            var mock = new MockMsalConfidentialClient
            {
                ClientAppFactory = (useCae) =>
                {
                    Assert.That(enableCae, Is.EqualTo(useCae));
                    return Moq.Mock.Of<IConfidentialClientApplication>();
                }
            };

            mock.CallCreateClientAsync(enableCae, async, default);
        }

        [Test]
        public async Task CacheRespectsEnableCaeConfig()
        {
            var options = new TestCredentialOptions
            {
                Transport = new MockTransport(),
                TokenCachePersistenceOptions = new TokenCachePersistenceOptions() { UnsafeAllowUnencryptedStorage = true }
            };
            var client = new MockMsalConfidentialClient(
                CredentialPipeline.GetInstance(options),
                "tenant",
                "client",
                "secret",
                "https://redirect",
                options);

            await client.CallBaseGetClientAsync(true, true, default);
            await client.CallBaseGetClientAsync(false, true, default);
            var caeEnabledCache = await client.GetTokenCache(true);
            var caeDisabledCache = await client.GetTokenCache(false);

            Assert.That(caeEnabledCache.IsCaeEnabled, Is.True);
            Assert.That(caeDisabledCache.IsCaeEnabled, Is.False);
        }

        public class TestCredentialOptions : TokenCredentialOptions, ISupportsTokenCachePersistenceOptions
        {
            public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
        }
    }
}
