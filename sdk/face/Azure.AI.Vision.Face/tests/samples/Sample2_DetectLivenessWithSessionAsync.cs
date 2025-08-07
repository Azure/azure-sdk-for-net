// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Samples
{
    public partial class Sample4_DetectLivenessWithSession: FaceSamplesBase
    {
        [Test]
        [TestCase(true)] // Change deleteSession to false to keep the session and perform liveness detection with liveness SDK
        public async Task CreateDetectLivenessSessionAsync(bool deleteSession)
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:CreateLivenessSessionAsync
            var createContent = new CreateLivenessSessionContent(LivenessOperationMode.Passive) {
                SendResultsToClient = true,
                DeviceCorrelationId = Guid.NewGuid().ToString(),
            };

            var createResponse = await sessionClient.CreateLivenessSessionAsync(createContent);

            var sessionId = createResponse.Value.SessionId;
            Console.WriteLine($"Session created, SessionId: {sessionId}");
            Console.WriteLine($"AuthToken: {createResponse.Value.AuthToken}");
            #endregion

            if (deleteSession)
            {
                #region Snippet:DeleteLivenessSessionAsync
                await sessionClient.DeleteLivenessSessionAsync(sessionId);
                #endregion
            }
        }

        [Ignore("Enable this case when you have performed liveness operation with liveness SDK")]
        [TestCase("cc3fc6b7-33bd-4137-9e8d-eb83e150c525")] // Replace session id with your session which sent underlying liveness request with liveness SDK to get the result
        public async Task GetDetectLivenessSessionResultAsync(string sessionId)
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:GetLivenessSessionResultAsync
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

            #region Snippet:GetLivenessSessionAuditEntriesAsync
            var getAuditEntriesResponse = await sessionClient.GetLivenessSessionAuditEntriesAsync(sessionId);
            foreach (var auditEntry in getAuditEntriesResponse.Value)
            {
                WriteLivenessSessionAuditEntry(auditEntry);
            }
            #endregion
        }

        public async Task ListDetectLivenessSessionsAsync()
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:GetLivenessSessionsAsync
            var listResponse = await sessionClient.GetLivenessSessionsAsync();
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
