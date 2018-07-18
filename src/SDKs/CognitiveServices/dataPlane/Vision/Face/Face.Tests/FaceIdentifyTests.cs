using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace FaceSDK.Tests
{
    public class FaceIdentifyTests : BaseTests
    {
        [Fact]
        public void FaceIdentificationPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceIdentificationPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId1 = null;
                string personGroupId = "1234";
                client.PersonGroup.CreateAsync(personGroupId, "fakePersonGroup").Wait();
                try
                {
                    Person satyaPerson = client.PersonGroupPerson.CreateAsync(personGroupId, "Satya").Result;
                    Person gatesPerson = client.PersonGroupPerson.CreateAsync(personGroupId, "Gates").Result;
                    AddPersonFace(client, personGroupId, satyaPerson.PersonId, "Satya");
                    AddPersonFace(client, personGroupId, gatesPerson.PersonId, "Gates");
                    client.PersonGroup.TrainAsync(personGroupId).Wait();

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                    {
                        faceId1 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                        Assert.NotNull(faceId1);
                    }

                    IList<IdentifyResult> identificationResults = client.Face.IdentifyAsync(personGroupId, new List<Guid> { faceId1.Value }).Result;
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

        private void AddPersonFace(IFaceClient client, string personGroupId, Guid personId, string fileName)
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
                    client.PersonGroupPerson.AddPersonFaceFromStreamAsync(personGroupId, personId, stream, null, new List<int>{
                        face.FaceRectangle.Left,
                        face.FaceRectangle.Top,
                        face.FaceRectangle.Width,
                        face.FaceRectangle.Height }).Wait();
                }
            }
        }
    }
}
