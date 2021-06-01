﻿using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ComputerVisionSDK.Tests
{
    public class VisionDomainModelTests : BaseTests
    {
        [Fact]
        public void AnalyzeCelebritiesDomainImageInStreamTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AnalyzeCelebritiesDomainImageInStreamTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("satya.jpg"), FileMode.Open))
                {
                    DomainModelResults results = client.AnalyzeImageByDomainInStreamAsync("celebrities", stream).Result;

                    Assert.Matches("^\\d{4}-\\d{2}-\\d{2}(-preview)?$", results.ModelVersion);
                    var jobject = results.Result as JObject;
                    Assert.NotNull(jobject);

                    var celebrities = jobject.ToObject<CelebrityResults>();
                    Assert.NotNull(celebrities);
                    Assert.Equal(1, celebrities.Celebrities.Count);

                    var celebrity = celebrities.Celebrities[0];
                    Assert.Equal("Satya Nadella", celebrity.Name);
                    Assert.True(celebrity.Confidence > 0.96);
                    Assert.True(celebrity.FaceRectangle.Width > 0);
                    Assert.True(celebrity.FaceRectangle.Height > 0);
                }
            }
        }

        [Fact]
        public void AnalyzeCelebritiesDomainImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AnalyzeCelebritiesDomainTest");

                string celebrityUrl = GetTestImageUrl("satya.jpg");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    DomainModelResults results = client.AnalyzeImageByDomainAsync("celebrities", celebrityUrl).Result;

                    Assert.Matches("^\\d{4}-\\d{2}-\\d{2}(-preview)?$", results.ModelVersion);
                    var jobject = results.Result as JObject;
                    Assert.NotNull(jobject);

                    var celebrities = jobject.ToObject<CelebrityResults>();
                    Assert.NotNull(celebrities);
                    Assert.Equal(1, celebrities.Celebrities.Count);

                    var celebrity = celebrities.Celebrities[0];
                    Assert.Equal("Satya Nadella", celebrity.Name);
                    Assert.True(celebrity.Confidence > 0.96);
                    Assert.True(celebrity.FaceRectangle.Width > 0);
                    Assert.True(celebrity.FaceRectangle.Height > 0);
                }
            }
        }

        [Fact]
        public void AnalyzeLandmarksDomainImageTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AnalyzeLandmarksDomainImageTest");

                string landmarksUrl = GetTestImageUrl("spaceneedle.jpg");
                const string Portuguese = "pt";

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                {
                    DomainModelResults results = client.AnalyzeImageByDomainAsync("landmarks", landmarksUrl, Portuguese).Result;

                    Assert.Matches("^\\d{4}-\\d{2}-\\d{2}(-preview)?$", results.ModelVersion);
                    var jobject = results.Result as JObject;
                    Assert.NotNull(jobject);

                    var landmarks = jobject.ToObject<LandmarkResults>();
                    Assert.NotNull(landmarks);
                    Assert.Equal(1, landmarks.Landmarks.Count);

                    var landmark = landmarks.Landmarks[0];
                    Assert.Equal("Obelisco Espacial", landmark.Name);
                    Assert.True(landmark.Confidence > 0.99);
                }
            }
        }

        [Fact]
        public void AnalyzeImageByDomainModelVersionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "AnalyzeImageByDomainModelVersionTest");

                using (IComputerVisionClient client = GetComputerVisionClient(HttpMockServer.CreateInstance()))
                using (FileStream stream = new FileStream(GetTestImagePath("satya.jpg"), FileMode.Open))
                {
                    const string targetModelVersion = "2021-04-01";

                    DomainModelResults results = client.AnalyzeImageByDomainInStreamAsync(
                        "celebrities",
                        stream,
                        modelVersion: targetModelVersion).Result;

                    Assert.Equal(targetModelVersion, results.ModelVersion);
                }
            }
        }
    }
}
