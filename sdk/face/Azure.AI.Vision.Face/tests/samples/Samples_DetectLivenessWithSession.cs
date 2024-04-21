// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Samples
{
    public partial class FaceSamples
    {
        [RecordedTest]
        [TestCase("", true)]
        //[TestCase("", false)]
        //[TestCase("cc3fc6b7-33bd-4137-9e8d-eb83e150c525", false)] // Replace session id with your session which sent underlying liveness request with
        public async Task SessionSample_DetectLivenessSession(string sessionId, bool deleteSession)
        {
            var sessionClient = CreateSessionClient();

            if (string.IsNullOrEmpty(sessionId))
            {
                #region Snippet:CreateLivenessSession
                var createContent = new CreateLivenessSessionContent(LivenessOperationMode.Passive) {
                    SendResultsToClient = true,
                    DeviceCorrelationId = Guid.NewGuid().ToString(),
                };

                var createResponse = await sessionClient.CreateLivenessSessionAsync(createContent);

                sessionId = createResponse.Value.SessionId;
                Console.WriteLine($"Session created, SessionId: {sessionId}");
                Console.WriteLine($"AuthToken: {createResponse.Value.AuthToken}");
                #endregion
            }

            #region Snippet:GetLivenessSessionResult
            var getResultResponse = await sessionClient.GetLivenessSessionResultAsync(sessionId);
            var sessionResult = getResultResponse.Value;
            Console.WriteLine($"Id: {sessionResult.Id}");
            Console.WriteLine($"CreatedDateTime: {sessionResult.CreatedDateTime}");
            Console.WriteLine($"SessionExpired: {sessionResult.SessionExpired}");
            Console.WriteLine($"DeviceCorrelationId: {sessionResult.DeviceCorrelationId}");
            Console.WriteLine($"AuthTokenTimeToLiveInSeconds: {sessionResult.AuthTokenTimeToLiveInSeconds}");
            Console.WriteLine($"Status: {sessionResult.Status}");
            Console.WriteLine($"SessionStartDateTime: {sessionResult.SessionStartDateTime}");
            if (sessionResult.Result != null) {
                WriteLivenessSessionAuditEntry(sessionResult.Result);
            }
            #endregion

            #region Snippet:GetLivenessSessionAuditEntries
            var getAuditEntriesResponse = await sessionClient.GetLivenessSessionAuditEntriesAsync(sessionId);
            foreach (var auditEntry in getAuditEntriesResponse.Value)
            {
                WriteLivenessSessionAuditEntry(auditEntry);
            }
            #endregion

            if (deleteSession)
            {
                #region Snippet:DeleteLivenessSession
                await sessionClient.DeleteLivenessSessionAsync(sessionId);
                #endregion
            }
        }

        #region Snippet:WriteLivenessSessionAuditEntry
        public void WriteLivenessSessionAuditEntry(LivenessSessionAuditEntry auditEntry)
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
        }
        #endregion
    }
}
