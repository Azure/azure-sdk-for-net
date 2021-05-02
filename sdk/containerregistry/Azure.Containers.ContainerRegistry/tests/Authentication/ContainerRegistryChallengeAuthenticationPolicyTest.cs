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
            MockAuthenticationClient mockClient = new MockAuthenticationClient(
                service => new AcrRefreshToken("TestAcrRefreshToken"),
                (service, scope) => new AcrAccessToken("TestAcrAccessToken"));
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

        [Test]
        public async Task ChallengePolicyCachesRefreshToken()
        {
            // Arrange
            int refreshTokenRequests = 0;
            int accessTokenRequests = 0;

            MockAuthenticationClient mockClient = new MockAuthenticationClient(
                service =>
                {
                    refreshTokenRequests++;
                    return new AcrRefreshToken($"TestAcrRefreshToken{refreshTokenRequests}");
                },
                (service, scope) =>
                {
                    accessTokenRequests++;
                    return new AcrAccessToken($"TestAcrAccessToken{accessTokenRequests}");
                });
            MockCredential mockCredential = new MockCredential();

            var policy = new ContainerRegistryChallengeAuthenticationPolicy(mockCredential, "TestScope", mockClient);

            var challengeResponse = new MockResponse(401);
            string challenge = "Bearer realm=\"https://example.azurecr.io/oauth2/token\",service=\"example.azurecr.io\",scope=\"repository:library/hello-world:metadata_read\",error=\"invalid_token\"";
            challengeResponse.AddHeader(new HttpHeader(HttpHeader.Names.WwwAuthenticate, challenge));

            // We'll send two GET requests - each will receive a challenge response
            MockTransport transport = CreateMockTransport(
                challengeResponse, new MockResponse(200),
                challengeResponse, new MockResponse(200));

            // Act
            await SendGetRequest(transport, policy, uri: new Uri("https://example.azurecr.io/acr/v1/hello-world/_tags/latest"), cancellationToken: default);
            MockRequest firstRequest = transport.Requests[0];

            // Assert
            string authHeaderValue;
            Assert.IsTrue(firstRequest.Headers.TryGetValue(HttpHeader.Names.Authorization, out authHeaderValue));
            Assert.AreEqual("Bearer TestAcrAccessToken1", authHeaderValue);
            Assert.AreEqual(1, refreshTokenRequests);
            Assert.AreEqual(1, accessTokenRequests);

            // Act
            await SendGetRequest(transport, policy, uri: new Uri("https://example.azurecr.io/acr/v1/hello-world/_tags/latest"), cancellationToken: default);
            MockRequest secondRequest = transport.Requests[2];

            // Assert
            Assert.IsTrue(secondRequest.Headers.TryGetValue(HttpHeader.Names.Authorization, out authHeaderValue));
            Assert.AreEqual("Bearer TestAcrAccessToken2", authHeaderValue);
            Assert.AreEqual(1, refreshTokenRequests);
            Assert.AreEqual(2, accessTokenRequests);
        }

        [Test]
        public async Task ChallengePolicyRefreshTokenExpires()
        {
            // Arrange
            int refreshTokenRequests = 0;
            int accessTokenRequests = 0;
            TimeSpan expiryTime = TimeSpan.FromSeconds(5);

            MockAuthenticationClient mockClient = new MockAuthenticationClient(
                service =>
                {
                    refreshTokenRequests++;
                    return new AcrRefreshToken($"TestAcrRefreshToken{refreshTokenRequests}");
                },
                (service, scope) =>
                {
                    accessTokenRequests++;
                    return new AcrAccessToken($"TestAcrAccessToken{accessTokenRequests}");
                });
            MockCredential mockCredential = new MockCredential();

            // We set refresh offset to zero so we don't try to refresh it before it expires.
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(mockCredential, "TestScope", mockClient, tokenRefreshOffset: TimeSpan.FromSeconds(0), tokenExpiryOffset: expiryTime);

            var challengeResponse = new MockResponse(401);
            string challenge = "Bearer realm=\"https://example.azurecr.io/oauth2/token\",service=\"example.azurecr.io\",scope=\"repository:library/hello-world:metadata_read\",error=\"invalid_token\"";
            challengeResponse.AddHeader(new HttpHeader(HttpHeader.Names.WwwAuthenticate, challenge));

            // We'll send three GET requests - each will receive a challenge response
            // In the last one, the token will have expired so a new request for it will be sent
            MockTransport transport = CreateMockTransport(
                challengeResponse, new MockResponse(200),
                challengeResponse, new MockResponse(200),
                challengeResponse, new MockResponse(200));

            // Act
            await SendGetRequest(transport, policy, uri: new Uri("https://example.azurecr.io/acr/v1/hello-world/_tags/latest"), cancellationToken: default);
            MockRequest firstRequest = transport.Requests[0];

            // Assert
            string authHeaderValue;
            Assert.IsTrue(firstRequest.Headers.TryGetValue(HttpHeader.Names.Authorization, out authHeaderValue));
            Assert.AreEqual("Bearer TestAcrAccessToken1", authHeaderValue);
            Assert.AreEqual(1, refreshTokenRequests);
            Assert.AreEqual(1, accessTokenRequests);

            // Act
            await SendGetRequest(transport, policy, uri: new Uri("https://example.azurecr.io/acr/v1/hello-world/_tags/latest"), cancellationToken: default);
            MockRequest secondRequest = transport.Requests[2];

            // Assert
            Assert.IsTrue(secondRequest.Headers.TryGetValue(HttpHeader.Names.Authorization, out authHeaderValue));
            Assert.AreEqual("Bearer TestAcrAccessToken2", authHeaderValue);
            Assert.AreEqual(1, refreshTokenRequests);
            Assert.AreEqual(2, accessTokenRequests);

            // Act
            await Task.Delay(expiryTime);

            await SendGetRequest(transport, policy, uri: new Uri("https://example.azurecr.io/acr/v1/hello-world/_tags/latest"), cancellationToken: default);
            MockRequest thirdRequest = transport.Requests[4];

            // Assert
            Assert.IsTrue(thirdRequest.Headers.TryGetValue(HttpHeader.Names.Authorization, out authHeaderValue));
            Assert.AreEqual("Bearer TestAcrAccessToken3", authHeaderValue);
            Assert.AreEqual(2, refreshTokenRequests);
            Assert.AreEqual(3, accessTokenRequests);
        }
    }
}
