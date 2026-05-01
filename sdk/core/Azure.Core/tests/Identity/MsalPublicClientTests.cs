// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests.Identity.Mock;
using Microsoft.Identity.Client;
using NUnit.Framework;

using Azure.Identity;
namespace Azure.Core.Tests.Identity
{
    public class MsalPublicClientTests
    {
        [Test]
        public void CreateClientRespectsCaeConfig(
            [Values(true, false)] bool enableCae,
            [Values(true, false)] bool async)
        {
            var mock = new MockMsalPublicClient
            {
                ClientAppFactory = (useCae) =>
                {
                    Assert.AreEqual(useCae, enableCae);
                    return Moq.Mock.Of<IPublicClientApplication>();
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
            var client = new MockMsalPublicClient(
                CredentialPipeline.GetInstance(options),
                "tenant",
                Guid.NewGuid().ToString(),
                "https://redirect",
                options);

            await client.CallBaseGetClientAsync(true, true, default);
            await client.CallBaseGetClientAsync(false, true, default);
            var caeEnabledCache = await client.GetTokenCache(true);
            var caeDisabledCache = await client.GetTokenCache(false);

            Assert.True(caeEnabledCache.IsCaeEnabled);
            Assert.False(caeDisabledCache.IsCaeEnabled);
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

            var options = new UsernamePasswordCredentialOptions
            {
                Transport = mockTransport,
                Retry = { MaxRetries = maxRetries, Delay = System.TimeSpan.Zero, MaxDelay = System.TimeSpan.Zero, Mode = Core.RetryMode.Fixed },
                DisableInstanceDiscovery = true // Disable instance discovery to avoid extra requests
            };

            var credential = new UsernamePasswordCredential("username", "password", "tenant", "client", options);

            var ex = async
                ? Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/.default" })))
                : Assert.Throws<AuthenticationFailedException>(() => credential.GetToken(new TokenRequestContext(new[] { "https://vault.azure.net/.default" })));

            // If MSAL retry was active, we'd see one or more extra requests.
            Assert.AreEqual(expectedCalls, requestCount, $"Expected exactly {expectedCalls} requests (1 initial + {maxRetries} Azure SDK retries). If this is {expectedCalls + 1}, MSAL retry is not disabled.");
        }

#pragma warning disable AZID5001 // AdditionalQueryParameters is experimental
        [Test]
        public void AdditionalQueryParametersAreForwardedToBuilder()
        {
            var extraParams = new Dictionary<string, (string Value, bool IncludeInCacheKey)>
            {
                ["feature"] = ("agenticSession", false),
                ["session_id"] = ("abc-123", true)
            };

            var options = new InteractiveBrowserCredentialOptions
            {
                Transport = new MockTransport(),
                DisableInstanceDiscovery = true,
                AdditionalQueryParameters = extraParams
            };

            var pipeline = CredentialPipeline.GetInstance(options);
            var client = new MockMsalPublicClient(pipeline, "tenant", Guid.NewGuid().ToString(), "https://redirect", options);

            // Verify the parameters were snapshotted into the MSAL client
            var stored = client.GetAdditionalQueryParameters();
            Assert.IsNotNull(stored);
            Assert.AreEqual(2, stored.Count);
            Assert.AreEqual(("agenticSession", false), stored["feature"]);
            Assert.AreEqual(("abc-123", true), stored["session_id"]);

            // Verify it's a snapshot (mutation of the original doesn't affect the client)
            extraParams["new_param"] = ("new_value", false);
            Assert.IsFalse(stored.ContainsKey("new_param"));

            // Verify the builder still works
            Assert.DoesNotThrowAsync(async () => await client.CallCreateClientAsync(false, true, default));
        }

        [Test]
        public void NullAdditionalQueryParametersDoesNotThrow()
        {
            var options = new InteractiveBrowserCredentialOptions
            {
                Transport = new MockTransport(),
                DisableInstanceDiscovery = true,
                AdditionalQueryParameters = null
            };

            var pipeline = CredentialPipeline.GetInstance(options);
            var client = new MockMsalPublicClient(pipeline, "tenant", Guid.NewGuid().ToString(), "https://redirect", options);

            Assert.IsNull(client.GetAdditionalQueryParameters());
            Assert.DoesNotThrowAsync(async () => await client.CallCreateClientAsync(false, true, default));
        }

        [Test]
        public void EmptyAdditionalQueryParametersDoesNotThrow()
        {
            var options = new InteractiveBrowserCredentialOptions
            {
                Transport = new MockTransport(),
                DisableInstanceDiscovery = true,
                AdditionalQueryParameters = new Dictionary<string, (string Value, bool IncludeInCacheKey)>()
            };

            var pipeline = CredentialPipeline.GetInstance(options);
            var client = new MockMsalPublicClient(pipeline, "tenant", Guid.NewGuid().ToString(), "https://redirect", options);

            Assert.IsNull(client.GetAdditionalQueryParameters());
            Assert.DoesNotThrowAsync(async () => await client.CallCreateClientAsync(false, true, default));
        }
#pragma warning restore AZID5001

        public class TestCredentialOptions : TokenCredentialOptions, ISupportsTokenCachePersistenceOptions
        {
            public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
        }
    }
}
