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
    public class FaceIdentifyTests : BaseTests
    {
        [Fact]
        public void FaceIdentificationPersonGroupPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceIdentificationPersonGroupPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId1 = null;
                string personGroupId = "person-group-id";
                client.PersonGroup.CreateAsync(personGroupId, "fakePersonGroup").Wait();
                try
                {
                    Person satyaPerson = client.PersonGroupPerson.CreateAsync(personGroupId, "Satya").Result;
                    Person gatesPerson = client.PersonGroupPerson.CreateAsync(personGroupId, "Gates").Result;
                    AddPersonGroupPersonFace(client, personGroupId, satyaPerson.PersonId, "Satya");
                    AddPersonGroupPersonFace(client, personGroupId, gatesPerson.PersonId, "Gates");
                    client.PersonGroup.TrainAsync(personGroupId).Wait();

                    var trainingStatus = WaitForPersonGroupTraining(client, personGroupId);
                    Assert.Equal(TrainingStatusType.Succeeded, trainingStatus.Status);

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                    {
                        faceId1 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                        Assert.NotNull(faceId1);
                    }

                    IList<IdentifyResult> identificationResults = client.Face.IdentifyAsync(new List<Guid> { faceId1.Value }, personGroupId).Result;
                    Assert.Equal(1, identificationResults.Count);
                    Assert.Equal(satyaPerson.PersonId, identificationResults[0].Candidates[0].PersonId);
                    Assert.True(identificationResults[0].Candidates[0].Confidence > 0.5);
                }
                finally
                {
                    client.PersonGroup.DeleteAsync(personGroupId).Wait();
                }
            }
        }

        [Fact]
        public void FaceIdentificationLargePersonGroupPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceIdentificationLargePersonGroupPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId1 = null;
                string largePersonGroupId = "large-person-group-id";
                client.LargePersonGroup.CreateAsync(largePersonGroupId, "fakeLargePersonGroup").Wait();
                try
                {
                    Person satyaPerson = client.LargePersonGroupPerson.CreateAsync(largePersonGroupId, "Satya").Result;
                    Person gatesPerson = client.LargePersonGroupPerson.CreateAsync(largePersonGroupId, "Gates").Result;
                    AddLargePersonGroupPersonFace(client, largePersonGroupId, satyaPerson.PersonId, "Satya");
                    AddLargePersonGroupPersonFace(client, largePersonGroupId, gatesPerson.PersonId, "Gates");
                    client.LargePersonGroup.TrainAsync(largePersonGroupId).Wait();

                    var trainingStatus = WaitForLargePersonGroupTraining(client, largePersonGroupId);
                    Assert.Equal(TrainingStatusType.Succeeded, trainingStatus.Status);

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                    {
                        faceId1 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                        Assert.NotNull(faceId1);
                    }

                    IList<IdentifyResult> identificationResults = client.Face.IdentifyAsync(new List<Guid> { faceId1.Value }, largePersonGroupId: largePersonGroupId).Result;
                    Assert.Equal(1, identificationResults.Count);
                    Assert.Equal(satyaPerson.PersonId, identificationResults[0].Candidates[0].PersonId);
                    Assert.True(identificationResults[0].Candidates[0].Confidence > 0.5);
                }
                finally
                {
                    client.LargePersonGroup.DeleteAsync(largePersonGroupId).Wait();
                }
            }
        }

        private void AddPersonGroupPersonFace(IFaceClient client, string personGroupId, Guid personId, string fileName)
        {
            for (int i = 1; i < 4; i++)
            {
                DetectedFace face = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    face = client.Face.DetectWithStreamAsync(stream, true).Result[0];
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    client.PersonGroupPerson.AddFaceFromStreamAsync(personGroupId, personId, stream, null, new List<int>{
                        face.FaceRectangle.Left,
                        face.FaceRectangle.Top,
                        face.FaceRectangle.Width,
                        face.FaceRectangle.Height }).Wait();
                }
            }
        }

        private void AddLargePersonGroupPersonFace(IFaceClient client, string largePersonGroupId, Guid personId, string fileName)
        {
            for (int i = 1; i < 4; i++)
            {
                DetectedFace face = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    face = client.Face.DetectWithStreamAsync(stream, true).Result[0];
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    client.LargePersonGroupPerson.AddFaceFromStreamAsync(largePersonGroupId, personId, stream, null, new List<int>{
                        face.FaceRectangle.Left,
                        face.FaceRectangle.Top,
                        face.FaceRectangle.Width,
                        face.FaceRectangle.Height }).Wait();
                }
            }
        }

        private TrainingStatus WaitForLargePersonGroupTraining(
            IFaceClient client,
            string largePersonGroupId,
            int timeIntervalInMilliSeconds = 1000)
        {
            var trainingStatus = client.LargePersonGroup.GetTrainingStatusAsync(largePersonGroupId).Result;

            while (trainingStatus?.Status != null
                   && !trainingStatus.Status.Equals(TrainingStatusType.Succeeded)
                   && !trainingStatus.Status.Equals(TrainingStatusType.Failed))
            {
                Thread.Sleep(timeIntervalInMilliSeconds);

                trainingStatus = client.LargePersonGroup.GetTrainingStatusAsync(largePersonGroupId).Result;
            }

            return trainingStatus;
        }

        private TrainingStatus WaitForPersonGroupTraining(
            IFaceClient client,
            string personGroupId,
            int timeIntervalInMilliSeconds = 1000)
        {
            var trainingStatus = client.PersonGroup.GetTrainingStatusAsync(personGroupId).Result;

            while (trainingStatus?.Status != null
                   && !trainingStatus.Status.Equals(TrainingStatusType.Succeeded)
                   && !trainingStatus.Status.Equals(TrainingStatusType.Failed))
            {
                Thread.Sleep(timeIntervalInMilliSeconds);

                trainingStatus = client.PersonGroup.GetTrainingStatusAsync(personGroupId).Result;
            }

            return trainingStatus;
        }
    }
}
