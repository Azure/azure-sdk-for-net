// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Tests
{
    public class ChallengeBasedAuthenticationPolicyTests : SyncAsyncPolicyTestBase
    {
        internal ChallengeBasedAuthenticationPolicy _policy;
        private const string KeyVaultChallenge = "Bearer authorization=\"https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47\", resource=\"https://vault.azure.net\"";
        public ChallengeBasedAuthenticationPolicyTests(bool isAsync) : base(isAsync)
        {
            _policy = new ChallengeBasedAuthenticationPolicy(new MockCredentialThrowsWithNoScopes());
        }

        [Test]
        [NonParallelizable]
        public async Task ScopesAreInitializedFromCache()
        {
            // Clear the cache to ensure the test starts with an empty cache.
            ChallengeBasedAuthenticationPolicy.ClearCache();

            var keyvaultChallengeResponse = new MockResponse(401);
            keyvaultChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", KeyVaultChallenge));
            MockTransport transport = CreateMockTransport(keyvaultChallengeResponse, new MockResponse(200));

            var response = await SendGetRequest(transport, _policy, uri: new Uri("https://example.com"));

            Assert.That(response.Status, Is.EqualTo(200));

            // Construct a new policy so that we can get the Scopes from cache.
            _policy = new ChallengeBasedAuthenticationPolicy(new MockCredentialThrowsWithNoScopes());

            transport = CreateMockTransport(keyvaultChallengeResponse, new MockResponse(200));
            response = await SendGetRequest(transport, _policy, uri: new Uri("https://example.com"));

            Assert.That(response.Status, Is.EqualTo(200));
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
