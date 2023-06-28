// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
                    Assert.AreEqual(useCae, enableCae);
                    return Moq.Mock.Of<IConfidentialClientApplication>();
                }
            };

            mock.CallCreateClientAsync(enableCae, async, default);
        }

        [Test]
        public void CacheRespectsEnableCaeConfig(
            [Values(true, false)] bool enableCae)
        {
            var options = new TestCredentialOptions {
                        Transport = new MockTransport(),
                        TokenCachePersistenceOptions = new TokenCachePersistenceOptions()
                    };
            var client = new MockMsalConfidentialClient(
                CredentialPipeline.GetInstance(options),
                "tenant",
                "client",
                "secret",
                "https://redirect",
                options);

            client.CallBaseGetClientAsync(enableCae, false, default);

            Assert.AreEqual(enableCae, client.Cache.EnableCae);
        }

        public class TestCredentialOptions : TokenCredentialOptions, ISupportsTokenCachePersistenceOptions
        {
            public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
        }
    }
}
