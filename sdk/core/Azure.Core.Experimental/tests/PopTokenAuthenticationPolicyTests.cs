// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class PopTokenAuthenticationPolicyTests : SyncAsyncPolicyTestBase
    {
        public PopTokenAuthenticationPolicyTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task PopTokenAuthenticationPolicy_HandlesPopChallenge()
        {
            string nonce = string.Empty;
            int callCount = 1;
            Func<MockRequest, MockResponse> responses = req =>
            {
                if (req.Headers.TryGetValue("Authorization", out string authValue))
                {
                    Console.WriteLine($"req: {req.Uri}, with auth: {authValue}");
                    return new MockResponse(200)
                        .WithHeader("WWW-Authenticate", $"""PoP nonce="myNonce{callCount++}" """);
                }
                else
                {
                    Console.WriteLine($"req: {req.Uri}, without auth");
                    return new MockResponse(401)
                        .WithHeader("WWW-Authenticate", $"""PoP nonce="myNonce{callCount}" """);
                }
            };

            var transport = CreateMockTransport(responses);

            var credential = new TokenCredentialStub((r, c) =>
            {
                nonce = r.ProofOfPossessionNonce;

                return new(Guid.NewGuid().ToString(), DateTimeOffset.Now.AddHours(2));
            }, IsAsync);

            var policy = new PopTokenAuthenticationPolicy(credential, "scope1");
            await SendGetRequest(transport, policy, uri: new Uri("https://example1.com"));
            Assert.AreEqual("myNonce1", nonce);

            await SendGetRequest(transport, policy, uri: new Uri("https://example2.com"));
            Assert.AreEqual("myNonce1", nonce);

            await SendGetRequest(transport, policy, uri: new Uri("https://example3.com"));
            Assert.AreEqual("myNonce2", nonce);

            await SendGetRequest(transport, policy, uri: new Uri("https://example4.com"));
            Assert.AreEqual("myNonce3", nonce);
        }

        [Test]
        public async Task PopTokenAuthenticationPolicy_UsesTokenProvidedByCredentials()
        {
            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope1" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default,
                IsAsync);
            var policy = new PopTokenAuthenticationPolicy(credential, "scope1");

            MockTransport transport = CreateMockTransport(
                new[]
                    {
                        new MockResponse(401)
                            .WithHeader("WWW-Authenticate", """PoP nonce="myNonce1" """),
                        new MockResponse(200)
                            .WithHeader("WWW-Authenticate", """PoP nonce="myNonce1" """),
                    }
            );
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.Requests.Last().Headers.TryGetValue("Authorization", out string authValue));
            Assert.AreEqual("PoP token", authValue);
        }

        [Test]
        public async Task PopTokenAuthenticationPolicy_RequestsTokenEveryRequest()
        {
            var accessTokens = new Queue<AccessToken>();
            accessTokens.Enqueue(new AccessToken("token1", DateTimeOffset.MaxValue));
            accessTokens.Enqueue(new AccessToken("token2", DateTimeOffset.MaxValue));

            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope1" }) ? accessTokens.Dequeue() : default,
                IsAsync);

            var policy = new PopTokenAuthenticationPolicy(credential, "scope1");
            MockTransport transport = CreateMockTransport(popWwwAuthenticateResponses);

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreEqual("PoP token1", auth1Value);
            Assert.AreEqual("PoP token2", auth2Value);
        }

        [Test]
        public void PopTokenAuthenticationPolicy_ThrowsForNonTlsEndpoint()
        {
            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default,
                IsAsync);

            var policy = new PopTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: new Uri("http://example.com")));
        }

        [Test]
        public void PopTokenAuthenticationPolicy_ThrowsForEmptyToken()
        {
            var credential = new TokenCredentialStub((r, c) => new AccessToken(string.Empty, DateTimeOffset.MaxValue), IsAsync);

            var policy = new PopTokenAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: new Uri("http://example.com")));
        }

        [Test]
        public async Task PopTokenAuthenticationPolicy_GatedConcurrentCalls()
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

            var policy = new PopTokenAuthenticationPolicy(credential, "scope");

            var transport = CreateMockTransport(popWwwAuthenticateResponses);

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            requestMre.Wait();

            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            responseMre.Set();

            await Task.WhenAll(firstRequestTask, secondRequestTask);

            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[2].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreNotEqual(auth1Value, auth2Value);
        }

        [Test]
        public void PopTokenAuthenticationPolicy_OneHundredConcurrentCallsFailed()
        {
            var credential = new TokenCredentialStub((r, c) =>
                {
                    Thread.Sleep(100);
                    throw new InvalidOperationException("Error");
                },
                IsAsync);

            var policy = new PopTokenAuthenticationPolicy(credential, "scope");
            var transport = CreateMockTransport(popWwwAuthenticateResponses);
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
        public void PopTokenAuthenticationPolicy_GatedConcurrentCallsFailed()
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

            var policy = new PopTokenAuthenticationPolicy(credential, "scope");
            var transport = CreateMockTransport(popWwwAuthenticateResponses);

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

        private class TokenCredentialStub : TokenCredential, ISupportsProofOfPossession
        {
            public TokenCredentialStub(Func<PopTokenRequestContext, CancellationToken, AccessToken> handler, bool isAsync)
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

            private readonly Func<PopTokenRequestContext, CancellationToken, ValueTask<AccessToken>> _getTokenAsyncHandler;
            private readonly Func<PopTokenRequestContext, CancellationToken, AccessToken> _getTokenHandler;

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenAsyncHandler(PopTokenRequestContext.FromTokenRequestContext(requestContext), cancellationToken);

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenHandler(PopTokenRequestContext.FromTokenRequestContext(requestContext), cancellationToken);

            public ValueTask<AccessToken> GetTokenAsync(PopTokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenAsyncHandler(requestContext, cancellationToken);

            public AccessToken GetToken(PopTokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenHandler(requestContext, cancellationToken);
        }

        private Func<MockRequest, MockResponse> popWwwAuthenticateResponses = req =>
            {
                if (req.Headers.TryGetValue("Authorization", out string authValue))
                {
                    return new MockResponse(200)
                        .WithHeader("WWW-Authenticate", """PoP nonce="myNonce" """);
                }
                else
                {
                    return new MockResponse(401)
                        .WithHeader("WWW-Authenticate", """PoP nonce="myNonce" """);
                }
            };
    }
}
