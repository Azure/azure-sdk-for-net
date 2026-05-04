// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

#pragma warning disable AZID0001 // AdditionalQueryParameters is experimental
        [Test]
        public void AdditionalQueryParametersAreForwardedToBuilder()
        {
            var options = new ClientSecretCredentialOptions
            {
                Transport = new MockTransport(),
                DisableInstanceDiscovery = true,
            };
            options.AdditionalQueryParameters["feature"] = ("agenticSession", false);
            options.AdditionalQueryParameters["session_id"] = ("abc-123", true);

            var pipeline = CredentialPipeline.GetInstance(options);
            var client = new MockMsalConfidentialClient(pipeline, "tenant", "client", "secret", "https://redirect", options);

            // Verify the parameters were snapshotted into the MSAL client
            var stored = client.GetAdditionalQueryParameters();
            Assert.IsNotNull(stored);
            Assert.AreEqual(2, stored.Count);
            Assert.AreEqual(("agenticSession", false), stored["feature"]);
            Assert.AreEqual(("abc-123", true), stored["session_id"]);

            // Verify it's a snapshot (mutation of the original doesn't affect the client)
            options.AdditionalQueryParameters["new_param"] = ("new_value", false);
            Assert.IsFalse(stored.ContainsKey("new_param"));

            // Verify the builder still works
            Assert.DoesNotThrowAsync(async () => await client.CallCreateClientAsync(false, true, default));
        }

        [Test]
        public async Task AdditionalQueryParametersAreIncludedInRequests()
        {
            var mockTransport = new MockTransport(req =>
            {
                var response = new MockResponse(400);
                response.SetContent("{\"error\":\"invalid_grant\",\"error_description\":\"bad request\"}");
                return response;
            });

            var options = new ClientSecretCredentialOptions
            {
                Transport = mockTransport,
                Retry = { MaxRetries = 0 },
                DisableInstanceDiscovery = true,
            };
#pragma warning disable AZID0001
            options.AdditionalQueryParameters["feature"] = ("agenticSession", false);
            options.AdditionalQueryParameters["session_id"] = ("abc-123", true);
#pragma warning restore AZID0001

            var credential = new ClientSecretCredential("tenant", "client", "secret", options);

            Assert.ThrowsAsync<AuthenticationFailedException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/.default" })));

            Assert.IsNotEmpty(mockTransport.Requests);
            var tokenRequest = mockTransport.Requests.Find(r => r.Uri.Path.Contains("/oauth2/v2.0/token"));
            Assert.IsNotNull(tokenRequest, "Expected a token request to /oauth2/v2.0/token");

            var query = tokenRequest.Uri.Query;
            Assert.IsTrue(query.Contains("feature=agenticSession"), $"Expected 'feature=agenticSession' in query: {query}");
            Assert.IsTrue(query.Contains("session_id=abc-123"), $"Expected 'session_id=abc-123' in query: {query}");
        }

        [Test]
        public void DefaultEmptyAdditionalQueryParametersDoesNotThrow()
        {
            var options = new ClientSecretCredentialOptions
            {
                Transport = new MockTransport(),
                DisableInstanceDiscovery = true,
            };

            var pipeline = CredentialPipeline.GetInstance(options);
            var client = new MockMsalConfidentialClient(pipeline, "tenant", "client", "secret", "https://redirect", options);

            Assert.IsNull(client.GetAdditionalQueryParameters());
            Assert.DoesNotThrowAsync(async () => await client.CallCreateClientAsync(false, true, default));
        }
#pragma warning restore AZID0001

        public class TestCredentialOptions : TokenCredentialOptions, ISupportsTokenCachePersistenceOptions
        {
            public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }
        }
    }
}
