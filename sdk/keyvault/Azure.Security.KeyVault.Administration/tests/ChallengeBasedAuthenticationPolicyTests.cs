// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Tests
{
    [NonParallelizable]
    public class ChallengeBasedAuthenticationPolicyTests : SyncAsyncPolicyTestBase
    {
        internal ChallengeBasedAuthenticationPolicy _policy;
        private const string KeyVaultChallenge = "Bearer authorization=\"https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47\", resource=\"https://vault.azure.net\"";
        public ChallengeBasedAuthenticationPolicyTests(bool isAsync) : base(isAsync)
        {
            _policy = new ChallengeBasedAuthenticationPolicy(new MockCredentialThrowsWithNoScopes(), false);
        }

        [SetUp]
        public void SetUp()
        {
            // Clear the cache to ensure the test starts with an empty cache.
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [Test]
        public async Task ScopesAreInitializedFromCache()
        {
            var keyvaultChallengeResponse = new MockResponse(401);
            keyvaultChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", KeyVaultChallenge));
            MockTransport transport = CreateMockTransport(keyvaultChallengeResponse, new MockResponse(200));

            Response response = await SendGetRequest(transport, _policy, uri: new Uri("https://myvault.vault.azure.net"));

            Assert.That(response.Status, Is.EqualTo(200));

            // Construct a new policy so that we can get the Scopes from cache.
            _policy = new ChallengeBasedAuthenticationPolicy(new MockCredentialThrowsWithNoScopes(), false);

            transport = CreateMockTransport(new MockResponse(200));
            response = await SendGetRequest(transport, _policy, uri: new Uri("https://myvault.vault.azure.net"));

            Assert.That(response.Status, Is.EqualTo(200));
        }

        [TestCaseSource(nameof(VerifyChallengeResourceData))]
        public async Task VerifyChallengeResource(Uri uri, bool disableVerification)
        {
            var keyvaultChallengeResponse = new MockResponse(401);
            keyvaultChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", KeyVaultChallenge));
            MockTransport transport = CreateMockTransport(keyvaultChallengeResponse, new MockResponse(200));

            ChallengeBasedAuthenticationPolicy policy = new(new MockCredentialThrowsWithNoScopes(), disableVerification);

            if (!disableVerification)
            {
                InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: uri));
                Assert.That(ex.Message, Is.EqualTo("The challenge resource 'vault.azure.net' does not match the requested domain. Set DisableChallengeResourceVerification to true in your client options to disable. See https://aka.ms/azsdk/blog/vault-uri for more information."));
            }
            else
            {
                Response response = await SendGetRequest(transport, policy, uri: uri);
                Assert.That(response.Status, Is.EqualTo(200));
            }
        }

        private static IEnumerable<object[]> VerifyChallengeResourceData => new[]
        {
            "https://example.com",
            "https://examplevault.azure.net",
            "https://example.vault.azure.com",
        }.Zip(new[] { false, true }, (uri, disableVerification) => new object[] { new Uri(uri), disableVerification });

        [Test]
        public void VerifyChallengeResourceInvalidUri()
        {
            var keyvaultChallengeResponse = new MockResponse(401);
            keyvaultChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", "Bearer authorization=\"https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47\", resource=\"invalid-uri\""));
            MockTransport transport = CreateMockTransport(keyvaultChallengeResponse, new MockResponse(200));

            ChallengeBasedAuthenticationPolicy policy = new(new MockCredentialThrowsWithNoScopes(), false);
            Uri uri = new("https://example.com");

            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: uri));
            Assert.That(ex.Message, Is.EqualTo("The challenge contains invalid scope 'invalid-uri/.default'."));
        }

        // Regression test: a single ChallengeBasedAuthenticationPolicy instance must not reuse a challenge
        // (or the token acquired for its scope and tenant) that was cached for one endpoint on a request to a
        // different endpoint. Before the fix, the pre-challenge fast path reused the first endpoint's sticky
        // challenge, attaching the first vault's token to a request bound for the second. The base fixture runs
        // this test for both the sync and async pipelines.
        [Test]
        public async Task DoesNotReuseTokenAcrossAuthorities()
        {
            const string hostA = "a.vault.azure.net";
            const string hostB = "b.vault.azure.net";
            const string tenantA = "11111111-1111-1111-1111-111111111111";
            const string tenantB = "22222222-2222-2222-2222-222222222222";
            string tokenA = Base64(tenantA);
            string tokenB = Base64(tenantB);

            List<string> authHeadersSentToHostB = new();

            static MockResponse Challenge(string tenant)
            {
                MockResponse response = new(401);
                response.AddHeader(new HttpHeader("WWW-Authenticate", @$"Bearer authorization=""https://login.windows.net/{tenant}"", resource=""https://vault.azure.net"""));
                return response;
            }

            MockTransport transport = new(request =>
            {
                string auth = request.Headers.TryGetValue("Authorization", out string value) ? value : null;
                switch (request.Uri.Host)
                {
                    case hostA:
                        return auth == $"Bearer {tokenA}" ? new MockResponse(200) : Challenge(tenantA);

                    case hostB:
                        if (auth != null)
                        {
                            authHeadersSentToHostB.Add(auth);
                        }
                        return auth == $"Bearer {tokenB}" ? new MockResponse(200) : Challenge(tenantB);

                    default:
                        throw new AssertionException($"Unexpected request: {request}");
                }
            });

            // The credential honors the tenant from the challenge and mints a token unique to that tenant.
            CallbackTokenCredential credential = new((requestContext, _) =>
                new AccessToken(Base64(requestContext.TenantId), DateTimeOffset.UtcNow.AddHours(1)));

            // A single policy instance is reused for both endpoints.
            ChallengeBasedAuthenticationPolicy policy = new(credential, disableChallengeResourceVerification: false);

            Response responseA = await SendGetRequest(transport, policy, uri: new Uri($"https://{hostA}"));
            Assert.That(responseA.Status, Is.EqualTo(200));

            Response responseB = await SendGetRequest(transport, policy, uri: new Uri($"https://{hostB}"));
            Assert.That(responseB.Status, Is.EqualTo(200));

            CollectionAssert.DoesNotContain(
                authHeadersSentToHostB,
                $"Bearer {tokenA}",
                "The first endpoint's token was reused on a request to a different endpoint.");
            CollectionAssert.Contains(
                authHeadersSentToHostB,
                $"Bearer {tokenB}",
                "The second endpoint was never authenticated with its own token.");
        }

        private static string Base64(string value) => Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value));

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

        public class MockCredentialThrowsWithNoScopes : TokenCredential
        {
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                if (requestContext.Scopes.Length != 1)
                {
                    Assert.Fail("TokenRequestContext contained no scopes.");
                }
                return new AccessToken("TEST TOKEN " + string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue);
            }
        }
    }
}
