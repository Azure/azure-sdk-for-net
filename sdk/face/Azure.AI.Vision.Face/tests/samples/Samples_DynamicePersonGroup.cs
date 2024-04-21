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
        public async Task Sample_VerifyFromDynamicPersonGroup()
        {
            var administrationClient = CreateAdministrationClient();

            var createPerson1Operation = await administrationClient.CreatePersonAsync(WaitUntil.Started, "Bill", userData: "Family1,singing");
            var personIdBill = createPerson1Operation.Value.PersonId;

            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdBill,
                FaceRecognitionModel.Recognition04,
                new Uri("https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/Face/images/Family1-Dad1.jpg"),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0001");

            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdBill,
                FaceRecognitionModel.Recognition04,
                new Uri("https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/Face/images/Family1-Dad2.jpg"),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0002");

            var createPerson2Operation = await administrationClient.CreatePersonAsync(WaitUntil.Started, "Ron", userData: "Family1");
            var personIdRon = createPerson2Operation.Value.PersonId;

            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdRon,
                FaceRecognitionModel.Recognition04,
                new Uri("https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/Face/images/Family1-Son1.jpg"),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0001");

            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                personIdRon,
                FaceRecognitionModel.Recognition04,
                new Uri("https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/Face/images/Family1-Son2.jpg"),
                detectionModel: FaceDetectionModel.Detection03,
                userData: "0002");

            var faceClient = CreateClient();
            var detectResponse = await faceClient.DetectFromUrlAsync(
                new Uri("https://raw.githubusercontent.com/Azure-Samples/cognitive-services-sample-data-files/master/Face/images/Family1-Dad3.jpg"),
                recognitionModel: FaceRecognitionModel.Recognition04,
                detectionModel: FaceDetectionModel.Detection03,
                returnFaceId: true);
            var targetFaceId = detectResponse.Value[0].FaceId.Value;

            var verifyBillResponse = await faceClient.VerifyFromPersonDirectoryAsync(targetFaceId, personIdBill);
            Console.WriteLine($"Face verification result for person Bill. IsIdentical: {verifyBillResponse.Value.IsIdentical}, Confidence: {verifyBillResponse.Value.Confidence}");

            var verifyRonResponse = await faceClient.VerifyFromPersonDirectoryAsync(targetFaceId, personIdRon);
            Console.WriteLine($"Face verification result for person Ron. IsIdentical: {verifyRonResponse.Value.IsIdentical}, Confidence: {verifyRonResponse.Value.Confidence}");
        }
    }
}
