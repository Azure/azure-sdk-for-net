// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Samples
{
    public partial class Sample4_DetectLivenessWithSession: FaceSamplesBase
    {
        [Test]
        [TestCase(true)] // Change deleteSession to false to keep the session and perform liveness detection with liveness SDK
        public void CreateDetectLivenessSession(bool deleteSession)
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:CreateLivenessSession
            var createContent = new CreateLivenessSessionContent(LivenessOperationMode.Passive) {
                DeviceCorrelationId = Guid.NewGuid().ToString(),
                UserCorrelationId = Guid.NewGuid().ToString(),
            };

            var createResponse = sessionClient.CreateLivenessSession(createContent);

            var sessionId = createResponse.Value.SessionId;
            Console.WriteLine($"Session created, SessionId: {sessionId}");
            Console.WriteLine($"AuthToken: {createResponse.Value.AuthToken}");
            #endregion

            if (deleteSession)
            {
                #region Snippet:DeleteLivenessSession
                sessionClient.DeleteLivenessSession(sessionId);
                #endregion
            }
        }

        [Ignore("Enable this case when you have performed liveness operation with liveness SDK")]
        [TestCase("cc3fc6b7-33bd-4137-9e8d-eb83e150c525")] // Replace session id with your session which sent underlying liveness request with liveness SDK to get the result
        public void GetDetectLivenessSessionResult(string sessionId)
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:GetLivenessSessionResult
            var getResultResponse = sessionClient.GetLivenessSessionResult(sessionId);
            var sessionResult = getResultResponse.Value;
            Console.WriteLine($"Id: {sessionResult.SessionId}");
            Console.WriteLine($"Status: {sessionResult.Status}");
            if (sessionResult.Results != null)
            {
                WriteLivenessSessionResults(sessionResult.Results);
            }
            #endregion
        }

        #region Snippet:WriteLivenessSessionResults
        public void WriteLivenessSessionResults(LivenessSessionResults results)
        {
            if (results.Attempts == null || results.Attempts.Count == 0)
            {
                Console.WriteLine("No attempts found in the session results.");
                return;
            }

            var firstAttempt = results.Attempts[0];
            Console.WriteLine($"Attempt ID: {firstAttempt.AttemptId}");
            Console.WriteLine($"Attempt Status: {firstAttempt.AttemptStatus}");

            if (firstAttempt.Result != null)
            {
                var result = firstAttempt.Result;
                Console.WriteLine($"    Liveness Decision: {result.LivenessDecision}");
                Console.WriteLine($"    Digest: {result.Digest}");
                Console.WriteLine($"    Session Image ID: {result.SessionImageId}");

                if (result.Targets?.Color?.FaceRectangle != null)
                {
                    var faceRect = result.Targets.Color.FaceRectangle;
                    Console.WriteLine($"    Face Rectangle: Top={faceRect.Top}, Left={faceRect.Left}, Width={faceRect.Width}, Height={faceRect.Height}");
                }
            }

            if (firstAttempt.ClientInformation != null && firstAttempt.ClientInformation.Count > 0)
            {
                Console.WriteLine($"    Client Information Count: {firstAttempt.ClientInformation.Count}");
            }
        }
        #endregion
    }
}
