// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
