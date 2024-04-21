// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        private List<string> _createdLivenessSessionIds = new();
        public FaceSessionClientTests(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
        }

        public FaceSessionClient CreateSessionClient(bool nonRecordingClient = false)
        {
            var endpoint = TestEnvironment.GetUrlVariable("FACE_ENDPOINT");
            var credential = TestEnvironment.GetKeyVariable("FACE_KEY");

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
            var client = CreateSessionClient(nonRecordingClient: true);

            foreach (var sessionId in _createdLivenessSessionIds)
            {
                await client.DeleteLivenessSessionAsync(sessionId);
            }

            _createdLivenessSessionIds.Clear();
        }

        protected async Task<IEnumerable<string>> PrepareLivenessSession(int count, bool addToCreatedList = true)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return Enumerable.Empty<string>();
            }

            var client = CreateSessionClient(nonRecordingClient: true);
            var testRandom = new TestRandom(Mode);
            var result = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var createContent = new CreateLivenessSessionContent(LivenessOperationMode.Passive)
                {
                    DeviceCorrelationId = testRandom.NewGuid().ToString(),
                };

                var createResponse = await client.CreateLivenessSessionAsync(createContent);
                result.Add(createResponse.Value.SessionId);

                if (addToCreatedList)
                {
                    _createdLivenessSessionIds.Add(createResponse.Value.SessionId);
                }
            }

            return result;
        }

        [RecordedTest]
        public async Task TestCreateLivenessSession()
        {
            var deviceCorrelationId = new TestRandom(Mode).NewGuid().ToString();
            var client = CreateSessionClient();

            var createContent = new CreateLivenessSessionContent(LivenessOperationMode.Passive)
            {
                DeviceCorrelationId = deviceCorrelationId,
            };

            var createResponse = await client.CreateLivenessSessionAsync(createContent);
            var sessionId = createResponse.Value.SessionId;

            if (Mode != RecordedTestMode.Playback)
            {
                _createdLivenessSessionIds.Add(sessionId);
            }

            Assert.IsNotNull(sessionId);
            Assert.IsNotNull(createResponse.Value.AuthToken);

            var getResponse = await client.GetLivenessSessionResultAsync(sessionId);
            Assert.AreEqual(deviceCorrelationId, getResponse.Value.DeviceCorrelationId);
        }

        [RecordedTest]
        public async Task TestListLivenessSessions()
        {
            await PrepareLivenessSession(2);

            var client = CreateSessionClient();

            var listResponse = await client.GetLivenessSessionsAsync();
            var sessionList = listResponse.Value;
            Assert.GreaterOrEqual(sessionList.Count, 2);
            Assert.Greater(sessionList[1].Id, sessionList[0].Id);

            foreach (var session in sessionList)
            {
                Assert.IsNotNull(session.CreatedDateTime);
                Assert.IsNotNull(session.DeviceCorrelationId);
                Assert.IsTrue(session.AuthTokenTimeToLiveInSeconds >= 60);
                Assert.IsTrue(session.AuthTokenTimeToLiveInSeconds <= 86400);
            }
        }

        [PlaybackOnly("Requiring other components to send underlying liveness request.")]
        [TestCase("4a4c21a2-38b4-4765-a895-eaed10f77c11")]
        public async Task TestGetSessionResult(string sessionId)
        {
            var client = CreateSessionClient();
            var response = await client.GetLivenessSessionResultAsync(sessionId);
            var session = response.Value;

            Assert.AreEqual(sessionId, session.Id);
            Assert.IsNotNull(session.CreatedDateTime);
            Assert.IsNotNull(session.DeviceCorrelationId);
            Assert.IsTrue(session.AuthTokenTimeToLiveInSeconds >= 60);
            Assert.IsTrue(session.AuthTokenTimeToLiveInSeconds <= 86400);
            Assert.IsNotNull(session.SessionStartDateTime);
            Assert.IsNotNull(session.SessionExpired);
            Assert.AreEqual(FaceSessionStatus.ResultAvailable, session.Status);

            Assert.IsNotNull(session.Result.Id);
            Assert.AreEqual(session.Result.SessionId, sessionId);
            Assert.IsNotNull(session.Result.RequestId);
            Assert.IsNotNull(session.Result.ReceivedDateTime);
            Assert.IsNotNull(session.Result.Digest);

            Assert.IsNotNull(session.Result.Request.Url);
            Assert.IsNotNull(session.Result.Request.Method);
            Assert.IsNotNull(session.Result.Request.ContentLength);
            Assert.IsNotNull(session.Result.Request.ContentType);

            Assert.IsNotNull(session.Result.Response.StatusCode);
            Assert.IsNotNull(session.Result.Response.LatencyInMilliseconds);
            Assert.IsNotNull(session.Result.Response.Body.LivenessDecision);
            Assert.IsNotNull(session.Result.Response.Body.Target.FaceRectangle.Top);
            Assert.IsNotNull(session.Result.Response.Body.Target.FaceRectangle.Left);
            Assert.IsNotNull(session.Result.Response.Body.Target.FaceRectangle.Width);
            Assert.IsNotNull(session.Result.Response.Body.Target.FaceRectangle.Height);
            Assert.IsNotNull(session.Result.Response.Body.Target.FileName);
            Assert.IsNotNull(session.Result.Response.Body.Target.TimeOffsetWithinFile);
            Assert.IsNotNull(session.Result.Response.Body.Target.ImageType);
        }

        [PlaybackOnly("Requiring other components to send underlying liveness request.")]
        [TestCase("4a4c21a2-38b4-4765-a895-eaed10f77c11")]
        public async Task TestGetSessionAuditEntries(string sessionId)
        {
            var client = CreateSessionClient();
            var response = await client.GetLivenessSessionAuditEntriesAsync(sessionId);

            foreach (var auditEntry in response.Value)
            {
                Assert.IsNotNull(auditEntry.Id);
                Assert.AreEqual(sessionId, auditEntry.SessionId);
                Assert.IsNotNull(auditEntry.RequestId);
                Assert.IsNotNull(auditEntry.ReceivedDateTime);
                Assert.IsNotNull(auditEntry.Digest);

                Assert.IsNotNull(auditEntry.Request.Url);
                Assert.IsNotNull(auditEntry.Request.Method);
                Assert.IsNotNull(auditEntry.Request.ContentLength);
                Assert.IsNotNull(auditEntry.Request.ContentType);

                Assert.IsNotNull(auditEntry.Response.StatusCode);
                Assert.IsNotNull(auditEntry.Response.LatencyInMilliseconds);
                Assert.IsNotNull(auditEntry.Response.Body.LivenessDecision);
                Assert.IsNotNull(auditEntry.Response.Body.ModelVersionUsed);
                Assert.IsNotNull(auditEntry.Response.Body.Target.FaceRectangle.Top);
                Assert.IsNotNull(auditEntry.Response.Body.Target.FaceRectangle.Left);
                Assert.IsNotNull(auditEntry.Response.Body.Target.FaceRectangle.Width);
                Assert.IsNotNull(auditEntry.Response.Body.Target.FaceRectangle.Height);
                Assert.IsNotNull(auditEntry.Response.Body.Target.FileName);
                Assert.IsNotNull(auditEntry.Response.Body.Target.TimeOffsetWithinFile);
                Assert.IsNotNull(auditEntry.Response.Body.Target.ImageType);
            }
        }

        [RecordedTest]
        public async Task TestDeleteLivenessSessions()
        {
            var sessions = await PrepareLivenessSession(1, false);

            var client = CreateSessionClient();
            await client.DeleteLivenessSessionAsync(sessions.First());
        }
    }
}
