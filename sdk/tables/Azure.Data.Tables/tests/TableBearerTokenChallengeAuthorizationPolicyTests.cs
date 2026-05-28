// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class TableBearerTokenChallengeAuthorizationPolicyTests : SyncAsyncPolicyTestBase
    {
        public TableBearerTokenChallengeAuthorizationPolicyTests(bool isAsync) : base(isAsync) { }

        private readonly string[] _scopes = { "https://storage.azure.com/.default" };
        private string _expectedTenantId;
        private MockCredential _cred;

        [SetUp]
        public void Setup()
        {
            int callCount = 0;
            _expectedTenantId = null;
            _cred = new MockCredential
            {
                GetTokenCallback = (trc, _) =>
                {
                    ++callCount;
                    Assert.AreEqual(_scopes, trc.Scopes);
                    Assert.AreEqual(_expectedTenantId, trc.TenantId);
                    // Validate that the token cache is working.
                    Assert.That(callCount, Is.LessThanOrEqualTo(1));
                }
            };
        }

        [Test]
        public async Task UsesTokenProvidedByCredentials()
        {
            var policy = new TableBearerTokenChallengeAuthorizationPolicy(_cred, _scopes[0], false);

            MockTransport transport = CreateMockTransport(new MockResponse(200));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.SingleRequest.Headers.TryGetValue("Authorization", out _));
        }

        [Test]
        public async Task DoesNotSendUnauthorizedRequestWhenEnableTenantDiscoveryIsFalse([Values(true, false)] bool enableTenantDiscovery)
        {
            var policy = new TableBearerTokenChallengeAuthorizationPolicy(_cred, _scopes[0], false);

            MockTransport transport = CreateMockTransport(_ => new MockResponse(200));

            for (int i = 0; i < 10; i++)
            {
                await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            }
            Assert.True(transport.Requests.All(r => r.Headers.TryGetValue("Authorization", out _)));
        }

        [Test]
        public async Task SendsUnauthorizedRequestWhenEnableTenantDiscoveryIsTrue([Values(true, false)] bool enableTenantDiscovery)
        {
            var policy = new TableBearerTokenChallengeAuthorizationPolicy(_cred, _scopes[0], enableTenantDiscovery);
            bool firstRequest = true;
            var challengeReponse = new MockResponse((int)HttpStatusCode.Unauthorized);
            if (enableTenantDiscovery)
            {
                _expectedTenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            }
            challengeReponse.AddHeader(
                new HttpHeader(
                    HttpHeader.Names.WwwAuthenticate,
                    $"Bearer authorization_uri=https://login.microsoftonline.com/{_expectedTenantId}/oauth2/authorize resource_id=https://storage.azure.com"));

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

            // if enableTenantDiscovery is true, the first request should be unauthorized
            if (enableTenantDiscovery)
            {
                Assert.False(transport.Requests[0].Headers.TryGetValue("Authorization", out _));
            }
            // If enableTenantDiscovery is true, all but the first request should be authorized.
            Assert.True(transport.Requests.Skip(enableTenantDiscovery ? 1 : 0).All(r => r.Headers.TryGetValue("Authorization", out _)));
        }
    }
}
