using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Xunit;

namespace FaceSDK.Tests
{
    public class FacePersonDirectoryTests : BaseTests
    {
        private static readonly string detectionModel = DetectionModel.Detection01;

        private static readonly string recognitionModel = RecognitionModel.Recognition02;

        [Fact]
        public void FacePersonDirectoryCreatePersonPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FacePersonDirectoryPersonPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());

                var person = new EnrolledPerson
                {
                    Name = "Person",
                    UserData = "UserData"
                };
                var personId = client.PersonDirectory.CreatePersonAsync(person).Result.PersonId;
                Assert.NotNull(personId);

                try
                {
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                    {
                        var faceId1 = client.PersonDirectory.AddPersonFaceFromStreamAsync(personId.ToString(), recognitionModel, stream, detectionModel).Result.PersistedFaceId;
                        Assert.NotNull(faceId1);
                    }
                }
                finally
                {
                    client.PersonDirectory.DeletePersonAsync(personId.ToString()).Wait();
                }
            }
        }

        [Fact]
        public void FacePersonDirectoryCreateDynamicPersonGroupPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FaceFindSimilarLargeFaceListPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId1 = null;
                string largeFaceListId = "large-face-list-id";
                client.LargeFaceList.CreateAsync(largeFaceListId, "fakeLargeFaceList", recognitionModel: recognitionModel).Wait();
                try
                {
                    var satyaPersistedFaceIds = AddLargeFaceListFace(client, largeFaceListId, "Satya");
                    var gatesPersistedFaceIds = AddLargeFaceListFace(client, largeFaceListId, "Gates");
                    client.LargeFaceList.TrainAsync(largeFaceListId).Wait();

                    var trainingStatus = WaitForTraining(client, largeFaceListId);
                    Assert.Equal(TrainingStatusType.Succeeded, trainingStatus.Status);

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                    {
                        faceId1 = client.Face.DetectWithStreamAsync(stream, true, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0].FaceId;
                        Assert.NotNull(faceId1);
                    }

                    IList<SimilarFace> findSimilarResults = client.Face.FindSimilarAsync(faceId1.Value, largeFaceListId: largeFaceListId).Result;
                    Assert.True(findSimilarResults.Count > 0);
                    Assert.Contains(findSimilarResults[0].PersistedFaceId, satyaPersistedFaceIds);
                    Assert.True(findSimilarResults[0].Confidence > 0.5);
                }
                finally
                {
                    client.LargeFaceList.DeleteAsync(largeFaceListId).Wait();
                }
            }
        }

        private List<Guid?> AddFaceListFace(IFaceClient client, string faceListId, string fileName)
        {
            var persistedFaceIds = new List<Guid?>();
            for (int i = 1; i < 4; i++)
            {
                DetectedFace face = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    face = client.Face.DetectWithStreamAsync(stream, true, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0];
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    var persistedFace = client.FaceList.AddFaceFromStreamAsync(faceListId, stream, null, new List<int>{
                        face.FaceRectangle.Left,
                        face.FaceRectangle.Top,
                        face.FaceRectangle.Width,
                        face.FaceRectangle.Height },
                        detectionModel: detectionModel).Result;

                    persistedFaceIds.Add(persistedFace.PersistedFaceId);
                }
            }

            return persistedFaceIds;
        }

        private List<Guid?> AddLargeFaceListFace(IFaceClient client, string largeFaceListId, string fileName)
        {
            var persistedFaceIds = new List<Guid?>();
            for (int i = 1; i < 4; i++)
            {
                DetectedFace face = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    face = client.Face.DetectWithStreamAsync(stream, true, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0];
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    var persistedFace = client.LargeFaceList.AddFaceFromStreamAsync(largeFaceListId, stream, null, new List<int>{
                        face.FaceRectangle.Left,
                        face.FaceRectangle.Top,
                        face.FaceRectangle.Width,
                        face.FaceRectangle.Height },
                        detectionModel: detectionModel).Result;

                    persistedFaceIds.Add(persistedFace.PersistedFaceId);
                }
            }

            return persistedFaceIds;
        }

        private List<Guid?> AddFaceArrayFace(IFaceClient client, string fileName)
        {
            var faceIdList = new List<Guid?>();
            for (int i = 1; i < 4; i++)
            {
                DetectedFace face = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    face = client.Face.DetectWithStreamAsync(stream, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0];
                }

                faceIdList.Add(face.FaceId);
            }

            return faceIdList;
        }

        private TrainingStatus WaitForTraining(
            IFaceClient client,
            string largeFaceListId,
            int timeIntervalInMilliSeconds = 1000)
        {
            var trainingStatus = client.LargeFaceList.GetTrainingStatusAsync(largeFaceListId).Result;

            while (trainingStatus?.Status != null
                   && !trainingStatus.Status.Equals(TrainingStatusType.Succeeded)
                   && !trainingStatus.Status.Equals(TrainingStatusType.Failed))
            {
                Thread.Sleep(timeIntervalInMilliSeconds);

                trainingStatus = client.LargeFaceList.GetTrainingStatusAsync(largeFaceListId).Result;
            }

            return trainingStatus;
        }
    }
}
