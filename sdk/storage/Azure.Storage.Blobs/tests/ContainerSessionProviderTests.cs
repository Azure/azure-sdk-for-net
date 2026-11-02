// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    /// <summary>
    /// Unit tests for <see cref="ContainerSessionProvider"/> exercised directly,
    /// independent of <see cref="SessionAuthenticationPolicy"/>.
    /// </summary>
    [TestFixture(true)]
    [TestFixture(false)]
    public class ContainerSessionProviderTests
    {
        private readonly bool _async;

        public ContainerSessionProviderTests(bool isAsync)
        {
            _async = isAsync;
        }

        #region Constants
        private const string AccountName = "testaccount";
        private const string ContainerName = "mycontainer";
        private const string BlobName = "myblob";
        private static readonly string s_sessionKey =
            Convert.ToBase64String(Encoding.UTF8.GetBytes("testsessionkey1234567890ab"));

        private static Uri ServiceUri => new Uri($"https://{AccountName}.blob.core.windows.net");
        private static Uri BlobUri => new Uri($"https://{AccountName}.blob.core.windows.net/{ContainerName}/{BlobName}");
        #endregion

        #region Helpers
        private sealed class StaticTokenCredential : TokenCredential
        {
            private static readonly AccessToken s_token =
                new AccessToken("fake-oauth-token", DateTimeOffset.MaxValue);

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => s_token;

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new ValueTask<AccessToken>(s_token);
        }

        private static MockResponse CreateSessionMockResponse(
            string sessionToken,
            DateTimeOffset? expiration = null)
        {
            expiration ??= DateTimeOffset.UtcNow.AddMinutes(30);

            string xml =
                $"<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                $"<CreateSessionResult>" +
                $"<Id>test-session-id</Id>" +
                $"<Expiration>{expiration.Value:R}</Expiration>" +
                $"<AuthenticationType>Hmac</AuthenticationType>" +
                $"<Credentials>" +
                $"<SessionToken>{sessionToken}</SessionToken>" +
                $"<SessionKey>{s_sessionKey}</SessionKey>" +
                $"</Credentials>" +
                $"</CreateSessionResult>";

            var response = new MockResponse(201);
            response.AddHeader("Content-Type", "application/xml");
            response.SetContent(xml);
            return response;
        }

        private static MockResponse CreateSessionErrorResponse(int statusCode, string errorCode = null)
        {
            string xml =
                $"<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                $"<Error>" +
                $"<Code>{errorCode ?? "UnknownError"}</Code>" +
                $"<Message>Simulated error</Message>" +
                $"</Error>";

            var response = new MockResponse(statusCode);
            response.AddHeader("Content-Type", "application/xml");
            if (errorCode != null)
            {
                response.AddHeader("x-ms-error-code", errorCode);
            }
            response.SetContent(xml);
            return response;
        }

        private static (ContainerSessionProvider Provider, MockTransport Transport) CreateProvider(
            Uri serviceUri,
            params MockResponse[] createSessionResponses)
        {
            var transport = new MockTransport(createSessionResponses);
            var options = new BlobClientOptions
            {
                Transport = transport,
            };
            options.Retry.MaxRetries = 0;

            return (new ContainerSessionProvider(serviceUri, new StaticTokenCredential(), options), transport);
        }

        /// <summary>
        /// Builds a bare <see cref="HttpMessage"/> carrying <paramref name="uri"/>, which is
        /// all the provider needs to scope a session to a container.
        /// </summary>
        private static HttpMessage CreateMessage(Uri uri)
        {
            var pipeline = new HttpPipeline(new MockTransport(new MockResponse(200)));
            HttpMessage message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(uri);
            return message;
        }

        private ValueTask<SessionProvider.SessionTokenInfo> GetSessionAsync(
            SessionProvider provider, HttpMessage message)
            => provider.GetSessionAsync(message, _async);

        private static Uri BlobUriFor(string containerName, string blobName = BlobName)
            => new Uri($"https://{AccountName}.blob.core.windows.net/{containerName}/{blobName}");
        #endregion

        #region Constructor Validation
        [Test]
        public void Ctor_NullServiceUri_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new ContainerSessionProvider(
                serviceUri: null,
                credential: new StaticTokenCredential()));
        }

        [Test]
        public void Ctor_NullCredential_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new ContainerSessionProvider(
                serviceUri: ServiceUri,
                credential: null));
        }

        [Test]
        public void Ctor_NullServiceUri_IsValidatedBeforeCredential()
        {
            // Both arguments are null; the exception must name serviceUri, locking in
            // that validation follows the declared parameter order.
            var ex = Assert.Throws<ArgumentNullException>(() => new ContainerSessionProvider(
                serviceUri: null,
                credential: null));
            Assert.AreEqual("serviceUri", ex.ParamName);
        }

        [Test]
        public void Ctor_NullOptions_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new ContainerSessionProvider(
                ServiceUri,
                new StaticTokenCredential()));
        }
        #endregion

        #region Service Endpoint Reduction
        /// <summary>
        /// The provider must reduce whatever URI it is handed to the account's blob
        /// service endpoint before minting sessions, so callers may pass a blob-,
        /// container-, or service-level URI interchangeably.
        /// </summary>
        [TestCase("https://testaccount.blob.core.windows.net")]
        [TestCase("https://testaccount.blob.core.windows.net/mycontainer")]
        [TestCase("https://testaccount.blob.core.windows.net/mycontainer/myblob")]
        [TestCase("https://testaccount.blob.core.windows.net/mycontainer/myblob?snapshot=2023-01-01T00:00:00.0000000Z")]
        [TestCase("https://testaccount.blob.core.windows.net/mycontainer/myblob?sv=2021-06-08&sig=fakesignature")]
        public async Task Ctor_ReducesUriToServiceEndpoint(string constructorUri)
        {
            var (provider, transport) = CreateProvider(
                new Uri(constructorUri),
                CreateSessionMockResponse("token"));

            await GetSessionAsync(provider, CreateMessage(BlobUri));

            Assert.AreEqual(1, transport.Requests.Count);
            Uri actual = transport.Requests[0].Uri.ToUri();

            // Regardless of the constructor URI, CreateSession must target the
            // container under the bare account endpoint with no inherited query state.
            Assert.AreEqual($"{AccountName}.blob.core.windows.net", actual.Host);
            Assert.AreEqual($"/{ContainerName}", actual.AbsolutePath);
            StringAssert.DoesNotContain("sig=", actual.Query);
            StringAssert.DoesNotContain("snapshot=", actual.Query);
        }

        [Test]
        public async Task CreateSession_TargetsContainerFromRequestUri()
        {
            var (provider, transport) = CreateProvider(
                ServiceUri,
                CreateSessionMockResponse("token"));

            // The session is scoped by the *request* URI, not the constructor URI.
            await GetSessionAsync(provider, CreateMessage(BlobUriFor("someothercontainer")));

            Assert.AreEqual(1, transport.Requests.Count);
            Assert.AreEqual("/someothercontainer", transport.Requests[0].Uri.ToUri().AbsolutePath);
        }
        #endregion

        #region Caching
        [Test]
        public async Task GetSession_SameContainer_ReturnsCachedValue()
        {
            // Only one response queued: a second CreateSession would throw.
            var (provider, transport) = CreateProvider(
                ServiceUri,
                CreateSessionMockResponse("cached-token"));

            SessionProvider.SessionTokenInfo first = await GetSessionAsync(provider, CreateMessage(BlobUriFor(ContainerName, "blob1")));
            SessionProvider.SessionTokenInfo second = await GetSessionAsync(provider, CreateMessage(BlobUriFor(ContainerName, "blob2")));

            Assert.AreEqual("cached-token", first.SessionToken);
            Assert.AreEqual("cached-token", second.SessionToken);
            Assert.AreEqual(1, transport.Requests.Count,
                "The second request for the same container must be served from cache.");
        }

        [Test]
        public async Task GetSession_DifferentContainers_MaintainSeparateCaches()
        {
            var (provider, transport) = CreateProvider(
                ServiceUri,
                CreateSessionMockResponse("token-a"),
                CreateSessionMockResponse("token-b"));

            SessionProvider.SessionTokenInfo a = await GetSessionAsync(provider, CreateMessage(BlobUriFor("containera")));
            SessionProvider.SessionTokenInfo b = await GetSessionAsync(provider, CreateMessage(BlobUriFor("containerb")));

            // Re-request both; neither should re-acquire.
            SessionProvider.SessionTokenInfo a2 = await GetSessionAsync(provider, CreateMessage(BlobUriFor("containera", "other")));
            SessionProvider.SessionTokenInfo b2 = await GetSessionAsync(provider, CreateMessage(BlobUriFor("containerb", "other")));

            Assert.AreEqual("token-a", a.SessionToken);
            Assert.AreEqual("token-b", b.SessionToken);
            Assert.AreEqual("token-a", a2.SessionToken, "containerA's cache should be intact.");
            Assert.AreEqual("token-b", b2.SessionToken, "containerB's cache should be intact.");
            Assert.AreEqual(2, transport.Requests.Count, "Expected exactly one CreateSession per container.");
        }

        [Test]
        public async Task GetSession_ContainerNameIsCaseInsensitive()
        {
            var (provider, transport) = CreateProvider(
                ServiceUri,
                CreateSessionMockResponse("token"));

            await GetSessionAsync(provider, CreateMessage(BlobUriFor("mycontainer")));
            await GetSessionAsync(provider, CreateMessage(BlobUriFor("MyContainer")));

            Assert.AreEqual(1, transport.Requests.Count,
                "Container names should be compared case-insensitively by the cache.");
        }
        #endregion

        #region Invalidation
        [Test]
        public async Task InvalidateSession_ClearsOnlyMatchingContainer()
        {
            var (provider, transport) = CreateProvider(
                ServiceUri,
                CreateSessionMockResponse("token-a"),
                CreateSessionMockResponse("token-b"),
                CreateSessionMockResponse("token-a-refreshed"));

            HttpMessage messageA = CreateMessage(BlobUriFor("containera"));
            SessionProvider.SessionTokenInfo a = await GetSessionAsync(provider, messageA);
            SessionProvider.SessionTokenInfo b = await GetSessionAsync(provider, CreateMessage(BlobUriFor("containerb")));

            provider.InvalidateSession(messageA, a);

            // containerB is untouched and must still be served from cache.
            SessionProvider.SessionTokenInfo b2 = await GetSessionAsync(provider, CreateMessage(BlobUriFor("containerb")));
            Assert.AreEqual("token-b", b2.SessionToken, "containerB must not be affected by containerA's invalidation.");
            Assert.AreEqual(2, transport.Requests.Count);

            // containerA re-acquires.
            SessionProvider.SessionTokenInfo a2 = await GetSessionAsync(provider, CreateMessage(BlobUriFor("containera")));
            Assert.AreEqual("token-a-refreshed", a2.SessionToken, "containerA should have re-acquired after invalidation.");
            Assert.AreEqual(3, transport.Requests.Count);
        }

        [Test]
        public async Task InvalidateSession_StaleValue_IsNoOp()
        {
            var (provider, transport) = CreateProvider(
                ServiceUri,
                CreateSessionMockResponse("current-token"));

            HttpMessage message = CreateMessage(BlobUri);
            await GetSessionAsync(provider, message);

            // Simulate a late 401 handler still holding a token that has since been
            // replaced: invalidation must not clobber the newer cached value.
            var stale = new SessionProvider.SessionTokenInfo(
                sessionToken: "stale-token",
                sessionKey: s_sessionKey,
                expiresOn: DateTimeOffset.UtcNow.AddMinutes(30),
                refreshOn: DateTimeOffset.UtcNow.AddMinutes(29),
                isFallbackToBearer: false);
            provider.InvalidateSession(message, stale);

            SessionProvider.SessionTokenInfo after = await GetSessionAsync(provider, CreateMessage(BlobUri));
            Assert.AreEqual("current-token", after.SessionToken,
                "Invalidating with a stale value must leave the current cache entry intact.");
            Assert.AreEqual(1, transport.Requests.Count);
        }
        #endregion

        #region Fallback Cooldown
        /// <summary>
        /// Every fallback-eligible CreateSession failure (5xx, 403, or 400 FeatureNotEnabled)
        /// produces a fallback-to-bearer sentinel cached for the same 5 minute cooldown.
        /// </summary>
        [TestCase(500, "InternalError")]
        [TestCase(503, "ServerBusy")]
        [TestCase(403, "AuthorizationFailure")]
        [TestCase(400, "FeatureNotEnabled")]
        public async Task AcquireFails_FallbackEligible_UsesFiveMinuteCooldown(int statusCode, string errorCode)
        {
            TimeSpan expectedCooldown = TimeSpan.FromMinutes(5);

            // Only one CreateSession response is queued: a re-acquisition within the
            // cooldown window would underrun the transport and throw.
            var (provider, transport) = CreateProvider(
                ServiceUri,
                CreateSessionErrorResponse(statusCode, errorCode));

            DateTimeOffset before = DateTimeOffset.UtcNow;
            SessionProvider.SessionTokenInfo sentinel = await GetSessionAsync(provider, CreateMessage(BlobUri));
            DateTimeOffset after = DateTimeOffset.UtcNow;

            Assert.IsTrue(sentinel.IsFallbackToBearer, "A fallback-eligible failure must produce the fallback sentinel.");
            Assert.GreaterOrEqual(sentinel.ExpiresOn, before + expectedCooldown,
                "The sentinel must be cached for at least the 5 minute cooldown.");
            Assert.LessOrEqual(sentinel.ExpiresOn, after + expectedCooldown,
                "The sentinel must not be cached for longer than the 5 minute cooldown.");
            Assert.AreEqual(sentinel.ExpiresOn, sentinel.RefreshOn,
                "RefreshOn must equal ExpiresOn so the full cooldown is honored.");

            // A second request within the cooldown is served from cache.
            SessionProvider.SessionTokenInfo second = await GetSessionAsync(provider, CreateMessage(BlobUri));
            Assert.IsTrue(second.IsFallbackToBearer);
            Assert.AreEqual(1, transport.Requests.Count,
                "The cooldown should prevent re-acquisition; expected exactly one CreateSession call.");
        }

        [TestCase(400, "InvalidInput")]
        [TestCase(404, "ContainerNotFound")]
        [TestCase(409, "ContainerBeingDeleted")]
        public void AcquireFails_NotFallbackEligible_Propagates(int statusCode, string errorCode)
        {
            var (provider, _) = CreateProvider(
                ServiceUri,
                CreateSessionErrorResponse(statusCode, errorCode));

            Assert.ThrowsAsync<RequestFailedException>(
                async () => await GetSessionAsync(provider, CreateMessage(BlobUri)));
        }
        #endregion

        #region Request Eligibility
        [TestCase("https://testaccount.blob.core.windows.net/mycontainer/myblob", true)]
        [TestCase("https://testaccount.blob.core.windows.net/mycontainer", false)]
        [TestCase("https://testaccount.blob.core.windows.net", false)]
        [TestCase("https://testaccount.blob.core.windows.net/mycontainer/myblob?comp=metadata", false)]
        [TestCase("https://testaccount.blob.core.windows.net/mycontainer/myblob?comp=tags", false)]
        [TestCase("https://testaccount.blob.core.windows.net/mycontainer/myblob?restype=container", false)]
        [TestCase("https://testaccount.blob.core.windows.net/mycontainer/myblob?snapshot=2023-01-01T00:00:00.0000000Z", true)]
        public void IsRequestEligible_GetRequests(string uri, bool expected)
        {
            var (provider, _) = CreateProvider(ServiceUri);
            HttpMessage message = CreateMessage(new Uri(uri));

            Assert.AreEqual(expected, provider.IsRequestEligible(message));
        }

        [Test]
        public void IsRequestEligible_NonGetRequest_IsFalse()
        {
            var (provider, _) = CreateProvider(ServiceUri);
            HttpMessage message = CreateMessage(BlobUri);
            message.Request.Method = RequestMethod.Head;

            Assert.IsFalse(provider.IsRequestEligible(message),
                "Only GET requests are eligible for session authentication.");
        }

        [Test]
        public void IsRequestEligible_StructuredMessageRequest_IsFalse()
        {
            var (provider, _) = CreateProvider(ServiceUri);
            HttpMessage message = CreateMessage(BlobUri);
            message.Request.Headers.SetValue(
                Constants.StructuredMessage.StructuredMessageHeader,
                Constants.StructuredMessage.CrcStructuredMessage);

            Assert.IsFalse(provider.IsRequestEligible(message),
                "Structured message requests are not eligible for session authentication.");
        }
        #endregion
    }
}
