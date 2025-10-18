// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
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
                DeviceCorrelationId = Guid.NewGuid().ToString(),
                UserCorrelationId = Guid.NewGuid().ToString(),
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
            Console.WriteLine($"Id: {sessionResult.SessionId}");
            Console.WriteLine($"Status: {sessionResult.Status}");
            if (sessionResult.Results != null)
            {
                WriteLivenessSessionResults(sessionResult.Results);
            }
            #endregion
        }
    }
}
