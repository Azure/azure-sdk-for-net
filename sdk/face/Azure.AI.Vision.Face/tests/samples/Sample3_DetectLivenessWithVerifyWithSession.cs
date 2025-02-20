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
        [Ignore("Sync MFD request will throw in debug build")]
        [Test]
        [TestCase(true)] // Change deleteSession to false to keep the session and perform liveness detection with liveness SDK
        public void CreateDetectLivenessWithVerifySession(bool deleteSession)
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:CreateLivenessWithVerifySession
            var parameters = new CreateLivenessWithVerifySessionContent(LivenessOperationMode.Passive) {
                SendResultsToClient = true,
                DeviceCorrelationId = Guid.NewGuid().ToString(),
            };

            using var fileStream = new FileStream(FaceTestConstant.LocalSampleImage, FileMode.Open, FileAccess.Read);

            var createResponse = sessionClient.CreateLivenessWithVerifySession(parameters, fileStream);

            var sessionId = createResponse.Value.SessionId;
            Console.WriteLine($"Session created, SessionId: {sessionId}");
            Console.WriteLine($"AuthToken: {createResponse.Value.AuthToken}");
            Console.WriteLine($"VerifyImage.FaceRectangle: {createResponse.Value.VerifyImage.FaceRectangle.Top}, {createResponse.Value.VerifyImage.FaceRectangle.Left}, {createResponse.Value.VerifyImage.FaceRectangle.Width}, {createResponse.Value.VerifyImage.FaceRectangle.Height}");
            Console.WriteLine($"VerifyImage.QualityForRecognition: {createResponse.Value.VerifyImage.QualityForRecognition}");
            #endregion

            if (deleteSession)
            {
                #region Snippet:DeleteLivenessWithVerifySession
                sessionClient.DeleteLivenessWithVerifySession(sessionId);
                #endregion
            }
        }

        [Ignore("Enable this case when you have performed liveness operation with liveness SDK")]
        [TestCase("cc3fc6b7-33bd-4137-9e8d-eb83e150c525")] // Replace session id with your session which sent underlying liveness request with liveness SDK to get the result
        public void GetDetectLivenessWithVerifySessionResult(string sessionId)
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:GetLivenessWithVerifySessionResult
            var getResultResponse = sessionClient.GetLivenessWithVerifySessionResult(sessionId);
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

            #region Snippet:GetLivenessWithVerifySessionAuditEntries
            var getAuditEntriesResponse = sessionClient.GetLivenessWithVerifySessionAuditEntries(sessionId);
            foreach (var auditEntry in getAuditEntriesResponse.Value)
            {
                WriteLivenessWithVerifySessionAuditEntry(auditEntry);
            }
            #endregion
        }

        public void ListDetectLivenessWithVerifySessions()
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:GetLivenessWithVerifySessions
            var listResponse = sessionClient.GetLivenessWithVerifySessions();
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

        #region Snippet:WriteLivenessWithVerifySessionAuditEntry
        public void WriteLivenessWithVerifySessionAuditEntry(LivenessSessionAuditEntry auditEntry)
        {
            Console.WriteLine($"Id: {auditEntry.Id}");
            Console.WriteLine($"SessionId: {auditEntry.SessionId}");
            Console.WriteLine($"RequestId: {auditEntry.RequestId}");
            Console.WriteLine($"ClientRequestId: {auditEntry.ClientRequestId}");
            Console.WriteLine($"ReceivedDateTime: {auditEntry.ReceivedDateTime}");
            Console.WriteLine($"Digest: {auditEntry.Digest}");

            Console.WriteLine($"    Request Url: {auditEntry.Request.Url}");
            Console.WriteLine($"    Request Method: {auditEntry.Request.Method}");
            Console.WriteLine($"    Request ContentLength: {auditEntry.Request.ContentLength}");
            Console.WriteLine($"    Request ContentType: {auditEntry.Request.ContentType}");
            Console.WriteLine($"    Request UserAgent: {auditEntry.Request.UserAgent}");

            Console.WriteLine($"    Response StatusCode: {auditEntry.Response.StatusCode}");
            Console.WriteLine($"    Response LatencyInMilliseconds: {auditEntry.Response.LatencyInMilliseconds}");
            Console.WriteLine($"        Response Body LivenessDecision: {auditEntry.Response.Body.LivenessDecision}");
            Console.WriteLine($"        Response Body ModelVersionUsed: {auditEntry.Response.Body.ModelVersionUsed}");
            Console.WriteLine($"        Response Body Target FaceRectangle: {auditEntry.Response.Body.Target.FaceRectangle.Top}, {auditEntry.Response.Body.Target.FaceRectangle.Left}, {auditEntry.Response.Body.Target.FaceRectangle.Width}, {auditEntry.Response.Body.Target.FaceRectangle.Height}");
            Console.WriteLine($"        Response Body Target FileName: {auditEntry.Response.Body.Target.FileName}");
            Console.WriteLine($"        Response Body Target TimeOffsetWithinFile: {auditEntry.Response.Body.Target.TimeOffsetWithinFile}");
            Console.WriteLine($"        Response Body Target FaceImageType: {auditEntry.Response.Body.Target.ImageType}");

            Console.WriteLine($"        Response Body VerifyResult IsIdentical: {auditEntry.Response.Body.VerifyResult.IsIdentical}");
            Console.WriteLine($"        Response Body VerifyResult MatchConfidence: {auditEntry.Response.Body.VerifyResult.MatchConfidence}");
            Console.WriteLine($"        Response Body VerifyResult VerifyImage.FaceRectangle: {auditEntry.Response.Body.VerifyResult.VerifyImage.FaceRectangle.Top}, {auditEntry.Response.Body.VerifyResult.VerifyImage.FaceRectangle.Left}, {auditEntry.Response.Body.VerifyResult.VerifyImage.FaceRectangle.Width}, {auditEntry.Response.Body.VerifyResult.VerifyImage.FaceRectangle.Height}");
            Console.WriteLine($"        Response Body VerifyResult VerifyImage.QualityForRecognition: {auditEntry.Response.Body.VerifyResult.VerifyImage.QualityForRecognition}");
        }
        #endregion
    }
}
