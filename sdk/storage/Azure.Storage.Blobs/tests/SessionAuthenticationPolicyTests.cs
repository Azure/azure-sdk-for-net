// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.IO;
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

        public SessionAuthenticationPolicyTests(bool @async)
        {
            _async = @async;
        }

        #region Constants
        private const string AccountName = "testaccount";
        private const string ContainerName = "mycontainer";
        private const string BlobName = "myblob";
        private static readonly string s_accountKey = Convert.ToBase64String(new byte[32]);
        private static readonly string s_sessionKey = Convert.ToBase64String(Encoding.UTF8.GetBytes("testsessionkey1234567890ab"));
        private const string SessionToken = "test-session-token";

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

        private static BlobServiceClient CreateMockServiceClient(params MockResponse[] responses)
        {
            var transport = new MockTransport(responses);
            var options = new BlobClientOptions();
            options.Transport = transport;
            options.Retry.MaxRetries = 0;

            return new BlobServiceClient(
                ServiceUri,
                new StorageSharedKeyCredential(AccountName, s_accountKey),
                options);
        }

        private static SessionAuthenticationPolicy CreateSessionPolicy(
            Mock<HttpPipelinePolicy> mockBearer,
            SessionOptions sessionOptions,
            params MockResponse[] createSessionResponses)
        {
            var serviceClient = CreateMockServiceClient(createSessionResponses);
            return new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: sessionOptions);
        }

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
                bearerTokenPolicy: null,
                blobServiceClientFactory: () => CreateMockServiceClient(),
                sessionOptions: EnabledOptions));
        }

        [Test]
        public void Ctor_NullFactory_Throws()
        {
            var mockBearer = CreateMockBearerPolicy();
            Assert.Throws<ArgumentNullException>(() => new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: null,
                sessionOptions: EnabledOptions));
        }

        [Test]
        public void Ctor_NullSessionOptions_DefaultsToNone()
        {
            var mockBearer = CreateMockBearerPolicy();
            Assert.DoesNotThrow(() => new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => CreateMockServiceClient(),
                sessionOptions: null));
        }

        [Test]
        public void Ctor_EnabledMode_MissingAccountName_Throws()
        {
            var mockBearer = CreateMockBearerPolicy();
            Assert.Throws<ArgumentException>(() => new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => CreateMockServiceClient(),
                sessionOptions: new SessionOptions
                {
                    SessionMode = SessionMode.Enabled,
                    AccountName = null
                }));
        }

        [Test]
        public void Ctor_EnabledMode_DoesNotThrow()
        {
            var mockBearer = CreateMockBearerPolicy();
            Assert.DoesNotThrow(() => new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => CreateMockServiceClient(),
                sessionOptions: EnabledOptions));
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
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(sessionToken: "shared-token"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

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
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(sessionToken: "token-containerA"),
                CreateSessionMockResponse(sessionToken: "token-containerB"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

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

        [Test]
        public void SessionAcquireFails_OperationCanceled_Propagates()
        {
            var mockBearer = CreateMockBearerPolicy();

            // Factory throws OperationCanceledException (not RequestFailedException).
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => throw new OperationCanceledException(cts.Token),
                sessionOptions: EnabledOptions);

            Assert.That(
                async () => await SendBlobGetAsync(
                    policy,
                    BlobUri,
                    RequestMethod.Get,
                    CreateBlobGetResponse(200)),
                Throws.InstanceOf<OperationCanceledException>());
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }
        #endregion

        #region Session Acquisition Cooldown
        [Test]
        public async Task SessionAcquireFails_500_CooldownPreventsRepeatAcquisition()
        {
            const int requestCount = 5;
            var mockBearer = CreateMockBearerPolicy();

            // Only one CreateSession response queued. If a second acquisition were
            // attempted within the cooldown window, the inner MockTransport would
            // throw, failing the test.
            var innerTransport = new MockTransport(CreateSessionErrorResponse(500, "InternalError"));
            var innerOptions = new BlobClientOptions { Transport = innerTransport };
            innerOptions.Retry.MaxRetries = 0;
            var serviceClient = new BlobServiceClient(
                ServiceUri,
                new StorageSharedKeyCredential(AccountName, s_accountKey),
                innerOptions);

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

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
            Assert.AreEqual(1, innerTransport.Requests.Count,
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
            var innerTransport = new MockTransport(
                CreateSessionErrorResponse(500, "InternalError"),
                CreateSessionMockResponse(sessionToken: "tokenB"));
            var innerOptions = new BlobClientOptions { Transport = innerTransport };
            innerOptions.Retry.MaxRetries = 0;
            var serviceClient = new BlobServiceClient(
                ServiceUri,
                new StorageSharedKeyCredential(AccountName, s_accountKey),
                innerOptions);

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

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
            Assert.AreEqual(2, innerTransport.Requests.Count,
                "Cooldown should be scoped per container; expected one CreateSession per container.");
        }

        [Test]
        public async Task Concurrent_SessionAcquireFails_CooldownPreventsThunderingHerd()
        {
            const int parallelism = 50;
            var mockBearer = CreateMockBearerPolicy();

            // Only one CreateSession response queued. A second acquisition would
            // underrun the inner transport and throw, failing the test.
            var innerTransport = new MockTransport(
                CreateSessionErrorResponse(503, "ServerBusy"));
            var innerOptions = new BlobClientOptions { Transport = innerTransport };
            innerOptions.Retry.MaxRetries = 0;
            var serviceClient = new BlobServiceClient(
                ServiceUri,
                new StorageSharedKeyCredential(AccountName, s_accountKey),
                innerOptions);

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

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
            Assert.AreEqual(1, innerTransport.Requests.Count,
                "Concurrent failed acquires should coalesce to a single CreateSession call.");
        }

        [Test]
        public void SessionTokenInfo_FallbackSentinel_RefreshOnIsBeforeExpiry()
        {
            TimeSpan cooldown = TimeSpan.FromMinutes(5);
            TimeSpan refreshBuffer = TimeSpan.FromSeconds(30);

            DateTimeOffset before = DateTimeOffset.UtcNow;
            SessionAuthenticationPolicy.SessionTokenInfo sentinel =
                SessionAuthenticationPolicy.SessionTokenInfo.CreateFallbackToBearer(cooldown, refreshBuffer);
            DateTimeOffset after = DateTimeOffset.UtcNow;

            Assert.IsTrue(sentinel.IsFallbackToBearer, "Sentinel must signal fallback to bearer.");
            Assert.GreaterOrEqual(sentinel.ExpiresOn, before + cooldown,
                "ExpiresOn must be at least UtcNow + cooldown at construction time.");
            Assert.LessOrEqual(sentinel.ExpiresOn, after + cooldown,
                "ExpiresOn must be at most UtcNow + cooldown at construction time.");
            // Locks in the contract that a background refresh probes the service
            // refreshBuffer before the cooldown expires.
            Assert.AreEqual(sentinel.ExpiresOn - refreshBuffer, sentinel.RefreshOn,
                "RefreshOn must precede ExpiresOn by exactly refreshBuffer to enable proactive recovery.");
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
        public async Task Response401_InvalidatesAndRetries()
        {
            string expiredToken = "expired-token";
            string freshToken = "fresh-token";
            var mockBearer = CreateMockBearerPolicy();
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(sessionToken: expiredToken),
                CreateSessionMockResponse(sessionToken: freshToken));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

            // Capture Authorization header values at send time to avoid shared-reference issue.
            var capturedAuthHeaders = new System.Collections.Generic.List<string>();
            var responseIndex = 0;
            // Any 401 triggers one retry with a fresh session.
            MockResponse[] outerResponses = new[]
            {
                CreateBlobGetResponse(401),
                CreateBlobGetResponse(200)
            };

            var outerTransport = MockTransport.FromMessageCallback(msg =>
            {
                msg.Request.Headers.TryGetValue("Authorization", out string auth);
                capturedAuthHeaders.Add(auth);
                return outerResponses[responseIndex++];
            });

            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            await SendAsync(pipeline, message);

            Assert.AreEqual(2, capturedAuthHeaders.Count);
            Assert.AreEqual(200, message.Response.Status);

            Assert.IsTrue(capturedAuthHeaders[0].StartsWith($"Session {expiredToken}:"), $"First request expected {expiredToken}, got: {capturedAuthHeaders[0]}");
            Assert.IsTrue(capturedAuthHeaders[1].StartsWith($"Session {freshToken}:"), $"Second request expected {freshToken}, got: {capturedAuthHeaders[1]}");
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task Response401_ReacquireFails_FallsBackToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(),
                CreateSessionErrorResponse(500, "InternalError"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(401));

            // Only 1 outer request
            Assert.AreEqual(1, outerTransport.Requests.Count);

            // Re-acquisition failed → fell back to bearer token.
            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public void Response401_ReacquireFails_NonFallbackError_Propagates()
        {
            var mockBearer = CreateMockBearerPolicy();
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(),
                CreateSessionErrorResponse(404, "ContainerNotFound"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

            // 404 is not a fallback-eligible error
            Assert.ThrowsAsync<RequestFailedException>(async () => await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(401)));

            // Bearer was never invoked — the error propagated before reaching fallback.
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task Response401_RetryAlso401_DoesNotLoopInfinitely()
        {
            var mockBearer = CreateMockBearerPolicy();
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(sessionToken: "token1"),
                CreateSessionMockResponse(sessionToken: "token2"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

            var capturedAuthHeaders = new System.Collections.Generic.List<string>();
            var responseIndex = 0;
            // Both the original and the retry return 401
            MockResponse[] outerResponses = new[]
            {
                CreateBlobGetResponse(401),
                CreateBlobGetResponse(401)
            };

            var outerTransport = MockTransport.FromMessageCallback(msg =>
            {
                msg.Request.Headers.TryGetValue("Authorization", out string auth);
                capturedAuthHeaders.Add(auth);
                return outerResponses[responseIndex++];
            });

            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            await SendAsync(pipeline, message);

            // Exactly 2 attempts: original + one retry. No infinite loop.
            Assert.AreEqual(2, capturedAuthHeaders.Count);
            // Final response is still 401 — not retried further.
            Assert.AreEqual(401, message.Response.Status);
            // Bearer was never invoked — second 401 doesn't trigger fallback.
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task Response403_SessionSchemeNotSupported_FallsBackToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            var response403 = new MockResponse(403, "Authentication scheme Session is not supported.");
            response403.AddHeader("Content-Type", "application/xml");
            response403.SetContent(
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<Error><Code>AuthenticationFailed</Code>" +
                "<Message>Authentication scheme Session is not supported.</Message></Error>");

            var (message, _) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                response403);

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task Response403_DifferentReasonPhrase_NoFallback()
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
                new MockResponse(403, "Forbidden"));

            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
            Assert.AreEqual(403, message.Response.Status);
        }

        [Test]
        public async Task Response503_SessionsUnavailable_FallsBackToBearer()
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
                CreateBlobGetResponse(503, errorCode: "SessionOperationsTemporarilyUnavailable"));

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task Response503_DifferentErrorCode_NoFallback()
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
                CreateBlobGetResponse(503, errorCode: "ServerBusy"));

            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
            Assert.AreEqual(503, message.Response.Status);
        }

        [Test]
        public async Task Response401_DisposesPriorContentStreamBeforeRetry()
        {
            var mockBearer = CreateMockBearerPolicy();
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(sessionToken: "token1"),
                CreateSessionMockResponse(sessionToken: "token2"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

            // Attach a tracking stream to the 401 response
            // the policy disposes it before re-sending. Mirrors Azure.Core.RetryPolicy
            // behavior of disposing message.Response.ContentStream between attempts to
            // release the connection-pool lease.
            var trackingStream = new DisposeTrackingStream(Encoding.UTF8.GetBytes("<Error/>"));
            var response401 = CreateBlobGetResponse(401);
            response401.ContentStream = trackingStream;

            var outerTransport = new MockTransport(response401, CreateBlobGetResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            await SendAsync(pipeline, message);

            Assert.IsTrue(
                trackingStream.Disposed,
                "The 401 response's ContentStream should be disposed before the retry to release the connection-pool lease.");
            Assert.AreEqual(200, message.Response.Status);
        }

        [Test]
        public async Task Response503_SessionsUnavailable_DisposesPriorContentStreamBeforeBearerFallback()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreateSessionPolicy(
                mockBearer,
                EnabledOptions,
                CreateSessionMockResponse());

            // Attach a tracking stream to the 503 response so we can observe whether
            // the policy disposes it before handing off to the bearer policy (which
            // will overwrite message.Response when it re-sends).
            var trackingStream = new DisposeTrackingStream(Encoding.UTF8.GetBytes("<Error/>"));
            var response503 = CreateBlobGetResponse(
                503,
                errorCode: "SessionOperationsTemporarilyUnavailable");
            response503.ContentStream = trackingStream;

            var outerTransport = new MockTransport(response503);
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            await SendAsync(pipeline, message);

            Assert.IsTrue(
                trackingStream.Disposed,
                "The 503 response's ContentStream should be disposed before bearer fallback to release the connection-pool lease.");
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
            //   3. containerA re-acquired session after 401 invalidation
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(sessionToken: "tokenA-original"),
                CreateSessionMockResponse(sessionToken: "tokenB-original"),
                CreateSessionMockResponse(sessionToken: "tokenA-refreshed"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

            var containerAUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerA/{BlobName}");
            var containerBUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerB/{BlobName}");

            // Warm both caches.
            await SendBlobGetAsync(policy, containerAUri, RequestMethod.Get, CreateBlobGetResponse(200));
            await SendBlobGetAsync(policy, containerBUri, RequestMethod.Get, CreateBlobGetResponse(200));

            // ContainerA gets a 401 → invalidates containerA's cache, re-acquires, retries.
            var responseIndex = 0;
            MockResponse[] outerResponses = new[] {
                CreateBlobGetResponse(401),
                CreateBlobGetResponse(200)
            };
            var capturedAuthHeaders = new System.Collections.Generic.List<string>();
            var outerTransport = MockTransport.FromMessageCallback(msg =>
            {
                msg.Request.Headers.TryGetValue("Authorization", out string auth);
                capturedAuthHeaders.Add(auth);
                return outerResponses[responseIndex++];
            });

            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(containerAUri);
            await SendAsync(pipeline, message);

            // ContainerA should have re-acquired a fresh token.
            Assert.AreEqual(2, capturedAuthHeaders.Count);
            Assert.IsTrue(capturedAuthHeaders[0].StartsWith("Session tokenA-original:"),
                $"First request expected tokenA-original, got: {capturedAuthHeaders[0]}");
            Assert.IsTrue(capturedAuthHeaders[1].StartsWith("Session tokenA-refreshed:"),
                $"Retry expected refreshed tokenA, got: {capturedAuthHeaders[1]}");

            // ContainerB's cache should be unaffected — still uses original token.
            var (_, transportB2) = await SendBlobGetAsync(
                policy, containerBUri, RequestMethod.Get, CreateBlobGetResponse(200));
            Assert.IsTrue(transportB2.Requests[0].Headers.TryGetValue("Authorization", out string authB));
            Assert.IsTrue(authB.StartsWith("Session tokenB-original:"),
                $"ContainerB cache should be intact, got: {authB}");
        }

        [Test]
        public async Task MultiContainer_AcquisitionFailure_DoesNotAffectOtherContainers()
        {
            var mockBearer = CreateMockBearerPolicy();
            // Two CreateSession responses:
            //   1. containerA fails with 500
            //   2. containerB succeeds
            var serviceClient = CreateMockServiceClient(
                CreateSessionErrorResponse(500, "InternalError"),
                CreateSessionMockResponse(sessionToken: "tokenB"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

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

        [Test]
        public async Task MultiContainer_Response503_DoesNotAffectOtherContainers()
        {
            var mockBearer = CreateMockBearerPolicy();
            // Two CreateSession responses — one per container, both succeed.
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(sessionToken: "tokenA"),
                CreateSessionMockResponse(sessionToken: "tokenB"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

            var containerAUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerA/{BlobName}");
            var containerBUri = new Uri($"https://{AccountName}.blob.core.windows.net/containerB/{BlobName}");

            // ContainerA gets a 503 SessionsUnavailable → falls back to bearer.
            var (_, _) = await SendBlobGetAsync(
                policy,
                containerAUri,
                RequestMethod.Get,
                CreateBlobGetResponse(503, errorCode: "SessionOperationsTemporarilyUnavailable"));
            VerifyBearerPolicyInvoked(mockBearer, Times.Once());

            // ContainerB should still get a session token from its own cache.
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
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(
                    sessionToken: "short-lived-token",
                    expiration: DateTimeOffset.UtcNow.AddSeconds(1)),
                CreateSessionMockResponse(
                    sessionToken: "renewed-token",
                    expiration: DateTimeOffset.UtcNow.AddMinutes(30)));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

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
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(
                    sessionToken: "tokenA-short",
                    expiration: DateTimeOffset.UtcNow.AddSeconds(1)),
                CreateSessionMockResponse(
                    sessionToken: "tokenB-long",
                    expiration: DateTimeOffset.UtcNow.AddMinutes(30)),
                CreateSessionMockResponse(
                    sessionToken: "tokenA-renewed",
                    expiration: DateTimeOffset.UtcNow.AddMinutes(30)));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

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
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(sessionToken: "shared-token"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

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
            var serviceClient = CreateMockServiceClient(sessionResponses);

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

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

        [Test]
        public async Task Concurrent_401_OnSameContainer_AllTasksRecover()
        {
            const int parallelism = 20;
            var mockBearer = CreateMockBearerPolicy();

            // The policy invalidates the cache on every 401 and retries.
            var sessionResponses = new MockResponse[parallelism + 1]; // +1 for the initial prime.
            for (int i = 0; i < sessionResponses.Length; i++)
            {
                sessionResponses[i] = CreateSessionMockResponse(sessionToken: $"token{i}");
            }
            var serviceClient = CreateMockServiceClient(sessionResponses);

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

            // Prime the cache so all `parallelism` tasks start with a known token.
            await SendBlobGetAsync(policy, BlobUri, RequestMethod.Get, CreateBlobGetResponse(200));

            // Per-message attempt tracking: each HttpMessage's first attempt returns 401,
            // its retry returns 200.
            var attemptByMessage = new ConcurrentDictionary<HttpMessage, int>();
            var capturedAuthHeaders = new ConcurrentQueue<string>();
            var outerTransport = MockTransport.FromMessageCallback(msg =>
            {
                msg.Request.Headers.TryGetValue("Authorization", out string auth);
                capturedAuthHeaders.Enqueue(auth);
                int attempt = attemptByMessage.AddOrUpdate(msg, 1, (_, v) => v + 1);
                return CreateBlobGetResponse(attempt == 1 ? 401 : 200);
            });
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });

            using var startGate = new ManualResetEventSlim(false);
            var tasks = new Task[parallelism];
            for (int i = 0; i < parallelism; i++)
            {
                tasks[i] = Task.Run(async () =>
                {
                    startGate.Wait();
                    var message = pipeline.CreateMessage();
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Uri.Reset(BlobUri);
                    await SendAsync(pipeline, message);
                    Assert.AreEqual(200, message.Response.Status);
                });
            }
            startGate.Set();
            await Task.WhenAll(tasks);

            // Each task: 1 initial 401 attempt + 1 retry that succeeded = 2 outer requests.
            Assert.AreEqual(parallelism * 2, capturedAuthHeaders.Count);
            // Every header should be a Session header (no fallback to bearer).
            foreach (string auth in capturedAuthHeaders)
            {
                Assert.IsNotNull(auth);
                Assert.IsTrue(auth.StartsWith("Session token"),
                    $"Expected a Session header, got: {auth}");
            }
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task Concurrent_401_OnSameContainer_CoalescesIntoSingleReacquire()
        {
            const int parallelism = 20;
            var mockBearer = CreateMockBearerPolicy();

            // Exactly two CreateSession responses queued: one for the initial prime,
            // one for the post-401 re-acquisition. If the policy's InvalidateIfCurrent
            // coalescing fails (e.g. each of the N concurrent 401 handlers wipes the
            // cache and triggers its own re-acquire), the inner MockTransport will
            // run out of responses and throw, failing the test.
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(sessionToken: "token-original"),
                CreateSessionMockResponse(sessionToken: "token-refreshed"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: EnabledOptions);

            // Prime the cache with token-original so all `parallelism` tasks start
            // signing with the same (about-to-be-invalidated) token.
            await SendBlobGetAsync(policy, BlobUri, RequestMethod.Get, CreateBlobGetResponse(200));

            var attemptByMessage = new ConcurrentDictionary<HttpMessage, int>();
            var capturedAuthHeaders = new ConcurrentQueue<string>();
            using var arrivalGate = new CountdownEvent(parallelism);
            using var releaseGate = new ManualResetEventSlim(false);
            var outerTransport = MockTransport.FromMessageCallback(msg =>
            {
                msg.Request.Headers.TryGetValue("Authorization", out string auth);
                capturedAuthHeaders.Enqueue(auth);
                int attempt = attemptByMessage.AddOrUpdate(msg, 1, (_, v) => v + 1);
                if (attempt == 1)
                {
                    // First attempt: signal arrival, then wait for the test to
                    // release all N 401s together.
                    arrivalGate.Signal();
                    releaseGate.Wait();
                    return CreateBlobGetResponse(401);
                }
                // Retry: succeed immediately.
                return CreateBlobGetResponse(200);
            });
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });

            using var startGate = new ManualResetEventSlim(false);
            var tasks = new Task[parallelism];
            for (int i = 0; i < parallelism; i++)
            {
                tasks[i] = Task.Run(async () =>
                {
                    startGate.Wait();
                    var message = pipeline.CreateMessage();
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Uri.Reset(BlobUri);
                    await SendAsync(pipeline, message);
                    Assert.AreEqual(200, message.Response.Status);
                });
            }
            startGate.Set();

            // Wait for every first attempt to be parked at the transport, then
            // release them all at once.
            arrivalGate.Wait();
            releaseGate.Set();
            await Task.WhenAll(tasks);

            // Every task: 1 initial 401 + 1 retry = 2 outer requests.
            Assert.AreEqual(parallelism * 2, capturedAuthHeaders.Count);

            // Partition captured headers by token. The original-token requests are
            // the initial 401 attempts; the refreshed-token requests are the retries.
            // We expect exactly `parallelism` of each — i.e., one and only one
            // re-acquisition serviced all N concurrent 401 retries.
            int originalCount = 0;
            int refreshedCount = 0;
            foreach (string auth in capturedAuthHeaders)
            {
                Assert.IsNotNull(auth);
                if (auth.StartsWith("Session token-original:"))
                {
                    originalCount++;
                }
                else if (auth.StartsWith("Session token-refreshed:"))
                {
                    refreshedCount++;
                }
                else
                {
                    Assert.Fail($"Unexpected Authorization header: {auth}");
                }
            }
            Assert.AreEqual(parallelism, originalCount,
                "Every task's first attempt should have signed with the original token.");
            Assert.AreEqual(parallelism, refreshedCount,
                "Every task's retry should have signed with the single refreshed token. " +
                "Seeing a different count means the cache was re-acquired more than once.");
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
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
