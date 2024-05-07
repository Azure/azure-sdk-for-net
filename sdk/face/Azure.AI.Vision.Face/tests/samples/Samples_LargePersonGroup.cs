// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Vision.Face.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Samples
{
    public partial class FaceSamples
    {
        [RecordedTest]
        public async Task Sample_VerifyAndIdentifyFromLargePersonGroup()
        {
            var administrationClient = CreateAdministrationClient();
            var groupId = "lpg_family1";

            await administrationClient.CreateLargePersonGroupAsync(groupId, "Family 1", userData: "A sweet family", recognitionModel: FaceRecognitionModel.Recognition04);

            var createPerson1Response = await administrationClient.CreateLargePersonGroupPersonAsync(groupId, "Bill", userData: "Dad");
            var dadPersonId = createPerson1Response.Value.PersonId;
            await administrationClient.AddLargePersonGroupPersonFaceFromUrlAsync(groupId, dadPersonId, new Uri(FaceTestConstant.UrlFamily1Dad1Image), userData: "Dad-1", detectionModel: FaceDetectionModel.Detection03);
            await administrationClient.AddLargePersonGroupPersonFaceFromUrlAsync(groupId, dadPersonId, new Uri(FaceTestConstant.UrlFamily1Dad2Image), userData: "Dad-2", detectionModel: FaceDetectionModel.Detection03);

            var createPerson2Response = await administrationClient.CreateLargePersonGroupPersonAsync(groupId, "Clare", userData: "Mom");
            var momPersonId = createPerson2Response.Value.PersonId;
            await administrationClient.AddLargePersonGroupPersonFaceFromUrlAsync(groupId, momPersonId, new Uri(FaceTestConstant.UrlFamily1Mom1Image), userData: "Mom-1", detectionModel: FaceDetectionModel.Detection03);
            await administrationClient.AddLargePersonGroupPersonFaceFromUrlAsync(groupId, momPersonId, new Uri(FaceTestConstant.UrlFamily1Mom2Image), userData: "Mom-2", detectionModel: FaceDetectionModel.Detection03);

            var createPerson3Response = await administrationClient.CreateLargePersonGroupPersonAsync(groupId, "Ron", userData: "Son");
            var sonPersonId = createPerson3Response.Value.PersonId;
            await administrationClient.AddLargePersonGroupPersonFaceFromUrlAsync(groupId, sonPersonId, new Uri(FaceTestConstant.UrlFamily1Son1Image), userData: "Son-1", detectionModel: FaceDetectionModel.Detection03);
            await administrationClient.AddLargePersonGroupPersonFaceFromUrlAsync(groupId, sonPersonId, new Uri(FaceTestConstant.UrlFamily1Son2Image), userData: "Son-2", detectionModel: FaceDetectionModel.Detection03);

            var operation = await administrationClient.TrainLargePersonGroupAsync(WaitUntil.Completed, groupId);
            await operation.WaitForCompletionResponseAsync();

            var faceClient = CreateClient();
            var detectResponse = await faceClient.DetectFromUrlAsync(new Uri(FaceTestConstant.UrlFamily1Dad3Image), FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
            var faceId = detectResponse.Value[0].FaceId.Value;

            var verifyDadResponse = await faceClient.VerifyFromLargePersonGroupAsync(faceId, groupId, dadPersonId);
            Console.WriteLine($"Is the detected face Bill? {verifyDadResponse.Value.IsIdentical} ({verifyDadResponse.Value.Confidence})");

            var verifyMomResponse = await faceClient.VerifyFromLargePersonGroupAsync(faceId, groupId, momPersonId);
            Console.WriteLine($"Is the detected face Clare? {verifyMomResponse.Value.IsIdentical} ({verifyMomResponse.Value.Confidence})");

            var identifyResponse = await faceClient.IdentifyFromLargePersonGroupAsync(new[] { faceId }, groupId);
            foreach (var candidate in identifyResponse.Value[0].Candidates)
            {
                var person = await administrationClient.GetLargePersonGroupPersonAsync(groupId, candidate.PersonId);
                Console.WriteLine($"The detected face belongs to {person.Value.Name} ({candidate.Confidence})");
            }

            await administrationClient.DeleteLargePersonGroupAsync(groupId);
        }
    }
}
