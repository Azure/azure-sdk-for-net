// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.AI.Vision.Face.Tests;
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
            using var fileStream = new FileStream(FaceTestConstant.LocalSampleImage, FileMode.Open, FileAccess.Read);
            var parameters = new CreateLivenessWithVerifySessionContent(LivenessOperationMode.Passive, fileStream)
            {
                DeviceCorrelationId = Guid.NewGuid().ToString(),
            };

            var createResponse = sessionClient.CreateLivenessWithVerifySession(parameters);

            var sessionId = createResponse.Value.SessionId;
            Console.WriteLine($"Session created, SessionId: {sessionId}");
            Console.WriteLine($"AuthToken: {createResponse.Value.AuthToken}");
            var results = createResponse.Value.Results;
            if (results.VerifyReferences.Count > 0)
            {
                var verifyReference = results.VerifyReferences[0];
                Console.WriteLine($"VerifyImage.FaceRectangle: {verifyReference.FaceRectangle.Top}, {verifyReference.FaceRectangle.Left}, {verifyReference.FaceRectangle.Width}, {verifyReference.FaceRectangle.Height}");
                Console.WriteLine($"VerifyImage.QualityForRecognition: {verifyReference.QualityForRecognition}");
            }
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
            Console.WriteLine($"Id: {sessionResult.SessionId}");
            Console.WriteLine($"Status: {sessionResult.Status}");
            if (sessionResult.Results != null)
            {
                WriteLivenessWithVerifySessionResults(sessionResult.Results);
            }
            #endregion
        }

        #region Snippet:WriteLivenessWithVerifySessionResults
        public void WriteLivenessWithVerifySessionResults(LivenessWithVerifySessionResults results)
        {
            if (results.Attempts?.Count == 0)
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
                    Console.WriteLine($"    Target Face Rectangle: Top={faceRect.Top}, Left={faceRect.Left}, Width={faceRect.Width}, Height={faceRect.Height}");
                }

                if (result.VerifyResult != null)
                {
                    Console.WriteLine($"    Verify Result IsIdentical: {result.VerifyResult.IsIdentical}");
                    Console.WriteLine($"    Verify Result MatchConfidence: {result.VerifyResult.MatchConfidence}");
                }

                Console.WriteLine($"    Verify Image Hash: {result.VerifyImageHash}");
            }

            if (results.VerifyReferences != null && results.VerifyReferences.Count > 0)
            {
                var verifyRef = results.VerifyReferences[0];
                if (verifyRef.FaceRectangle != null)
                {
                    Console.WriteLine($"    Verify Reference Face Rectangle: Top={verifyRef.FaceRectangle.Top}, Left={verifyRef.FaceRectangle.Left}, Width={verifyRef.FaceRectangle.Width}, Height={verifyRef.FaceRectangle.Height}");
                }
                Console.WriteLine($"    Verify Reference Quality For Recognition: {verifyRef.QualityForRecognition}");
            }

            if (firstAttempt.ClientInformation != null && firstAttempt.ClientInformation.Count > 0)
            {
                Console.WriteLine($"    Client Information Count: {firstAttempt.ClientInformation.Count}");
            }
        }
        #endregion
    }
}
