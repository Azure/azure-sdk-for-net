using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace FaceSDK.Tests
{
    public class FaceVerificationTests : BaseTests
    {
        [Fact]
        public void FaceVerificationPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationPositive");

                IFaceAPI client = GetFaceClient(HttpMockServer.CreateInstance());

                string faceId1 = null;
                string faceId2 = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                {
                    faceId1 = client.Face.DetectInStreamAsync(stream, true).Result[0].FaceId;
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare1.png"), FileMode.Open))
                {
                    faceId2 = client.Face.DetectInStreamAsync(stream, true).Result[0].FaceId;
                }

                VerifyResult verifyResult = client.Face.VerifyAsync(faceId1, faceId2).Result;
                Assert.True(verifyResult.Confidence > 0.7);
                Assert.True(verifyResult.IsIdentical);
            }
        }

        [Fact]
        public void FaceVerificationNegative()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationNegative");

                IFaceAPI client = GetFaceClient(HttpMockServer.CreateInstance());

                string faceId1 = null;
                string faceId2 = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                {
                    faceId1 = client.Face.DetectInStreamAsync(stream, true).Result[0].FaceId;
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare2.png"), FileMode.Open))
                {
                    faceId2 = client.Face.DetectInStreamAsync(stream, true).Result[0].FaceId;
                }

                VerifyResult verifyResult = client.Face.VerifyAsync(faceId1, faceId2).Result;
                Assert.True(verifyResult.Confidence < 0.3);
                Assert.False(verifyResult.IsIdentical);
            }
        }

        [Fact]
        public void FaceVerificationNegative2()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationNegative2");

                IFaceAPI client = GetFaceClient(HttpMockServer.CreateInstance());
                string faceId1 = null;
                string faceId2 = null;
                string personGroupId = "123";

                client.PersonGroup.CreateAsync(personGroupId, "fakePersonGroup").Wait();
                try
                {
                    CreatePersonResult createPersonResult = client.Person.CreateAsync(personGroupId, "David").Result;
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                    {
                        client.Person.AddPersonFaceFromStreamAsync(personGroupId, createPersonResult.PersonId, stream).Wait();
                    }

                    client.PersonGroup.TrainAsync(personGroupId).Wait();

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare1.png"), FileMode.Open))
                    {
                        faceId2 = client.Face.DetectInStreamAsync(stream, true).Result[0].FaceId;
                    }

                    VerifyResult verifyResult = client.Face.VerifyWithPersonGroupAsync(faceId2, createPersonResult.PersonId, personGroupId).Result;
                    Assert.True(verifyResult.Confidence > 0.7);
                    Assert.True(verifyResult.IsIdentical);
                }
                finally
                {
                    client.PersonGroup.DeleteAsync(personGroupId);
                }
            }
        }
    }
}
