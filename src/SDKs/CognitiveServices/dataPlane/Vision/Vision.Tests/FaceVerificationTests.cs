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

                IFaceAPI client = GetClient(HttpMockServer.CreateInstance());

                string faceId1 = null;
                string faceId2 = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                {
                    faceId1 = client.Face.DetectInStream(stream, true)[0].FaceId;
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare1.png"), FileMode.Open))
                {
                    faceId2 = client.Face.DetectInStream(stream, true)[0].FaceId;
                }

                VerifyResult verifyResult = client.Face.Verify(faceId1, faceId2);
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

                IFaceAPI client = GetClient(HttpMockServer.CreateInstance());

                string faceId1 = null;
                string faceId2 = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                {
                    faceId1 = client.Face.DetectInStream(stream, true)[0].FaceId;
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare2.png"), FileMode.Open))
                {
                    faceId2 = client.Face.DetectInStream(stream, true)[0].FaceId;
                }

                VerifyResult verifyResult = client.Face.Verify(faceId1, faceId2);
                Assert.True(verifyResult.Confidence < 0.3);
                Assert.False(verifyResult.IsIdentical);
            }
        }

        [Fact]
        public void FaceVerificationPersonGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationNegative");

                IFaceAPI client = GetClient(HttpMockServer.CreateInstance());
                string faceId1 = null;
                string faceId2 = null;
                string personGroupId = "123";

                client.PersonGroup.Create(personGroupId, "fakePersonGroup");
                try
                {
                    CreatePersonResult createPersonResult = client.Person.Create(personGroupId, "David");
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                    {
                        client.Person.AddPersonFaceFromStream(personGroupId, createPersonResult.PersonId, stream);
                    }

                    client.PersonGroup.Train(personGroupId);

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare1.png"), FileMode.Open))
                    {
                        faceId2 = client.Face.DetectInStream(stream, true)[0].FaceId;
                    }

                    VerifyResult verifyResult = client.Face.VerifyWithPersonGroup(faceId2, createPersonResult.PersonId, personGroupId);
                    Assert.True(verifyResult.Confidence > 0.7);
                    Assert.True(verifyResult.IsIdentical);
                }
                finally
                {
                    client.PersonGroup.Delete(personGroupId);
                }
            }
        }
    }
}
