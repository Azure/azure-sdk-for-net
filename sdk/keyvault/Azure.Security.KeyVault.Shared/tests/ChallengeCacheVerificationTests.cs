// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Tests
{
    [NonParallelizable]
    public class ChallengeCacheVerificationTests : SyncAsyncPolicyTestBase
    {
        private const string ValidScope = "https://vault.azure.net/.default";
        private const string ForeignScope = "https://foreign.example/.default";
        private const string Authorization = "https://login.microsoftonline.com/common";
        private static readonly Uri s_vaultUri = new("https://cache-tests.vault.azure.net");

        public ChallengeCacheVerificationTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        [TearDown]
        public void ClearCache()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [TestCase(ForeignScope, true)]
        [TestCase(ForeignScope, false)]
        [TestCase("not-an-absolute-uri/.default", true)]
        [TestCase("https://vault.azure.net.foreign.example/.default", true)]
        public async Task RejectsUnverifiedCachedScopeBeforeCredentialOrTransport(string scope, bool useScope)
        {
            await SeedChallengeAsync(s_vaultUri, scope, useScope);

            int tokenRequests = 0;
            MockCredential credential = new() { GetTokenCallback = (_, _) => tokenRequests++ };
            ChallengeBasedAuthenticationPolicy policy = new(credential, disableChallengeResourceVerification: false);
            MockTransport transport = CreateMockTransport(new MockResponse(200));

            Assert.ThrowsAsync<InvalidOperationException>(() => SendGetRequest(transport, policy, uri: s_vaultUri));
            Assert.That(tokenRequests, Is.Zero);
            Assert.That(transport.Requests, Is.Empty);
        }

        [TestCase("https://cache-tests.vault.azure.net", "https://CACHE-TESTS.VAULT.AZURE.NET:443/path", ValidScope)]
        [TestCase("https://cache-tests.vault.azure.net:443", "https://cache-tests.vault.azure.net", ValidScope)]
        [TestCase("https://cache-tests.vault.azure.net:8443", "https://CACHE-TESTS.VAULT.AZURE.NET:8443/path", ValidScope)]
        [TestCase("https://cache-tests.vault.usgovcloudapi.net", "https://cache-tests.vault.usgovcloudapi.net/path", "https://vault.usgovcloudapi.net/.default")]
        [TestCase("https://cache-tests.vault.azure.cn", "https://cache-tests.vault.azure.cn/path", "https://vault.azure.cn/.default")]
        [TestCase("https://cache-tests.vault.microsoftazure.de", "https://cache-tests.vault.microsoftazure.de/path", "https://vault.microsoftazure.de/.default")]
        [TestCase("https://cache-tests.managedhsm.azure.net", "https://cache-tests.managedhsm.azure.net/path", "https://managedhsm.azure.net/.default")]
        [TestCase("https://cache-tests.managedhsm.usgovcloudapi.net", "https://cache-tests.managedhsm.usgovcloudapi.net/path", "https://managedhsm.usgovcloudapi.net/.default")]
        [TestCase("https://cache-tests.managedhsm.azure.cn", "https://cache-tests.managedhsm.azure.cn/path", "https://managedhsm.azure.cn/.default")]
        [TestCase("https://cache-tests.private.example", "https://cache-tests.private.example/path", "https://private.example/.default")]
        [TestCase("https://cache-tests.private.example.", "https://cache-tests.private.example./path", "https://private.example./.default")]
        [TestCase("https://cache-tests.xn--bcher-kva.example", "https://cache-tests.xn--bcher-kva.example/path", "https://xn--bcher-kva.example/.default")]
        [TestCase("https://cache-tests.vault.azure.net", "https://cache-tests.vault.azure.net/path", "http://vault.azure.net:8080/.default")]
        public async Task CachedMatchingScopePreservesFreshChallengeContract(string seedUri, string requestUri, string scope)
        {
            Uri target = new(requestUri);
            int tokenRequests = 0;
            MockCredential credential = new()
            {
                GetTokenCallback = (context, _) =>
                {
                    tokenRequests++;
                    CollectionAssert.AreEqual(new[] { scope }, context.Scopes);
                    Assert.That(context.TenantId, Is.EqualTo("common"));
                }
            };

            // Establish the existing fresh-challenge contract before testing the cached path.
            MockTransport fresh = CreateMockTransport(Challenge(scope), new MockResponse(200));
            await SendGetRequest(fresh, new ChallengeBasedAuthenticationPolicy(credential, false), uri: target);
            Assert.That(tokenRequests, Is.EqualTo(1));
            ChallengeBasedAuthenticationPolicy.ClearCache();

            await SeedChallengeAsync(new Uri(seedUri), scope);
            MockTransport cached = CreateMockTransport(new MockResponse(200));
            await SendGetRequest(cached, new ChallengeBasedAuthenticationPolicy(credential, false), uri: target);
            Assert.That(tokenRequests, Is.EqualTo(2));
            Assert.That(cached.Requests.Count, Is.EqualTo(1));
            Assert.That(cached.SingleRequest.Headers.Contains("Authorization"), Is.True);
        }

        [TestCase("https://CACHE-TESTS.VAULT.AZURE.NET:443/path")]
        [TestCase("https://cache-tests.vault.azure.net/secrets/another")]
        public async Task NormalizedAuthorityDoesNotBypassVerification(string requestUri)
        {
            await SeedChallengeAsync(s_vaultUri, ForeignScope);
            MockTransport transport = CreateMockTransport(new MockResponse(200));
            MockCredential credential = new() { GetTokenCallback = (_, _) => Assert.Fail("Credential must not be invoked.") };

            Assert.ThrowsAsync<InvalidOperationException>(() => SendGetRequest(
                transport, new ChallengeBasedAuthenticationPolicy(credential, false), uri: new Uri(requestUri)));
            Assert.That(transport.Requests, Is.Empty);
        }

        [TestCase("https://other-cache-tests.vault.azure.net")]
        [TestCase("https://cache-tests.vault.azure.net:8443")]
        public async Task ForeignCacheEntryDoesNotAffectDistinctAuthority(string requestUri)
        {
            await SeedChallengeAsync(s_vaultUri, ForeignScope);
            int tokenRequests = 0;
            MockCredential credential = new()
            {
                GetTokenCallback = (context, _) =>
                {
                    tokenRequests++;
                    CollectionAssert.AreEqual(new[] { ValidScope }, context.Scopes);
                }
            };
            int requests = 0;
            MockTransport transport = CreateMockTransport(request =>
            {
                if (++requests == 1)
                {
                    Assert.That(request.Headers.Contains("Authorization"), Is.False);
                    return Challenge(ValidScope);
                }
                Assert.That(request.Headers.Contains("Authorization"), Is.True);
                return new MockResponse(200);
            });

            await SendGetRequest(transport, new ChallengeBasedAuthenticationPolicy(credential, false), uri: new Uri(requestUri));
            Assert.That(tokenRequests, Is.EqualTo(1));
            Assert.That(requests, Is.EqualTo(2));
        }

        [Test]
        public async Task VerificationDisabledConsumerCanReuseForeignScope()
        {
            await SeedChallengeAsync(s_vaultUri, ForeignScope);
            int tokenRequests = 0;
            MockCredential credential = new()
            {
                GetTokenCallback = (context, _) =>
                {
                    tokenRequests++;
                    CollectionAssert.AreEqual(new[] { ForeignScope }, context.Scopes);
                }
            };
            MockTransport transport = CreateMockTransport(new MockResponse(200));
            await SendGetRequest(transport, new ChallengeBasedAuthenticationPolicy(credential, true), uri: s_vaultUri);
            Assert.That(tokenRequests, Is.EqualTo(1));
            Assert.That(transport.SingleRequest.Headers.Contains("Authorization"), Is.True);
        }

        [Test]
        public async Task EstablishedStrictPolicyRejectsForeignCacheReplacement()
        {
            int tokenRequests = 0;
            MockCredential credential = new() { GetTokenCallback = (_, _) => tokenRequests++ };
            ChallengeBasedAuthenticationPolicy policy = new(credential, false);
            MockTransport initial = CreateMockTransport(Challenge(ValidScope), new MockResponse(200));
            await SendGetRequest(initial, policy, uri: s_vaultUri);
            Assert.That(tokenRequests, Is.EqualTo(1));

            await SeedChallengeAsync(s_vaultUri, ForeignScope);
            MockTransport subsequent = CreateMockTransport(new MockResponse(200));
            Assert.ThrowsAsync<InvalidOperationException>(() => SendGetRequest(subsequent, policy, uri: s_vaultUri));
            Assert.That(tokenRequests, Is.EqualTo(1));
            Assert.That(subsequent.Requests, Is.Empty);
        }

        [Test]
        public async Task FailedLenientAcquisitionDoesNotAuthorizeStrictConsumer()
        {
            InvalidOperationException acquisitionFailure = new("Simulated token acquisition failure.");
            MockCredential seedCredential = new() { GetTokenCallback = (_, _) => throw acquisitionFailure };
            MockTransport seedTransport = CreateMockTransport(Challenge(ForeignScope), new MockResponse(200));

            InvalidOperationException actual = Assert.ThrowsAsync<InvalidOperationException>(() => SendGetRequest(
                seedTransport, new ChallengeBasedAuthenticationPolicy(seedCredential, true), uri: s_vaultUri));
            Assert.That(actual, Is.SameAs(acquisitionFailure));
            Assert.That(seedTransport.Requests.Count, Is.EqualTo(1));
            Assert.That(seedTransport.SingleRequest.Headers.Contains("Authorization"), Is.False);

            int tokenRequests = 0;
            MockCredential credential = new() { GetTokenCallback = (_, _) => tokenRequests++ };
            MockTransport transport = CreateMockTransport(new MockResponse(200));
            Assert.ThrowsAsync<InvalidOperationException>(() => SendGetRequest(
                transport, new ChallengeBasedAuthenticationPolicy(credential, false), uri: s_vaultUri));
            Assert.That(tokenRequests, Is.Zero);
            Assert.That(transport.Requests, Is.Empty);
        }

        [Test]
        public async Task StrictConsumerRecoversAfterForeignCacheEntryIsReplaced()
        {
            await SeedChallengeAsync(s_vaultUri, ForeignScope);
            int tokenRequests = 0;
            MockCredential credential = new()
            {
                GetTokenCallback = (context, _) =>
                {
                    tokenRequests++;
                    CollectionAssert.AreEqual(new[] { ValidScope }, context.Scopes);
                }
            };
            ChallengeBasedAuthenticationPolicy policy = new(credential, false);
            MockTransport rejected = CreateMockTransport(new MockResponse(200));
            Assert.ThrowsAsync<InvalidOperationException>(() => SendGetRequest(rejected, policy, uri: s_vaultUri));
            Assert.That(tokenRequests, Is.Zero);
            Assert.That(rejected.Requests, Is.Empty);

            await SeedChallengeAsync(s_vaultUri, ValidScope);
            MockTransport recovered = CreateMockTransport(new MockResponse(200));
            Response response = await SendGetRequest(recovered, policy, uri: s_vaultUri);
            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(tokenRequests, Is.EqualTo(1));
            Assert.That(recovered.SingleRequest.Headers.TryGetValue("Authorization", out string authorization), Is.True);
            Assert.That(authorization, Is.EqualTo($"Bearer TEST TOKEN {ValidScope}"));
        }

        [Test]
        public async Task InFlightAcquisitionUsesValidatedSnapshotDuringCacheReplacement()
        {
            await SeedChallengeAsync(s_vaultUri, ValidScope);
            AsyncGate<TokenRequestContext, bool> gate = new();
            int tokenRequests = 0;
            MockCredential credential = new()
            {
                GetTokenCallback = (context, _) =>
                {
                    if (++tokenRequests == 1)
                    {
                        gate.WaitForRelease(context).GetAwaiter().GetResult();
                    }
                }
            };
            ChallengeBasedAuthenticationPolicy policy = new(credential, false);
            MockTransport transport = CreateMockTransport(new MockResponse(200));
            Task<Response> pending = Task.Run(() => SendGetRequest(transport, policy, uri: s_vaultUri));
            TokenRequestContext acquiredContext = await gate.WaitForSignal();
            try
            {
                await SeedChallengeAsync(s_vaultUri, ForeignScope);
                CollectionAssert.AreEqual(new[] { ValidScope }, acquiredContext.Scopes);
            }
            finally
            {
                gate.Release(true);
            }

            Assert.That((await pending).Status, Is.EqualTo(200));
            MockTransport subsequent = CreateMockTransport(new MockResponse(200));
            Assert.ThrowsAsync<InvalidOperationException>(() => SendGetRequest(subsequent, policy, uri: s_vaultUri));
            Assert.That(tokenRequests, Is.EqualTo(1));
            Assert.That(subsequent.Requests, Is.Empty);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ClaimsChallengeRevalidatesCachedScope(bool replaceWithForeignScope)
        {
            await SeedChallengeAsync(s_vaultUri, ValidScope);
            List<TokenRequestContext> contexts = new();
            MockCredential credential = new() { GetTokenCallback = (context, _) => contexts.Add(context) };
            ChallengeBasedAuthenticationPolicy policy = new(credential, false);
            MockTransport transport = CreateMockTransport();
            Task<Response> pending = Task.Run(() => SendGetRequest(transport, policy, uri: s_vaultUri));
            await transport.RequestGate.WaitForSignal();
            try
            {
                if (replaceWithForeignScope)
                {
                    await SeedChallengeAsync(s_vaultUri, ForeignScope);
                }
            }
            finally
            {
                transport.RequestGate.Release(new MockResponse(401).WithHeader(
                    "WWW-Authenticate",
                    $"Bearer authorization_uri=\"{Authorization}\", error=\"insufficient_claims\", claims=\"e30=\""));
            }

            if (replaceWithForeignScope)
            {
                Assert.ThrowsAsync<InvalidOperationException>(() => pending);
                Assert.That(contexts.Count, Is.EqualTo(1));
                Assert.That(transport.Requests.Count, Is.EqualTo(1));
            }
            else
            {
                await transport.RequestGate.Cycle(new MockResponse(200));
                Assert.That((await pending).Status, Is.EqualTo(200));
                Assert.That(contexts.Count, Is.EqualTo(2));
                Assert.That(contexts[1].Claims, Is.EqualTo("{}"));
            }
            foreach (TokenRequestContext context in contexts)
            {
                CollectionAssert.AreEqual(new[] { ValidScope }, context.Scopes);
            }
        }

        private async Task SeedChallengeAsync(Uri uri, string scope, bool useScope = true)
        {
            string acquiredScope = null;
            MockCredential credential = new() { GetTokenCallback = (context, _) => acquiredScope = context.Scopes[0] };
            MockTransport transport = CreateMockTransport(Challenge(scope, useScope), new MockResponse(200));
            Response response = await SendGetRequest(transport, new ChallengeBasedAuthenticationPolicy(credential, true), uri: uri);
            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(acquiredScope, Is.EqualTo(scope));
            Assert.That(transport.Requests.Count, Is.EqualTo(2));
            Assert.That(transport.Requests[1].Headers.Contains("Authorization"), Is.True);
        }

        private static MockResponse Challenge(string scope, bool useScope = true)
        {
            string parameter = useScope ? "scope" : "resource";
            string value = useScope ? scope : scope.Substring(0, scope.Length - "/.default".Length);
            return new MockResponse(401).WithHeader(
                "WWW-Authenticate", $"Bearer authorization=\"{Authorization}\", {parameter}=\"{value}\"");
        }
    }
}
