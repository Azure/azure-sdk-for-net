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
