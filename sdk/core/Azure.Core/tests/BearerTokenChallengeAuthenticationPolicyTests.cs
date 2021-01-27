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
    public class BearerTokenChallengeAuthenticationPolicyTests : SyncAsyncPolicyTestBase
    {
        public BearerTokenChallengeAuthenticationPolicyTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task BearerTokenChallengeAuthenticationPolicy_UsesTokenProvidedByCredentials()
        {
            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope1", "scope2" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default, IsAsync);
            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, new[] { "scope1", "scope2" });

            MockTransport transport = CreateMockTransport(new MockResponse(200));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.SingleRequest.Headers.TryGetValue("Authorization", out string authValue));
            Assert.AreEqual("Bearer token", authValue);
        }

        [Test]
        public async Task BearerTokenChallengeAuthenticationPolicy_RequestsTokenEveryRequest()
        {
            var accessTokens = new Queue<AccessToken>();
            accessTokens.Enqueue(new AccessToken("token1", DateTimeOffset.UtcNow));
            accessTokens.Enqueue(new AccessToken("token2", DateTimeOffset.UtcNow));

            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope1", "scope2" }) ? accessTokens.Dequeue() : default, IsAsync);

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, new[] { "scope1", "scope2" });
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreEqual("Bearer token1", auth1Value);
            Assert.AreEqual("Bearer token2", auth2Value);
        }

        [Test]
        public async Task BearerTokenChallengeAuthenticationPolicy_CachesHeaderValue()
        {
            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default, IsAsync);

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));
            await SendGetRequest(transport, policy, uri: new Uri("https://example.com"));

            Assert.True(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth1Value));
            Assert.True(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth2Value));

            Assert.AreSame(auth1Value, auth1Value);
            Assert.AreEqual("Bearer token", auth2Value);
        }

        [Test]
        public void BearerTokenChallengeAuthenticationPolicy_ThrowsForNonTlsEndpoint()
        {
            var credential = new TokenCredentialStub(
                (r, c) => r.Scopes.SequenceEqual(new[] { "scope" }) ? new AccessToken("token", DateTimeOffset.MaxValue) : default, IsAsync);

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: new Uri("http://example.com")));
        }

        [Test]
        public void BearerTokenChallengeAuthenticationPolicy_ThrowsForEmptyToken()
        {
            var credential = new TokenCredentialStub((r, c) => new AccessToken(string.Empty, DateTimeOffset.MaxValue), IsAsync);

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport();

            Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: new Uri("http://example.com")));
        }

        [Test]
        public async Task BearerTokenChallengeAuthenticationPolicy_OneHundredConcurrentCalls()
        {
            var credential = new TokenCredentialStub((r, c) =>
            {
                Thread.Sleep(100);
                return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddMinutes(30));
            }, IsAsync);

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, "scope");
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
        public async Task BearerTokenChallengeAuthenticationPolicy_GatedConcurrentCalls()
        {
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddMinutes(30));
            }, IsAsync);

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, "scope");
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
        public async Task BearerTokenChallengeAuthenticationPolicy_SucceededFailedSucceeded()
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

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, new[] { "scope" }, TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(30));
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
        public async Task BearerTokenChallengeAuthenticationPolicy_TokenAlmostExpired()
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

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, "scope");
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
        public async Task BearerTokenChallengeAuthenticationPolicy_TokenAlmostExpired_NoRefresh()
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

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, "scope");
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
        public async Task BearerTokenChallengeAuthenticationPolicy_TokenExpired()
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

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, new[] { "scope" }, TimeSpan.FromSeconds(2), TimeSpan.FromMilliseconds(50));
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
        public void BearerTokenChallengeAuthenticationPolicy_OneHundredConcurrentCallsFailed()
        {
            var credential = new TokenCredentialStub((r, c) =>
            {
                Thread.Sleep(100);
                throw new InvalidOperationException("Error");
            }, IsAsync);

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, "scope");
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
        public async Task BearerTokenChallengeAuthenticationPolicy_GatedConcurrentCallsFailed()
        {
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var credential = new TokenCredentialStub((r, c) =>
            {
                requestMre.Set();
                responseMre.Wait(c);
                throw new InvalidOperationException("Error");
            }, IsAsync);

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

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
        public async Task BearerTokenChallengeAuthenticationPolicy_TokenExpiredThenFailed()
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

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, new[] { "scope" }, TimeSpan.FromSeconds(2), TimeSpan.FromMilliseconds(50));
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
        public async Task BearerTokenChallengeAuthenticationPolicy_TokenAlmostExpiredThenFailed()
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
            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, new[] { "scope" }, TimeSpan.FromMinutes(2), tokenRefreshRetryDelay);
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
        public void BearerTokenChallengeAuthenticationPolicy_GatedConcurrentCallsCancelled()
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

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, "scope");
            MockTransport transport = CreateMockTransport(new MockResponse(200), new MockResponse(200));

            var firstRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);
            requestMre.Wait();

            var secondRequestTask = SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: cts.Token);
            cts.Cancel();

            Assert.CatchAsync<OperationCanceledException>(async () => await secondRequestTask);
            responseMre.Set();

            Assert.CatchAsync<InvalidOperationException>(async () => await firstRequestTask);
        }

        private const string CaeInsufficientClaimsChallenge = "Bearer realm=\"\", authorization_uri=\"https://login.microsoftonline.com/common/oauth2/authorize\", client_id=\"00000003-0000-0000-c000-000000000000\", error=\"insufficient_claims\", claims=\"eyJhY2Nlc3NfdG9rZW4iOiB7ImZvbyI6ICJiYXIifX0=\"";
        private const string CaeInsufficientClaimsChallengeValue = "eyJhY2Nlc3NfdG9rZW4iOiB7ImZvbyI6ICJiYXIifX0=";
        private static readonly Challenge ParsedCaeInsufficientClaimsChallenge = new Challenge
        {
            Scheme = "Bearer",
            Parameters =
            {
                ("realm", ""),
                ("authorization_uri", "https://login.microsoftonline.com/common/oauth2/authorize"),
                ("client_id", "00000003-0000-0000-c000-000000000000"),
                ("error", "insufficient_claims"),
                ("claims", "eyJhY2Nlc3NfdG9rZW4iOiB7ImZvbyI6ICJiYXIifX0="),
            }
        };

        private const string CaeSessionsRevokedClaimsChallenge = "Bearer authorization_uri=\"https://login.windows-ppe.net/\", error=\"invalid_token\", error_description=\"User session has been revoked\", claims=\"eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwgInZhbHVlIjoiMTYwMzc0MjgwMCJ9fX0=\"";
        private const string CaeSessionsRevokedClaimsChallengeValue = "eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwgInZhbHVlIjoiMTYwMzc0MjgwMCJ9fX0=";
        private static readonly Challenge ParsedCaeSessionsRevokedClaimsChallenge = new Challenge
        {
            Scheme = "Bearer",
            Parameters =
            {
                ("authorization_uri", "https://login.windows-ppe.net/"),
                ("error", "invalid_token"),
                ("error_description", "User session has been revoked"),
                ("claims", "eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwgInZhbHVlIjoiMTYwMzc0MjgwMCJ9fX0="),
            }
        };

        private const string KeyVaultChallenge = "Bearer authorization=\"https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47\", resource=\"https://vault.azure.net\"";
        private static readonly Challenge ParsedKeyVaultChallenge = new Challenge
        {
            Scheme = "Bearer",
            Parameters =
            {
                ("authorization", "https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47"),
                ("resource", "https://vault.azure.net"),
            }
        };

        private const string ArmChallenge = "Bearer authorization_uri=\"https://login.windows.net/\", error=\"invalid_token\", error_description=\"The authentication failed because of missing 'Authorization' header.\"";
        private static readonly Challenge ParsedArmChallenge = new Challenge()
        {
            Scheme = "Bearer",
            Parameters =
            {
                ("authorization_uri", "https://login.windows.net/"),
                ("error", "invalid_token"),
                ("error_description", "The authentication failed because of missing 'Authorization' header."),
            }
        };

        private static readonly Dictionary<string, string> ChallengeStrings = new Dictionary<string, string>()
        {
            { "CaeInsufficientClaims", CaeInsufficientClaimsChallenge },
            { "CaeSessionsRevoked", CaeSessionsRevokedClaimsChallenge },
            { "KeyVault", KeyVaultChallenge },
            { "Arm", ArmChallenge }
        };

        private static readonly Dictionary<string, Challenge> ParsedChallenges = new Dictionary<string, Challenge>()
        {
            { "CaeInsufficientClaims", ParsedCaeInsufficientClaimsChallenge },
            { "CaeSessionsRevoked", ParsedCaeSessionsRevokedClaimsChallenge },
            { "KeyVault", ParsedKeyVaultChallenge },
            { "Arm", ParsedArmChallenge }
        };

        private class Challenge
        {
            public string Scheme { get; set; }

            public List<(string, string)> Parameters { get; } = new List<(string, string)>();
        }

        [Test]
        public void BearerTokenChallengeAuthenticationPolicy_ValidateChallengeParsing([Values("CaeInsufficientClaims", "CaeSessionsRevoked", "KeyVault", "Arm")] string challengeKey)
        {
            var challenge = ChallengeStrings[challengeKey];

            List<Challenge> parsedChallenges = new List<Challenge>();

            foreach (var (ChallengeKey, ChallengeParameters) in BearerTokenChallengeAuthenticationPolicy.ParseChallenges(challenge))
            {
                Challenge parsedChallenge = new Challenge();

                parsedChallenge.Scheme = ChallengeKey;

                foreach (var paramTuple in BearerTokenChallengeAuthenticationPolicy.ParseChallengeParameters(ChallengeParameters))
                {
                    parsedChallenge.Parameters.Add(paramTuple);
                }

                parsedChallenges.Add(parsedChallenge);
            }

            Assert.AreEqual(1, parsedChallenges.Count);

            ValidateParsedChallenge(ParsedChallenges[challengeKey], parsedChallenges[0]);
        }

        [Test]
        public async Task BearerTokenChallengeAuthenticationPolicy_ValidateClaimsChallengeTokenRequest()
        {
            string currentClaimChallenge = null;

            int tokensRequested = 0;

            var credential = new TokenCredentialStub((r, c) =>
            {
                tokensRequested++;

                Assert.AreEqual(currentClaimChallenge, r.ClaimsChallenge);

                return new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow + TimeSpan.FromDays(1));
            }, IsAsync);

            var policy = new BearerTokenChallengeAuthenticationPolicy(credential, "scope");

            var insufficientClaimsChallengeResponse = new MockResponse(401);

            insufficientClaimsChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", CaeInsufficientClaimsChallenge));

            var sessionRevokedChallengeResponse = new MockResponse(401);

            sessionRevokedChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", CaeSessionsRevokedClaimsChallenge));

            var armChallengeResponse = new MockResponse(401);

            armChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", ArmChallenge));

            var keyvaultChallengeResponse = new MockResponse(401);

            keyvaultChallengeResponse.AddHeader(new HttpHeader("WWW-Authenticate", KeyVaultChallenge));

            MockTransport transport = CreateMockTransport(new MockResponse(200),
                insufficientClaimsChallengeResponse,
                new MockResponse(200),
                sessionRevokedChallengeResponse,
                new MockResponse(200),
                armChallengeResponse,
                keyvaultChallengeResponse);

            var response = await SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);

            Assert.AreEqual(tokensRequested, 1);

            Assert.AreEqual(response.Status, 200);

            currentClaimChallenge = Base64Url.DecodeString(CaeInsufficientClaimsChallengeValue);

            response = await SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);

            Assert.AreEqual(tokensRequested, 2);

            Assert.AreEqual(response.Status, 200);

            currentClaimChallenge = Base64Url.DecodeString(CaeSessionsRevokedClaimsChallengeValue);

            response = await SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);

            Assert.AreEqual(tokensRequested, 3);

            Assert.AreEqual(response.Status, 200);

            currentClaimChallenge = null;

            response = await SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);

            Assert.AreEqual(tokensRequested, 3);

            Assert.AreEqual(response.Status, 401);

            response = await SendGetRequest(transport, policy, uri: new Uri("https://example.com"), cancellationToken: default);

            Assert.AreEqual(tokensRequested, 3);

            Assert.AreEqual(response.Status, 401);
        }

        private void ValidateParsedChallenge(Challenge expected, Challenge actual)
        {
            Assert.AreEqual(expected.Scheme, actual.Scheme);

            CollectionAssert.AreEquivalent(expected.Parameters, actual.Parameters);
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
