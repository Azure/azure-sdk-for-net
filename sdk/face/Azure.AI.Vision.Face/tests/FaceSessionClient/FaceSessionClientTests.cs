// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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
        private const string UserCorrelationId = "eab3f6b7-baab-4a72-abee-d76eba620f6c";
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

        protected void AssertLivenessWithVerifySessionResults(LivenessWithVerifySessionResults results, string sessionId)
        {
            // Assert that we have attempts
            Assert.IsNotNull(results.Attempts);
            Assert.IsTrue(results.Attempts.Count > 0, "Expected at least one attempt in the session results");

            // Get the first attempt
            var firstAttempt = results.Attempts[0];
            Assert.IsNotNull(firstAttempt);
            Assert.IsNotNull(firstAttempt.AttemptId);
            Assert.IsNotNull(firstAttempt.AttemptStatus);

            Assert.IsNotNull(firstAttempt.Result, "Expected result to be present in the first attempt");
            var result = firstAttempt.Result;

            Assert.IsNotNull(result.Digest);
            Assert.IsNotNull(result.LivenessDecision);
            Assert.IsNotNull(result.SessionImageId);

            Assert.IsNotNull(result.Targets);
            Assert.IsNotNull(result.Targets.Color);
            Assert.IsNotNull(result.Targets.Color.FaceRectangle);
            var faceRect = result.Targets.Color.FaceRectangle;
            Assert.IsNotNull(faceRect.Top);
            Assert.IsNotNull(faceRect.Left);
            Assert.IsNotNull(faceRect.Width);
            Assert.IsNotNull(faceRect.Height);

            Assert.IsNotNull(result.VerifyResult, "Expected verify result to be present");
            Assert.IsNotNull(result.VerifyResult.IsIdentical);
            Assert.IsNotNull(result.VerifyResult.MatchConfidence);

            Assert.IsNotNull(results.VerifyReferences);
            Assert.IsTrue(results.VerifyReferences.Count > 0, "Expected at least one verify reference");
            var verifyRef = results.VerifyReferences[0];
            Assert.IsNotNull(verifyRef.FaceRectangle);
            Assert.IsNotNull(verifyRef.FaceRectangle.Top);
            Assert.IsNotNull(verifyRef.FaceRectangle.Left);
            Assert.IsNotNull(verifyRef.FaceRectangle.Width);
            Assert.IsNotNull(verifyRef.FaceRectangle.Height);
            Assert.IsNotNull(verifyRef.QualityForRecognition);
        }

        #region LivenessSession
        protected async Task<LivenessSession> CreateLivenessSession(bool nonRecordingClient = false)
        {
            var client = CreateSessionClient(nonRecordingClient: nonRecordingClient);

            var createContent = new CreateLivenessSessionContent(LivenessOperationMode.Passive)
            {
                DeviceCorrelationId = DeviceCorrelationId,
                UserCorrelationId = UserCorrelationId,
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

            Assert.IsNotNull(createResult.SessionId);
            Assert.IsNotNull(createResult.AuthToken);

            var getResponse = await client.GetLivenessSessionResultAsync(createResult.SessionId);
            Assert.AreEqual(createResult.SessionId, getResponse.Value.SessionId);
        }

        [RecordedTest]
        public async Task TestGetSessionResult()
        {
            var client = CreateSessionClient();
            var createResult = await CreateLivenessSession();
            var response = await client.GetLivenessSessionResultAsync(createResult.SessionId);
            var session = response.Value;

            Assert.AreEqual(createResult.SessionId, session.SessionId);
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
        protected async Task<LivenessWithVerifySession> CreateLivenessWithVerifySession(bool nonRecordingClient = false)
        {
            var client = CreateSessionClient(nonRecordingClient: nonRecordingClient);
            using var fileStream = new FileStream(FaceTestConstant.LocalSampleImage, FileMode.Open, FileAccess.Read);
            var createContent = new CreateLivenessWithVerifySessionContent(LivenessOperationMode.Passive, fileStream)
            {
                DeviceCorrelationId = DeviceCorrelationId,
            };

            Response<LivenessWithVerifySession> createResponse = null;
            createResponse = await client.CreateLivenessWithVerifySessionAsync(createContent);

            _createdSessions.Add((SessionType.LivenessWithVerify, createResponse.Value.SessionId));

            return createResponse.Value;
        }

        protected void AssertVerifyResult(LivenessWithVerifyOutputs verifyResult)
        {
            Assert.IsNotNull(verifyResult.IsIdentical);
            Assert.IsNotNull(verifyResult.MatchConfidence);
        }

        [LiveOnly] // Unable to playback multipart request.
        [AsyncOnly] // Sync MFD request will throw in debug build
        [RecordedTest]
        [Ignore("API is returning a bad request for user correlation id missing. Requires investigation https://github.com/Azure/azure-sdk-for-net/issues/53289.")]
        public async Task TestCreateLivenessWithVerifySession()
        {
            var client = CreateSessionClient();

            var createResult = await CreateLivenessWithVerifySession();

            Assert.IsNotNull(createResult.SessionId);
            Assert.IsNotNull(createResult.AuthToken);

            var getResponse = await client.GetLivenessWithVerifySessionResultAsync(createResult.SessionId);
            Assert.IsNotNull(getResponse.Value.ExpectedClientIpAddress);
        }

        [Ignore("API is returning a bad request for user correlation id missing. Requires investigation https://github.com/Azure/azure-sdk-for-net/issues/53289.")]
        [PlaybackOnly("Requiring other components to send underlying liveness request.")]
        [TestCase("56d976a9-130a-44e2-bb25-e84410f05b05")]
        public async Task TestGetLivenessWithVerifySessionResult(string sessionId)
        {
            var client = CreateSessionClient();
            var response = await client.GetLivenessWithVerifySessionResultAsync(sessionId);
            var session = response.Value;

            Assert.AreEqual(sessionId, session.SessionId);
            Assert.AreEqual(OperationState.Succeeded, session.Status);

            AssertLivenessWithVerifySessionResults(session.Results, sessionId);
            var attempts = session.Results.Attempts;
            Assert.IsTrue(attempts.Count > 0);
            var verifyResult = attempts[0].Result.VerifyResult;
            Assert.IsNotNull(verifyResult);
            AssertVerifyResult(verifyResult);
        }

        [RecordedTest]
        [Ignore("API is returning a bad request for missing user correlation id which is not defined in payload. Requires investigation https://github.com/Azure/azure-sdk-for-net/issues/53289.")]
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
