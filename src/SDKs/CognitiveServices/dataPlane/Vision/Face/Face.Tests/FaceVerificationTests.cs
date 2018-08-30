using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.IO;
using Xunit;

namespace FaceSDK.Tests
{
    public class FaceVerificationTests : BaseTests
    {
        [Fact]
        public void FaceVerificationFacePositive()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationFacePositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());

                Guid? faceId1 = null;
                Guid? faceId2 = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                {
                    faceId1 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare1.png"), FileMode.Open))
                {
                    faceId2 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                }

                Assert.NotNull(faceId1);
                Assert.NotNull(faceId2);
                VerifyResult verifyResult = client.Face.VerifyFaceToFaceAsync(faceId1.Value, faceId2.Value).Result;
                Assert.True(verifyResult.Confidence > 0.7);
                Assert.True(verifyResult.IsIdentical);
            }
        }

        [Fact]
        public void FaceVerificationPersonGroupPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationPersonGroupPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId2 = null;
                string personGroupId = "person-group-id";

                client.PersonGroup.CreateAsync(personGroupId, "fakePersonGroup").Wait();
                try
                {
                    Person createPersonResult = client.PersonGroupPerson.CreateAsync(personGroupId, "David").Result;
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                    {
                        client.PersonGroupPerson.AddFaceFromStreamAsync(personGroupId, createPersonResult.PersonId, stream).Wait();
                    }

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare1.png"), FileMode.Open))
                    {
                        faceId2 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                    }

                    Assert.NotNull(faceId2);
                    VerifyResult verifyResult = client.Face.VerifyFaceToPersonAsync(faceId2.Value, createPersonResult.PersonId, personGroupId).Result;
                    Assert.True(verifyResult.Confidence > 0.7);
                    Assert.True(verifyResult.IsIdentical);
                }
                finally
                {
                    client.PersonGroup.DeleteAsync(personGroupId).Wait();
                }
            }
        }

        [Fact]
        public void FaceVerificationLargePersonGroupPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationLargePersonGroupPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId2 = null;
                string largePersonGroupId = "large-person-group-id";

                client.LargePersonGroup.CreateAsync(largePersonGroupId, "fakeLargePersonGroup").Wait();
                try
                {
                    Person createPersonResult = client.LargePersonGroupPerson.CreateAsync(largePersonGroupId, "David").Result;
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                    {
                        client.LargePersonGroupPerson.AddFaceFromStreamAsync(largePersonGroupId, createPersonResult.PersonId, stream).Wait();
                    }

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare1.png"), FileMode.Open))
                    {
                        faceId2 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                    }

                    Assert.NotNull(faceId2);
                    VerifyResult verifyResult = client.Face.VerifyFaceToPersonAsync(faceId2.Value, createPersonResult.PersonId, largePersonGroupId: largePersonGroupId).Result;
                    Assert.True(verifyResult.Confidence > 0.7);
                    Assert.True(verifyResult.IsIdentical);
                }
                finally
                {
                    client.LargePersonGroup.DeleteAsync(largePersonGroupId).Wait();
                }
            }
        }

        [Fact]
        public void FaceVerificationFaceNegative()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationFaceNegative");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());

                Guid? faceId1 = null;
                Guid? faceId2 = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                {
                    faceId1 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare2.png"), FileMode.Open))
                {
                    faceId2 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                }

                Assert.NotNull(faceId1);
                Assert.NotNull(faceId2);
                VerifyResult verifyResult = client.Face.VerifyFaceToFaceAsync(faceId1.Value, faceId2.Value).Result;
                Assert.True(verifyResult.Confidence < 0.3);
                Assert.False(verifyResult.IsIdentical);
            }
        }

        [Fact]
        public void FaceVerificationPersonGroupNegative()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationPersonGroupNegative");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId2 = null;
                string personGroupId = "person-group-id";

                client.PersonGroup.CreateAsync(personGroupId, "fakePersonGroup").Wait();
                try
                {
                    Person createPersonResult = client.PersonGroupPerson.CreateAsync(personGroupId, "David").Result;
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                    {
                        client.PersonGroupPerson.AddFaceFromStreamAsync(personGroupId, createPersonResult.PersonId, stream).Wait();
                    }

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare2.png"), FileMode.Open))
                    {
                        faceId2 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                    }

                    Assert.NotNull(faceId2);
                    VerifyResult verifyResult = client.Face.VerifyFaceToPersonAsync(faceId2.Value, createPersonResult.PersonId, personGroupId).Result;
                    Assert.True(verifyResult.Confidence < 0.3);
                    Assert.False(verifyResult.IsIdentical);
                }
                finally
                {
                    client.PersonGroup.DeleteAsync(personGroupId).Wait();
                }
            }
        }

        [Fact]
        public void FaceVerificationLargePersonGroupNegative()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationLargePersonGroupNegative");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId2 = null;
                string largePersonGroupId = "large-person-group-id";

                client.LargePersonGroup.CreateAsync(largePersonGroupId, "fakeLargePersonGroup").Wait();
                try
                {
                    Person createPersonResult = client.LargePersonGroupPerson.CreateAsync(largePersonGroupId, "David").Result;
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                    {
                        client.LargePersonGroupPerson.AddFaceFromStreamAsync(largePersonGroupId, createPersonResult.PersonId, stream).Wait();
                    }

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare2.png"), FileMode.Open))
                    {
                        faceId2 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                    }

                    Assert.NotNull(faceId2);
                    VerifyResult verifyResult = client.Face.VerifyFaceToPersonAsync(faceId2.Value, createPersonResult.PersonId, largePersonGroupId: largePersonGroupId).Result;
                    Assert.True(verifyResult.Confidence < 0.3);
                    Assert.False(verifyResult.IsIdentical);
                }
                finally
                {
                    client.LargePersonGroup.DeleteAsync(largePersonGroupId).Wait();
                }
            }
        }
    }
}
