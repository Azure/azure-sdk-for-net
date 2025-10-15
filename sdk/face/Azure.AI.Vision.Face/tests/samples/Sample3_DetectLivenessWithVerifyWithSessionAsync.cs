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
        [Ignore("API requires user correlation id - requires investigation. https://github.com/Azure/azure-sdk-for-net/issues/53289")]
        [Test]
        [TestCase(true)] // Change deleteSession to false to keep the session and perform liveness detection with liveness SDK
        public async Task CreateDetectLivenessWithVerifySessionAsync(bool deleteSession)
        {
            var sessionClient = CreateSessionClient();

            #region Snippet:CreateLivenessWithVerifySessionAsync
            using var fileStream = new FileStream(FaceTestConstant.LocalSampleImage, FileMode.Open, FileAccess.Read);
            var parameters = new CreateLivenessWithVerifySessionContent(LivenessOperationMode.Passive, fileStream)
            {
                DeviceCorrelationId = Guid.NewGuid().ToString(),
            };

            var createResponse = await sessionClient.CreateLivenessWithVerifySessionAsync(parameters);

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
            Console.WriteLine($"Id: {sessionResult.SessionId}");
            Console.WriteLine($"Status: {sessionResult.Status}");
            if (sessionResult.Results != null)
            {
                WriteLivenessWithVerifySessionResults(sessionResult.Results);
            }
            #endregion
        }
    }
}
