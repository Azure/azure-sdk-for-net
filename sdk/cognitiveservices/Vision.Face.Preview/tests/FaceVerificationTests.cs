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
        private static readonly string detectionModel = DetectionModel.Detection01;

        private static readonly string recognitionModel = RecognitionModel.Recognition02;

        [Fact]
        public void FaceVerificationFacePositive()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FaceVerificationFacePositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());

                Guid? faceId1 = null;
                Guid? faceId2 = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                {
                    faceId1 = client.Face.DetectWithStreamAsync(stream, true, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0].FaceId;
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare1.png"), FileMode.Open))
                {
                    faceId2 = client.Face.DetectWithStreamAsync(stream, true, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0].FaceId;
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FaceVerificationPersonGroupPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId2 = null;
                string personGroupId = "person-group-id";

                client.PersonGroup.CreateAsync(personGroupId, "fakePersonGroup", recognitionModel: recognitionModel).Wait();
                try
                {
                    Person createPersonResult = client.PersonGroupPerson.CreateAsync(personGroupId, "David").Result;
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                    {
                        client.PersonGroupPerson.AddFaceFromStreamAsync(personGroupId, createPersonResult.PersonId, stream, detectionModel: detectionModel).Wait();
                    }

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare1.png"), FileMode.Open))
                    {
                        faceId2 = client.Face.DetectWithStreamAsync(stream, true, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0].FaceId;
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FaceVerificationLargePersonGroupPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId2 = null;
                string largePersonGroupId = "large-person-group-id";

                client.LargePersonGroup.CreateAsync(largePersonGroupId, "fakeLargePersonGroup", recognitionModel: recognitionModel).Wait();
                try
                {
                    Person createPersonResult = client.LargePersonGroupPerson.CreateAsync(largePersonGroupId, "David").Result;
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                    {
                        client.LargePersonGroupPerson.AddFaceFromStreamAsync(largePersonGroupId, createPersonResult.PersonId, stream, detectionModel: detectionModel).Wait();
                    }

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare1.png"), FileMode.Open))
                    {
                        faceId2 = client.Face.DetectWithStreamAsync(stream, true, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0].FaceId;
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FaceVerificationFaceNegative");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());

                Guid? faceId1 = null;
                Guid? faceId2 = null;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                {
                    faceId1 = client.Face.DetectWithStreamAsync(stream, true, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0].FaceId;
                }

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare2.png"), FileMode.Open))
                {
                    faceId2 = client.Face.DetectWithStreamAsync(stream, true, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0].FaceId;
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FaceVerificationPersonGroupNegative");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId2 = null;
                string personGroupId = "person-group-id";

                client.PersonGroup.CreateAsync(personGroupId, "fakePersonGroup", recognitionModel: recognitionModel).Wait();
                try
                {
                    Person createPersonResult = client.PersonGroupPerson.CreateAsync(personGroupId, "David").Result;
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                    {
                        client.PersonGroupPerson.AddFaceFromStreamAsync(personGroupId, createPersonResult.PersonId, stream, detectionModel: detectionModel).Wait();
                    }

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare2.png"), FileMode.Open))
                    {
                        faceId2 = client.Face.DetectWithStreamAsync(stream, true, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0].FaceId;
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FaceVerificationLargePersonGroupNegative");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId2 = null;
                string largePersonGroupId = "large-person-group-id";

                client.LargePersonGroup.CreateAsync(largePersonGroupId, "fakeLargePersonGroup", recognitionModel: recognitionModel).Wait();
                try
                {
                    Person createPersonResult = client.LargePersonGroupPerson.CreateAsync(largePersonGroupId, "David").Result;
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                    {
                        client.LargePersonGroupPerson.AddFaceFromStreamAsync(largePersonGroupId, createPersonResult.PersonId, stream, detectionModel: detectionModel).Wait();
                    }

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare2.png"), FileMode.Open))
                    {
                        faceId2 = client.Face.DetectWithStreamAsync(stream, true, detectionModel: detectionModel, recognitionModel: recognitionModel).Result[0].FaceId;
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
