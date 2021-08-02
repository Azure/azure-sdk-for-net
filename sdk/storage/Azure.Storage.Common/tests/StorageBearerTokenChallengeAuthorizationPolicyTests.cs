﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Shared;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Storage.Tests
{
    public class StorageBearerTokenChallengeAuthorizationPolicyTests : SyncAsyncPolicyTestBase
    {
        public StorageBearerTokenChallengeAuthorizationPolicyTests(bool isAsync) : base(isAsync) { }

        private string[] scopes = { "scope1", "scope2" };
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
    }
}
