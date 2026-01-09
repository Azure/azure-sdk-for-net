// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Vision.Face;
using Azure.AI.Vision.Face.Tests;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Tests
{
    public class FaceSessionClientTests : RecordedTestBase<FaceTestEnvironment>
    {
        internal enum SessionType {
            Liveness,
            LivenessWithVerify
        }

        // Pre-generated random device correlation id
        private const string DeviceCorrelationId = "11902120-3636-1876-4916-073bdc0f9b12";
        private List<(SessionType, string)> _createdSessions = new();
        public FaceSessionClientTests(bool isAsync) : base(isAsync)
        {
        }

        public FaceSessionClient CreateSessionClient(bool nonRecordingClient = false)
        {
            var endpoint = TestEnvironment.GetUrlVariable("FACE_ENDPOINT");
            var credential = TestEnvironment.Credential;

            if (nonRecordingClient)
            {
                return new FaceSessionClient(endpoint, credential);
            }

            return InstrumentClient(new FaceSessionClient(
                endpoint,
                credential,
                InstrumentClientOptions(new AzureAIVisionFaceClientOptions())));
        }

        [TearDown]
        protected async Task Cleanup()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                _createdSessions.Clear();
                return;
            }

            var client = CreateSessionClient(nonRecordingClient: true);

            foreach (var (type, sessionId) in _createdSessions)
            {
                if (type == SessionType.Liveness)
                {
                    await client.DeleteLivenessSessionAsync(sessionId);
                }
                else if (type == SessionType.LivenessWithVerify)
                {
                    await client.DeleteLivenessWithVerifySessionAsync(sessionId);
                }
            }

            _createdSessions.Clear();
        }

        protected void AssertAuditEntry(LivenessSessionAuditEntry auditEntry, string sessionId)
        {
            Assert.Multiple(() =>
            {
                Assert.That(auditEntry.Id, Is.Not.Null);
                Assert.That(auditEntry.RequestId, Is.Not.Null);
                Assert.That(auditEntry.ReceivedDateTime, Is.Not.Null);
                Assert.That(auditEntry.Digest, Is.Not.Null);
                Assert.That(sessionId, Is.EqualTo(auditEntry.SessionId));

                Assert.That(auditEntry.Request.Url, Is.Not.Null);
                Assert.That(auditEntry.Request.Method, Is.Not.Null);
                Assert.That(auditEntry.Request.ContentLength, Is.Not.Null);
                Assert.That(auditEntry.Request.ContentType, Is.Not.Null);

                Assert.That(auditEntry.Response.StatusCode, Is.Not.Null);
                Assert.That(auditEntry.Response.LatencyInMilliseconds, Is.Not.Null);

                Assert.That(auditEntry.Response.Body.LivenessDecision, Is.Not.Null);
                Assert.That(auditEntry.Response.Body.Target.FaceRectangle.Top, Is.Not.Null);
                Assert.That(auditEntry.Response.Body.Target.FaceRectangle.Left, Is.Not.Null);
                Assert.That(auditEntry.Response.Body.Target.FaceRectangle.Width, Is.Not.Null);
                Assert.That(auditEntry.Response.Body.Target.FaceRectangle.Height, Is.Not.Null);
                Assert.That(auditEntry.Response.Body.Target.FileName, Is.Not.Null);
                Assert.That(auditEntry.Response.Body.Target.TimeOffsetWithinFile, Is.Not.Null);
                Assert.That(auditEntry.Response.Body.Target.ImageType, Is.Not.Null);
            });
        }

        #region LivenessSession
        protected async Task<CreateLivenessSessionResult> CreateLivenessSession(bool nonRecordingClient = false)
        {
            var client = CreateSessionClient(nonRecordingClient: nonRecordingClient);

            var createContent = new CreateLivenessSessionContent(LivenessOperationMode.Passive)
            {
                DeviceCorrelationId = DeviceCorrelationId,
            };

            var createResponse = await client.CreateLivenessSessionAsync(createContent);
            _createdSessions.Add((SessionType.Liveness, createResponse.Value.SessionId));

            return createResponse.Value;
        }

        [RecordedTest]
        public async Task TestCreateLivenessSession()
        {
            var client = CreateSessionClient();

            var createResult = await CreateLivenessSession();

            Assert.That(createResult.SessionId, Is.Not.Null);
            Assert.That(createResult.AuthToken, Is.Not.Null);

            var getResponse = await client.GetLivenessSessionResultAsync(createResult.SessionId);
            Assert.That(getResponse.Value.DeviceCorrelationId, Is.EqualTo(DeviceCorrelationId));
        }

        [RecordedTest]
        public async Task TestListLivenessSessions()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                await CreateLivenessSession(nonRecordingClient: true);
                await CreateLivenessSession(nonRecordingClient: true);
            }

            var client = CreateSessionClient();

            var listResponse = await client.GetLivenessSessionsAsync();
            var sessionList = listResponse.Value;
            Assert.That(sessionList, Has.Count.GreaterThanOrEqualTo(2));
            Assert.That(sessionList[1].Id, Is.GreaterThan(sessionList[0].Id));

            foreach (var session in sessionList)
            {
                Assert.That(session.CreatedDateTime, Is.Not.Null);
                Assert.That(session.DeviceCorrelationId, Is.Not.Null);
                Assert.That(session.AuthTokenTimeToLiveInSeconds, Is.GreaterThanOrEqualTo(60));
                Assert.That(session.AuthTokenTimeToLiveInSeconds <= 86400, Is.True);
            }
        }

        [PlaybackOnly("Requiring other components to send underlying liveness request.")]
        [TestCase("4aeb437b-d9a1-4408-9731-15f79c2e4862")]
        public async Task TestGetSessionResult(string sessionId)
        {
            var client = CreateSessionClient();
            var response = await client.GetLivenessSessionResultAsync(sessionId);
            var session = response.Value;

            Assert.That(session.Id, Is.EqualTo(sessionId));
            Assert.That(session.CreatedDateTime, Is.Not.Null);
            Assert.That(session.DeviceCorrelationId, Is.Not.Null);
            Assert.That(session.AuthTokenTimeToLiveInSeconds, Is.GreaterThanOrEqualTo(60));
            Assert.That(session.AuthTokenTimeToLiveInSeconds <= 86400, Is.True);
            Assert.That(session.SessionStartDateTime, Is.Not.Null);
            Assert.That(session.SessionExpired, Is.Not.Null);
            Assert.That(session.Status, Is.EqualTo(FaceSessionStatus.ResultAvailable));

            AssertAuditEntry(session.Result, sessionId);
        }

        [PlaybackOnly("Requiring other components to send underlying liveness request.")]
        [TestCase("4aeb437b-d9a1-4408-9731-15f79c2e4862")]
        public async Task TestGetSessionAuditEntries(string sessionId)
        {
            var client = CreateSessionClient();
            var response = await client.GetLivenessSessionAuditEntriesAsync(sessionId);

            foreach (var auditEntry in response.Value)
            {
                AssertAuditEntry(auditEntry, sessionId);
            }
        }

        [RecordedTest]
        public async Task TestDeleteLivenessSessions()
        {
            var result = await CreateLivenessSession();

            var client = CreateSessionClient();
            await client.DeleteLivenessSessionAsync(result.SessionId);
            _createdSessions.RemoveAll(s => s.Item2 == result.SessionId);
        }
        #endregion

        #region LivenessWithVerifySession
        protected async Task<CreateLivenessWithVerifySessionResult> CreateLivenessWithVerifySession(bool withVerifyImage, bool nonRecordingClient = false)
        {
            var client = CreateSessionClient(nonRecordingClient: nonRecordingClient);

            var createContent = new CreateLivenessWithVerifySessionContent(LivenessOperationMode.Passive)
            {
                DeviceCorrelationId = DeviceCorrelationId,
            };

            Response<CreateLivenessWithVerifySessionResult> createResponse = null;

            if (withVerifyImage)
            {
                using var fileStream = new FileStream(FaceTestConstant.LocalSampleImage, FileMode.Open, FileAccess.Read);
                createResponse = await client.CreateLivenessWithVerifySessionAsync(createContent, fileStream);
            }
            else
            {
                createResponse = await client.CreateLivenessWithVerifySessionAsync(createContent, null);
            }

            _createdSessions.Add((SessionType.LivenessWithVerify, createResponse.Value.SessionId));

            return createResponse.Value;
        }

        protected void AssertVerifyResult(LivenessWithVerifyOutputs verifyResult)
        {
            Assert.That(verifyResult.IsIdentical, Is.Not.Null);
            Assert.That(verifyResult.MatchConfidence, Is.Not.Null);
            Assert.That(verifyResult.VerifyImage.FaceRectangle.Top, Is.Not.Null);
            Assert.That(verifyResult.VerifyImage.FaceRectangle.Left, Is.Not.Null);
            Assert.That(verifyResult.VerifyImage.FaceRectangle.Width, Is.Not.Null);
            Assert.That(verifyResult.VerifyImage.FaceRectangle.Height, Is.Not.Null);
            Assert.That(verifyResult.VerifyImage.QualityForRecognition, Is.Not.Null);
        }

        [LiveOnly] // Unable to playback multipart request.
        [AsyncOnly] // Sync MFD request will throw in debug build
        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task TestCreateLivenessWithVerifySession(bool withVerifyImage)
        {
            var client = CreateSessionClient();

            var createResult = await CreateLivenessWithVerifySession(withVerifyImage);

            Assert.That(createResult.SessionId, Is.Not.Null);
            Assert.That(createResult.AuthToken, Is.Not.Null);

            if (withVerifyImage)
            {
                Assert.That(createResult.VerifyImage, Is.Not.Null);
                Assert.That(createResult.VerifyImage.FaceRectangle.Top, Is.Not.Null);
                Assert.That(createResult.VerifyImage.FaceRectangle.Left, Is.Not.Null);
                Assert.That(createResult.VerifyImage.FaceRectangle.Width, Is.Not.Null);
                Assert.That(createResult.VerifyImage.FaceRectangle.Height, Is.Not.Null);
                Assert.That(createResult.VerifyImage.QualityForRecognition, Is.Not.Null);
            }

            var getResponse = await client.GetLivenessWithVerifySessionResultAsync(createResult.SessionId);
            Assert.That(getResponse.Value.DeviceCorrelationId, Is.EqualTo(DeviceCorrelationId));
        }

        [RecordedTest]
        public async Task TestListLivenessWithVerifySessions()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                await CreateLivenessWithVerifySession(true, nonRecordingClient: true);
                await CreateLivenessWithVerifySession(false, nonRecordingClient: true);
            }

            var client = CreateSessionClient();

            var listResponse = await client.GetLivenessWithVerifySessionsAsync();
            var sessionList = listResponse.Value;
            Assert.That(sessionList, Has.Count.GreaterThanOrEqualTo(2));
            Assert.That(sessionList[1].Id, Is.GreaterThan(sessionList[0].Id));

            foreach (var session in sessionList)
            {
                Assert.That(session.CreatedDateTime, Is.Not.Null);
                Assert.That(session.DeviceCorrelationId, Is.Not.Null);
                Assert.That(session.AuthTokenTimeToLiveInSeconds, Is.GreaterThanOrEqualTo(60));
                Assert.That(session.AuthTokenTimeToLiveInSeconds <= 86400, Is.True);
            }
        }

        [PlaybackOnly("Requiring other components to send underlying liveness request.")]
        [TestCase("56d976a9-130a-44e2-bb25-e84410f05b05")]
        public async Task TestGetLivenessWithVerifySessionResult(string sessionId)
        {
            var client = CreateSessionClient();
            var response = await client.GetLivenessWithVerifySessionResultAsync(sessionId);
            var session = response.Value;

            Assert.That(session.Id, Is.EqualTo(sessionId));
            Assert.That(session.CreatedDateTime, Is.Not.Null);
            Assert.That(session.DeviceCorrelationId, Is.Not.Null);
            Assert.That(session.AuthTokenTimeToLiveInSeconds, Is.GreaterThanOrEqualTo(60));
            Assert.That(session.AuthTokenTimeToLiveInSeconds <= 86400, Is.True);
            Assert.That(session.SessionStartDateTime, Is.Not.Null);
            Assert.That(session.SessionExpired, Is.Not.Null);
            Assert.That(session.Status, Is.EqualTo(FaceSessionStatus.ResultAvailable));

            AssertAuditEntry(session.Result, sessionId);
            AssertVerifyResult(session.Result.Response.Body.VerifyResult);
        }

        [PlaybackOnly("Requiring other components to send underlying liveness request.")]
        [TestCase("56d976a9-130a-44e2-bb25-e84410f05b05")]
        public async Task TestGetLivenessWithVerifySessionAuditEntries(string sessionId)
        {
            var client = CreateSessionClient();
            var response = await client.GetLivenessWithVerifySessionAuditEntriesAsync(sessionId);

            foreach (var auditEntry in response.Value)
            {
                AssertAuditEntry(auditEntry, sessionId);
                AssertVerifyResult(auditEntry.Response.Body.VerifyResult);
            }
        }

        [RecordedTest]
        public async Task TestDeleteLivenessWithVerifySessions()
        {
            var result = await CreateLivenessWithVerifySession(false);

            var client = CreateSessionClient();
            await client.DeleteLivenessWithVerifySessionAsync(result.SessionId);
            _createdSessions.RemoveAll(s => s.Item2 == result.SessionId);
        }
        #endregion
    }
}
