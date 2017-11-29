using FaceSDK.Tests;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

                IFaceAPI client = GetFaceClient(HttpMockServer.CreateInstance());
                string faceId1 = null;
                string personGroupId = "1234";
                client.PersonGroup.CreateAsync(personGroupId, "fakePersonGroup").Wait();
                try
                {
                    CreatePersonResult satyaPerson = client.Person.CreateAsync(personGroupId, "Satya").Result;
                    CreatePersonResult gatesPerson = client.Person.CreateAsync(personGroupId, "Gates").Result;
                    AddPersonFace(client, personGroupId, satyaPerson.PersonId, "Satya");
                    AddPersonFace(client, personGroupId, gatesPerson.PersonId, "Gates");
                    client.PersonGroup.TrainAsync(personGroupId).Wait();

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                    {
                        faceId1 = client.Face.DetectInStreamAsync(stream, true).Result[0].FaceId;
                    }

                    IList<IdentifyResultItem> identificationResults = client.Face.IdentifyAsync(personGroupId, new List<string> { faceId1 }).Result;
                    Assert.Equal(1, identificationResults.Count);
                    Assert.Equal(satyaPerson.PersonId, identificationResults[0].Candidates[0].PersonId);
                    Assert.True(identificationResults[0].Candidates[0].Confidence > 0.5);
                }
                finally
                {
                    client.PersonGroup.DeleteAsync(personGroupId);
                }
            }
        }

        private void AddPersonFace(IFaceAPI client, string personGroupId, string personId, string fileName)
        {
            for (int i = 1; i < 4; i++)
            {
                DetectedFace face = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    face = client.Face.DetectInStreamAsync(stream, true).Result[0];
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", fileName + i + ".jpg"), FileMode.Open))
                {
                    client.Person.AddPersonFaceFromStreamAsync(personGroupId, personId, stream, null, new List<int>{
                        face.FaceRectangle.Left,
                        face.FaceRectangle.Top,
                        face.FaceRectangle.Width,
                        face.FaceRectangle.Height }).Wait();
                }
            }
        }
    }
}
