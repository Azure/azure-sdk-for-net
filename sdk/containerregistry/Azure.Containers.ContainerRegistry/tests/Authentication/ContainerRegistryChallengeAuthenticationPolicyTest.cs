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

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryChallengeAuthenticationPolicyTest : SyncAsyncPolicyTestBase
    {
        private readonly string TestAcrRefreshToken = "TestAcrRefreshToken";
        private readonly string TestAcrAccessToken = "TestAcrAccessToken";

        public ContainerRegistryChallengeAuthenticationPolicyTest(bool isAsync) : base(isAsync) { }

        private MockResponse GetChallengeResponse(string serviceName = "example")
        {
            MockResponse challengeResponse = new MockResponse(401);
            string challenge = $"Bearer realm=\"https://example.azurecr.io/oauth2/token\",service=\"{serviceName}.azurecr.io\",scope=\"repository:library/hello-world:metadata_read\",error=\"invalid_token\"";
            challengeResponse.AddHeader(new HttpHeader(HttpHeader.Names.WwwAuthenticate, challenge));
            return challengeResponse;
        }

        private MockAuthenticationClient GetMockAuthClient()
        {
            return new MockAuthenticationClient(
               service => new AcrRefreshToken(TestAcrRefreshToken),
               (service, scope) => new AcrAccessToken(TestAcrAccessToken));
        }

        private string GetMockJwt(TimeSpan expireIn)
        {
            long expireOn = (DateTimeOffset.UtcNow + expireIn).ToUnixTimeSeconds();
            string decodedHeader = "{header}";
            string decodedBody = $"{{ \"exp\": {expireOn} }}";
            string decodedSignature = "{signature}";
            return $"{Base64Url.EncodeString(decodedHeader)}.{Base64Url.EncodeString(decodedBody)}.{Base64Url.EncodeString(decodedSignature)}";
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_UsesTokenProvidedByAuthClient()
        {
            MockAuthenticationClient mockClient = GetMockAuthClient();
            MockCredential mockCredential = new MockCredential();

            var policy = new ContainerRegistryChallengeAuthenticationPolicy(mockCredential, "TestScope", mockClient);

            MockTransport transport = CreateMockTransport(GetChallengeResponse(), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.azurecr.io/acr/v1/hello-world/_tags/latest"), cancellationToken: default);

            MockRequest request = transport.Requests[0];

            Assert.IsTrue(request.Headers.TryGetValue(HttpHeader.Names.Authorization, out string authHeaderValue));
            Assert.AreEqual("Bearer TestAcrAccessToken", authHeaderValue);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_CachesRefreshToken()
        {
            // Arrange
            int refreshTokenRequests = 0;
            int accessTokenRequests = 0;

            string mockJwt = GetMockJwt(TimeSpan.FromHours(3));

            // We expect the refresh token request method to be called only the first time.
            MockAuthenticationClient mockClient = new MockAuthenticationClient(
                service =>
                {
                    refreshTokenRequests++;
                    return new AcrRefreshToken(mockJwt);
                },
                (service, scope) =>
                {
                    accessTokenRequests++;
                    return new AcrAccessToken($"TestAcrAccessToken{accessTokenRequests}");
                });
            MockCredential mockCredential = new MockCredential();

            var policy = new ContainerRegistryChallengeAuthenticationPolicy(mockCredential, "TestScope", mockClient);

            // We'll send two GET requests - each will receive a challenge response
            MockTransport transport = CreateMockTransport(
                GetChallengeResponse(), new MockResponse(200),
                GetChallengeResponse(), new MockResponse(200));

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
        public async Task ContainerRegistryChallengeAuthenticationPolicy_ExpiresRefreshToken()
        {
            // Arrange
            int refreshTokenRequests = 0;
            int accessTokenRequests = 0;
            TimeSpan expiryTime = TimeSpan.FromSeconds(2);

            string mockJwt = GetMockJwt(expiryTime);

            // We expect the refresh token request method to be called the first and third times.
            MockAuthenticationClient mockClient = new MockAuthenticationClient(
                service =>
                {
                    refreshTokenRequests++;
                    return new AcrRefreshToken(mockJwt);
                },
                (service, scope) =>
                {
                    accessTokenRequests++;
                    return new AcrAccessToken($"TestAcrAccessToken{accessTokenRequests}");
                });
            MockCredential mockCredential = new MockCredential();

            // We set refresh offset to zero so we don't try to refresh it before it expires.
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(mockCredential, "TestScope", mockClient, tokenRefreshOffset: TimeSpan.FromSeconds(0));

            // We'll send three GET requests - each will receive a challenge response
            // In the last one, the token will have expired so a new request for it will be sent
            MockTransport transport = CreateMockTransport(
                GetChallengeResponse(), new MockResponse(200),
                GetChallengeResponse(), new MockResponse(200),
                GetChallengeResponse(), new MockResponse(200));

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

            // Wait for bg thread to complete its refresh request.
            await Task.Delay(TimeSpan.FromSeconds(1));

            // Assert
            Assert.IsTrue(thirdRequest.Headers.TryGetValue(HttpHeader.Names.Authorization, out authHeaderValue));
            Assert.AreEqual("Bearer TestAcrAccessToken3", authHeaderValue);
            Assert.AreEqual(2, refreshTokenRequests);
            Assert.AreEqual(3, accessTokenRequests);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_RefreshesRefreshToken()
        {
            // Arrange
            int refreshTokenRequests = 0;
            int accessTokenRequests = 0;
            TimeSpan refreshOffset = TimeSpan.FromSeconds(30);
            TimeSpan expiryTime = TimeSpan.FromSeconds(32);

            string mockJwt = GetMockJwt(expiryTime);

            // We expect the refresh token request method to be called the first and third times.
            MockAuthenticationClient mockClient = new MockAuthenticationClient(
                service =>
                {
                    refreshTokenRequests++;
                    return new AcrRefreshToken(mockJwt);
                },
                (service, scope) =>
                {
                    accessTokenRequests++;
                    return new AcrAccessToken($"TestAcrAccessToken{accessTokenRequests}");
                });
            MockCredential mockCredential = new MockCredential();

            // Set expiration 5 seconds longer than refresh time.  Result should be that it tries to refresh in 5 seconds.
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(mockCredential, "TestScope", mockClient, tokenRefreshOffset: refreshOffset);

            // We'll send three GET requests - each will receive a challenge response
            // In the last one, the token will need to be refreshed so a new request for it will be sent
            MockTransport transport = CreateMockTransport(
                GetChallengeResponse(), new MockResponse(200),
                GetChallengeResponse(), new MockResponse(200),
                GetChallengeResponse(), new MockResponse(200));

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
            await Task.Delay(expiryTime - refreshOffset);

            await SendGetRequest(transport, policy, uri: new Uri("https://example.azurecr.io/acr/v1/hello-world/_tags/latest"), cancellationToken: default);
            MockRequest thirdRequest = transport.Requests[4];

            // Wait for bg thread to complete its refresh request.
            await Task.Delay(TimeSpan.FromSeconds(1));

            // Assert
            Assert.IsTrue(thirdRequest.Headers.TryGetValue(HttpHeader.Names.Authorization, out authHeaderValue));
            Assert.AreEqual("Bearer TestAcrAccessToken3", authHeaderValue);
            Assert.AreEqual(2, refreshTokenRequests);
            Assert.AreEqual(3, accessTokenRequests);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_RequestsTokenOnForceRefresh()
        {
            // Arrange
            int refreshTokenRequests = 0;
            int accessTokenRequests = 0;

            MockAuthenticationClient mockClient = new MockAuthenticationClient(
                service =>
                {
                    refreshTokenRequests++;
                    return new AcrRefreshToken(GetMockJwt(TimeSpan.FromHours(3)));
                },
               (service, scope) =>
               {
                   accessTokenRequests++;
                   return new AcrAccessToken($"TestAcrAccessToken{accessTokenRequests}");
               });
            MockCredential mockCredential = new MockCredential();

            var policy = new ContainerRegistryChallengeAuthenticationPolicy(mockCredential, "TestScope", mockClient);

            // Getting a different service name will invalidate the token and force a refresh.
            MockTransport transport = CreateMockTransport(
                GetChallengeResponse("example1"), new MockResponse(200),
                GetChallengeResponse("example2"), new MockResponse(200));

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
            Assert.AreEqual(2, refreshTokenRequests);
            Assert.AreEqual(2, accessTokenRequests);
        }

        [Test]
        public void ContainerRegistryChallengeAuthenticationPolicy_ThrowsForNonTlsEndpoint()
        {
            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(new MockCredential(), "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: new Uri("http://example.com")));
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_OneHundredConcurrentCalls()
        {
            MockAuthenticationClient mockAuthClient = new MockAuthenticationClient(
            service => new AcrRefreshToken("TestAcrRefreshToken"),
            (service, scope) =>
            {
                Thread.Sleep(10);
                return new AcrAccessToken("TestAcrAccessToken");
            });

            var policy = new ContainerRegistryChallengeAuthenticationPolicy(new MockCredential(), "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport(r => GetChallengeResponse());
            var requestTasks = new Task<Response>[100];

            for (int i = 0; i < requestTasks.Length; i++)
            {
                requestTasks[i] = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            }

            await Task.WhenAll(requestTasks);
            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));

            for (int i = 1; i < requestTasks.Length; i++)
            {
                Assert.True(transport.Requests[i].Headers.TryGetValue("Authorization", out string authValue));
                Assert.AreEqual(auth1Value, authValue);
            }
        }

        [Test]
        public void ContainerRegistryChallengeAuthenticationPolicy_OneHundredConcurrentCallsFailed()
        {
            MockAuthenticationClient mockAuthClient = new MockAuthenticationClient(
            service =>
            {
                Thread.Sleep(10);
                throw new InvalidOperationException("Error");
            },
            (service, scope) =>
            {
                return new AcrAccessToken("TestAcrAccessToken");
            });

            var policy = new ContainerRegistryChallengeAuthenticationPolicy(new MockCredential(), "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport(r => GetChallengeResponse());
            var requestTasks = new Task<Response>[100];

            for (int i = 0; i < requestTasks.Length; i++)
            {
                requestTasks[i] = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            }

            Assert.CatchAsync(async () => await Task.WhenAll(requestTasks));

            foreach (Task<Response> task in requestTasks)
            {
                Assert.IsTrue(task.IsFaulted);
            }
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
