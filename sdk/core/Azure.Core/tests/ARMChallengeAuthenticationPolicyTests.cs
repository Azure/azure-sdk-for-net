// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ARMChallengeAuthenticationPolicyTests : SyncAsyncPolicyTestBase
    {
        public ARMChallengeAuthenticationPolicyTests(bool isAsync) : base(isAsync) { }

        private const string CaeInsufficientClaimsChallenge = "Bearer realm=\"\", authorization_uri=\"https://login.microsoftonline.com/common/oauth2/authorize\", client_id=\"00000003-0000-0000-c000-000000000000\", error=\"insufficient_claims\", claims=\"eyJhY2Nlc3NfdG9rZW4iOiB7ImZvbyI6ICJiYXIifX0=\"";
        private const string CaeInsufficientClaimsChallengeValue = "eyJhY2Nlc3NfdG9rZW4iOiB7ImZvbyI6ICJiYXIifX0=";
        private const string CaeSessionsRevokedClaimsChallenge = "Bearer authorization_uri=\"https://login.windows-ppe.net/\", error=\"invalid_token\", error_description=\"User session has been revoked\", claims=\"eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwgInZhbHVlIjoiMTYwMzc0MjgwMCJ9fX0=\"";
        private const string CaeSessionsRevokedClaimsChallengeValue = "eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwgInZhbHVlIjoiMTYwMzc0MjgwMCJ9fX0=";
        private const string KeyVaultChallenge = "Bearer authorization=\"https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47\", resource=\"https://vault.azure.net\"";
        private const string ArmChallenge = "Bearer authorization_uri=\"https://login.windows.net/\", error=\"invalid_token\", error_description=\"The authentication failed because of missing 'Authorization' header.\"";

        [Test]
        public async Task ValidateClaimsChallengeTokenRequest()
        {
            string currentClaimChallenge = null;

            int tokensRequested = 0;

            var credential = new TokenCredentialStub((r, c) =>
            {
                tokensRequested++;

                Assert.AreEqual(currentClaimChallenge, r.Claims);

                return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow + TimeSpan.FromDays(1));
            }, IsAsync);

            var policy = new ARMChallengeAuthenticationPolicy(credential, "scope");

            var insufficientClaimsChallengeResponse = new MockResponse(401);

            insufficientClaimsChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", CaeInsufficientClaimsChallenge));

            var sessionRevokedChallengeResponse = new MockResponse(401);

            sessionRevokedChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", CaeSessionsRevokedClaimsChallenge));

            var armChallengeResponse = new MockResponse(401);

            armChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", ArmChallenge));

            var keyvaultChallengeResponse = new MockResponse(401);

            keyvaultChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", KeyVaultChallenge));

            MockTransport transport = CreateMockTransport(new MockResponse(200),
                insufficientClaimsChallengeResponse,
                new MockResponse(200),
                sessionRevokedChallengeResponse,
                new MockResponse(200),
                armChallengeResponse,
                keyvaultChallengeResponse);

            var response = await SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);

            Assert.AreEqual(tokensRequested, 1);

            Assert.AreEqual(response.Status, 200);

            currentClaimChallenge = Base64Url.DecodeString(CaeInsufficientClaimsChallengeValue);

            response = await SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);

            Assert.AreEqual(tokensRequested, 2);

            Assert.AreEqual(response.Status, 200);

            currentClaimChallenge = Base64Url.DecodeString(CaeSessionsRevokedClaimsChallengeValue);

            response = await SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);

            Assert.AreEqual(tokensRequested, 3);

            Assert.AreEqual(response.Status, 200);

            currentClaimChallenge = null;

            response = await SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);

            Assert.AreEqual(tokensRequested, 3);

            Assert.AreEqual(response.Status, 401);

            response = await SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);

            Assert.AreEqual(tokensRequested, 3);

            Assert.AreEqual(response.Status, 401);
        }

        private class TokenCredentialStub : TokenCredential
        {
            public TokenCredentialStub(Func<TokenRequestContext, CancellationToken, AccessToken> handler, bool isAsync)
            {
                if (isAsync)
                {
#pragma warning disable 1998
                    _getTokenAsyncHandler = async (r, c) => handler(r, c);
#pragma warning restore 1998
                }
                else
                {
                    _getTokenHandler = handler;
                }
            }

            private readonly Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> _getTokenAsyncHandler;
            private readonly Func<TokenRequestContext, CancellationToken, AccessToken> _getTokenHandler;

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenAsyncHandler(requestContext, cancellationToken);

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenHandler(requestContext, cancellationToken);
        }
    }
}
