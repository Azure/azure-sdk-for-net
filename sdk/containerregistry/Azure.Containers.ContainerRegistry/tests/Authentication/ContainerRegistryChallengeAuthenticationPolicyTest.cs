// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryChallengeAuthenticationPolicyTest : SyncAsyncPolicyTestBase
    {
        public ContainerRegistryChallengeAuthenticationPolicyTest(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task ChallengePolicySetsToken()
        {
            MockAuthenticationClient mockClient = new MockAuthenticationClient();
            MockCredential mockCredential = new MockCredential();

            var policy = new ContainerRegistryChallengeAuthenticationPolicy(mockCredential, "TestScope", mockClient);

            var challengeResponse = new MockResponse(401);
            string challenge = "Bearer realm=\"https://example.azurecr.io/oauth2/token\",service=\"example.azurecr.io\",scope=\"repository:library/hello-world:metadata_read\",error=\"invalid_token\"";
            challengeResponse.AddHeader(new HttpHeader(HttpHeader.Names.WwwAuthenticate, challenge));

            MockTransport transport = CreateMockTransport(challengeResponse, new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.azurecr.io/acr/v1/hello-world/_tags/latest"), cancellationToken: default);

            MockRequest request = transport.Requests[0];

            Assert.IsTrue(request.Headers.TryGetValue(HttpHeader.Names.Authorization, out string authHeaderValue));
            Assert.AreEqual("Bearer TestAcrAccessToken", authHeaderValue);
        }
    }
}
