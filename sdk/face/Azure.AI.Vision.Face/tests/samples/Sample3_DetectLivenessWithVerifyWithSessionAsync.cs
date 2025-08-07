// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Vision.Face.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Samples
{
    public partial class Sample5_DetectLivenessWithVerifyWithSession : FaceSamplesBase
    {
        [Test]
        [TestCase(true)] // Change deleteSession to false to keep the session and perform liveness detection with liveness SDK
        public async Task CreateDetectLivenessWithVerifySessionAsync(bool deleteSession)
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:CreateLivenessWithVerifySessionAsync
            var parameters = new CreateLivenessWithVerifySessionContent(LivenessOperationMode.Passive) {
                SendResultsToClient = true,
                DeviceCorrelationId = Guid.NewGuid().ToString(),
            };

            using var fileStream = new FileStream(FaceTestConstant.LocalSampleImage, FileMode.Open, FileAccess.Read);

            var createResponse = await sessionClient.CreateLivenessWithVerifySessionAsync(parameters, fileStream);

            var sessionId = createResponse.Value.SessionId;
            Console.WriteLine($"Session created, SessionId: {sessionId}");
            Console.WriteLine($"AuthToken: {createResponse.Value.AuthToken}");
            Console.WriteLine($"VerifyImage.FaceRectangle: {createResponse.Value.VerifyImage.FaceRectangle.Top}, {createResponse.Value.VerifyImage.FaceRectangle.Left}, {createResponse.Value.VerifyImage.FaceRectangle.Width}, {createResponse.Value.VerifyImage.FaceRectangle.Height}");
            Console.WriteLine($"VerifyImage.QualityForRecognition: {createResponse.Value.VerifyImage.QualityForRecognition}");
            #endregion

            if (deleteSession)
            {
                #region Snippet:DeleteLivenessWithVerifySessionAsync
                await sessionClient.DeleteLivenessWithVerifySessionAsync(sessionId);
                #endregion
            }
        }

        [Ignore("Enable this case when you have performed liveness operation with liveness SDK")]
        [TestCase("cc3fc6b7-33bd-4137-9e8d-eb83e150c525")] // Replace session id with your session which sent underlying liveness request with liveness SDK to get the result
        public async Task GetDetectLivenessWithVerifySessionResultAsync(string sessionId)
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:GetLivenessWithVerifySessionResultAsync
            var getResultResponse = await sessionClient.GetLivenessWithVerifySessionResultAsync(sessionId);
            var sessionResult = getResultResponse.Value;
            Console.WriteLine($"Id: {sessionResult.Id}");
            Console.WriteLine($"CreatedDateTime: {sessionResult.CreatedDateTime}");
            Console.WriteLine($"SessionExpired: {sessionResult.SessionExpired}");
            Console.WriteLine($"DeviceCorrelationId: {sessionResult.DeviceCorrelationId}");
            Console.WriteLine($"AuthTokenTimeToLiveInSeconds: {sessionResult.AuthTokenTimeToLiveInSeconds}");
            Console.WriteLine($"Status: {sessionResult.Status}");
            Console.WriteLine($"SessionStartDateTime: {sessionResult.SessionStartDateTime}");
            if (sessionResult.Result != null) {
                WriteLivenessWithVerifySessionAuditEntry(sessionResult.Result);
            }
            #endregion

            #region Snippet:GetLivenessWithVerifySessionAuditEntriesAsync
            var getAuditEntriesResponse = await sessionClient.GetLivenessWithVerifySessionAuditEntriesAsync(sessionId);
            foreach (var auditEntry in getAuditEntriesResponse.Value)
            {
                WriteLivenessWithVerifySessionAuditEntry(auditEntry);
            }
            #endregion
        }

        public async Task ListDetectLivenessWithVerifySessionsAsync()
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:GetLivenessWithVerifySessionsAsync
            var listResponse = await sessionClient.GetLivenessWithVerifySessionsAsync();
            foreach (var session in listResponse.Value)
            {
                Console.WriteLine($"SessionId: {session.Id}");
                Console.WriteLine($"CreatedDateTime: {session.CreatedDateTime}");
                Console.WriteLine($"SessionExpired: {session.SessionExpired}");
                Console.WriteLine($"DeviceCorrelationId: {session.DeviceCorrelationId}");
                Console.WriteLine($"AuthTokenTimeToLiveInSeconds: {session.AuthTokenTimeToLiveInSeconds}");
                Console.WriteLine($"SessionStartDateTime: {session.SessionStartDateTime}");
            }
            #endregion
        }
    }
}
