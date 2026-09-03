// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    [NonParallelizable]
    public class ChallengeBasedAuthenticationPolicyTests
    {
        [SetUp]
        public void Setup()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        private static string Base64(string value) => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));

        // Regression test: a single ChallengeBasedAuthenticationPolicy instance must not reuse a challenge
        // (or the token acquired for its scope and tenant) that was cached for one endpoint on a request to a
        // different endpoint. Before the fix, the second request's pre-challenge fast path reused the first
        // endpoint's sticky challenge, attaching the first vault's token to a request bound for the second.
        [TestCase(true)]
        [TestCase(false)]
        public async Task DoesNotReuseTokenAcrossAuthorities(bool async)
        {
            const string hostA = "a.vault.azure.net";
            const string hostB = "b.vault.azure.net";
            const string tenantA = "11111111-1111-1111-1111-111111111111";
            const string tenantB = "22222222-2222-2222-2222-222222222222";
            string tokenA = Base64(tenantA);
            string tokenB = Base64(tenantB);

            List<string> authHeadersSentToHostB = new();

            MockResponse Challenge(string tenant)
            {
                MockResponse response = new(401, "Unauthorized");
                response.AddHeader(new HttpHeader("WWW-Authenticate", @$"Bearer authorization=""https://login.windows.net/{tenant}"", resource=""https://vault.azure.net"""));
                return response;
            }

            MockTransport transport = new(request =>
            {
                string auth = request.Headers.TryGetValue("Authorization", out string value) ? value : null;
                switch (request.Uri.Host)
                {
                    case hostA:
                        return auth == $"Bearer {tokenA}"
                            ? new MockResponse(200, "OK")
                            : Challenge(tenantA);

                    case hostB:
                        if (auth != null)
                        {
                            authHeadersSentToHostB.Add(auth);
                        }
                        return auth == $"Bearer {tokenB}"
                            ? new MockResponse(200, "OK")
                            : Challenge(tenantB);

                    default:
                        throw new AssertionException($"Unexpected request: {request}");
                }
            });

            // The credential honors the tenant from the challenge and mints a token unique to that tenant.
            CallbackTokenCredential credential = new((requestContext, _) =>
                new AccessToken(Base64(requestContext.TenantId), DateTimeOffset.UtcNow.AddHours(1)));

            ChallengeBasedAuthenticationPolicy policy = new(credential, disableChallengeResourceVerification: false);
            HttpPipeline pipeline = new(transport, new HttpPipelinePolicy[] { policy });

            async Task SendAsync(string host)
            {
                Request request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"https://{host}/keys/test?api-version=7.4"));
                Response response = async
                    ? await pipeline.SendRequestAsync(request, default)
                    : pipeline.SendRequest(request, default);
                Assert.AreEqual(200, response.Status);
            }

            // First, authenticate against host A. This populates the shared challenge cache and the base
            // policy's token cache for tenant A.
            await SendAsync(hostA);

            // Then reuse the same policy instance for a different host. Host A's token must not be attached.
            await SendAsync(hostB);

            CollectionAssert.DoesNotContain(
                authHeadersSentToHostB,
                $"Bearer {tokenA}",
                "The first endpoint's token was reused on a request to a different endpoint.");
            CollectionAssert.Contains(
                authHeadersSentToHostB,
                $"Bearer {tokenB}",
                "The second endpoint was never authenticated with its own token.");
        }

        // Regression test for the concurrent variant: interleaved requests to two endpoints on a single policy
        // instance must each be authorized with their own endpoint's token. Because no challenge is memoized on
        // the policy instance, a request bound for one endpoint can never observe the other endpoint's challenge.
        [TestCase(10, 0, 0)]
        [TestCase(10, 20, 200)]
        public async Task DoesNotReuseTokenAcrossAuthoritiesConcurrently(int requestsPerHost, int minDelay, int maxDelay)
        {
            const string hostA = "a.vault.azure.net";
            const string hostB = "b.vault.azure.net";
            const string tenantA = "11111111-1111-1111-1111-111111111111";
            const string tenantB = "22222222-2222-2222-2222-222222222222";
            string tokenA = Base64(tenantA);
            string tokenB = Base64(tenantB);

            Random rand = new();

            MockResponse Challenge(string tenant)
            {
                MockResponse response = new(401, "Unauthorized");
                response.AddHeader(new HttpHeader("WWW-Authenticate", @$"Bearer authorization=""https://login.windows.net/{tenant}"", resource=""https://vault.azure.net"""));
                return response;
            }

            // Assert on every authenticated request as it is processed: a request to one host must never carry
            // the other host's token.
            MockTransport transport = new(request =>
            {
                int delay;
                lock (rand)
                {
                    delay = rand.Next(minDelay, maxDelay);
                }

                if (delay > 0)
                {
                    Thread.Sleep(delay);
                }

                string auth = request.Headers.TryGetValue("Authorization", out string value) ? value : null;
                switch (request.Uri.Host)
                {
                    case hostA:
                        Assert.AreNotEqual($"Bearer {tokenB}", auth, "Host B's token was attached to a host A request.");
                        return auth == $"Bearer {tokenA}" ? new MockResponse(200, "OK") : Challenge(tenantA);

                    case hostB:
                        Assert.AreNotEqual($"Bearer {tokenA}", auth, "Host A's token was attached to a host B request.");
                        return auth == $"Bearer {tokenB}" ? new MockResponse(200, "OK") : Challenge(tenantB);

                    default:
                        throw new AssertionException($"Unexpected request: {request}");
                }
            });

            CallbackTokenCredential credential = new((requestContext, _) =>
                new AccessToken(Base64(requestContext.TenantId), DateTimeOffset.UtcNow.AddHours(1)));

            ChallengeBasedAuthenticationPolicy policy = new(credential, disableChallengeResourceVerification: false);
            HttpPipeline pipeline = new(transport, new HttpPipelinePolicy[] { policy });

            async Task SendAsync(string host)
            {
                Request request = pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"https://{host}/keys/test?api-version=7.4"));
                Response response = await pipeline.SendRequestAsync(request, default);
                Assert.AreEqual(200, response.Status);
            }

            Task[] tasks = new Task[requestsPerHost * 2];
            for (int i = 0; i < requestsPerHost; i++)
            {
                tasks[2 * i] = Task.Run(() => SendAsync(hostA));
                tasks[2 * i + 1] = Task.Run(() => SendAsync(hostB));
            }

            await Task.WhenAll(tasks);
        }

        private class CallbackTokenCredential : TokenCredential
        {
            private readonly Func<TokenRequestContext, CancellationToken, AccessToken> _callback;

            public CallbackTokenCredential(Func<TokenRequestContext, CancellationToken, AccessToken> callback)
            {
                _callback = callback;
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _callback(requestContext, cancellationToken);

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new ValueTask<AccessToken>(_callback(requestContext, cancellationToken));
        }
    }
}
