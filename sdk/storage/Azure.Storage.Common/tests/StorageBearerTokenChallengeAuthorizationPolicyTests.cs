// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Storage.Shared;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Storage.Tests
{
    public class StorageBearerTokenChallengeAuthorizationPolicyTests : SyncAsyncPolicyTestBase
    {
        public StorageBearerTokenChallengeAuthorizationPolicyTests(bool isAsync) : base(isAsync) { }

        private string[] scopes = { "https://storage.azure.com/.default" };
        private string expectedTenantId;
        private MockCredential cred;

        [SetUp]
        public void Setup()
        {
            expectedTenantId = null;
            cred = new MockCredential
            {
                GetTokenCallback = (trc, _) =>
                {
                    Assert.AreEqual(scopes, trc.Scopes);
                    Assert.AreEqual(expectedTenantId, trc.TenantId);
                }
            };
        }

        [Test]
        public async Task UsesTokenProvidedByCredentials()
        {
            var policy = new StorageBearerTokenChallengeAuthorizationPolicy(cred, scopes, false);

            MockTransport transport = CreateMockTransport(new MockResponse(200));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.SingleRequest.Headers.TryGetValue("Authorization", out _));
        }

        [Test]
        public async Task DoesNotSendUnAuthroizedRequestWhenEnableTenantDiscoveryIsFalse([Values(true, false)] bool enableTenantDiscovery)
        {
            var policy = new StorageBearerTokenChallengeAuthorizationPolicy(cred, scopes, false);

            MockTransport transport = CreateMockTransport(_ => new MockResponse(200));

            for (int i = 0; i < 10; i++)
            {
                await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            }
            Assert.True(transport.Requests.All(r => r.Headers.TryGetValue("Authorization", out _)));
        }

        [Test]
        public async Task SendsUnUnAuthroizedRequestWhenEnableTenantDiscoveryIsTrue([Values(true, false)] bool enableTenantDiscovery)
        {
            var policy = new StorageBearerTokenChallengeAuthorizationPolicy(cred, scopes, enableTenantDiscovery);
            bool firstRequest = true;
            var challengeReponse = new MockResponse((int)HttpStatusCode.Unauthorized);
            if (enableTenantDiscovery)
            {
                expectedTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            }
            challengeReponse.AddHeader(
                new HttpHeader(
                    HttpHeader.Names.WwwAuthenticate,
                    $"Bearer authorization_uri=https://login.microsoftonline.com/{expectedTenantId}/oauth2/authorize resource_id=https://storage.azure.com"));

            MockTransport transport = CreateMockTransport(
                _ =>
                {
                    var response = firstRequest switch
                    {
                        false when enableTenantDiscovery => challengeReponse,
                        _ => new MockResponse(200)
                    };
                    firstRequest = false;
                    return response;
                });

            for (int i = 0; i < 10; i++)
            {
                await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            }

            // if enableTeanantDiscovery is true, the first request should be unauthorized
            if (enableTenantDiscovery)
            {
                Assert.False(transport.Requests[0].Headers.TryGetValue("Authorization", out _));
            }
            // If enableTenantDiscovery is true, all but the first request should be authorized.
            Assert.True(transport.Requests.Skip(enableTenantDiscovery ? 1 : 0).All(r => r.Headers.TryGetValue("Authorization", out _)));
        }

        [Test]
        public async Task UsesScopeFromBearerChallange()
        {
            // Arrange
            bool firstRequest = true;
            string initialMismatchedScope = "https://disk.compute.azure.com/.default";
            string serviceChallengeResponseScope = "https://storage.azure.com";

            string[] initialMismatchedScopes = new string[] { initialMismatchedScope };
            string[] serviceChallengeResponseScopes = new string[] { serviceChallengeResponseScope + "/.default" };
            int callCount = 0;
            MockCredential mockCredential = new MockCredential()
            {
                GetTokenCallback = (trc, _) =>
                {
                    Assert.IsTrue(callCount <= 1);
                    Assert.AreEqual(serviceChallengeResponseScopes, trc.Scopes);
                    callCount++;
                }
            };

            StorageBearerTokenChallengeAuthorizationPolicy tokenChallengeAuthorizationPolicy = new StorageBearerTokenChallengeAuthorizationPolicy(mockCredential, initialMismatchedScopes, enableTenantDiscovery: true);
            MockResponse challengeResponse = new MockResponse((int)HttpStatusCode.Unauthorized);
            challengeResponse.AddHeader(
                new HttpHeader(
                    HttpHeader.Names.WwwAuthenticate,
                    $"Bearer authorization_uri=https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47/oauth2/authorize resource_id={serviceChallengeResponseScope}"));

            MockTransport transport = CreateMockTransport(
                _ =>
                {
                    MockResponse response = firstRequest switch
                    {
                        true => challengeResponse,
                        false => new MockResponse(200)
                    };
                    firstRequest = false;
                    return response;
                });

            // Act
            await SendGetRequest(transport, tokenChallengeAuthorizationPolicy, uri: new Uri("https://example.com"));
            await SendGetRequest(transport, tokenChallengeAuthorizationPolicy, uri: new Uri("https://example.com"));
        }

        [Test]
        [TestCaseSource(nameof(CaeTestDetails))]
        public async Task StorageBearerTokenChallengeAuthorizationPolicy_CAE_TokenRevocation(string description, string challenge, int expectedResponseCode, string expectedClaims, string encodedClaims)
        {
            string serviceChallengeResponseScope = "https://storage.azure.com";
            string[] serviceChallengeResponseScopes = new string[] { serviceChallengeResponseScope + "/.default" };
            string claims = null;
            int callCount = 0;

            MockCredential mockCredential = new MockCredential()
            {
                GetTokenCallback = (trc, _) =>
                {
                    // Assert.AreEqual(serviceChallengeResponseScopes, trc.Scopes);
                    claims = trc.Claims;
                    Interlocked.Increment(ref callCount);
                    Assert.AreEqual(true, trc.IsCaeEnabled);
                }
            };

            var transport = CreateMockTransport(req =>
            {
                if (callCount <= 1)
                {
                    return challenge == null ? new(200) : new MockResponse(401).WithHeader("WWW-Authenticate", challenge);
                }
                else
                {
                    return new(200);
                }
            });

            var policy = new StorageBearerTokenChallengeAuthorizationPolicy(mockCredential, "scope", enableTenantDiscovery: false);

            using AzureEventSourceListener listener = new((args, text) =>
            {
                TestContext.WriteLine(text);
                if (args.EventName == "FailedToDecodeCaeChallengeClaims")
                {
                    Assert.That(text, Does.Contain($"'{encodedClaims}'"));
                }
            }, System.Diagnostics.Tracing.EventLevel.Error);

            var response = await SendGetRequest(transport, policy, uri: new("https://example.com/1/Original"));
            Assert.AreEqual(expectedClaims, claims);
            Assert.AreEqual(expectedResponseCode, response.Status);

            var response2 = await SendGetRequest(transport, policy, uri: new("https://example.com/1/Original"));
            if (expectedClaims != null)
            {
                Assert.IsNull(claims);
            }
        }

        private static IEnumerable<object[]> CaeTestDetails()
        {
            //args: description, challenge, expectedResponseCode, expectedClaims, encodedClaims
            yield return new object[] { "no challenge", null, 200, null, null };
            yield return new object[] { "unexpected error value", """Bearer authorization_uri="https://login.windows.net/", error="invalid_token", claims="ey==" """, 401, null, "ey==" };
            yield return new object[] { "unexpected error value", """Bearer authorization_uri="https://login.windows.net/", error="invalid_token", claims="ey==" """, 401, null, "ey==" };
            yield return new object[] { "parsing error", """Bearer claims="not base64", error="insufficient_claims" """, 401, null, "not base64" };
            yield return new object[] { "no padding", """Bearer error="insufficient_claims", authorization_uri="http://localhost", claims="ey" """, 401, null, "ey" };
            yield return new object[] { "more parameters, different order", """Bearer realm="", authorization_uri="http://localhost", client_id="00000003-0000-0000-c000-000000000000", error="insufficient_claims", claims="ey==" """, 200, "{", "ey==" };
            yield return new object[] { "more parameters, different order", """Bearer realm="", authorization_uri="http://localhost", client_id="00000003-0000-0000-c000-000000000000", error="insufficient_claims", claims="ey==" """, 200, "{", "ey==" };
            yield return new object[] { "standard", """Bearer realm="", authorization_uri="https://login.microsoftonline.com/common/oauth2/authorize", error="insufficient_claims", claims="eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwidmFsdWUiOiIxNzI2MDc3NTk1In0sInhtc19jYWVlcnJvciI6eyJ2YWx1ZSI6IjEwMDEyIn19fQ==" """, 200, """{"access_token":{"nbf":{"essential":true,"value":"1726077595"},"xms_caeerror":{"value":"10012"}}}""", "eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwidmFsdWUiOiIxNzI2MDc3NTk1In0sInhtc19jYWVlcnJvciI6eyJ2YWx1ZSI6IjEwMDEyIn19fQ==" };
            yield return new object[] { "multiple challenges", """PoP realm="", authorization_uri="https://login.microsoftonline.com/common/oauth2/authorize", client_id="00000003-0000-0000-c000-000000000000", nonce="ey==", Bearer realm="", authorization_uri="https://login.microsoftonline.com/common/oauth2/authorize", client_id="00000003-0000-0000-c000-000000000000", error_description="Continuous access evaluation resulted in challenge with result: InteractionRequired and code: TokenIssuedBeforeRevocationTimestamp", error="insufficient_claims", claims="eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwgInZhbHVlIjoiMTcyNjI1ODEyMiJ9fX0=" """, 200, """{"access_token":{"nbf":{"essential":true, "value":"1726258122"}}}""", "eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwgInZhbHVlIjoiMTcyNjI1ODEyMiJ9fX0=" };
        }
    }
}
