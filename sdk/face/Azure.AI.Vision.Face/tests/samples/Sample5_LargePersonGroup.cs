// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Vision.Face.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Samples
{
    public partial class Sample5_LargePersonGroup : FaceSamplesBase
    {
        [Test]
        public void VerifyAndIdentifyFromLargePersonGroup()
        {
            var groupClient = CreateLargePersonGroupClient();
            #region Snippet:VerifyAndIdentifyFromLargePersonGroup_CreateLargePersonGroup
            var groupId = "lpg_family1";

            groupClient.Create(groupId, "Family 1", userData: "A sweet family", recognitionModel: FaceRecognitionModel.Recognition04);
            #endregion

            #region Snippet:VerifyAndIdentifyFromLargePersonGroup_CreatePersonAndAddFaces
            var persons = new[]
            {
                new { Name = "Bill", UserData = "Dad", ImageUrls = new[] { FaceTestConstant.UrlFamily1Dad1Image, FaceTestConstant.UrlFamily1Dad2Image } },
                new { Name = "Clare", UserData = "Mom", ImageUrls = new[] { FaceTestConstant.UrlFamily1Mom1Image, FaceTestConstant.UrlFamily1Mom2Image } },
                new { Name = "Ron", UserData = "Son", ImageUrls = new[] { FaceTestConstant.UrlFamily1Son1Image, FaceTestConstant.UrlFamily1Son2Image } }
            };
            var personIds = new Dictionary<string, Guid>();

            foreach (var person in persons)
            {
                var createPersonResponse = groupClient.CreatePerson(groupId, person.Name, userData: person.UserData);
                var personId = createPersonResponse.Value.PersonId;
                personIds.Add(person.Name, personId);

                foreach (var imageUrl in person.ImageUrls)
                {
                    groupClient.AddFace(groupId, personId, new Uri(imageUrl), userData: $"{person.UserData}-{imageUrl}", detectionModel: FaceDetectionModel.Detection03);
                }
            }
            #endregion

            #region Snippet:VerifyAndIdentifyFromLargePersonGroup_Train
            var operation = groupClient.Train(WaitUntil.Completed, groupId);
            operation.WaitForCompletionResponse();
            #endregion

            var faceClient = CreateClient();
            var detectResponse = faceClient.Detect(new Uri(FaceTestConstant.UrlFamily1Dad3Image), FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
            var faceId = detectResponse.Value[0].FaceId.Value;

            #region Snippet:VerifyAndIdentifyFromLargePersonGroup_Verify
            var verifyDadResponse = faceClient.VerifyFromLargePersonGroup(faceId, groupId, personIds["Bill"]);
            Console.WriteLine($"Is the detected face Bill? {verifyDadResponse.Value.IsIdentical} ({verifyDadResponse.Value.Confidence})");

            var verifyMomResponse = faceClient.VerifyFromLargePersonGroup(faceId, groupId, personIds["Clare"]);
            Console.WriteLine($"Is the detected face Clare? {verifyMomResponse.Value.IsIdentical} ({verifyMomResponse.Value.Confidence})");
            #endregion

            #region Snippet:VerifyAndIdentifyFromLargePersonGroup_Identify
            var identifyResponse = faceClient.IdentifyFromLargePersonGroup(new[] { faceId }, groupId);
            foreach (var candidate in identifyResponse.Value[0].Candidates)
            {
                var person = groupClient.GetPerson(groupId, candidate.PersonId);
                Console.WriteLine($"The detected face belongs to {person.Value.Name} ({candidate.Confidence})");
            }
            #endregion

            #region Snippet:VerifyAndIdentifyFromLargePersonGroup_DeleteLargePersonGroup
            groupClient.Delete(groupId);
            #endregion
        }
    }
}