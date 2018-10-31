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
    public class FaceFindSimilarTests : BaseTests
    {
        [Fact]
        public void FaceFindSimilarFacePositive()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceFindSimilarFacePositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId1 = null;
                var faceIds = new List<Guid?>();
                var satyaFaceIds = AddFaceArrayFace(client, "Satya");
                var gatesFaceIds = AddFaceArrayFace(client, "Gates");
                faceIds.AddRange(satyaFaceIds);
                faceIds.AddRange(gatesFaceIds);

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                {
                    faceId1 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                    Assert.NotNull(faceId1);
                }

                IList<SimilarFace> findSimilarResults = client.Face.FindSimilarAsync(faceId1.Value, faceIds: faceIds).Result;
                Assert.True(findSimilarResults.Count > 0);
                Assert.Contains(findSimilarResults[0].FaceId, satyaFaceIds);
                Assert.True(findSimilarResults[0].Confidence > 0.5);
            }
        }

        [Fact]
        public void FaceFindSimilarFaceListPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceFindSimilarFaceListPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId1 = null;
                string faceListId = "face-list-id";
                client.FaceList.CreateAsync(faceListId, "fakeFaceList").Wait();
                try
                {
                    var satyaPersistedFaceIds = AddFaceListFace(client, faceListId, "Satya");
                    var gatesPersistedFaceIds = AddFaceListFace(client, faceListId, "Gates");

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                    {
                        faceId1 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                        Assert.NotNull(faceId1);
                    }

                    IList<SimilarFace> findSimilarResults = client.Face.FindSimilarAsync(faceId1.Value, faceListId: faceListId).Result;
                    Assert.True(findSimilarResults.Count > 0);
                    Assert.Contains(findSimilarResults[0].PersistedFaceId, satyaPersistedFaceIds);
                    Assert.True(findSimilarResults[0].Confidence > 0.5);
                }
                finally
                {
                    client.FaceList.DeleteAsync(faceListId).Wait();
                }
            }
        }

        [Fact]
        public void FaceFindSimilarLargeFaceListPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceFindSimilarLargeFaceListPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId1 = null;
                string largeFaceListId = "large-face-list-id";
                client.LargeFaceList.CreateAsync(largeFaceListId, "fakeLargeFaceList").Wait();
                try
                {
                    var satyaPersistedFaceIds = AddLargeFaceListFace(client, largeFaceListId, "Satya");
                    var gatesPersistedFaceIds = AddLargeFaceListFace(client, largeFaceListId, "Gates");
                    client.LargeFaceList.TrainAsync(largeFaceListId).Wait();

                    var trainingStatus = WaitForTraining(client, largeFaceListId);
                    Assert.Equal(TrainingStatusType.Succeeded, trainingStatus.Status);

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                    {
                        faceId1 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
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
                    face = client.Face.DetectWithStreamAsync(stream, true).Result[0];
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    var persistedFace = client.FaceList.AddFaceFromStreamAsync(faceListId, stream, null, new List<int>{
                        face.FaceRectangle.Left,
                        face.FaceRectangle.Top,
                        face.FaceRectangle.Width,
                        face.FaceRectangle.Height }).Result;

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
                    face = client.Face.DetectWithStreamAsync(stream, true).Result[0];
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    var persistedFace = client.LargeFaceList.AddFaceFromStreamAsync(largeFaceListId, stream, null, new List<int>{
                        face.FaceRectangle.Left,
                        face.FaceRectangle.Top,
                        face.FaceRectangle.Width,
                        face.FaceRectangle.Height }).Result;

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
                    face = client.Face.DetectWithStreamAsync(stream).Result[0];
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
