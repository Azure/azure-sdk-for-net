// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class SessionAuthenticationPolicyTests
    {
        private readonly bool _async;

        public SessionAuthenticationPolicyTests(bool isAsync)
        {
            _async = isAsync;
        }

        #region Constants
        private const string AccountName = "testaccount";
        private const string ContainerName = "mycontainer";
        private const string BlobName = "myblob";
        private static readonly string s_accountKey = Convert.ToBase64String(new byte[32]);
        private static readonly string s_sessionKey = Convert.ToBase64String(Encoding.UTF8.GetBytes("testsessionkey1234567890ab"));
        private const string SessionToken = "test-session-token";

        /// <summary>
        /// Event id of <see cref="BlobsEventSource.SessionAuthenticationDisabledAccountNameUnavailable"/>.
        /// </summary>
        private const int SessionAuthenticationDisabledEventId = 1;

        /// <summary>
        /// Event id of <see cref="BlobsEventSource.SessionAuthenticationCannotBeEnabledAccountNameUnavailable"/>.
        /// </summary>
        private const int SessionAuthenticationCannotBeEnabledEventId = 2;

        private static Uri BlobUri => new Uri($"https://{AccountName}.blob.core.windows.net/{ContainerName}/{BlobName}");
        private static Uri ContainerUri => new Uri($"https://{AccountName}.blob.core.windows.net/{ContainerName}");
        private static Uri ServiceUri => new Uri($"https://{AccountName}.blob.core.windows.net");
        #endregion

        #region Helpers
        private async Task SendAsync(HttpPipeline pipeline, HttpMessage message)
        {
            if (_async)
            {
                await pipeline.SendAsync(message, CancellationToken.None);
            }
            else
            {
                pipeline.Send(message, CancellationToken.None);
            }
        }

        private static Mock<HttpPipelinePolicy> CreateMockBearerPolicy()
        {
            var mock = new Mock<HttpPipelinePolicy>();
            mock
                .Setup(p => p.ProcessAsync(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()))
                .Returns(default(ValueTask));
            mock
                .Setup(p => p.Process(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()));
            return mock;
        }

        private static MockResponse CreateSessionMockResponse(
            string sessionToken = SessionToken,
            string sessionKey = null,
            DateTimeOffset? expiration = null)
        {
            sessionKey ??= s_sessionKey;
            expiration ??= DateTimeOffset.UtcNow.AddMinutes(30);

            string xml =
                $"<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                $"<CreateSessionResult>" +
                $"<Id>test-session-id</Id>" +
                $"<Expiration>{expiration.Value:R}</Expiration>" +
                $"<AuthenticationType>Hmac</AuthenticationType>" +
                $"<Credentials>" +
                $"<SessionToken>{sessionToken}</SessionToken>" +
                $"<SessionKey>{sessionKey}</SessionKey>" +
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

        private static MockResponse CreateBlobGetResponse(
            int statusCode = 200,
            string authInfoHeader = null,
            string wwwAuthenticateHeader = null,
            string errorCode = null)
        {
            var response = new MockResponse(statusCode);
            if (authInfoHeader != null)
            {
                response.AddHeader("x-ms-auth-info", authInfoHeader);
            }
            if (wwwAuthenticateHeader != null)
            {
                response.AddHeader("WWW-Authenticate", wwwAuthenticateHeader);
            }
            if (errorCode != null)
            {
                response.AddHeader("x-ms-error-code", errorCode);
            }
            return response;
        }

        /// <summary>
        /// A <see cref="TokenCredential"/> stub returning a fixed, non-expiring token.
        /// The provider's <see cref="MockTransport"/> intercepts all traffic, so the
        /// credential is never exercised against a real identity endpoint.
        /// </summary>
        private sealed class StaticTokenCredential : TokenCredential
        {
            private static readonly AccessToken s_token =
                new AccessToken("fake-oauth-token", DateTimeOffset.MaxValue);

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => s_token;

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new ValueTask<AccessToken>(s_token);
        }

        /// <summary>
        /// Creates a <see cref="ContainerSessionProvider"/> whose internal
        /// session-minting client is backed by a <see cref="MockTransport"/>.
        /// The returned transport observes only CreateSession traffic, so tests can
        /// assert exactly how many sessions were minted.
        /// </summary>
        private static (ContainerSessionProvider Provider, MockTransport CreateSessionTransport) CreateProvider(
            params MockResponse[] createSessionResponses)
        {
            var transport = new MockTransport(createSessionResponses);
            var options = new BlobClientOptions
            {
                Transport = transport,
            };
            options.Retry.MaxRetries = 0;

            var provider = new ContainerSessionProvider(
                ServiceUri,
                new StaticTokenCredential(),
                options);

            return (provider, transport);
        }

        private static SessionAuthenticationPolicy CreateSessionPolicy(
            Mock<HttpPipelinePolicy> mockBearer,
            SessionOptions sessionOptions,
            params MockResponse[] createSessionResponses)
            => CreateSessionPolicy(mockBearer, sessionOptions, CreateProvider(createSessionResponses).Provider);

        /// <summary>
        /// Builds a policy over an existing <see cref="SessionProvider"/>. Use when a
        /// single provider must be shared across multiple policies (i.e. multiple clients).
        /// </summary>
        private static SessionAuthenticationPolicy CreateSessionPolicy(
            Mock<HttpPipelinePolicy> mockBearer,
            SessionOptions sessionOptions,
            SessionProvider sessionProvider)
            => new SessionAuthenticationPolicy(
                BlobUri,
                mockBearer.Object,
                sessionProvider,
                sessionOptions);

        private async Task<(HttpMessage Message, MockTransport OuterTransport)> SendBlobGetAsync(
            SessionAuthenticationPolicy policy,
            Uri requestUri,
            RequestMethod method,
            params MockResponse[] outerResponses)
        {
            var outerTransport = new MockTransport(outerResponses);
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = method;
            message.Request.Uri.Reset(requestUri);

            await SendAsync(pipeline, message);
            return (message, outerTransport);
        }

        private static SessionOptions EnabledOptions => new SessionOptions
        {
            SessionMode = SessionMode.Enabled,
            AccountName = AccountName
        };

        private void VerifyBearerPolicyInvoked(Mock<HttpPipelinePolicy> mockBearer, Times times)
        {
            if (_async)
            {
                mockBearer.Verify(
                    p => p.ProcessAsync(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()),
                    times);
            }
            else
            {
                mockBearer.Verify(
                    p => p.Process(It.IsAny<HttpMessage>(), It.IsAny<ReadOnlyMemory<HttpPipelinePolicy>>()),
                    times);
            }
        }
        #endregion

        #region Constructor Tests
        [Test]
        public void Ctor_NullBearerPolicy_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new SessionAuthenticationPolicy(
                endpoint: BlobUri,
                fallbackAuthPolicy: null,
                sessionProvider: CreateProvider().Provider,
                sessionOptions: EnabledOptions));
        }

        [Test]
        public void Ctor_NullSessionProvider_Throws()
        {
            var mockBearer = CreateMockBearerPolicy();
            Assert.Throws<ArgumentNullException>(() => new SessionAuthenticationPolicy(
                endpoint: BlobUri,
                fallbackAuthPolicy: mockBearer.Object,
                sessionProvider: null,
                sessionOptions: EnabledOptions));
        }

        [Test]
        public void Ctor_NullEndpoint_Throws()
        {
            var mockBearer = CreateMockBearerPolicy();
            Assert.Throws<ArgumentNullException>(() => new SessionAuthenticationPolicy(
                endpoint: null,
                fallbackAuthPolicy: mockBearer.Object,
                sessionProvider: CreateProvider().Provider,
                sessionOptions: EnabledOptions));
        }

        [Test]
        public void Ctor_NullSessionOptions_DefaultsToNone()
        {
            var mockBearer = CreateMockBearerPolicy();
            Assert.DoesNotThrow(() => new SessionAuthenticationPolicy(
                BlobUri,
                mockBearer.Object,
                CreateProvider().Provider,
                sessionOptions: null));
        }

        [Test]
        public void Ctor_EnabledMode_MissingAccountName_DerivesFromEndpoint()
        {
            var mockBearer = CreateMockBearerPolicy();
            // AccountName is optional; it is derived from the endpoint at construction time.
            Assert.DoesNotThrow(() => new SessionAuthenticationPolicy(
                BlobUri,
                mockBearer.Object,
                CreateProvider().Provider,
                new SessionOptions
                {
                    SessionMode = SessionMode.Enabled,
                    AccountName = null
                }));
        }

        [Test]
        public void Ctor_EnabledMode_MissingAccountName_PathStyleEndpoint_DerivesFromEndpoint()
        {
            var mockBearer = CreateMockBearerPolicy();
            Assert.DoesNotThrow(() => new SessionAuthenticationPolicy(
                new Uri($"https://127.0.0.1:10000/{AccountName}/{ContainerName}/{BlobName}"),
                mockBearer.Object,
                CreateProvider().Provider,
                new SessionOptions
                {
                    SessionMode = SessionMode.Enabled,
                    AccountName = null
                }));
        }

        [Test]
        public void Ctor_ExplicitEnabledMode_AccountNameNotDerivable_Throws()
        {
            var mockBearer = CreateMockBearerPolicy();
            // Sessions were explicitly requested but cannot be signed without an account
            // name, so construction fails rather than silently degrading.
            Assert.Throws<InvalidOperationException>(() => new SessionAuthenticationPolicy(
                new Uri("https://127.0.0.1:10000/"),
                mockBearer.Object,
                CreateProvider().Provider,
                new SessionOptions
                {
                    SessionMode = SessionMode.Enabled,
                    AccountName = null
                }));
        }

        [Test]
        public void Ctor_AutoMode_AccountNameNotDerivable_DoesNotThrow()
        {
            var mockBearer = CreateMockBearerPolicy();
            // The default mode must never break clients built against endpoints with no
            // parseable account name; session authentication is disabled instead.
            Assert.DoesNotThrow(() => new SessionAuthenticationPolicy(
                new Uri("https://127.0.0.1:10000/"),
                mockBearer.Object,
                CreateProvider().Provider,
                new SessionOptions
                {
                    SessionMode = SessionMode.Auto,
                    AccountName = null
                }));
        }

        [Test]
        public void Ctor_EnabledMode_DoesNotThrow()
        {
            var mockBearer = CreateMockBearerPolicy();
            Assert.DoesNotThrow(() => new SessionAuthenticationPolicy(
                BlobUri,
                mockBearer.Object,
                CreateProvider().Provider,
                EnabledOptions));
        }

        [Test]
        public async Task Ctor_SnapshotsSessionOptions_MutationsAfterCtorIgnored()
        {
            var mockBearer = CreateMockBearerPolicy();
            var options = new SessionOptions { SessionMode = SessionMode.Disabled };
            var policy = CreateSessionPolicy(mockBearer, options);

            options.SessionMode = SessionMode.Enabled;
            options.AccountName = AccountName;

            await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                new MockResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }
        #endregion

        #region Request Routing — Mode-Agnostic
        [Test]
        public async Task SessionModeNone_DelegatesToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                new SessionOptions { SessionMode = SessionMode.Disabled });

            await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                new MockResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task NonGetRequest_DelegatesToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Head,
                new MockResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task ServiceLevelUri_DelegatesToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            await SendBlobGetAsync(
                policy,
                ServiceUri,
                RequestMethod.Get,
                new MockResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task ContainerLevelUri_NoBlobName_DelegatesToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            await SendBlobGetAsync(
                policy,
                ContainerUri,
                RequestMethod.Get,
                new MockResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [TestCase("comp=metadata")]
        [TestCase("comp=tags")]
        [TestCase("comp=blocklist")]
        [TestCase("snapshot=2023-01-01T00:00:00.0000000Z&comp=metadata")]
        [TestCase("comp=metadata&timeout=30")]
        public async Task CompQueryParameter_DelegatesToBearer(string query)
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            var uriWithComp = new Uri($"https://{AccountName}.blob.core.windows.net/{ContainerName}/{BlobName}?{query}");

            await SendBlobGetAsync(
                policy,
                uriWithComp,
                RequestMethod.Get,
                new MockResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }
        #endregion

        #region Request Routing — Enabled
        [Test]
        public async Task MultiContainer_AnyContainer_UsesSession()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
            Assert.AreEqual(200, message.Response.Status);
            Assert.IsTrue(
                outerTransport.Requests[0].Headers.TryGetValue("Authorization", out string authHeader));
            Assert.That(authHeader, Does.StartWith("Session "));
        }

        [Test]
        public async Task MultiContainer_SameContainer_SharesCache()
        {
            var mockBearer = CreateMockBearerPolicy();
            // Only one CreateSession response — second call would throw if cache miss.
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse(sessionToken: "shared-token"));

            var blob1Uri = new Uri($"https://{AccountName}.blob.core.windows.net/{ContainerName}/blob1");
            var blob2Uri = new Uri($"https://{AccountName}.blob.core.windows.net/{ContainerName}/blob2");

            var (_, transport1) = await SendBlobGetAsync(
                policy, blob1Uri, RequestMethod.Get, CreateBlobGetResponse(200));
            var (_, transport2) = await SendBlobGetAsync(
                policy, blob2Uri, RequestMethod.Get, CreateBlobGetResponse(200));

            Assert.IsTrue(transport1.Requests[0].Headers.TryGetValue("Authorization", out string auth1));
            Assert.IsTrue(transport2.Requests[0].Headers.TryGetValue("Authorization", out string auth2));
            Assert.IsTrue(auth1.StartsWith("Session shared-token:"));
            Assert.IsTrue(auth2.StartsWith("Session shared-token:"));
        }

        [Test]
        public async Task MultiContainer_DifferentContainers_MaintainSeparateCaches()
        {
            var mockBearer = CreateMockBearerPolicy();
            // Only two CreateSession responses — a third CreateSession call would throw,
            // proving that the third blob request below hits an existing cache entry.
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse(sessionToken: "token-containerA"),
                CreateSessionMockResponse(sessionToken: "token-containerB"));

            var containerAUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerA/{BlobName}");
            var containerBUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerB/{BlobName}");
            var containerA2Uri = new Uri($"https://{AccountName}.blob.core.windows.net/containerA/blob2");
            var containerB2Uri = new Uri($"https://{AccountName}.blob.core.windows.net/containerB/blob2");

            // Warm both caches.
            var (_, transportA) = await SendBlobGetAsync(
                policy, containerAUri, RequestMethod.Get, CreateBlobGetResponse(200));
            var (_, transportB) = await SendBlobGetAsync(
                policy, containerBUri, RequestMethod.Get, CreateBlobGetResponse(200));

            // Go back to containerA and containerB
            var (_, transportA2) = await SendBlobGetAsync(
                policy, containerA2Uri, RequestMethod.Get, CreateBlobGetResponse(200));
            var (_, transportB2) = await SendBlobGetAsync(
                policy, containerB2Uri, RequestMethod.Get, CreateBlobGetResponse(200));

            Assert.IsTrue(transportA.Requests[0].Headers.TryGetValue("Authorization", out string authA));
            Assert.IsTrue(transportB.Requests[0].Headers.TryGetValue("Authorization", out string authB));
            Assert.IsTrue(transportA2.Requests[0].Headers.TryGetValue("Authorization", out string authA2));
            Assert.IsTrue(transportB2.Requests[0].Headers.TryGetValue("Authorization", out string authB2));

            // containerA and containerB got different tokens.
            Assert.IsTrue(authA.StartsWith("Session token-containerA:"), $"Unexpected auth for containerA: {authA}");
            Assert.IsTrue(authB.StartsWith("Session token-containerB:"), $"Unexpected auth for containerB: {authB}");

            // Subsequent requests to containerA still uses tokenA and containerB still uses tokenB.
            Assert.IsTrue(authA2.StartsWith("Session token-containerA:"), $"Expected containerA cache to be intact, got: {authA2}");
            Assert.IsTrue(authB2.StartsWith("Session token-containerB:"), $"Expected containerB cache to be intact, got: {authB2}");
        }

        [Test]
        public async Task MultiContainer_SnapshotQueryWithoutComp_UsesSession()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            var snapshotUri = new Uri($"https://{AccountName}.blob.core.windows.net/{ContainerName}/{BlobName}?snapshot=2023-01-01T00:00:00.0000000Z");

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                snapshotUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
            Assert.IsTrue(outerTransport.Requests[0].Headers.TryGetValue("Authorization", out string authHeader));
            Assert.That(authHeader, Does.StartWith("Session "));
        }

        [Test]
        public async Task MultiContainer_CustomDomainUrl_UsesSessionToken()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            var customDomainBlobUri = new Uri($"https://storage.mycustomdomain.com/{ContainerName}/{BlobName}");

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                customDomainBlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
            Assert.AreEqual(200, message.Response.Status);
            Assert.IsTrue(outerTransport.Requests[0].Headers.TryGetValue("Authorization", out string authHeader));
            Assert.That(authHeader, Does.StartWith("Session "));
        }
        #endregion

        #region Session Token Acquisition & Signing
        [Test]
        public async Task SessionAcquireSucceeds_SetsSessionAuthorizationHeader()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.IsTrue(
                outerTransport.Requests[0].Headers.TryGetValue("Authorization", out string authHeader));
            Assert.IsTrue(authHeader.StartsWith($"Session {SessionToken}:"), $"Unexpected Authorization header: {authHeader}");
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task SessionAcquireSucceeds_SetsXMsDateHeader()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.IsTrue(outerTransport.Requests[0].Headers.TryGetValue("x-ms-date", out string dateHeader));
            Assert.IsNotEmpty(dateHeader);
        }
        #endregion

        #region Optional AccountName
        [Test]
        public async Task AccountNameOmitted_DerivedFromUrl_SignsSuccessfully()
        {
            var mockBearer = CreateMockBearerPolicy();
            // AccountName is intentionally omitted; it must be parsed from the
            // standard *.blob.core.windows.net request URL at signing time.
            var policy = CreateSessionPolicy(
                mockBearer,
                new SessionOptions { SessionMode = SessionMode.Enabled },
                CreateSessionMockResponse());

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.IsTrue(
                outerTransport.Requests[0].Headers.TryGetValue("Authorization", out string authHeader));
            Assert.IsTrue(authHeader.StartsWith($"Session {SessionToken}:"),
                $"Expected session signing using the URL-derived account name, got: {authHeader}");
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [TestCase("https://storage.mycustomdomain.com/" + ContainerName + "/" + BlobName)]
        [TestCase("https://test/test")]
        public async Task AccountNameOmitted_AutoMode_AccountNameNotDerivable_FallsBackToBearer(string endpoint)
        {
            var mockBearer = CreateMockBearerPolicy();
            var unparseableUri = new Uri(endpoint);

            var policy = new SessionAuthenticationPolicy(
                unparseableUri,
                mockBearer.Object,
                CreateProvider(CreateSessionMockResponse()).Provider,
                new SessionOptions { SessionMode = SessionMode.Auto });

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                unparseableUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
            Assert.IsFalse(
                message.Request.Headers.TryGetValue("Authorization", out string authHeader) &&
                authHeader.StartsWith("Session "),
                "Request must not be signed with a session token when the account name is unknown.");
        }

        [Test]
        public void AccountNameNotDerivable_SessionsEnabled_WritesWarningToEventSource()
        {
            var mockBearer = CreateMockBearerPolicy();

            using var listener = new TestEventListener();
            listener.EnableEvents(BlobsEventSource.Singleton, EventLevel.Warning);

            var unparseableUri = new Uri($"https://warning-{_async}/test");
            Assert.Throws<InvalidOperationException>(() => new SessionAuthenticationPolicy(
                unparseableUri,
                mockBearer.Object,
                CreateProvider().Provider,
                new SessionOptions { SessionMode = SessionMode.Enabled }));

            EventWrittenEventArgs sessionEvent = listener.SingleEventById(
                SessionAuthenticationCannotBeEnabledEventId,
                e => e.Payload.Contains(unparseableUri.GetLeftPart(UriPartial.Path)));
            Assert.AreEqual(EventLevel.Warning, sessionEvent.Level);
            Assert.AreEqual(
                nameof(BlobsEventSource.SessionAuthenticationCannotBeEnabledAccountNameUnavailable),
                sessionEvent.EventName);
        }

        [Test]
        public void AccountNameDerivable_DoesNotWriteWarningToEventSource()
        {
            var mockBearer = CreateMockBearerPolicy();

            using var listener = new TestEventListener();
            listener.EnableEvents(BlobsEventSource.Singleton, EventLevel.Warning);

            _ = new SessionAuthenticationPolicy(
                BlobUri,
                mockBearer.Object,
                CreateProvider().Provider,
                new SessionOptions { SessionMode = SessionMode.Enabled });

            Assert.IsFalse(
                WarningWrittenFor(listener, SessionAuthenticationDisabledEventId, BlobUri) ||
                WarningWrittenFor(listener, SessionAuthenticationCannotBeEnabledEventId, BlobUri),
                "No warning should be written when the account name is derived from the endpoint.");
        }

        [Test]
        public void AccountNameNotDerivable_SessionsDisabled_DoesNotWriteWarningToEventSource()
        {
            var mockBearer = CreateMockBearerPolicy();

            using var listener = new TestEventListener();
            listener.EnableEvents(BlobsEventSource.Singleton, EventLevel.Warning);

            var unparseableUri = new Uri($"https://no-warning-{_async}/test");
            _ = new SessionAuthenticationPolicy(
                unparseableUri,
                mockBearer.Object,
                CreateProvider().Provider,
                new SessionOptions { SessionMode = SessionMode.Disabled });

            Assert.IsFalse(
                WarningWrittenFor(listener, SessionAuthenticationDisabledEventId, unparseableUri) ||
                WarningWrittenFor(listener, SessionAuthenticationCannotBeEnabledEventId, unparseableUri),
                "No warning should be written when the caller explicitly disabled sessions.");
        }

        [Test]
        public void AccountNameNotDerivable_ExplicitEnabled_WritesWarningBeforeThrowing()
        {
            var mockBearer = CreateMockBearerPolicy();

            using var listener = new TestEventListener();
            listener.EnableEvents(BlobsEventSource.Singleton, EventLevel.Warning);

            var unparseableUri = new Uri($"https://throwing-warning-{_async}/test");
            Assert.Throws<InvalidOperationException>(() => new SessionAuthenticationPolicy(
                unparseableUri,
                mockBearer.Object,
                CreateProvider().Provider,
                new SessionOptions { SessionMode = SessionMode.Enabled }));

            Assert.IsTrue(
                WarningWrittenFor(listener, SessionAuthenticationCannotBeEnabledEventId, unparseableUri),
                "The warning must be written before the constructor throws.");
            Assert.IsFalse(
                WarningWrittenFor(listener, SessionAuthenticationDisabledEventId, unparseableUri),
                "Explicitly enabled sessions are not disabled, so the fallback warning must not be written.");
        }

        [Test]
        public void AccountNameNotDerivable_SessionsEnabled_DoesNotLeakQueryStringToEventSource()
        {
            var mockBearer = CreateMockBearerPolicy();

            using var listener = new TestEventListener();
            listener.EnableEvents(BlobsEventSource.Singleton, EventLevel.Warning);

            var unparseableUri = new Uri($"https://query-{_async}/test?sig=supersecretsignature");
            Assert.Throws<InvalidOperationException>(() => new SessionAuthenticationPolicy(
                unparseableUri,
                mockBearer.Object,
                CreateProvider().Provider,
                new SessionOptions { SessionMode = SessionMode.Enabled }));

            EventWrittenEventArgs sessionEvent = listener.SingleEventById(
                SessionAuthenticationCannotBeEnabledEventId,
                e => e.Payload.Contains(unparseableUri.GetLeftPart(UriPartial.Path)));
            CollectionAssert.DoesNotContain(
                sessionEvent.Payload,
                unparseableUri.AbsoluteUri,
                "The endpoint must be reported without its query string.");
        }

        /// <summary>
        /// Determines whether the warning with <paramref name="eventId"/> was written for
        /// <paramref name="endpoint"/>. The listener observes the process-wide event
        /// source, so events must be matched on their endpoint payload. The endpoint is
        /// reported without its query string so SAS tokens are never logged.
        /// </summary>
        private static bool WarningWrittenFor(TestEventListener listener, int eventId, Uri endpoint)
        {
            foreach (EventWrittenEventArgs e in listener.EventsById(eventId))
            {
                if (e.Payload.Contains(endpoint.GetLeftPart(UriPartial.Path)))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Session Acquisition Fallback
        [Test]
        public async Task SessionAcquireFails_500_FallsBackToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionErrorResponse(500, "InternalError"));

            await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                new MockResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task SessionAcquireFails_403_FallsBackToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionErrorResponse(403, "Forbidden"));

            await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                new MockResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task SessionAcquireFails_400_FeatureNotEnabled_FallsBackToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionErrorResponse(400, "FeatureNotEnabled"));

            await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                new MockResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public void SessionAcquireFails_400_OtherErrorCode_Propagates()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionErrorResponse(400, "InvalidInput"));

            Assert.ThrowsAsync<RequestFailedException>(async () => await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200)));
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public void SessionAcquireFails_404_Propagates()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionErrorResponse(404, "ContainerNotFound"));

            Assert.ThrowsAsync<RequestFailedException>(async () => await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200)));
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        #endregion

        #region Session Acquisition Cooldown
        /// <summary>
        /// Every fallback-eligible CreateSession failure caches a fallback-to-bearer
        /// sentinel, so subsequent requests reuse it instead of re-attempting acquisition.
        /// 5xx, 403, and 400/FeatureNotEnabled all use the same 5 minute cooldown.
        /// All three must suppress re-acquisition within the test's time window.
        /// </summary>
        [TestCase(500, "InternalError")]
        [TestCase(503, "ServerBusy")]
        [TestCase(403, "Forbidden")]
        [TestCase(400, "FeatureNotEnabled")]
        public async Task SessionAcquireFails_CooldownPreventsRepeatAcquisition(int statusCode, string errorCode)
        {
            const int requestCount = 5;
            var mockBearer = CreateMockBearerPolicy();

            // Only one CreateSession response queued. If a second acquisition were
            // attempted within the cooldown window, the inner MockTransport would
            // throw, failing the test.
            var (provider, createSessionTransport) = CreateProvider(
                CreateSessionErrorResponse(statusCode, errorCode));
            var policy = CreateSessionPolicy(mockBearer, EnabledOptions, provider);

            for (int i = 0; i < requestCount; i++)
            {
                await SendBlobGetAsync(
                    policy,
                    BlobUri,
                    RequestMethod.Get,
                    CreateBlobGetResponse(200));
            }

            // Every request should have fallen back to bearer.
            VerifyBearerPolicyInvoked(mockBearer, Times.Exactly(requestCount));
            // Exactly one CreateSession attempt — the sentinel cached after the first
            // failure prevented re-acquisition for all subsequent requests.
            Assert.AreEqual(1, createSessionTransport.Requests.Count,
                "Cooldown should prevent re-acquisition; expected exactly one CreateSession call.");
        }

        [Test]
        public async Task SessionAcquireFails_CooldownIsPerContainer()
        {
            var mockBearer = CreateMockBearerPolicy();

            // Two CreateSession responses on a single inner transport:
            //   1. containerA's first acquire fails (eligible 500).
            //   2. containerB's first acquire succeeds with tokenB.
            // If containerA's cooldown weren't per-container, a re-acquire on A would
            // steal containerB's queued response and break this test.
            var (provider, createSessionTransport) = CreateProvider(
                CreateSessionErrorResponse(500, "InternalError"),
                CreateSessionMockResponse(sessionToken: "tokenB"));
            var policy = CreateSessionPolicy(mockBearer, EnabledOptions, provider);

            var containerAUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerA/{BlobName}");
            var containerBUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerB/{BlobName}");

            // 3 requests to A — all should fall back to bearer.
            for (int i = 0; i < 3; i++)
            {
                await SendBlobGetAsync(
                    policy,
                    containerAUri,
                    RequestMethod.Get,
                    CreateBlobGetResponse(200));
            }

            // 3 requests to B — all should sign with tokenB.
            for (int i = 0; i < 3; i++)
            {
                var (_, transportB) = await SendBlobGetAsync(
                    policy,
                    containerBUri,
                    RequestMethod.Get,
                    CreateBlobGetResponse(200));

                Assert.IsTrue(transportB.Requests[0].Headers.TryGetValue("Authorization", out string authB));
                Assert.IsTrue(authB.StartsWith("Session tokenB:"),
                    $"Expected containerB to sign with tokenB, got: {authB}");
            }

            // Bearer was invoked once per A request; containerB's requests went through
            // the session path (not bearer).
            VerifyBearerPolicyInvoked(mockBearer, Times.Exactly(3));
            // Exactly two CreateSession attempts: one A (failed → cooldown), one B (succeeded → cached).
            Assert.AreEqual(2, createSessionTransport.Requests.Count,
                "Cooldown should be scoped per container; expected one CreateSession per container.");
        }

        [Test]
        public async Task Concurrent_SessionAcquireFails_CooldownPreventsThunderingHerd()
        {
            const int parallelism = 50;
            var mockBearer = CreateMockBearerPolicy();

            // Only one CreateSession response queued. A second acquisition would
            // underrun the inner transport and throw, failing the test.
            var (provider, createSessionTransport) = CreateProvider(
                CreateSessionErrorResponse(503, "ServerBusy"));
            var policy = CreateSessionPolicy(mockBearer, EnabledOptions, provider);

            var outerResponses = new ConcurrentQueue<MockResponse>();
            for (int i = 0; i < parallelism; i++)
            {
                outerResponses.Enqueue(CreateBlobGetResponse(200));
            }
            var capturedAuthHeaders = new ConcurrentQueue<string>();
            var outerTransport = CreateConcurrentOuterTransport(outerResponses, capturedAuthHeaders);
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });

            using var startGate = new ManualResetEventSlim(false);
            var tasks = new Task[parallelism];
            for (int i = 0; i < parallelism; i++)
            {
                int index = i;
                tasks[i] = Task.Run(async () =>
                {
                    startGate.Wait();
                    var blobUri = new Uri($"https://{AccountName}.blob.core.windows.net/{ContainerName}/blob{index}");
                    var message = pipeline.CreateMessage();
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Uri.Reset(blobUri);
                    await SendAsync(pipeline, message);
                });
            }
            startGate.Set();
            await Task.WhenAll(tasks);

            // Every concurrent request fell back to bearer.
            VerifyBearerPolicyInvoked(mockBearer, Times.Exactly(parallelism));
            // Exactly one CreateSession attempt across all 50 concurrent callers — proves
            // both (a) the cache's TCS coalescing handled concurrent first-callers, and
            // (b) the cooldown prevented post-failure callers from re-attempting.
            Assert.AreEqual(1, createSessionTransport.Requests.Count,
                "Concurrent failed acquires should coalesce to a single CreateSession call.");
        }

        [Test]
        public void SessionTokenInfo_FallbackSentinel_RefreshOnEqualsExpiresOn()
        {
            TimeSpan cooldown = TimeSpan.FromMinutes(5);

            DateTimeOffset before = DateTimeOffset.UtcNow;
            SessionProvider.SessionTokenInfo sentinel =
                SessionProvider.SessionTokenInfo.CreateFallbackToBearer(cooldown);
            DateTimeOffset after = DateTimeOffset.UtcNow;

            Assert.IsTrue(sentinel.IsFallbackToBearer, "Sentinel must signal fallback to bearer.");
            Assert.GreaterOrEqual(sentinel.ExpiresOn, before + cooldown,
                "ExpiresOn must be at least UtcNow + cooldown at construction time.");
            Assert.LessOrEqual(sentinel.ExpiresOn, after + cooldown,
                "ExpiresOn must be at most UtcNow + cooldown at construction time.");
            // The sentinel must not refresh early: an earlier RefreshOn would shorten
            // the intended cooldown window and cause premature re-acquisition.
            Assert.AreEqual(sentinel.ExpiresOn, sentinel.RefreshOn,
                "RefreshOn must equal ExpiresOn so the full cooldown is honored.");
        }
        #endregion

        #region Response Handling
        [Test]
        public async Task SuccessResponse_ReturnsNormally()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            var (message, _) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.AreEqual(200, message.Response.Status);
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task Response401_InvalidatesCacheAndFallsBackToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(401));

            // The policy no longer retries with a fresh session: exactly one
            // session-authenticated attempt is made.
            Assert.AreEqual(1, outerTransport.Requests.Count,
                "A 401 must not trigger a session retry; expected a single outer request.");

            // The request is instead re-issued through the bearer token policy.
            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task Response401_NextRequest_ReAcquiresFreshSession()
        {
            const string staleToken = "stale-token";
            const string freshToken = "fresh-token";

            var mockBearer = CreateMockBearerPolicy();
            var (provider, createSessionTransport) = CreateProvider(
                CreateSessionMockResponse(sessionToken: staleToken),
                CreateSessionMockResponse(sessionToken: freshToken));
            var policy = CreateSessionPolicy(mockBearer, EnabledOptions, provider);

            // First request signs with the stale token and gets a 401, which must
            // invalidate the cached session. The Authorization header is captured as
            // the request goes over the wire, because the policy strips the session
            // credential off the request before falling back to bearer auth.
            string auth1 = null;
            var transport1 = new MockTransport(req =>
            {
                req.Headers.TryGetValue("Authorization", out auth1);
                return CreateBlobGetResponse(401);
            });
            var pipeline1 = new HttpPipeline(transport1, new HttpPipelinePolicy[] { policy });
            var message1 = pipeline1.CreateMessage();
            message1.Request.Method = RequestMethod.Get;
            message1.Request.Uri.Reset(BlobUri);

            await SendAsync(pipeline1, message1);

            Assert.IsNotNull(auth1, "First request should have been signed with a session token.");
            Assert.IsTrue(auth1.StartsWith($"Session {staleToken}:"),
                $"First request expected {staleToken}, got: {auth1}");
            VerifyBearerPolicyInvoked(mockBearer, Times.Once());

            // The session credential and its signing date must not survive the
            // fallback to bearer authentication.
            Assert.IsFalse(message1.Request.Headers.TryGetValue("Authorization", out _),
                "The session Authorization header should be removed before bearer fallback.");
            Assert.IsFalse(message1.Request.Headers.TryGetValue("x-ms-date", out _),
                "The session signing date should be removed before bearer fallback.");

            // The next request must mint a brand new session, proving the 401
            // cleared the cache rather than leaving the stale token in place.
            var (_, transport2) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.IsTrue(transport2.Requests[0].Headers.TryGetValue("Authorization", out string auth2));
            Assert.IsTrue(auth2.StartsWith($"Session {freshToken}:"),
                $"Second request expected {freshToken} after invalidation, got: {auth2}");
            Assert.AreEqual(2, createSessionTransport.Requests.Count,
                "Expected a second CreateSession call after the 401 invalidated the cache.");
        }

        [Test]
        public async Task Response401_DisposesPriorContentStreamBeforeBearerFallback()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            // Attach a tracking stream to the 401 response so we can observe whether
            // the policy disposes it before handing off to the bearer policy (which
            // will overwrite message.Response when it re-sends). Mirrors
            // Azure.Core.RetryPolicy behavior of disposing message.Response.ContentStream
            // between attempts to release the connection-pool lease.
            var trackingStream = new DisposeTrackingStream(Encoding.UTF8.GetBytes("<Error/>"));
            var response401 = CreateBlobGetResponse(401);
            response401.ContentStream = trackingStream;

            var outerTransport = new MockTransport(response401);
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            await SendAsync(pipeline, message);

            Assert.IsTrue(
                trackingStream.Disposed,
                "The 401 response's ContentStream should be disposed before bearer fallback to release the connection-pool lease.");
            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }
        #endregion

        #region Response Handling — MultiContainer
        [Test]
        public async Task MultiContainer_Response401_InvalidatesOnlyAffectedContainer()
        {
            var mockBearer = CreateMockBearerPolicy();
            // Three CreateSession responses:
            //   1. containerA initial session
            //   2. containerB initial session
            //   3. containerA re-acquired session on the request following the 401
            var (provider, createSessionTransport) = CreateProvider(
                CreateSessionMockResponse(sessionToken: "tokenA-original"),
                CreateSessionMockResponse(sessionToken: "tokenB-original"),
                CreateSessionMockResponse(sessionToken: "tokenA-refreshed"));
            var policy = CreateSessionPolicy(mockBearer, EnabledOptions, provider);

            var containerAUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerA/{BlobName}");
            var containerBUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerB/{BlobName}");

            // Warm both caches.
            await SendBlobGetAsync(policy, containerAUri, RequestMethod.Get, CreateBlobGetResponse(200));
            await SendBlobGetAsync(policy, containerBUri, RequestMethod.Get, CreateBlobGetResponse(200));

            // ContainerA gets a 401 -> invalidates only containerA's cache and falls back to bearer.
            var (_, transportA401) = await SendBlobGetAsync(
                policy, containerAUri, RequestMethod.Get, CreateBlobGetResponse(401));

            Assert.AreEqual(1, transportA401.Requests.Count,
                "A 401 must not trigger a session retry.");
            VerifyBearerPolicyInvoked(mockBearer, Times.Once());

            // ContainerB's cache must be unaffected -- still uses its original token
            // and must not have triggered a re-acquisition.
            var (_, transportB2) = await SendBlobGetAsync(
                policy, containerBUri, RequestMethod.Get, CreateBlobGetResponse(200));
            Assert.IsTrue(transportB2.Requests[0].Headers.TryGetValue("Authorization", out string authB));
            Assert.IsTrue(authB.StartsWith("Session tokenB-original:"),
                $"ContainerB cache should be intact, got: {authB}");
            Assert.AreEqual(2, createSessionTransport.Requests.Count,
                "ContainerB should still be served from cache; no third CreateSession yet.");

            // ContainerA's next request re-acquires, proving its entry (and only its
            // entry) was invalidated.
            var (_, transportA2) = await SendBlobGetAsync(
                policy, containerAUri, RequestMethod.Get, CreateBlobGetResponse(200));
            Assert.IsTrue(transportA2.Requests[0].Headers.TryGetValue("Authorization", out string authA2));
            Assert.IsTrue(authA2.StartsWith("Session tokenA-refreshed:"),
                $"ContainerA should have re-acquired after the 401, got: {authA2}");
            Assert.AreEqual(3, createSessionTransport.Requests.Count);
        }

        [Test]
        public async Task MultiContainer_AcquisitionFailure_DoesNotAffectOtherContainers()
        {
            var mockBearer = CreateMockBearerPolicy();
            // Two CreateSession responses:
            //   1. containerA fails with 500
            //   2. containerB succeeds
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionErrorResponse(500, "InternalError"),
                CreateSessionMockResponse(sessionToken: "tokenB"));

            var containerAUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerA/{BlobName}");
            var containerBUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerB/{BlobName}");

            // ContainerA acquisition fails → falls back to bearer.
            await SendBlobGetAsync(
                policy,
                containerAUri,
                RequestMethod.Get,
                new MockResponse(200));
            VerifyBearerPolicyInvoked(mockBearer, Times.Once());

            // ContainerB should still get a session token — not affected by containerA's failure.
            var (_, transportB) = await SendBlobGetAsync(
                policy, containerBUri, RequestMethod.Get, CreateBlobGetResponse(200));
            Assert.IsTrue(transportB.Requests[0].Headers.TryGetValue("Authorization", out string authB));
            Assert.IsTrue(authB.StartsWith("Session tokenB:"),
                $"ContainerB should use session auth, got: {authB}");
        }

        #endregion

        #region Cache Expiration
        [Test]
        public async Task SecondRequest_AfterSessionExpires_ReAcquiresNewSession()
        {
            var mockBearer = CreateMockBearerPolicy();
            // First session expires very quickly (already in the past by second request),
            // second session is long-lived.
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse(
                    sessionToken: "short-lived-token",
                    expiration: DateTimeOffset.UtcNow.AddSeconds(1)),
                CreateSessionMockResponse(
                    sessionToken: "renewed-token",
                    expiration: DateTimeOffset.UtcNow.AddMinutes(30)));

            // First request succeeds with the short-lived token.
            var (message1, transport1) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.IsTrue(transport1.Requests[0].Headers.TryGetValue("Authorization", out string auth1));
            Assert.IsTrue(auth1.StartsWith("Session short-lived-token:"),
                $"First request expected short-lived-token, got: {auth1}");

            // Wait for the session to expire (expiration was 1s, refresh buffer is 30s,
            // so refreshOn is already in the past → cache treats it as expired).
            await Task.Delay(TimeSpan.FromSeconds(2));

            // Second request should trigger re-acquisition since the session expired.
            var (message2, transport2) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.IsTrue(transport2.Requests[0].Headers.TryGetValue("Authorization", out string auth2));
            Assert.IsTrue(auth2.StartsWith("Session renewed-token:"),
                $"Second request expected renewed-token after expiry, got: {auth2}");
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task MultiContainer_ExpiredContainer_ReAcquires_WhileOtherContainerCacheIntact()
        {
            var mockBearer = CreateMockBearerPolicy();
            // Three CreateSession responses:
            //   1. containerA: short-lived session (expires in 1s)
            //   2. containerB: long-lived session
            //   3. containerA: re-acquired session after expiry
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse(
                    sessionToken: "tokenA-short",
                    expiration: DateTimeOffset.UtcNow.AddSeconds(1)),
                CreateSessionMockResponse(
                    sessionToken: "tokenB-long",
                    expiration: DateTimeOffset.UtcNow.AddMinutes(30)),
                CreateSessionMockResponse(
                    sessionToken: "tokenA-renewed",
                    expiration: DateTimeOffset.UtcNow.AddMinutes(30)));

            var containerAUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerA/{BlobName}");
            var containerBUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerB/{BlobName}");
            var containerA2Uri = new Uri($"https://{AccountName}.blob.core.windows.net/containerA/blob2");
            var containerB2Uri = new Uri($"https://{AccountName}.blob.core.windows.net/containerB/blob2");

            // Warm both caches.
            var (_, transportA1) = await SendBlobGetAsync(
                policy, containerAUri, RequestMethod.Get, CreateBlobGetResponse(200));
            var (_, transportB1) = await SendBlobGetAsync(
                policy, containerBUri, RequestMethod.Get, CreateBlobGetResponse(200));

            Assert.IsTrue(transportA1.Requests[0].Headers.TryGetValue("Authorization", out string authA1));
            Assert.IsTrue(transportB1.Requests[0].Headers.TryGetValue("Authorization", out string authB1));
            Assert.IsTrue(authA1.StartsWith("Session tokenA-short:"), $"Expected tokenA-short, got: {authA1}");
            Assert.IsTrue(authB1.StartsWith("Session tokenB-long:"), $"Expected tokenB-long, got: {authB1}");

            // Wait for containerA's session to expire.
            await Task.Delay(2_000);

            // ContainerA should re-acquire a fresh session.
            var (_, transportA2) = await SendBlobGetAsync(
                policy, containerA2Uri, RequestMethod.Get, CreateBlobGetResponse(200));
            Assert.IsTrue(transportA2.Requests[0].Headers.TryGetValue("Authorization", out string authA2));
            Assert.IsTrue(authA2.StartsWith("Session tokenA-renewed:"),
                $"Expected containerA to re-acquire after expiry, got: {authA2}");

            // ContainerB's cache should be completely unaffected — still using original token.
            var (_, transportB2) = await SendBlobGetAsync(
                policy, containerB2Uri, RequestMethod.Get, CreateBlobGetResponse(200));
            Assert.IsTrue(transportB2.Requests[0].Headers.TryGetValue("Authorization", out string authB2));
            Assert.IsTrue(authB2.StartsWith("Session tokenB-long:"),
                $"Expected containerB cache to be intact, got: {authB2}");

            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }
        #endregion

        #region Concurrency
        [Test]
        public async Task Concurrent_SameContainer_AcquiresSessionOnce()
        {
            const int parallelism = 50;
            var mockBearer = CreateMockBearerPolicy();

            // Only one CreateSession response queued. If a second acquisition were
            // attempted, the inner MockTransport would throw, failing the test.
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse(sessionToken: "shared-token"));

            var outerResponses = new ConcurrentQueue<MockResponse>();
            for (int i = 0; i < parallelism; i++)
            {
                outerResponses.Enqueue(CreateBlobGetResponse(200));
            }
            var capturedAuthHeaders = new ConcurrentQueue<string>();
            var outerTransport = CreateConcurrentOuterTransport(outerResponses, capturedAuthHeaders);
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });

            // Release all tasks at once.
            using var startGate = new ManualResetEventSlim(false);
            var tasks = new Task[parallelism];
            for (int i = 0; i < parallelism; i++)
            {
                int index = i;
                tasks[i] = Task.Run(async () =>
                {
                    startGate.Wait();
                    var blobUri = new Uri($"https://{AccountName}.blob.core.windows.net/{ContainerName}/blob{index}");
                    var message = pipeline.CreateMessage();
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Uri.Reset(blobUri);
                    await SendAsync(pipeline, message);
                    Assert.AreEqual(200, message.Response.Status);
                });
            }
            startGate.Set();
            await Task.WhenAll(tasks);

            // Every request must have signed with the single shared token.
            Assert.AreEqual(parallelism, capturedAuthHeaders.Count);
            foreach (string auth in capturedAuthHeaders)
            {
                Assert.IsNotNull(auth, "Every concurrent request should have an Authorization header.");
                Assert.IsTrue(
                    auth.StartsWith("Session shared-token:"),
                    $"Expected shared-token, got: {auth}");
            }
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task Concurrent_DifferentContainers_EachAcquiresSessionOnce()
        {
            const int numContainers = 5;
            const int numCallsPerContainer = 20;
            var mockBearer = CreateMockBearerPolicy();

            // Exactly one CreateSession response per container. Any extra acquisition
            // would drain the queue and throw, proving each container's cache is
            // populated exactly once.
            var sessionResponses = new MockResponse[numContainers];
            for (int i = 0; i < numContainers; i++)
            {
                sessionResponses[i] = CreateSessionMockResponse(sessionToken: $"token{i}");
            }
            var policy = CreateSessionPolicy(mockBearer, EnabledOptions, sessionResponses);

            int totalRequests = numContainers * numCallsPerContainer;
            var outerResponses = new ConcurrentQueue<MockResponse>();
            for (int i = 0; i < totalRequests; i++)
            {
                outerResponses.Enqueue(CreateBlobGetResponse(200));
            }
            // Capture (containerIndex, sessionToken) pairs so we can verify each
            // container consistently uses the same token across all its requests.
            var capturedTokens = new ConcurrentQueue<(int ContainerIndex, string Token)>();
            var outerTransport = MockTransport.FromMessageCallback(msg =>
            {
                msg.Request.Headers.TryGetValue("Authorization", out string auth);
                // Recover containerIndex from the URL path: "/cN/blobM" -> N.
                string path = msg.Request.Uri.Path;
                string containerSegment = path.Split('/')[1]; // "cN"
                int idx = int.Parse(containerSegment.Substring(1));
                // Extract the session token portion: "Session <token>:<sig>" -> "<token>".
                string token = auth?.Substring("Session ".Length).Split(':')[0];
                capturedTokens.Enqueue((idx, token));
                outerResponses.TryDequeue(out MockResponse resp);
                return resp;
            });
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });

            using var startGate = new ManualResetEventSlim(false);
            var tasks = new Task[totalRequests];
            for (int i = 0; i < totalRequests; i++)
            {
                int containerIdx = i % numContainers;
                int blobIdx = i;
                tasks[i] = Task.Run(async () =>
                {
                    startGate.Wait();
                    var uri = new Uri($"https://{AccountName}.blob.core.windows.net/c{containerIdx}/blob{blobIdx}");
                    var message = pipeline.CreateMessage();
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Uri.Reset(uri);
                    await SendAsync(pipeline, message);
                });
            }
            startGate.Set();
            await Task.WhenAll(tasks);

            Assert.AreEqual(totalRequests, capturedTokens.Count);

            // Group captured tokens by container index. Each container must:
            //   1. Have used exactly one token across all its requests.
            //   2. Map to a distinct token (no two containers shared a cache).
            var tokenByContainer = new System.Collections.Generic.Dictionary<int, string>();
            foreach (var (containerIndex, token) in capturedTokens)
            {
                Assert.IsNotNull(token, $"Container c{containerIndex} request had no Authorization token.");
                if (tokenByContainer.TryGetValue(containerIndex, out string existing))
                {
                    Assert.AreEqual(existing, token,
                        $"Container c{containerIndex} should consistently use one token, but saw both '{existing}' and '{token}'.");
                }
                else
                {
                    tokenByContainer[containerIndex] = token;
                }
            }
            Assert.AreEqual(numContainers, tokenByContainer.Count, "Every container should have acquired a token.");
            Assert.AreEqual(numContainers, new System.Collections.Generic.HashSet<string>(tokenByContainer.Values).Count,
                "Each container must have its own distinct token (per-container cache isolation).");
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }
        #endregion

        #region Shared SessionProvider Across Clients
        // A SessionProvider owns its own session-minting BlobServiceClient, built from
        // the arguments given to its constructor. It is therefore independent of the
        // lifetime and pipeline of any client that consumes it. These tests share a
        // single provider across multiple policies (each policy standing in for an
        // independently constructed client) and assert that the session cache is shared
        // and survives.

        [Test]
        public async Task SharedProvider_AfterClientDropped_CacheSurvives()
        {
            var mockBearer = CreateMockBearerPolicy();

            // Only one CreateSession response: the surviving client must reuse the
            // cache warmed by the dropped one.
            var (provider, createSessionTransport) = CreateProvider(
                CreateSessionMockResponse(sessionToken: "persistent-token"));

            // Warm the cache using a policy scoped to a helper method, then drop it.
            // Azure SDK clients are not IDisposable, so "disposing" a client means
            // releasing the last reference to it.
            WeakReference weakRef = await WarmCacheWithTransientClientAsync(provider, mockBearer);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // Collection is not what keeps the cache alive (the provider is
            // independently rooted), so this is informational rather than load-bearing.
            TestContext.WriteLine($"Transient client collected: {!weakRef.IsAlive}");

            // A brand new client over the same provider must reuse the cached session.
            var survivingPolicy = CreateSessionPolicy(mockBearer, EnabledOptions, provider);
            var (_, transport) = await SendBlobGetAsync(
                survivingPolicy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.IsTrue(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth));
            Assert.IsTrue(auth.StartsWith("Session persistent-token:"),
                $"The surviving client should reuse the cached session, got: {auth}");
            Assert.AreEqual(1, createSessionTransport.Requests.Count,
                "The session cache must survive the disposal of the client that warmed it.");
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        /// <summary>
        /// Warms <paramref name="provider"/>'s cache using a policy that goes out of
        /// scope when this method returns, leaving only a <see cref="WeakReference"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private async Task<WeakReference> WarmCacheWithTransientClientAsync(
            SessionProvider provider,
            Mock<HttpPipelinePolicy> mockBearer)
        {
            var transientPolicy = CreateSessionPolicy(mockBearer, EnabledOptions, provider);

            var (_, transport) = await SendBlobGetAsync(
                transientPolicy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.IsTrue(transport.Requests[0].Headers.TryGetValue("Authorization", out string auth));
            Assert.IsTrue(auth.StartsWith("Session persistent-token:"),
                $"The transient client should have warmed the cache, got: {auth}");

            return new WeakReference(transientPolicy);
        }

        [Test]
        public async Task SharedProvider_401OnOneClient_InvalidatesForAllClients()
        {
            var mockBearer = CreateMockBearerPolicy();
            var (provider, createSessionTransport) = CreateProvider(
                CreateSessionMockResponse(sessionToken: "token-original"),
                CreateSessionMockResponse(sessionToken: "token-refreshed"));

            // Client A warms the cache.
            var policyA = CreateSessionPolicy(mockBearer, EnabledOptions, provider);
            var (_, transportA1) = await SendBlobGetAsync(
                policyA, BlobUri, RequestMethod.Get, CreateBlobGetResponse(200));
            Assert.IsTrue(transportA1.Requests[0].Headers.TryGetValue("Authorization", out string authA1));
            Assert.IsTrue(authA1.StartsWith("Session token-original:"));

            // Client A then receives a 401, invalidating the shared cache entry.
            var (_, transportA2) = await SendBlobGetAsync(
                policyA, BlobUri, RequestMethod.Get, CreateBlobGetResponse(401));
            Assert.AreEqual(1, transportA2.Requests.Count, "A 401 must not trigger a session retry.");
            VerifyBearerPolicyInvoked(mockBearer, Times.Once());

            // Client B — a different client — must observe the invalidation and mint
            // a fresh session rather than reusing the revoked token.
            var policyB = CreateSessionPolicy(mockBearer, EnabledOptions, provider);
            var (_, transportB) = await SendBlobGetAsync(
                policyB, BlobUri, RequestMethod.Get, CreateBlobGetResponse(200));

            Assert.IsTrue(transportB.Requests[0].Headers.TryGetValue("Authorization", out string authB));
            Assert.IsTrue(authB.StartsWith("Session token-refreshed:"),
                $"Invalidation must be visible across clients sharing a provider, got: {authB}");
            Assert.AreEqual(2, createSessionTransport.Requests.Count);
        }

        [Test]
        public async Task SharedProvider_ConcurrentClients_AcquireSessionOnce()
        {
            const int policyCount = 5;
            const int requestsPerPolicy = 10;
            const int totalRequests = policyCount * requestsPerPolicy;

            var mockBearer = CreateMockBearerPolicy();

            // One queued CreateSession response across every concurrent caller on
            // every policy: guards the ConcurrentDictionary + AutoRefreshingCache
            // coalescing under the shared-provider topology.
            var (provider, createSessionTransport) = CreateProvider(
                CreateSessionMockResponse(sessionToken: "shared-token"));

            var outerResponses = new ConcurrentQueue<MockResponse>();
            for (int i = 0; i < totalRequests; i++)
            {
                outerResponses.Enqueue(CreateBlobGetResponse(200));
            }
            var capturedAuthHeaders = new ConcurrentQueue<string>();
            var outerTransport = CreateConcurrentOuterTransport(outerResponses, capturedAuthHeaders);

            // Each policy is an independently constructed client sharing one provider,
            // and each gets its own pipeline over a common transport.
            var pipelines = new HttpPipeline[policyCount];
            for (int i = 0; i < policyCount; i++)
            {
                var policy = CreateSessionPolicy(mockBearer, EnabledOptions, provider);
                pipelines[i] = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            }

            using var startGate = new ManualResetEventSlim(false);
            var tasks = new Task[totalRequests];
            for (int i = 0; i < totalRequests; i++)
            {
                HttpPipeline pipeline = pipelines[i % policyCount];
                int blobIndex = i;
                tasks[i] = Task.Run(async () =>
                {
                    startGate.Wait();
                    var blobUri = new Uri($"https://{AccountName}.blob.core.windows.net/{ContainerName}/blob{blobIndex}");
                    var message = pipeline.CreateMessage();
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Uri.Reset(blobUri);
                    await SendAsync(pipeline, message);
                    Assert.AreEqual(200, message.Response.Status);
                });
            }
            startGate.Set();
            await Task.WhenAll(tasks);

            Assert.AreEqual(1, createSessionTransport.Requests.Count,
                "Concurrent clients sharing a provider should coalesce into one CreateSession.");
            Assert.AreEqual(totalRequests, capturedAuthHeaders.Count);
            foreach (string auth in capturedAuthHeaders)
            {
                Assert.IsNotNull(auth);
                Assert.IsTrue(auth.StartsWith("Session shared-token:"),
                    $"Expected the single shared token, got: {auth}");
            }
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }
        #endregion

        #region SessionOptions.SessionProvider Wiring
        private static MockResponse CreateBlobDownloadResponse()
        {
            var response = new MockResponse(200);
            response.AddHeader("Content-Type", "application/octet-stream");
            response.AddHeader("x-ms-blob-type", "BlockBlob");
            response.SetContent("hello");
            return response;
        }

        /// <summary>
        /// Builds client options wired to <paramref name="provider"/> and to a
        /// data-plane transport that serves a single blob download.
        /// </summary>
        private static (BlobClientOptions Options, MockTransport DataTransport) CreateWiredClientOptions(
            SessionProvider provider)
        {
            var dataTransport = new MockTransport(CreateBlobDownloadResponse());
            var options = new BlobClientOptions
            {
                Transport = dataTransport,
                SessionOptions = new SessionOptions
                {
                    SessionMode = SessionMode.Enabled,
                    AccountName = AccountName,
                    SessionProvider = provider,
                },
            };
            options.Retry.MaxRetries = 0;
            return (options, dataTransport);
        }

        private async Task DownloadAsync(BlobClient client)
        {
            if (_async)
            {
                await client.DownloadStreamingAsync();
            }
            else
            {
                client.DownloadStreaming();
            }
        }

        private static void AssertSignedWithSession(MockTransport dataTransport, string expectedToken)
        {
            Assert.Greater(dataTransport.Requests.Count, 0, "Expected a data-plane request.");
            Assert.IsTrue(
                dataTransport.Requests[0].Headers.TryGetValue("Authorization", out string auth),
                "Data-plane request should carry an Authorization header.");
            Assert.IsTrue(auth.StartsWith($"Session {expectedToken}:", StringComparison.Ordinal),
                $"Expected session auth using the supplied provider's token, got: {auth}");
        }

        [Test]
        public void Clone_PreservesSessionProvider()
        {
            var (provider, _) = CreateProvider();
            var options = new SessionOptions
            {
                SessionMode = SessionMode.Enabled,
                AccountName = AccountName,
                SessionProvider = provider,
            };

            // The policy defensively clones SessionOptions; if Clone dropped the
            // provider, every client would silently fall back to its own cache.
            SessionOptions clone = options.Clone();

            Assert.AreSame(provider, clone.SessionProvider,
                "Clone must carry the customer-supplied provider through to the policy.");
            Assert.AreEqual(SessionMode.Enabled, clone.SessionMode);
            Assert.AreEqual(AccountName, clone.AccountName);
        }

        [Test]
        public async Task BlobClient_UsesSuppliedSessionProvider()
        {
            var (provider, createSessionTransport) = CreateProvider(CreateSessionMockResponse());
            var (options, dataTransport) = CreateWiredClientOptions(provider);

            var client = new BlobClient(BlobUri, new StaticTokenCredential(), options);
            await DownloadAsync(client);

            Assert.AreEqual(1, createSessionTransport.Requests.Count,
                "CreateSession should have been issued by the supplied provider's own transport.");
            AssertSignedWithSession(dataTransport, SessionToken);
        }

        [Test]
        public async Task BlobContainerClient_UsesSuppliedSessionProvider()
        {
            var (provider, createSessionTransport) = CreateProvider(CreateSessionMockResponse());
            var (options, dataTransport) = CreateWiredClientOptions(provider);

            var containerClient = new BlobContainerClient(ContainerUri, new StaticTokenCredential(), options);
            BlobClient client = containerClient.GetBlobClient(BlobName);
            await DownloadAsync(client);

            Assert.AreEqual(1, createSessionTransport.Requests.Count);
            AssertSignedWithSession(dataTransport, SessionToken);
        }

        [Test]
        public async Task BlobServiceClient_UsesSuppliedSessionProvider()
        {
            var (provider, createSessionTransport) = CreateProvider(CreateSessionMockResponse());
            var (options, dataTransport) = CreateWiredClientOptions(provider);

            var serviceClient = new BlobServiceClient(ServiceUri, new StaticTokenCredential(), options);
            BlobClient client = serviceClient
                .GetBlobContainerClient(ContainerName)
                .GetBlobClient(BlobName);
            await DownloadAsync(client);

            Assert.AreEqual(1, createSessionTransport.Requests.Count);
            AssertSignedWithSession(dataTransport, SessionToken);
        }

        /// <summary>
        /// The end-to-end expression of the scenario the provider abstraction exists
        /// for: two clients constructed entirely independently, sharing one provider,
        /// must mint only a single session for the same container.
        /// </summary>
        [Test]
        public async Task SharedProvider_AcrossIndependentClients_AcquiresSessionOnce()
        {
            // A single queued CreateSession response: a second acquisition would
            // underrun the provider transport and throw.
            var (provider, createSessionTransport) = CreateProvider(CreateSessionMockResponse());

            var (optionsA, dataTransportA) = CreateWiredClientOptions(provider);
            var clientA = new BlobClient(BlobUri, new StaticTokenCredential(), optionsA);
            await DownloadAsync(clientA);

            // Client B is built from scratch — separate options, separate pipeline,
            // separate transport — sharing only the provider.
            var (optionsB, dataTransportB) = CreateWiredClientOptions(provider);
            var clientB = new BlobClient(BlobUri, new StaticTokenCredential(), optionsB);
            await DownloadAsync(clientB);

            Assert.AreEqual(1, createSessionTransport.Requests.Count,
                "Independent clients sharing a provider must reuse a single cached session.");
            AssertSignedWithSession(dataTransportA, SessionToken);
            AssertSignedWithSession(dataTransportB, SessionToken);
        }

        [Test]
        public async Task NoSuppliedProvider_ClientsDoNotShareCache()
        {
            // Each client creates its own client-scoped provider, so each must mint
            // its own session. Both clients point at their own CreateSession transport
            // via their own options; a shared cache would leave one unused.
            var transportA = new MockTransport(CreateSessionMockResponse(), CreateBlobDownloadResponse());
            var optionsA = new BlobClientOptions
            {
                Transport = transportA,
                SessionOptions = new SessionOptions
                {
                    SessionMode = SessionMode.Enabled,
                    AccountName = AccountName,
                },
            };
            optionsA.Retry.MaxRetries = 0;

            var transportB = new MockTransport(CreateSessionMockResponse(), CreateBlobDownloadResponse());
            var optionsB = new BlobClientOptions
            {
                Transport = transportB,
                SessionOptions = new SessionOptions
                {
                    SessionMode = SessionMode.Enabled,
                    AccountName = AccountName,
                },
            };
            optionsB.Retry.MaxRetries = 0;

            await DownloadAsync(new BlobClient(BlobUri, new StaticTokenCredential(), optionsA));
            await DownloadAsync(new BlobClient(BlobUri, new StaticTokenCredential(), optionsB));

            // Each transport saw both a CreateSession and a download, proving neither
            // client benefited from the other's cache.
            Assert.AreEqual(2, transportA.Requests.Count,
                "Client A should have minted its own session when no provider was supplied.");
            Assert.AreEqual(2, transportB.Requests.Count,
                "Client B should have minted its own session when no provider was supplied.");
        }
        #endregion

        /// <summary>
        /// Creates an outer <see cref="MockTransport"/> backed by a thread-safe FIFO of
        /// responses, recording the Authorization header observed on each request.
        /// Use when multiple requests may be sent concurrently through a single pipeline.
        /// </summary>
        private static MockTransport CreateConcurrentOuterTransport(
            ConcurrentQueue<MockResponse> responses,
            ConcurrentQueue<string> capturedAuthHeaders)
        {
            return MockTransport.FromMessageCallback(msg =>
            {
                msg.Request.Headers.TryGetValue("Authorization", out string auth);
                capturedAuthHeaders.Enqueue(auth);
                if (!responses.TryDequeue(out MockResponse response))
                {
                    throw new InvalidOperationException("Outer transport ran out of queued responses.");
                }
                return response;
            });
        }

        private sealed class DisposeTrackingStream : MemoryStream
        {
            public bool Disposed { get; private set; }

            public DisposeTrackingStream(byte[] data) : base(data)
            {
            }

            protected override void Dispose(bool disposing)
            {
                Disposed = true;
                base.Dispose(disposing);
            }
        }
    }
}
