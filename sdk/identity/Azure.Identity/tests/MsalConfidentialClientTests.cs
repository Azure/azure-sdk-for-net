// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
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

        [Test]
        public async Task VerifyMsalRetriesAreDisabled(
            [Values(true, false)] bool async)
        {
            int maxRetries = 3;
            int expectedCalls = maxRetries + 1; // initial call + retries
            int requestCount = 0;

            var mockTransport = new MockTransport(req =>
            {
                requestCount++;
                var response = new MockResponse(500);
                response.SetContent("{\"error\":\"server_error\",\"error_description\":\"Internal server error\"}");
                return response;
            });

            var options = new ClientSecretCredentialOptions
            {
                Transport = mockTransport,
                Retry = { MaxRetries = maxRetries, Delay = System.TimeSpan.Zero, MaxDelay = System.TimeSpan.Zero, Mode = Core.RetryMode.Fixed },
                DisableInstanceDiscovery = true // Disable instance discovery to avoid extra requests
            };

            var credential = new ClientSecretCredential("tenant", "client", "secret", options);

            var ex = async
                ? Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/.default" })))
                : Assert.Throws<AuthenticationFailedException>(() => credential.GetToken(new TokenRequestContext(new[] { "https://vault.azure.net/.default" })));

            // If MSAL retry was active, we'd see one or more extra requests.
            Assert.AreEqual(expectedCalls, requestCount, $"Expected exactly {expectedCalls} requests (1 initial + {maxRetries} Azure SDK retries). MSAL retry is not disabled.");
        }

        public class TestCredentialOptions : TokenCredentialOptions, ISupportsTokenCachePersistenceOptions
        {
            public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
        }
    }
}
