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
        public async Task Sample_VerifyFromPersonDirectory()
        {
            var administrationClient = CreateAdministrationClient();

            var createPerson1Operation = await administrationClient.CreatePersonAsync(WaitUntil.Started, "Bill", userData: "Family1,singing");
            var personIdBill = createPerson1Operation.Value.PersonId;

            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdBill,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily1Dad1Image),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0001");

            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdBill,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily1Dad2Image),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0002");

            var createPerson2Operation = await administrationClient.CreatePersonAsync(WaitUntil.Started, "Ron", userData: "Family1");
            var personIdRon = createPerson2Operation.Value.PersonId;

            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdRon,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily1Son1Image),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0001");

            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdRon,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily1Son2Image),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0002");

            var faceClient = CreateClient();
            var detectResponse = await faceClient.DetectFromUrlAsync(
                new Uri(FaceTestConstant.UrlFamily1Dad3Image),
                recognitionModel: FaceRecognitionModel.Recognition04,
                detectionModel: FaceDetectionModel.Detection03,
                returnFaceId: true);
            var targetFaceId = detectResponse.Value[0].FaceId.Value;

            var verifyBillResponse = await faceClient.VerifyFromPersonDirectoryAsync(targetFaceId, personIdBill);
            Console.WriteLine($"Face verification result for person Bill. IsIdentical: {verifyBillResponse.Value.IsIdentical}, Confidence: {verifyBillResponse.Value.Confidence}");

            var verifyRonResponse = await faceClient.VerifyFromPersonDirectoryAsync(targetFaceId, personIdRon);
            Console.WriteLine($"Face verification result for person Ron. IsIdentical: {verifyRonResponse.Value.IsIdentical}, Confidence: {verifyRonResponse.Value.Confidence}");

            await administrationClient.DeletePersonAsync(WaitUntil.Started, personIdBill);
            await administrationClient.DeletePersonAsync(WaitUntil.Started, personIdRon);
        }

        [RecordedTest]
        public async Task Sample_IdentifyFromPerson()
        {
            var administrationClient = CreateAdministrationClient();

            var createPerson1Operation = await administrationClient.CreatePersonAsync(WaitUntil.Started, "Ron", userData: "Family1");
            var personIdRon = createPerson1Operation.Value.PersonId;
            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdRon,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily1Son1Image),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0001");
            var person1LastAddFaceOperation = await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdRon,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily1Son2Image),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0002");

            var createPerson2Operation = await administrationClient.CreatePersonAsync(WaitUntil.Started, "Gill", userData: "Family1");
            var personIdGill = createPerson2Operation.Value.PersonId;
            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdGill,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily1Daughter1Image),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0001");
            var person2LastAddFaceOperation = await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdGill,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily1Daughter2Image),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0002");

            var createPerson3Operation = await administrationClient.CreatePersonAsync(WaitUntil.Started, "Anna", userData: "Family2,singing");
            var personIdAnna = createPerson3Operation.Value.PersonId;
            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdAnna,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily2Lady1Image),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0001");
            var person3LastAddFaceOperation = await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdAnna,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily2Lady2Image),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0002");

            await Task.WhenAll(
                createPerson1Operation.WaitForCompletionAsync().AsTask(),
                createPerson2Operation.WaitForCompletionAsync().AsTask(),
                createPerson3Operation.WaitForCompletionAsync().AsTask(),
                person1LastAddFaceOperation.WaitForCompletionAsync().AsTask(),
                person2LastAddFaceOperation.WaitForCompletionAsync().AsTask(),
                person3LastAddFaceOperation.WaitForCompletionAsync().AsTask());

            var faceClient = CreateClient();
            var detectResponse = await faceClient.DetectFromUrlAsync(
                new Uri(FaceTestConstant.UrlFamily1Daughter3Image),
                recognitionModel: FaceRecognitionModel.Recognition04,
                detectionModel: FaceDetectionModel.Detection03,
                returnFaceId: true);
            var targetFaceId = detectResponse.Value[0].FaceId.Value;

            var identifyPersonResponse = await faceClient.IdentifyFromPersonDirectoryAsync(new[] {targetFaceId}, new[] { personIdRon, personIdGill, personIdAnna });
            foreach (var facesIdentifyResult in identifyPersonResponse.Value)
            {
                Console.WriteLine($"For face {facesIdentifyResult.FaceId}");
                foreach (var candidate in facesIdentifyResult.Candidates)
                {
                    Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
                }
            }
        }
    }
}
