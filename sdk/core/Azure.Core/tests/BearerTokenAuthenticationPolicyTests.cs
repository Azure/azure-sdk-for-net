// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
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
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope1", "scope2" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default, IsAsync);
            var policy = new BearerTokenAuthenticationPolicy(credential, new[] { "scope1", "scope2" });

            MockTransport transport = CreateMockTransport(new MockResponse(200));
            await SendGetRequest(transport, policy, uri:new Uri("https://example.com"));

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
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope1", "scope2" }) ? accessTokens.Dequeue() : default, IsAsync);

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
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default, IsAsync);

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
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default, IsAsync);

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
            }, IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(Enumerable.Range(0, 100).Select(i => new MockResponse(200)).ToArray());
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
            }, IsAsync);

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
        public async Task BearerTokenAuthenticationPolicy_TokenAlmostExpired()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddMinutes(1.5));
            }, IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/1"));
            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string authValue));

            requestMre.Reset();
            responseMre.Reset();

            Task requestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/2"));
            requestMre.Wait();

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/3"));
            responseMre.Set();

            await requestTask;
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/4"));

            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue("Authorization", out string auth2Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue("Authorization", out string auth3Value));

            Assert.AreEqual(authValue, auth1Value);
            Assert.AreNotEqual(authValue, auth2Value);
            Assert.AreEqual(auth2Value, auth3Value);
        }

        [Test]
        public async Task BearerTokenAuthenticationPolicy_TokenExpired()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var expiresOnOffset = 2;
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffsetHelpers.GetUtcNow().AddSeconds(expiresOnOffset++));
            }, IsAsync, TimeSpan.FromSeconds(2));

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com/0"));
            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string authValue));

            await Task.Delay(2_000);

            requestMre.Reset();
            responseMre.Reset();

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/1"));
            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com/2"));
            requestMre.Wait();
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
            }, IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(Enumerable.Range(0, 100).Select(i => new MockResponse(200)).ToArray());
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
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                throw new InvalidOperationException("Error");
            }, IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            requestMre.Wait();
            responseMre.Set();

            Assert.CatchAsync(async () => await Task.WhenAll(firstRequestTask, secondRequestTask));

            Assert.IsTrue(firstRequestTask.IsFaulted);
            Assert.IsTrue(secondRequestTask.IsFaulted);
            Assert.AreEqual(firstRequestTask.Exception.InnerException, secondRequestTask.Exception.InnerException);
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
            }, IsAsync);

            var policy = new BearerTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: cts.Token);
            requestMre.Wait();

            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: cts.Token);
            cts.Cancel();

            Assert.CatchAsync<OperationCanceledException>(async () => await secondRequestTask);
            responseMre.Set();

            Assert.CatchAsync<OperationCanceledException>(async () => await firstRequestTask);
        }

        private class TokenCredentialStub : TokenCredential
        {
            public TokenCredentialStub(Func<TokenRequestContext, CancellationToken, AccessToken> handler, bool isAsync)
                : this (handler, isAsync, TimeSpan.FromMinutes(2))
            { }

            public TokenCredentialStub(Func<TokenRequestContext, CancellationToken, AccessToken> handler, bool isAsync, TimeSpan tokenRefreshOffset)
            {
                RefreshOffset = new TokenRefreshOptions(tokenRefreshOffset);

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

            public override TokenRefreshOptions RefreshOffset { get; }

            private readonly Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> _getTokenAsyncHandler;
            private readonly Func<TokenRequestContext, CancellationToken, AccessToken> _getTokenHandler;

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenAsyncHandler(requestContext, cancellationToken);

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenHandler(requestContext, cancellationToken);
        }
    }
}
