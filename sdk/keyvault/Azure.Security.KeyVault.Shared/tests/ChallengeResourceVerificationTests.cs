// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Tests
{
    [NonParallelizable]
    public class ChallengeResourceVerificationTests : SyncAsyncPolicyTestBase
    {
        private static readonly Uri s_endpoint = new Uri("https://test.contoso.test");

        public ChallengeResourceVerificationTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [TearDown]
        public void TearDown()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [Test]
        public void InvalidChallengeIsRejectedBeforeTokenAcquisition(
            [Values(
                "https://resource.example@contoso.test",
                "https://user:password@contoso.test",
                "https://%75ser@contoso.test",
                "https://resource.example%40other.example@contoso.test",
                "https://resource.example%2Fpath@contoso.test",
                "https://resource.example@contoso.test:443",
                "https://resource.example@contoso.test:8443",
                "https://resource.example@contoso.test/",
                "https://resource.example%40contoso.test",
                "https://contoso.test:invalid",
                "https://[invalid",
                "relative-resource")] string resource,
            [Values("resource", "scope")] string parameter,
            [Values(false, true)] bool includeClaims)
        {
            int credentialCalls = 0;
            var credential = new MockCredential
            {
                GetTokenCallback = (_, _) => credentialCalls++
            };
            var policy = new ChallengeBasedAuthenticationPolicy(credential, disableChallengeResourceVerification: false);
            string scope = resource + "/.default";

            // A rejected challenge must not populate the shared cache.
            for (int attempt = 0; attempt < 2; attempt++)
            {
                MockTransport transport = CreateMockTransport(
                    CreateChallenge(parameter, resource, includeClaims), new MockResponse(200));
                InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(
                    async () => await SendGetRequest(transport, policy, uri: s_endpoint));

                Assert.That(exception.Message, Is.EqualTo($"The challenge contains invalid scope '{scope}'."));
                Assert.That(credentialCalls, Is.Zero);
                Assert.That(transport.Requests.Count, Is.EqualTo(1));
                Assert.That(transport.SingleRequest.Headers.Contains("Authorization"), Is.False);
            }
        }

        [Test]
        public async Task CachedChallengeIsVerifiedByEachPolicy(
            [Values(
                "https://resource.example@contoso.test",
                "https://other.example",
                "relative-resource")] string resource,
            [Values("resource", "scope")] string parameter,
            [Values(false, true)] bool warmTokenCache)
        {
            int credentialCalls = 0;
            var credential = new MockCredential
            {
                GetTokenCallback = (_, _) => credentialCalls++
            };
            var policy = new ChallengeBasedAuthenticationPolicy(credential, disableChallengeResourceVerification: false);

            if (warmTokenCache)
            {
                MockTransport warmup = CreateMockTransport(
                    CreateChallenge("resource", "https://contoso.test"), new MockResponse(200));
                Assert.That((await SendGetRequest(warmup, policy, uri: s_endpoint)).Status, Is.EqualTo(200));
            }

            var optedOutPolicy = new ChallengeBasedAuthenticationPolicy(
                new MockCredential(), disableChallengeResourceVerification: true);
            MockTransport optedOutTransport = CreateMockTransport(
                CreateChallenge(parameter, resource), new MockResponse(200));
            Assert.That((await SendGetRequest(optedOutTransport, optedOutPolicy, uri: s_endpoint)).Status, Is.EqualTo(200));

            credentialCalls = 0;
            MockTransport transport = CreateMockTransport(new MockResponse(200));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await SendGetRequest(transport, policy, uri: s_endpoint));

            Assert.That(credentialCalls, Is.Zero);
            Assert.That(transport.Requests, Is.Empty);
        }

        [Test]
        public async Task ValidChallengeAndCachedScopeArePreserved(
            [Values(
                "https://vault.azure.net",
                "https://vault.azure.cn",
                "https://vault.usgovcloudapi.net",
                "https://vault.microsoftazure.de",
                "https://managedhsm.azure.net",
                "https://managedhsm.azure.cn",
                "https://managedhsm.usgovcloudapi.net",
                "https://custom.contoso.test",
                "https://CONTOSO.TEST",
                "https://contoso.test:8443",
                "https://contoso.test.",
                "https://xn--bcher-kva.test",
                "https://contoso.test/path@segment",
                "https://contoso.test/path%40segment",
                "https://@contoso.test",
                "http://contoso.test")] string resource,
            [Values("resource", "scope")] string parameter)
        {
            string scope = resource + "/.default";
            Uri resourceUri = new Uri(resource);
            Uri endpoint = new Uri($"https://test.{resourceUri.Authority}");
            int credentialCalls = 0;
            var credential = new MockCredential
            {
                GetTokenCallback = (context, _) =>
                {
                    credentialCalls++;
                    Assert.That(context.Scopes, Is.EqualTo(new[] { scope }));
                }
            };
            var policy = new ChallengeBasedAuthenticationPolicy(credential, disableChallengeResourceVerification: false);
            MockTransport transport = CreateMockTransport(CreateChallenge(parameter, resource), new MockResponse(200));

            Assert.That((await SendGetRequest(transport, policy, uri: endpoint)).Status, Is.EqualTo(200));
            Assert.That(transport.Requests.Count, Is.EqualTo(2));
            Assert.That(transport.Requests[1].Headers.Contains("Authorization"), Is.True);

            var secondPolicy = new ChallengeBasedAuthenticationPolicy(credential, disableChallengeResourceVerification: false);
            MockTransport cachedTransport = CreateMockTransport(new MockResponse(200));
            Assert.That((await SendGetRequest(cachedTransport, secondPolicy, uri: endpoint)).Status, Is.EqualTo(200));
            Assert.That(cachedTransport.SingleRequest.Headers.Contains("Authorization"), Is.True);
            Assert.That(credentialCalls, Is.EqualTo(2));
        }

        [Test]
        public async Task VerificationOptOutIsPreserved(
            [Values(
                "https://resource.example@contoso.test",
                "https://other.example",
                "relative-resource")] string resource,
            [Values("resource", "scope")] string parameter)
        {
            string scope = resource + "/.default";
            int credentialCalls = 0;
            var credential = new MockCredential
            {
                GetTokenCallback = (context, _) =>
                {
                    credentialCalls++;
                    Assert.That(context.Scopes, Is.EqualTo(new[] { scope }));
                }
            };
            var policy = new ChallengeBasedAuthenticationPolicy(credential, disableChallengeResourceVerification: true);
            MockTransport transport = CreateMockTransport(CreateChallenge(parameter, resource), new MockResponse(200));

            Assert.That((await SendGetRequest(transport, policy, uri: s_endpoint)).Status, Is.EqualTo(200));
            Assert.That(transport.Requests[1].Headers.Contains("Authorization"), Is.True);

            var secondPolicy = new ChallengeBasedAuthenticationPolicy(credential, disableChallengeResourceVerification: true);
            MockTransport cachedTransport = CreateMockTransport(new MockResponse(200));
            Assert.That((await SendGetRequest(cachedTransport, secondPolicy, uri: s_endpoint)).Status, Is.EqualTo(200));
            Assert.That(cachedTransport.SingleRequest.Headers.Contains("Authorization"), Is.True);
            Assert.That(credentialCalls, Is.EqualTo(2));
        }

        private static MockResponse CreateChallenge(string parameter, string resource, bool includeClaims = false)
        {
            string value = parameter == "resource" ? resource : resource + "/.default";
            string challenge = $"Bearer authorization=\"https://login.microsoftonline.com/11111111-1111-1111-1111-111111111111\", {parameter}=\"{value}\"";
            if (includeClaims)
            {
                challenge += ", error=\"insufficient_claims\", claims=\"e30=\"";
            }

            return new MockResponse(401).WithHeader("WWW-Authenticate", challenge);
        }
    }
}
