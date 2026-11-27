// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
#if !NET462
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
#endif
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class BearerTokenAuthenticationPolicyTests : SyncAsyncPolicyTestBase
    {
        public BearerTokenAuthenticationPolicyTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_UsesTokenProvidedByCredentials()
        {
            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope1", "scope2" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default,
                IsAsync);
            var policy = new BearerTokenAuthenticationPolicy(credential, new[] { "scope1", "scope2" });

            MockTransport transport = CreateMockTransport(new MockResponse(200));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.SingleRequest.Headers.TryGetValue("Authorization", out string authValue));
            Assert.AreEqual("Bearer token", authValue);
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_RequestsTokenEveryRequest()
        {
            var accessTokens = new Queue<AccessToken>();
            accessTokens.Enqueue(new AccessToken("token1", DateTimeOffset.UtcNow));
            accessTokens.Enqueue(new AccessToken("token2", DateTimeOffset.UtcNow));

            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope1", "scope2" }) ? accessTokens.Dequeue() : default,
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, new[] { "scope1", "scope2" });
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreEqual("Bearer token1", auth1Value);
            Assert.AreEqual("Bearer token2", auth2Value);
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_RequestsTokenEveryRequest_InvalidExpiresOn()
        {
            var accessTokens = new Queue<AccessToken>();
            accessTokens.Enqueue(new AccessToken("token1", default));
            accessTokens.Enqueue(new AccessToken("token2", default));

            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope1", "scope2" }) ? accessTokens.Dequeue() : default,
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, new[] { "scope1", "scope2" });
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreEqual("Bearer token1", auth1Value);
            Assert.AreEqual("Bearer token2", auth2Value);
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_CachesHeaderValue()
        {
            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default,
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreSame(auth1Value, auth1Value);
            Assert.AreEqual("Bearer token", auth2Value);
        }

        [Test]
        public void BearerTokenAuthenticationPolicy_ThrowsForNonTlsEndpoint()
        {
            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default,
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: new Uri("http://example.com")));
        }

        [Test]
        public void BearerTokenAuthenticationPolicy_ThrowsForEmptyToken()
        {
            var credential = new TokenCredentialStub((r, c) => new AccessToken(string.Empty, DateTimeOffset.MaxValue), IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: new Uri("http://example.com")));
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_OneHundredConcurrentCalls()
        {
            var credential = new TokenCredentialStub((r, c) =>
                {
                    Thread.Sleep(100);
                    return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddMinutes(30));
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(r => new MockResponse(200));
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
        public async Task BearerTokenAuthenticationPolicy_GatedConcurrentCalls()
        {
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var credential = new TokenCredentialStub((r, c) =>
                {
                    requestMre.Set();
                    responseMre.Wait(c);
                    return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddMinutes(30));
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
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
        public async Task BearerTokenAuthenticationPolicy_SucceededFailedSucceeded()
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
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, new[] { "scope" }, TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(30));
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
        public async Task BearerTokenAuthenticationPolicy_TokenAlmostExpired()
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
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
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

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue("Authorization", out string auth3Value));
            Assert.True(transport.Requests[3].Headers.TryGetValue("Authorization", out string auth4Value));

            Assert.AreEqual(auth1Value, auth2Value);
            Assert.AreEqual(auth2Value, auth3Value);
            Assert.AreNotEqual(auth3Value, auth4Value);
            Assert.GreaterOrEqual(callCount, 2);
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_TokenNotAlmostExpiredWithRefreshOnNow()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var currentTime = DateTimeOffset.UtcNow;
            var expires = new Queue<DateTimeOffset>(new[] { currentTime.AddMinutes(10), currentTime.AddMinutes(30) });
            var callCount = 0;
            var credential = new TokenCredentialStub((r, c) =>
                {
                    requestMre.Set();
                    responseMre.Wait(c);
                    requestMre.Reset();
                    callCount++;

                    return new AccessToken(Guid.NewGuid().ToString(), expires.Dequeue(), refreshOn: currentTime);
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
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

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue("Authorization", out string auth3Value));
            Assert.True(transport.Requests[3].Headers.TryGetValue("Authorization", out string auth4Value));

            Assert.AreEqual(auth1Value, auth2Value);
            Assert.AreEqual(auth2Value, auth3Value);
            Assert.AreNotEqual(auth3Value, auth4Value);
            Assert.GreaterOrEqual(callCount, 2);
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_TokenAlmostExpired_NoRefresh()
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
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
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
        public async Task BearerTokenAuthenticationPolicy_TokenExpired()
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
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, new[] { "scope" }, TimeSpan.FromSeconds(2), TimeSpan.FromMilliseconds(50));
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
        public void BearerTokenAuthenticationPolicy_OneHundredConcurrentCallsFailed()
        {
            var credential = new TokenCredentialStub((r, c) =>
                {
                    Thread.Sleep(100);
                    throw new InvalidOperationException("Error");
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(r => new MockResponse(200));
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
        public void BearerTokenAuthenticationPolicy_GatedConcurrentCallsFailed()
        {
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var getTokenCallCount = 0;
            var credential = new TokenCredentialStub((r, c) =>
            {
                if (Interlocked.Increment(ref getTokenCallCount) == 1)
                {
                    requestMre.Set();
                    responseMre.Wait(c);
                }

                throw new InvalidOperationException($"Error");
            }, IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            requestMre.Wait();

            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            responseMre.Set();

            Assert.CatchAsync(async () => await Task.WhenAll(firstRequestTask, secondRequestTask));

            Assert.IsTrue(firstRequestTask.IsFaulted);
            Assert.IsTrue(secondRequestTask.IsFaulted);

            if (getTokenCallCount == 1)
            {
                Assert.AreEqual(firstRequestTask.Exception.InnerException, secondRequestTask.Exception.InnerException);
            }
            else
            {
                Assert.AreEqual(getTokenCallCount, 2);
            }
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_TokenExpiredThenFailed()
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
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, new[] { "scope" }, TimeSpan.FromSeconds(2), TimeSpan.FromMilliseconds(50));
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
        public async Task BearerTokenAuthenticationPolicy_TokenAlmostExpiredThenFailed()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var credentialMre = new ManualResetEventSlim(false);

            var getTokenRequestTimes = new ConcurrentQueue<DateTimeOffset>();
            var transportCallCount = 0;
            var credential = new TokenCredentialStub((r, c) =>
            {
                if (transportCallCount > 0)
                {
                    credentialMre.Set();
                    getTokenRequestTimes.Enqueue(DateTimeOffset.UtcNow);
                    throw new InvalidOperationException("Credential Error");
                }

                return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddMinutes(1.5));
            }, IsAsync);

            var tokenRefreshRetryDelay = TimeSpan.FromSeconds(2);
            var policy = new BearerTokenAuthenticationPolicy(credential, new[] { "scope" }, TimeSpan.FromMinutes(2), tokenRefreshRetryDelay);
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
            var getTokenRequestTimesList = getTokenRequestTimes.ToList();
            Assert.True(getTokenRequestTimesList[1] - getTokenRequestTimesList[0] > tokenRefreshRetryDelay);
        }

        [Test]
        public void BearerTokenAuthenticationPolicy_GatedConcurrentCallsCancelled()
        {
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var cts = new CancellationTokenSource();
            var credential = new TokenCredentialStub((r, c) =>
                {
                    requestMre.Set();
                    responseMre.Wait(c);
                    throw new InvalidOperationException("Error");
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
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
        public async Task BearerTokenAuthenticationPolicy_CancelledFirstRequestDoesNotCancelPendingSecondRequest()
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
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport((req) =>
            {
                return new MockResponse(200);
            });

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
        public void BearerTokenAuthenticationPolicy_CancelledFirstRequestAndCancelledSecondRequest()
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
                },
                IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport((req) =>
            {
                return new MockResponse(200);
            });

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example1.com"), cancellationToken: cts1.Token);
            requestMre.Wait();

            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example2.com"), cancellationToken: cts2.Token);
            cts1.Cancel();
            cts2.Cancel();

            Assert.CatchAsync<OperationCanceledException>(async () => await firstRequestTask);
            responseMre.Set();

            Assert.CatchAsync<OperationCanceledException>(async () => await secondRequestTask);
        }

        [Test]
        [Repeat(10)]
        public void BearerTokenAuthenticationPolicy_UnobservedTaskException()
        {
            var unobservedTaskExceptionWasRaised = false;
            var expectedFailedException = new RequestFailedException("Communication Error");
            try
            {
                TaskScheduler.UnobservedTaskException += UnobservedTaskExceptionHandler;
                var credential =
                    new TokenCredentialStub((_, ct) => throw expectedFailedException,
                        IsAsync);

                var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
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

        [Test]
        [Retry(3)] //https://github.com/Azure/azure-sdk-for-net/issues/21005
        [NonParallelizable]
        public async Task BearerTokenAuthenticationPolicy_BackgroundRefreshCancelledAndLogs()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var currentTime = DateTimeOffset.UtcNow;
            var expires = new ConcurrentQueue<DateTimeOffset>(new[] { currentTime.AddMinutes(2), currentTime.AddMinutes(30) });
            int requestCount = 0;
            var logged = false;
            string msg = "fail to refresh";
            var credential = new BearerTokenAuthenticationPolicyTests.TokenCredentialStub((r, c) =>
                {
                    TestContext.WriteLine($"Start TokenCredentialStub: requestCount: {requestCount}");
                    if (Interlocked.Increment(ref requestCount) > 1)
                    {
                        Task.Delay(100).GetAwaiter().GetResult();
                        throw new OperationCanceledException(msg);
                    }
                    requestMre.Set();
                    responseMre.Wait(c);
                    requestMre.Reset();

                    expires.TryDequeue(out var token);
                    TestContext.WriteLine($"End TokenCredentialStub: callCount: {requestCount}");
                    return new AccessToken(Guid.NewGuid().ToString(), token);
                },
                IsAsync);

            using AzureEventSourceListener listener = new((args, text) =>
            {
                TestContext.WriteLine(text);
                if (args.EventName == "BackgroundRefreshFailed" && text.Contains(msg))
                {
                    logged = true;
                }
            }, System.Diagnostics.Tracing.EventLevel.Informational);

            var policy = new BearerTokenAuthenticationPolicy(credential, new[] { "scope" }, TimeSpan.FromMinutes(5), TimeSpan.FromMilliseconds(10));
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/1/Original"));
            responseMre.Reset();

            Task requestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/3/Refresh"));
            // requestMre.Wait();

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/2/AlmostExpired"));
            await requestTask;
            responseMre.Set();
            await Task.Delay(1_000);

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/4/AfterRefresh"));

            Assert.IsTrue(logged);
        }

        [Test]
        [NonParallelizable]
        [Retry(3)] //https://github.com/Azure/azure-sdk-for-net/issues/21005
        public async Task BearerTokenAuthenticationPolicy_BackgroundRefreshFailsAndLogs()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var currentTime = DateTimeOffset.UtcNow;
            var expires = new Queue<DateTimeOffset>(new[] { currentTime.AddMinutes(2), currentTime.AddMinutes(30) });
            var callCount = 0;
            var logged = false;
            string msg = "fail to refresh";
            var credential = new BearerTokenAuthenticationPolicyTests.TokenCredentialStub((r, c) =>
                {
                    TestContext.WriteLine($"Start TokenCredentialStub: callCount: {callCount}");
                    if (callCount > 0)
                    {
                        throw new Exception(msg);
                    }
                    requestMre.Set();
                    responseMre.Wait(c);
                    requestMre.Reset();
                    callCount++;

                    TestContext.WriteLine($"End TokenCredentialStub: callCount: {callCount}");
                    return new AccessToken(Guid.NewGuid().ToString(), expires.Dequeue());
                },
                IsAsync);

            using AzureEventSourceListener listener = new((args, text) =>
            {
                TestContext.WriteLine(text);
                if (args.EventName == "BackgroundRefreshFailed" && text.Contains(msg))
                {
                    logged = true;
                }
            }, System.Diagnostics.Tracing.EventLevel.Informational);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/1/Original"));
            responseMre.Reset();

            Task requestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/3/Refresh"));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/2/AlmostExpired"));
            await requestTask;
            responseMre.Set();
            await Task.Delay(1_000);

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/4/AfterRefresh"));

            Assert.IsTrue(logged);
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_SwitchedTenants()
        {
            var responses = new[]
            {
                new MockResponse(401)
                    .WithHeader("WWW-Authenticate", @"Bearer authorization=""https://login.windows.net/de763a21-49f7-4b08-a8e1-52c8fbc103b4"", resource=""https://vault.azure.net"""),

                new MockResponse(200),
                new MockResponse(200),

                // Moved tenants.
                new MockResponse(401)
                    .WithHeader("WWW-Authenticate", @"Bearer authorization=""https://login.windows.net/72f988bf-86f1-41af-91ab-2d7cd011db47"", resource=""https://vault.azure.net""")
                    .WithJson("""
                    {
                        "error": {
                            "code": "Unauthorized",
                            "message": "AKV10032: Invalid issuer. Expected one of https://sts.windows.net/72f988bf-86f1-41af-91ab-2d7cd011db47/, https://sts.windows.net/f8cdef31-a31e-4b4a-93e4-5f571e91255a/, https://sts.windows.net/e2d54eb5-3869-4f70-8578-dee5fc7331f4/, https://sts.windows.net/33e01921-4d64-4f8c-a055-5bdaffd5e33d/, https://sts.windows.net/975f013f-7f24-47e8-a7d3-abc4752bf346/, found https://sts.windows.net/96be4b7a-defb-4dc2-a31f-49ee6145d5ab/."
                        }
                    }
                    """),

                new MockResponse(200),
            };

            var transport = CreateMockTransport(responses);

            string tenantId = null;
            int callCount = 0;
            var credential = new TokenCredentialStub((r, c) =>
            {
                tenantId = r.TenantId;
                Interlocked.Increment(ref callCount);

                return new(Guid.NewGuid().ToString(), DateTimeOffset.Now.AddHours(2));
            }, IsAsync);
            var policy = new ChallengeBasedAuthenticationTestPolicy(credential, "scope");

            await SendGetRequest(transport, policy, uri: new("https://example.com/1/Original"));
            Assert.AreEqual("de763a21-49f7-4b08-a8e1-52c8fbc103b4", tenantId);
            // This is initially 2 because the pipeline tries to pre-authenticate, then again when the test policy authenticates on a 401.
            Assert.AreEqual(2, callCount);

            await SendGetRequest(transport, policy, uri: new("https://example.com/1/Original"));
            Assert.AreEqual("de763a21-49f7-4b08-a8e1-52c8fbc103b4", tenantId);
            Assert.AreEqual(2, callCount);

            await SendGetRequest(transport, policy, uri: new("https://example.com/1/Original"));
            Assert.AreEqual("72f988bf-86f1-41af-91ab-2d7cd011db47", tenantId);
            // An additional call to TokenCredential.GetTokenAsync is expected now that the tenant has changed.
            Assert.AreEqual(3, callCount);
        }

        [Test]
        public async Task TokenCacheCurrentTcsTOkenIsExpiredAndBackgroundTcsInitialized()
        {
            var currentTcs = new TaskCompletionSource<BearerTokenAuthenticationPolicy.AccessTokenCache.AuthHeaderValueInfo>();
            var backgroundTcs = new TaskCompletionSource<BearerTokenAuthenticationPolicy.AccessTokenCache.AuthHeaderValueInfo>();

            currentTcs.SetResult(new BearerTokenAuthenticationPolicy.AccessTokenCache.AuthHeaderValueInfo("token", DateTimeOffset.UtcNow.AddMinutes(-5), DateTimeOffset.UtcNow.AddMinutes(-5)));

            TokenRequestContext ctx = new TokenRequestContext(new[] { "scope" });
            var cache = new BearerTokenAuthenticationPolicy.AccessTokenCache(
                new TokenCredentialStub((r, c) => new AccessToken(string.Empty, DateTimeOffset.MaxValue), IsAsync),
                TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(30))
            {
                _state = new BearerTokenAuthenticationPolicy.AccessTokenCache.TokenRequestState(
                    ctx,
                    currentTcs,
                    backgroundTcs
                    )
            };
            var msg = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);
            var cts = new CancellationTokenSource();
            cts.CancelAfter(5000);
            msg.CancellationToken = cts.Token;
            await cache.GetAuthHeaderValueAsync(msg, ctx, IsAsync);
        }

        [Test]
        public async Task TokenCacheCurrentTcsIsCancelledAndBackgroundTcsInitialized()
        {
            var currentTcs = new TaskCompletionSource<BearerTokenAuthenticationPolicy.AccessTokenCache.AuthHeaderValueInfo>();
            var backgroundTcs = new TaskCompletionSource<BearerTokenAuthenticationPolicy.AccessTokenCache.AuthHeaderValueInfo>();

            currentTcs.SetCanceled();

            TokenRequestContext ctx = new TokenRequestContext(new[] { "scope" });
            var cache = new BearerTokenAuthenticationPolicy.AccessTokenCache(
                new TokenCredentialStub((r, c) => new AccessToken(string.Empty, DateTimeOffset.MaxValue), IsAsync),
                TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(30))
            {
                _state = new BearerTokenAuthenticationPolicy.AccessTokenCache.TokenRequestState(
                    ctx,
                    currentTcs,
                    backgroundTcs
                    )
            };
            var msg = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);
            var cts = new CancellationTokenSource();
            cts.CancelAfter(5000);
            msg.CancellationToken = cts.Token;
            await cache.GetAuthHeaderValueAsync(msg, ctx, IsAsync);
        }

        [Test]
        [TestCaseSource(nameof(CaeTestDetails))]
        public async Task BearerTokenAuthenticationPolicy_CAE_TokenRevocation(string description, string challenge, int expectedResponseCode, string expectedClaims, string encodedClaims)
        {
            string claims = null;
            int callCount = 0;

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

            var credential = new TokenCredentialStub((r, c) =>
            {
                claims = r.Claims;
                Interlocked.Increment(ref callCount);
                Assert.AreEqual(true, r.IsCaeEnabled);

                return new(callCount.ToString(), DateTimeOffset.Now.AddHours(2));
            }, IsAsync);
            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");

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

        [Test]
        public async Task BearerTokenAuthenticationPolicy_CrossHostRedirect_DoesNotReAttachAuthorization()
        {
            var callCount = 0;
            var credential = new TokenCredentialStub((r, c) =>
            {
                Interlocked.Increment(ref callCount);
                return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(2));
            }, IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");

            // MockTransport stores the Request by reference, so the Authorization header that
            // RedirectPolicy strips before the second hop also disappears from Requests[0].
            // Capture each request's Authorization header as it is sent.
            var observedAuth = new List<string>();
            var responses = new Queue<MockResponse>(new[]
            {
                new MockResponse(302).WithHeader("Location", "https://attacker.example/path"),
                new MockResponse(200),
            });
            var transport = CreateMockTransport(req =>
            {
                observedAuth.Add(req.Headers.TryGetValue("Authorization", out string value) ? value : null);
                return responses.Dequeue();
            });

            var pipeline = new HttpPipeline(transport, new HttpPipelinePolicy[] { RedirectPolicy.Shared, policy });

            await SendRequestAsync(pipeline, message =>
            {
                message.Request.Method = RequestMethod.Get;
                message.Request.Uri.Reset(new Uri("https://example.com/"));
                RedirectPolicy.SetAllowAutoRedirect(message, true);
            });

            Assert.AreEqual(2, transport.Requests.Count);
            Assert.AreEqual("https://attacker.example/path", transport.Requests[1].Uri.ToString());

            Assert.AreEqual("Bearer token", observedAuth[0],
                "Authorization header must be attached on the original-host request.");
            Assert.IsNull(observedAuth[1],
                "Authorization header must not be re-attached after a cross-host redirect.");

            Assert.AreEqual(1, callCount,
                "Credential must not be re-called when the redirect target host differs from the authorized host.");
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_SameHostRedirect_PreservesAuthorization()
        {
            var callCount = 0;
            var credential = new TokenCredentialStub((r, c) =>
            {
                Interlocked.Increment(ref callCount);
                return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(2));
            }, IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");

            var observedAuth = new List<string>();
            var responses = new Queue<MockResponse>(new[]
            {
                new MockResponse(302).WithHeader("Location", "/redirected"),
                new MockResponse(200),
            });
            var transport = CreateMockTransport(req =>
            {
                observedAuth.Add(req.Headers.TryGetValue("Authorization", out string value) ? value : null);
                return responses.Dequeue();
            });

            var pipeline = new HttpPipeline(transport, new HttpPipelinePolicy[] { RedirectPolicy.Shared, policy });

            await SendRequestAsync(pipeline, message =>
            {
                message.Request.Method = RequestMethod.Get;
                message.Request.Uri.Reset(new Uri("https://example.com/original"));
                RedirectPolicy.SetAllowAutoRedirect(message, true);
            });

            Assert.AreEqual(2, transport.Requests.Count);
            Assert.AreEqual("https://example.com/redirected", transport.Requests[1].Uri.ToString());

            Assert.AreEqual("Bearer token", observedAuth[0]);
            Assert.AreEqual("Bearer token", observedAuth[1],
                "Authorization header must be re-attached on same-host redirects.");

            Assert.AreEqual(1, callCount, "Credential should be served from cache on same-host redirect.");
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_CaeChallengeOnOriginalHost_IsStillHandled()
        {
            var callCount = 0;
            string lastClaims = null;
            var credential = new TokenCredentialStub((r, c) =>
            {
                Interlocked.Increment(ref callCount);
                lastClaims = r.Claims;
                return new AccessToken(callCount.ToString(), DateTimeOffset.UtcNow.AddHours(2));
            }, IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            var transport = CreateMockTransport(
                new MockResponse(401).WithHeader(
                    "WWW-Authenticate",
                    """Bearer realm="", authorization_uri="https://login.microsoftonline.com/common/oauth2/authorize", error="insufficient_claims", claims="eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwidmFsdWUiOiIxNzI2MDc3NTk1In0sInhtc19jYWVlcnJvciI6eyJ2YWx1ZSI6IjEwMDEyIn19fQ==" """),
                new MockResponse(200));

            var response = await SendGetRequest(transport, policy, uri: new Uri("https://example.com/Original"));

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(2, transport.Requests.Count);
            Assert.AreEqual(2, callCount, "CAE handler should call the credential a second time with claims.");
            Assert.IsNotNull(lastClaims, "Second credential call should carry decoded CAE claims.");
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_CaeChallengeFromRedirectTargetHost_IsSuppressed()
        {
            var callCount = 0;
            string lastClaims = null;
            var credential = new TokenCredentialStub((r, c) =>
            {
                Interlocked.Increment(ref callCount);
                lastClaims = r.Claims;
                return new AccessToken("token", DateTimeOffset.UtcNow.AddHours(2));
            }, IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");

            var observedAuth = new List<string>();
            var responses = new Queue<MockResponse>(new[]
            {
                new MockResponse(302).WithHeader("Location", "https://attacker.example/path"),
                new MockResponse(401).WithHeader(
                    "WWW-Authenticate",
                    """Bearer realm="", authorization_uri="https://login.microsoftonline.com/common/oauth2/authorize", error="insufficient_claims", claims="eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwidmFsdWUiOiIxNzI2MDc3NTk1In0sInhtc19jYWVlcnJvciI6eyJ2YWx1ZSI6IjEwMDEyIn19fQ==" """),
            });
            var transport = CreateMockTransport(req =>
            {
                observedAuth.Add(req.Headers.TryGetValue("Authorization", out string value) ? value : null);
                return responses.Dequeue();
            });

            var pipeline = new HttpPipeline(transport, new HttpPipelinePolicy[] { RedirectPolicy.Shared, policy });

            var message = await SendMessageRequestAsync(pipeline, msg =>
            {
                msg.Request.Method = RequestMethod.Get;
                msg.Request.Uri.Reset(new Uri("https://example.com/"));
                RedirectPolicy.SetAllowAutoRedirect(msg, true);
            });

            Assert.AreEqual(401, message.Response.Status,
                "The 401 from a redirect-target host must surface to the caller without an authenticated retry.");
            Assert.AreEqual(2, transport.Requests.Count,
                "The CAE handler must not retry against a redirect-target host.");

            Assert.AreEqual("Bearer token", observedAuth[0]);
            Assert.IsNull(observedAuth[1],
                "Authorization header must not be sent to a redirect-target host.");

            Assert.AreEqual(1, callCount,
                "Credential must not be re-called in response to a challenge from a redirect-target host.");
            Assert.IsNull(lastClaims,
                "Credential must not be called with CAE claims derived from a redirect-target host's challenge.");
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_ReAcquiresPerRequestUriEvenWhenCredentialReturnsPlainBearerToken()
        {
            // The URI-based cache invalidation is gated on both contexts having
            // IsProofOfPossessionEnabled=true — the *requested* PoP flag, not whether the
            // credential honored it — to close the concurrent-request race where a second
            // request arriving while the initial token acquisition is still in flight would
            // otherwise reuse the pending token (whose completion state isn't yet observable).
            // The trade-off is that a PoP-requesting caller whose credential silently returns
            // plain bearer tokens still gets one credential invocation per distinct URI. That
            // is the intended cost of opting into PoP; the CAE flow is unaffected because CAE
            // callers do not enable PoP and therefore never reach this branch.
            int callCount = 0;
            var credential = new TokenCredentialStub((_, _) =>
                {
                    Interlocked.Increment(ref callCount);
                    return new AccessToken("bearer-token", DateTimeOffset.UtcNow.AddHours(1));
                },
                IsAsync);

            var policy = new ProofOfPossessionTestPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/resource-a"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/resource-b"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/resource-c"));

            Assert.AreEqual(3, callCount,
                "Cache invalidation must fire on URI change whenever PoP is requested, independent of what the credential returns.");
        }

#if !NET462
        // CertificateRequest was introduced in .NET Framework 4.7.2 and .NET Core 2.0, so the
        // PoP-bound token tests below are excluded from the net462 TFM.
        [Test]
        public async Task BearerTokenAuthenticationPolicy_ReAcquiresPerRequestUriWhileInitialAcquisitionIsInFlight()
        {
            // Regression coverage for
            // https://github.com/Azure/azure-sdk-for-net/pull/61654#discussion_r3817254121.
            // If IsCurrentContextMismatched gates the URI/method invalidation on the cached
            // token being observably PoP-bound (Task.Status == RanToCompletion && BindingCertificate != null),
            // then a second request for a different URI arriving while the very first
            // credential invocation is still in flight will slip through: the task is not yet
            // completed, the gate returns false, the context comparison reports "not
            // mismatched", and the second request awaits the first request's token — which is
            // bound to a different URI. Gating on *requested* PoP (present on both contexts)
            // closes this window because it does not depend on the cached token's completion.
            using var bindingCertificate = MakeSelfSignedCertificate();
            var contexts = new List<TokenRequestContext>();
            var gate = new ManualResetEventSlim(initialState: false);
            var firstCallStarted = new ManualResetEventSlim(false);
            var secondCallReached = new ManualResetEventSlim(false);
            var credential = new TokenCredentialStub((requestContext, cancellationToken) =>
                {
                    int index;
                    lock (contexts)
                    {
                        contexts.Add(requestContext);
                        index = contexts.Count;
                    }
                    if (index == 1)
                    {
                        firstCallStarted.Set();
                        // Block synchronously so the first credential invocation is still
                        // in flight (Task not yet RanToCompletion) when the second request
                        // enters the cache's RefreshTokenRequestState.
                        gate.Wait(cancellationToken);
                    }
                    else
                    {
                        // The second request issued its own credential call instead of coalescing
                        // onto the first request's URI-bound in-flight acquisition.
                        secondCallReached.Set();
                    }
                    return new AccessToken(
                        $"pop-token-{index}",
                        DateTimeOffset.UtcNow.AddHours(1),
                        refreshOn: null,
                        tokenType: "PoP",
                        bindingCertificate: bindingCertificate);
                },
                IsAsync);

            var policy = new ProofOfPossessionTestPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            var firstRequest = Task.Run(() => SendGetRequest(transport, policy, uri: new Uri("https://example.com/resource-a")));
            firstCallStarted.Wait();

            var secondRequest = Task.Run(() => SendGetRequest(transport, policy, uri: new Uri("https://example.com/resource-b")));

            // Deterministic synchronization: wait until the second request has independently reached its
            // own credential call while the first acquisition is still blocked in flight. A broken
            // implementation coalesces the second request onto the first (no second credential call), so
            // this wait times out and the assertion below fails instead of passing on a lucky schedule.
            bool secondReached = secondCallReached.Wait(TimeSpan.FromSeconds(30));
            gate.Set();

            await Task.WhenAll(firstRequest, secondRequest).ConfigureAwait(false);

            Assert.IsTrue(secondReached,
                "A second request for a different URI must trigger its own PoP acquisition while the first is in flight, not reuse the first request's URI-bound token.");
            Assert.AreEqual(2, contexts.Count,
                "The in-flight acquisition must not be shared across distinct request URIs when PoP is requested.");
            // Order depends on scheduling, so just assert the set of URIs seen.
            var uris = contexts.Select(c => c.ResourceRequestUri).ToArray();
            CollectionAssert.AreEquivalent(
                new[] { new Uri("https://example.com/resource-a"), new Uri("https://example.com/resource-b") },
                uris);
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_ReAcquiresProofOfPossessionTokenPerRequestUri()
        {
            // Regression coverage for the PoP token cache issue raised in
            // https://github.com/Azure/azure-sdk-for-net/pull/61654#discussion_r3798801017.
            // PoP tokens are cryptographically bound to the request URI and HTTP method, so
            // AccessTokenCache must re-invoke the credential when either changes rather than
            // silently returning a token whose binding no longer matches the outgoing request.
            using var bindingCertificate = MakeSelfSignedCertificate();
            var contexts = new List<TokenRequestContext>();
            var credential = new TokenCredentialStub((requestContext, _) =>
                {
                    lock (contexts)
                    {
                        contexts.Add(requestContext);
                        return new AccessToken(
                            $"pop-token-{contexts.Count}",
                            DateTimeOffset.UtcNow.AddHours(1),
                            refreshOn: null,
                            tokenType: "PoP",
                            bindingCertificate: bindingCertificate);
                    }
                },
                IsAsync);

            var policy = new ProofOfPossessionTestPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/resource-a"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/resource-b"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/resource-a")); // back to first URI

            Assert.AreEqual(3, contexts.Count,
                "Expected one credential invocation per distinct request URI when PoP is enabled.");
            Assert.AreEqual(new Uri("https://example.com/resource-a"), contexts[0].ResourceRequestUri);
            Assert.AreEqual(new Uri("https://example.com/resource-b"), contexts[1].ResourceRequestUri);
            Assert.AreEqual(new Uri("https://example.com/resource-a"), contexts[2].ResourceRequestUri);
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_ReusesProofOfPossessionTokenForSameUri()
        {
            // Complements the invalidate-on-URI-change regression test: repeated requests to
            // the same URI+method still hit the cache. The URI-based invalidation only fires
            // when the resource target actually changes.
            using var bindingCertificate = MakeSelfSignedCertificate();
            int callCount = 0;
            var credential = new TokenCredentialStub((_, _) =>
                {
                    Interlocked.Increment(ref callCount);
                    return new AccessToken(
                        "pop-token",
                        DateTimeOffset.UtcNow.AddHours(1),
                        refreshOn: null,
                        tokenType: "PoP",
                        bindingCertificate: bindingCertificate);
                },
                IsAsync);

            var policy = new ProofOfPossessionTestPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200));

            var uri = new Uri("https://example.com/same-resource");
            await SendGetRequest(transport, policy, uri: uri);
            await SendGetRequest(transport, policy, uri: uri);
            await SendGetRequest(transport, policy, uri: uri);

            Assert.AreEqual(1, callCount, "PoP token cache must still hit when the request URI and method are unchanged.");
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_ReAcquiresProofOfPossessionTokenPerNonce()
        {
            // A PoP token is also bound to the challenge nonce, so a new nonce for the same URI and method must
            // re-invoke the credential rather than reuse proof generated with the stale nonce.
            using var bindingCertificate = MakeSelfSignedCertificate();
            var contexts = new List<TokenRequestContext>();
            var credential = new TokenCredentialStub((requestContext, _) =>
                {
                    lock (contexts)
                    {
                        contexts.Add(requestContext);
                        return new AccessToken(
                            $"pop-token-{contexts.Count}",
                            DateTimeOffset.UtcNow.AddHours(1),
                            refreshOn: null,
                            tokenType: "PoP",
                            bindingCertificate: bindingCertificate);
                    }
                },
                IsAsync);

            var nonces = new Queue<string>(new[] { "nonce-1", "nonce-2" });
            var policy = new ProofOfPossessionNonceTestPolicy(credential, "scope", () => nonces.Dequeue());
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            var uri = new Uri("https://example.com/same-resource");
            await SendGetRequest(transport, policy, uri: uri);
            await SendGetRequest(transport, policy, uri: uri);

            Assert.AreEqual(2, contexts.Count, "Expected a fresh credential call when only the PoP nonce changes.");
            Assert.AreEqual("nonce-1", contexts[0].ProofOfPossessionNonce);
            Assert.AreEqual("nonce-2", contexts[1].ProofOfPossessionNonce);
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_ReAcquiresProofOfPossessionTokenPerRequestMethod()
        {
            // A PoP token is bound to the HTTP method as well as the URI and nonce, so the same URI with a
            // different method (GET then POST) must re-invoke the credential rather than reuse the cached token.
            using var bindingCertificate = MakeSelfSignedCertificate();
            var contexts = new List<TokenRequestContext>();
            var credential = new TokenCredentialStub((requestContext, _) =>
                {
                    lock (contexts)
                    {
                        contexts.Add(requestContext);
                        return new AccessToken(
                            $"pop-token-{contexts.Count}",
                            DateTimeOffset.UtcNow.AddHours(1),
                            refreshOn: null,
                            tokenType: "PoP",
                            bindingCertificate: bindingCertificate);
                    }
                },
                IsAsync);

            var policy = new ProofOfPossessionTestPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            var uri = new Uri("https://example.com/same-resource");
            await SendGetRequest(transport, policy, uri: uri);
            await SendRequestAsync(transport, message =>
            {
                message.Request.Method = RequestMethod.Post;
                message.Request.Uri.Reset(uri);
            }, policy);

            Assert.AreEqual(2, contexts.Count, "Expected a fresh credential call when only the request method changes.");
            Assert.AreEqual("GET", contexts[0].ResourceRequestMethod);
            Assert.AreEqual("POST", contexts[1].ResourceRequestMethod);
        }

        private static X509Certificate2 MakeSelfSignedCertificate()
        {
            using RSA key = RSA.Create(2048);
            var request = new CertificateRequest(
                $"CN=BearerTokenAuthenticationPolicyTests-{Guid.NewGuid()}",
                key,
                HashAlgorithmName.SHA256,
                RSASignaturePadding.Pkcs1);
            return request.CreateSelfSigned(DateTimeOffset.UtcNow.AddMinutes(-5), DateTimeOffset.UtcNow.AddHours(1));
        }
#endif

        private class ProofOfPossessionTestPolicy : BearerTokenAuthenticationPolicy
        {
            public ProofOfPossessionTestPolicy(TokenCredential credential, string scope) : base(credential, scope) { }

            protected override void AuthorizeRequest(HttpMessage message) =>
                AuthenticateAndAuthorizeRequest(message, BuildPoPContext(message));

            protected override async ValueTask AuthorizeRequestAsync(HttpMessage message) =>
                await AuthenticateAndAuthorizeRequestAsync(message, BuildPoPContext(message)).ConfigureAwait(false);

            private static TokenRequestContext BuildPoPContext(HttpMessage message) =>
                new TokenRequestContext(
                    new[] { "scope" },
                    parentRequestId: message.Request.ClientRequestId,
                    isCaeEnabled: true,
                    isProofOfPossessionEnabled: true,
                    requestUri: message.Request.Uri.ToUri(),
                    requestMethod: message.Request.Method.ToString());
        }

        private class ProofOfPossessionNonceTestPolicy : BearerTokenAuthenticationPolicy
        {
            private readonly Func<string> _nonceProvider;

            public ProofOfPossessionNonceTestPolicy(TokenCredential credential, string scope, Func<string> nonceProvider)
                : base(credential, scope) => _nonceProvider = nonceProvider;

            protected override void AuthorizeRequest(HttpMessage message) =>
                AuthenticateAndAuthorizeRequest(message, BuildContext(message));

            protected override async ValueTask AuthorizeRequestAsync(HttpMessage message) =>
                await AuthenticateAndAuthorizeRequestAsync(message, BuildContext(message)).ConfigureAwait(false);

            private TokenRequestContext BuildContext(HttpMessage message) =>
                new TokenRequestContext(
                    new[] { "scope" },
                    parentRequestId: message.Request.ClientRequestId,
                    isCaeEnabled: true,
                    isProofOfPossessionEnabled: true,
                    proofOfPossessionNonce: _nonceProvider(),
                    requestUri: message.Request.Uri.ToUri(),
                    requestMethod: message.Request.Method.ToString());
        }

        private class ChallengeBasedAuthenticationTestPolicy : BearerTokenAuthenticationPolicy
        {
            public string TenantId { get; private set; }

            private readonly ConcurrentQueue<string> _tenantIds = new(
                new[]
                {
                    "de763a21-49f7-4b08-a8e1-52c8fbc103b4",
                    "72f988bf-86f1-41af-91ab-2d7cd011db47",
                });

            public ChallengeBasedAuthenticationTestPolicy(TokenCredential credential, string scope) : base(credential, scope)
            {
            }

            protected override void AuthorizeRequest(HttpMessage message) =>
                AuthorizeRequestAsync(message, false).EnsureCompleted();

            protected override async ValueTask AuthorizeRequestAsync(HttpMessage message) =>
                await AuthorizeRequestAsync(message, true).ConfigureAwait(false);

            private async ValueTask AuthorizeRequestAsync(HttpMessage message, bool isAsync)
            {
                if (!message.Request.Headers.Contains(HttpHeader.Names.Authorization))
                {
                    TokenRequestContext context = new(new[] { "scope" });
                    if (isAsync)
                    {
                        await AuthenticateAndAuthorizeRequestAsync(message, context);
                    }
                    else
                    {
                        AuthenticateAndAuthorizeRequest(message, context);
                    }
                }
            }

            protected override bool AuthorizeRequestOnChallenge(HttpMessage message) =>
                AuthorizeRequestOnChallengeAsync(message, false).EnsureCompleted();

            protected override async ValueTask<bool> AuthorizeRequestOnChallengeAsync(HttpMessage message) =>
                await AuthorizeRequestOnChallengeAsync(message, true).ConfigureAwait(false);

            private async ValueTask<bool> AuthorizeRequestOnChallengeAsync(HttpMessage message, bool isAsync)
            {
                Assert.IsTrue(_tenantIds.TryDequeue(out string tenantId));
                TenantId = tenantId;

                TokenRequestContext context = new(new[] { "scope" }, tenantId: tenantId);
                if (isAsync)
                {
                    await AuthenticateAndAuthorizeRequestAsync(message, context);
                }
                else
                {
                    AuthenticateAndAuthorizeRequest(message, context);
                }

                return true;
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
