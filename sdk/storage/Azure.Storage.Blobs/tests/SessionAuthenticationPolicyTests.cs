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
        private static Uri DifferentContainerBlobUri => new Uri($"https://{AccountName}.blob.core.windows.net/othercontainer/{BlobName}");
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

        private static SessionAuthenticationPolicy CreatePolicy(
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

        private static SessionOptions SingleContainerOptions => new SessionOptions
        {
            SessionMode = SessionMode.SingleContainer,
            ContainerName = ContainerName
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
                sessionOptions: SingleContainerOptions));
        }

        [Test]
        public void Ctor_NullFactory_Throws()
        {
            var mockBearer = CreateMockBearerPolicy();
            Assert.Throws<ArgumentNullException>(() => new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: null,
                sessionOptions: SingleContainerOptions));
        }

        [Test]
        public void Ctor_SingleContainerMode_EmptyContainerName_Throws()
        {
            var mockBearer = CreateMockBearerPolicy();
            Assert.Throws<ArgumentException>(() => new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => CreateMockServiceClient(),
                sessionOptions: new SessionOptions
                {
                    SessionMode = SessionMode.SingleContainer,
                    ContainerName = null
                }));
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
        #endregion

        #region Request Routing (AnalyzeRequest)
        [Test]
        public async Task SessionModeNone_DelegatesToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                new SessionOptions { SessionMode = SessionMode.None });

            var outerTransport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            await SendAsync(pipeline, message);

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task NonGetRequest_DelegatesToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionMockResponse());

            var outerTransport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Put;
            message.Request.Uri.Reset(BlobUri);

            await SendAsync(pipeline, message);

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task ServiceLevelUri_DelegatesToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionMockResponse());

            var outerTransport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(ServiceUri);

            await SendAsync(pipeline, message);

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task ContainerLevelUri_NoBlobName_DelegatesToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionMockResponse());

            var outerTransport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(ContainerUri);

            await SendAsync(pipeline, message);

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task DifferentContainer_DelegatesToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionMockResponse());

            var outerTransport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(DifferentContainerBlobUri);

            await SendAsync(pipeline, message);

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task MatchingContainerBlobGet_UsesSessionToken()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionMockResponse());

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
            Assert.AreEqual(1, outerTransport.Requests.Count);
            Assert.AreEqual(200, message.Response.Status);
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }
        #endregion

        #region Session Token Acquisition & Signing
        [Test]
        public async Task SessionAcquireSucceeds_SetsSessionAuthorizationHeader()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
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
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
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
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionErrorResponse(500, "InternalError"));

            var outerTransport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            await SendAsync(pipeline, message);

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task SessionAcquireFails_403_FallsBackToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionErrorResponse(403, "Forbidden"));

            var outerTransport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            await SendAsync(pipeline, message);

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public async Task SessionAcquireFails_400_FeatureNotEnabled_FallsBackToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionErrorResponse(400, "FeatureNotEnabled"));

            var outerTransport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            await SendAsync(pipeline, message);

            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public void SessionAcquireFails_400_OtherErrorCode_Propagates()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionErrorResponse(400, "InvalidInput"));

            var outerTransport = new MockTransport(CreateBlobGetResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            Assert.ThrowsAsync<RequestFailedException>(async () => await SendAsync(pipeline, message));
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public void SessionAcquireFails_404_Propagates()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionErrorResponse(404, "ContainerNotFound"));

            var outerTransport = new MockTransport(CreateBlobGetResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            Assert.ThrowsAsync<RequestFailedException>(async () => await SendAsync(pipeline, message));
        }
        #endregion

        #region Response Handling
        [Test]
        public async Task SuccessResponse_NoAuthInfoHeader_ReturnsNormally()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionMockResponse());

            var (message, _) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.AreEqual(200, message.Response.Status);
        }

        [Test]
        public async Task SuccessResponse_SessionExpiring_SchedulesRefresh()
        {
            string refreshedToken = "refreshed-token";
            var mockBearer = CreateMockBearerPolicy();
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(),
                CreateSessionMockResponse(sessionToken: refreshedToken));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: SingleContainerOptions);

            // Request 1: session_expiring → ScheduleRefresh() marks RefreshOn = now.
            var (message1, outerTransport1) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200, authInfoHeader: "session_expiring"));

            Assert.AreEqual(200, message1.Response.Status);
            Assert.IsTrue(
                outerTransport1.Requests[0].Headers.TryGetValue("Authorization", out string auth1));
            Assert.IsTrue(
                auth1.StartsWith($"Session {SessionToken}:"),
                $"Request 1 should use original token, got: {auth1}");

            // Request 2: GetAsync sees NeedsBackgroundRefresh, starts Task.Run,
            // but returns the current (old) token immediately.
            var (message2, outerTransport2) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.AreEqual(200, message2.Response.Status);
            Assert.IsTrue(
                outerTransport2.Requests[0].Headers.TryGetValue("Authorization", out string auth2));
            Assert.IsTrue(
                auth2.StartsWith($"Session {SessionToken}:"),
                $"Request 2 should still use original token (background in-flight), got: {auth2}");

            // Give the background Task.Run time to complete.
            await Task.Delay(2_000);

            // Request 3: EvaluateState promotes the completed background value to current.
            var (message3, outerTransport3) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.AreEqual(200, message3.Response.Status);
            Assert.IsTrue(
                outerTransport3.Requests[0].Headers.TryGetValue("Authorization", out string auth3));
            Assert.IsTrue(
                auth3.StartsWith($"Session {refreshedToken}:"),
                $"Request 3 should use refreshed token after background promotion, got: {auth3}");
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task SuccessResponse_SessionRevoking_InvalidatesCache()
        {
            string originalToken = "original-token";
            string newToken = "new-token";
            var mockBearer = CreateMockBearerPolicy();
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(sessionToken: originalToken),
                CreateSessionMockResponse(sessionToken: newToken));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: SingleContainerOptions);

            // Request 1: uses original-token, response has session_revoking → Invalidate().
            var (message1, outerTransport1) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200, authInfoHeader: "session_revoking"));

            Assert.AreEqual(200, message1.Response.Status);
            Assert.IsTrue(
                outerTransport1.Requests[0].Headers.TryGetValue("Authorization", out string auth1));
            Assert.IsTrue(
                auth1.StartsWith($"Session {originalToken}:"),
                $"Request 1 should use {originalToken}, got: {auth1}");

            // Request 2: cache was invalidated, so a fresh CreateSession call yields new-token.
            var (message2, outerTransport2) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            Assert.AreEqual(200, message2.Response.Status);
            Assert.IsTrue(
                outerTransport2.Requests[0].Headers.TryGetValue("Authorization", out string auth2));
            Assert.IsTrue(
                auth2.StartsWith($"Session {newToken}:"),
                $"Request 2 should use {newToken} after invalidation, got: {auth2}");
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task Response401_SessionExpired_InvalidatesAndRetries()
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
                sessionOptions: SingleContainerOptions);

            // Capture Authorization header values at send time to avoid shared-reference issue.
            var capturedAuthHeaders = new System.Collections.Generic.List<string>();
            var responseIndex = 0;
            MockResponse[] outerResponses = new[]
            {
                CreateBlobGetResponse(401, wwwAuthenticateHeader: "Bearer error=\"session_expired\""),
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
        public async Task Response401_SessionExpired_ReacquireFails_FallsBackToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(),
                CreateSessionErrorResponse(500, "InternalError"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: SingleContainerOptions);

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(401, wwwAuthenticateHeader: "Bearer error=\"session_expired\""));

            // Only 1 outer request — the 500 was on the inner CreateSession transport.
            Assert.AreEqual(1, outerTransport.Requests.Count);

            // Re-acquisition failed → fell back to bearer token.
            VerifyBearerPolicyInvoked(mockBearer, Times.Once());
        }

        [Test]
        public void Response401_SessionExpired_ReacquireFails_NonFallbackError_Propagates()
        {
            var mockBearer = CreateMockBearerPolicy();
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(),
                CreateSessionErrorResponse(404, "ContainerNotFound"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: SingleContainerOptions);

            // 404 is not a fallback-eligible error, so it propagates as RequestFailedException.
            Assert.ThrowsAsync<RequestFailedException>(async () => await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(401, wwwAuthenticateHeader: "Bearer error=\"session_expired\"")));

            // Bearer was never invoked — the error propagated before reaching fallback.
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task Response401_OtherError_NoRetry()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionMockResponse());

            var (message, outerTransport) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(401, wwwAuthenticateHeader: "Bearer error=\"invalid_token\""));

            Assert.AreEqual(1, outerTransport.Requests.Count);
            Assert.AreEqual(401, message.Response.Status);
            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
        }

        [Test]
        public async Task Response503_SessionsUnavailable_FallsBackToBearer()
        {
            var mockBearer = CreateMockBearerPolicy();
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
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
            var policy = CreatePolicy(
                mockBearer,
                SingleContainerOptions,
                CreateSessionMockResponse());

            var (message, _) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(503, errorCode: "ServerBusy"));

            VerifyBearerPolicyInvoked(mockBearer, Times.Never());
            Assert.AreEqual(503, message.Response.Status);
        }
        #endregion

        [Test]
        public async Task SessionTokenIsCachedAcrossRequests()
        {
            var mockBearer = CreateMockBearerPolicy();
            // Only one CreateSession response — second call would throw.
            var serviceClient = CreateMockServiceClient(
                CreateSessionMockResponse(sessionToken: "cached-token"));

            var policy = new SessionAuthenticationPolicy(
                bearerTokenPolicy: mockBearer.Object,
                blobServiceClientFactory: () => serviceClient,
                sessionOptions: SingleContainerOptions);

            var (_, transport1) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            var (_, transport2) = await SendBlobGetAsync(
                policy,
                BlobUri,
                RequestMethod.Get,
                CreateBlobGetResponse(200));

            // Both requests should use the same cached session token.
            Assert.IsTrue(transport1.Requests[0].Headers.TryGetValue("Authorization", out string auth1));
            Assert.IsTrue(transport2.Requests[0].Headers.TryGetValue("Authorization", out string auth2));
            Assert.IsTrue(auth1.StartsWith("Session cached-token:"));
            Assert.IsTrue(auth2.StartsWith("Session cached-token:"));
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
                sessionOptions: SingleContainerOptions);

            var outerTransport = new MockTransport(CreateBlobGetResponse(200));
            var pipeline = new HttpPipeline(outerTransport, new HttpPipelinePolicy[] { policy });
            var message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(BlobUri);

            Assert.That(
                async () => await SendAsync(pipeline, message),
                Throws.InstanceOf<OperationCanceledException>());
        }
    }
}
