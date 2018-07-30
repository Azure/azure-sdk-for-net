﻿using Microsoft.Azure.CognitiveServices.Vision.Face;
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
        public void FaceVerificationPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationPositive");

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
        public void FaceVerificationNegative()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationNegative");

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
        public void FaceVerificationNegative2()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceVerificationNegative2");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                Guid? faceId2 = null;
                string personGroupId = "123";

                client.PersonGroup.CreateAsync(personGroupId, "fakePersonGroup").Wait();
                try
                {
                    Person createPersonResult = client.PersonGroupPerson.CreateAsync(personGroupId, "David").Result;
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationBase1.png"), FileMode.Open))
                    {
                        client.PersonGroupPerson.AddPersonFaceFromStreamAsync(personGroupId, createPersonResult.PersonId, stream).Wait();
                    }

                    client.PersonGroup.TrainAsync(personGroupId).Wait();

                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "verificationCompare1.png"), FileMode.Open))
                    {
                        faceId2 = client.Face.DetectWithStreamAsync(stream, true).Result[0].FaceId;
                    }

                    Assert.NotNull(faceId2);
                    VerifyResult verifyResult = client.Face.VerifyFaceToPersonAsync(faceId2.Value, personGroupId, createPersonResult.PersonId).Result;
                    Assert.True(verifyResult.Confidence > 0.7);
                    Assert.True(verifyResult.IsIdentical);
                }
                finally
                {
                    client.PersonGroup.DeleteAsync(personGroupId).Wait();
                }
            }
        }
    }
}
