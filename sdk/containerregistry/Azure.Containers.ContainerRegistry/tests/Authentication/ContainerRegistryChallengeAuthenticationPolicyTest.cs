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

        private MockResponse GetChallengeResponse()
        {
            MockResponse challengeResponse = new MockResponse(401);
            string challenge = "Bearer realm=\"https://example.azurecr.io/oauth2/token\",service=\"example.azurecr.io\",scope=\"repository:library/hello-world:metadata_read\",error=\"invalid_token\"";
            challengeResponse.AddHeader(new HttpHeader(HttpHeader.Names.WwwAuthenticate, challenge));
            return challengeResponse;
        }

        private MockAuthenticationClient GetMockAuthClient()
        {
            return new MockAuthenticationClient(
               service => new AcrRefreshToken(TestAcrRefreshToken),
               (service, scope) => new AcrAccessToken(TestAcrAccessToken));
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_SetsToken()
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

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_UsesTokenProvidedByCredentials()
        {
            //var credential = new TokenCredentialStub(
            //    (r, c) => r.Scopes.SequenceEqual(new[] { "scope1", "scope2" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default, IsAsync);

            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope1" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            //var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, new[] { "scope1", "scope2" }, mockAuthClient);
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope1", mockAuthClient);

            MockTransport transport = CreateMockTransport(new MockResponse(200));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.SingleRequest.Headers.TryGetValue("Authorization", out string authValue));
            Assert.AreEqual("Bearer token", authValue);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_RequestsTokenEveryRequest()
        {
            var accessTokens = new Queue<AccessToken>();
            accessTokens.Enqueue(new AccessToken("token1", DateTimeOffset.UtcNow));
            accessTokens.Enqueue(new AccessToken("token2", DateTimeOffset.UtcNow));

            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope1" }) ? accessTokens.Dequeue() : default, IsAsync);

            //var credential = new TokenCredentialStub(
            //    (r, c) => r.Scopes.SequenceEqual(new[] { "scope1", "scope2" }) ? accessTokens.Dequeue() : default, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope1", mockAuthClient);
            // var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, new[] { "scope1", "scope2" }, mockAuthClient);
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreEqual("Bearer token1", auth1Value);
            Assert.AreEqual("Bearer token2", auth2Value);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_CachesHeaderValue()
        {
            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport(GetChallengeResponse(), new MockResponse(200), GetChallengeResponse(), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreEqual($"Bearer {TestAcrAccessToken}", auth1Value);
            Assert.AreEqual($"Bearer {TestAcrAccessToken}", auth2Value);
        }

        [Test]
        public void ContainerRegistryChallengeAuthenticationPolicy_ThrowsForNonTlsEndpoint()
        {
            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: new Uri("http://example.com")));
        }

        [Test]
        public void ContainerRegistryChallengeAuthenticationPolicy_ThrowsForEmptyToken()
        {
            var credential = new TokenCredentialStub((r, c) => new AccessToken(string.Empty, DateTimeOffset.MaxValue), IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: new Uri("http://example.com")));
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_OneHundredConcurrentCalls()
        {
            var credential = new TokenCredentialStub((r, c) =>
            {
                Thread.Sleep(100);
                return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddMinutes(30));
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
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

        private bool IsEven(int value)
        {
            return (value % 2 == 0);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_GatedConcurrentCalls()
        {
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddMinutes(30));
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            requestMre.Wait();

            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            responseMre.Set();

            await Task.WhenAll(firstRequestTask, secondRequestTask);

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreEqual(auth1Value, auth2Value);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_SucceededFailedSucceeded()
        {
            var requestMre = new ManualResetEventSlim(false);
            var callCount = 0;
            var credential = new TokenCredentialStub((r, c) =>
            {
                Interlocked.Increment(ref callCount);
                var offsetTime = DateTimeOffset.UtcNow;
                requestMre.Set();

                return callCount == 2
                    ? throw new InvalidOperationException("Call Failed")
                    : new AccessToken(Guid.NewGuid().ToString(), offsetTime.AddMilliseconds(1000));
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient, TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(30));
            MockTransport transport = CreateMockTransport(r => new MockResponse(200));

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/1"));
            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/2"));

            requestMre.Wait();
            await Task.Delay(200);

            await Task.WhenAll(firstRequestTask, secondRequestTask);
            await Task.Delay(1000);

            Assert.AreEqual(1, callCount);
            requestMre.Reset();

            var failedTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/3/failed"));
            requestMre.Wait();

            Assert.AreEqual(2, callCount);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await failedTask);

            requestMre.Reset();

            firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/4"));
            secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/5"));

            requestMre.Wait();

            await Task.WhenAll(firstRequestTask, secondRequestTask);

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue("Authorization", out string auth3Value));
            Assert.True(transport.Requests[3].Headers.TryGetValue("Authorization", out string auth4Value));

            Assert.AreEqual(3, callCount);
            Assert.AreEqual(auth1Value, auth2Value);
            Assert.AreNotEqual(auth2Value, auth3Value);
            Assert.AreEqual(auth3Value, auth4Value);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_TokenAlmostExpired()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var currentTime = DateTimeOffset.UtcNow;
            var expires = new Queue<DateTimeOffset>(new[] { currentTime.AddMinutes(2), currentTime.AddMinutes(30) });
            var callCount = 0;
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                requestMre.Reset();
                callCount++;

                return new AccessToken(Guid.NewGuid().ToString(), expires.Dequeue());
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/1/Original"));
            responseMre.Reset();

            Task requestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/3/Refresh"));
            requestMre.Wait();

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/2/AlmostExpired"));
            await requestTask;
            responseMre.Set();
            await Task.Delay(1_000);

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/4/AfterRefresh"));

            Assert.AreEqual(2, callCount);

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue("Authorization", out string auth3Value));
            Assert.True(transport.Requests[3].Headers.TryGetValue("Authorization", out string auth4Value));

            Assert.AreEqual(auth1Value, auth2Value);
            Assert.AreEqual(auth2Value, auth3Value);
            Assert.AreNotEqual(auth3Value, auth4Value);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_TokenAlmostExpired_NoRefresh()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var currentTime = DateTimeOffset.UtcNow;
            var callCount = 0;

            var credential = new TokenCredentialStub((r, c) =>
            {
                callCount++;
                responseMre.Wait(c);
                requestMre.Set();

                return new AccessToken(Guid.NewGuid().ToString(), currentTime.AddMinutes(2));
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/1/Original"));
            requestMre.Wait();
            responseMre.Reset();

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/2/AlmostExpired"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/3/AlmostExpired"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/4/AlmostExpired"));

            requestMre.Reset();
            responseMre.Set();
            requestMre.Wait();

            Assert.AreEqual(2, callCount);

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue("Authorization", out string auth3Value));
            Assert.True(transport.Requests[3].Headers.TryGetValue("Authorization", out string auth4Value));

            Assert.AreEqual(auth1Value, auth2Value);
            Assert.AreEqual(auth2Value, auth3Value);
            Assert.AreEqual(auth3Value, auth4Value);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_TokenExpired()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var currentTime = DateTimeOffset.UtcNow;
            var expires = new Queue<DateTimeOffset>(new[] { currentTime.AddSeconds(2), currentTime.AddMinutes(30) });
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                return new AccessToken(Guid.NewGuid().ToString(), expires.Dequeue());
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient, TimeSpan.FromSeconds(2), TimeSpan.FromMilliseconds(50));
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/0"));
            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string authValue));

            await Task.Delay(3_000);

            requestMre.Reset();
            responseMre.Reset();

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/1"));
            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/2"));
            requestMre.Wait();
            await Task.Delay(1_000);
            responseMre.Set();

            await Task.WhenAll(firstRequestTask, secondRequestTask);

            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreNotEqual(authValue, auth1Value);
            Assert.AreEqual(auth1Value, auth2Value);
        }

        [Test]
        public void ContainerRegistryChallengeAuthenticationPolicy_OneHundredConcurrentCallsFailed()
        {
            var credential = new TokenCredentialStub((r, c) =>
            {
                Thread.Sleep(100);
                throw new InvalidOperationException("Error");
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
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

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_GatedConcurrentCallsFailed()
        {
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                throw new InvalidOperationException("Error");
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport(GetChallengeResponse(), new MockResponse(200));

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            requestMre.Wait();
            await Task.Delay(1_000);
            responseMre.Set();

            Assert.CatchAsync(async () => await Task.WhenAll(firstRequestTask, secondRequestTask));

            Assert.IsTrue(firstRequestTask.IsFaulted);
            Assert.IsTrue(secondRequestTask.IsFaulted);
            Assert.AreEqual(firstRequestTask.Exception.InnerException, secondRequestTask.Exception.InnerException);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_TokenExpiredThenFailed()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var fail = false;
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                if (fail)
                {
                    throw new InvalidOperationException("Error");
                }

                fail = true;
                return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddSeconds(2));
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient, TimeSpan.FromSeconds(2), TimeSpan.FromMilliseconds(50));
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/0"));
            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string _));

            await Task.Delay(3_000);

            requestMre.Reset();
            responseMre.Reset();

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            requestMre.Wait();
            await Task.Delay(1_000);
            responseMre.Set();

            Assert.CatchAsync(async () => await Task.WhenAll(firstRequestTask, secondRequestTask));

            Assert.IsTrue(firstRequestTask.IsFaulted);
            Assert.IsTrue(secondRequestTask.IsFaulted);
            Assert.AreEqual(firstRequestTask.Exception.InnerException, secondRequestTask.Exception.InnerException);
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/14612")]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_TokenAlmostExpiredThenFailed()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var credentialMre = new ManualResetEventSlim(false);

            var getTokenRequestTimes = new List<DateTimeOffset>();
            var transportCallCount = 0;
            var credential = new TokenCredentialStub((r, c) =>
            {
                if (transportCallCount > 0)
                {
                    credentialMre.Set();
                    getTokenRequestTimes.Add(DateTimeOffset.UtcNow);
                    throw new InvalidOperationException("Error");
                }

                return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddMinutes(1.5));
            }, IsAsync);

            var tokenRefreshRetryDelay = TimeSpan.FromSeconds(2);
            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient, TimeSpan.FromMinutes(2), tokenRefreshRetryDelay);
            MockTransport transport = CreateMockTransport(r =>
            {
                requestMre.Set();
                responseMre.Wait();
                if (Interlocked.Increment(ref transportCallCount) == 4)
                {
                    credentialMre.Wait();
                }
                return new MockResponse(200);
            });

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/1"));
            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));

            requestMre.Reset();
            responseMre.Reset();

            Task requestTask1 = SendGetRequest(transport, policy, uri: new Uri("https://example.com/2/TokenFromCache/RefreshInBackground"));
            Task requestTask2 = SendGetRequest(transport, policy, uri: new Uri("https://example.com/3/TokenFromCache/"));

            requestMre.Wait();
            responseMre.Set();

            await Task.WhenAll(requestTask1, requestTask2);

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/4/TokenFromCache"));

            await Task.Delay((int)tokenRefreshRetryDelay.TotalMilliseconds + 1_000);
            credentialMre.Reset();

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/5/TokenFromCache/GetTokenFailed"));
            credentialMre.Wait();

            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue("Authorization", out string auth3Value));
            Assert.True(transport.Requests[3].Headers.TryGetValue("Authorization", out string auth4Value));
            Assert.True(transport.Requests[4].Headers.TryGetValue("Authorization", out string auth5Value));

            Assert.AreEqual(auth1Value, auth2Value);
            Assert.AreEqual(auth2Value, auth3Value);
            Assert.AreEqual(auth3Value, auth4Value);
            Assert.AreEqual(auth4Value, auth5Value);

            Assert.AreEqual(2, getTokenRequestTimes.Count);
            Assert.True(getTokenRequestTimes[1] - getTokenRequestTimes[0] > tokenRefreshRetryDelay);
        }

        [Test]
        public void ContainerRegistryChallengeAuthenticationPolicy_GatedConcurrentCallsCancelled()
        {
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var cts = new CancellationTokenSource();
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                throw new InvalidOperationException("Error");
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);
            requestMre.Wait();

            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: cts.Token);
            cts.Cancel();

            Assert.CatchAsync<OperationCanceledException>(async () => await secondRequestTask);
            responseMre.Set();

            Assert.CatchAsync<InvalidOperationException>(async () => await firstRequestTask);
        }

        [Test]
        public async Task ContainerRegistryChallengeAuthenticationPolicy_CancelledFirstRequestDoesNotCancelPendingSecondRequest()
        {
            var currentTime = DateTime.UtcNow;
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var cts = new CancellationTokenSource();
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                return new AccessToken(Guid.NewGuid().ToString(), currentTime.AddMinutes(2));
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport((req) => new MockResponse(200));

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: cts.Token);
            requestMre.Wait();

            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);
            cts.Cancel();

            Assert.CatchAsync<OperationCanceledException>(async () => await firstRequestTask);
            responseMre.Set();

            var response = await secondRequestTask;
            Assert.That(response.Status, Is.EqualTo(200));
        }

        [Test]
        public void ContainerRegistryChallengeAuthenticationPolicy_CancelledFirstRequestAndCancelledSecondRequest()
        {
            var currentTime = DateTime.UtcNow;
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var cts1 = new CancellationTokenSource();
            var cts2 = new CancellationTokenSource();
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                return new AccessToken(Guid.NewGuid().ToString(), currentTime.AddMinutes(2));
            }, IsAsync);

            MockAuthenticationClient mockAuthClient = GetMockAuthClient();
            var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
            MockTransport transport = CreateMockTransport((req) =>
            {
                return new MockResponse(200);
            });

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: cts1.Token);
            requestMre.Wait();

            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: cts2.Token);
            cts1.Cancel();
            cts2.Cancel();

            Assert.CatchAsync<OperationCanceledException>(async () => await firstRequestTask);
            responseMre.Set();

            Assert.CatchAsync<OperationCanceledException>(async () => await secondRequestTask);
        }

        [Test]
        [Repeat(10)]
        public void ContainerRegistryChallengeAuthenticationPolicy_UnobservedTaskException()
        {
            var unobservedTaskExceptionWasRaised = false;
            var expectedFailedException = new RequestFailedException("Communication Error");
            try
            {
                TaskScheduler.UnobservedTaskException += UnobservedTaskExceptionHandler;
                var credential =
                    new TokenCredentialStub((_, ct) => throw expectedFailedException,
                        IsAsync);

                MockAuthenticationClient mockAuthClient = GetMockAuthClient();
                var policy = new ContainerRegistryChallengeAuthenticationPolicy(credential, "scope", mockAuthClient);
                MockTransport transport = CreateMockTransport((_) => new MockResponse(500));

                Assert.ThrowsAsync<RequestFailedException>(async () =>
                    await SendRequestAsync(transport, request => { request.Uri.Scheme = "https"; }, policy));

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            finally
            {
                TaskScheduler.UnobservedTaskException -= UnobservedTaskExceptionHandler;
            }

            Assert.False(unobservedTaskExceptionWasRaised, "UnobservedTaskException should not be raised");

            void UnobservedTaskExceptionHandler(object sender, UnobservedTaskExceptionEventArgs args)
            {
                if (args.Exception.InnerException == null ||
                    args.Exception.InnerException.ToString() != expectedFailedException.ToString())
                    return;

                args.SetObserved();
                unobservedTaskExceptionWasRaised = true;
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
