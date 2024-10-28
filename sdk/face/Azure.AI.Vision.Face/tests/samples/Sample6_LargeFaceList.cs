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
    public partial class Sample6_LargeFaceList : FaceSamplesBase
    {
        [Test]
        public void FindSimilarFromLargeFaceList()
        {
            var listId = "lfl_family1";
            var listClient = CreateLargeFaceListClient(listId);

            #region Snippet:CreateLargeFaceList
            listClient.Create("Family 1", userData: "A sweet family", recognitionModel: FaceRecognitionModel.Recognition04);
            #endregion

            #region Snippet:AddFacesToLargeFaceList
            var faces = new[]
            {
                new { UserData = "Dad", ImageUrl = new Uri(FaceTestConstant.UrlFamily1Dad1Image) },
                new { UserData = "Mom", ImageUrl = new Uri(FaceTestConstant.UrlFamily1Mom1Image) },
                new { UserData = "Son", ImageUrl = new Uri(FaceTestConstant.UrlFamily1Son1Image) }
            };
            var faceIds = new Dictionary<Guid, string>();

            foreach (var face in faces)
            {
                var addFaceResponse = listClient.AddFace(face.ImageUrl, userData: face.UserData);
                faceIds[addFaceResponse.Value.PersistedFaceId] = face.UserData;
            }
            #endregion

            #region Snippet:TrainLargeFaceList
            var operation = listClient.Train(WaitUntil.Completed);
            operation.WaitForCompletionResponse();
            #endregion

            #region Snippet:FindSimilarFromLargeFaceList
            var faceClient = CreateClient();
            var detectResponse = faceClient.Detect(new Uri(FaceTestConstant.UrlFamily1Dad3Image), FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
            var faceId = detectResponse.Value[0].FaceId.Value;

            var findSimilarResponse = faceClient.FindSimilarFromLargeFaceList(faceId, listId);
            foreach (var similarFace in findSimilarResponse.Value)
            {
                Console.WriteLine($"The detected face is similar to the face with '{faceIds[similarFace.PersistedFaceId.Value]}' ID {similarFace.PersistedFaceId} ({similarFace.Confidence})");
            }
            #endregion

            #region Snippet:DeleteLargeFaceList
            listClient.Delete();
            #endregion
        }
    }
}
